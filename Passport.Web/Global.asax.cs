namespace Passport.Web
{
    using System.Web.Http;
    using System.Web.Mvc;
    using System.Web.Routing;

    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            IoCContainerConfig.Setup(GlobalConfiguration.Configuration);
            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            MvcHandler.DisableMvcResponseHeader = true;
        }
    }
}
