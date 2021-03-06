﻿using System.Globalization;
using System.Linq;
using System.ServiceModel;
using System.Threading.Tasks;
using System.Web.Mvc;
using AutoMapper;
using HR.Contracts.Shared.Enums;
using HR.Contracts.Shared.Models;
using HR.Contracts.WebUI.ContractService;
using HR.Contracts.WebUI.Models;
using HR.Contracts.WebUI.Resources;

namespace HR.Contracts.WebUI.Controllers
{
    public class ContractController : Controller
    {
        private const string ListActionName = "List";
        private const string SalaryPropertyName = "Salary";
        
        /// <summary>
        /// TODO: Remove hardcoded value.
        /// </summary>
        public int PageSize { get { return 10; } }

        public async Task<ViewResult> List(ContractFilterCriteria filterArgs, int page = 1)
        {
            var client = new ContractServiceClient();
            try
            {
                var filterCriteria = CreateFilterCriteria(filterArgs);
                var contractsPage = await client.GetAllContractsAsync(filterCriteria, page, this.PageSize);
                client.Close();

                var model = new ContractsListViewModel
                {
                    Contracts = contractsPage.Contracts.Select(c => Mapper.Map<ContractModel>(c)),
                    PagingInfo = new PagingInfo { CurrentPage = page, ItemsPerPage = this.PageSize, TotalItems = contractsPage.TotalRecords }
                };
                return this.View(model);
            }
            catch (FaultException)
            {
                client.Abort();
                throw;
            }
        }

        public ViewResult Create()
        {
            return this.View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(ContractModel model)
        {
            if (this.ModelState.IsValid)
            {
                var contract = Mapper.Map<DtoContract>(model);
                var client = new ContractServiceClient();
                try
                {
                    var result = await client.CreateContractAsync(contract);
                    client.Close();

                    if (!result)
                    {
                        var errorMessage = string.Format(CultureInfo.CurrentCulture, Messages.TheSalaryValueAndCalculatedDoNotMatch, Labels.ContractSalary);
                        this.ModelState.AddModelError(SalaryPropertyName, errorMessage);
                    }
                    else
                    {
                        return this.RedirectToAction(ListActionName);
                    }
                }
                catch (FaultException)
                {
                    client.Abort();
                    throw;
                }
            }

            return this.View(model);
        }

        private static ColumnFilterInfo[] CreateFilterCriteria(ContractFilterCriteria filterArgs)
        {
            return new ColumnFilterInfo[]
            {
                    new ColumnFilterInfo { Type = ColumnFilterType.ContractName, Value = filterArgs.Name },
                    new ColumnFilterInfo { Type = ColumnFilterType.ContractType, Value = filterArgs.Type.HasValue
                    ? filterArgs.Type.ToString()
                    : null },
                    new ColumnFilterInfo { Type = ColumnFilterType.ContractExperience, Value = filterArgs.Experience },
                    new ColumnFilterInfo { Type = ColumnFilterType.ContractSalaryEqualTo, Value = filterArgs.SalaryEqualTo },
                    new ColumnFilterInfo { Type = ColumnFilterType.ContractSalaryGreaterThan, Value = filterArgs.SalaryGreaterThan }
            };
        }
    }
}