using AutoMapper;
using BenchmarkDotNet.Attributes;
using MapperComparison.AutoMapper;
using MapperComparison.AutoMapperProfile;
using MapperComparison.Models;
using System.Runtime.InteropServices;

namespace MapperComparison.Services;

[MemoryDiagnoser]
public class MapService
{
    private readonly MapperConfiguration _config;
    private readonly IMapper _mapper;

    #region data for test

    private readonly UserToMap _userToMap = new UserToMap()
    {
        Id = 1,
        FirstName = "Adam",
        LasName = "Mickiewicz",
        Email = "a.mickiewicz@gmail.com",
        CardNumber = "123456789",
        Password = "Password",
        PhoneNumber = "1234567890",
    };

    private readonly List<UserToMap> _usersToMap = new List<UserToMap>()
    {
        new UserToMap()
        {
            Id = 1,
            FirstName = "Adam",
            LasName = "Mickiewicz",
            Email = "a.mickiewicz@gmail.com",
            CardNumber = "123456789",
            Password = "Password",
            PhoneNumber = "1234567890",
        },
        new UserToMap()
        {
            Id = 2,
            FirstName = "Krzysztof",
            LasName = "Kolumb",
            Email = "k.kolumb@gmail.com",
            CardNumber = "123456789",
            Password = "Password",
            PhoneNumber = "1234567890",
        },
        new UserToMap()
        {
            Id = 3,
            FirstName = "Maria",
            LasName = "Skłodowska-Curie",
            Email = "m.sklodowska-curie@gmail.com",
            CardNumber = "123456789",
            Password = "Password",
            PhoneNumber = "1234567890",
        },
        new UserToMap()
        {
            Id = 4,
            FirstName = "Maria",
            LasName = "Dąbrowska",
            Email = "m.dabrowska@gmail.com",
            CardNumber = "123456789",
            Password = "Password",
            PhoneNumber = "1234567890",
        }
    };

    #endregion

    public MapService()
    {
        _config = new MapperConfiguration(conf => conf.AddProfile<UserProfile>());
        _mapper = AutoMapperInitializator.GetMapper(_config);
    }

    [Benchmark]
    public User MapOneObjectManually()
    {
        return new User()
        {
            Id = _userToMap.Id,
            FirstName = _userToMap.FirstName,
            LasName = _userToMap.LasName,
            Email = _userToMap.Email,
            CardNumber = _userToMap.CardNumber,
            Password = _userToMap.Password,
            PhoneNumber = _userToMap.PhoneNumber
        };
    }

    [Benchmark]
    public List<User> MapListOfObjectsManually()
    {
        var listToReturn = new List<User>();

        foreach (var userToMap in _usersToMap)
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

    [Benchmark]
    public List<User> MapListOfObjectsManuallyAsSpan()
    {
        var listToReturn = new List<User>();
        var usersToMapSpan = CollectionsMarshal.AsSpan(_usersToMap);

        foreach (var userToMap in usersToMapSpan)
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

    [Benchmark]
    public User MapObjectUsingAutoMapper()
        => _mapper.Map<UserToMap, User>(_userToMap);

    [Benchmark]
    public List<User> MapListOfObjectsUsingAutoMapper()
        => _mapper.Map<List<UserToMap>, List<User>>(_usersToMap);

    [Benchmark]
    public User MapOneUserUsingImplicitOperator()
        => _userToMap;

    [Benchmark]
    public List<User> MapListOfUsersUsingImplicitOperator()
    {
        var listToReturn = new List<User>();

        foreach (var userToMap in _usersToMap)
            listToReturn.Add(userToMap);

        return listToReturn;
    }
}
