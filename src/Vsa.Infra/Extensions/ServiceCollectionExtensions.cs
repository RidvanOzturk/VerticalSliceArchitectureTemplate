using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Vsa.Infra.Database;

namespace Vsa.Infra.Extensions;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection RegisterDbContext(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<ApplicationDbContext>(options =>
        {
            options.UseInMemoryDatabase("VsaDb");
        });

        return services;
    }
}