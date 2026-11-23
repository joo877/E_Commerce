using E_Commerce.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.Domain.Contract
{
    public interface IUnitOfWork
    {

        IGenaricRepository<TEnity, TKey> GetRepository<TEnity, TKey>() where TEnity:BaseEntity<TKey> ; 

        Task<int> SaveChangeAsync(CancellationToken ct = default);
    }
}
