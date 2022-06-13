using AutoMapper;
using Domain.DTOs.User;
using Domain.Entities;

namespace CrossCuting.Mappings
{
    public class EntityToDTOProfile: Profile
    {
        public EntityToDTOProfile()
        {
            CreateMap<UserDTOCreate, UserEntity>()
                .ReverseMap();

            CreateMap<UserDTOCreateResult, UserEntity>()
                .ReverseMap();

            CreateMap<UserDTOUpdateResult, UserEntity>()
                .ReverseMap();
        }
    }
}
