using FluentValidation;

namespace Berger.Global.Notifications.Patterns
{
    public partial class Notification 
    {
        public void IfInvalidContract<T>(T model, AbstractValidator<T> validator)
        {
            var results = validator.Validate(model);

            foreach (var error in results.Errors)
                _notifications.Add(new NotificationViewModel(error.PropertyName, error.ErrorMessage, (error.AttemptedValue ?? string.Empty).ToString()));
        }
    }
}