using Berger.Extensions.Abstractions;

namespace Berger.Extensions.Notification
{
    public partial class Notification : INotification
    {
        public void CustomCreate(string property, string message)
        {
            AddNotification(property, message);
        }
    }
}