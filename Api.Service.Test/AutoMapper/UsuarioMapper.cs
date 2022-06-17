using Domain.DTOs.User;
using Domain.Entities;
using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace Api.Service.Test.AutoMapper
{
    public class UsuarioMapper : BaseTestService
    {
        [Fact(DisplayName = "É Possível mapear os Modelos")]

        public void _E_Possivel_Mapear_os_Modelos()
        {
            var model = new UserModel
            {
                Id = Guid.NewGuid(),
                Name = Faker.Name.FullName(),
                Email = Faker.Internet.Email(),
                CreateAt = DateTime.UtcNow,
                UpdateAt = DateTime.UtcNow
            };

            var listaEntity = new List<UserEntity>();

            for (int i = 0; i < 5; i++)
            {
                var item = new UserEntity
                {
                    Id = Guid.NewGuid(),
                    Name = Faker.Name.FullName(),
                    Email = Faker.Internet.Email(),
                    CreateAt = DateTime.UtcNow,
                    UpdateAt = DateTime.UtcNow
                };

                listaEntity.Add(item);
            }

            //Model => Entity
            var entity = mapper.Map<UserEntity>(model);
            Assert.Equal(entity.Id, model.Id);
            Assert.Equal(entity.Name, model.Name);
            Assert.Equal(entity.Email, model.Email);
            Assert.Equal(entity.CreateAt, model.CreateAt);
            Assert.Equal(entity.UpdateAt, model.UpdateAt);

            //Entity para Dto
            var userDto = mapper.Map<UserDTO>(entity);
            Assert.Equal(userDto.Id, entity.Id);
            Assert.Equal(userDto.Name, entity.Name);
            Assert.Equal(userDto.Email, entity.Email);
            Assert.Equal(userDto.CreateAt, entity.CreateAt);

            var listaDTO = mapper.Map<List<UserDTO>>(listaEntity);
            Assert.True(listaDTO.Count() == listaEntity.Count());

            for (int i = 0; i < listaDTO.Count(); i++)
            {
                Assert.Equal(listaDTO[i].Id, listaEntity[i].Id);
                Assert.Equal(listaDTO[i].Name, listaEntity[i].Name);
                Assert.Equal(listaDTO[i].Email, listaEntity[i].Email);
                Assert.Equal(listaDTO[i].CreateAt, listaEntity[i].CreateAt);
            }

            var userDTOCreateResult = mapper.Map<UserDTOCreateResult>(entity);
            Assert.Equal(userDTOCreateResult.Id, entity.Id);
            Assert.Equal(userDTOCreateResult.Name, entity.Name);
            Assert.Equal(userDTOCreateResult.Email, entity.Email);
            Assert.Equal(userDTOCreateResult.CreateAt, entity.CreateAt);

            var userDTOUpdateResult = mapper.Map<UserDTOUpdateResult>(entity);
            Assert.Equal(userDTOUpdateResult.Id, entity.Id);
            Assert.Equal(userDTOUpdateResult.Name, entity.Name);
            Assert.Equal(userDTOUpdateResult.Email, entity.Email);
            Assert.Equal(userDTOUpdateResult.UpdateAt, entity.UpdateAt);

            //dto para model
            var userModel = mapper.Map<UserModel>(userDto);
            Assert.Equal(userModel.Id, userDto.Id);
            Assert.Equal(userModel.Name, userDto.Name);
            Assert.Equal(userModel.Email, userDto.Email);
            Assert.Equal(userModel.CreateAt, userDto.CreateAt);

            var userDTOCreate = mapper.Map<UserDTOCreate>(userModel);
            Assert.Equal(userDTOCreate.Name, userModel.Name);
            Assert.Equal(userDTOCreate.Email, userModel.Email);

            var userDTOUpdate = mapper.Map<UserDTOUpdate>(userModel);
            Assert.Equal(userDTOUpdate.Id, userModel.Id);
            Assert.Equal(userDTOUpdate.Name, userModel.Name);
            Assert.Equal(userDTOUpdate.Email, userModel.Email);
        }
    }
}
