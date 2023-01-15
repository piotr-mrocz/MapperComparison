using AutoMapper;
using MapperComparison.Models;

namespace MapperComparison.AutoMapperProfile;
public sealed class UserProfile : Profile
{
	public UserProfile()
	{
		CreateMap<UserToMap, User>().ReverseMap();

		CreateMap<UsersListToMap, List<User>>()
			.ConvertUsing(source => source.Users.Select(x => new User()
			{
                Id = x.Id,
                FirstName = x.FirstName,
                LasName = x.LasName,
                Email = x.Email,
                CardNumber = x.CardNumber,
                Password = x.Password,
                PhoneNumber = x.PhoneNumber
            }).ToList());
	}
}
