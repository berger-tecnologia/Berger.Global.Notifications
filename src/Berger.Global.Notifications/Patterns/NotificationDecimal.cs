using System;
using System.Linq.Expressions;
using Berger.Global.Notifications.Resources;
using Berger.Global.Notifications.Extensions;

namespace Berger.Global.Notifications.Patterns
{
    public partial class Notification<T> where T : Notifiable
    {
        /// <summary>
        /// Dado um int, adicione uma notificação se seu valor for menor que o parâmetro min
        /// </summary>
        /// <param name="selector">Nome da propriedade que deseja testar</param>
        /// <param name="min">Minimum Length</param>
        /// <param name="message">Mensagem de erro (Opcional)</param>
        /// <returns>Dado um int, adicione uma notificação se seu valor for menor que o parâmetro min</returns>
        public Notification<T> IfLowerThan(Expression<Func<T, decimal>> selector, decimal min, string message = "")
        {
            var val = selector.Compile().Invoke(_notifiable);
            var name = ((MemberExpression)selector.Body).Member.Name;

            if (val < min)
                _notifiable.AddNotification(name, string.IsNullOrEmpty(message) ? Message.IfLowerThan.ToFormat(name, min) : message);

            return this;
        }

        /// <summary>
        /// Dada um decimal, adicione uma notificação se seu valor for maior que o parâmetro max
        /// </summary>
        /// <param name="selector">Nome da propriedade que deseja testar</param>
        /// <param name="min">Minimum Length</param>
        /// <param name="message">Mensagem de erro (Opcional)</param>
        /// <returns>Dada um decimal, adicione uma notificação se seu valor for maior que o parâmetro max</returns>
        public Notification<T> IfGreaterThan(Expression<Func<T, decimal>> selector, decimal max, string message = "")
        {
            var val = selector.Compile().Invoke(_notifiable);
            var name = ((MemberExpression)selector.Body).Member.Name;

            if (val > max)
                _notifiable.AddNotification(name, string.IsNullOrEmpty(message) ? Message.IfGreaterThan.ToFormat(name, max) : message);

            return this;
        }

        /// <summary>
        /// Dado um int, adicione uma notificação se for maior ou igual ao parametro passado
        /// </summary>
        /// <param name="selector">Nome da propriedade que deseja testar</param>
        /// <param name="number">Number to be compared</param>
        /// <param name="message">Mensagem de erro (Opcional)</param>
        /// <returns>Dado um int, adicione uma notificação se for maior ou igual ao parametro passado</returns>
        public Notification<T> IfGreaterOrEqualsThan(Expression<Func<T, decimal>> selector, decimal number, string message = "")
        {
            var val = selector.Compile().Invoke(_notifiable);
            var name = ((MemberExpression)selector.Body).Member.Name;

            if (val >= number)
                _notifiable.AddNotification(name, string.IsNullOrEmpty(message) ? Message.IfGreaterOrEqualsThan.ToFormat(name, number) : message);

            return this;
        }

        /// <summary>
        /// Dado um int, adicione uma notificação se for menor ou igual ao parametro passado
        /// </summary>
        /// <param name="selector">Nome da propriedade que deseja testar</param>
        /// <param name="number">Number to be compared</param>
        /// <param name="message">Mensagem de erro (Opcional)</param>
        /// <returns>Dado um int, adicione uma notificação se for menor ou igual ao parametro passado</returns>
        public Notification<T> IfLowerOrEqualsThan(Expression<Func<T, decimal>> selector, decimal number, string message = "")
        {
            var val = selector.Compile().Invoke(_notifiable);
            var name = ((MemberExpression)selector.Body).Member.Name;

            if (val <= number)
                _notifiable.AddNotification(name, string.IsNullOrEmpty(message) ? Message.IfLowerOrEqualsThan.ToFormat(name, number) : message);

            return this;
        }

        /// <summary>
        /// Dado um int, adicione uma notificação se não estiver entre alguns dois valores
        /// </summary>
        /// <param name="selector">Nome da propriedade que deseja testar</param>
        /// <param name="a">Lower value</param>
        /// <param name="b">Higher value</param>
        /// <param name="message">Mensagem de erro (Opcional)</param>
        /// <returns>Dado um int, adicione uma notificação se não estiver entre alguns dois valores</returns>
        public Notification<T> IfNotRange(Expression<Func<T, decimal>> selector, decimal a, decimal b, string message = "")
        {
            var val = selector.Compile().Invoke(_notifiable);
            var name = ((MemberExpression)selector.Body).Member.Name;

            if (val < a || val > b)
                _notifiable.AddNotification(name, string.IsNullOrEmpty(message) ? Message.IfNotRange.ToFormat(name, a, b) : message);

            return this;
        }

        /// <summary>
        /// Dado um int, adicione uma notificação se estiver entre alguns dois valores
        /// </summary>
        /// <param name="selector">Nome da propriedade que deseja testar</param>
        /// <param name="a">Lower value</param>
        /// <param name="b">Higher value</param>
        /// <param name="message">Mensagem de erro (Opcional)</param>
        /// <returns>Dado um int, adicione uma notificação se estiver entre alguns dois valores</returns>
        public Notification<T> IfRange(Expression<Func<T, decimal>> selector, decimal a, decimal b, string message = "")
        {
            var val = selector.Compile().Invoke(_notifiable);
            var name = ((MemberExpression)selector.Body).Member.Name;

            if (val > a && val < b)
                _notifiable.AddNotification(name, string.IsNullOrEmpty(message) ? Message.IfRange.ToFormat(name, a, b) : message);

            return this;
        }

        /// <summary>
        /// Dada uma string, adicione uma notificação se não for igual a
        /// </summary>
        /// <param name="selector">Nome da propriedade que deseja testar</param>
        /// <param name="val">Value to be compared</param>
        /// <param name="message">Mensagem de erro (Opcional)</param>
        /// <returns>Dada uma string, adicione uma notificação se não for igual a</returns>
        public Notification<T> IfNotAreEquals(Expression<Func<T, decimal>> selector, decimal value, string message = "")
        {
            var val = selector.Compile().Invoke(_notifiable);
            var name = ((MemberExpression)selector.Body).Member.Name;

            if (val != value)
                _notifiable.AddNotification(name, string.IsNullOrEmpty(message) ? Message.IfNotAreEquals.ToFormat(name, value) : message);

            return this;
        }

        /// <summary>
        /// Dada uma string, adicione uma notificação se for igual
        /// </summary>
        /// <param name="selector">Nome da propriedade que deseja testar</param>
        /// <param name="val">Value to be compared</param>
        /// <param name="message">Mensagem de erro (Opcional)</param>
        /// <returns>Dada uma string, adicione uma notificação se for igual</returns>
        public Notification<T> IfAreEquals(Expression<Func<T, decimal>> selector, decimal value, string message = "")
        {
            var val = selector.Compile().Invoke(_notifiable);
            var name = ((MemberExpression)selector.Body).Member.Name;

            if (val == value)
                _notifiable.AddNotification(name, string.IsNullOrEmpty(message) ? Message.IfAreEquals.ToFormat(name, value) : message);

            return this;
        }
        
        /// <summary>
        /// Dada um decimal, adicione uma notificação se for igual a zero
        /// </summary>
        /// <param name="selector">Nome da propriedade que deseja testar</param>
        /// <param name="val">Value to be compared</param>
        /// <param name="message">Mensagem de erro (Opcional)</param>
        /// <returns>Dada um decimal, adicione uma notificação se for igual a zero</returns>
        public Notification<T> IfEqualsZero(Expression<Func<T, decimal>> selector, string message = "")
        {
            var val = selector.Compile().Invoke(_notifiable);
            var name = ((MemberExpression)selector.Body).Member.Name;

            if (val == 0)
                _notifiable.AddNotification(name, string.IsNullOrEmpty(message) ? Message.IfEqualsZero.ToFormat(name) : message);

            return this;
        }

        /// <summary>
        /// Dada um objeto decimal, adicione uma notificação se for igual null
        /// </summary>
        /// <param name="selector">Nome da propriedade que deseja testar</param>
        /// <param name="val">Value to be compared</param>
        /// <param name="message">Mensagem de erro (Opcional)</param>
        /// <returns>Dada um objeto decimal, adicione uma notificação se for igual null</returns>
        public Notification<T> IfNull(Expression<Func<T, decimal?>> selector, string message = "")
        {
            var val = selector.Compile().Invoke(_notifiable);
            var name = ((MemberExpression)selector.Body).Member.Name;

            if (val == null)
                _notifiable.AddNotification(name, string.IsNullOrEmpty(message) ? Message.IfNull.ToFormat(name) : message);

            return this;
        }

        /// <summary>
        /// Dada um objeto decimal, adicione uma notificação se não for igual null
        /// </summary>
        /// <param name="selector">Nome da propriedade que deseja testar</param>
        /// <param name="val">Value to be compared</param>
        /// <param name="message">Mensagem de erro (Opcional)</param>
        /// <returns>Dada um objeto decimal, adicione uma notificação se não for igual null</returns>
        public Notification<T> IfNotNull(Expression<Func<T, decimal?>> selector, string message = "")
        {
            var val = selector.Compile().Invoke(_notifiable);
            var name = ((MemberExpression)selector.Body).Member.Name;

            if (val != null)
                _notifiable.AddNotification(name, string.IsNullOrEmpty(message) ? Message.IfNotNull.ToFormat(name) : message);

            return this;
        }

        /// <summary>
        /// Dado um int, adicione uma notificação se seu valor for menor que o parâmetro min
        /// </summary>
        /// <param name="val">Valor informado</param>
        /// <param name="min">Minimum Length</param>
        /// <param name="objectName">Nome da propriedade ou objeto que representa a informação</param>
        /// <param name="message">Mensagem de erro (Opcional)</param>
        /// <returns>Dado um int, adicione uma notificação se seu valor for menor que o parâmetro min</returns>
        public Notification<T> IfLowerThan(decimal val, decimal min, string objectName, string message = "")
        {
            if (val < min)
                _notifiable.AddNotification(objectName, string.IsNullOrEmpty(message) ? Message.IfLowerThan.ToFormat(objectName, min) : message);

            return this;
        }

        /// <summary>
        /// Dada um decimal, adicione uma notificação se seu valor for maior que o parâmetro max
        /// </summary>
        /// <param name="val">Valor informado</param>
        /// <param name="min">Minimum Length</param>
        /// <param name="objectName">Nome da propriedade ou objeto que representa a informação</param>
        /// <param name="message">Mensagem de erro (Opcional)</param>
        /// <returns>Dada um decimal, adicione uma notificação se seu valor for maior que o parâmetro max</returns>
        public Notification<T> IfGreaterThan(decimal val, decimal max, string objectName, string message = "")
        {
            if (val > max)
                _notifiable.AddNotification(objectName, string.IsNullOrEmpty(message) ? Message.IfGreaterThan.ToFormat(objectName, max) : message);

            return this;
        }

        /// <summary>
        /// Dado um int, adicione uma notificação se for maior ou igual ao parametro passado
        /// </summary>
        /// <param name="val">Valor informado</param>
        /// <param name="number">Number to be compared</param>
        /// <param name="objectName">Nome da propriedade ou objeto que representa a informação</param>
        /// <param name="message">Mensagem de erro (Opcional)</param>
        /// <returns>Dado um int, adicione uma notificação se for maior ou igual ao parametro passado</returns>
        public Notification<T> IfGreaterOrEqualsThan(decimal val, decimal number, string objectName, string message = "")
        {

            if (val >= number)
                _notifiable.AddNotification(objectName, string.IsNullOrEmpty(message) ? Message.IfGreaterOrEqualsThan.ToFormat(objectName, number) : message);

            return this;
        }

        /// <summary>
        /// Dado um int, adicione uma notificação se for menor ou igual ao parametro passado
        /// </summary>
        /// <param name="val">Valor informado</param>
        /// <param name="number">Number to be compared</param>
        /// <param name="objectName">Nome da propriedade ou objeto que representa a informação</param>
        /// <param name="message">Mensagem de erro (Opcional)</param>
        /// <returns>Dado um int, adicione uma notificação se for menor ou igual ao parametro passado</returns>
        public Notification<T> IfLowerOrEqualsThan(decimal val, decimal number, string objectName, string message = "")
        {
            if (val <= number)
                _notifiable.AddNotification(objectName, string.IsNullOrEmpty(message) ? Message.IfLowerOrEqualsThan.ToFormat(objectName, number) : message);

            return this;
        }

        /// <summary>
        /// Dado um int, adicione uma notificação se não estiver entre alguns dois valores
        /// </summary>
        /// <param name="val">Valor informado</param>
        /// <param name="a">Valor menor</param>
        /// <param name="b">Valor maior</param>
        /// <param name="objectName">Nome da propriedade ou objeto que representa a informação</param>
        /// <param name="message">Mensagem de erro (Opcional)</param>
        /// <returns>Dado um int, adicione uma notificação se não estiver entre alguns dois valores</returns>
        public Notification<T> IfNotRange(decimal val, decimal a, decimal b, string objectName, string message = "")
        {
            if (val < a || val > b)
                _notifiable.AddNotification(objectName, string.IsNullOrEmpty(message) ? Message.IfNotRange.ToFormat(objectName, a, b) : message);

            return this;
        }

        /// <summary>
        /// Dado um int, adicione uma notificação se estiver entre alguns dois valores
        /// </summary>
        /// <param name="val">Valor informado</param>
        /// <param name="a">Valor menor</param>
        /// <param name="b">Valor maior</param>
        /// <param name="objectName">Nome da propriedade ou objeto que representa a informação</param>
        /// <param name="message">Mensagem de erro (Opcional)</param>
        /// <returns>Dado um int, adicione uma notificação se estiver entre alguns dois valores</returns>
        public Notification<T> IfRange(decimal val, decimal a, decimal b, string objectName, string message = "")
        {
            if (val > a && val < b)
                _notifiable.AddNotification(objectName, string.IsNullOrEmpty(message) ? Message.IfRange.ToFormat(objectName, a, b) : message);

            return this;
        }

        /// <summary>
        /// Dada uma string, adicione uma notificação se não for igual a
        /// </summary>
        /// <param name="val">Valor informado</param>
        /// <param name="value">Valor a ser comparado</param>
        /// <param name="objectName">Nome da propriedade ou objeto que representa a informação</param>
        /// <param name="message">Mensagem de erro (Opcional)</param>
        /// <returns>Dada uma string, adicione uma notificação se não for igual a</returns>
        public Notification<T> IfNotAreEquals(decimal val, decimal value, string objectName, string message = "")
        {
            if (val != value)
                _notifiable.AddNotification(objectName, string.IsNullOrEmpty(message) ? Message.IfNotAreEquals.ToFormat(objectName, value) : message);

            return this;
        }

        /// <summary>
        /// Dada uma string, adicione uma notificação se for igual
        /// </summary>
        /// <param name="val">Valor informado</param>
        /// <param name="value">Valor a ser comparado</param>
        /// <param name="objectName">Nome da propriedade ou objeto que representa a informação</param>
        /// <param name="message">Mensagem de erro (Opcional)</param>
        /// <returns>Dada uma string, adicione uma notificação se for igual</returns>
        public Notification<T> IfAreEquals(decimal val, decimal value, string objectName, string message = "")
        {
            if (val == value)
                _notifiable.AddNotification(objectName, string.IsNullOrEmpty(message) ? Message.IfAreEquals.ToFormat(objectName, value) : message);

            return this;
        }

        /// <summary>
        /// Dada um decimal, adicione uma notificação se for igual a zero
        /// </summary>
        /// <param name="val">Valor informado</param>
        /// <param name="objectName">Nome da propriedade ou objeto que representa a informação</param>
        /// <param name="message">Mensagem de erro (Opcional)</param>
        /// <returns>Dada um decimal, adicione uma notificação se for igual a zero</returns>
        public Notification<T> IfEqualsZero(decimal val, string objectName, string message = "")
        {
            if (val == 0)
                _notifiable.AddNotification(objectName, string.IsNullOrEmpty(message) ? Message.IfEqualsZero.ToFormat(objectName) : message);

            return this;
        }

        /// <summary>
        /// Dada um objeto decimal, adicione uma notificação se for igual null
        /// </summary>
        /// <param name="val">Valor informado</param>
        /// <param name="objectName">Nome da propriedade ou objeto que representa a informação</param>
        /// <param name="message">Mensagem de erro (Opcional)</param>
        /// <returns>Dada um objeto decimal, adicione uma notificação se for igual null</returns>
        public Notification<T> IfNull(decimal? val, string objectName, string message = "")
        {
            if (val == null)
                _notifiable.AddNotification(objectName, string.IsNullOrEmpty(message) ? Message.IfNull.ToFormat(objectName) : message);

            return this;
        }

        /// <summary>
        /// Dada um objeto decimal, adicione uma notificação se não for igual null
        /// </summary>
        /// <param name="val">Valor informado</param>
        /// <param name="val">Value to be compared</param>
        /// <param name="objectName">Nome da propriedade ou objeto que representa a informação</param>
        /// <param name="message">Mensagem de erro (Opcional)</param>
        /// <returns>Dada um objeto decimal, adicione uma notificação se não for igual null</returns>
        public Notification<T> IfNotNull(decimal? val, string objectName, string message = "")
        {
            if (val != null)
                _notifiable.AddNotification(objectName, string.IsNullOrEmpty(message) ? Message.IfNotNull.ToFormat(objectName) : message);

            return this;
        }
    }
}