using System;
using System.Linq.Expressions;
using Berger.Global.Notifications.Resources;
using Berger.Global.Notifications.Extensions;

namespace Berger.Global.Notifications.Patterns
{
    public partial class Notification<T> where T : Notifiable
    {
        /// <summary>
        /// Dada um objeto, adicione uma notificação se for igual null
        /// </summary>
        /// <param name="selector">Nome da propriedade que deseja testar</param>
        /// <param name="val">Value to be compared</param>
        /// <param name="message">Mensagem de erro (Opcional)</param>
        /// <returns>Dada um objeto, adicione uma notificação se for igual null</returns>
        public Notification<T> IfNull(Expression<Func<T, object>> selector, string message = "")
        {
            var val = selector.Compile().Invoke(_notifiable);
            var name = ((MemberExpression)selector.Body).Member.Name;

            if (val == null)
                _notifiable.AddNotification(name, string.IsNullOrEmpty(message) ? Message.IfNull.ToFormat(name) : message);

            return this;
        }
        /// <summary>
        /// Dada um objeto, adicione uma notificação se não for igual null
        /// </summary>
        /// <param name="selector">Nome da propriedade que deseja testar</param>
        /// <param name="val">Value to be compared</param>
        /// <param name="message">Mensagem de erro (Opcional)</param>
        /// <returns>Dada um objeto, adicione uma notificação se não for igual null</returns>
        public Notification<T> IfNotNull(Expression<Func<T, object>> selector, string message = "")
        {
            var val = selector.Compile().Invoke(_notifiable);
            var name = ((MemberExpression)selector.Body).Member.Name;

            if (val != null)
                _notifiable.AddNotification(name, string.IsNullOrEmpty(message) ? Message.IfNotNull.ToFormat(name) : message);

            return this;
        }

        /// <summary>
        /// Dada um objeto, adicione uma notificação se for igual null
        /// </summary>
        /// <param name="val">Valor informado</param>
        /// <param name="objectName">Nome da propriedade ou objeto que representa a informação</param>
        /// <param name="message">Mensagem de erro (Opcional)</param>
        /// <returns>Dada um objeto, adicione uma notificação se for igual null</returns>
        public Notification<T> IfNull(object val, string objectName, string message = "")
        {
            if (val == null)
                _notifiable.AddNotification(objectName, string.IsNullOrEmpty(message) ? Message.IfNull.ToFormat(objectName) : message);

            return this;
        }
        /// <summary>
        /// Dada um objeto, adicione uma notificação se não for igual null
        /// </summary>
        /// <param name="val">Valor informado</param>
        /// <param name="objectName">Nome da propriedade ou objeto que representa a informação</param>
        /// <param name="message">Mensagem de erro (Opcional)</param>
        /// <returns>Dada um objeto, adicione uma notificação se não for igual null</returns>
        public Notification<T> IfNotNull(object val, string objectName, string message = "")
        {
            if (val != null)
                _notifiable.AddNotification(objectName, string.IsNullOrEmpty(message) ? Message.IfNotNull.ToFormat(objectName) : message);

            return this;
        }
    }
}