namespace MyBase.BLL.Interfaces
{
    public interface IMapper<TSource, TDestination>
    {
        TDestination Convert(TSource source);
        TSource Convert(TDestination source);
    }
}