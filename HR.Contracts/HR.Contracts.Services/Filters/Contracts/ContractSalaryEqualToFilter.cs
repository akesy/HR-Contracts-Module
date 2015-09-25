using System.Globalization;
using System.Linq;
using HR.Contracts.Domain.Entities;
using HR.Contracts.Shared.Enums;
using HR.Contracts.Shared.Models;

namespace HR.Contracts.Services.Filters.Contracts
{
    class ContractSalaryEqualToFilter : CollectionFilter<Contract>
    {
        public ContractSalaryEqualToFilter(CollectionFilter<Contract> successor)
        {
            this.Successor = successor;
        }

        public override IQueryable<Contract> Filter(ColumnFilterInfo filterInfo, IQueryable<Contract> items)
        {
            if (filterInfo.Type == ColumnFilterType.ContractSalaryEqualTo && filterInfo.Value != null)
            {
                var value = decimal.Parse(filterInfo.Value.ToString(), CultureInfo.InvariantCulture);
                return items.Where(item => item.Salary == value);
            }

            return base.Filter(filterInfo, items);
        }
    }
}