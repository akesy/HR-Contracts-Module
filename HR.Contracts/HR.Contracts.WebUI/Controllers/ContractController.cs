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
        /// <summary>
        /// TODO: Remove hardcoded value.
        /// </summary>
        public int PageSize { get { return 10; } }

        public async Task<ViewResult> List(int page = 1)
        {
            var client = new ContractServiceClient();
            try
            {
                var contracts = await client.GetAllContractsAsync(page, this.PageSize);
                var totalRecords = await client.GetTotalContractsAsync();
                client.Close();

                var model = new ContractListViewModel
                {
                    Contracts = contracts.Select(c => Mapper.Map<ContractModel>(c)),
                    PagingInfo = new PagingInfo { CurrentPage = page, ItemsPerPage = this.PageSize, TotalItems = totalRecords }
                };
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