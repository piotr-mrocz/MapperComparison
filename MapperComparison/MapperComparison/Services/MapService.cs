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

    public static List<User> MapListOfObjectsManually(List<UserToMap> usersToMap)
    {
        var listToReturn = new List<User>();

        foreach (var userToMap in usersToMap)
        {
            listToReturn.Add(new User()
            {
                Id = userToMap.Id,
                FirstName = userToMap.FirstName,
                LasName = userToMap.LasName,
                Email = userToMap.Email,
                CardNumber = userToMap.CardNumber,
                Password = userToMap.Password,
                PhoneNumber = userToMap.PhoneNumber
            });
        }

        return listToReturn;
    }
}
