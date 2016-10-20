using System.Web.Mvc;
using System.Web.Routing;
using DVDRenatal.Infrastructure.Autofac;
using DVDRenatal.Infrastructure.AutoMapper;

namespace DVDRental.Ui
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AutofacConfig.Initialize();
            AutoMapperConfig.Initialize();

            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);
        }
    }
}
