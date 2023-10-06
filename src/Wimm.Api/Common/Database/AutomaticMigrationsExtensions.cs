using Microsoft.EntityFrameworkCore;

namespace Wimm.Api.Common.Database;

internal static class AutomaticMigrationsExtensions
{
    internal static IApplicationBuilder UseAutomaticMigrations(this IApplicationBuilder applicationBuilder)
    {
        using var scope = applicationBuilder.ApplicationServices.CreateScope();
        var context = scope.ServiceProvider.GetRequiredService<Persistence>();
        context.Database.Migrate();
        
        return applicationBuilder;
    }
}