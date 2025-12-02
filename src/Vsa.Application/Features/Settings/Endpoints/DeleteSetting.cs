using FastEndpoints;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Vsa.Application.Common.Models;
using Vsa.Infra.Database;

namespace Vsa.Application.Features.Settings.Endpoints;

public class DeleteSetting(ApplicationDbContext applicationDbContext) : Endpoint<IdRequest>
{
    public override void Configure()
    {
        Delete("/settings/{id}");
        Summary(s =>
        {
            s.Summary = "Delete an existing setting";
            s.Response(StatusCodes.Status204NoContent);
            s.Response(StatusCodes.Status404NotFound);
        });
        AllowAnonymous();
    }
    public override async Task HandleAsync(IdRequest request, CancellationToken cancellationToken)
    {
        var setting = await applicationDbContext.Settings.FirstOrDefaultAsync(u => u.Id == request.Id, cancellationToken);

        if (setting is null)
        {
            await Send.NotFoundAsync(cancellationToken);
            return;
        }

        applicationDbContext.Settings.Remove(setting);
        await applicationDbContext.SaveChangesAsync(cancellationToken);
        await Send.NoContentAsync(cancellationToken);
    }
}
