using Microsoft.EntityFrameworkCore;

namespace PeliculasAPI.Helpers.PaginarResultados
{
    public static class HttpContextExtensions
    {
        public async static Task InsertarParametrosPaginacionEnCabecera<T>(this HttpContext httpContext, IQueryable<T> queryable, int cantidadRegistrosPorPagina)
        {
            if (httpContext is null)
            {
                throw new ArgumentNullException(nameof(httpContext));
            } 
            double cantidad = await queryable.CountAsync(); //conteo
            double cantidadPagina = Math.Ceiling(cantidad / cantidadRegistrosPorPagina); 
            httpContext.Response.Headers.Add("X-Cantidad-Total-Paginas", cantidadPagina.ToString());
        }
    }
}
