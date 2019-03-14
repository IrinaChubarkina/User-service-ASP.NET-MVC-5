namespace MyBase.DAL.Interfaces
{
    public interface IRepository<TEntity>
       where TEntity : class
    {
        void Create(TEntity item);
        void Update(TEntity item);
    }
}
