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
            var contract = new DtoContract();
            var mock = new Mock<IRepository<Contract>>();
            var service = new ContractService(mock.Object);

            service.AddContract(contract);

            mock.Verify(m => m.Add(It.IsAny<Contract>()), Times.Once());
            mock.Verify(m => m.SaveChanges(), Times.Once());
        }
    }
}
