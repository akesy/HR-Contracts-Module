using System.Collections.Generic;
using System.ServiceModel;
using System.Threading.Tasks;
using HR.Contracts.Services.Dto;

namespace HR.Contracts.Services.Abstract
{
    [ServiceContract]
    public interface IContractService
    {
        [OperationContract]
        Task<bool> AddContractAsync(DtoContract contract);

        [OperationContract]
        IEnumerable<DtoContract> GetAllContracts(int page, int pageSize);

        [OperationContract]
        int GetTotalContracts();
    }
}