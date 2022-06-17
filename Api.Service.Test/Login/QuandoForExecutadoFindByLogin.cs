using Domain.DTOs;
using Domain.Interfaces.Services.User;
using Moq;
using System;
using System.Threading.Tasks;
using Xunit;

namespace Api.Service.Test.Login
{
    public class QuandoForExecutadoFindByLogin
    {
        private ILoginService _service;

        private Mock<ILoginService> _serviceMock;

        [Fact(DisplayName = "É Possível executar o Método FindByLogin.")]
        public async Task E_Possivel_Executar_FindByLogin()
        {
            var email = Faker.Internet.Email();

            var objetoRetorno = new
            {
                authenticated = true,
                created = DateTime.UtcNow,
                expiration = DateTime.UtcNow.AddHours(8),
                acessToken = Guid.NewGuid(),
                userName = email,
                message = "Usuário Logado com sucesso."
            };


            var loginDTO = new LoginDTO
            {
                Email = email
            };

            _serviceMock = new Mock<ILoginService>();
            _serviceMock.Setup(m => m.FindByLogin(loginDTO)).ReturnsAsync(objetoRetorno);

            _service = _serviceMock.Object;

            var result = await _service.FindByLogin(loginDTO);
            Assert.NotNull(result);

        }
    }
}
