using System;
using System.Linq.Expressions;
using Berger.Global.Notifications.Resources;
using Berger.Global.Notifications.Extensions;

namespace Berger.Global.Notifications.Patterns
{
    public partial class Notification<T> where T : Notifiable
    {
        /// <summary>
        /// Dada uma bool, adicione uma notificação se for verdadeira
        /// </summary>
        /// <param name="selector">Nome da propriedade que deseja testar</param>
        /// <param name="message">Mensagem de erro (Opcional)</param>
        /// <returns>Dada uma bool, adicione uma notificação se for verdadeira</returns>
        public Notification<T> IfTrue(Expression<Func<T, bool>> selector, string message = "")
        {
            var data = selector.Compile().Invoke(_notifiable);
            var name = ((MemberExpression)selector.Body).Member.Name;

            if (data == true)
                _notifiable.AddNotification(name, string.IsNullOrEmpty(message) ? Message.IfTrue.ToFormat(name) : message);

            return this;
        }

        /// <summary>
        /// Dada uma bool, adicione uma notificação se for falso
        /// </summary>
        /// <param name="val">Nome da propriedade que deseja testar</param>
        /// <param name="message">Mensagem de erro (Opcional)</param>
        /// <returns>Dada uma bool, adicione uma notificação se for falso</returns>
        public Notification<T> IfFalse(Expression<Func<T, bool>> selector, string message = "")
        {
            var data = selector.Compile().Invoke(_notifiable);
            var name = ((MemberExpression)selector.Body).Member.Name;

            if (data == false)
                _notifiable.AddNotification(name, string.IsNullOrEmpty(message) ? Message.IfFalse.ToFormat(name) : message);

            return this;
        }

        /// <summary>
        /// Dada uma bool, adicione uma notificação se for verdadeira
        /// </summary>
        /// <param name="val">Nome da propriedade que deseja testar</param>
        /// <param name="objectName">Nome da propriedade ou objeto que representa a informação</param>
        /// <param name="message">Mensagem de erro (Opcional)</param>
        /// <returns>Dada uma bool, adicione uma notificação se for verdadeira</returns>
        public Notification<T> IfTrue(bool val, string objectName, string message = "")
        {
            if (val == true)
                _notifiable.AddNotification(objectName, string.IsNullOrEmpty(message) ? Message.IfTrue.ToFormat(objectName) : message);

            return this;
        }

        /// <summary>
        /// Dada uma bool, adicione uma notificação se for falso
        /// </summary>
        /// <param name="val">Nome da propriedade que deseja testar</param>
        /// <param name="objectName">Nome da propriedade ou objeto que representa a informação</param>
        /// <param name="message">Mensagem de erro (Opcional)</param>
        /// <returns>Dada uma bool, adicione uma notificação se for falso</returns>
        
        public Notification<T> IfFalse(bool val, string objectName, string message = "")
        {
            if (val == false)
                _notifiable.AddNotification(objectName, string.IsNullOrEmpty(message) ? Message.IfFalse.ToFormat(objectName) : message);

            return this;
        }
    }
}