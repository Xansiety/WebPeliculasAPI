using System.ComponentModel.DataAnnotations;

namespace PeliculasAPI.DTOs.Genero
{
    public class GeneroDTO
    {
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string Nombre { get; set; }
    }
}
