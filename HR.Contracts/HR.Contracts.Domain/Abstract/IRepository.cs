using System.Linq;
using System.Threading.Tasks;

namespace HR.Contracts.Domain.Abstract
{
    public interface IRepository<TEntity>
    {
        IQueryable<TEntity> Items { get; }

        void Add(TEntity entity);

        Task SaveChangesAsync();
    }
}