﻿using HR.Contracts.Services.Dto;
using System;
using System.Linq;

namespace HR.Contracts.Services.Filters.Contracts
{
    class ContractExperienceFilter : CollectionFilter<DtoContract>
    {
        private const string FilterName = "ContractExperience";

        public ContractExperienceFilter(CollectionFilter<DtoContract> successor)
        {
            this.Successor = successor;
        }

        public override IQueryable<DtoContract> Filter(CollectionFilterInfo filterInfo, IQueryable<DtoContract> items)
        {
            if (string.Equals(filterInfo.Name, FilterName, StringComparison.OrdinalIgnoreCase)
                && filterInfo.Value != null)
            {
                return items.Where(item => item.Experience.Equals(filterInfo.Value));
            }

            return base.Filter(filterInfo, items);
        }
    }
}