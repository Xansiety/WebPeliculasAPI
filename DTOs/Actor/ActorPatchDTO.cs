using System.ComponentModel.DataAnnotations;

namespace PeliculasAPI.DTOs.Actor
{
    public class ActorPatchDTO
    {
        [Required]
        [StringLength(150, MinimumLength = 3)]
        public string Nombre { get; set; }
        public DateTime FechaNacimiento { get; set; }
    }
}
