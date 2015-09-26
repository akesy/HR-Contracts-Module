using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using HR.Contracts.Shared.Enums;
using HR.Contracts.WebUI.SalaryService;

namespace HR.Contracts.WebUI.Controllers
{
    public class SalaryController : Controller
    {
        public async Task<JsonResult> Calculate(ContractType contractType, int experience)
        {
            var client = new SalaryServiceClient();
            try
            {
                var salary = await client.CalculateSalaryAsync(contractType, experience);
                client.Close();

                return this.Json(salary, JsonRequestBehavior.AllowGet);
            }
            catch (Exception)
            {
                client.Abort();
                throw;
            }
        }
    }
}