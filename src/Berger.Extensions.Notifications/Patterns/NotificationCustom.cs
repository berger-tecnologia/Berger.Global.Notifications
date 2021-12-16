namespace Berger.Extensions.Notifications.Patterns
{
    public partial class Notification 
    {
        public void CustomCreate(string property, string message)
        {
            AddNotification(property, message);
        }
    }
}