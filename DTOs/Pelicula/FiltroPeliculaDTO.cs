using PeliculasAPI.DTOs.Paginacion;

namespace PeliculasAPI.DTOs.Pelicula
{
    public class FiltroPeliculaDTO
    {
        public int Pagina { get; set; } = 1;
        public int CantidadRegistrosPorPagina { get; set; } = 10;
        
        public PaginacionDTO Paginacion
        {
            get
            {
                return new PaginacionDTO
                {
                    Pagina = Pagina,
                    CantidadRegistrosPorPagina = CantidadRegistrosPorPagina
                };
            }
        }

        //FILTROS PARA EL CLIENTE
        public string Titulo { get; set; }
        public int GeneroID { get; set; }
        public bool EnCines { get; set; } 
        public bool ProximosEstrenos { get; set; }

        public string CampoOrdenar { get; set; }
        public bool OrdenAscendente { get; set; } = true;

    }
}
