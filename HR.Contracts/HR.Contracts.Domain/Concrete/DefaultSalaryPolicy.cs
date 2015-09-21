﻿using HR.Contracts.Domain.Abstract;
using System;

namespace HR.Contracts.Domain.Concrete
{
    class DefaultSalaryPolicy : ISalaryPolicy
    {
        public double GetMinimumWage(ContractType contractType, int experience)
        {
            // TODO: Move hardcoded values to config file.

            if (experience < 1)
            {
                throw new ArgumentException("The experience must be at least one year.", "experience");
            }

            if (contractType == ContractType.Developer)
            {
                if (experience >= 1 && experience < 3)
                {
                    return 2500;
                }

                if (experience >= 3 && experience <= 5)
                {
                    return 5000;
                }

                return 5500;
            }
            else if (contractType == ContractType.Tester)
            {
                if (experience >= 1 && experience < 2)
                {
                    return 2000;
                }

                if (experience >= 2 && experience <= 4)
                {
                    return 2700;
                }

                return 3200;
            }
            else
            {
                throw new ArgumentException("The contract type in unknown.", "contractType");
            }
        }
    }
}
