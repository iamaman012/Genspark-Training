using Azure.Identity;
using Azure.Security.KeyVault.Secrets;
using Microsoft.EntityFrameworkCore;
using ProductApiSqlServerAzure.Context;
using ProductApiSqlServerAzure.Interfaces;
using ProductApiSqlServerAzure.Model;
using ProductApiSqlServerAzure.Repositories;
using ProductApiSqlServerAzure.Services;
using System.Numerics;

namespace ProductApiSqlServerAzure
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            //builder.Services.AddEndpointsApiExplorer();
            //builder.Services.AddSwaggerGen();
            const string secretName = "productDbString";
            var keyVaultName = "amanVault";
            var kvUri = $"https://{keyVaultName}.vault.azure.net";

            var client = new SecretClient(new Uri(kvUri), new DefaultAzureCredential());
            Console.WriteLine($"Retrieving your secret from {keyVaultName}.");
            var secret = client.GetSecret(secretName);
            Console.WriteLine($"Your secret is '{secret.Value.Value}'.");

            //builder.Services.AddDbContext<AzureContext>(
            //  options => options.UseSqlServer(builder.Configuration.GetConnectionString("defaultConnection"))
            //  );
            builder.Services.AddDbContext<AzureContext>(
            options => options.UseSqlServer(secret.Value.Value)
            );
            builder.Services.AddScoped<IRepository<int, Product>, ProductRepository>();

            builder.Services.AddScoped<IProductService, ProductService>();

            var app = builder.Build();

            // Configure the HTTP request pipeline.

            app.UseHttpsRedirection();

            app.UseAuthorization();

            app.MapControllers();

            app.Run();
        }
    }
}