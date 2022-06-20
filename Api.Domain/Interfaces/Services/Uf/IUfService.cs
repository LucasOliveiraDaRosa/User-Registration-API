using Domain.DTOs.Uf;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Domain.Interfaces.Services.Uf
{
    public interface IUfService
    {
        Task<UfDTO> Get(Guid id);

        Task<IEnumerable<UfDTO>> GetAll();
    }
}
