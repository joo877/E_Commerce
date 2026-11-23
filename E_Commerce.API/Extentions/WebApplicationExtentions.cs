using E_Commerce.Domain.Contract;

namespace E_Commerce.API.Extentions
{
    public static class WebApplicationExtentions
    {

        public async static Task<WebApplication> SeedAndMigrateAsync(this WebApplication app ,CancellationToken ct = default)
        {
            using var scope = app.Services.CreateScope();
            var seeder = scope.ServiceProvider.GetRequiredKeyedService<IDataSeader>("Catalog");
            await seeder.SeedDataAsync();


            return app;

        }

    }
}
