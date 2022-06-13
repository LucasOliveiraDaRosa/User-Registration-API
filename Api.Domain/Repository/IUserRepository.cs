using Domain.Entities;
using Domain.Interfaces;
using System.Threading.Tasks;

namespace Domain.Repository
{
    public interface IUserRepository: IRepository<UserEntity>
    {
        Task<UserEntity> FindByLogin(string email);
    }
}
