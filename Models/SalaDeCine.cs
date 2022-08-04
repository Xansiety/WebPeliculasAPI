using NetTopologySuite.Geometries;
using System.ComponentModel.DataAnnotations;

namespace PeliculasAPI.Models
{
    public class SalaDeCine : IId
    {
        public int Id { get; set; } 
        [Required]
        [StringLength(120)]
        public string Nombre { get; set; } 
        //Microsoft.EntityFrameworkCore.SqlServer.TopologySuite 
        //propiedades para topology
        public Point Ubicacion { get; set; }
        public List<PeliculasSalasDeCine> PeliculasSalasDeCines { get; set; }


    }
}
