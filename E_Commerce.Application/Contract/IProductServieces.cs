using E_Commerce.Application.Common;
using E_Commerce.Application.DTOs.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.Application.Contract
{
    public interface IProductServieces
    {
        Task<Result<IReadOnlyList<ProductDto>>> GetAllProductsAsync(CancellationToken ct = default);
        Task<Result<ProductDto>?> GetProductByIdAsync(int id,CancellationToken ct = default);
        Task<Result<IReadOnlyList<TypeDto>>> GetAllTypesAsync(CancellationToken ct = default);
        Task<Result<IReadOnlyList<BrandDto>>> GetAlLBrandAsync(CancellationToken ct = default);

    }
}
