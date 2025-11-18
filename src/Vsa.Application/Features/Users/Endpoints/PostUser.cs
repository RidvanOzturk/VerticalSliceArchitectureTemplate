using FastEndpoints;
using Microsoft.AspNetCore.Http;
using Vsa.Application.Common.Models;
using Vsa.Application.Features.Users.Helpers;
using Vsa.Application.Features.Users.Models;
using Vsa.Infra.Database;

namespace Vsa.Application.Features.Users.Endpoints;

public class CreateUser(ApplicationDbContext applicationDbContext,
                        UserMapper userMapper)
    : Endpoint<UserCreationRequest, IdResponse>
{
    public override void Configure()
    {
        Post("users");
        Summary(s =>
        {
            s.Summary = "Creates a new user";
            s.Response(StatusCodes.Status200OK);
            s.Response(StatusCodes.Status400BadRequest);
        });
    }

    public override async Task HandleAsync(UserCreationRequest request, CancellationToken cancellationToken)
    {
        var user = userMapper.Map(request);

        await applicationDbContext.Users.AddAsync(user, cancellationToken);
        await applicationDbContext.SaveChangesAsync(cancellationToken);

        var response = userMapper.MapToIdResponse(user);

        await Send.OkAsync(response, cancellationToken);
    }
}
