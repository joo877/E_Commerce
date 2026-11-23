using E_Commerce.Domain.Contract;
using E_Commerce.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.Infrastructure.Repositories
{
    internal class UnitOfWork(StoreDbContext dbContext) : IUnitOfWork
    {
        private readonly Dictionary<string, object> repositories = [];
        IGenaricRepository<TEnity, TKey> IUnitOfWork.GetRepository<TEnity, TKey>()
        {
            var typeName = typeof(TEnity).Name;
            if (repositories.TryGetValue(typeName, out object? value))
                return (IGenaricRepository<TEnity, TKey>)value;
            else
            {
                var repo = new GenaricRepository<TEnity, TKey>(dbContext);
                repositories[typeName] = repo;
                return repo;

           
            };
            

        }

        async Task<int> IUnitOfWork.SaveChangeAsync(CancellationToken ct) => await dbContext.SaveChangesAsync(ct);
    }
}
