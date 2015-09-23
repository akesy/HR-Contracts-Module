using System.Linq;
using HR.Contracts.Services.Dto;
using HR.Contracts.Shared.Enums;
using HR.Contracts.Shared.Models;

namespace HR.Contracts.Services.Filters.Contracts
{
    class ContractSalaryFilter : CollectionFilter<DtoContract>
    {
        public ContractSalaryFilter(CollectionFilter<DtoContract> successor)
        {
            this.Successor = successor;
        }

        public override IQueryable<DtoContract> Filter(ColumnFilterInfo filterInfo, IQueryable<DtoContract> items)
        {
            if (filterInfo.Type == ColumnFilterType.ContractSalary && filterInfo.Value != null)
            {
                return items.Where(item => item.Salary.Equals(filterInfo.Value));
            }

            return base.Filter(filterInfo, items);
        }
    }
}