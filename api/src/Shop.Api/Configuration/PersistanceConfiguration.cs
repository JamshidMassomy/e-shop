
using Shop.Application.Auth;
using Shop.Infrastructure.Context;
using ISession = Shop.Domain.Entities.Auth.Interfaces.ISession;
using Microsoft.EntityFrameworkCore;


namespace Shop.Api.Configuration
{
    public static class PersistanceConfiguration
    {
        public static IServiceCollection AddPersistenceSetup(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<ISession, Session>();
            services.AddDbContext<ApplicationDbContext>(o =>
            {
                o.UseSqlServer(configuration.GetConnectionString("DefaultConnection"));
            });
            

            return services;
        }
    }
}
