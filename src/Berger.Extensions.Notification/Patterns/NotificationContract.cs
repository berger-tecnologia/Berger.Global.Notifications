using FluentValidation;
using Berger.Extensions.Abstractions;

namespace Berger.Extensions.Notification
{
    public partial class Notification : INotification
    {
        public void IfInvalidContract<T>(T model, AbstractValidator<T> validator)
        {
            var results = validator.Validate(model);

            foreach (var error in results.Errors)
                _notifications.Add(new NotificationMessage(error.PropertyName, error.ErrorMessage, (error.AttemptedValue ?? string.Empty).ToString()));
        }
    }
}