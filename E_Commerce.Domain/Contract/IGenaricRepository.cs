using E_Commerce.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.Domain.Contract
{
    public interface IGenaricRepository<TEntitiy , TKey> where TEntitiy: BaseEntity<TKey>
    {
        void Add(TEntitiy entitiy); 
        void Update(TEntitiy entitiy); 
        void Delete(TEntitiy entitiy);

        Task<IReadOnlyList<TEntitiy>> GetAllAsync(CancellationToken ct = default);
        Task<TEntitiy?> GetByIdAsync(TKey id, CancellationToken ct = default);


    }
}
