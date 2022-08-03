using System.ComponentModel.DataAnnotations;

namespace PeliculasAPI.DTOs.Cine
{
    public class SalaDeCineCreacionDTO
    { 
        [Required]
        [StringLength(120)]
        public string Nombre { get; set; }
    }
}
