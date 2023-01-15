using AutoMapper;

namespace MapperComparison.AutoMapper;
public static class AutoMapperInitializator
{
    public static IMapper GetMapper(MapperConfiguration config)
        => config.CreateMapper();
}
