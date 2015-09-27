using System.ComponentModel.DataAnnotations;
using HR.Contracts.Shared.Enums;

namespace HR.Contracts.WebUI.Models
{
    [MetadataType(typeof(ContractModelMetadata))]
    public class ContractModel
    {
        public string Name { get; set; }

        public ContractType Type { get; set; }

        public int Experience { get; set; }

        public decimal Salary { get; set; }
    }
}