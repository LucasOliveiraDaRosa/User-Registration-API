using Data.Context;
using Data.Implementations;
using Domain.Entities;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Api.Data.Test
{
    public class CepCrudCompleto : BaseTest, IClassFixture<DbTest>
    {
        private ServiceProvider _serviceProvider;

        public CepCrudCompleto(DbTest dbTest)
        {
            _serviceProvider = dbTest.serviceProvider;
        }
        [Fact(DisplayName = "CRUD de Cep")]
        [Trait("CRUD", "CepEntity")]
        public async Task E_Possivel_Realizar_CRUD_Cep()
        {
            using (var context = _serviceProvider.GetService<MyContext>())
            {
                MunicipioImplementation _repositorioMunicipio = new MunicipioImplementation(context);

                MunicipioEntity _entityMunicipio = new MunicipioEntity
                {
                    Nome = Faker.Address.City(),
                    CodIBGE = Faker.RandomNumber.Next(1000000, 9999999),
                    UFId = new Guid("e7e416de-477c-4fa3-a541-b5af5f35ccf6")
                };

                //post
                var _registroCriado = await _repositorioMunicipio.InsertAsync(_entityMunicipio);
                Assert.NotNull(_registroCriado);
                Assert.Equal(_entityMunicipio.Nome, _registroCriado.Nome);
                Assert.Equal(_entityMunicipio.CodIBGE, _registroCriado.CodIBGE);
                Assert.Equal(_entityMunicipio.UFId, _registroCriado.UFId);
                Assert.False(_entityMunicipio.Id == Guid.Empty);

                CepImplementations _repositorioCep = new CepImplementations(context);

                CepEntity _entityCep = new CepEntity
                {
                    Cep = "13.481-001",
                    Logradouro = Faker.Address.StreetName(),
                    Numero = "0 até 200",
                    MunicipioId = _registroCriado.Id
                };

                var _registroCriadoCep = await _repositorioCep.InsertAsync(_entityCep);
                Assert.NotNull(_registroCriadoCep);
                Assert.Equal(_entityCep.Cep, _registroCriadoCep.Cep);
                Assert.Equal(_entityCep.Logradouro, _registroCriadoCep.Logradouro);
                Assert.Equal(_entityCep.Numero, _registroCriadoCep.Numero);
                Assert.Equal(_entityCep.MunicipioId, _registroCriadoCep.MunicipioId);
                Assert.False(_registroCriadoCep.Id == Guid.Empty);

                _entityCep.Logradouro = Faker.Address.StreetName();
                _entityCep.Id = _registroCriadoCep.Id;
                var _registroAtualizado = await _repositorioCep.UpdateAsync(_entityCep);
                Assert.NotNull(_registroAtualizado);
                Assert.Equal(_entityCep.Cep, _registroAtualizado.Cep);
                Assert.Equal(_entityCep.Logradouro, _registroAtualizado.Logradouro);
                Assert.Equal(_entityCep.MunicipioId, _registroAtualizado.MunicipioId);
                Assert.True(_registroCriadoCep.Id == _entityCep.Id);

                //get por id
                var _registroExiste = await _repositorioCep.ExistAsync(_registroAtualizado.Id);
                Assert.True(_registroExiste);

                var _registroSelecionado = await _repositorioCep.SelectAsync(_registroAtualizado.Id);
                Assert.NotNull(_registroSelecionado);
                Assert.Equal(_registroAtualizado.Cep, _registroSelecionado.Cep);
                Assert.Equal(_registroAtualizado.Logradouro, _registroSelecionado.Logradouro);
                Assert.Equal(_registroAtualizado.MunicipioId, _registroSelecionado.MunicipioId);

                //get por cep
                _registroSelecionado = await _repositorioCep.SelectAsync(_registroAtualizado.Cep);
                Assert.NotNull(_registroSelecionado);
                Assert.Equal(_registroAtualizado.Cep, _registroSelecionado.Cep);
                Assert.Equal(_registroAtualizado.Logradouro, _registroSelecionado.Logradouro);
                Assert.Equal(_registroAtualizado.MunicipioId, _registroSelecionado.MunicipioId);
                Assert.NotNull(_registroSelecionado.Municipio);
                Assert.NotNull(_registroSelecionado.Municipio.Uf);
                Assert.Equal(_entityMunicipio.Nome, _registroSelecionado.Municipio.Nome);
                Assert.NotNull(_registroSelecionado.Municipio.Uf);
                Assert.Equal("SP", _registroSelecionado.Municipio.Uf.Sigla);

                var _todosRegistros = await _repositorioCep.SelectAsync();
                Assert.NotNull(_todosRegistros);
                Assert.True(_todosRegistros.Count() > 0);

                var _removeu = await _repositorioCep.DeleteAsync(_registroSelecionado.Id);
                Assert.True(_removeu);

                _todosRegistros = await _repositorioCep.SelectAsync();
                Assert.NotNull(_todosRegistros);
                Assert.True(_todosRegistros.Count() == 0);
            }
        }

    }
}
