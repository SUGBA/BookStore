using BookStore.EF.Context;
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


            app.MapGet("/", (BookStoreContext db) => db.Users.ToList());

            app.Run();
        }
    }
}