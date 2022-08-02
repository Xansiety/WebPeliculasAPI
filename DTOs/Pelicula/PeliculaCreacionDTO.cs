using PeliculasAPI.Validaciones; 

namespace PeliculasAPI.DTOs.Pelicula
{
    public class PeliculaCreacionDTO : PeliculaPatchDTO
    {
         
        
        [PesoArchivoValidacion(PesoMaximoEnMegaBytes: 4)]
        [TipoArchivoValidacion(grupoTipoArchivo: GrupoTipoArchivo.Imagen)]
        public IFormFile Poster { get; set; }

        public List<int> GenerosId { get; set; }
    }
}
