using Berger.Global.Notifications.Patterns;
using Berger.Global.Notifications.Interfaces;

namespace Berger.Global.Notifications.Services
{
    public class NotificationFactory<T> : Notification<T>, INotificationFactory<T> 
    {
        //public NotificationFactory(T model) : base(model) { }
        public NotificationFactory() : base() { }
    }
}