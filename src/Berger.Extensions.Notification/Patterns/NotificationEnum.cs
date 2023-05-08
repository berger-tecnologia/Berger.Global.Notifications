using System;
using System.Linq.Expressions;
using Berger.Extensions.Notification.Resources;

namespace Berger.Extensions.Notification
{
    public partial class Notification 
    {
        /// <summary>
        /// Dado um Enum, adiciona notificação caso seu valor não esteja definido dentro do próprio Enum
        /// </summary>
        /// <param name="selector">Nome da propriedade que deseja testar</param>
        /// <param name="message">Mensagem de erro (Opcional)</param>
        /// <returns>Dado um Enum, adiciona notificação caso seu valor não esteja definido dentro do próprio Enum</returns>
        public void IfEnumInvalid<T>(T model, Expression<Func<T, System.Enum>> selector, string message = "")
        {
            var val = selector.Compile().Invoke(model);
            var name = string.Empty;

            var op = ((UnaryExpression)selector.Body).Operand;
            name = ((MemberExpression)op).Member.Name;

            if (!val.IsEnumValid())
                AddNotification(name, string.IsNullOrEmpty(message) ? Message.IfEnumInvalid.ToFormat(name) : message);
        }

        /// <summary>
        /// Dado um Enum, adiciona notificação caso seu valor não esteja definido dentro do próprio Enum
        /// </summary>
        /// <param name="val">Valor informado</param>
        /// <param name="objectName">Nome da propriedade ou objeto que representa a informação</param>
        /// <param name="message">Mensagem de erro (Opcional)</param>
        /// <returns>Dado um Enum, adiciona notificação caso seu valor não esteja definido dentro do próprio Enum</returns>
        public void IfEnumInvalid(Enum val, string objectName, string message = "")
        {
            if (!val.IsEnumValid())
                AddNotification(objectName, string.IsNullOrEmpty(message) ? Message.IfEnumInvalid.ToFormat(objectName) : message);
        }
    }
}