using AutoMapper;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PeliculasAPI.DTOs.Pelicula;
using PeliculasAPI.Helpers.PaginarResultados;
using PeliculasAPI.Models;
using PeliculasAPI.Servicios;
using System.Linq.Dynamic.Core;

namespace PeliculasAPI.Controllers
{
    [ApiController]
    [Route("api/peliculas")]
    public class PeliculasController : CustomBaseController
    {
        private readonly ApplicationDbContext context;
        private readonly ILogger<PeliculasController> logger;
        private readonly IMapper mapper;
        private readonly IAlmacenArchivos almacenArchivos;
        private readonly string contenedor = "peliculas";

        public PeliculasController(ApplicationDbContext context, ILogger<PeliculasController> logger, IMapper mapper, IAlmacenArchivos almacenArchivos): base(context, mapper)
        {
            this.context = context;
            this.logger = logger;
            this.mapper = mapper;
            this.almacenArchivos = almacenArchivos;
        }

        [HttpGet]
        public async Task<ActionResult<PeliculasIndexDTO>> Get()
        {
            var top = 5;
            var hoy = DateTime.Today;
            var proximosEstrenos = await context.Peliculas
                .Where(x => x.FechaEstreno > hoy)
                .OrderBy(x => x.FechaEstreno)
                .Take(top)
                .ToListAsync();

            var enCines = await context.Peliculas
                .Where(x => x.EnCines)
                .OrderBy(x => x.Titulo)
                .ToListAsync();

            var resultado = new PeliculasIndexDTO();
            resultado.FuturosEstrenos = mapper.Map<List<PeliculaDTO>>(proximosEstrenos);
            resultado.EnCines = mapper.Map<List<PeliculaDTO>>(enCines);

            return resultado;
            //var peliculas = await context.Peliculas.ToListAsync();
            //return mapper.Map<List<PeliculaDTO>>(peliculas);
        }

        [HttpGet("filtro")]
        public async Task<ActionResult<List<PeliculaDTO>>> Filtrar([FromQuery] FiltroPeliculaDTO filtroPeliculaDTO)
        {
            //ejecución diferida
            var peliculasQueryable = context.Peliculas.AsQueryable();

            if (!string.IsNullOrEmpty(filtroPeliculaDTO.Titulo))
            {
                peliculasQueryable = peliculasQueryable.Where(x => x.Titulo.Contains(filtroPeliculaDTO.Titulo));
            }
            if (filtroPeliculaDTO.EnCines)
            {
                peliculasQueryable = peliculasQueryable.Where(x => x.EnCines);
            }
            if (filtroPeliculaDTO.ProximosEstrenos)
            {
                var hoy = DateTime.Today;
                peliculasQueryable = peliculasQueryable.Where(x => x.FechaEstreno > hoy);
            }

            if (filtroPeliculaDTO.GeneroID != 0)
            {
                peliculasQueryable = peliculasQueryable.Where(x => x.PeliculasGeneros.Select(y => y.GeneroId)
               .Contains(filtroPeliculaDTO.GeneroID));
            }


            //forma para hacer campo por campo que se desa ordenar
            //if (!String.IsNullOrEmpty(filtroPeliculaDTO.CampoOrdenar))
            //{
            //    if (filtroPeliculaDTO.CampoOrdenar == "titulo")
            //    {
            //        if (filtroPeliculaDTO.OrdenAscendente)
            //        {
            //            peliculasQueryable = peliculasQueryable.OrderBy(x => x.Titulo);
            //        }
            //        else {
            //            peliculasQueryable = peliculasQueryable.OrderByDescending(x => x.Titulo);
            //        }
            //    }
            //}
            if (!String.IsNullOrEmpty(filtroPeliculaDTO.CampoOrdenar))
            {
                //Se instala la libreria System.Linq.Dynamic.Core desde nugget
                var tipoOrden = filtroPeliculaDTO.OrdenAscendente ? "ascending" : "descending";

                //si el usuario nos envía algo diferente a algún campo manejamos mediante excepción
                try
                {
                    peliculasQueryable = peliculasQueryable.OrderBy($"{filtroPeliculaDTO.CampoOrdenar} {tipoOrden}");
                }
                catch (Exception)
                {
                    //throw;
                    logger.LogError("El campo de ordenamiento no es válido");
                }

            }
            
            await HttpContext.InsertarParametrosPaginacionEnCabecera(peliculasQueryable, filtroPeliculaDTO.CantidadRegistrosPorPagina);
            var peliculas = await peliculasQueryable.Paginar(filtroPeliculaDTO.Paginacion).ToListAsync();
            return mapper.Map<List<PeliculaDTO>>(peliculas); //mapeo de la lista de películas a la lista de peliculasDTO

        }

        [HttpGet("{id}", Name = "ObtenerPelicula")]
        public async Task<ActionResult<PeliculasDetallesDTO>> Get(int id)
        {
            var pelicula = await context.Peliculas
                .Include(x => x.PeliculasActores).ThenInclude(x => x.Actor) //then entonces incluye también la propiedad de navegación indicada
                .Include(x => x.PeliculasGeneros).ThenInclude(x => x.Genero)
                .FirstOrDefaultAsync(x => x.Id == id);
            if (pelicula is null) return NotFound();

            pelicula.PeliculasActores = pelicula.PeliculasActores.OrderBy(x => x.Orden).ToList();

            return mapper.Map<PeliculasDetallesDTO>(pelicula);
        }

        [HttpPost]
        public async Task<ActionResult> Post([FromForm] PeliculaCreacionDTO peliculaCreacionDTO)
        {
            var pelicula = mapper.Map<Pelicula>(peliculaCreacionDTO);

            if (peliculaCreacionDTO.Poster is not null)
            {
                using (var memoryString = new MemoryStream())
                {
                    await peliculaCreacionDTO.Poster.CopyToAsync(memoryString);
                    var contenido = memoryString.ToArray();
                    var extension = Path.GetExtension(peliculaCreacionDTO.Poster.FileName);
                    pelicula.Poster = await almacenArchivos.GuadarArchivo(contenido: contenido, extension: extension, contenedor: contenedor, contentType: peliculaCreacionDTO.Poster.ContentType);
                }
            }

            AsignarOdenActores(pelicula);
            context.Add(pelicula);
            await context.SaveChangesAsync();
            var peliculaDTO = mapper.Map<PeliculaDTO>(pelicula);
            return new CreatedAtRouteResult("ObtenerPelicula", new { id = pelicula.Id }, peliculaDTO);
        }


        private void AsignarOdenActores(Pelicula pelicula)
        {
            if (pelicula.PeliculasActores is not null)
            {
                for (int i = 0; i < pelicula.PeliculasActores.Count; i++)
                {
                    pelicula.PeliculasActores[i].Orden = i;
                }
            }
        }



        [HttpPut("{id}")]
        public async Task<ActionResult> Put(int id, [FromForm] PeliculaCreacionDTO peliculaCreacionDTO)
        {
            var peliculaDB = await context.Peliculas
                .Include(x => x.PeliculasActores)
                .Include(x => x.PeliculasGeneros)
                .FirstOrDefaultAsync(x => x.Id == id);

            if (peliculaDB is null) return NotFound();

            peliculaDB = mapper.Map(peliculaCreacionDTO, peliculaDB);

            if (peliculaCreacionDTO.Poster is not null)
            {
                using (var memoryString = new MemoryStream())
                {
                    await peliculaCreacionDTO.Poster.CopyToAsync(memoryString);
                    var contenido = memoryString.ToArray();
                    var extension = Path.GetExtension(peliculaCreacionDTO.Poster.FileName);
                    peliculaDB.Poster = await almacenArchivos.EditarArchivo(contenido: contenido, extension: extension, contenedor: contenedor, contentType: peliculaCreacionDTO.Poster.ContentType, ruta: peliculaDB.Poster);
                }
            }
            AsignarOdenActores(peliculaDB);
            await context.SaveChangesAsync();
            return NoContent();
        }



        [HttpPatch("{id}")]
        public async Task<ActionResult> Patch(int id, [FromBody] JsonPatchDocument<PeliculaPatchDTO> patchDocument)
        {
            return await Patch<Pelicula, PeliculaPatchDTO>(id, patchDocument);
            //if (patchDocument is null) return BadRequest();

            //var entidadDb = await context.Peliculas.FirstOrDefaultAsync(x => x.Id == id);
            //if (entidadDb is null) return NotFound();

            //var entidadDTO = mapper.Map<PeliculaPatchDTO>(entidadDb);

            ////para error en Model estate se instala Microsoft.AspNetCore.Mvc.NewtonsoftJson
            ////para configurara: se modifica startup en  .AddNewtonsoftJson();
            //patchDocument.ApplyTo(entidadDTO, ModelState);

            //if (!TryValidateModel(entidadDTO)) return BadRequest(ModelState);

            //mapper.Map(entidadDTO, entidadDb);
            //await context.SaveChangesAsync();
            //return NoContent();

        }


        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            return await Delete<Pelicula>(id);
            //var modelo = await context.Peliculas.AnyAsync(x => x.Id == id);
            //if (!modelo) return NotFound();
            //context.Remove(new Pelicula { Id = id });
            //await context.SaveChangesAsync();
            //return NoContent();
        }
    }
}
