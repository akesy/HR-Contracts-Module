using AutoMapper;
using HR.Contracts.Domain.Abstract;
using HR.Contracts.Domain.Entities;
using HR.Contracts.Services.Abstract;
using HR.Contracts.Services.Dto;
using HR.Contracts.Services.Validators;

namespace HR.Contracts.Services.Concrete
{
    public class ContractService : IContractService
    {
        private readonly IRepository<Contract> contractRepository;

        public ContractService(IRepository<Contract> contractRepository)
        {
            this.contractRepository = contractRepository;
        }

        public bool AddContract(DtoContract contract)
        {
            var validator = new ContractValidator();
            var result = validator.Validate(contract);
            if (!result.IsValid)
            {
                return false;
            }

            var entity = Mapper.Map<Contract>(contract);
            this.contractRepository.Add(entity);
            this.contractRepository.SaveChanges();

            return true;
        }
    }
}
