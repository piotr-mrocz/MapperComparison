using AutoMapper;
using MapperComparison.Models;

namespace MapperComparison.AutoMapperProfile;
public sealed class UserProfile : Profile
{
	public UserProfile()
	{
		CreateMap<UserToMap, User>().ReverseMap();
	}
}
