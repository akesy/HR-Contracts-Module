using HR.Contracts.Shared.Enums;

namespace HR.Contracts.Domain.Abstract
{
    public interface ISalaryCalculator
    {
        decimal Calculate(ContractType contractType, int experience, decimal minWage);
    }
}