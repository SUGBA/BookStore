using BookStore.Auth.Entity;
using BookStore.Catalog.Entity;
using System.Reflection.Emit;
using BookStore.EF.Context;
using BookStore.News.Entity;
using Microsoft.EntityFrameworkCore;

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

            var app = builder.Build();

            app.UseStaticFiles();
            app.MapRazorPages();
            app.MapDefaultControllerRoute();


            app.MapGet("/", (BookStoreContext db) =>
            {
                using (db)
                {
                    var departments = db.Departments.Select(x => x.Address);

                    return string.Join(" | ", departments);
                }
            });

            app.Run();
        }
    }
}