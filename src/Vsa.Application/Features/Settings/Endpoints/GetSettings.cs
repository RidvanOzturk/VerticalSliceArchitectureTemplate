using FastEndpoints;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Vsa.Application.Features.Settings.Mappers;
using Vsa.Application.Features.Settings.Models;
using Vsa.Infra.Database;

namespace Vsa.Application.Features.Settings.Endpoints;

public class GetSettings(ApplicationDbContext applicationDbContext) : Endpoint<SettingsQueryRequest, List<SettingReadResponse>>
{
    public override void Configure()
    {
        Get("/settings");
        Summary(s =>
        {
            s.Summary = "Get all settings or filter by query parameters";
            s.Response(StatusCodes.Status200OK);
        });
        AllowAnonymous();
    }

    public override async Task HandleAsync(SettingsQueryRequest request, CancellationToken cancellationToken)
    {
        var settingQuery = applicationDbContext.Settings.AsNoTracking();

        if (!string.IsNullOrWhiteSpace(request.Key))
        {
            settingQuery = settingQuery.Where(x => x.Key == request.Key);
        }

        if (!string.IsNullOrWhiteSpace(request.Value))
        {
            settingQuery = settingQuery.Where(x => x.Value == request.Value);
        }

        var settings = await settingQuery.ToListAsync(cancellationToken);
        var response = settings.Select(SettingMapper.ToResponse).ToList();

        await Send.OkAsync(response, cancellationToken);
    }
}
