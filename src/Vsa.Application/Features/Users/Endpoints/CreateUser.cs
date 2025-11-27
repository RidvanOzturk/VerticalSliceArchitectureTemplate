using FastEndpoints;
using Microsoft.AspNetCore.Http;
using Vsa.Application.Features.Users.Mappers;
using Vsa.Application.Features.Users.Models;
using Vsa.Infra.Database;

namespace Vsa.Application.Features.Users.Endpoints;

public class CreateUser(ApplicationDbContext applicationDbContext) : Endpoint<CreateUserRequest, UserResponse>
{
    public override void Configure()
    {
        Post("/api/users");
        Summary(s =>
        {
            s.Summary = "Create a new user";
            s.Response(StatusCodes.Status200OK);
            s.Response(StatusCodes.Status400BadRequest);
        });
        AllowAnonymous();
    }
    public override async Task HandleAsync(CreateUserRequest request, CancellationToken cancellationToken)
    {
        if (request is null)
        {
            await Send.ErrorsAsync(statusCode: 400, cancellationToken);
            return;
        }
        var user = UserMapper.ToEntity(request);
        applicationDbContext.Add(user);
        await applicationDbContext.SaveChangesAsync(cancellationToken);

        var response = UserMapper.ToResponse(user);

        await Send.OkAsync(response, cancellationToken);

    }
}
