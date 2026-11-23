using AutoMapper;
using AutoMapper.Execution;
using E_Commerce.Application.DTOs.Products;
using E_Commerce.Domain.Entities;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.Application.Profiles
{
    internal class PictureUrlResolver : IValueResolver<Products, ProductDto, string>
    {
        private readonly UrlSettings _urlSettings;

        public PictureUrlResolver(IOptions<UrlSettings> options )
        {
            _urlSettings = options.Value;
        }

        public string Resolve(Products source, ProductDto destination, string destMember, ResolutionContext context)
        {

            var baseUrl = _urlSettings.BaseUrl.TrimEnd('/');
            var path = source.PictureUrl.TrimStart('/');
            return $"{baseUrl}/Files/{path}";

        }


    }

    public class UrlSettings
    {
        public string BaseUrl { get; set; }

    }
}
