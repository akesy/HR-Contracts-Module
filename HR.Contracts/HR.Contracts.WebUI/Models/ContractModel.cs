using System.ComponentModel.DataAnnotations;
using HR.Contracts.Shared.Enums;

namespace HR.Contracts.WebUI.Models
{
    public class ContractModel
    {
        private const string LocalizedEnumDisplayTemplateName = "LocalizedEnum";

        public string Name { get; set; }

        [UIHint(LocalizedEnumDisplayTemplateName)]
        public ContractType Type { get; set; }

        public int Experience { get; set; }

        public decimal Salary { get; set; }
    }
}