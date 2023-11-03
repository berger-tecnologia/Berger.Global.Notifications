using Berger.Extensions.Abstractions;

namespace Berger.Extensions.Notification
{
    public partial class Notification : INotification
    {
        public readonly List<INotificationMessage> _notifications;
        public IReadOnlyCollection<INotificationMessage> Messages => _notifications;
        public Notification()
        {
            _notifications = new List<INotificationMessage>();
        }
    }
}