namespace MyBase.BLL.Mappers
{
    public interface IMapper<TSource, TDestination>
    {
        TDestination Map(TSource source);
    }
}