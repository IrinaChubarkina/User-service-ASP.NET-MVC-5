using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBase.BLL.Interfaces
{
    public interface IMapper<TSource, TDestination>
    {
        TDestination Convert(TSource source);
        TSource Convert(TDestination source);
    }
}