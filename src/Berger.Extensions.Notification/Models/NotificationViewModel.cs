using System;

namespace Berger.Extensions.Notification
{
    public class NotificationViewModel
    {
        #region Constructors
        public NotificationViewModel(string property, string message)
        {
            Message = message;
            Property = property;
        }
        public NotificationViewModel(string property, string message, string value)
        {
            Property = property;
            Message = message;
            Value = value;
        }
        #endregion

        #region Properties
        public Guid ID { get; set; }
        public string Name { get; set; }
        public string Title { get; set; }
        public string Property { get; set; }
        public string Value { get; set; }
        public string Message { get; set; }
        public string Code { get; set; }
        public int Status { get; set; }
        public DateTime Created { get; set; } = DateTime.UtcNow;
        public DateTime? Updated { get; set; }
        public bool Deleted { get; set; }
        #endregion
    }
}