using AutoMapper;
using PeliculasAPI.DTOs.Actor;
using PeliculasAPI.DTOs.Genero;
using PeliculasAPI.DTOs.Pelicula;
using PeliculasAPI.Models;

namespace PeliculasAPI.Helpers
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {

            //profiles Genero
            CreateMap<Genero, GeneroDTO>().ReverseMap();
            CreateMap<GeneroCreacionDTO, Genero>();

            //profiles Actor
            CreateMap<Actor, ActorDTO>().ReverseMap();
            CreateMap<ActorCreacionDTO, Actor>()
                .ForMember(x => x.Foto, opt => opt.Ignore());
            CreateMap<ActorPatchDTO, Actor>().ReverseMap();

            //profiles Película
            CreateMap<Pelicula, PeliculaDTO>().ReverseMap();
            CreateMap<PeliculaCreacionDTO, Pelicula>()
                .ForMember(x => x.Poster, opt => opt.Ignore())
                .ForMember(x => x.PeliculasGeneros, options => options.MapFrom(MapPeliculasGeneros))
                .ForMember(x => x.PeliculasActores, options => options.MapFrom(MapPeliculasActores));
            CreateMap<PeliculaPatchDTO, Pelicula>().ReverseMap();


            //
        }


        private List<PeliculasGeneros> MapPeliculasGeneros(PeliculaCreacionDTO peliculaCreacionDTO, Pelicula pelicula)
        {
            var resultado = new List<PeliculasGeneros>();
            if (peliculaCreacionDTO.GenerosId is null) return resultado;

            peliculaCreacionDTO.GenerosId.ForEach(x =>
            {
                resultado.Add(new PeliculasGeneros
                {
                    GeneroId = x
                });
            });

            //foreach (var id in peliculaCreacionDTO.GenerosId)
            //{
            //    resultado.Add(new PeliculasGeneros() { GeneroId = id });
            //}

            return resultado; 
        }

        private List<PeliculasActores> MapPeliculasActores(PeliculaCreacionDTO peliculaCreacionDTO, Pelicula pelicula)
        {
            var resultado = new List<PeliculasActores>();
            if (peliculaCreacionDTO.Actores is null) return resultado;

            peliculaCreacionDTO.Actores.ForEach(x =>
            {
                resultado.Add(new PeliculasActores
                {
                    ActorId = x.ActorID,
                    Personaje = x.Personaje
                });
            });

            //foreach (var id in peliculaCreacionDTO.GenerosId)
            //{
            //    resultado.Add(new PeliculasGeneros() { GeneroId = id });
            //}

            return resultado;
        }
    }
}
