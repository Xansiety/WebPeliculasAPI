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


        //se usa el model binder para poder recibir el tipo de dato
        [ModelBinder(binderType: typeof(TypeBinder<List<int>>))]
        public List<int> GenerosId { get; set; }

        [ModelBinder(binderType: typeof(TypeBinder<List<ActorPeliculasCreacionDTO>>))]
        public List<ActorPeliculasCreacionDTO> Actores { get; set; }
    }
}
