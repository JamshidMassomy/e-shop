


using Shop.Application.Common.Behaviors;
using Shope.Application;

public static class MediatorRSetup
{
    public static IServiceCollection AddMediatRSetup(this IServiceCollection services)
    {
        services.AddMediatR((config) =>
        {
             config.RegisterServicesFromAssemblyContaining(typeof(IAssemblyMarker));
             config.AddOpenBehavior(typeof(ValidationResultPipelineBehavior<,>));
        });



        return services;
    }
}