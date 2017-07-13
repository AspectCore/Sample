using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using Autofac;
using AspectCore.Extensions.Autofac;
using AspectCore.Extensions.Configuration;
using Autofac.Integration.Mvc;
using AspectCore.Sample.Net45.Mvc.Services;
using AspectCore.Sample.Net45.Mvc.Interceptors;

namespace AspectCore.Sample.Net45.Mvc
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();

            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);

            RouteConfig.RegisterRoutes(RouteTable.Routes);

            BundleConfig.RegisterBundles(BundleTable.Bundles);

            var builder = new ContainerBuilder();

            builder.RegisterType<CustomeService>().As<ICustomService>().InstancePerDependency();

            //注册Mvc Controller的动态代理
            builder.RegisterControllers(typeof(MvcApplication).Assembly).AsClassProxy();

            //注册AspectCore
            builder.RegisterAspectCore(config=>
            {
                config.InterceptorFactories.AddTyped<ExtensibleActionInterceptorAttribute>();
            });

            var container = builder.Build();

            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
        }
    }
}
