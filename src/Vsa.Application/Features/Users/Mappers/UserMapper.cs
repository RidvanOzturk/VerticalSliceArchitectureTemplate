using Vsa.Application.Features.Users.Models;
using Vsa.Domain.Database;

namespace Vsa.Application.Features.Users.Mappers;

public static class UserMapper
{
    public static User ToEntity(CreateUserRequest r) => new()
    {
        Name = r.Name,
        Surname = r.Surname,
        Email = r.Email,
        Age = r.Age,
        Sex = r.Sex
    };

    public static void UpdateEntity(UpdateUserRequest r, User e)
    {
        e.Name = r.Name;
        e.Surname = r.Surname;
        e.Email = r.Email;
        e.Age = r.Age;
        e.Sex = r.Sex;
    }

    public static UserResponse ToResponse(User e) => new()
    {
        Id = e.Id,
        Name = e.Name,
        Surname = e.Surname,
        Age = e.Age,
        Sex = e.Sex.ToString()
    };
}
