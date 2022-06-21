using Domain.DTOs.Cep;
using Domain.DTOs.Municipio;
using Domain.DTOs.Uf;
using System;
using System.Collections.Generic;

namespace Api.Service.Test.Cep
{
    public class CepTestes
    {
        public static string CepOriginal { get; set; }
        public static string LogradouroOriginal { get; set; }
        public static string NumeroOriginal { get; set; }
        public static string CepAlterado { get; set; }
        public static string LogradouroAlterado { get; set; }
        public static string NumeroAlterado { get; set; }
        public static Guid IdMunicipio { get; set; }
        public static Guid IdCep { get; set; }

        public List<CepDTO> listaDTO = new List<CepDTO>();
        public CepDTO cepDTO;
        public CepDTOCreate cepDTOCreate;
        public CepDTOCreateResult cepDTOCreateResult;
        public CepDTOUpdate cepDTOUpdate;
        public CepDTOUpdateResult cepDTOUpdateResult;

        public CepTestes()
        {
            IdMunicipio = Guid.NewGuid();
            IdCep = Guid.NewGuid();
            CepOriginal = Faker.RandomNumber.Next(10000, 99999).ToString();
            NumeroOriginal = Faker.RandomNumber.Next(1, 1000).ToString();
            LogradouroOriginal = Faker.Address.StreetName();
            CepAlterado = Faker.RandomNumber.Next(10000, 99999).ToString();
            NumeroAlterado = Faker.RandomNumber.Next(1, 1000).ToString();
            LogradouroAlterado = Faker.Address.StreetName();

            for (int i = 0; i < 10; i++)
            {
                var DTO = new CepDTO()
                {
                    Id = Guid.NewGuid(),
                    Cep = Faker.RandomNumber.Next(10000, 99999).ToString(),
                    Logradouro = Faker.Address.StreetName(),
                    Numero = Faker.RandomNumber.Next(1, 1000).ToString(),
                    MunicipioId = Guid.NewGuid(),
                    Municipio = new MunicipioDTOCompleto
                    {
                        Id = IdMunicipio,
                        Nome = Faker.Address.City(),
                        CodIBGE = Faker.RandomNumber.Next(1, 10000),
                        UfId = Guid.NewGuid(),
                        Uf = new UfDTO
                        {
                            Id = Guid.NewGuid(),
                            Nome = Faker.Address.UsState(),
                            Sigla = Faker.Address.UsState().Substring(1, 3)
                        }
                    }
                };
                listaDTO.Add(DTO);
            }

            cepDTO = new CepDTO
            {
                Id = IdCep,
                Cep = CepOriginal,
                Logradouro = LogradouroOriginal,
                Numero = NumeroOriginal,
                MunicipioId = IdMunicipio,
                Municipio = new MunicipioDTOCompleto
                {
                    Id = IdMunicipio,
                    Nome = Faker.Address.City(),
                    CodIBGE = Faker.RandomNumber.Next(1, 10000),
                    UfId = Guid.NewGuid(),
                    Uf = new UfDTO
                    {
                        Id = Guid.NewGuid(),
                        Nome = Faker.Address.UsState(),
                        Sigla = Faker.Address.UsState().Substring(1, 3)
                    }
                }
            };

            cepDTOCreate = new CepDTOCreate
            {
                Cep = CepOriginal,
                Logradouro = LogradouroOriginal,
                Numero = NumeroOriginal,
                MunicipioId = IdMunicipio,
            };

            cepDTOCreateResult = new CepDTOCreateResult
            {
                Id = IdCep,
                Cep = CepOriginal,
                Logradouro = LogradouroOriginal,
                Numero = NumeroOriginal,
                MunicipioId = IdMunicipio,
                CreateAt = DateTime.UtcNow
            };

            cepDTOUpdate = new CepDTOUpdate
            {
                Id = IdCep,
                Cep = CepAlterado,
                Logradouro = LogradouroAlterado,
                Numero = NumeroAlterado,
                MunicipioId = IdMunicipio
            };

            cepDTOUpdateResult = new CepDTOUpdateResult
            {
                Id = IdMunicipio,
                Cep = CepAlterado,
                Logradouro = LogradouroAlterado,
                Numero = NumeroAlterado,
                MunicipioId = IdMunicipio,
                UpdateAt = DateTime.UtcNow
            };

        }
    }
}
