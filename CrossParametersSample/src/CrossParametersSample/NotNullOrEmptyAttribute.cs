using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AspectCore.Abstractions;
using AspectCore.Extensions.CrossParameters;

namespace CrossParametersSample
{
    public class NotNullOrEmptyAttribute : ParameterInterceptorAttribute
    {
        public override Task Invoke(IParameterDescriptor parameter, ParameterAspectContext context, ParameterAspectDelegate next)
        {
            if (parameter.ParameterType == typeof(string))
            {
                if (string.IsNullOrEmpty(parameter.Value?.ToString()))
                {
                    throw new ArgumentException($"Invalid parameter. {parameter.Name} cannot be null or empty");
                }
            }
            return next(parameter, context);
        }
    }
}

