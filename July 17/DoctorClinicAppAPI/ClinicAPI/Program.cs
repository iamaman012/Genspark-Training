
using Azure.Identity;
using Azure.Security.KeyVault.Secrets;
using ClinicAPI.Contexts;
using ClinicAPI.Interfaces;
using ClinicAPI.models;
using ClinicAPI.Repositories;
using ClinicAPI.services;
using Microsoft.EntityFrameworkCore;

namespace ClinicAPI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            const string secretName = "dbstringnew5";
            var keyVaultName = "key-string-aman";
            var kvUri = $"https://{keyVaultName}.vault.azure.net";

            var client = new SecretClient(new Uri(kvUri), new DefaultAzureCredential());
            Console.WriteLine($"Retrieving your secret from {keyVaultName}.");
            var secret =  client.GetSecret(secretName);
            Console.WriteLine($"Your secret is '{secret.Value.Value}'.");

            //builder.Services.AddDbContext<ClinicContext>(
            //  options => options.UseSqlServer(builder.Configuration.GetConnectionString("defaultConnection"))
            //  );
            builder.Services.AddDbContext<ClinicContext>(
             options => options.UseSqlServer(secret.Value.Value)
             ) ;

            builder.Services.AddScoped<IRepository<int, Doctor>, DoctorRepository>();

            builder.Services.AddScoped<IDoctorService, DoctorService>();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
