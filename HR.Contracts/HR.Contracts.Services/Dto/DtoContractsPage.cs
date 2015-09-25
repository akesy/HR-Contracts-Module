using System.Collections.Generic;

namespace HR.Contracts.Services.Dto
{
    public class DtoContractsPage
    {
        public IEnumerable<DtoContract> Contracts { get; set; }

        public int TotalRecords { get; set; }
    }
}