﻿using System;
using System.Threading.Tasks;
using Application.Controllers;
using Domain.DTOs.Cep;
using Domain.Interfaces.Services.Cep;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Xunit;

namespace Api.Application.Test.Cep.QuandoRequisitarCreate
{
    public class Retorno_Created
    {
        private CepController _controller;

        [Fact(DisplayName = "É possível Realizar o Created.")]
        public async Task E_Possivel_Invocar_a_Controller_Create()
        {
            var serviceMock = new Mock<ICepService>();
            serviceMock.Setup(m => m.Post(It.IsAny<CepDTOCreate>())).ReturnsAsync(
                new CepDTOCreateResult
                {
                    Id = Guid.NewGuid(),
                    Logradouro = "Teste de Rua",
                    CreateAt = DateTime.UtcNow
                }
            );

            _controller = new CepController(serviceMock.Object);

            Mock<IUrlHelper> url = new Mock<IUrlHelper>();
            url.Setup(x => x.Link(It.IsAny<string>(), It.IsAny<object>())).Returns("http://localhost:5000");
            _controller.Url = url.Object;

            var cepDtoCreate = new CepDTOCreate
            {
                Logradouro = "Teste de Rua",
                Numero = ""
            };

            var result = await _controller.Post(cepDtoCreate);
            Assert.True(result is CreatedResult);

        }

    }
}
