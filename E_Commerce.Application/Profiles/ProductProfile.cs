using AutoMapper;
using E_Commerce.Application.DTOs.Products;
using E_Commerce.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.Application.Profiles
{
    internal class ProductProfile : Profile
    {

        public ProductProfile()
        {
            CreateMap<Brands,BrandDto>();
            CreateMap<Types,TypeDto>();
            CreateMap<Products, ProductDto>()
                .ForMember(des => des.ProductBrand, opt => opt.MapFrom(src => src.ProductBrand.Name))
                .ForMember(des => des.ProductType, opt => opt.MapFrom(src => src.ProductType.Name))
                .ForMember(des => des.PictureUrl, opt => opt.MapFrom<PictureUrlResolver>());
        }

    }
}
