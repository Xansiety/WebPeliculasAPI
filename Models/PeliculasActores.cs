namespace PeliculasAPI.Models
{
    public class PeliculasActores
    {
        public int ActorId { get; set; }
        public int PeliculaId { get; set; }
        public string Personaje { get; set; }
        public int Orden { get; set; }
         
        //Propiedades de navegación
        public Actor actor { get; set; }
        public Pelicula pelicula { get; set; }
    }
}
