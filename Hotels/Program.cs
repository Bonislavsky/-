using HotelsSite.API.Controllers;
using HotelsSite.Application.HotelNumbers;
using HotelsSite.Application.Hotels;
using HotelsSite.Application.Reservations;
using HotelsSite.Domain;
using HotelsSite.Infrastructure.Database;
using HotelsSite.Infrastructure.Error;
using HotelsSite.Infrastructure.Helpers.Cache;
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

            builder.Services.AddScoped<IStatusCache>(provider =>
            {
                var context = provider.GetService<HotelsSiteContext>();
                return new StatusCache(context);
            });
            
            builder.Services.AddScoped<HotelNumberHandler>();
            builder.Services.AddScoped<HotelHandler>();
            builder.Services.AddScoped<ReservationHandler>();

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