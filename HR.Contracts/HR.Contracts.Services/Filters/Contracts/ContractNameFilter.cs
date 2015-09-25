using System.Linq;
using HR.Contracts.Domain.Entities;
using HR.Contracts.Shared.Enums;
using HR.Contracts.Shared.Models;

namespace HR.Contracts.Services.Filters.Contracts
{
    class ContractNameFilter : CollectionFilter<Contract>
    {
        public ContractNameFilter(CollectionFilter<Contract> successor)
        {
            this.Successor = successor;
        }

        public override IQueryable<Contract> Filter(ColumnFilterInfo filterInfo, IQueryable<Contract> items)
        {
            var value = filterInfo.Value as string;
            if (filterInfo.Type == ColumnFilterType.ContractName && !string.IsNullOrWhiteSpace(value))
            {
                return items.Where(item => item.Name == value);
            }

            return base.Filter(filterInfo, items);
        }
    }
}