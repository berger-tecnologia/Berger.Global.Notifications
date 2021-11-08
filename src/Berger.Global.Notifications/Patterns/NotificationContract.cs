using FluentValidation;

namespace Berger.Global.Notifications.Patterns
{
    public partial class Notification<T> where T : Notifiable
    {
        public Notification<T> IfInvalidContract(T model, AbstractValidator<T> validator)
        {
            _notifiable.AddNotification<T>(model, validator);

            return this;
        }
    }
}