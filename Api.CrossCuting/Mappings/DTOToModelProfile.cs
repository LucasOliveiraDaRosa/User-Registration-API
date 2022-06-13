using AutoMapper;
using Domain.DTOs.User;
using Domain.Models;

namespace CrossCuting.Mappings
{
    public class DTOToModelProfile : Profile
    {
        public DTOToModelProfile()
        {
            CreateMap<UserModel, UserDTO>()
                .ReverseMap();
            
            CreateMap<UserModel, UserDTOCreate>()
                .ReverseMap();
            
            CreateMap<UserModel, UserDTOUpdate>()
                .ReverseMap();
        }
    }
}
