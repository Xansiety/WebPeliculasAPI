namespace PeliculasAPI.Models
{
    public class PeliculasGeneros
    {
        public int GeneroId { get; set; }
        public int PeliculaId { get; set; }

        //propiedades de navegación
        public Genero Genero { get; set; }
        public Pelicula Pelicula { get; set; }
    }
}
