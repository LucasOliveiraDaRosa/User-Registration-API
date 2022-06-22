using System;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Domain.DTOs.Cep;
using Domain.DTOs.Municipio;
using Newtonsoft.Json;
using Xunit;

namespace Api.Integration.Test.Cep
{
    public class QuandoRequisitarCep : BaseIntegration
    {
        [Fact]
        public async Task E_Possivel_Realizar_Crud_CEP()
        {
            await AdicionarToken();

            var municipioDto = new MunicipioDTOCreate()
            {
                Nome = "São Paulo",
                CodIBGE = 3550308,
                UfId = new Guid("e7e416de-477c-4fa3-a541-b5af5f35ccf6")
            };

            //Post
            var response = await PostJsonAsync(municipioDto, $"{hostApi}municipio", client);
            var postResult = await response.Content.ReadAsStringAsync();
            var registroPost = JsonConvert.DeserializeObject<MunicipioDTOCreateResult>(postResult);
            Assert.Equal(HttpStatusCode.Created, response.StatusCode);
            Assert.Equal("São Paulo", registroPost.Nome);
            Assert.Equal(3550308, registroPost.CodIBGE);
            Assert.True(registroPost.Id != default(Guid));

            var cepDto = new CepDTOCreate()
            {
                Cep = "13480180",
                Logradouro = "Rua Boa Morte",
                Numero = "até nº 200",
                MunicipioId = registroPost.Id
            };

            //Post
            response = await PostJsonAsync(cepDto, $"{hostApi}Cep", client);
            postResult = await response.Content.ReadAsStringAsync();
            var registroCepPost = JsonConvert.DeserializeObject<CepDTOCreateResult>(postResult);
            Assert.Equal(HttpStatusCode.Created, response.StatusCode);
            Assert.Equal(cepDto.Cep, registroCepPost.Cep);
            Assert.Equal(cepDto.Logradouro, registroCepPost.Logradouro);
            Assert.Equal(cepDto.Numero, registroCepPost.Numero);
            Assert.True(registroCepPost.Id != default(Guid));

            var cepMunicipioDto = new CepDTOUpdate()
            {
                Id = registroCepPost.Id,
                Cep = "13480180",
                Logradouro = "Rua da Liberdade",
                Numero = "até nº 200",
                MunicipioId = registroPost.Id
            };

            //PUT
            var stringContent = new StringContent(JsonConvert.SerializeObject(cepMunicipioDto),
                                    Encoding.UTF8, "application/json");
            response = await client.PutAsync($"{hostApi}cep", stringContent);
            var jsonResult = await response.Content.ReadAsStringAsync();
            var registroAtualizado = JsonConvert.DeserializeObject<CepDTOUpdateResult>(jsonResult);

            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
            Assert.Equal(cepMunicipioDto.Logradouro, registroAtualizado.Logradouro);

            //GET Id
            response = await client.GetAsync($"{hostApi}cep/{registroAtualizado.Id}");
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
            jsonResult = await response.Content.ReadAsStringAsync();
            var registroSelecionado = JsonConvert.DeserializeObject<CepDTO>(jsonResult);
            Assert.NotNull(registroSelecionado);
            Assert.Equal(cepMunicipioDto.Logradouro, registroSelecionado.Logradouro);

            //GET Cep
            response = await client.GetAsync($"{hostApi}cep/byCep/{registroAtualizado.Cep}");
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
            jsonResult = await response.Content.ReadAsStringAsync();
            registroSelecionado = JsonConvert.DeserializeObject<CepDTO>(jsonResult);
            Assert.NotNull(registroSelecionado);
            Assert.NotEqual(cepMunicipioDto.Logradouro, registroSelecionado.Logradouro);

            //DELETE
            response = await client.DeleteAsync($"{hostApi}cep/{registroSelecionado.Id}");
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);

            //GET ID depois do DELETE
            response = await client.GetAsync($"{hostApi}cep/{registroSelecionado.Id}");
            Assert.Equal(HttpStatusCode.NotFound, response.StatusCode);

        }
    }
}
