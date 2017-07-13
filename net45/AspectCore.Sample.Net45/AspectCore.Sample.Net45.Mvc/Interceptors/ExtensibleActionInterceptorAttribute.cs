using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using System.Web;
using AspectCore.Abstractions;

namespace AspectCore.Sample.Net45.Mvc.Interceptors
{
    public class ExtensibleActionInterceptorAttribute : InterceptorAttribute
    {
        public override Task Invoke(AspectContext context, AspectDelegate next)
        {
            foreach (var parameter in context.Parameters)
            {
                if (parameter.ParameterInfo.IsDefined(typeof(FromServiceAttribute)))
                {
                    parameter.Value = context.ServiceProvider.GetService(parameter.ParameterType);
                }
            }
            return next(context);
        }
    }
}