using System.Collections.Generic;

namespace Berger.Global.Notifications.Interfaces
{
    public interface INotification
    {
        List<NotificationBody> Get();
    }
}