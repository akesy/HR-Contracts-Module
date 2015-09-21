using HR.Contracts.Domain.Abstract;
using System;

namespace HR.Contracts.Domain.Concrete
{
    class DefaultSalaryCalculator : ISalaryCalculator
    {
        public decimal Calculate(ContractType contractType, int experience, decimal minWage)
        {
            switch (contractType)
            {
                case ContractType.Developer:
                    return minWage + (experience * 125);
                case ContractType.Tester:
                    return minWage + (experience * 100 + minWage / 4);
                default:
                    throw new ArgumentException("The contract type in unknown.", "contractType");
            }
        }
    }
}
