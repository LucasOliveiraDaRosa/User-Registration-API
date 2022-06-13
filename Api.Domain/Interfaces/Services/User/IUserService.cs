using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Domain.DTOs.User;
using Domain.Entities;


namespace Domain.Interfaces.Services.User
{
    public interface IUserService
    {
        Task<UserDTO> Get(Guid id);

        Task<IEnumerable<UserDTO>> GetAll();

        Task<UserDTOCreateResult> Post(UserDTOCreate user);

        Task<UserDTOUpdateResult> Put(UserDTOUpdate user);

        Task<bool> Delete(Guid id);

    }
}
