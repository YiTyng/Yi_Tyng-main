namespace Passport.WebApi
{
    using System;
    using System.Configuration;
    using System.Reflection;
    using System.Web.Http;
    using Autofac;
    using Autofac.Integration.WebApi;
    using AutoMapper;
    using Models;
    using Passport.BusinessService;

    public static class IoCContainerConfig
    {
        public static void Setup(HttpConfiguration config)
        {
            var builder = new ContainerBuilder();

            builder.RegisterApiControllers(Assembly.GetExecutingAssembly());

            builder
                .Register(
                    context =>
                    {
                        var keys = ConfigurationManager.AppSettings["AcceptableKeys"].Split(new[] { ";" }, StringSplitOptions.RemoveEmptyEntries);
                        return new AuthorizationHandler(keys);
                    })
                .SingleInstance();

            builder
                .RegisterType<PassportValidator>()
                .SingleInstance();

            builder
                .Register(
                    context =>
                    {
                        var maperConfig = new MapperConfiguration(
                                            cfg =>
                                            {
                                                cfg.CreateMap<PassportInput, PassportData>();
                                                cfg.CreateMap<ValidationResult, ValidationOutput>();
                                            });

                        return maperConfig.CreateMapper();
                    })
                .SingleInstance();

            config.DependencyResolver = new AutofacWebApiDependencyResolver(builder.Build());
        }
    }
}