using MassTransit.NewIdProviders;
using MassTransit;
using Shop.Application.Common;
using Shop.Infrastructure.Context;
using System.Reflection;
using Shop.Domain.Entities.Common;


namespace Shop.Api.Configuration
{
    public static class ApplicationSetup
    {
        public static IServiceCollection AddApplicationSetup(this IServiceCollection services)
        {
            services.AddScoped<IContext, ApplicationDbContext>();
            NewId.SetProcessIdProvider(new CurrentProcessIdProvider());
            ApplyAllMappingConfigFromAssembly();

            return services;
        }
        private static IEnumerable<Type> GetTypesWithInterface<TInterface>(Assembly asm)
        {
            var it = typeof(TInterface);
            return asm.GetTypes().Where(x => it.IsAssignableFrom(x) && x is { IsInterface: false, IsAbstract: false });
        }


        private static void ApplyAllMappingConfigFromAssembly()
        {
            var mappers = GetTypesWithInterface<IMappingConfig>(typeof(IMappingConfig).Assembly);
            foreach (var mapperType in mappers)
            {
                var instance = (IMappingConfig)Activator.CreateInstance(mapperType)!;
                instance.ApplyConfig();
            }
        }



    }
}
