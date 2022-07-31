using AutoMapper;
using PeliculasAPI.DTOs.Actor;
using PeliculasAPI.DTOs.Genero;
using PeliculasAPI.Models;

namespace PeliculasAPI.Helpers
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<Genero, GeneroDTO>().ReverseMap(); 
            CreateMap<GeneroCreacionDTO, Genero>();


            CreateMap<Actor, ActorDTO>().ReverseMap();
            CreateMap<ActorCreacionDTO, Actor>()
                .ForMember(x => x.Foto, opt => opt.Ignore());
        }
    }
}
