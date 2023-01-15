using AutoMapper;
using MapperComparison.AutoMapperProfile;
using MapperComparison.Models;

namespace MapperComparison.Services;
public class MapService
{
    private readonly MapperConfiguration _config;
    private readonly IMapper _mapper;

    public MapService()
    {
        _config = new MapperConfiguration(conf => conf.AddProfile<UserProfile>());
        _mapper = AutoMapperInitializator.GetMapper(_config);
    }

    public User MapOneObjectManually(UserToMap userToMap)
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

    public List<User> MapListOfObjectsManually(List<UserToMap> usersToMap)
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

    public User MapObjectUsingAutoMapper(UserToMap userToMap)
        => _mapper.Map<UserToMap, User>(userToMap);

    public List<User> MapListOfObjectsUsingAutoMapper(List<UserToMap> usersToMap)
    => _mapper.Map<List<UserToMap>, List<User>>(usersToMap);
}
