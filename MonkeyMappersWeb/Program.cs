using Microsoft.EntityFrameworkCore;
using MonkeyMappersWeb.Components;
using MonkeyMappersWeb.Data;
using MonkeyMappersWeb.Models;
using MonkeyMappersWeb.Repo.IRepo;
using MonkeyMappersWeb.Repositories;
using MonkeyMappersWeb.Services;
using MonkeyMappersWeb.Services.IServices;

namespace MonkeyMappersWeb
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddRazorComponents()
                .AddInteractiveServerComponents();

            builder.Services.AddDbContext<DataContext>(options =>
            {
                {
                    options.UseSqlServer(builder.Configuration.GetConnectionString("MyDBConnection"));

                }
            }
);
            builder.Services.AddScoped<IPlayerRepo, PlayerRepo>();
            builder.Services.AddScoped<ISortService, SortService>();

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
            app.UseAntiforgery();

            app.MapRazorComponents<App>()
                .AddInteractiveServerRenderMode();

            app.Run();
        }
    }
}
