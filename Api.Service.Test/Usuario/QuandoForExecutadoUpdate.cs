
using Domain.Interfaces.Services.User;
using Moq;
using System.Threading.Tasks;
using Xunit;

namespace Api.Service.Test.Usuario
{
    public class QuandoForExecutadoUpdate : UsuarioTestes
    {
        private IUserService _service;
        private Mock<IUserService> _serviceMock;

        [Fact(DisplayName = "É possível executar o metódo UPDATE.")]
        public async Task E_Possivel_Executar_Metodo_Update()
        {
            _serviceMock = new Mock<IUserService>();
            _serviceMock.Setup(m => m.Post(userDTOCreate)).ReturnsAsync(userDTOCreateResult);
            _service = _serviceMock.Object;

            var result = await _service.Post(userDTOCreate);
            Assert.NotNull(result);
            Assert.Equal(NomeUsuario, result.Name);
            Assert.Equal(EmailUsuario, result.Email);


            _serviceMock = new Mock<IUserService>();
            _serviceMock.Setup(m => m.Put(userDTOUpdate)).ReturnsAsync(userDTOUpdateResult);
            _service = _serviceMock.Object;

            var resultUpdate = await _service.Put(userDTOUpdate);
            Assert.NotNull(resultUpdate);
            Assert.Equal(NomeUsuarioAlterado, resultUpdate.Name);
            Assert.Equal(EmailUsuarioAlterado, resultUpdate.Email);

        }
    }
}
