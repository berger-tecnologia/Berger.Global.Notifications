using Berger.Extensions.Abstractions;

namespace Berger.Extensions.Notification
{
    public class NotificationMessage : INotificationMessage
    {
        #region Constructors
        public NotificationMessage(string property, string message)
        {
            Message = message;
            Property = property;
        }
        public NotificationMessage(string property, string message, string value)
        {
            Value = value;
            Message = message;
            Property = property;
        }
        #endregion

        #region Properties
        public Guid ID { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Title { get; set; } = string.Empty;
        public string Property { get; set; } = string.Empty;
        public string Value { get; set; } = string.Empty;
        public string Message { get; set; } = string.Empty;
        public string Code { get; set; } = string.Empty;
        public int Status { get; set; }
        public DateTime Created { get; set; } = DateTime.UtcNow;
        public DateTime? Updated { get; set; }
        public bool Deleted { get; set; }
        #endregion
    }
}