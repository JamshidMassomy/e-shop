using Shop.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;


namespace Shop.Api.Configuration
{
    public static class PersistanceConfiguration
    {
        public static IServiceCollection AddPersistenceSetup(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<ApplicationDbContext>(o =>
            {
                o.UseSqlServer(configuration.GetConnectionString("DefaultConnection"));
            });
            

            return services;
        }
    }
}
