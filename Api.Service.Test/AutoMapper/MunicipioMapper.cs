using System;
using System.Collections.Generic;
using System.Linq;
using Domain.DTOs.Municipio;
using Domain.Entities;
using Domain.Models;
using Xunit;

namespace Api.Service.Test.AutoMapper
{
    public class MunicipioMapper : BaseTestService
    {
        [Fact(DisplayName = "É Possível Mapear os Modelo de Municipio")]
        public void E_Possivel_Mapear_os_Modelos_Municipio()
        {
            var model = new MunicipioModel
            {
                Id = Guid.NewGuid(),
                Nome = Faker.Address.City(),
                CodIBGE = Faker.RandomNumber.Next(1, 10000),
                UfId = Guid.NewGuid(),
                CreateAt = DateTime.UtcNow,
                UpdateAt = DateTime.UtcNow
            };

            var listaEntity = new List<MunicipioEntity>();
            for (int i = 0; i < 5; i++)
            {
                var item = new MunicipioEntity
                {
                    Id = Guid.NewGuid(),
                    Nome = Faker.Address.City(),
                    CodIBGE = Faker.RandomNumber.Next(1, 10000),
                    UFId = Guid.NewGuid(),
                    CreateAt = DateTime.UtcNow,
                    UpdateAt = DateTime.UtcNow,
                    Uf = new UFEntity
                    {
                        Id = Guid.NewGuid(),
                        Nome = Faker.Address.UsState(),
                        Sigla = Faker.Address.UsState().Substring(1, 3)
                    }
                };
                listaEntity.Add(item);
            }

            //Model => Entity
            var entity = mapper.Map<MunicipioEntity>(model);
            Assert.Equal(entity.Id, model.Id);
            Assert.Equal(entity.Nome, model.Nome);
            Assert.Equal(entity.CodIBGE, model.CodIBGE);
            Assert.Equal(entity.UFId, model.UfId);
            Assert.Equal(entity.CreateAt, model.CreateAt);
            Assert.Equal(entity.UpdateAt, model.UpdateAt);

            //Entity para Dto
            var userDto = mapper.Map<MunicipioDTO>(entity);
            Assert.Equal(userDto.Id, entity.Id);
            Assert.Equal(userDto.Nome, entity.Nome);
            Assert.Equal(userDto.CodIBGE, entity.CodIBGE);
            Assert.Equal(userDto.UfId, entity.UFId);

            var userDtoCompleto = mapper.Map<MunicipioDTOCompleto>(listaEntity.FirstOrDefault());
            Assert.Equal(userDtoCompleto.Id, listaEntity.FirstOrDefault().Id);
            Assert.Equal(userDtoCompleto.Nome, listaEntity.FirstOrDefault().Nome);
            Assert.Equal(userDtoCompleto.CodIBGE, listaEntity.FirstOrDefault().CodIBGE);
            Assert.Equal(userDtoCompleto.UfId, listaEntity.FirstOrDefault().UFId);
            Assert.NotNull(userDtoCompleto.Uf);

            var listaDto = mapper.Map<List<MunicipioDTO>>(listaEntity);
            Assert.True(listaDto.Count() == listaEntity.Count());
            for (int i = 0; i < listaDto.Count(); i++)
            {
                Assert.Equal(listaDto[i].Id, listaEntity[i].Id);
                Assert.Equal(listaDto[i].Nome, listaEntity[i].Nome);
                Assert.Equal(listaDto[i].CodIBGE, listaEntity[i].CodIBGE);
                Assert.Equal(listaDto[i].UfId, listaEntity[i].UFId);
            }

            var userDtoCreateResult = mapper.Map<MunicipioDTOCreateResult>(entity);
            Assert.Equal(userDtoCreateResult.Id, entity.Id);
            Assert.Equal(userDtoCreateResult.Nome, entity.Nome);
            Assert.Equal(userDtoCreateResult.CodIBGE, entity.CodIBGE);
            Assert.Equal(userDtoCreateResult.UfId, entity.UFId);
            Assert.Equal(userDtoCreateResult.CreateAt, entity.CreateAt);

            var userDtoUpdateResult = mapper.Map<MunicipioDTOUpdateResult>(entity);
            Assert.Equal(userDtoUpdateResult.Id, entity.Id);
            Assert.Equal(userDtoUpdateResult.Nome, entity.Nome);
            Assert.Equal(userDtoUpdateResult.CodIBGE, entity.CodIBGE);
            Assert.Equal(userDtoCreateResult.UfId, entity.UFId);
            Assert.Equal(userDtoUpdateResult.UpdateAt, entity.UpdateAt);

            //Dto para Model
            var userModel = mapper.Map<MunicipioModel>(userDto);
            Assert.Equal(userModel.Id, userDto.Id);
            Assert.Equal(userModel.Nome, userDto.Nome);
            Assert.Equal(userModel.CodIBGE, userDto.CodIBGE);
            Assert.Equal(userModel.UfId, userDto.UfId);

            var userDtoCreate = mapper.Map<MunicipioDTOCreate>(userModel);
            Assert.Equal(userDtoCreate.Nome, userModel.Nome);
            Assert.Equal(userDtoCreate.CodIBGE, userModel.CodIBGE);
            Assert.Equal(userDtoCreate.UfId, userModel.UfId);

            var userDtoUpdate = mapper.Map<MunicipioDTOUpdate>(userModel);
            Assert.Equal(userDtoUpdate.Id, userModel.Id);
            Assert.Equal(userDtoUpdate.Nome, userModel.Nome);
            Assert.Equal(userDtoUpdate.CodIBGE, userModel.CodIBGE);
            Assert.Equal(userDtoUpdate.UfId, userModel.UfId);

        }
    }
}
