namespace Berger.Global.Notifications.Patterns
{
    public partial class AddNotifications<T> where T : Notifiable
    {
        private readonly T _notifiableObject;

        public AddNotifications(T notifiableObject)
        {
            _notifiableObject = notifiableObject;
        }
    }
}