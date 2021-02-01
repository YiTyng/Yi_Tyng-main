namespace Passport.WebApi
{
    using System.Web;
    using System.Web.Http;
    using System.Web.Mvc;
    using System.Web.Routing;

    public class MvcApplication : HttpApplication
    {
        protected void Application_Start()
        {
            IoCContainerConfig.Setup(GlobalConfiguration.Configuration);
            AreaRegistration.RegisterAllAreas();
            WebApiConfig.Register(GlobalConfiguration.Configuration);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            MvcHandler.DisableMvcResponseHeader = true;
        }
    }
}
