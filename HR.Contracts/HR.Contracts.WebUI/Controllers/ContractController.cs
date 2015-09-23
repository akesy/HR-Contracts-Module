using System;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Mvc;
using AutoMapper;
using HR.Contracts.WebUI.ContractService;
using HR.Contracts.WebUI.Models;

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

                var model = contracts.Select(c => Mapper.Map<ContractModel>(c));
                return this.View(model);
            }
            catch (Exception)
            {
                client.Abort();
                throw;
            }
        }
    }
}