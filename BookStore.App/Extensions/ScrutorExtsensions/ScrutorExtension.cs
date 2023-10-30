namespace BookStore.App.Extensions.ScrutorExtsensions
{
    public static class ScrutorExtension
    {
        public static void ScanServices(this IServiceCollection services)
        {
            services.Scan(selector => selector
                    .FromApplicationDependencies()
                    .AddClasses(classSelector => classSelector
                    .InNamespaces("BookStore.EF.Repository"))
                    .AsMatchingInterface()
                    .WithTransientLifetime()

                    .AddClasses(classSelector => classSelector
                    .InNamespaces("BookStore.App.Services"))
                    .AsMatchingInterface()
                    .WithTransientLifetime());
        }
    }
}
