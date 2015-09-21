namespace HR.Contracts.Domain.Entities
{
    class Contract
    {
        public string Name { get; set; }

        public EmployeeType EmployeeType { get; set; }

        public int Experience { get; set; }

        public decimal Salary { get; set; }
    }
}
