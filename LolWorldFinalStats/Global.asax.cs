using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using Autofac;
using Autofac.Features.ResolveAnything;
using Autofac.Integration.Mvc;
using FluentValidation;
using LolWorldFinalStats.Configuration;
using LolWorldFinalStats.Models;
using LolWorldFinalStats.Validation;
using LolWorldFinalStatWeb.Data;
using Microsoft.AspNet.Identity;

namespace LolWorldFinalStats
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            GlobalConfiguration.Configure(WebApiConfig.Register);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            RegisterAutoFac();

            RegisterAutoMapper();
        }

        private void RegisterAutoMapper()
        {
            AutoMapper.Mapper.CreateMap<User, ApplicationUser>();
            AutoMapper.Mapper.CreateMap<ApplicationUser, User>();
        }

        private void RegisterAutoFac()
        {
            var builder = new ContainerBuilder();

            builder.RegisterControllers(Assembly.GetExecutingAssembly());

            builder.RegisterType(typeof(NHibernateRespository))
                .As(typeof(IRepository));

            builder.RegisterType(typeof(NHibernateUserStore<ApplicationUser>))
             .As(typeof(IUserStore<ApplicationUser>));

            builder.RegisterAssemblyTypes(typeof(ChampionValidator).Assembly)
              .AsClosedTypesOf(typeof(IValidator<>))
              .AsImplementedInterfaces();

            builder.RegisterSource(new AnyConcreteTypeNotAlreadyRegisteredSource());

            var container = builder.Build();

            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
        }
    }
}
