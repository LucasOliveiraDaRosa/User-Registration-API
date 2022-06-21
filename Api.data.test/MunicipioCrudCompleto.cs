using Data.Context;
using Data.Implementations;
using Domain.Entities;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace Api.Data.Test
{
    public class MunicipioCrudCompleto : BaseTest, IClassFixture<DbTest>
    {
        private ServiceProvider _serviceProvider;

        public MunicipioCrudCompleto(DbTest dbTest)
        {
            _serviceProvider = dbTest.serviceProvider;
        }

        [Fact(DisplayName = "CRUD de Município")]
        [Trait("CRUD", "MunicipioEntity")]
        public async Task E_Possivel_Realizar_CRUD_Municipio()
        {
            using (var context = _serviceProvider.GetService<MyContext>())
            {
                MunicipioImplementation _repositorio = new MunicipioImplementation(context);

                MunicipioEntity _entity = new MunicipioEntity
                {
                    Nome = Faker.Address.City(),
                    CodIBGE = Faker.RandomNumber.Next(1000000,9999999),
                    UFId = new Guid("e7e416de-477c-4fa3-a541-b5af5f35ccf6")
                };

                //post
                var _registroCriado = await _repositorio.InsertAsync(_entity);
                Assert.NotNull(_registroCriado);
                Assert.Equal(_entity.Nome, _registroCriado.Nome);
                Assert.Equal(_entity.CodIBGE, _registroCriado.CodIBGE);
                Assert.Equal(_entity.UFId, _registroCriado.UFId);
                Assert.False(_entity.Id == Guid.Empty);

                //put
                _entity.Nome = Faker.Address.City();
                _entity.Id = _registroCriado.Id;
                var _registroAtualizado = await _repositorio.UpdateAsync(_entity);
                Assert.NotNull(_registroAtualizado);
                Assert.Equal(_entity.Nome, _registroAtualizado.Nome);
                Assert.Equal(_entity.CodIBGE, _registroAtualizado.CodIBGE);
                Assert.Equal(_entity.UFId, _registroAtualizado.UFId);
                Assert.True(_entity.Id == _registroCriado.Id);

                //get
                var _registroExiste = await _repositorio.ExistAsync(_registroAtualizado.Id);
                Assert.True(_registroExiste);

                var _registroSelecionado = await _repositorio.SelectAsync(_registroAtualizado.Id);
                Assert.NotNull(_registroSelecionado);
                Assert.Equal(_registroAtualizado.Nome, _registroSelecionado.Nome);
                Assert.Equal(_registroAtualizado.CodIBGE, _registroSelecionado.CodIBGE);
                Assert.Equal(_registroAtualizado.UFId, _registroSelecionado.UFId);
                Assert.Null(_registroSelecionado.Uf);

                //get por cod ibge
                _registroSelecionado = await _repositorio.GetCompleteByIBGE(_registroAtualizado.CodIBGE);
                Assert.NotNull(_registroSelecionado);
                Assert.Equal(_registroAtualizado.Nome, _registroSelecionado.Nome);
                Assert.Equal(_registroAtualizado.CodIBGE, _registroSelecionado.CodIBGE);
                Assert.Equal(_registroAtualizado.UFId, _registroSelecionado.UFId);
                Assert.NotNull(_registroSelecionado.Uf);

                //get por id
                _registroSelecionado = await _repositorio.GetCompleteById(_registroAtualizado.Id);
                Assert.NotNull(_registroSelecionado);
                Assert.Equal(_registroAtualizado.Nome, _registroSelecionado.Nome);
                Assert.Equal(_registroAtualizado.CodIBGE, _registroSelecionado.CodIBGE);
                Assert.Equal(_registroAtualizado.UFId, _registroSelecionado.UFId);
                Assert.NotNull(_registroSelecionado.Uf);

                //getall
                var _todosRegistros = await _repositorio.SelectAsync();
                Assert.NotNull(_todosRegistros);
                Assert.True(_todosRegistros.Count() > 0);

                //delete
                var _removeu = await _repositorio.DeleteAsync(_registroSelecionado.Id);
                Assert.True(_removeu);
            }
        }
    }
}
