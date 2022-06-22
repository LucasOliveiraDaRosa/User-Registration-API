using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Application.Controllers;
using Domain.DTOs.Municipio;
using Domain.Interfaces.Services.Municipio;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Xunit;

namespace Api.Application.Test.Municipio.QuandoRequisitarGetAll
{
    public class Retorno_OK
    {
        private MunicipioController _controller;

        [Fact(DisplayName = "É possível Realizar o GetAll.")]
        public async Task E_Possivel_Invocar_a_Controller_GetAll()
        {
            var serviceMock = new Mock<IMunicipioService>();
            serviceMock.Setup(m => m.GetAll()).ReturnsAsync(
                 new List<MunicipioDTO>
                 {
                    new MunicipioDTO
                    {
                        Id = Guid.NewGuid(),
                        Nome = "São Paulo",
                    },
                    new MunicipioDTO
                    {
                        Id = Guid.NewGuid(),
                        Nome = "Limeira",
                    }
                 }
            );

            _controller = new MunicipioController(serviceMock.Object);
            var result = await _controller.GetAll();
            Assert.True(result is OkObjectResult);

        }
    }
}
