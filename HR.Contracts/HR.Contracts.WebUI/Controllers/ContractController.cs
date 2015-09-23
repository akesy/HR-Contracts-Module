using System.Web.Mvc;

namespace HR.Contracts.WebUI.Controllers
{
    public class ContractController : Controller
    {
        public ViewResult List()
        {
            return this.View();
        }
    }
}