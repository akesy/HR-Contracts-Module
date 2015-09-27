using System.Linq;
using System.Threading.Tasks;
using HR.Contracts.Domain.Abstract;
using HR.Contracts.Domain.Concrete;
using HR.Contracts.Domain.Entities;
using HR.Contracts.Services.Abstract;
using HR.Contracts.Services.Concrete;
using HR.Contracts.Services.Dto;
using HR.Contracts.Shared.Enums;
using HR.Contracts.Shared.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace HR.Contracts.UnitTests
{
    [TestClass]
    public class ContractServiceTest
    {
        public ContractServiceTest()
        {
            AutoMapperConfig.RegisterMappings();
        }

        [TestMethod]
        public async Task GivenValidContractWhenAddingThenContractIsAdded()
        {
            var contract = new DtoContract { Name = "C1", Type = ContractType.Developer, Experience = 3, Salary = 5375 };
            var mock = new Mock<IRepository<Contract>>();
            IContractService service = new ContractService(mock.Object, new DefaultSalaryPolicy(), new DefaultSalaryCalculator());

            var expected = true;
            var actual = await service.CreateContractAsync(contract);

            mock.Verify(m => m.Add(It.IsAny<Contract>()), Times.Once());
            mock.Verify(m => m.SaveChangesAsync(), Times.Once());

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public async Task GivenInvalidContractWhenAddingThenContractIsNotAdded()
        {
            var contract = new DtoContract { Experience = 1 };
            var mock = new Mock<IRepository<Contract>>();
            IContractService service = new ContractService(mock.Object, new DefaultSalaryPolicy(), new DefaultSalaryCalculator());

            var expected = false;
            var actual = await service.CreateContractAsync(contract);

            mock.Verify(m => m.Add(It.IsAny<Contract>()), Times.Never());
            mock.Verify(m => m.SaveChangesAsync(), Times.Never());

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void GivenListOfContractsWhenGettingAllContractsThenAllContractsAreReturned()
        {
            var contracts = new Contract[]
            {
                new Contract { Id = 1, Name = "C1", Type = ContractType.Developer, Experience = 3, Salary = 5000 },
                new Contract { Id = 2, Name = "C2", Type = ContractType.Tester, Experience = 3, Salary = 3000 },
                new Contract { Id = 3, Name = "C3", Type = ContractType.Developer, Experience = 5, Salary = 8000 }
            }.AsQueryable();
            var mock = new Mock<IRepository<Contract>>();
            mock.Setup(m => m.Items).Returns(contracts);
            IContractService service = new ContractService(mock.Object, null, null);

            var actual = service.GetAllContracts(null, 1, 3);

            Assert.IsTrue(actual.Contracts.All(c => c is DtoContract));
            Assert.AreEqual(3, actual.Contracts.Count());
            Assert.AreEqual("C1", actual.Contracts.ElementAt(0).Name, true);
            Assert.AreEqual("C2", actual.Contracts.ElementAt(1).Name, true);
            Assert.AreEqual("C3", actual.Contracts.ElementAt(2).Name, true);
        }

        [TestMethod]
        public void GivenListOfContractsWhenGettingContractsPageThenDesiredPageIsReturned()
        {
            var contracts = new Contract[]
            {
                new Contract { Id = 1, Name = "C1", Type = ContractType.Developer, Experience = 3, Salary = 5000 },
                new Contract { Id = 2, Name = "C2", Type = ContractType.Tester, Experience = 3, Salary = 3000 },
                new Contract { Id = 3, Name = "C3", Type = ContractType.Developer, Experience = 5, Salary = 8000 },
                new Contract { Id = 4, Name = "C4", Type = ContractType.Tester, Experience = 5, Salary = 6000 },
                new Contract { Id = 5, Name = "C5", Type = ContractType.Developer, Experience = 1, Salary = 3000 }
            }.AsQueryable();
            var mock = new Mock<IRepository<Contract>>();
            mock.Setup(m => m.Items).Returns(contracts);
            IContractService service = new ContractService(mock.Object, null, null);

            var actual = service.GetAllContracts(null, 2, 3);

            Assert.IsTrue(actual.Contracts.All(c => c is DtoContract));
            Assert.AreEqual(2, actual.Contracts.Count());
            Assert.AreEqual("C4", actual.Contracts.ElementAt(0).Name, true);
            Assert.AreEqual("C5", actual.Contracts.ElementAt(1).Name, true);
        }

        [TestMethod]
        public void GivenListOfContractsWhenGettingNonExistingContractsPageThenNoContractsAreReutrned()
        {
            var contracts = new Contract[]
            {
                new Contract { Id = 1, Name = "C1", Type = ContractType.Developer, Experience = 3, Salary = 5000 },
                new Contract { Id = 2, Name = "C2", Type = ContractType.Tester, Experience = 3, Salary = 3000 },
                new Contract { Id = 3, Name = "C3", Type = ContractType.Developer, Experience = 5, Salary = 8000 },
                new Contract { Id = 4, Name = "C4", Type = ContractType.Tester, Experience = 5, Salary = 6000 },
                new Contract { Id = 5, Name = "C5", Type = ContractType.Developer, Experience = 1, Salary = 3000 }
            }.AsQueryable();
            var mock = new Mock<IRepository<Contract>>();
            mock.Setup(m => m.Items).Returns(contracts);
            IContractService service = new ContractService(mock.Object, null, null);

            var actual = service.GetAllContracts(null, 2, 5);

            Assert.IsFalse(actual.Contracts.Any());
            Assert.AreEqual(5, actual.TotalRecords);
        }

        [TestMethod]
        public void GivenListOfContractsWhenFilteringDeveloperContractsThenDeveloperContractsOnlyAreReturned()
        {
            var contracts = new Contract[]
            {
                new Contract { Id = 1, Name = "C1", Type = ContractType.Developer, Experience = 3, Salary = 5000 },
                new Contract { Id = 2, Name = "C2", Type = ContractType.Tester, Experience = 3, Salary = 3000 },
                new Contract { Id = 3, Name = "C3", Type = ContractType.Developer, Experience = 5, Salary = 8000 },
                new Contract { Id = 4, Name = "C4", Type = ContractType.Tester, Experience = 5, Salary = 6000 },
                new Contract { Id = 5, Name = "C5", Type = ContractType.Developer, Experience = 1, Salary = 3000 }
            }.AsQueryable();
            var mock = new Mock<IRepository<Contract>>();
            mock.Setup(m => m.Items).Returns(contracts);
            IContractService service = new ContractService(mock.Object, null, null);
            var filterCriteria = new ColumnFilterInfo[]
            {
                new ColumnFilterInfo { Type = ColumnFilterType.ContractType, Value = ContractType.Developer.ToString() }
            };

            var actual = service.GetAllContracts(filterCriteria, 1, 10);

            Assert.IsTrue(actual.Contracts.All(c => c is DtoContract));
            Assert.AreEqual(3, actual.Contracts.Count());
            Assert.AreEqual(3, actual.TotalRecords);
            Assert.AreEqual("C1", actual.Contracts.ElementAt(0).Name, true);
            Assert.AreEqual("C3", actual.Contracts.ElementAt(1).Name, true);
            Assert.AreEqual("C5", actual.Contracts.ElementAt(2).Name, true);
        }

        [TestMethod]
        public void GivenListOfContractsWhenFilteringContractsNonMeetingFilterCriteriaThenNoContractsAreReturned()
        {
            var contracts = new Contract[]
            {
                new Contract { Id = 1, Name = "C1", Type = ContractType.Developer, Experience = 3, Salary = 5000 },
                new Contract { Id = 2, Name = "C2", Type = ContractType.Tester, Experience = 3, Salary = 3000 },
                new Contract { Id = 3, Name = "C3", Type = ContractType.Developer, Experience = 5, Salary = 8000 },
                new Contract { Id = 4, Name = "C4", Type = ContractType.Tester, Experience = 5, Salary = 6000 },
                new Contract { Id = 5, Name = "C5", Type = ContractType.Developer, Experience = 1, Salary = 3000 }
            }.AsQueryable();
            var mock = new Mock<IRepository<Contract>>();
            mock.Setup(m => m.Items).Returns(contracts);
            IContractService service = new ContractService(mock.Object, null, null);
            var filterCriteria = new ColumnFilterInfo[]
            {
                new ColumnFilterInfo { Type = ColumnFilterType.ContractType, Value = ContractType.Developer.ToString() },
                new ColumnFilterInfo { Type = ColumnFilterType.ContractExperience, Value = 4 }
            };

            var actual = service.GetAllContracts(filterCriteria, 1, 10);

            Assert.IsFalse(actual.Contracts.Any());
            Assert.AreEqual(0, actual.TotalRecords);
        }

        [TestMethod]
        public void GivenContractTypeAndExperienceWhenCalculatingSalaryThenCalculationIsCorrect()
        {
            var contractType = ContractType.Developer;
            var experience = 3;
            ISalaryService service = new ContractService(null, new DefaultSalaryPolicy(), new DefaultSalaryCalculator());

            var expected = 5375;
            var actual = service.CalculateSalary(contractType, experience);

            Assert.AreEqual(expected, actual);
        }
    }
}