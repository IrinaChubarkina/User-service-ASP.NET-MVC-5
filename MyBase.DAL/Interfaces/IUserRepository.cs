using System.Collections.Generic;

namespace MyBase.DAL.Interfaces
{
    public interface IUserRepository<TEntity> : IRepository<TEntity>
       where TEntity : class
    {
        IEnumerable<TEntity> GetList(int listSize, int startFrom);
        TEntity GetUser(int id);
        int GetUsersCount();
    }
}

