using FastEndpoints;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Vsa.Application.Features.Users.Mappers;
using Vsa.Application.Features.Users.Models;
using Vsa.Infra.Database;

namespace Vsa.Application.Features.Users.Endpoints;

public class GetUser(ApplicationDbContext applicationDbContext) : Endpoint<GetUserRequest, UserResponse>
{
    public override void Configure()
    {
        Get("/api/users/{id}");
        Summary(s =>
        {
            s.Summary = "Get user for specified id";
            s.Response(StatusCodes.Status200OK);
            s.Response(StatusCodes.Status404NotFound);
        });
        AllowAnonymous();
    }

    public override async Task HandleAsync(GetUserRequest request, CancellationToken cancellationToken)
    {
        var user = await applicationDbContext.Users
            .AsNoTracking()
            .FirstOrDefaultAsync(x => x.Id == request.Id, cancellationToken);
        if (user is null)
        {
            await Send.NotFoundAsync(cancellationToken);
            return;
        }
        var response = UserMapper.ToResponse(user);

        await Send.OkAsync(response, cancellationToken);
    }
}
