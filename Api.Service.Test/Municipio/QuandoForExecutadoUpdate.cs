using Domain.Interfaces.Services.Municipio;
using Moq;
using System.Threading.Tasks;
using Xunit;

namespace Api.Service.Test.Municipio
{
    public class QuandoForExecutadoUpdate : MunicipioTestes
    {
        private IMunicipioService _service;
        private Mock<IMunicipioService> _serviceMock;

        [Fact(DisplayName = "É Possivel executar o Método Update.")]
        public async Task E_Possivel_Executar_Metodo_Update()
        {
            _serviceMock = new Mock<IMunicipioService>();
            _serviceMock.Setup(m => m.Put(municipioDTOUpdate)).ReturnsAsync(municipioDTOUpdateResult);
            _service = _serviceMock.Object;

            var resultUpdate = await _service.Put(municipioDTOUpdate);
            Assert.NotNull(resultUpdate);
            Assert.Equal(NomeMunicipioAlterado, resultUpdate.Nome);
            Assert.Equal(CodigoIBGEMunicipioAlterado, resultUpdate.CodIBGE);
            Assert.Equal(IdUf, resultUpdate.UfId);

        }
    }
}
