using System;
using Berger.Global.Notifications.Ioc;
using Microsoft.Extensions.Configuration;
using Berger.Global.Notifications.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace Berger.Global.Notifications.Tests
{
    public abstract class BaseConfiguration : IDisposable
    {
        public static IConfiguration Configuration { get; }

        protected void Initialize()
        {
        }

        public INotification Create() 
        {
            // Service Configuration
            IServiceCollection services = new ServiceCollection();

            // Service Dependencies
            services.Register();

            // Service Building
            var provider =  services.BuildServiceProvider();

            return provider.GetService<INotification>();
        }

        public abstract void Dispose();
    }
}