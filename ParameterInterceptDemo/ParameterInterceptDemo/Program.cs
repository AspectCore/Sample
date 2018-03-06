using System;
using System.Threading.Tasks;
using AspectCore.DynamicProxy;
using AspectCore.DynamicProxy.Parameters;

namespace ParameterInterceptDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            var generator = new ProxyGeneratorBuilder()
                .Configure(config=>
                {
                    config.EnableParameterAspect(); //启动参数拦截
                })
                .Build();
            var service = generator.CreateInterfaceProxy<IService, Service>();
            service.Foo("lemon");
            Console.ReadKey();
        }
    }

    public interface IService
    {
        void Foo([LogParameter]string value);
    }

    public class Service : IService
    {
        public void Foo(string value)
        {
        }
    }

    public class LogParameterAttribute : ParameterInterceptorAttribute
    {
        public override Task Invoke(ParameterAspectContext context, ParameterAspectDelegate next)
        {
            Console.WriteLine("parameter type : {0} value : {1}", context.Parameter.Type, context.Parameter.Value);
            return next(context);
        }
    }
}
