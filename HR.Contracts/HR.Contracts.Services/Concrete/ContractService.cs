using System;
using HR.Contracts.Domain.Abstract;
using HR.Contracts.Domain.Entities;
using HR.Contracts.Services.Abstract;
using HR.Contracts.Services.Dto;
using AutoMapper;

namespace HR.Contracts.Services.Concrete
{
    public class ContractService : IContractService
    {
        private readonly IRepository<Contract> contractRepository;

        public ContractService(IRepository<Contract> contractRepository)
        {
            this.contractRepository = contractRepository;
        }

        public void AddContract(DtoContract contract)
        {
            // TODO: Validate the contract.
            var entity = Mapper.Map<Contract>(contract);
            this.contractRepository.Add(entity);
            this.contractRepository.SaveChanges();
        }
    }
}
