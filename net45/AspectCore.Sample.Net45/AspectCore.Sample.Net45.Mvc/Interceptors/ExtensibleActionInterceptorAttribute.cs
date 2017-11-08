using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using System.Web;
using AspectCore.DynamicProxy;
using AspectCore.DynamicProxy.Parameters;

namespace AspectCore.Sample.Net45.Mvc.Interceptors
{
    public class ExtensibleActionInterceptorAttribute : AbstractInterceptorAttribute
    {
        public override Task Invoke(AspectContext context, AspectDelegate next)
        {
            foreach (var parameter in context.GetParameters())
            {
                if (parameter.ParameterInfo.IsDefined(typeof(FromServiceAttribute)))
                {
                    parameter.Value = context.ServiceProvider.GetService(parameter.Type);
                }
            }
            return next(context);
        }
    }
}