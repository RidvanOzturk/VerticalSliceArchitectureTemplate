using FastEndpoints;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Vsa.Application.Features.Users.Mappers;
using Vsa.Application.Features.Users.Models;
using Vsa.Infra.Database;

namespace Vsa.Application.Features.Users.Endpoints;

public class GetUsers(ApplicationDbContext applicationDbContext) : Endpoint<UsersQueryRequest, List<UserReadResponse>>
{
    public override void Configure()
    {
        Get("/users");
        Summary(s =>
        {
            s.Summary = "Get all users or filter by query parameters";
            s.Response(StatusCodes.Status200OK);
        });
        AllowAnonymous();
    }

    public override async Task HandleAsync(UsersQueryRequest request, CancellationToken cancellationToken)
    {
        var userQuery = applicationDbContext.Users.AsNoTracking();

        if (!string.IsNullOrWhiteSpace(request.Name))
        {
            userQuery = userQuery.Where(x => x.Name == request.Name);
        }

        if (!string.IsNullOrWhiteSpace(request.Surname))
        {
            userQuery = userQuery.Where(x => x.Surname == request.Surname);
        }

        var users = await userQuery.ToListAsync(cancellationToken);
        var response = users.Select(UserMapper.ToResponse).ToList();

        await Send.OkAsync(response, cancellationToken);
    }

}
