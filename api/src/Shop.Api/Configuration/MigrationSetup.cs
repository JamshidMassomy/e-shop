using Microsoft.EntityFrameworkCore;
using Shop.Application.Common;
using Shope.Application;

namespace Shop.Api.Configuration
{
    public static class MigrationSetup
    {
        public static async Task Migrate(this WebApplication app)
        {
            await using var scope = app.Services.CreateAsyncScope();
            var logger = scope.ServiceProvider.GetRequiredService<ILogger<IAssemblyMarker>>();
            var dbContext = scope.ServiceProvider.GetRequiredService<IContext>();

            logger.LogInformation("Running migrations...");
            await dbContext.Database.MigrateAsync();
            logger.LogInformation("Migrations applied succesfully");
        }
    }
}