using BookStore.Auth.Entity;
using BookStore.Catalog.Entity;
using System.Reflection.Emit;
using BookStore.EF.Context;
using BookStore.News.Entity;
using Microsoft.EntityFrameworkCore;
using BookStore.App.Extensions.EfExtensions;

namespace BookStore.App
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            string connection = builder.Configuration.GetConnectionString("DefaultConnection")!;
            builder.Services.AddDbContext<BookStoreContext>(options => options.UseNpgsql(connection));
            builder.Services.AddControllersWithViews();
            builder.Services.AddRazorPages();
            builder.Services.AddSwaggerGen();

            builder.Services.Scan(selector => selector
                    .FromCallingAssembly()

                    .AddClasses(classSelector =>
                    classSelector.InNamespaces("BookStore.EF.Repository"))
                    .AsMatchingInterface()
                    .WithTransientLifetime()

                    .AddClasses(classSelector =>
                    classSelector.InNamespaces("BookStore.App.Services"))
                    .AsMatchingInterface()
                    .WithTransientLifetime()
                    );

            var app = builder.Build();

            app.UseStaticFiles();
            app.MapRazorPages();
            app.MapDefaultControllerRoute();

            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.Services.InitializeDb();

            app.UseSwaggerUI(options =>
            {
                options.SwaggerEndpoint("/swagger/v1/swagger.json", "v1");
                options.RoutePrefix = string.Empty;
            });

            app.Run();
        }
    }
}