using E_Commerce.Domain.Contract;
using E_Commerce.Infrastructure.Data;
using E_Commerce.Infrastructure.DataSeeding;
using E_Commerce.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.Infrastructure
{
    public static class InfrastrrucureServiceRegistration
    {

        public static IServiceCollection AddInfrastrrucureService(this IServiceCollection Services  , IConfiguration configuration)
        {
            Services.AddDbContext<StoreDbContext>(option =>
            option.UseSqlServer(configuration.GetConnectionString("DefaultConnection") )


            );
            Services.AddKeyedScoped<IDataSeader, CatalogDataSeeder>("Catalog");
            Services.AddScoped<IUnitOfWork , UnitOfWork>();

            return Services;
        
        }

    }
}
