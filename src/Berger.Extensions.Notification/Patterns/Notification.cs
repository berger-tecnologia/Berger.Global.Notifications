using System.Collections.Generic;

namespace Berger.Extensions.Notification
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