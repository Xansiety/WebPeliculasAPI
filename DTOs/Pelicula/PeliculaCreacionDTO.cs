using Microsoft.AspNetCore.Mvc;
using PeliculasAPI.Helpers.ModelBinder;
using PeliculasAPI.Validaciones; 

namespace PeliculasAPI.DTOs.Pelicula
{
    public class PeliculaCreacionDTO : PeliculaPatchDTO
    {
         
        
        [PesoArchivoValidacion(PesoMaximoEnMegaBytes: 4)]
        [TipoArchivoValidacion(grupoTipoArchivo: GrupoTipoArchivo.Imagen)]
        public IFormFile Poster { get; set; }

        [ModelBinder(binderType: typeof(TypeBinder))]
        public List<int> GenerosId { get; set; }

        public List<ActorPeliculasCreacionDTO> Actores { get; set; }
    }
}
