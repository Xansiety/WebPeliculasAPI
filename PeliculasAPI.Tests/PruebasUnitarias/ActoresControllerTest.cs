using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.JsonPatch.Operations;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.EntityFrameworkCore;
using Moq;
using PeliculasAPI.Controllers;
using PeliculasAPI.DTOs.Actor;
using PeliculasAPI.DTOs.Paginacion;
using PeliculasAPI.Models;
using PeliculasAPI.Servicios;
using PeliculasAPI.Tests.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PeliculasAPI.Tests.PruebasUnitarias
{
    [TestClass]
    public class ActoresControllerTest : BasePruebas
    {

        [TestMethod]
        public async Task ObtenerPersonasPaginadas()
        {
            var nombreDB = Guid.NewGuid().ToString();
            var context = ConstruirContext(nombreDB);
            var mapping = ConfigurarAutoMapper();

            context.Actores.Add(new Actor() { Nombre = "Actor 1" });
            context.Actores.Add(new Actor() { Nombre = "Actor 2" });
            context.Actores.Add(new Actor() { Nombre = "Actor 3" });

            await context.SaveChangesAsync();

            var context2 = ConstruirContext(nombreDB);
            var controller = new ActoresController(context2, mapping, null);
            controller.ControllerContext.HttpContext = new DefaultHttpContext(); //para metodos que necesiteos un contexthttp

            var pagina1 = await controller.Get(new PaginacionDTO() { Pagina = 1, CantidadRegistrosPorPagina = 2 });
            var actoresPagina1 = pagina1.Value;
            Assert.AreEqual(2, actoresPagina1.Count());



            //no podemos generar una cabera por lo que se crea oro context
            controller.ControllerContext.HttpContext = new DefaultHttpContext(); //para metodos que necesiteos un contexthttp
            var pagina2 = await controller.Get(new PaginacionDTO() { Pagina = 2, CantidadRegistrosPorPagina = 2 });
            var actoresPagina2 = pagina2.Value;
            Assert.AreEqual(1, actoresPagina2.Count());


            controller.ControllerContext.HttpContext = new DefaultHttpContext(); //para metodos que necesiteos un contexthttp
            var pagina3 = await controller.Get(new PaginacionDTO() { Pagina = 3, CantidadRegistrosPorPagina = 2 });
            var actoresPagina3 = pagina3.Value;
            Assert.AreEqual(0, actoresPagina3.Count());
        }

        [TestMethod]
        public async Task CrearActorSinFotos()
        {
            var nombreDB = Guid.NewGuid().ToString();
            var context = ConstruirContext(nombreDB);
            var mapping = ConfigurarAutoMapper();

            var actor = new ActorCreacionDTO() { Nombre = "Actor 1", FechaNacimiento = DateTime.Now };

            //moq para crear una clase auxiliar sin depender de una interfaz real
            var mock = new Mock<IAlmacenArchivos>();
            mock.Setup(x => x.GuadarArchivo(null, null, null, null)
            ).Returns(Task.FromResult("url"));

            var controller = new ActoresController(context, mapping, mock.Object);
            var repsuesta = await controller.Post(actor);
            var resultado = repsuesta as CreatedAtRouteResult;
            Assert.AreEqual(201, resultado.StatusCode);

            var context2 = ConstruirContext(nombreDB);
            var listado = await context2.Actores.ToListAsync();
            Assert.AreEqual(1, listado.Count());
            Assert.IsNull(listado.First().Foto); //la foto debe ser null

            //validar que el mock no fue llamado
            Assert.AreEqual(0, mock.Invocations.Count);
        }


        [TestMethod]
        public async Task CrearActorConFoto()
        {
            var nombreDB = Guid.NewGuid().ToString();
            var context = ConstruirContext(nombreDB);
            var mapping = ConfigurarAutoMapper();

            var content = Encoding.UTF8.GetBytes("Imagen creada de prueba");
            var archivo = new FormFile(new MemoryStream(content), 0, content.Length, "Data", "imagen.jpg");
            archivo.Headers = new HeaderDictionary();
            archivo.ContentType = "image/jpeg";

            var actor = new ActorCreacionDTO() { Nombre = "Actor 1", FechaNacimiento = DateTime.Now, Foto = archivo };

            var mock = new Mock<IAlmacenArchivos>();
            mock.Setup(x => x.GuadarArchivo(content, ".jpg", "actores", archivo.ContentType))
                .Returns(Task.FromResult("url"));

            var controller = new ActoresController(context, mapping, mock.Object);
            var repsuesta = await controller.Post(actor);
            var resultado = repsuesta as CreatedAtRouteResult;
            Assert.AreEqual(201, resultado.StatusCode);
            
            var context2 = ConstruirContext(nombreDB);
            var listado = await context2.Actores.ToListAsync();
            Assert.AreEqual(1, listado.Count());
            Assert.AreEqual("url", listado.First().Foto); //la foto debe ser null

            //validar que el mock fue llamado
            Assert.AreEqual(1, mock.Invocations.Count); 
        }

        [TestMethod]
        public async Task PatchRetorna404() {
            var nombreDB = Guid.NewGuid().ToString();
            var context = ConstruirContext(nombreDB);
            var mapping = ConfigurarAutoMapper();
            var controller = new ActoresController(context, mapping, null);
            //instanciar pathc document
            var patchDoc = new JsonPatchDocument<ActorPatchDTO>();
            var respuesta = await controller.Patch(1, patchDoc);
            var resultado = respuesta as NotFoundResult;
            Assert.AreEqual(404, resultado.StatusCode);
        }


        [TestMethod]
        public async Task PatchActualizaUnSoloCampo()
        {
            var nombreDB = Guid.NewGuid().ToString();
            var context = ConstruirContext(nombreDB);
            var mapping = ConfigurarAutoMapper();
            var controller = new ActoresController(context, mapping, null);
            //instanciar pathc document
            var fechaNacimiento = DateTime.Now;
            var actor = new Actor() { Nombre = "Actor 1", FechaNacimiento = fechaNacimiento };
            context.Add(actor);
            await context.SaveChangesAsync();

            var context2 = ConstruirContext(nombreDB); 

            var objectValidator = new Mock<IObjectModelValidator>();
            //pasamos class validator para que no valide nada, y siempre valide como positivo
            objectValidator.Setup(x => x.Validate(
                It.IsAny<ActionContext>(), 
                It.IsAny<ValidationStateDictionary>(),
                It.IsAny<string>(), 
                It.IsAny<object>()));

            controller.ObjectValidator = objectValidator.Object;
            var patchDoc = new JsonPatchDocument<ActorPatchDTO>();
            patchDoc.Operations.Add(new Operation<ActorPatchDTO>()
            {
                op = "replace",
                path = "/nombre",
                value = "Fernando"
            });

            var resp = await controller.Patch(1, patchDoc);
            var resultado = resp as StatusCodeResult;
            Assert.AreEqual(204, resultado.StatusCode);

            var context3 = ConstruirContext(nombreDB);
            var actorActualizado = await context3.Actores.FirstOrDefaultAsync();
            Assert.AreEqual("Fernando", actorActualizado.Nombre);
            Assert.AreEqual(fechaNacimiento, actorActualizado.FechaNacimiento);
        }
        
    }
}
