using System.Linq;
using HR.Contracts.Services.Dto;

namespace HR.Contracts.Services.Filters.Contracts
{
    class ContractNameFilter : CollectionFilter<DtoContract>
    {
        public ContractNameFilter(CollectionFilter<DtoContract> successor)
        {
            this.Successor = successor;
        }

        public override IQueryable<DtoContract> Filter(ColumnFilterInfo filterInfo, IQueryable<DtoContract> items)
        {
            if (filterInfo.Type == ColumnFilterType.ContractName && filterInfo.Value != null)
            {
                return items.Where(item => item.Name.Contains(filterInfo.Value.ToString()));
            }

            return base.Filter(filterInfo, items);
        }
    }
}