using System.Collections.Generic;
using Berger.Global.Notifications.Interfaces;

namespace Berger.Global.Notifications.Patterns
{
    public partial class Notification<T> : INotification<T> 
    {
        public readonly List<NotificationViewModel> _notifications;
        public IReadOnlyCollection<NotificationViewModel> Messages => _notifications;
        public Notification()
        {
            _notifications = new List<NotificationViewModel>();
        }
        public Notification(T model)
        {
            _notifications = new List<NotificationViewModel>();
        }
    }
}