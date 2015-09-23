using System.Web.Mvc;
using System.Web.Routing;
using HR.Contracts.WebUI.App_Start;

namespace HR.Contracts.WebUI
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            AutoMapperConfig.RegisterMappings();
        }
    }
}