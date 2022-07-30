using System.ComponentModel.DataAnnotations;

namespace PeliculasAPI.DTOs.Genero
{
    public class GeneroCreacionDTO
    {
        [Required]
        [StringLength(50)]
        public string Nombre { get; set; }
    }
}
