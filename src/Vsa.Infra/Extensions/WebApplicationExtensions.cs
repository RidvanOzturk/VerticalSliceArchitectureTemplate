using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Vsa.Infra.Database;

namespace Vsa.Infra.Extensions;

public static class WebApplicationExtensions
{
    extension(WebApplication app)
    {
        public WebApplication UseApplicationDb()
        {
            using var scope = app.Services.CreateScope();
            var db = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();

            db.Database.EnsureCreated();

            return app;
        }
    }
}
