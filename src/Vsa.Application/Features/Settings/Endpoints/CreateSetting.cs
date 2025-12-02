using FastEndpoints;
using Microsoft.AspNetCore.Http;
using Vsa.Application.Features.Settings.Mappers;
using Vsa.Application.Features.Settings.Models;
using Vsa.Infra.Database;

namespace Vsa.Application.Features.Settings.Endpoints;

public class CreateSetting(ApplicationDbContext applicationDbContext) : Endpoint<SettingInsertRequest, SettingInsertResponse>
{
    public override void Configure()
    {
        Post("/settings");
        Summary(s =>
        {
            s.Summary = "Create a new setting";
            s.Response(StatusCodes.Status201Created);
            s.Response(StatusCodes.Status400BadRequest);
        });
        AllowAnonymous();
    }
    public override async Task HandleAsync(SettingInsertRequest request, CancellationToken cancellationToken)
    {
        var setting = SettingMapper.ToEntity(request);

        applicationDbContext.Settings.Add(setting);
        await applicationDbContext.SaveChangesAsync(cancellationToken);

        var response = new SettingInsertResponse
        {
            Id = setting.Id
        };

        await Send.CreatedAtAsync<GetSetting>(
        routeValues: new { id = setting.Id },
        responseBody: response,
        cancellation: cancellationToken);
    }
}
