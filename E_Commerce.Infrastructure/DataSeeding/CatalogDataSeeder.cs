using E_Commerce.Domain.Common;
using E_Commerce.Domain.Contract;
using E_Commerce.Domain.Entities;
using E_Commerce.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace E_Commerce.Infrastructure.DataSeeding
{
    internal class CatalogDataSeeder(StoreDbContext dbContext, ILogger<CatalogDataSeeder> logger) : IDataSeader
    {
        public async Task SeedDataAsync(CancellationToken ct = default)
        {
            var pendingMagiration = await dbContext.Database.GetPendingMigrationsAsync(ct);
            if (pendingMagiration.Any())
                await dbContext.Database.MigrateAsync(ct);
                

            //D:\.Net Ass\programming tasks\E_Commerce\E_Commerce.API\bin\Debug\net8.0\DataSeed/{FileName}
            var seedPath = Path.Combine(AppContext.BaseDirectory , "DataSeed");

          await  SeedIfEmptyAsync<Brands, int>(seedPath, "brands.json", ct);
           
   await dbContext.SaveChangesAsync(ct);
          await  SeedIfEmptyAsync<Types,int>(seedPath, "types.json", ct);
             await dbContext.SaveChangesAsync(ct);
   
          await SeedIfEmptyAsync<Products, int>(seedPath, "products.json", ct);
        
            var result = await dbContext.SaveChangesAsync(ct);
            if (result > 0)
                logger.LogInformation($"{result} Rows Added");
            else
                logger.LogInformation("Database Already Seeded");

        }

        private async Task SeedIfEmptyAsync<T,TKey>(string rootPath, string fileName, CancellationToken ct) where T : BaseEntity<TKey>
        {
            if (await dbContext.Set<T>().AnyAsync())
            {
                logger.LogInformation("Table  Already Has Data");
                return;
            }
            var filePath = Path.Combine(rootPath, fileName);
            if (!File.Exists(filePath))
            {
                logger.LogWarning($"{fileName} Is Not Found");
                return;
            }

            using var fileStream = File.OpenRead(filePath);
            var option = new JsonSerializerOptions() {PropertyNameCaseInsensitive = true };

            var items = JsonSerializer.Deserialize<List<T>>(fileStream, option);
            if (items?.Any() ?? false)
                dbContext.Set<T>().AddRange(items);

        
        
        }
    }
}
