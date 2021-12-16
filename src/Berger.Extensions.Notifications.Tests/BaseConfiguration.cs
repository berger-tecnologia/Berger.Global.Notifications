using System;
using Microsoft.Extensions.Configuration;
using Berger.Extensions.Notifications.Patterns;
using Microsoft.Extensions.DependencyInjection;
using Berger.Extensions.Notifications.Interfaces;

namespace Berger.Extensions.Notifications.Tests
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
            services.AddScoped<INotification, Notification>();

            // Service Building
            var provider =  services.BuildServiceProvider();

            return provider.GetService<INotification>();
        }

        public abstract void Dispose();
    }
}