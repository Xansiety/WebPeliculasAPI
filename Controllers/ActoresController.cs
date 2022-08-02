using AutoMapper;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PeliculasAPI.DTOs.Actor;
using PeliculasAPI.DTOs.Paginacion;
using PeliculasAPI.Helpers.PaginarResultados;
using PeliculasAPI.Models;
using PeliculasAPI.Servicios;

namespace PeliculasAPI.Controllers
{
    [Route("api/actores")]
    [ApiController]
    public class ActoresController : ControllerBase
    {
        private readonly ApplicationDbContext context;
        private readonly IMapper mapper;
        private readonly IAlmacenArchivos almacenArchivos;
        private readonly string contenedor = "actores";

        public ActoresController(ApplicationDbContext context, IMapper mapper, IAlmacenArchivos almacenArchivos)
        {
            this.context = context;
            this.mapper = mapper;
            this.almacenArchivos = almacenArchivos;
        }


        [HttpGet]
        public async Task<ActionResult<List<ActorDTO>>> Get([FromQuery] PaginacionDTO paginacionDTO)
        {

            var queryable = context.Actores.AsQueryable();
            await HttpContext.InsertarParametrosPaginacionEnCabecera(queryable, paginacionDTO.CantidadRegistrosPorPagina);

            var actores = await queryable.Paginar(paginacionDTO).ToListAsync();
            return mapper.Map<List<ActorDTO>>(actores);

            //var modelo = await context.Actores.ToListAsync();
            //return mapper.Map<List<ActorDTO>>(modelo); 
        }


        [HttpGet("{id:int}", Name = "ObtenerActor")]
        public async Task<ActionResult<ActorDTO>> Get(int id)
        {
            var modelo = await context.Actores.FirstOrDefaultAsync(x => x.Id == id);
            if (modelo is null) return NotFound();
            return mapper.Map<ActorDTO>(modelo);
        }


        [HttpPost]
        public async Task<ActionResult> Post([FromForm] ActorCreacionDTO actorCreacionDTO)
        {
            var entidad = mapper.Map<Actor>(actorCreacionDTO);

            if (actorCreacionDTO.Foto is not null)
            {
                using (var memoryString = new MemoryStream())
                {
                    await actorCreacionDTO.Foto.CopyToAsync(memoryString);
                    var contenido = memoryString.ToArray();
                    var extension = Path.GetExtension(actorCreacionDTO.Foto.FileName);
                    entidad.Foto = await almacenArchivos.GuadarArchivo(contenido: contenido, extension: extension, contenedor: contenedor, contentType: actorCreacionDTO.Foto.ContentType);
                }
            }
            context.Add(entidad);
            await context.SaveChangesAsync();
            var actorDTO = mapper.Map<ActorDTO>(entidad);
            return new CreatedAtRouteResult("ObtenerActor", new { id = actorDTO.Id }, actorDTO);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Put(int id, [FromForm] ActorCreacionDTO actorCreacionDTO)
        {
            var actorDB = await context.Actores.FirstOrDefaultAsync(x => x.Id == id);
            if (actorDB is null) return NotFound();

            actorDB = mapper.Map(actorCreacionDTO, actorDB);

            if (actorCreacionDTO.Foto is not null)
            {
                using (var memoryString = new MemoryStream())
                {
                    await actorCreacionDTO.Foto.CopyToAsync(memoryString);
                    var contenido = memoryString.ToArray();
                    var extension = Path.GetExtension(actorCreacionDTO.Foto.FileName);
                    actorDB.Foto = await almacenArchivos.EditarArchivo(contenido: contenido, extension: extension, contenedor: contenedor, contentType: actorCreacionDTO.Foto.ContentType, ruta: actorDB.Foto);
                }
            }

            await context.SaveChangesAsync();
            return NoContent();
        }


        [HttpPatch("{id}")]
        public async Task<ActionResult> Patch(int id, [FromBody] JsonPatchDocument<ActorPatchDTO> patchDocument)
        {
            if (patchDocument is null) return BadRequest();

            var entidadDb = await context.Actores.FirstOrDefaultAsync(x => x.Id == id);
            if (entidadDb is null) return NotFound();

            var entidadDTO = mapper.Map<ActorPatchDTO>(entidadDb);

            //para error en Model estate se instala Microsoft.AspNetCore.Mvc.NewtonsoftJson
            //para configurara: se modifica startup en  .AddNewtonsoftJson();
            patchDocument.ApplyTo(entidadDTO, ModelState);

            if (!TryValidateModel(entidadDTO)) return BadRequest(ModelState);

            mapper.Map(entidadDTO, entidadDb);
            await context.SaveChangesAsync();
            return NoContent();

        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var modelo = await context.Actores.AnyAsync(x => x.Id == id);
            if (!modelo) return NotFound();
            context.Remove(new Actor { Id = id });
            await context.SaveChangesAsync();
            return NoContent();
        }


    }
}
