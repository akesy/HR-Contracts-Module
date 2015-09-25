using System;
using System.Linq;
using HR.Contracts.Domain.Entities;
using HR.Contracts.Shared.Enums;
using HR.Contracts.Shared.Models;

namespace HR.Contracts.Services.Filters.Contracts
{
    class ContractTypeFilter : CollectionFilter<Contract>
    {
        public ContractTypeFilter(CollectionFilter<Contract> successor)
        {
            this.Successor = successor;
        }

        public override IQueryable<Contract> Filter(ColumnFilterInfo filterInfo, IQueryable<Contract> items)
        {
            if (filterInfo.Type == ColumnFilterType.ContractType && filterInfo.Value != null)
            {
                var value = (ContractType)Enum.Parse(typeof(ContractType), filterInfo.Value.ToString());
                return items.Where(item => item.Type == value);
            }

            return base.Filter(filterInfo, items);
        }
    }
}