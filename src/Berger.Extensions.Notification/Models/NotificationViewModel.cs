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