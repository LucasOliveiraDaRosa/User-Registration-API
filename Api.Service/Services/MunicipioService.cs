using AutoMapper;
using Domain.DTOs.Municipio;
using Domain.Entities;
using Domain.Interfaces.Services.Municipio;
using Domain.Models;
using Domain.Repository;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Service.Services
{
    public class MunicipioService : IMunicipioService
    {
        private IMunicipioRepository _repository;
        private readonly IMapper _mapper;

        public MunicipioService(IMunicipioRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<MunicipioDTO> Get(Guid id)
        {
            var entity = await _repository.SelectAsync(id);
            return _mapper.Map<MunicipioDTO>(entity);
        }

        public async Task<MunicipioDTOCompleto> GetCompleteById(Guid id)
        {
            var entity = await _repository.GetCompleteById(id);
            return _mapper.Map<MunicipioDTOCompleto>(entity);
        }

        public async Task<MunicipioDTOCompleto> GetCompleteByIBGE(int codIBGE)
        {
            var entity = await _repository.GetCompleteByIBGE(codIBGE);
            return _mapper.Map<MunicipioDTOCompleto>(entity);
        }

        public async Task<IEnumerable<MunicipioDTO>> GetAll()
        {
            var listEntity = await _repository.SelectAsync();

            return _mapper.Map<IEnumerable<MunicipioDTO>>(listEntity);
        }

        public async Task<MunicipioDTOCreateResult> Post(MunicipioDTOCreate municipio)
        {
            var model = _mapper.Map<MunicipioModel>(municipio);

            var entity = _mapper.Map<MunicipioEntity>(model);

            var result = await _repository.InsertAsync(entity);

            return _mapper.Map<MunicipioDTOCreateResult>(result);
        }

        public async Task<MunicipioDTOUpdateResult> Put(MunicipioDTOUpdate municipio)
        {
            var model = _mapper.Map<MunicipioModel>(municipio);

            var entity = _mapper.Map<MunicipioEntity>(model);

            var result = await _repository.UpdateAsync(entity);

            return _mapper.Map<MunicipioDTOUpdateResult>(result);
        }

        public async Task<bool> Delete(Guid id)
        {
            return await _repository.DeleteAsync(id);
        }
    }
}
