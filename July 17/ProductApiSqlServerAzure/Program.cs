using Azure.Identity;
using Azure.Security.KeyVault.Secrets;
using Microsoft.EntityFrameworkCore;
using ProductApiSqlServerAzure.Context;
using ProductApiSqlServerAzure.Interfaces;
using ProductApiSqlServerAzure.Model;
using ProductApiSqlServerAzure.Repositories;
using ProductApiSqlServerAzure.Services;
using System.Numerics;
using Azure.Storage.Blobs;
using Azure.Storage.Blobs.Models;
using System;
using System.IO;
using Microsoft.OpenApi.Models;

namespace ProductApiSqlServerAzure
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            //builder.Services.AddEndpointsApiExplorer();
            //builder.Services.AddSwaggerGen();
            const string secretName1 = "productDbString";
            const string secretName2 = "blobString";
            var keyVaultName = "amanVault";
            var kvUri = $"https://{keyVaultName}.vault.azure.net";

            var client = new SecretClient(new Uri(kvUri), new DefaultAzureCredential());
            Console.WriteLine($"Retrieving your secret from {keyVaultName}.");
            var secret1 = client.GetSecret(secretName1);
            var secret2 = client.GetSecret(secretName2);
            Console.WriteLine($"Your secret is '{secret1.Value.Value}'.");
            builder.Services.AddDbContext<AzureContext>(
            options => options.UseSqlServer(secret1.Value.Value)
            );

            //builder.Services.AddDbContext<AzureContext>(
            //  options => options.UseSqlServer(builder.Configuration.GetConnectionString("defaultConnection"))
            //  );
            // Retrieve the connection string for use with the application. 
            //string connectionString = builder.Configuration.GetConnectionString("blobConnection");
            string connectionString = secret2.Value.Value;

            // Create a BlobServiceClient object 
            var blobServiceClient = new BlobServiceClient(connectionString);

            //string containerName = "imagecontainer" + Guid.NewGuid().ToString();

            //// Create the container and return a container client object
            //BlobContainerClient containerClient = await blobServiceClient.CreateBlobContainerAsync(containerName);

            //// Create a local file in the ./data/ directory for uploading and downloading
            //string localPath = "data";
            //Directory.CreateDirectory(localPath);
            //string fileName = "quickstart" + Guid.NewGuid().ToString() + ".txt";
            //string localFilePath = Path.Combine(localPath, fileName);

            //// Write text to the file
            //await File.WriteAllTextAsync(localFilePath, "Hello, World!");
            //// Get a reference to a blob
            //BlobClient blobClient = containerClient.GetBlobClient(fileName);
            //Console.WriteLine("Uploading to Blob storage as blob:\n\t {0}\n", blobClient.Uri);
            //// Upload data from the local file
            //await blobClient.UploadAsync(localFilePath, true);

            //Console.WriteLine("Listing blobs...");

            //// List all blobs in the container
            //await foreach (BlobItem blobItem in containerClient.GetBlobsAsync())
            //{
            //    Console.WriteLine("\t" + blobItem.Name);
            //}

            builder.Services.AddScoped<IRepository<int, Product>, ProductRepository>();

            builder.Services.AddScoped<IProductService, ProductService>();
            builder.Services.AddSingleton(blobServiceClient);

            var app = builder.Build();
            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }


            //app.UseHttpsRedirection();

            app.UseAuthorization();

            app.MapControllers();

            app.Run();
        }
    }
}