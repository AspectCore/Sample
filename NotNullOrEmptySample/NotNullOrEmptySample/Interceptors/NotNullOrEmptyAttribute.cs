using AspectCore.Abstractions;
using AspectCore.Extensions.CrossParameters;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace NotNullOrEmptySample.Interceptors
{
    public class NotNullOrEmptyAttribute : ParameterInterceptorAttribute
    {
        public override Task Invoke(IParameterDescriptor parameter, ParameterAspectContext context, ParameterAspectDelegate next)
        {
            if (string.IsNullOrEmpty(parameter.Value?.ToString()))
            {
                throw new ArgumentNullException($"Invalid parameter. {parameter.Name} cannot be null or empty");
            }
            return next(parameter, context);
        }
    }
}
