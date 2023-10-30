using System.Runtime.CompilerServices;
using BookStore.Admin.Entity;
using BookStore.EF.Context;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace BookStore.App.Extensions.EfExtensions
{
    public static class InitializeDbExtension
    {
        public static void InitializeDb(this IServiceProvider serviceProvider)
        {
            using (var scope = serviceProvider.CreateScope())
            {
                var dbService = scope.ServiceProvider.GetRequiredService<BookStoreContext>();

                try
                {
                    dbService.Database.Migrate();
                }
                catch (Exception)
                {
                    //TODO Добавить логирование
                }

                if (!dbService.Users.Any(x => x.Role == UserRole.Admin))
                    dbService.Users.Add(new UserEntity() { Login = "admin", Password = "admin", Role = UserRole.Admin, Name = "Админ Админович" });

                dbService.SaveChanges();
            }
        }
    }
}
