using FastEndpoints;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Vsa.Application.Common.Models;
using Vsa.Application.Features.Users.Models;
using Vsa.Infra.Database;

namespace Vsa.Application.Features.Users.Endpoints;

public class DeleteUser(ApplicationDbContext applicationDbContext) : Endpoint<IdRequest>
{
    public override void Configure()
    {
        Delete("/users/{id}");
        Summary(s =>
        {
            s.Summary = "Delete an existing user";
            s.Response(StatusCodes.Status204NoContent);
            s.Response(StatusCodes.Status404NotFound);
        });
        AllowAnonymous();
    }
    public override async Task HandleAsync(IdRequest request, CancellationToken cancellationToken)
    {
        var user = await applicationDbContext.Users.FirstOrDefaultAsync(u => u.Id == request.Id, cancellationToken);
        
        if (user is null)
        {
            await Send.NotFoundAsync(cancellationToken);
        }

        applicationDbContext.Users.Remove(user);
        await applicationDbContext.SaveChangesAsync(cancellationToken);
        await Send.NoContentAsync(cancellationToken);
    }
}
