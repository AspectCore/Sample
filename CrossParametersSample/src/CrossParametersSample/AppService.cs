using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AspectCore.Abstractions;
using AspectCore.Extensions.CrossParameters;

namespace CrossParametersSample
{
    public interface IAppService
    {
        void Run([NotNull]string[] args);

        void Stop([NotNullOrEmpty]string message);

        Lifetime GetLifetime([Inject]IAppLifetime lifetime = null);
    }

    public class AppService : IAppService
    {
        public Lifetime GetLifetime(IAppLifetime lifetime = null)
        {
            return lifetime.Lifetime;
        }

        public void Run([NotNull]string[] args)
        {
        }

        public void Stop(string message)
        {
        }
    }
}
