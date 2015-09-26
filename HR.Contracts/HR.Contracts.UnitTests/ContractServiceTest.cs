using System.Linq;
using System.Threading.Tasks;
using HR.Contracts.Domain.Abstract;
using HR.Contracts.Domain.Concrete;
using HR.Contracts.Domain.Entities;
using HR.Contracts.Services.Abstract;
using HR.Contracts.Services.Concrete;
using HR.Contracts.Services.Dto;
using HR.Contracts.Shared.Enums;
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
                new Contract { Name = "C1", Type = ContractType.Developer, Experience = 3, Salary = 5000 },
                new Contract { Name = "C2", Type = ContractType.Tester, Experience = 3, Salary = 3000 },
                new Contract { Name = "C3", Type = ContractType.Developer, Experience = 5, Salary = 8000 }
            }.AsQueryable();
            var mock = new Mock<IRepository<Contract>>();
            mock.Setup(m => m.Items).Returns(contracts);
            IContractService service = new ContractService(mock.Object, new DefaultSalaryPolicy(), new DefaultSalaryCalculator());

            var actual = service.GetAllContracts(null, 1, 3);

            Assert.IsTrue(actual.Contracts.All(c => c is DtoContract));
            Assert.AreEqual(3, actual.Contracts.Count());
            Assert.AreEqual("C1", actual.Contracts.ElementAt(0).Name, true);
            Assert.AreEqual("C2", actual.Contracts.ElementAt(1).Name, true);
            Assert.AreEqual("C3", actual.Contracts.ElementAt(2).Name, true);
        }
    }
}