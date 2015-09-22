using HR.Contracts.Services.Dto;
using System;
using System.Linq;

namespace HR.Contracts.Services.Filters.Contracts
{
    public class ContractNameFilter : CollectionFilter<DtoContract>
    {
        private const string FilterName = "ContractName";

        public ContractNameFilter(CollectionFilter<DtoContract> successor)
        {
            this.Successor = successor;
        }

        public override IQueryable<DtoContract> Filter(CollectionFilterInfo filterInfo, IQueryable<DtoContract> items)
        {
            if (string.Equals(filterInfo.Name, FilterName, StringComparison.OrdinalIgnoreCase)
                && filterInfo.Value != null)
            {
                return items.Where(item => item.Name.Contains(filterInfo.Value.ToString()));
            }

            return base.Filter(filterInfo, items);
        }
    }
}
