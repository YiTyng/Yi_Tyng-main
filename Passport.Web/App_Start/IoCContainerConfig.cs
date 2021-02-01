namespace Passport.Web
{
    using System;
    using System.Configuration;
    using System.Net.Http;
    using System.Reflection;
    using System.Web.Http;
    using System.Web.Mvc;
    using Autofac;
    using Autofac.Integration.Mvc;
    using Autofac.Integration.WebApi;

    public static class IoCContainerConfig
    {
        public static void Setup(HttpConfiguration config)
        {
            var builder = new ContainerBuilder();

            builder.RegisterControllers(Assembly.GetExecutingAssembly());

            builder.RegisterType<HttpClient>().SingleInstance();

            //resolver for Web API client
            builder
                .Register(
                    context =>
                    {
                        var endpoint = ConfigurationManager.AppSettings["WebApiEndpoint"];
                        var key = ConfigurationManager.AppSettings["WebApiAuthorizationKey"];
                        return new WebApiClient(context.Resolve<HttpClient>(), new Uri(endpoint), key);
                    });

            var container = builder.Build();
            var resolver = new AutofacDependencyResolver(container);
            DependencyResolver.SetResolver(resolver);

            config.DependencyResolver = new AutofacWebApiDependencyResolver(container);
        }
    }
}