using AutoMapper;
using MoviesAPI.Data.DTOs.Movie;
using MoviesAPI.Models;

namespace MoviesAPI.Profiles;

public class MovieProfile : Profile

{
    public MovieProfile()
    {
        CreateMap<CreateFilmeDTO, Movie>();
        CreateMap<UpdateFilmeDto, Movie>();
        CreateMap<Movie, UpdateFilmeDto>();
        CreateMap<Movie, ReadFilmeDto>().
            ForMember(filmeDto => filmeDto.Sessoes,
                    opt => opt.MapFrom(filme => filme.Sessoes)); 
    }
}
