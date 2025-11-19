using FastEndpoints;
using Vsa.Application.Features.Users.Models;
using Vsa.Domain.Database;

namespace Vsa.Application.Features.Users.Helpers;

public sealed class UserMapper : Mapper<UserRequest, UserResponse, User>
{
    public override User ToEntity(UserRequest r) => new()
    {
        Id = r.Id,
        Name = r.Name,
        Surname = r.Surname,
        Email = r.Email,
        Age = r.Age,
        Sex = r.Sex
    };

    public override UserResponse FromEntity(User e) => new()
    {
        Name = e.Name,
        Surname = e.Surname,
        Age = e.Age,
        Sex = e.Sex.ToString()
    };
}
