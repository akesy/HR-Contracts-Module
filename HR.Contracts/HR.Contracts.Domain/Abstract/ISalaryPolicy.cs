namespace HR.Contracts.Domain.Abstract
{
    public interface ISalaryPolicy
    {
        double GetMinimumWage(ContractType contractType, int experience);
    }
}
