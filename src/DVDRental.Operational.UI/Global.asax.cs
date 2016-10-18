using System.Web.Mvc;
using System.Web.Routing;
using DVDRenatal.Infrastructure.Autofac;

namespace DVDRental.Operational.UI
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AutofacConfig.Initialize();

            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);
        }
    }
}
