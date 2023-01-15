using AutoMapper;

namespace MapperComparison.Services;
public static class AutoMapperInitializator
{
    public static IMapper GetMapper(MapperConfiguration config)
        => config.CreateMapper();
}
