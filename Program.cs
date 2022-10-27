using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.EntityFrameworkCore;
using Virtualize_bug.Data;

namespace Virtualize_bug
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddRazorPages();
            builder.Services.AddServerSideBlazor();
            builder.Services.AddSingleton<WeatherForecastService>();

            var services = builder.Services;

            services.AddDbContextFactory<Context>(options => // AddDbContextFactory
                options.UseSqlServer($"Server=(localdb)\\mssqllocaldb;Database=TEST123321;user=;Password=;Encrypt=True;TrustServerCertificate=True;MultipleActiveResultSets=true;"));


            var serviceProvider = services.BuildServiceProvider();
            var context = serviceProvider.GetRequiredService<Context>();
            if (context != null) Context.Initialize(context);

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

            app.MapBlazorHub();
            app.MapFallbackToPage("/_Host");

            app.Run();
        }
    }
}