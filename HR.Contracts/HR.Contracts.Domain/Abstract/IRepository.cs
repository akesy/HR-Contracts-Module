namespace HR.Contracts.Domain.Abstract
{
    public interface IRepository<TEntity>
    {
        void Add(TEntity entity);

        void SaveChanges();
    }
}
