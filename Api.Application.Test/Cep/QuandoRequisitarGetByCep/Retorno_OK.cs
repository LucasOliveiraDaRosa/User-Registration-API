using System;
using System.Threading.Tasks;
using Application.Controllers;
using Domain.DTOs.Cep;
using Domain.Interfaces.Services.Cep;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Xunit;

namespace Application.Test.Cep.QuandoRequisitarGet
{
    public class Retorno_OK
    {
        private CepController _controller;

        [Fact(DisplayName = "É possível Realizar o Get.")]
        public async Task E_Possivel_Invocar_a_Controller_Get()
        {
            var serviceMock = new Mock<ICepService>();

            serviceMock.Setup(m => m.Get(It.IsAny<string>())).ReturnsAsync(
                 new CepDTO
                 {
                     Id = Guid.NewGuid(),
                     Logradouro = "Teste de Rua",
                 }
            );

            _controller = new CepController(serviceMock.Object);

            var result = await _controller.Get("13480000");
            Assert.True(result is OkObjectResult);

        }
    }
}
