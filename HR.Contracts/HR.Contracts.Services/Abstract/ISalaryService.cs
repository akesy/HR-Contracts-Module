using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
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
