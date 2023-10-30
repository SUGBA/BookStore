using BookStore.Admin.Entity;
using BookStore.Catalog.Entity;
using System.Reflection.Emit;
using BookStore.EF.Context;
using BookStore.News.Entity;
using Microsoft.EntityFrameworkCore;
using BookStore.App.Extensions.EfExtensions;
using System.Text;
using BookStore.Data.AutoMapper;
using BookStore.App.Extensions.ScrutorExtsensions;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authentication.OAuth;
using Microsoft.IdentityModel.Tokens;
using Microsoft.Extensions.Options;
using Microsoft.AspNetCore.Authentication.Cookies;

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

            builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
                            .AddCookie();

            builder.Services.AddAutoMapper(typeof(AppMappingProfile));
            builder.Services.ScanServices();

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

            app.UseAuthentication();
            app.UseAuthorization();

            app.Run();
        }
    }
}