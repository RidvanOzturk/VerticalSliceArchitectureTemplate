using Vsa.Domain.Database.Enums;

public class UserInsertRequest
{
    public string Name { get; set; } = default!;
    public string Surname { get; set; } = default!;
    public string Email { get; set; } = default!;
    public int Age { get; set; }
    public Sex Sex { get; set; }
}