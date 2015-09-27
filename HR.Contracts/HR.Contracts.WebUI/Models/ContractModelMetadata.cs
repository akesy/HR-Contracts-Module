using System.ComponentModel.DataAnnotations;
using HR.Contracts.Shared.Enums;
using HR.Contracts.WebUI.Constants;
using HR.Contracts.WebUI.Resources;

namespace HR.Contracts.WebUI.Models
{
    public class ContractModelMetadata
    {
        [Required]
        [Display(Name = ResourceKeys.ContractName, ResourceType = typeof(Labels))]
        public string Name { get; set; }

        [Required]
        [Display(Name = ResourceKeys.ContractType, ResourceType = typeof(Labels))]
        [UIHint(DisplayTemplateNames.LocalizedEnum)]
        public ContractType Type { get; set; }

        [Required]
        [Display(Name = ResourceKeys.ContractExperience, ResourceType = typeof(Labels))]
        public int Experience { get; set; }

        [Required]
        [Display(Name = ResourceKeys.ContractSalary, ResourceType = typeof(Labels))]
        public decimal Salary { get; set; }
    }
}