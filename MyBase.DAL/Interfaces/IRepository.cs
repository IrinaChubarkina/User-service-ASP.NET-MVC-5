using MyBase.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBase.DAL.Interfaces
{
    public interface IRepository<TEntity>
       where TEntity : class
    {
        void Add(TEntity item);
        void Edit(TEntity item);
        void Delete(int id);
        void InsertFakeData(IEnumerable<User> source);
        int Count();
    }
}
