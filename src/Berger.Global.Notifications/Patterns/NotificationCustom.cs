namespace Berger.Global.Notifications.Patterns
{
    public partial class Notification<T> where T : Notifiable
    {
        public Notification<T> CustomCreate(string property, string message)
        {
            _notifiable.AddNotification(property, message);

            return this;
        }
    }
}