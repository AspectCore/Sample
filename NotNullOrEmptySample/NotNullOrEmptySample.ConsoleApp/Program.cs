using AspectCore.Extensions.CrossParameters;
using AspectCore.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection;
using NotNullOrEmptySample.Services;
using System;
using System.Collections.Generic;

namespace NotNullOrEmptySample.ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            IServiceProvider serviceProvider = GetServiceProvider();
            IAppService appService = serviceProvider.GetService<IAppService>();
            var checkResults = CheckNotNullOrEmpty(appService);
            checkResults.ForEach(result => Console.WriteLine(result));
            Console.ReadLine();
        }

        static IServiceProvider GetServiceProvider()
        {
            IServiceCollection services = new ServiceCollection();
            services.AddAspectCore(options =>
            {
                options.AddParameterIntercept();
            });
            services.AddTransient<IAppService, AppService>();

            return services.BuildAspectCoreServiceProvider();
        }

        static List<string> CheckNotNullOrEmpty(IAppService appService)
        {
            List<string> results = new List<string>();

            results.Add(appService.CheckString(null));
            results.Add(appService.CheckString(string.Empty));
            results.Add(appService.CheckString("str"));

            results.Add(appService.CheckObject(null));
            results.Add(appService.CheckObject(new object()));

            int? nullableInteger = null;
            results.Add(appService.CheckNullalble(nullableInteger));
            nullableInteger = 1;
            results.Add(appService.CheckNullalble(nullableInteger));
            return results;
        }
    }
}