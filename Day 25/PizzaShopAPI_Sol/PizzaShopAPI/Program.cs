
using PizzaShopAPI.Contexts;
using PizzaShopAPI.Interfaces;
using PizzaShopAPI.Models;
using PizzaShopAPI.Repositories;
using PizzaShopAPI.Services;

namespace PizzaShopAPI
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
            #region Context
            builder.Services.AddDbContext<PizzaShopContext>();
            #endregion
            #region Repositories
            builder.Services.AddScoped<IRepository<int, Pizza>, PizzaRepository>();
            #endregion
            #region Services
            builder.Services.AddScoped<IPizzaService, PizzaService>();
            #endregion
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
