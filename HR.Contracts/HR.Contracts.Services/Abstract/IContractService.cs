using System.Collections.Generic;
using System.ServiceModel;
using System.Threading.Tasks;
using HR.Contracts.Services.Dto;
using HR.Contracts.Shared.Models;

namespace HR.Contracts.Services.Abstract
{
    [ServiceContract]
    public interface IContractService
    {
        [OperationContract]
        Task<bool> AddContractAsync(DtoContract contract);

        [OperationContract]
        DtoContractsPage GetAllContracts(IEnumerable<ColumnFilterInfo> filterCriteria, int page, int pageSize);
    }
}