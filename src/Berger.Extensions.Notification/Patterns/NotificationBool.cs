using System;
using System.Linq.Expressions;
using Berger.Extensions.Notification.Resources;

namespace Berger.Extensions.Notification
{
    public partial class Notification 
    {
        /// <summary>
        /// Dada uma bool, adicione uma notificação se for verdadeira
        /// </summary>
        /// <param name="selector">Nome da propriedade que deseja testar</param>
        /// <param name="message">Mensagem de erro (Opcional)</param>
        /// <returns>Dada uma bool, adicione uma notificação se for verdadeira</returns>
        public void IfTrue<T>(T model, Expression<Func<T, bool>> selector, string message = "")
        {
            var data = selector.Compile().Invoke(model);
            var name = ((MemberExpression)selector.Body).Member.Name;

            if (data == true)
                AddNotification(name, string.IsNullOrEmpty(message) ? Message.IfTrue.ToFormat(name) : message);
        }

        /// <summary>
        /// Dada uma bool, adicione uma notificação se for falso
        /// </summary>
        /// <param name="val">Nome da propriedade que deseja testar</param>
        /// <param name="message">Mensagem de erro (Opcional)</param>
        /// <returns>Dada uma bool, adicione uma notificação se for falso</returns>
        public void IfFalse<T>(T model, Expression<Func<T, bool>> selector, string message = "")
        {
            var data = selector.Compile().Invoke(model);
            var name = ((MemberExpression)selector.Body).Member.Name;

            if (data == false)
                AddNotification(name, string.IsNullOrEmpty(message) ? Message.IfFalse.ToFormat(name) : message);
        }

        /// <summary>
        /// Dada uma bool, adicione uma notificação se for verdadeira
        /// </summary>
        /// <param name="val">Nome da propriedade que deseja testar</param>
        /// <param name="objectName">Nome da propriedade ou objeto que representa a informação</param>
        /// <param name="message">Mensagem de erro (Opcional)</param>
        /// <returns>Dada uma bool, adicione uma notificação se for verdadeira</returns>
        public void IfTrue(bool val, string objectName, string message = "")
        {
            if (val == true)
                AddNotification(objectName, string.IsNullOrEmpty(message) ? Message.IfTrue.ToFormat(objectName) : message);
        }

        /// <summary>
        /// Dada uma bool, adicione uma notificação se for falso
        /// </summary>
        /// <param name="val">Nome da propriedade que deseja testar</param>
        /// <param name="objectName">Nome da propriedade ou objeto que representa a informação</param>
        /// <param name="message">Mensagem de erro (Opcional)</param>
        /// <returns>Dada uma bool, adicione uma notificação se for falso</returns>

        public void IfFalse(bool val, string objectName, string message = "")
        {
            if (val == false)
                AddNotification(objectName, string.IsNullOrEmpty(message) ? Message.IfFalse.ToFormat(objectName) : message);
        }
    }
}