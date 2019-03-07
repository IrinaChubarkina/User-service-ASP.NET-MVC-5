using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBase.DAL.Interfaces
{
    public interface IUserRepository<TEntity> : IRepository<TEntity>
       where TEntity : class
    {
        IEnumerable<TEntity> GetList(int listSize, int startFrom);
        TEntity Get(int id);
        int Count();
    }
}

