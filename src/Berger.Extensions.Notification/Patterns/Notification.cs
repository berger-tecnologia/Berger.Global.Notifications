namespace Berger.Extensions.Notification
{
    public partial class Notification : INotification
    {
        public readonly List<NotificationMessage> _notifications;
        public IReadOnlyCollection<NotificationMessage> Messages => _notifications;
        public Notification()
        {
            _notifications = new List<NotificationMessage>();
        }
    }
}