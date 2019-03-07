namespace MyBase.DAL.Interfaces
{
    public interface IRepository<TEntity>
       where TEntity : class
    {
        void Add(TEntity item);
        void Update(TEntity item);
        void Delete(int id);
        int GetLastId();
    }
}
