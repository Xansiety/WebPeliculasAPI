using PeliculasAPI.DTOs.Actor;
using PeliculasAPI.DTOs.Genero;

namespace PeliculasAPI.DTOs.Pelicula
{
    public class PeliculasDetallesDTO : PeliculaDTO
    {
        public List<GeneroDTO> Generos { get; set; }
        public List<ActorPeliculaDetalleDTO> Actores {get; set;}
}
}
