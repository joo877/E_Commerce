using E_Commerce.Application.Contract;
using E_Commerce.Application.Profiles;
using E_Commerce.Application.Servieces;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static E_Commerce.Application.Profiles.PictureUrlResolver;

namespace E_Commerce.Application
{
    public static class ApplicationServiceRegistration
    {
        public static IServiceCollection AddApplicationService(this IServiceCollection Services)
        {
            Services.AddAutoMapper(config => { } , typeof(ApplicationServiceRegistration).Assembly);
            Services.AddScoped<IProductServieces, ProductServieces>();
         
            return Services;


        }


    }
}
