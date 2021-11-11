using Berger.Global.Notifications.Patterns;
using Berger.Global.Notifications.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace Berger.Global.Notifications.Ioc
{
    public static class Bootstrap
    {
        public static void Register(this IServiceCollection services)
        {
            services.AddScoped<INotification, Notification>();
        }
    }
}