using Data.Context;
using Data.Repository;
using Domain.Entities;
using Domain.Repository;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace Data.Implementations
{
    public class CepImplementations : BaseRepository<CepEntity>, ICepRepository
    {
        private DbSet<CepEntity> _dataset;

        public CepImplementations(MyContext context) : base(context)
        {
            _dataset = context.Set<CepEntity>();
        }

        public async Task<CepEntity> SelectAsync(string cep)
        {
            return await _dataset.Include(c => c.Municipio)
                .ThenInclude(m => m.Uf)
                .FirstOrDefaultAsync(u => u.Cep.Equals(cep));
        }
    }
}
