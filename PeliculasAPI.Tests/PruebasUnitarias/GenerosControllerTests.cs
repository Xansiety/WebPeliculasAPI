using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PeliculasAPI.Controllers;
using PeliculasAPI.DTOs.Genero;
using PeliculasAPI.Models;
using PeliculasAPI.Tests.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PeliculasAPI.Tests.PruebasUnitarias
{
    [TestClass]
    public class GenerosControllerTests : BasePruebas
    {
        [TestMethod]
        public async Task ObtenerTodosLosGeneros()
        {
            //preparacion
            var nombreDB = Guid.NewGuid().ToString();
            var context = ConstruirContext(nombreDB);
            var mapper = ConfigurarAutoMapper();

            context.Generos.Add(new Genero() { Nombre = "Genero 1" });
            context.Generos.Add(new Genero() { Nombre = "Genero 2" });
            await context.SaveChangesAsync();

            var contexto2 = ConstruirContext(nombreDB);

            //ejecucion
            var controller = new GenerosController(contexto2, mapper);
            var respuesta = await controller.Get();

            //assert
            var generos = respuesta.Value;
            Assert.AreEqual(2, generos.Count());
        }


        [TestMethod]
        public async Task ObtenerGeneroPorIdNoExistente()
        {
            //preparacion
            var nombreDB = Guid.NewGuid().ToString();
            var context = ConstruirContext(nombreDB);
            var mapper = ConfigurarAutoMapper();

            //ejecucion
            var controller = new GenerosController(context, mapper);
            var respuesta = await controller.Get(1);

            //assert
            var resultado = respuesta.Result as StatusCodeResult;
            Assert.AreEqual(404, resultado.StatusCode);
        }


        [TestMethod]
        public async Task ObtenerGeneroPorIdExistente()
        {
            //preparacion
            var nombreDB = Guid.NewGuid().ToString();
            var context = ConstruirContext(nombreDB);
            var mapper = ConfigurarAutoMapper();

            context.Generos.Add(new Genero() { Nombre = "Genero 1" });
            context.Generos.Add(new Genero() { Nombre = "Genero 2" });
            await context.SaveChangesAsync();

            var contexto2 = ConstruirContext(nombreDB);
            //ejecucion
            var controller = new GenerosController(contexto2, mapper);
            var id = 1;
            var respuesta = await controller.Get(id);

            //assert
            var resultado = respuesta.Value;
            Assert.AreEqual(id, resultado.Id);
        }

        [TestMethod]
        public async Task CrearGenero()
        {
            //preparacion
            var nombreDB = Guid.NewGuid().ToString();
            var context = ConstruirContext(nombreDB);
            var mapper = ConfigurarAutoMapper();

            var nuevoGenero = new GeneroCreacionDTO() { Nombre = "Nuevo genero 1" };

            var controller = new GenerosController(context, mapper);
            var respuesta = await controller.Post(nuevoGenero);

            //assert
            var resultado = respuesta as CreatedAtRouteResult;
            Assert.IsNotNull(resultado); //si no es null, es un CreatedAtRouteResult

            var contexto2 = ConstruirContext(nombreDB);
            var cantidad = await contexto2.Generos.CountAsync();
            Assert.AreEqual(1, cantidad);
        }

        [TestMethod]
        public async Task ActualizarGenero()
        {
            //preparacion
            var nombreDB = Guid.NewGuid().ToString();
            var context = ConstruirContext(nombreDB);
            var mapper = ConfigurarAutoMapper();

            context.Generos.Add(new Genero() { Nombre = "genero 1" });
            await context.SaveChangesAsync();

            var contexto2 = ConstruirContext(nombreDB);
            var controller = new GenerosController(contexto2, mapper);

            var generoCreacionDTO = new GeneroCreacionDTO() { Nombre = "Nuevo genero 1" };
            var id = 1;
            var respuesta = await controller.Put(id, generoCreacionDTO);
            var resultado = respuesta as StatusCodeResult;
            Assert.AreEqual(204, resultado.StatusCode);

            var contexto3 = ConstruirContext(nombreDB);
            var existe = await contexto3.Generos.AnyAsync(x => x.Nombre == "Nuevo genero 1");
            Assert.IsTrue(existe);
        }

        [TestMethod]
        public async Task IntentaBorrarGeneroNoExistente()
        { //preparacion
            var nombreDB = Guid.NewGuid().ToString();
            var context = ConstruirContext(nombreDB);
            var mapper = ConfigurarAutoMapper();

            var controller = new GenerosController(context, mapper);

            var id = 1;
            var respuesta = await controller.Delete(id);

            var resultado = respuesta as StatusCodeResult;
            Assert.AreEqual(404, resultado.StatusCode); //assert
        }



        public async Task BorrarGeneroExistente()
        { //preparacion
            var nombreDB = Guid.NewGuid().ToString();
            var context = ConstruirContext(nombreDB);
            var mapper = ConfigurarAutoMapper();

            context.Generos.Add(new Genero() { Nombre = "genero 1" });
            await context.SaveChangesAsync();


            var contexto2 = ConstruirContext(nombreDB);
            var controller = new GenerosController(contexto2, mapper);

            var respuesta = await controller.Delete(1);
            var resultado = respuesta as StatusCodeResult;
            Assert.AreEqual(204, resultado.StatusCode); //assert

            var contexto3 = ConstruirContext(nombreDB);
            var existe = await contexto3.Generos.AnyAsync();
            Assert.IsFalse(existe);
        }
    }
}
