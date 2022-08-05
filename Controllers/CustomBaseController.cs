using AutoMapper;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PeliculasAPI.DTOs.Paginacion;
using PeliculasAPI.Helpers.PaginarResultados;
using PeliculasAPI.Models;

namespace PeliculasAPI.Controllers
{
    public class CustomBaseController : ControllerBase
    {
        private readonly ApplicationDbContext context;
        private readonly IMapper mapper;

        public CustomBaseController(ApplicationDbContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }
        //protected es para que las clases derivadas puedan utilizarlo
        protected async Task<List<TDTO>> Get<TEntidad, TDTO>() where TEntidad : class
        {
            var entidades = await context.Set<TEntidad>().ToListAsync();
            return mapper.Map<List<TDTO>>(entidades);
        }


        protected async Task<List<TDTO>> Get<TEntidad, TDTO>(PaginacionDTO paginacionDTO) 
            where TEntidad : class
        {
            var queryable = context.Set<TEntidad>().AsQueryable();
            //await HttpContext.InsertarParametrosPaginacionEnCabecera(queryable, paginacionDTO.CantidadRegistrosPorPagina);
            //var actores = await queryable.Paginar(paginacionDTO).ToListAsync();
            //return mapper.Map<List<TDTO>>(actores);
            return await Get<TEntidad, TDTO>(paginacionDTO, queryable);
        }

        protected async Task<List<TDTO>> Get<TEntidad, TDTO>(PaginacionDTO paginacionDTO, IQueryable<TEntidad> queryable)
            where TEntidad : class 
        { 
            await HttpContext.InsertarParametrosPaginacionEnCabecera(queryable, paginacionDTO.CantidadRegistrosPorPagina);
            var actores = await queryable.Paginar(paginacionDTO).ToListAsync();
            return mapper.Map<List<TDTO>>(actores);
        }



        //INDICAMOS QUE IMPLEMNTE LA INTERFAZ LA CLASE GENERICA class, IId
        protected async Task<ActionResult<TDTO>> Get<TEntidad, TDTO>(int id) where TEntidad : class, IId
        {
            var entidad = await context.Set<TEntidad>().FirstOrDefaultAsync(x => x.Id == id);
            if (entidad is null) return NotFound();
            return mapper.Map<TDTO>(entidad);
        }


        protected async Task<ActionResult> Post<TCreacion, TEntidad, TLectura>(TCreacion creacionDTO, string nombreRuta) where TEntidad : class, IId
        {
            var entidad = mapper.Map<TEntidad>(creacionDTO);
            context.Add(entidad);
            await context.SaveChangesAsync();
            var dtoLectura = mapper.Map<TLectura>(entidad);
            return CreatedAtRoute(nombreRuta, new { id = entidad.Id }, dtoLectura);
        }


        protected async Task<ActionResult> Put<TCreacion, TEntidad>(int id, TCreacion creacionDTO) where TEntidad : class, IId
        {
            var entidad = mapper.Map<TEntidad>(creacionDTO);
            entidad.Id = id;
            context.Entry(entidad).State = EntityState.Modified;
            await context.SaveChangesAsync();
            return NoContent();
        }


        protected async Task<ActionResult> Patch<TEntidad, TDTO>(int id, JsonPatchDocument<TDTO> patchDocument) 
            where TDTO : class
            where TEntidad : class, IId
        {
            if (patchDocument is null) return BadRequest();

            var entidadDb = await context.Set<TEntidad>().FirstOrDefaultAsync(x => x.Id == id);
            if (entidadDb is null) return NotFound();

            var entidadDTO = mapper.Map<TDTO>(entidadDb);

            //para error en Model estate se instala Microsoft.AspNetCore.Mvc.NewtonsoftJson
            //para configurara: se modifica startup en  .AddNewtonsoftJson();
            patchDocument.ApplyTo(entidadDTO, ModelState);

            if (!TryValidateModel(entidadDTO)) return BadRequest(ModelState);

            mapper.Map(entidadDTO, entidadDb);
            await context.SaveChangesAsync();
            return NoContent();
        }

        protected async Task<ActionResult> Delete<TEntidad>(int id) where TEntidad : class, IId, new()
        {
            var entidad = await context.Set<TEntidad>().AnyAsync(x => x.Id == id);
            if (!entidad) return NotFound();

            context.Remove(new TEntidad() { Id = id });
            await context.SaveChangesAsync();
            return NoContent();
        }


    }
}
