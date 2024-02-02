using Microsoft.EntityFrameworkCore;
using Fribergs_rentals_2.Data;

namespace Fribergs_rentals_2
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add dbContext as a service
            builder.Services.AddDbContext<AppDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("AppDbConnectionString")));

            // Add other services to the container.
            builder.Services.AddRazorPages();
            builder.Services.AddTransient<IAdministrator, AdministratorRepository>();
            builder.Services.AddTransient<ICustomer, CustomerRepository>();
            builder.Services.AddTransient<ICar, CarRepository>();
            builder.Services.AddTransient<ICarPicture, CarPicRepository>();
            builder.Services.AddTransient<IBooking, BookingRepository>();
            // TODO: Add service for cookies
            //builder.Services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.MapRazorPages();

            app.Run();
        }
    }
}
