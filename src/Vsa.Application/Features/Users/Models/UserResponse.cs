using Vsa.Domain.Database.Enums;

namespace Vsa.Application.Features.Users.Models;

public class UserResponse
{
    public string Name { get; set; } = string.Empty;
    public string Surname { get; set; } = string.Empty;
    public int Age { get; set; }
    public string Sex { get; set; } = string.Empty;
}
