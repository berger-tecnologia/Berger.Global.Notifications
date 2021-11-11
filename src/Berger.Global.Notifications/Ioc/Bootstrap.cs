using Berger.Global.Notifications.Services;
using Berger.Global.Notifications.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace Berger.Global.Notifications.Ioc
{
    public static class Bootstrap
    {
        public static void Register(this IServiceCollection services)
        {
            services.AddScoped(typeof(INotificationFactory<>), typeof(NotificationFactory<>));
        }

        public static void Register<T>(this IServiceCollection services, T model) 
        {
            services.AddScoped<INotificationFactory<T>>(x => new NotificationFactory<T>(model));
        }
    }
}