using AspectCore.Extensions.CrossParameters;
using AspectCore.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection;
using NotNullOrEmptySample.Services;
using System;
using System.Threading.Tasks;
using Xunit;

namespace NotNullOrEmptySample.Test
{
    public class NotNullOrEmptyAttributeTest
    {
        private IAppService _appService;
        public NotNullOrEmptyAttributeTest()
        {
            var provider = GetServiceProvider();
            _appService = provider.GetService<IAppService>();
        }

        [Fact]
        public void StringTest()
        {
            Assert.Throws<AggregateException>(() => _appService.ValidateNotNullOrEmpty<string>(null));
            Assert.Throws<AggregateException>(() => _appService.ValidateNotNullOrEmpty(string.Empty));
            _appService.ValidateNotNullOrEmpty("str");
        }

        [Fact]
        public void ObjectTest()
        {
            Assert.Throws<AggregateException>(() => _appService.ValidateNotNullOrEmpty<object>(null));
            _appService.ValidateNotNullOrEmpty(new object());
        }

        [Fact]
        public void NullableStructTest()
        {
            int? i = null;
            Assert.Throws<AggregateException>(() => _appService.ValidateNotNullOrEmpty(i));
            i = 0;
            _appService.ValidateNotNullOrEmpty(i);
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
    }
}
