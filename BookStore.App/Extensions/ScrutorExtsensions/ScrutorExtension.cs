using BookStore.Data.Entity;
using BookStore.EF.Repository;
using BookStore.EF.Repository.Interfaces;

namespace BookStore.App.Extensions.ScrutorExtsensions
{
    public static class ScrutorExtension
    {
        public static void ScanServices(this IServiceCollection services)
        {
            services.Scan(selector => selector
                    .FromApplicationDependencies()
                    //.AddClasses(classSelector => classSelector.AssignableTo(typeof(BaseRepository<IEntity>))
                    //.InNamespaces("BookStore.EF.Repository"))
                    //.AsImplementedInterfaces()
                    //.WithTransientLifetime()

                    .AddClasses(classSelector => classSelector
                    .InNamespaces("BookStore.App.Services"))
                    .AsMatchingInterface()
                    .WithTransientLifetime());
        }
    }
}
