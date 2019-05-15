using Autofac;
using Autofac.Integration.Mvc;
using PruebaConcepto.Validations;
using PruebaConcepto.Validations.Implements;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PruebaConcepto.WebApp.App_Start
{
    public static class AutofacConfig
    {
        public static void config()
        {
            var builder = new ContainerBuilder();
            builder.RegisterControllers(typeof(MvcApplication).Assembly);

            builder.RegisterAssemblyTypes(typeof(IValidate<>).Assembly).AsClosedTypesOf(typeof(IValidate<>));


            var container = builder.Build();
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
        }
    }
}