using E_Commerce.Domain.Common;
using E_Commerce.Domain.Contract;
using E_Commerce.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.Infrastructure.Repositories
{
    internal class GenaricRepository<TEntity, TKey>(StoreDbContext dbContext) : IGenaricRepository<TEntity, TKey> where TEntity : BaseEntity<TKey>
    {
        public void Add(TEntity entitiy) => dbContext.Set<TEntity>().Add(entitiy);
        public void Delete(TEntity entitiy) => dbContext.Set<TEntity>().Remove(entitiy);
        public void Update(TEntity entitiy) => dbContext.Set<TEntity>().Update(entitiy);

        public async Task<IReadOnlyList<TEntity>> GetAllAsync(CancellationToken ct = default)
          => await dbContext.Set<TEntity>().ToListAsync(ct);



        public async Task<TEntity?> GetByIdAsync(TKey id, CancellationToken ct = default)
          => await dbContext.Set<TEntity>().FindAsync(id, ct);
      

    }
}
