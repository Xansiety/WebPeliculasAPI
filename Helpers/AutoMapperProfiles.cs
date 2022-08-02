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
                .ForMember(x => x.Poster, opt => opt.Ignore());
            CreateMap<PeliculaPatchDTO, Pelicula>().ReverseMap();
        }
    }
}
