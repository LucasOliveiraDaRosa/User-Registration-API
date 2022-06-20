using Domain.DTOs.Cep;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Domain.Interfaces.Services.Cep
{
    public interface ICepService
    {
        Task<CepDTO> Get(Guid id);

        Task<CepDTO> Get(string cep);

        Task<CepDTOCreateResult> Post(CepDTOCreate municipio);

        Task<CepDTOUpdateResult> Put(CepDTOUpdate municipio);

        Task<bool> Delete(Guid id);
    }
}
