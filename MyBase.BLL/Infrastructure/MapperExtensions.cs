using AutoMapper;

namespace MyBase.BLL.Infrastructure
{
    public static class MapperExtensions
    {
        public static TDestination Map<TDestination>(this object source)
        {
            return Mapper.Map<TDestination>(source);
        }
    }
}
