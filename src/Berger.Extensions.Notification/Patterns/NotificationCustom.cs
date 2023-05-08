namespace Berger.Extensions.Notification
{
    public partial class Notification 
    {
        public void CustomCreate(string property, string message)
        {
            AddNotification(property, message);
        }
    }
}