using AutoMapper;
using Domain.Entities;
using Domain.Models;

namespace CrossCuting.Mappings
{
    public class ModelToEntityProfile : Profile
    {
        public ModelToEntityProfile()
        {
            CreateMap<UserEntity, UserModel>()
                .ReverseMap();
        }
    }
}
