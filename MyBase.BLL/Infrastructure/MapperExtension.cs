using System;
using AutoMapper;

namespace MyBase.BLL.Infrastructure
{
    public static class MapperExtensions
    {
        public static TDestination Map<TDestination>(this object source)
        {
            if (source == null)
            {
                throw new ArgumentNullException("Empty source");
            }
            return Mapper.Map<TDestination>(source);
        }
    }
}
