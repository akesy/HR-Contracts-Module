namespace HR.Contracts.Domain.Migrations
{
    using System.Data.Entity.Migrations;
    using Concrete;
    using Entities;
    using Shared.Enums;

    internal sealed class Configuration : DbMigrationsConfiguration<EFDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(EFDbContext context)
        {
            context.Contracts.AddOrUpdate(
                new Contract { Id = 1, Name = "C1", Type = ContractType.Developer, Experience = 3, Salary = 5375 },
                new Contract { Id = 2, Name = "C2", Type = ContractType.Developer, Experience = 5, Salary = 5625 },
                new Contract { Id = 3, Name = "C3", Type = ContractType.Tester, Experience = 2, Salary = 3575 },
                new Contract { Id = 4, Name = "C4", Type = ContractType.Tester, Experience = 1, Salary = 2600 },
                new Contract { Id = 5, Name = "C5", Type = ContractType.Developer, Experience = 5, Salary = 6125 },
                new Contract { Id = 6, Name = "C6", Type = ContractType.Tester, Experience = 3, Salary = 3675 },
                new Contract { Id = 7, Name = "C7", Type = ContractType.Developer, Experience = 1, Salary = 2625 },
                new Contract { Id = 8, Name = "C8", Type = ContractType.Tester, Experience = 4, Salary = 3775 },
                new Contract { Id = 9, Name = "C9", Type = ContractType.Developer, Experience = 2, Salary = 2750 },
                new Contract { Id = 10, Name = "C10", Type = ContractType.Developer, Experience = 6, Salary = 6250 },
                new Contract { Id = 11, Name = "C11", Type = ContractType.Tester, Experience = 5, Salary = 4500 }
                );
        }
    }
}