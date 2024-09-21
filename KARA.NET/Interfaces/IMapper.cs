namespace KARA.NET;
public interface IMapper
{
    public TOutput Map<TOutput>(object input);
    public void Map<TInput, TOutput>(TInput input, TOutput output);
}