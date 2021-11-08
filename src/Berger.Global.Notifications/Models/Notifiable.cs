using System;
using System.Linq;
using FluentValidation;
using System.Collections.Generic;
using Berger.Global.Notifications.Interfaces;

namespace Berger.Global.Notifications
{
    public class Notifiable : INotification
    {
        #region Properties
        private readonly List<Notification> _notifications;
        public Notifiable() 
        {
            _notifications = new List<Notification>();
        }
        public IReadOnlyCollection<Notification> Notifications => _notifications;
        #endregion

        #region Methods
        public List<Notification> Get()
        {
            return _notifications;
        }

        public bool Validate<TModel>(TModel model, AbstractValidator<TModel> validator)
        {
            var results = validator.Validate(model);

            foreach (var error in results.Errors)
            {
                _notifications.Add(new Notification(error.PropertyName, error.ErrorMessage, (error.AttemptedValue ?? string.Empty).ToString()));
            }

            return results.IsValid;
        }

        public void AddNotification(string property, string message)
        {
            _notifications.Add(new Notification(property, message));
        }

        public void AddNotification(string property, string message, params object[] parameters)
        {
            _notifications.Add(new Notification(property, string.Format(message, parameters)));
        }
        public void AddNotification(Notification notification)
        {
            _notifications.Add(notification);
        }
        public void AddNotifications(IReadOnlyCollection<Notification> notifications)
        {
            _notifications.AddRange(notifications);
        }
        public void AddNotifications(params Notifiable[] objects)
        {
            foreach (var notifiable in objects)
                _notifications.AddRange(notifiable.Notifications);
        }
        public void AddNotifications(params IEnumerable<Notifiable>[] objects)
        {
            foreach (var notifiables in objects)
                foreach (var notifiable in notifiables)
                    _notifications.AddRange(notifiable.Notifications);
        }
        public void AddNotifications(IList<Notification> notifications)
        {
            _notifications.AddRange(notifications);
        }
        public void AddNotifications(ICollection<Notification> notifications)
        {
            _notifications.AddRange(notifications);
        }
        public void ClearNotifications()
        {
            _notifications.Clear();
        }
        public void Dispose()
        {
            _notifications.Clear();

            GC.SuppressFinalize(this);
        }
        public bool IsValid() => _notifications == null || _notifications.Count == 0;
        public bool IsInvalid() => _notifications != null && _notifications.Any();
        #endregion
    }
}