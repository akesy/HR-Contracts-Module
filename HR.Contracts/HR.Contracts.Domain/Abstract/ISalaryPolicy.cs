namespace HR.Contracts.Domain.Abstract
{
    public interface ISalaryPolicy
    {
        decimal GetMinimumWage(ContractType contractType, int experience);
    }
}
