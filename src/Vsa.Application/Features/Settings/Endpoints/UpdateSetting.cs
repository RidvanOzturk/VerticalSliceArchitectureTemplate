using FastEndpoints;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Vsa.Application.Features.Settings.Mappers;
using Vsa.Application.Features.Settings.Models;
using Vsa.Infra.Database;

namespace Vsa.Application.Features.Settings.Endpoints;

public class UpdateSetting(ApplicationDbContext applicationDbContext) : Endpoint<SettingUpdateRequest>
{
    public override void Configure()
    {
        Put("/settings/{id}");
        Summary(s =>
        {
            s.Summary = "Update an existing setting";
            s.Response(StatusCodes.Status204NoContent);
            s.Response(StatusCodes.Status404NotFound);
        });
        AllowAnonymous();
    }
    public override async Task HandleAsync(SettingUpdateRequest request, CancellationToken cancellationToken)
    {
        var setting = await applicationDbContext.Settings.FirstOrDefaultAsync(x => x.Id == request.Id, cancellationToken);

        if (setting is null)
        {
            await Send.NotFoundAsync(cancellationToken);
            return;
        }

        SettingMapper.UpdateEntity(request, setting);
        await applicationDbContext.SaveChangesAsync(cancellationToken);
        await Send.NoContentAsync(cancellationToken);
    }
}
