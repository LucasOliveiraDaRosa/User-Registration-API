using Data.Context;
using Data.Repository;
using Domain.Entities;
using Domain.Repository;
using Microsoft.EntityFrameworkCore;

namespace Data.Implementations
{
    public class UfImplementations : BaseRepository<UFEntity>, IUfRepository
    {
        private DbSet<UFEntity> _dataset;

        public UfImplementations(MyContext context) : base(context)
        {
            _dataset = context.Set<UFEntity>();
        }

    }
}
