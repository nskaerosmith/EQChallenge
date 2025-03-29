using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Pensions.Persistence.DbContexts;

namespace Pensions.Host.Extensions
{
    public static class MigrationsExtension
    {
        public static void UpdateDatabase(this IApplicationBuilder app)
        {
            using (var serviceScope = app.ApplicationServices.GetRequiredService<IServiceScopeFactory>().CreateScope())
            {
                using (var context = serviceScope.ServiceProvider.GetService<PensionsContext>())
                {
                    context.Database.Migrate();
                }
            }
        }
    }
}
