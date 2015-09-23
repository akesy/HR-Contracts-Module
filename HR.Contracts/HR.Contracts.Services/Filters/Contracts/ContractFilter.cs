using System.Collections.Generic;
using System.Linq;
using HR.Contracts.Services.Dto;

namespace HR.Contracts.Services.Filters.Contracts
{
    public class ContractFilter
    {
        private readonly CollectionFilter<DtoContract> headFilter;

        public ContractFilter()
        {
            var salaryFilter = new ContractSalaryFilter(null);
            var experienceFilter = new ContractExperienceFilter(salaryFilter);
            var typeFilter = new ContractTypeFilter(experienceFilter);
            this.headFilter = new ContractNameFilter(typeFilter);
        }

        public IQueryable<DtoContract> Filter(IQueryable<DtoContract> items, IEnumerable<ColumnFilterInfo> filterCriteria)
        {
            var result = items.AsQueryable();
            foreach (var filterCriterion in filterCriteria)
            {
                result = this.headFilter.Filter(filterCriterion, result);
            }

            return result;
        }
    }
}