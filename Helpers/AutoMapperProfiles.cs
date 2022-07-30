using AutoMapper;
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
        }
    }
}
