using AutoMapper;
using Domain.DTOs.Cep;
using Domain.DTOs.Municipio;
using Domain.DTOs.Uf;
using Domain.DTOs.User;
using Domain.Entities;

namespace CrossCuting.Mappings
{
    public class EntityToDTOProfile: Profile
    {
        public EntityToDTOProfile()
        {
            CreateMap<UserDTO, UserEntity>()
               .ReverseMap();

            CreateMap<UserDTOCreateResult, UserEntity>()
               .ReverseMap();

            CreateMap<UserDTOUpdateResult, UserEntity>()
               .ReverseMap();

            CreateMap<UfDTO, UFEntity>()
               .ReverseMap();

            CreateMap<MunicipioDTO, MunicipioEntity>()
               .ReverseMap();

            CreateMap<MunicipioDTOCompleto, MunicipioEntity>()
               .ReverseMap();

            CreateMap<MunicipioDTOCreateResult, MunicipioEntity>()
               .ReverseMap();

            CreateMap<MunicipioDTOUpdateResult, MunicipioEntity>()
               .ReverseMap();

            CreateMap<CepDTO, CepEntity>()
               .ReverseMap();

            CreateMap<CepDTOCreateResult, CepEntity>()
               .ReverseMap();

            CreateMap<CepDTOUpdateResult, CepEntity>()
               .ReverseMap();
        }
    }
}
