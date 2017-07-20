using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AspectCore.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection;
using AspectCore.Extensions.CrossParameters;

namespace CrossParametersSample
{
    public class Program
    {
        public static void Main(string[] args)
        {
            IServiceCollection services = new ServiceCollection();
            services.AddAspectCore(options =>
            {
                options.AddMethodInject();
                options.AddParameterIntercept();
            });
            services.AddTransient<IAppService, AppService>();
            services.AddTransient<IAppLifetime, AppLifetime>();

            IServiceProvider aspectCoreServiceProvider = services.BuildAspectCoreServiceProvider();

            IAppService appService = aspectCoreServiceProvider.GetService<IAppService>();
            appService.GetLifetime();
            appService.Stop("");
            Console.ReadKey();
        }
    }
}
