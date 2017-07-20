using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CrossParametersSample
{
    public interface IAppLifetime
    {
        Lifetime Lifetime { get; }
    }

    public class AppLifetime : IAppLifetime
    {
        public Lifetime Lifetime
        {
            get
            {
                return Lifetime.Running;
            }
        }
    }

    public enum Lifetime
    {
        Running,
        Stop,
    }
}
