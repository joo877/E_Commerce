using AutoMapper;
using E_Commerce.Application.Common;
using E_Commerce.Application.Contract;
using E_Commerce.Application.DTOs.Products;
using E_Commerce.Domain.Contract;
using E_Commerce.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.Application.Servieces
{
    internal class ProductServieces : IProductServieces
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public ProductServieces(IUnitOfWork unitOfWork , IMapper mapper  )
        {
           _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<Result<IReadOnlyList<BrandDto>>> GetAlLBrandAsync(CancellationToken ct = default)
        {
            var brands = await _unitOfWork.GetRepository<Brands, int>().GetAllAsync(ct);
            var brandsMpped = _mapper.Map<IReadOnlyList<BrandDto>>(brands);
            return Result<IReadOnlyList<BrandDto>>.OK(brandsMpped);
        }

        public async Task<Result<IReadOnlyList<ProductDto>>> GetAllProductsAsync(CancellationToken ct = default)
        {
            var products = await _unitOfWork.GetRepository<Products, int>().GetAllAsync(ct);
            var productsMpped = _mapper.Map<IReadOnlyList<ProductDto>>(products);
            return Result<IReadOnlyList<ProductDto>>.OK(productsMpped);
        }

        public async Task<Result<IReadOnlyList<TypeDto>>> GetAllTypesAsync(CancellationToken ct = default)
        {
            var types = await _unitOfWork.GetRepository<Types, int>().GetAllAsync(ct);
            var typesMpped = _mapper.Map<IReadOnlyList<TypeDto>>(types);
            return Result<IReadOnlyList<TypeDto>>.OK(typesMpped);
        }

        public async Task<Result<ProductDto>?> GetProductByIdAsync(int id, CancellationToken ct = default)
        {
            var product = await _unitOfWork.GetRepository<Products,int>().GetByIdAsync(id, ct);
            if (product == null) return Result<ProductDto>.Fail(Error.NotFound("Product Not Found",$"Product {id} NOt Found"));

            var productsMpped = _mapper.Map<ProductDto>(product);
            return Result<ProductDto>.OK(productsMpped);


        }
    }
}
