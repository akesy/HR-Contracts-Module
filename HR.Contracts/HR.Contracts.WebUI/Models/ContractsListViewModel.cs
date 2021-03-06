﻿using System.Collections.Generic;

namespace HR.Contracts.WebUI.Models
{
    public class ContractsListViewModel
    {
        public IEnumerable<ContractModel> Contracts { get; set; }

        public PagingInfo PagingInfo { get; set; }
    }
}