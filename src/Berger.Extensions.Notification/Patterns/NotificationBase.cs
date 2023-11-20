using Berger.Extensions.Abstractions;

namespace Berger.Extensions.Notification
{
    public partial class Notification : INotification
    {
        #region Methods
        public int Count() => _notifications.Count();
        public bool HasNotifications() => _notifications.Any();
        public bool IsValid() => _notifications == null || _notifications.Count == 0;
        public bool IsInvalid() => _notifications != null && _notifications.Any();
        public List<IMessage<NotificationType>> Get() => _notifications;
        public void AddNotification(string property, string message)
        {
            _notifications.Add(new NotificationMessage(property, message));
        }
        public void AddNotification(string property, string message, params object[] parameters)
        {
            _notifications.Add(new NotificationMessage(property, string.Format(message, parameters)));
        }
        public void AddNotification(IMessage<NotificationType> notification)
        {
            _notifications.Add(notification);
        }
        public void AddNotifications(IReadOnlyCollection<IMessage<NotificationType>> notifications)
        {
            _notifications.AddRange(notifications);
        }
        public void AddNotifications(IList<IMessage<NotificationType>> notifications)
        {
            _notifications.AddRange(notifications);
        }
        public void AddNotifications(ICollection<IMessage<NotificationType>> notifications)
        {
            _notifications.AddRange(notifications);
        }
        public void ClearNotifications()
        {
            _notifications.Clear();
        }
        public void Dispose()
        {
            _notifications.Clear();

            GC.SuppressFinalize(this);
        }
        #endregion
    }
}