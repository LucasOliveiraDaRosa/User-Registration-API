using System;
using System.Threading.Tasks;
using Application.Controllers;
using Domain.DTOs.Municipio;
using Domain.Interfaces.Services.Municipio;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Xunit;


namespace Api.Application.Test.Municipio.QuandoRequisitarGetCompleteById
{
    public class Retorno_OK
    {
        private MunicipioController _controller;

        [Fact(DisplayName = "É possível Realizar o Get.")]
        public async Task E_Possivel_Invocar_a_Controller_Get()
        {
            var serviceMock = new Mock<IMunicipioService>();

            serviceMock.Setup(m => m.GetCompleteById(It.IsAny<Guid>())).ReturnsAsync(
                 new MunicipioDTOCompleto
                 {
                     Id = Guid.NewGuid(),
                     Nome = "São Paulo",
                 }
            );

            _controller = new MunicipioController(serviceMock.Object);

            var result = await _controller.GetCompleteById(Guid.NewGuid());
            Assert.True(result is OkObjectResult);

        }
    }
}
