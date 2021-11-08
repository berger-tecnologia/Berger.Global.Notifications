using System;
using System.Linq;
using System.Collections;
using System.Linq.Expressions;
using System.Collections.Generic;
using Berger.Global.Notifications.Resources;
using Berger.Global.Notifications.Extensions;

namespace Berger.Global.Notifications.Patterns
{
    public partial class Notification<T> where T : Notifiable
    {
        /// <summary>
        /// Dada uma coleção, adicione uma notificação se for nula
        /// </summary>
        /// <param name="selector">Nome da propriedade que deseja testar</param>
        /// <param name="message">Mensagem de erro (Opcional)</param>
        /// <returns>Dada uma coleção, adicione uma notificação se for nula</returns>
        public Notification<T> IfCollectionIsNull(Expression<Func<T, IEnumerable>> selector, string message = "")
        {
            IEnumerable colectionValue = selector.Compile().Invoke(_notifiable);
            var name = ((MemberExpression)selector.Body).Member.Name;


            if (colectionValue == null)
            {
                _notifiable.AddNotification(name, string.IsNullOrEmpty(message) ? Message.IfCollectionIsNull.ToFormat(name) : message);
            }

            return this;
        }

        /// <summary>
        /// Dada uma coleção, adicione uma notificação se for nula ou não tenha itens
        /// </summary>
        /// <param name="selector">Nome da propriedade que deseja testar</param>
        /// <param name="message">Mensagem de erro (Opcional)</param>
        /// <returns>Dada uma coleção, adicione uma notificação se for nula ou não tenha itens</returns>
        public Notification<T> IfCollectionIsNullOrEmpty(Expression<Func<T, IEnumerable<T>>> selector, string message = "")
        {
            IEnumerable<T> colectionValue = selector.Compile().Invoke(_notifiable);
            var name = ((MemberExpression)selector.Body).Member.Name;


            if (colectionValue == null || colectionValue.ToList().Count <= 0)
            {
                _notifiable.AddNotification(name, string.IsNullOrEmpty(message) ? Message.IfCollectionIsNullOrEmpty.ToFormat(name) : message);
            }

            return this;
        }

        /// <summary>
        /// Dada uma coleção, adicione uma notificação se for nula
        /// </summary>
        /// <param name="val">Nome da propriedade que deseja testar</param>
        /// <param name="objectName">Nome da propriedade ou objeto que representa a informação</param>
        /// <param name="message">Mensagem de erro (Opcional)</param>
        /// <returns>Dada uma coleção, adicione uma notificação se for nula</returns>
        public Notification<T> IfCollectionIsNull(IEnumerable val, string objectName, string message = "")
        {
            if (val == null)
            {
                _notifiable.AddNotification(objectName, string.IsNullOrEmpty(message) ? Message.IfCollectionIsNull.ToFormat(objectName) : message);
            }

            return this;
        }

        /// <summary>
        /// Dada uma coleção, adicione uma notificação se for nula ou não tenha itens
        /// </summary>
        /// <param name="val">Nome da propriedade que deseja testar</param>
        /// <param name="objectName">Nome da propriedade ou objeto que representa a informação</param>
        /// <param name="message">Mensagem de erro (Opcional)</param>
        /// <returns>Dada uma coleção, adicione uma notificação se for nula ou não tenha itens</returns>
        public Notification<T> IfCollectionIsNullOrEmpty(IEnumerable<T> val, string objectName, string message = "")
        {
            if (val == null || val.ToList().Count <= 0)
            {
                _notifiable.AddNotification(objectName, string.IsNullOrEmpty(message) ? Message.IfCollectionIsNullOrEmpty.ToFormat(objectName) : message);
            }

            return this;
        }
    }
}