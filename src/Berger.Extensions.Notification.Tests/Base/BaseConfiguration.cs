using System;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Berger.Extensions.Notification.Tests
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