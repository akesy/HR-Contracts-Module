using HR.Contracts.Domain.Abstract;
using HR.Contracts.Domain.Entities;
using HR.Contracts.Services.Concrete;
using HR.Contracts.Services.Dto;
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
        public void GivenValidContractWhenAddingThenContractIsAdded()
        {
            var contract = new DtoContract { Name = "C1", Type = ContractType.Developer, Experience = 3, Salary = 5375 };
            var mock = new Mock<IRepository<Contract>>();
            var service = new ContractService(mock.Object);

            var expected = true;
            var actual = service.AddContract(contract);

            mock.Verify(m => m.Add(It.IsAny<Contract>()), Times.Once());
            mock.Verify(m => m.SaveChanges(), Times.Once());

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void GivenInvalidContractWhenAddingThenContractIsNotAdded()
        {
            var contract = new DtoContract();
            var mock = new Mock<IRepository<Contract>>();
            var service = new ContractService(mock.Object);

            var expected = false;
            var actual = service.AddContract(contract);

            mock.Verify(m => m.Add(It.IsAny<Contract>()), Times.Never());
            mock.Verify(m => m.SaveChanges(), Times.Never());

            Assert.AreEqual(expected, actual);
        }
    }
}
