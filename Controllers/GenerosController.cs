using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PeliculasAPI.DTOs.Genero;
using PeliculasAPI.Models;

namespace PeliculasAPI.Controllers
{
    [Route("api/generos")]
    [ApiController]
    public class GenerosController : CustomBaseController
    {
        //private readonly ApplicationDbContext context;
        //private readonly IMapper mapper;

        public GenerosController(ApplicationDbContext context, IMapper mapper) : base(context, mapper)
        {
            //this.context = context;
            //this.mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<List<GeneroDTO>>> Get()
        {
            //var modelo = await context.Generos.ToListAsync();
            //var dtos = mapper.Map<List<GeneroDTO>>(modelo);
            //return dtos;
            return await Get<Genero,GeneroDTO>();
        }


        [HttpGet("{id:int}", Name = "ObtenerGenero")]
        public async Task<ActionResult<GeneroDTO>> Get(int id)
        {
            //var modelo = await context.Generos.FirstOrDefaultAsync(x => x.Id == id);
            //if (modelo is null) return NotFound();
            //var dto = mapper.Map<GeneroDTO>(modelo);
            //return dto;
            return await Get<Genero, GeneroDTO>(id);
        }


        [HttpPost]
        public async Task<ActionResult> Post([FromBody] GeneroCreacionDTO generoCreacionDTO)
        {
            //var entidad = mapper.Map<Genero>(generoCreacionDTO);
            //context.Add(entidad);
            //await context.SaveChangesAsync();
            //var generoDTO = mapper.Map<GeneroDTO>(entidad);
            //return new CreatedAtRouteResult("ObtenerGenero", new { id = generoDTO.Id }, generoDTO);
            return await Post<GeneroCreacionDTO, Genero,  GeneroDTO>(generoCreacionDTO, "ObtenerGenero");
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Put(int id, [FromBody] GeneroCreacionDTO generoCreacionDTO)
        {
            return await Put<GeneroCreacionDTO, Genero>(id, generoCreacionDTO);
            //var entidad = mapper.Map<Genero>(generoCreacionDTO);
            //entidad.Id = id;
            //context.Entry(entidad).State = EntityState.Modified;
            //await context.SaveChangesAsync();
            //return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            return await Delete<Genero>(id);
            //var modelo = await context.Generos.AnyAsync(x => x.Id == id);
            //if (!modelo) return NotFound();
            //context.Remove(new Genero { Id = id });
            //await context.SaveChangesAsync();
            //return NoContent();
        }

    }
}
