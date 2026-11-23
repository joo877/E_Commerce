
using E_Commerce.API.Extentions;
using E_Commerce.Application;
using E_Commerce.Application.Profiles;
using E_Commerce.Domain.Contract;
using E_Commerce.Infrastructure;
using Microsoft.Extensions.FileProviders;
using System.Threading.Tasks;


namespace E_Commerce.API
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            builder.Services.AddApplicationService();
            builder.Services.AddInfrastrrucureService(builder.Configuration);
            builder.Services.Configure<UrlSettings>(builder.Configuration.GetSection("UrlSettings"));

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();

           await app.SeedAndMigrateAsync();
            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }
            app.UseStaticFiles(new StaticFileOptions()
            {
                FileProvider = new PhysicalFileProvider(Path.Combine(builder.Environment.ContentRootPath, "Files")),
                RequestPath = "/Files"
            });

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
