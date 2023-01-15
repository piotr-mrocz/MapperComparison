namespace MapperComparison.Models;
public sealed class User
{
    public int Id { get; set; }
    public string FirstName { get; set; } = null!;
    public string LasName { get; set; } = null!;
    public string Email { get; set; } = null!;
    public string Password { get; set; } = null!;
    public string CardNumber { get; set; } = null!;
    public string PhoneNumber { get; set; } = null!;


    public static implicit operator User(UserToMap userToMap)
    {
        return new User()
        {
            Id = userToMap.Id,
            FirstName = userToMap.FirstName,
            LasName = userToMap.LasName,
            Email = userToMap.Email,
            CardNumber = userToMap.CardNumber,
            Password = userToMap.Password,
            PhoneNumber = userToMap.PhoneNumber
        };
    }
}
