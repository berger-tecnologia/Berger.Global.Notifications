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

        public INotificationFactory<T> CreateFactory<T>(T model) 
        {
            // Service Configuration
            IServiceCollection services = new ServiceCollection();

            // Service Dependencies
            services.Register(model);

            // Service Building
            var provider =  services.BuildServiceProvider();

            return provider.GetService<INotificationFactory<T>>();
        }

        public abstract void Dispose();
    }
}