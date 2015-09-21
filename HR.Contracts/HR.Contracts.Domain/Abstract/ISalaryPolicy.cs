namespace HR.Contracts.Domain.Abstract
{
    interface ISalaryPolicy
    {
        double GetMinimumWage(ContractType contractType, int experience);
    }
}
