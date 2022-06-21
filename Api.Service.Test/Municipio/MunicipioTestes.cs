using Domain.DTOs.Municipio;
using Domain.DTOs.Uf;
using System;
using System.Collections.Generic;

namespace Api.Service.Test.Municipio
{
    public class MunicipioTestes
    {
        public static string NomeMunicipio { get; set; }
        public static int CodigoIBGEMunicipio { get; set; }
        public static string NomeMunicipioAlterado { get; set; }
        public static int CodigoIBGEMunicipioAlterado { get; set; }
        public static Guid IdMunicipio { get; set; }
        public static Guid IdUf { get; set; }

        public List<MunicipioDTO> listaDTO = new List<MunicipioDTO>();
        public MunicipioDTO municipioDTO;
        public MunicipioDTOCompleto municipioDTOCompleto;
        public MunicipioDTOCreate municipioDTOCreate;
        public MunicipioDTOCreateResult municipioDTOCreateResult;
        public MunicipioDTOUpdate municipioDTOUpdate;
        public MunicipioDTOUpdateResult municipioDTOUpdateResult;

        public MunicipioTestes()
        {
            IdMunicipio = Guid.NewGuid();
            NomeMunicipio = Faker.Address.StreetName();
            CodigoIBGEMunicipio = Faker.RandomNumber.Next(1, 10000);
            NomeMunicipioAlterado = Faker.Address.StreetName();
            CodigoIBGEMunicipioAlterado = Faker.RandomNumber.Next(1, 10000);
            IdUf = Guid.NewGuid();

            for (int i = 0; i < 10; i++)
            {
                var DTO = new MunicipioDTO()
                {
                    Id = Guid.NewGuid(),
                    Nome = Faker.Name.FullName(),
                    CodIBGE = Faker.RandomNumber.Next(1, 10000),
                    UfId = Guid.NewGuid()
                };
                listaDTO.Add(DTO);
            }

            municipioDTO = new MunicipioDTO
            {
                Id = IdMunicipio,
                Nome = NomeMunicipio,
                CodIBGE = CodigoIBGEMunicipio,
                UfId = IdUf
            };

            municipioDTOCompleto = new MunicipioDTOCompleto
            {
                Id = IdMunicipio,
                Nome = NomeMunicipio,
                CodIBGE = CodigoIBGEMunicipio,
                UfId = IdUf,
                Uf = new UfDTO
                {
                    Id = Guid.NewGuid(),
                    Nome = Faker.Address.UsState(),
                    Sigla = Faker.Address.UsState().Substring(1, 3)
                }
            };

            municipioDTOCreate = new MunicipioDTOCreate
            {
                Nome = NomeMunicipio,
                CodIBGE = CodigoIBGEMunicipio,
                UfId = IdUf
            };

            municipioDTOCreateResult = new MunicipioDTOCreateResult
            {
                Id = IdMunicipio,
                Nome = NomeMunicipio,
                CodIBGE = CodigoIBGEMunicipio,
                UfId = IdUf,
                CreateAt = DateTime.UtcNow
            };

            municipioDTOUpdate = new MunicipioDTOUpdate
            {
                Id = IdMunicipio,
                Nome = NomeMunicipioAlterado,
                CodIBGE = CodigoIBGEMunicipioAlterado,
                UfId = IdUf
            };

            municipioDTOUpdateResult = new MunicipioDTOUpdateResult
            {
                Id = IdMunicipio,
                Nome = NomeMunicipioAlterado,
                CodIBGE = CodigoIBGEMunicipioAlterado,
                UfId = IdUf,
                UpdateAt = DateTime.UtcNow
            };

        }
    }
}
