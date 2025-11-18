using FastEndpoints;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Vsa.Application.Common.Models;
using Vsa.Infra.Database;

namespace Vsa.Application.Features.Users.Endpoints;

public class DeleteUser(ApplicationDbContext applicationDbContext)
    : Endpoint<IdRouteRequest>
{
    public override void Configure()
    {
        Delete("users/{id}");
        Summary(s =>
        {
            s.Summary = "Deletes the user for the specified id";
            s.Response(StatusCodes.Status200OK);
            s.Response(StatusCodes.Status404NotFound);
        });
    }

    public override async Task HandleAsync(IdRouteRequest request, CancellationToken cancellationToken)
    {
        var user = await applicationDbContext.Users
            .FirstOrDefaultAsync(x => x.Id == request.Id, cancellationToken);

        if (user is null)
        {
            await Send.NotFoundAsync(cancellationToken);
            return;
        }

        applicationDbContext.Users.Remove(user);
        await applicationDbContext.SaveChangesAsync(cancellationToken);

        await Send.OkAsync(cancellationToken);
    }
}
