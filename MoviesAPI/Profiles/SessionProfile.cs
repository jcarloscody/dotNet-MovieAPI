using MoviesAPI.Data.DTOs.Session;
using MoviesAPI.Models;
using AutoMapper;

namespace MoviesAPI.Profiles
{
    public class SessionProfile : Profile
    {
        public SessionProfile()
        {
            CreateMap<CreateSessionDTO, Session>();
            CreateMap<Session, ReadSessionDTO>();
        }
    }
}
