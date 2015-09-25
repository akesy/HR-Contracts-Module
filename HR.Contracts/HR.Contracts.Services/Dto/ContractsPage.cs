using System.Collections.Generic;

namespace HR.Contracts.Services.Dto
{
    public class ContractsPage
    {
        public IEnumerable<DtoContract> Contracts { get; set; }

        public int TotalRecords { get; set; }
    }
}