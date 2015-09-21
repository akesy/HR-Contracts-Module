using HR.Contracts.Services.Dto;
using System.ServiceModel;

namespace HR.Contracts.Services.Abstract
{
    [ServiceContract]
    public interface IContractService
    {
        [OperationContract]
        bool AddContract(DtoContract contract);
    }
}
