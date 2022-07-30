using PeliculasAPI.Validaciones;
using System.ComponentModel.DataAnnotations;

namespace PeliculasAPI.DTOs.Actor
{
    public class ActorCreacionDTO
    {
        [Required]
        [StringLength(150, MinimumLength = 3)]
        public string Nombre { get; set; }
        public DateTime FechaNacimiento { get; set; }
        
        [PesoArchivoValidacion(PesoMaximoEnMegaBytes: 4)]
        [TipoArchivoValidacion(grupoTipoArchivo: GrupoTipoArchivo.Imagen)]
        public IFormFile Foto { get; set; }
    }
}
