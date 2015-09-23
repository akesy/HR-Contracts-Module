using HR.Contracts.Domain.Abstract;

namespace HR.Contracts.Domain.Entities
{
    public class Contract : IEntity
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public ContractType Type { get; set; }

        public int Experience { get; set; }

        public decimal Salary { get; set; }
    }
}
