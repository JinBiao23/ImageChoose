using Autofac;
using Autofac.Integration.Mvc;
using ImageChoose.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace ImageChoose
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            RegisterAutofac();

            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }

        private void RegisterAutofac()
        {
            var builder = new ContainerBuilder();
            builder.RegisterControllers(Assembly.GetExecutingAssembly());
            builder.RegisterSource(new ViewRegistrationSource());

            builder.RegisterType<UserImageService>().As<IUserImageService>();
            builder.RegisterType<UserImageRepository>().As<IUserImageRepository>();
            var container = builder.Build();

            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));

            //builder.RegisterType<IUserImageService,UserImageService>
            
        }
    }
}
