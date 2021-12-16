using System.Collections.Generic;
using Berger.Extensions.Notifications.Interfaces;

namespace Berger.Extensions.Notifications.Patterns
{
    public partial class Notification : INotification 
    {
        public readonly List<NotificationViewModel> _notifications;
        public IReadOnlyCollection<NotificationViewModel> Messages => _notifications;
        public Notification()
        {
            _notifications = new List<NotificationViewModel>();
        }
    }
}