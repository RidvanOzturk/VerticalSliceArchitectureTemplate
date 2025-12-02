using FastEndpoints;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Vsa.Application.Common.Models;
using Vsa.Application.Features.Settings.Mappers;
using Vsa.Application.Features.Settings.Models;
using Vsa.Infra.Database;

namespace Vsa.Application.Features.Settings.Endpoints;

public class GetSetting(ApplicationDbContext applicationDbContext) : Endpoint<IdRequest, SettingReadResponse>
{
    public override void Configure()
    {
        Get("/settings/{id}");
        Summary(s =>
        {
            s.Summary = "Get setting for specified id";
            s.Response(StatusCodes.Status200OK);
            s.Response(StatusCodes.Status404NotFound);
        });
        AllowAnonymous();
    }

    public override async Task HandleAsync(IdRequest request, CancellationToken cancellationToken)
    {
        var setting = await applicationDbContext.Settings
            .AsNoTracking()
            .FirstOrDefaultAsync(x => x.Id == request.Id, cancellationToken);

        if (setting is null)
        {
            await Send.NotFoundAsync(cancellationToken);
            return;
        }
        
        var response = SettingMapper.ToResponse(setting);
        await Send.OkAsync(response, cancellationToken);
    }
}
