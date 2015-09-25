using System.Collections.Generic;
using System.Linq;
using HR.Contracts.Domain.Entities;
using HR.Contracts.Shared.Models;

namespace HR.Contracts.Services.Filters.Contracts
{
    public class ContractFilter
    {
        private readonly CollectionFilter<Contract> headFilter;

        public ContractFilter()
        {
            var salaryFilter = new ContractSalaryFilter(null);
            var experienceFilter = new ContractExperienceFilter(salaryFilter);
            var typeFilter = new ContractTypeFilter(experienceFilter);
            this.headFilter = new ContractNameFilter(typeFilter);
        }

        public IQueryable<Contract> Filter(IQueryable<Contract> items, IEnumerable<ColumnFilterInfo> filterCriteria)
        {
            if (filterCriteria == null)
            {
                return items;
            }

            var result = items.AsQueryable();
            foreach (var filterCriterion in filterCriteria)
            {
                result = this.headFilter.Filter(filterCriterion, result);
            }

            return result;
        }
    }
}