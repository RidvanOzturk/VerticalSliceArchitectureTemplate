using FastEndpoints;
using FastEndpoints.Swagger;
using Vsa.Application;

namespace Vsa.Api.Extensions;

public static class ServiceCollectionExtensions
{
    extension(IServiceCollection services)
    {
        public IServiceCollection RegisterFastEndpoints()
        {
            services.AddFastEndpoints(options =>
            {
                options.DisableAutoDiscovery = true;
                options.Assemblies = [typeof(IApplicationAssemblyHook).Assembly];
                options.IncludeAbstractValidators = true;
            });

            services.SwaggerDocument();

            return services;
        }
    }
}
