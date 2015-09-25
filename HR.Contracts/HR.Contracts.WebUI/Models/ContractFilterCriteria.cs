using HR.Contracts.Shared.Enums;

namespace HR.Contracts.WebUI.Models
{
    public class ContractFilterCriteria
    {
        public string Name { get; set; }

        public ContractType? Type { get; set; }

        public int? Experience { get; set; }

        public int? SalaryEqualTo { get; set; }

        public int? SalaryGreaterThan { get; set; }
    }
}