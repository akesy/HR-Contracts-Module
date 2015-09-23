using System.Linq;
using System.Threading.Tasks;

namespace HR.Contracts.Domain.Abstract
{
    public interface IRepository<TEntity>
    {
        IQueryable<TEntity> Items { get; }

        void Add(TEntity entity);

        IQueryable<TEntity> Get();

        Task SaveChangesAsync();
    }
}
