using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using HR.Contracts.Domain.Abstract;

namespace HR.Contracts.Domain.Concrete
{
    public class EFRepository<TEntity> : IRepository<TEntity>
        where TEntity : class, IEntity
    {
        private readonly DbContext context;
        private readonly IDbSet<TEntity> items;

        public EFRepository(DbContext context)
        {
            this.context = context;
            this.items = this.context.Set<TEntity>();
        }

        public IQueryable<TEntity> Items { get { return this.items; } }

        public void Add(TEntity entity)
        {
            if (entity.Id == 0)
            {
                this.items.Add(entity);
            }
        }

        public IQueryable<TEntity> Get()
        {
            return this.items;
        }

        public async Task SaveChangesAsync()
        {
            await this.context.SaveChangesAsync();
        }
    }
}