using E_Commerce.Application.Common;
using E_Commerce.Application.Contract;
using E_Commerce.Application.DTOs.Products;
using E_Commerce.Domain.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace E_Commerce.API.Controllers
{
 
    public class ProductsController : ApiBaseController
    {
        private readonly IProductServieces _productServieces;

        public ProductsController(IProductServieces productServieces)
        {
            _productServieces = productServieces;
        }

        // Get All Product 
        [HttpGet]
        public async Task<ActionResult<IReadOnlyList<ProductDto>>> GetAllProductAsync(CancellationToken ct)
        {
            var products = await _productServieces.GetAllProductsAsync(ct);
            return ToActionResult(products);

        }
        // Get Product By Id
        
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]

        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<ProductDto>> GetProductByIdAsync(int id, CancellationToken ct)
        {
            var product = await _productServieces.GetProductByIdAsync(id, ct);
            return ToActionResult(product);
           

        }
        // Get All Brands
        [HttpGet("brands")]
        public async Task<ActionResult<IReadOnlyList<BrandDto>>> GetAlLBrandAsync(CancellationToken ct)
        {
            var Brands = await _productServieces.GetAlLBrandAsync(ct);
            return ToActionResult(Brands);

        }
        // Get All Types
        [HttpGet("types")]
        public async Task<ActionResult<IReadOnlyList<TypeDto>>> GetAllTypesAsync(CancellationToken ct)
        {
            var Types = await _productServieces.GetAllTypesAsync(ct);
            return ToActionResult(Types);

        }
    }
}
