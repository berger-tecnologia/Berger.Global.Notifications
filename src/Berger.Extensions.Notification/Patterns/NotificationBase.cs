namespace Berger.Extensions.Notification
{
    public partial class Notification 
    {
        #region Methods
        public int Count() => _notifications.Count();
        public bool HasNotifications() => _notifications.Any();
        public bool IsValid() => _notifications == null || _notifications.Count == 0;
        public bool IsInvalid() => _notifications != null && _notifications.Any();
        public List<NotificationViewModel> Get() => _notifications;
        public void AddNotification(string property, string message)
        {
            _notifications.Add(new NotificationViewModel(property, message));
        }
        public void AddNotification(string property, string message, params object[] parameters)
        {
            _notifications.Add(new NotificationViewModel(property, string.Format(message, parameters)));
        }
        public void AddNotification(NotificationViewModel notification)
        {
            _notifications.Add(notification);
        }
        public void AddNotifications(IReadOnlyCollection<NotificationViewModel> notifications)
        {
            _notifications.AddRange(notifications);
        }
        public void AddNotifications(IList<NotificationViewModel> notifications)
        {
            _notifications.AddRange(notifications);
        }
        public void AddNotifications(ICollection<NotificationViewModel> notifications)
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