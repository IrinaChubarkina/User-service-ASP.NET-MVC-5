using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBase.DAL.Interfaces
{
    public interface IUserRepository<TEntity>
       where TEntity : class
    {
        IEnumerable<TEntity> GetList();
        TEntity Get(int id);
        //TEntity Get<TProperty>(int id, Expression<Func<TEntity,TProperty>> expression );
        void Add(TEntity item);
        void Edit(TEntity item);
        void Delete(int id);
    }
}

