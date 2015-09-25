using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using HR.Contracts.Domain.Abstract;
using HR.Contracts.Domain.Entities;
using HR.Contracts.Services.Abstract;
using HR.Contracts.Services.Dto;
using HR.Contracts.Services.Filters.Contracts;
using HR.Contracts.Services.Validators;
using HR.Contracts.Shared.Models;

namespace HR.Contracts.Services.Concrete
{
    public class ContractService : IContractService
    {
        private readonly IRepository<Contract> contractRepository;
        private readonly ISalaryPolicy policy;
        private readonly ISalaryCalculator calculator;

        public ContractService(IRepository<Contract> contractRepository, ISalaryPolicy policy, ISalaryCalculator calculator)
        {
            this.contractRepository = contractRepository;
            this.policy = policy;
            this.calculator = calculator;
        }

        public async Task<bool> AddContractAsync(DtoContract contract)
        {
            var validator = new ContractValidator(this.policy, this.calculator);
            var result = validator.Validate(contract);
            if (!result.IsValid)
            {
                return false;
            }

            var entity = Mapper.Map<Contract>(contract);
            this.contractRepository.Add(entity);
            await this.contractRepository.SaveChangesAsync();

            return true;
        }

        public ContractsPage GetAllContracts(IEnumerable<ColumnFilterInfo> filterCriteria, int page, int pageSize)
        {
            var filter = new ContractFilter();
            var items = filter.Filter(this.contractRepository.Items, filterCriteria);
            var contracts = items
                .OrderBy(c => c.Id)
                .Skip((page - 1) * pageSize)
                .Take(pageSize)
                .ToList();

            var dtoContracts = contracts.Select(c => Mapper.Map<DtoContract>(c));
            return new ContractsPage { Contracts = dtoContracts, TotalRecords = items.Count() };
        }
    }
}