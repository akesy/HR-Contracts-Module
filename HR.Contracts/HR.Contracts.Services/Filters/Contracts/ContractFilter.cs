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
            var salaryGreaterThanFilter = new ContractSalaryGraterThanFilter(null);
            var salaryEqualToFilter = new ContractSalaryEqualToFilter(salaryGreaterThanFilter);
            var experienceFilter = new ContractExperienceFilter(salaryEqualToFilter);
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