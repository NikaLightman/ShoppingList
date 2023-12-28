using Microsoft.EntityFrameworkCore;
using ShoppingList.WebAPI.Settings;
using ShoppingList.DataAccess;

namespace ShoppingList.WebAPI.IoC
{
    public class DbContextConfigurator
    {
        public static void ConfigureService(IServiceCollection services, ShoppingListSettings settings)
        {
            services.AddDbContextFactory<ShoppingListDbContext>(
                options => { options.UseSqlServer(settings.ShoppingListDbContextConnectionString); },
                ServiceLifetime.Scoped);
        }

        public static void ConfigureApplication(IApplicationBuilder app)
        {
            using var scope = app.ApplicationServices.CreateScope();
            var contextFactory = scope.ServiceProvider.GetRequiredService<IDbContextFactory<ShoppingListDbContext>>();
            using var context = contextFactory.CreateDbContext();
            context.Database.Migrate();
        }
    }
}