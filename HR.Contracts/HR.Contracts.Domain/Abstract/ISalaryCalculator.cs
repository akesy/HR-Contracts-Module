namespace HR.Contracts.Domain.Abstract
{
    interface ISalaryCalculator
    {
        decimal Calculate(ContractType contractType, int experience, decimal minWage);
    }
}
