using AutoMapper;
using Microsoft.AspNetCore.Identity;
using NetTopologySuite;
using NetTopologySuite.Geometries;
using PeliculasAPI.DTOs.Actor;
using PeliculasAPI.DTOs.Cine;
using PeliculasAPI.DTOs.Genero;
using PeliculasAPI.DTOs.Pelicula;
using PeliculasAPI.DTOs.Review;
using PeliculasAPI.DTOs.Usuarios;
using PeliculasAPI.Models;

namespace PeliculasAPI.Helpers
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles(GeometryFactory geometryFactory )
        {
            //profiles Auth
            CreateMap<IdentityUser, UsuarioDTO>();
             
            //profiles Genero
            CreateMap<Genero, GeneroDTO>().ReverseMap();
            CreateMap<GeneroCreacionDTO, Genero>();

            //profiles Reviews
            CreateMap<Review, ReviewDTO>()
                .ForMember(x => x.NombreUsuario, x => x.MapFrom(y => y.Usuario.UserName));

            CreateMap<ReviewDTO, Review>();
            CreateMap<ReviewCreacionDTO, Review>();

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
            CreateMap<Pelicula, PeliculasDetallesDTO>()
                .ForMember(x => x.Generos, options => options.MapFrom(MapPeliculasGeneros))
                .ForMember(x => x.Actores, options => options.MapFrom(MapPeliculasActores));

            //profiles Cine
            CreateMap<SalaDeCine, SalaDeCineDTO>()
                .ForMember(x => x.Latitud , x => x.MapFrom(y => y.Ubicacion.Y) )
                .ForMember(x => x.Longitud, x => x.MapFrom(y => y.Ubicacion.X));

            ////Para indicar el sistema de coordenada para representare coordenadas en el mapa
            //var geometryFactory = NtsGeometryServices.Instance.CreateGeometryFactory(srid: 4326);

            CreateMap<SalaDeCineDTO, SalaDeCine>()
                .ForMember(x => x.Ubicacion, x => x.MapFrom(y => geometryFactory.CreatePoint(new Coordinate(y.Longitud, y.Latitud))));



            CreateMap<SalaDeCineCreacionDTO, SalaDeCine>()
                .ForMember(x => x.Ubicacion, x => x.MapFrom(y => geometryFactory.CreatePoint(new Coordinate(y.Longitud, y.Latitud))));

        }

        private List<ActorPeliculaDetalleDTO> MapPeliculasActores(Pelicula pelicula, PeliculasDetallesDTO peliculasDetallesDTO)
        {
            var resultado = new List<ActorPeliculaDetalleDTO>();
            if (pelicula.PeliculasActores is null) return resultado;

            pelicula.PeliculasActores.ForEach(x =>
            {
                resultado.Add(new ActorPeliculaDetalleDTO
                {
                    ActorId = x.ActorId,
                    Personaje = x.Personaje,
                    NombrePersona = x.Actor.Nombre
                });
            });

            return resultado;
        }
            
        private List<GeneroDTO> MapPeliculasGeneros(Pelicula pelicula, PeliculasDetallesDTO peliculasDetallesDTO)
        {
            var resultado = new List<GeneroDTO>();
            if (pelicula.PeliculasGeneros is null) return resultado;

            pelicula.PeliculasGeneros.ForEach(x =>
            {
                resultado.Add(new GeneroDTO
                {
                    Id = x.GeneroId,
                    Nombre = x.Genero.Nombre
                });
            });

            return resultado;
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
