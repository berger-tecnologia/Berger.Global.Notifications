namespace Berger.Global.Notifications.Patterns
{
    public partial class Notification<T> where T : Notifiable
    {
        private readonly T _notifiable;

        public Notification(T notifiable)
        {
            _notifiable = notifiable;
        }
    }
}