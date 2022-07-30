using System.ComponentModel.DataAnnotations;

namespace PeliculasAPI.DTOs.Actor
{
    public class ActorDTO
    {
        public int Id { get; set; }

        [Required]
        [StringLength(150, MinimumLength = 3)]
        public string Nombre { get; set; }
        public DateTime FechaNacimiento { get; set; }
        public string Foto { get; set; }
    }
}
