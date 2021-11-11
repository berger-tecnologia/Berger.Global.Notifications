using System;
using System.Linq.Expressions;
using Berger.Global.Notifications.Resources;
using Berger.Global.Notifications.Extensions;

namespace Berger.Global.Notifications.Patterns
{
    public partial class Notification<T> 
    {
        /// <summary>
        /// Dado um DateTime, adicione uma notificação se seu valor for menor que o parâmetro min
        /// </summary>
        /// <param name="selector">Nome da propriedade que deseja testar</param>
        /// <param name="min">Minimum Length</param>
        /// <param name="message">Mensagem de erro (Opcional)</param>
        /// <returns>Dado um DateTime, adicione uma notificação se seu valor for menor que o parâmetro min</returns>
        public void IfLowerThan(Expression<Func<T, DateTime>> selector, DateTime min, string message = "")
        {
            var val = selector.Compile().Invoke(_model);
            var name = ((MemberExpression)selector.Body).Member.Name;

            if (val < min)
                AddNotification(name, string.IsNullOrEmpty(message) ? Message.IfLowerThan.ToFormat(name, min) : message);
        }

        /// <summary>
        /// Dada um DateTime, adicione uma notificação se seu valor for maior que o parâmetro max
        /// </summary>
        /// <param name="selector">Nome da propriedade que deseja testar</param>
        /// <param name="min">Minimum Length</param>
        /// <param name="message">Mensagem de erro (Opcional)</param>
        /// <returns>Dada um DateTime, adicione uma notificação se seu valor for maior que o parâmetro max</returns>
        public void IfGreaterThan(Expression<Func<T, DateTime>> selector, DateTime max, string message = "")
        {
            var val = selector.Compile().Invoke(_model);
            var name = ((MemberExpression)selector.Body).Member.Name;

            if (val > max)
                AddNotification(name, string.IsNullOrEmpty(message) ? Message.IfGreaterThan.ToFormat(name, max) : message);
        }

        /// <summary>
        /// Dado um int, adicione uma notificação se for maior ou igual ao parametro passado
        /// </summary>
        /// <param name="selector">Nome da propriedade que deseja testar</param>
        /// <param name="number">Number to be compared</param>
        /// <param name="message">Mensagem de erro (Opcional)</param>
        /// <returns>Dado um int, adicione uma notificação se for maior ou igual ao parametro passado</returns>
        public void IfGreaterOrEqualsThan(Expression<Func<T, DateTime>> selector, DateTime date, string message = "")
        {
            var val = selector.Compile().Invoke(_model);
            var name = ((MemberExpression)selector.Body).Member.Name;

            if (val >= date)
                AddNotification(name, string.IsNullOrEmpty(message) ? Message.IfGreaterOrEqualsThan.ToFormat(name, date) : message);
        }

        /// <summary>
        /// Dado um int, adicione uma notificação se for menor ou igual ao parametro passado
        /// </summary>
        /// <param name="selector">Nome da propriedade que deseja testar</param>
        /// <param name="number">Number to be compared</param>
        /// <param name="message">Mensagem de erro (Opcional)</param>
        /// <returns>Dado um int, adicione uma notificação se for menor ou igual ao parametro passado</returns>
        public void IfLowerOrEqualsThan(Expression<Func<T, DateTime>> selector, DateTime date, string message = "")
        {
            var val = selector.Compile().Invoke(_model);
            var name = ((MemberExpression)selector.Body).Member.Name;

            if (val <= date)
                AddNotification(name, string.IsNullOrEmpty(message) ? Message.IfLowerOrEqualsThan.ToFormat(name, date) : message);

        }

        /// <summary>
        /// Dado um int, adicione uma notificação se não estiver entre alguns dois valores
        /// </summary>
        /// <param name="selector">Nome da propriedade que deseja testar</param>
        /// <param name="a">Lower value</param>
        /// <param name="b">Higher value</param>
        /// <param name="message">Mensagem de erro (Opcional)</param>
        /// <returns>Dado um int, adicione uma notificação se não estiver entre alguns dois valores</returns>
        public void IfNotRange(Expression<Func<T, DateTime>> selector, DateTime a, DateTime b, string message = "")
        {
            var val = selector.Compile().Invoke(_model);
            var name = ((MemberExpression)selector.Body).Member.Name;

            if (val < a || val > b)
                AddNotification(name, string.IsNullOrEmpty(message) ? Message.IfNotRange.ToFormat(name, a, b) : message);
        }

        /// <summary>
        /// Dado um int, adicione uma notificação se estiver entre alguns dois valores
        /// </summary>
        /// <param name="selector">Nome da propriedade que deseja testar</param>
        /// <param name="a">Lower value</param>
        /// <param name="b">Higher value</param>
        /// <param name="message">Mensagem de erro (Opcional)</param>
        /// <returns>Dado um int, adicione uma notificação se estiver entre alguns dois valores</returns>
        public void IfRange(Expression<Func<T, DateTime>> selector, DateTime a, DateTime b, string message = "")
        {
            var val = selector.Compile().Invoke(_model);
            var name = ((MemberExpression)selector.Body).Member.Name;

            if (val > a && val < b)
                AddNotification(name, string.IsNullOrEmpty(message) ? Message.IfRange.ToFormat(name, a, b) : message);
        }

        /// <summary>
        /// Dada uma string, adicione uma notificação se não for igual a
        /// </summary>
        /// <param name="selector">Nome da propriedade que deseja testar</param>
        /// <param name="val">Value to be compared</param>
        /// <param name="message">Mensagem de erro (Opcional)</param>
        /// <returns>Dada uma string, adicione uma notificação se não for igual a</returns>
        public void IfNotAreEquals(Expression<Func<T, DateTime>> selector, DateTime value, string message = "")
        {
            var val = selector.Compile().Invoke(_model);
            var name = ((MemberExpression)selector.Body).Member.Name;

            if (val != value)
                AddNotification(name, string.IsNullOrEmpty(message) ? Message.IfNotAreEquals.ToFormat(name, value) : message);
        }

        /// <summary>
        /// Dada uma string, adicione uma notificação se for igual
        /// </summary>
        /// <param name="selector">Nome da propriedade que deseja testar</param>
        /// <param name="val">Value to be compared</param>
        /// <param name="message">Mensagem de erro (Opcional)</param>
        /// <returns>Dada uma string, adicione uma notificação se for igual a</returns>
        public void IfAreEquals(Expression<Func<T, DateTime>> selector, DateTime value, string message = "")
        {
            var val = selector.Compile().Invoke(_model);
            var name = ((MemberExpression)selector.Body).Member.Name;

            if (val == value)
                AddNotification(name, string.IsNullOrEmpty(message) ? Message.IfAreEquals.ToFormat(name, value) : message);
        }

        /// <summary>
        /// Dada um objeto de data, adicione uma notificação se for igual null
        /// </summary>
        /// <param name="selector">Nome da propriedade que deseja testar</param>
        /// <param name="val">Value to be compared</param>
        /// <param name="message">Mensagem de erro (Opcional)</param>
        /// <returns>Dada um objeto de data, adicione uma notificação se for igual null</returns>
        public void IfNull(Expression<Func<T, DateTime>> selector, string message = "")
        {
            var val = selector.Compile().Invoke(_model);
            var name = ((MemberExpression)selector.Body).Member.Name;

            if (val == null)
                AddNotification(name, string.IsNullOrEmpty(message) ? Message.IfNull.ToFormat(name) : message);
        }

        /// <summary>
        /// Dada um objeto de data, adicione uma notificação se for igual null
        /// </summary>
        /// <param name="selector">Nome da propriedade que deseja testar</param>
        /// <param name="val">Value to be compared</param>
        /// <param name="message">Mensagem de erro (Opcional)</param>
        /// <returns>Dada um objeto de data, adicione uma notificação se for igual null</returns>
        public void IfNull(Expression<Func<T, DateTime?>> selector, string message = "")
        {
            var val = selector.Compile().Invoke(_model);
            var name = ((MemberExpression)selector.Body).Member.Name;

            if (val == null)
                AddNotification(name, string.IsNullOrEmpty(message) ? Message.IfNull.ToFormat(name) : message);
        }

        /// <summary>
        /// Dada um objeto de data, adicione uma notificação se não for igual null
        /// </summary>
        /// <param name="selector">Nome da propriedade que deseja testar</param>
        /// <param name="val">Value to be compared</param>
        /// <param name="message">Mensagem de erro (Opcional)</param>
        /// <returns>Dada um objeto de data, adicione uma notificação se não for igual null</returns>
        public void IfNotNull(Expression<Func<T, DateTime>> selector, string message = "")
        {
            var val = selector.Compile().Invoke(_model);
            var name = ((MemberExpression)selector.Body).Member.Name;

            if (val != null)
                AddNotification(name, string.IsNullOrEmpty(message) ? Message.IfNotNull.ToFormat(name) : message);
        }

        /// <summary>
        /// Dada um objeto de data, adicione uma notificação se não for igual null
        /// </summary>
        /// <param name="selector">Nome da propriedade que deseja testar</param>
        /// <param name="val">Value to be compared</param>
        /// <param name="message">Mensagem de erro (Opcional)</param>
        /// <returns>Dada um objeto de data, adicione uma notificação se não for igual null</returns>
        public void IfNotNull(Expression<Func<T, DateTime?>> selector, string message = "")
        {
            var val = selector.Compile().Invoke(_model);
            var name = ((MemberExpression)selector.Body).Member.Name;

            if (val != null)
                AddNotification(name, string.IsNullOrEmpty(message) ? Message.IfNotNull.ToFormat(name) : message);
        }

        /// <summary>
        /// Dado um DateTime, adicione uma notificação se seu valor for menor que o parâmetro min
        /// </summary>
        /// <param name="val">Nome da propriedade que deseja testar</param>
        /// <param name="min">Minimum Length</param>
        /// <param name="objectName">Nome da propriedade ou objeto que representa a informação</param>
        /// <param name="message">Mensagem de erro (Opcional)</param>
        /// <returns>Dado um DateTime, adicione uma notificação se seu valor for menor que o parâmetro min</returns>
        public void IfLowerThan(DateTime val, DateTime min, string objectName, string message = "")
        {
            if (val < min)
                AddNotification(objectName, string.IsNullOrEmpty(message) ? Message.IfLowerThan.ToFormat(objectName, min) : message);
        }

        /// <summary>
        /// Dada um DateTime, adicione uma notificação se seu valor for maior que o parâmetro max
        /// </summary>
        /// <param name="val">Nome da propriedade que deseja testar</param>
        /// <param name="min">Minimum Length</param>
        /// <param name="objectName">Nome da propriedade ou objeto que representa a informação</param>
        /// <param name="message">Mensagem de erro (Opcional)</param>
        /// <returns>Dada um DateTime, adicione uma notificação se seu valor for maior que o parâmetro max</returns>
        public void IfGreaterThan(DateTime val, DateTime max, string objectName, string message = "")
        {
            if (val > max)
                AddNotification(objectName, string.IsNullOrEmpty(message) ? Message.IfGreaterThan.ToFormat(objectName, max) : message);
        }

        /// <summary>
        /// Dado um int, adicione uma notificação se for maior ou igual ao parametro passado
        /// </summary>
        /// <param name="val">Nome da propriedade que deseja testar</param>
        /// <param name="number">Number to be compared</param>
        /// <param name="objectName">Nome da propriedade ou objeto que representa a informação</param>
        /// <param name="message">Mensagem de erro (Opcional)</param>
        /// <returns>Dado um int, adicione uma notificação se for maior ou igual ao parametro passado</returns>
        public void IfGreaterOrEqualsThan(DateTime val, DateTime date, string objectName, string message = "")
        {
            if (val >= date)
                AddNotification(objectName, string.IsNullOrEmpty(message) ? Message.IfGreaterOrEqualsThan.ToFormat(objectName, date) : message);
        }

        /// <summary>
        /// Dado um int, adicione uma notificação se for menor ou igual ao parametro passado
        /// </summary>
        /// <param name="val">Nome da propriedade que deseja testar</param>
        /// <param name="number">Number to be compared</param>
        /// <param name="objectName">Nome da propriedade ou objeto que representa a informação</param>
        /// <param name="message">Mensagem de erro (Opcional)</param>
        /// <returns>Dado um int, adicione uma notificação se for menor ou igual ao parametro passado</returns>
        public void IfLowerOrEqualsThan(DateTime val, DateTime date, string objectName, string message = "")
        {
            if (val <= date)
                AddNotification(objectName, string.IsNullOrEmpty(message) ? Message.IfLowerOrEqualsThan.ToFormat(objectName, date) : message);
        }

        /// <summary>
        /// Dado um int, adicione uma notificação se não estiver entre alguns dois valores
        /// </summary>
        /// <param name="val">Nome da propriedade que deseja testar</param>
        /// <param name="a">Lower value</param>
        /// <param name="b">Higher value</param>
        /// <param name="objectName">Nome da propriedade ou objeto que representa a informação</param>
        /// <param name="message">Mensagem de erro (Opcional)</param>
        /// <returns>Dado um int, adicione uma notificação se não estiver entre alguns dois valores</returns>
        public void IfNotRange(DateTime val, DateTime a, DateTime b, string objectName, string message = "")
        {

            if (val < a || val > b)
                AddNotification(objectName, string.IsNullOrEmpty(message) ? Message.IfNotRange.ToFormat(objectName, a, b) : message);
        }

        /// <summary>
        /// Dado um int, adicione uma notificação se estiver entre alguns dois valores
        /// </summary>
        /// <param name="val">Nome da propriedade que deseja testar</param>
        /// <param name="a">Lower value</param>
        /// <param name="b">Higher value</param>
        /// <param name="objectName">Nome da propriedade ou objeto que representa a informação</param>
        /// <param name="message">Mensagem de erro (Opcional)</param>
        /// <returns>Dado um int, adicione uma notificação se estiver entre alguns dois valores</returns>
        public void IfRange(DateTime val, DateTime a, DateTime b, string objectName, string message = "")
        {
            if (val > a && val < b)
                AddNotification(objectName, string.IsNullOrEmpty(message) ? Message.IfRange.ToFormat(objectName, a, b) : message);
        }

        /// <summary>
        /// Dada uma string, adicione uma notificação se não for igual a
        /// </summary>
        /// <param name="val">Nome da propriedade que deseja testar</param>
        /// <param name="val">Value to be compared</param>
        /// <param name="objectName">Nome da propriedade ou objeto que representa a informação</param>
        /// <param name="message">Mensagem de erro (Opcional)</param>
        /// <returns>Dada uma string, adicione uma notificação se não for igual a</returns>
        public void IfNotAreEquals(DateTime val, DateTime value, string objectName, string message = "")
        {
            if (val != value)
                AddNotification(objectName, string.IsNullOrEmpty(message) ? Message.IfNotAreEquals.ToFormat(objectName, value) : message);
        }

        /// <summary>
        /// Dada uma string, adicione uma notificação se for igual
        /// </summary>
        /// <param name="val">Nome da propriedade que deseja testar</param>
        /// <param name="val">Value to be compared</param>
        /// <param name="objectName">Nome da propriedade ou objeto que representa a informação</param>
        /// <param name="message">Mensagem de erro (Opcional)</param>
        /// <returns>Dada uma string, adicione uma notificação se for igual a</returns>
        public void IfAreEquals(DateTime val, DateTime value, string objectName, string message = "")
        {
            if (val == value)
                AddNotification(objectName, string.IsNullOrEmpty(message) ? Message.IfAreEquals.ToFormat(objectName, value) : message);
        }

        /// <summary>
        /// Dada um objeto de data, adicione uma notificação se for igual null
        /// </summary>
        /// <param name="val">Nome da propriedade que deseja testar</param>
        /// <param name="val">Value to be compared</param>
        /// <param name="objectName">Nome da propriedade ou objeto que representa a informação</param>
        /// <param name="message">Mensagem de erro (Opcional)</param>
        /// <returns>Dada um objeto de data, adicione uma notificação se for igual null</returns>
        public void IfNull(DateTime val, string objectName, string message = "")
        {
            if (val == null)
                AddNotification(objectName, string.IsNullOrEmpty(message) ? Message.IfNull.ToFormat(objectName) : message);
        }

        /// <summary>
        /// Dada um objeto de data, adicione uma notificação se for igual null
        /// </summary>
        /// <param name="val">Nome da propriedade que deseja testar</param>
        /// <param name="val">Value to be compared</param>
        /// <param name="objectName">Nome da propriedade ou objeto que representa a informação</param>
        /// <param name="message">Mensagem de erro (Opcional)</param>
        /// <returns>Dada um objeto de data, adicione uma notificação se for igual null</returns>
        public void IfNull(DateTime? val, string objectName, string message = "")
        {
            if (val == null)
                AddNotification(objectName, string.IsNullOrEmpty(message) ? Message.IfNull.ToFormat(objectName) : message);
        }

        /// <summary>
        /// Dada um objeto de data, adicione uma notificação se não for igual null
        /// </summary>
        /// <param name="val">Nome da propriedade que deseja testar</param>
        /// <param name="val">Value to be compared</param>
        /// <param name="objectName">Nome da propriedade ou objeto que representa a informação</param>
        /// <param name="message">Mensagem de erro (Opcional)</param>
        /// <returns>Dada um objeto de data, adicione uma notificação se não for igual null</returns>
        public void IfNotNull(DateTime val, string objectName, string message = "")
        {
            if (val != null)
                AddNotification(objectName, string.IsNullOrEmpty(message) ? Message.IfNotNull.ToFormat(objectName) : message);
        }

        /// <summary>
        /// Dada um objeto de data, adicione uma notificação se não for igual null
        /// </summary>
        /// <param name="val">Nome da propriedade que deseja testar</param>
        /// <param name="val">Value to be compared</param>
        /// <param name="objectName">Nome da propriedade ou objeto que representa a informação</param>
        /// <param name="message">Mensagem de erro (Opcional)</param>
        /// <returns>Dada um objeto de data, adicione uma notificação se não for igual null</returns>
        public void IfNotNull(DateTime? val, string objectName, string message = "")
        {
            if (val != null)
                AddNotification(objectName, string.IsNullOrEmpty(message) ? Message.IfNotNull.ToFormat(objectName) : message);
        }
    }
}