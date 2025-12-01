using Vsa.Application.Features.Users.Models;
using Vsa.Domain.Database;

namespace Vsa.Application.Features.Users.Mappers;

public static class UserMapper
{
    public static User ToEntity(UserInsertRequest request) => new()
    {
        Name = request.Name,
        Surname = request.Surname,
        Email = request.Email,
        Age = request.Age,
        Sex = request.Sex
    };

    public static void UpdateEntity(UserUpdateRequest request, User user)
    {
        user.Name = request.Name;
        user.Surname = request.Surname;
        user.Email = request.Email;
        user.Age = request.Age;
        user.Sex = request.Sex;
    }

    public static UserReadResponse ToResponse(User user) => new()
    {
        Id = user.Id,
        Name = user.Name,
        Email = user.Email,
        Surname = user.Surname,
        Age = user.Age,
        Sex = user.Sex.ToString()
    };

}
