
using Shop.Application.Auth;
using ISession = Shop.Domain.Entities.Auth.Interfaces.ISession;

namespace Shop.Api.Configuration
{
    public static class DbContextConfiguration
    {
        public static IServiceCollection AddPersistenceSetup(this IServiceCollection services, IConfiguration configuration)
        {

            
            services.AddScoped<ISession, Session>();
            /*services.AddDbContext<ApplicationDbContext>(o =>
            {
                o.UseSqlServer(configuration.GetConnectionString("DefaultConnection"));
            });
            */

            return services;
        }
    }
}
