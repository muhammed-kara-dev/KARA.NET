using AutoMapper;

namespace KARA.NET;
public class Mapper
    : IMapper
{
    public TOutput Map<TOutput>(object input)
    {
        var config = new MapperConfiguration(x => x.CreateMap<object, TOutput>());
        var mapper = config.CreateMapper();
        return mapper.Map<TOutput>(input);
    }

    public void Map<TInput, TOutput>(TInput input, TOutput output)
    {
        var config = new MapperConfiguration(x => x.CreateMap<TInput, TOutput>());
        var mapper = config.CreateMapper();
        mapper.Map(input, output);
    }
}