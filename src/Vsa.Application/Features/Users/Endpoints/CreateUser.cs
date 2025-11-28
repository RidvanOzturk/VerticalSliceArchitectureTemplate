using FastEndpoints;
using Microsoft.AspNetCore.Http;
using Vsa.Application.Features.Users.Mappers;
using Vsa.Application.Features.Users.Models;
using Vsa.Infra.Database;

namespace Vsa.Application.Features.Users.Endpoints;

public class CreateUser(ApplicationDbContext applicationDbContext) : Endpoint<UserInsertRequest, UserInsertResponse>
{
    public override void Configure()
    {
        Post("/users");
        Summary(s =>
        {
            s.Summary = "Create a new user";
            s.Response(StatusCodes.Status201Created);
            s.Response(StatusCodes.Status400BadRequest);
        });
        AllowAnonymous();
    }
    public override async Task HandleAsync(UserInsertRequest request, CancellationToken cancellationToken)
    {
        var user = UserMapper.ToEntity(request);

        applicationDbContext.Users.Add(user);
        await applicationDbContext.SaveChangesAsync(cancellationToken);

        var response = new UserInsertResponse
        {
            Id = user.Id
        };
        await Send.CreatedAtAsync<GetUser>(
       routeValues: new { id = user.Id },
       responseBody: response,
       cancellation: cancellationToken);
    }
}
