using FastEndpoints;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Vsa.Application.Features.Users.Models;
using Vsa.Infra.Database;

namespace Vsa.Application.Features.Users.Endpoints;

public class UpdateUser(ApplicationDbContext applicationDbContext)
    : Endpoint<UserUpdateRequest, UserFetchingResponse>
{
    public override void Configure()
    {
        Put("users/{id}");
        Summary(s =>
        {
            s.Summary = "Updates an existing user";
            s.Response(StatusCodes.Status200OK);
            s.Response(StatusCodes.Status400BadRequest);
            s.Response(StatusCodes.Status404NotFound);
        });
    }

    public override async Task HandleAsync(UserUpdateRequest request, CancellationToken cancellationToken)
    {
        var user = await applicationDbContext.Users
            .FirstOrDefaultAsync(x => x.Id == request.Id, cancellationToken);

        if (user is null)
        {
            await Send.NotFoundAsync(cancellationToken);
            return;
        }

        user.Name = request.Name;
        user.Email = request.Email;

        await applicationDbContext.SaveChangesAsync(cancellationToken);

        var response = new UserFetchingResponse(user.Id, user.Name);

        await Send.OkAsync(response, cancellationToken);
    }
}
