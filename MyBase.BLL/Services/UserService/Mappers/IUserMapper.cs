using System.Collections.Generic;

namespace MyBase.BLL.Services.UserService.Mappers
{
    public interface IUserMapper<TSource, TDestination>
    {
        TDestination Map(TSource source);
        TSource Map(TDestination source);
        List<TDestination> Map(List<TSource> source);
    }
}
