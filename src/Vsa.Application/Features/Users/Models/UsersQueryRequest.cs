using FastEndpoints;

namespace Vsa.Application.Features.Users.Models;

public class UsersQueryRequest
{
    [QueryParam]
    public string Name { get; set; } = string.Empty;

    [QueryParam]
    public string Surname { get; set; } = string.Empty;
}