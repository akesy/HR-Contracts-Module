using HR.Contracts.Shared.Enums;

namespace HR.Contracts.WebUI.Models
{
    public class ContractFilterCriteria
    {
        public string Name { get; set; }

        public ContractType? ContractType { get; set; }

        public int? Experience { get; set; }

        public int? Salary { get; set; }
    }
}