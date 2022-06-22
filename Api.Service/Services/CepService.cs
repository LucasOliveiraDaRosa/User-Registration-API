using AutoMapper;
using Domain.DTOs.Cep;
using Domain.Entities;
using Domain.Interfaces.Services.Cep;
using Domain.Models;
using Domain.Repository;
using System;
using System.Threading.Tasks;

namespace Service.Services
{
    public class CepService : ICepService
    {
        private ICepRepository _repository;
        private readonly IMapper _mapper;
        public CepService(ICepRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<CepDTO> Get(Guid id)
        {
            var entity = await _repository.SelectAsync(id);
            return _mapper.Map<CepDTO>(entity);
        }

        public async Task<CepDTO> Get(string cep)
        {
            var entity = await _repository.SelectAsync(cep);
            return _mapper.Map<CepDTO>(entity);
        }

        public async Task<CepDTOCreateResult> Post(CepDTOCreate cep)
        {
            var model = _mapper.Map<CepModel>(cep);

            var entity = _mapper.Map<CepEntity>(model);

            var result = await _repository.InsertAsync(entity);

            return _mapper.Map<CepDTOCreateResult>(result);
        }

        public async Task<CepDTOUpdateResult> Put(CepDTOUpdate cep)
        {
            var model = _mapper.Map<CepModel>(cep);
            var entity = _mapper.Map<CepEntity>(model);

            var result = await _repository.UpdateAsync(entity);
            return _mapper.Map<CepDTOUpdateResult>(result);
        }

        public async Task<bool> Delete(Guid id)
        {
            return await _repository.DeleteAsync(id);
        }
    }
}
