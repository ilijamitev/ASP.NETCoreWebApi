using AutoMapper;
using MovieApp.Domain.Models;
using MovieApp.ServiceModels.MovieServiceModels;

namespace MovieApp.Mappers;

public class MovieProfile : Profile
{
    public MovieProfile()
    {
        CreateMap<Movie, MovieDto>().ForMember(dest => dest.Genre, opt => opt.MapFrom(x => x.Genre.ToString()));

        CreateMap<Movie, MovieDto>().ForMember(dest => dest.Genre, opt => opt.MapFrom(x => x.Genre.ToString())).ReverseMap();

        CreateMap<Movie, UpdateMovieDto>().ForMember(dest => dest.Genre, opt => opt.MapFrom(x => x.Genre.ToString()));

        CreateMap<Movie, UpdateMovieDto>().ForMember(dest => dest.Genre, opt => opt.MapFrom(x => x.Genre.ToString())).ReverseMap();


    }
}
