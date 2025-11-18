using FastEndpoints;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Vsa.Application.Common.Models;
using Vsa.Application.Features.Users.Helpers;
using Vsa.Application.Features.Users.Models;
using Vsa.Infra.Database;

namespace Vsa.Application.Features.Users.Endpoints;

public class GetUser(ApplicationDbContext applicationDbContext,
                     UserMapper userMapper) : Endpoint<IdRouteRequest, UserFetchingResponse>
{
    public override void Configure()
    {
        Get("users/{id}");
        Summary(s =>
        {
            s.Summary = "Gets the user for the specified id";
            s.Response(StatusCodes.Status200OK);
            s.Response(StatusCodes.Status400BadRequest);
        });
    }

    public override async Task HandleAsync(IdRouteRequest request, CancellationToken cancellationToken)
    {
        var user = await applicationDbContext.Users
            .AsNoTracking()
            .FirstOrDefaultAsync(x => x.Id == request.Id, cancellationToken);

        if (user is null)
        {
            await Send.NotFoundAsync(cancellationToken);
            return;
        }

        var response = userMapper.MapToFullTypeResponse(user);

        await Send.OkAsync(response, cancellationToken);
    }
}
