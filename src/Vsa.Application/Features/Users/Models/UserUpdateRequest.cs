using Vsa.Domain.Database.Enums;

public  class UserUpdateRequest
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Surname { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public int Age { get; set; }
    public Sex Sex { get; set; }
}