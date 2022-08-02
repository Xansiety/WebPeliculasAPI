namespace PeliculasAPI.DTOs.Paginacion
{
    public class PaginacionDTO
    {
        public int Pagina { get; set; } = 1;
        private int cantidadRegistrosPorPagina = 10;
        private readonly int cantidadMaximaRegistrosPorPagina = 50;
        public int CantidadRegistrosPorPagina
        {
            get  => cantidadRegistrosPorPagina;
            set
            {
                cantidadRegistrosPorPagina = (value > cantidadMaximaRegistrosPorPagina) ? cantidadMaximaRegistrosPorPagina : value;
                //Si el valor mandado es mayor a 50, regresamos el valor máximos definido por nosotros, en caso contrario asignamos el valor mandado
            }
        }
    }
}
