namespace Core.Mapping;

public interface IMapper<TIn, TOut>
{
    TIn? ConvertFrom(TOut? item);
    TOut? ConvertTo(TIn? item);
}
