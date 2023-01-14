using MapperComparison.Models;

namespace MapperComparison.Services;
public static class MapService
{
    public static User MapOneObjectManually(UserToMap userToMap)
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
