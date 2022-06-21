using AutoMapper;
using Domain.Entities;
using Domain.Models;

namespace CrossCuting.Mappings
{
    public class ModelToEntityProfile : Profile
    {
        public ModelToEntityProfile()
        {
            CreateMap<UserModel, UserEntity>()
               .ReverseMap();

            CreateMap<UfModel, UFEntity>()
               .ReverseMap();

            CreateMap<MunicipioModel, MunicipioEntity>()
               .ReverseMap();

            CreateMap<CepModel, CepEntity>()
               .ReverseMap();
        }
    }
}
