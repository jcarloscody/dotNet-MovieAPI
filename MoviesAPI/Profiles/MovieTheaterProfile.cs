using AutoMapper;
using MoviesAPI.Data.DTOs.MovieThea;
using MoviesAPI.Models;

namespace MoviesAPI.Profiles
{
    public class MovieTheaterProfile : Profile
    {
        public MovieTheaterProfile()
        {
            CreateMap<CreateMovieTheaterDTO, MovieTheater>();
            CreateMap<MovieTheater, ReadMovieTheaterDTO>()
                .ForMember(cinemaDto => cinemaDto.Endereco,
                    opt => opt.MapFrom(cinema => cinema.Endereco))
                .ForMember(cinemaDto => cinemaDto.Sessoes,
                    opt => opt.MapFrom(cinema => cinema.Sessoes));
            CreateMap<UpdateMovieTheaterDTO, MovieTheater>();
        }
    }
}
