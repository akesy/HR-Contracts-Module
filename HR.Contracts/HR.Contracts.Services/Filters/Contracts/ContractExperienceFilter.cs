using System.Globalization;
using System.Linq;
using HR.Contracts.Domain.Entities;
using HR.Contracts.Shared.Enums;
using HR.Contracts.Shared.Models;

namespace HR.Contracts.Services.Filters.Contracts
{
    class ContractExperienceFilter : CollectionFilter<Contract>
    {
        public ContractExperienceFilter(CollectionFilter<Contract> successor)
        {
            this.Successor = successor;
        }

        public override IQueryable<Contract> Filter(ColumnFilterInfo filterInfo, IQueryable<Contract> items)
        {
            if (filterInfo.Type == ColumnFilterType.ContractExperience && filterInfo.Value != null)
            {
                var value = int.Parse(filterInfo.Value.ToString(), CultureInfo.InvariantCulture);
                return items.Where(item => item.Experience == value);
            }

            return base.Filter(filterInfo, items);
        }
    }
}