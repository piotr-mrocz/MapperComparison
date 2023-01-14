namespace MapperComparison.Models;
public sealed class UserToMap
{
    public int Id { get; set; }
    public string FirstName { get; set; } = null!;
    public string LasName { get; set; } = null!;
    public string Email { get; set; } = null!;
    public string Password { get; set; } = null!;
    public string CardNumber { get; set; } = null!;
    public string PhoneNumber { get; set; } = null!;
}
