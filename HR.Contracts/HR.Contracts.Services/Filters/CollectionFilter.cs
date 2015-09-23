using System.Linq;
using HR.Contracts.Shared.Models;

namespace HR.Contracts.Services.Filters
{
    class CollectionFilter<T>
    {
        protected CollectionFilter<T> Successor { get; set; }

        public virtual IQueryable<T> Filter(ColumnFilterInfo filterInfo, IQueryable<T> items)
        {
            if (this.Successor != null)
            {
                return this.Successor.Filter(filterInfo, items);
            }

            return items;
        }
    }
}