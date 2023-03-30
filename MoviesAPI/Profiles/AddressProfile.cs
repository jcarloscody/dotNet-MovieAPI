using AutoMapper;
using MoviesAPI.Data.DTOs.Address;
using MoviesAPI.Models;

namespace MoviesAPI.Profiles
{
    public class AddressProfile: Profile
    {
        public AddressProfile()
        {
            CreateMap<CreateEnderecoDTO, Address>();
            CreateMap<Address, ReadEnderecoDTO>();
            CreateMap<UpdateEnderecoDTO, Address>();
        }
    }
}
