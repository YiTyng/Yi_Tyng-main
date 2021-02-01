namespace Passport.WebApi
{
    using Filters;
    using System.Net.Http;
    using System.Web.Http;

    public static class WebApiConfig
    {
        internal const string WebApiRouteName = "DummyRestApi";

        /// <summary>
        /// Registers Web API for the specified <see cref="HttpConfiguration"/>.
        /// </summary>
        /// <param name="configuration">The <see cref="HttpConfiguration"/> to setup Web API for.</param>
        public static void Register(HttpConfiguration configuration)
        {
            configuration.MapHttpAttributeRoutes();

            configuration.Routes.MapHttpRoute(
                name: WebApiRouteName,
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional },
                constraints: null);

            var handler = (DelegatingHandler)configuration.DependencyResolver.GetService(typeof(AuthorizationHandler));
            configuration.MessageHandlers.Add(handler);

            configuration.Formatters.Remove(configuration.Formatters.XmlFormatter);

            configuration.Filters.Add(new GlobalExceptionFilterAttribute());
            configuration.EnsureInitialized();
        }
    }
}