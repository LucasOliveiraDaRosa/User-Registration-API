using AutoMapper;
using Domain.DTOs.Cep;
using Domain.DTOs.Municipio;
using Domain.DTOs.Uf;
using Domain.DTOs.User;
using Domain.Models;

namespace CrossCuting.Mappings
{
    public class DTOToModelProfile : Profile
    {
        public DTOToModelProfile()
        {
            #region User
            CreateMap<UserModel, UserDTO>()
                .ReverseMap();
            CreateMap<UserModel, UserDTOCreate>()
                .ReverseMap();
            CreateMap<UserModel, UserDTOUpdate>()
                .ReverseMap();
            #endregion

            #region UF
            CreateMap<UfModel, UfDTO>()
                .ReverseMap();
            #endregion

            #region Municipio
            CreateMap<MunicipioModel, MunicipioDTO>()
                .ReverseMap();
            CreateMap<MunicipioModel, MunicipioDTOCreate>()
                .ReverseMap();
            CreateMap<MunicipioModel, MunicipioDTOUpdate>()
                .ReverseMap();
            #endregion

            #region CEP
            CreateMap<CepModel, CepDTO>()
                .ReverseMap();
            CreateMap<CepModel, CepDTOCreate>()
                .ReverseMap();
            CreateMap<CepModel, CepDTOUpdate>()
                .ReverseMap();
            #endregion
        }
    }
}
