using NotNullOrEmptySample.Interceptors;
using System;
using System.Collections.Generic;
using System.Text;

namespace NotNullOrEmptySample.Services
{
    public interface IAppService
    {
        void ValidateNotNullOrEmpty<TType>([NotNullOrEmpty]TType input);
    }


    public class AppService : IAppService
    {
        public void ValidateNotNullOrEmpty<TType>([NotNullOrEmpty]TType input)
        {
            return;
        }
    }
}
