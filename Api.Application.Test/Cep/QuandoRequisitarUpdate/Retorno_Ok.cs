using System;
using System.Threading.Tasks;
using Application.Controllers;
using Domain.DTOs.Cep;
using Domain.Interfaces.Services.Cep;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Xunit;

namespace Api.Application.Test.Cep.QuandoRequisitarUpdate
{
    public class Retorno_Ok
    {
        private CepController _controller;

        [Fact(DisplayName = "É possível Realizar o Updated.")]
        public async Task E_Possivel_Invocar_a_Controller_Create()
        {
            var serviceMock = new Mock<ICepService>();
            serviceMock.Setup(m => m.Put(It.IsAny<CepDTOUpdate>())).ReturnsAsync(
                new CepDTOUpdateResult
                {
                    Id = Guid.NewGuid(),
                    Logradouro = "Teste de Rua",
                    Cep = "10333444",
                    UpdateAt = DateTime.UtcNow
                }
            );

            _controller = new CepController(serviceMock.Object);

            var cepDtoUpdate = new CepDTOUpdate
            {
                Logradouro = "Teste de Rua",
                Cep = "10333444"
            };

            var result = await _controller.Put(cepDtoUpdate);
            Assert.True(result is OkObjectResult);

        }

    }
}
