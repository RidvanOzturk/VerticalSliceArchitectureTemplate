using Vsa.Domain.Database.Enums;

namespace Vsa.Application.Features.Users.Models;

public class UserReadResponse
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Surname { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public int Age { get; set; }
    public string Sex { get; set; } = string.Empty;
}
