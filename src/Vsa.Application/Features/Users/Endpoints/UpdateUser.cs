using FastEndpoints;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Vsa.Application.Features.Users.Mappers;
using Vsa.Application.Features.Users.Models;
using Vsa.Infra.Database;

namespace Vsa.Application.Features.Users.Endpoints;

public class UpdateUser(ApplicationDbContext applicationDbContext) : Endpoint<UserUpdateRequest>
{
    public override void Configure()
    {
        Put("/users/{id}");
        Summary(s =>
        {
            s.Summary = "Update an existing user";
            s.Response(StatusCodes.Status204NoContent);
            s.Response(StatusCodes.Status404NotFound);
        });
        AllowAnonymous();
    }
    public override async Task HandleAsync(UserUpdateRequest request, CancellationToken cancellationToken)
    {
        var user = await applicationDbContext.Users.FirstOrDefaultAsync(u => u.Id == request.Id, cancellationToken);

        if (user is null)
        {
            await Send.NotFoundAsync(cancellationToken);
            return;
        }

        UserMapper.UpdateEntity(request, user);
        await applicationDbContext.SaveChangesAsync(cancellationToken); 
        await Send.NoContentAsync(cancellationToken);
    }
}
