using MassTransit.NewIdProviders;
using MassTransit;
using Shop.Application.Common;
using Shop.Infrastructure.Context;
using AspNetCoreRateLimit;

namespace Shop.Api.Configuration
{
    public static class ApplicationSetup
    {
        public static IServiceCollection AddApplicationSetup(this IServiceCollection services)
        {
            services.AddSingleton<IRateLimitConfiguration, RateLimitConfiguration>();
            services.AddScoped<IContext, ApplicationDbContext>();
            NewId.SetProcessIdProvider(new CurrentProcessIdProvider());
            return services;
        }
        
       


    }
}
