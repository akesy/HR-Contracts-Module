﻿namespace HR.Contracts.Domain.Entities
{
    public class Contract
    {
        public string Name { get; set; }

        public ContractType Type { get; set; }

        public int Experience { get; set; }

        public decimal Salary { get; set; }
    }
}