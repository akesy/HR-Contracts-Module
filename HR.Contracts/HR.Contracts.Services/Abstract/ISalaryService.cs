using System.ServiceModel;
using HR.Contracts.Shared.Enums;

namespace HR.Contracts.Services.Abstract
{
    [ServiceContract]
    public interface ISalaryService
    {
        [OperationContract]
        decimal CalculateSalary(ContractType contractType, int experience);
    }
}