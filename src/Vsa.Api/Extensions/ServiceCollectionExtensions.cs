using FastEndpoints;
using Vsa.Application;

namespace Vsa.Api.Extensions;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection RegisterFastEndpoints(
        this IServiceCollection services)
    {
        services.AddFastEndpoints(options =>
        {
            options.DisableAutoDiscovery = true;
            options.Assemblies = [typeof(IApplicationAssemblyHook).Assembly];
            options.IncludeAbstractValidators = true;
        });

        return services;
    }
}
