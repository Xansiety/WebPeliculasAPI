using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PeliculasAPI.DTOs.Actor;
using PeliculasAPI.Models;

namespace PeliculasAPI.Controllers
{
    [Route("api/actores")]
    [ApiController]
    public class ActoresController : ControllerBase
    {
        private readonly ApplicationDbContext context;
        private readonly IMapper mapper;

        public ActoresController(ApplicationDbContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper; 
        }


        [HttpGet]
        public async Task<ActionResult<List<ActorDTO>>> Get()
        {
            var modelo = await context.Actores.ToListAsync();
            return mapper.Map<List<ActorDTO>>(modelo); 
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
            context.Add(entidad);
            //await context.SaveChangesAsync();
            var actorDTO = mapper.Map<ActorDTO>(entidad);
            return new CreatedAtRouteResult("ObtenerActor", new { id = actorDTO.Id }, actorDTO);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Put(int id, [FromBody] ActorCreacionDTO actorCreacionDTO)
        {
            var entidad = mapper.Map<Actor>(actorCreacionDTO);
            entidad.Id = id;
            context.Entry(entidad).State = EntityState.Modified;
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
