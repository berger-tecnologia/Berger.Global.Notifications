namespace Berger.Global.Notifications.Patterns
{
    public partial class Notification<T> 
    {
        public void CustomCreate(string property, string message)
        {
            AddNotification(property, message);
        }
    }
}