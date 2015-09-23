using System;
using System.Threading.Tasks;
using System.Web.Mvc;
using HR.Contracts.WebUI.ContractService;

namespace HR.Contracts.WebUI.Controllers
{
    public class ContractController : Controller
    {
        public async Task<ViewResult> List()
        {
            var client = new ContractServiceClient();
            try
            {
                var contracts = await client.GetAllContractsAsync();
                client.Close();
                return this.View(contracts);
            }
            catch (Exception)
            {
                client.Abort();
                throw;
            }
        }
    }
}