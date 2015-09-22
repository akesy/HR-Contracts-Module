using HR.Contracts.Services.Dto;
using System;
using System.Linq;

namespace HR.Contracts.Services.Filters.Contracts
{
    class ContractSalaryFilter : CollectionFilter<DtoContract>
    {
        private const string FilterName = "ContractSalary";

        public ContractSalaryFilter(CollectionFilter<DtoContract> successor)
        {
            this.Successor = successor;
        }

        public override IQueryable<DtoContract> Filter(CollectionFilterInfo filterInfo, IQueryable<DtoContract> items)
        {
            if (string.Equals(filterInfo.Name, FilterName, StringComparison.OrdinalIgnoreCase)
                && filterInfo.Value != null)
            {
                return items.Where(item => item.Salary.Equals(filterInfo.Value));
            }

            return base.Filter(filterInfo, items);
        }
    }
}
