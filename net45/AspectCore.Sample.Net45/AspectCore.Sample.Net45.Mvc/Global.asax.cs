using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using AspectCore.Configuration;
using AspectCore.Extensions.Autofac;
using AspectCore.Sample.Net45.Mvc.Interceptors;
using AspectCore.Sample.Net45.Mvc.Services;
using Autofac;
using Autofac.Integration.Mvc;

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
            builder.RegisterControllers(typeof(MvcApplication).Assembly);

            //注册AspectCore
            builder.RegisterDynamicProxy(config=>
            {
                config.Interceptors.AddTyped<ExtensibleActionInterceptorAttribute>(Predicates.ForService("*Controller"));
            });

            var container = builder.Build();

            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
        }
    }
}
