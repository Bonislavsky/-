using HotelsSite.API.Controllers;
using HotelsSite.Application.Hotels;
using HotelsSite.Infrastructure.Database;
using HotelsSite.Infrastructure.Error;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace HotelsSite.API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddControllers();

            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));

            
            var connection = builder.Configuration.GetConnectionString("HotelsSiteConnection");
            builder.Services.AddDbContext<HotelsSiteContext>(options => options.UseSqlServer(connection));

            //builder.Services.AddScoped<HotelController>();
            builder.Services.AddScoped<HotelHandler>();

            var app = builder.Build();

            app.UseMiddleware<ErrorHandlingMiddleware>();

            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}