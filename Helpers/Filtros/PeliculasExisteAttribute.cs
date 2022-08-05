using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.EntityFrameworkCore;

namespace PeliculasAPI.Helpers.Filtros
{
    public class PeliculasExisteAttribute : Attribute, IAsyncResourceFilter
    {
        private readonly ApplicationDbContext Dbcontext;

        public PeliculasExisteAttribute(ApplicationDbContext context)
        {
            this.Dbcontext = context;
        }
        public async Task OnResourceExecutionAsync(ResourceExecutingContext context, ResourceExecutionDelegate next)
        {
            var peliculaIdObject = context.HttpContext.Request.RouteValues["peliculaId"];

            if (peliculaIdObject is null) return;

            var peliculaId = int.Parse(peliculaIdObject.ToString());

            var existePelicula = await Dbcontext.Peliculas.AnyAsync(x => x.Id == peliculaId);
            if (!existePelicula)
            {
                context.Result = new NotFoundResult();
            }
            else
            {
                await next();
            }
        }
    }
}
