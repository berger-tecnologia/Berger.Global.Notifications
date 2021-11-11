using FluentValidation;

namespace Berger.Global.Notifications.Patterns
{
    public partial class Notification<T> 
    {
        public void IfInvalidContract(AbstractValidator<T> validator)
        {
            var results = validator.Validate(_model);

            foreach (var error in results.Errors)
                _notifications.Add(new NotificationViewModel(error.PropertyName, error.ErrorMessage, (error.AttemptedValue ?? string.Empty).ToString()));
        }
    }
}