using System.Linq.Expressions;
using Berger.Extensions.Notification.Resources;

namespace Berger.Extensions.Notification
{
    public partial class Notification 
    {
        /// <summary>
        /// Dado um float, adicione uma notificação se seu valor for menor que o parâmetro min
        /// </summary>
        /// <param name="selector">Nome da propriedade que deseja testar</param>
        /// <param name="min">Minimum Length</param>
        /// <param name="message">Mensagem de erro (Opcional)</param>
        /// <returns>Dado um float, adicione uma notificação se seu valor for menor que o parâmetro min</returns>
        public void IfLowerThan<T>(T model, Expression<Func<T, float>> selector, float min, string message = "")
        {
            var val = selector.Compile().Invoke(model);
            var name = ((MemberExpression)selector.Body).Member.Name;

            if (val < min)
                AddNotification(name, string.IsNullOrEmpty(message) ? Message.IfLowerThan.ToFormat(name, min) : message);
        }

        /// <summary>
        /// Dada um float, adicione uma notificação se seu valor for maior que o parâmetro max
        /// </summary>
        /// <param name="selector">Nome da propriedade que deseja testar</param>
        /// <param name="min">Minimum Length</param>
        /// <param name="message">Mensagem de erro (Opcional)</param>
        /// <returns>Dada um float, adicione uma notificação se seu valor for maior que o parâmetro max</returns>
        public void IfGreaterThan<T>(T model, Expression<Func<T, float>> selector, float max, string message = "")
        {
            var val = selector.Compile().Invoke(model);
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
        public void IfGreaterOrEqualsThan<T>(T model, Expression<Func<T, float>> selector, float number, string message = "")
        {
            var val = selector.Compile().Invoke(model);
            var name = ((MemberExpression)selector.Body).Member.Name;

            if (val >= number)
                AddNotification(name, string.IsNullOrEmpty(message) ? Message.IfGreaterOrEqualsThan.ToFormat(name, number) : message);
        }

        /// <summary>
        /// Dado um int, adicione uma notificação se for menor ou igual ao parametro passado
        /// </summary>
        /// <param name="selector">Nome da propriedade que deseja testar</param>
        /// <param name="number">Number to be compared</param>
        /// <param name="message">Mensagem de erro (Opcional)</param>
        /// <returns>Dado um int, adicione uma notificação se for menor ou igual ao parametro passado</returns>
        public void IfLowerOrEqualsThan<T>(T model, Expression<Func<T, float>> selector, float number, string message = "")
        {
            var val = selector.Compile().Invoke(model);
            var name = ((MemberExpression)selector.Body).Member.Name;

            if (val <= number)
                AddNotification(name, string.IsNullOrEmpty(message) ? Message.IfLowerOrEqualsThan.ToFormat(name, number) : message);
        }

        /// <summary>
        /// Dado um int, adicione uma notificação se não estiver entre alguns dois valores
        /// </summary>
        /// <param name="selector">Nome da propriedade que deseja testar</param>
        /// <param name="a">Lower value</param>
        /// <param name="b">Higher value</param>
        /// <param name="message">Mensagem de erro (Opcional)</param>
        /// <returns>Dado um int, adicione uma notificação se não estiver entre alguns dois valores</returns>
        public void IfNotRange<T>(T model, Expression<Func<T, float>> selector, float a, float b, string message = "")
        {
            var val = selector.Compile().Invoke(model);
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
        public void IfRange<T>(T model, Expression<Func<T, float>> selector, float a, float b, string message = "")
        {
            var val = selector.Compile().Invoke(model);
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
        public void IfNotAreEquals<T>(T model, Expression<Func<T, float>> selector, float value, string message = "")
        {
            var val = selector.Compile().Invoke(model);
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
        /// <returns>Dada uma string, adicione uma notificação se for igual</returns>
        public void IfAreEquals<T>(T model, Expression<Func<T, float>> selector, float value, string message = "")
        {
            var val = selector.Compile().Invoke(model);
            var name = ((MemberExpression)selector.Body).Member.Name;

            if (val == value)
                AddNotification(name, string.IsNullOrEmpty(message) ? Message.IfAreEquals.ToFormat(name, value) : message);
        }

        /// <summary>
        /// Dada um objeto float, adicione uma notificação se for igual null
        /// </summary>
        /// <param name="selector">Nome da propriedade que deseja testar</param>
        /// <param name="val">Value to be compared</param>
        /// <param name="message">Mensagem de erro (Opcional)</param>
        /// <returns>Dada um objeto float, adicione uma notificação se for igual null</returns>
        public void IfNull<T>(T model, Expression<Func<T, float?>> selector, string message = "")
        {
            var val = selector.Compile().Invoke(model);
            var name = ((MemberExpression)selector.Body).Member.Name;

            if (val == null)
                AddNotification(name, string.IsNullOrEmpty(message) ? Message.IfNull.ToFormat(name) : message);
        }

        /// <summary>
        /// Dada um float, adicione uma notificação se for igual a zero
        /// </summary>
        /// <param name="selector">Nome da propriedade que deseja testar</param>
        /// <param name="val">Value to be compared</param>
        /// <param name="message">Mensagem de erro (Opcional)</param>
        /// <returns>Dada um float, adicione uma notificação se for igual a zero</returns>
        public void IfEqualsZero<T>(T model, Expression<Func<T, float>> selector, string message = "")
        {
            var val = selector.Compile().Invoke(model);
            var name = ((MemberExpression)selector.Body).Member.Name;

            if (val == 0)
                AddNotification(name, string.IsNullOrEmpty(message) ? Message.IfEqualsZero.ToFormat(name) : message);
        }

        /// <summary>
        /// Dada um objeto float, adicione uma notificação se não for igual null
        /// </summary>
        /// <param name="selector">Nome da propriedade que deseja testar</param>
        /// <param name="val">Value to be compared</param>
        /// <param name="message">Mensagem de erro (Opcional)</param>
        /// <returns>Dada um objeto float, adicione uma notificação se não for igual null</returns>
        public void IfNotNull<T>(T model, Expression<Func<T, float?>> selector, string message = "")
        {
            var val = selector.Compile().Invoke(model);
            var name = ((MemberExpression)selector.Body).Member.Name;

            if (val != null)
                AddNotification(name, string.IsNullOrEmpty(message) ? Message.IfNotNull.ToFormat(name) : message);
        }

        /// <summary>
        /// Dado um float, adicione uma notificação se seu valor for menor que o parâmetro min
        /// </summary>
        /// <param name="val">Valor informado</param>
        /// <param name="min">Informe o valor mínimo</param>
        /// <param name="objectName">Nome da propriedade ou objeto que representa a informação</param>
        /// <param name="message">Mensagem de erro (Opcional)</param>
        /// <returns>Dado um float, adicione uma notificação se seu valor for menor que o parâmetro min</returns>
        public void IfLowerThan(float val, float min, string objectName, string message = "")
        {
            if (val < min)
                AddNotification(objectName, string.IsNullOrEmpty(message) ? Message.IfLowerThan.ToFormat(objectName, min) : message);
        }

        /// <summary>
        /// Dada um float, adicione uma notificação se seu valor for maior que o parâmetro max
        /// </summary>
        /// <param name="val">Valor informado</param>
        /// <param name="max">Informe o valor máximo</param>
        /// <param name="objectName">Nome da propriedade ou objeto que representa a informação</param>
        /// <param name="message">Mensagem de erro (Opcional)</param>
        /// <returns>Dada um float, adicione uma notificação se seu valor for maior que o parâmetro max</returns>
        public void IfGreaterThan(float val, float max, string objectName, string message = "")
        {
            if (val > max)
                AddNotification(objectName, string.IsNullOrEmpty(message) ? Message.IfGreaterThan.ToFormat(objectName, max) : message);
        }

        /// <summary>
        /// Dado um int, adicione uma notificação se for maior ou igual ao parametro passado
        /// </summary>
        /// <param name="val">Valor informado</param>
        /// <param name="number">Numero a ser comparado</param>
        /// <param name="objectName">Nome da propriedade ou objeto que representa a informação</param>
        /// <param name="message">Mensagem de erro (Opcional)</param>
        /// <returns>Dado um int, adicione uma notificação se for maior ou igual ao parametro passado</returns>
        public void IfGreaterOrEqualsThan(float val, float number, string objectName, string message = "")
        {
            if (val >= number)
                AddNotification(objectName, string.IsNullOrEmpty(message) ? Message.IfGreaterOrEqualsThan.ToFormat(objectName, number) : message);

            
        }

        /// <summary>
        /// Dado um int, adicione uma notificação se for menor ou igual ao parametro passado
        /// </summary>
        /// <param name="val">Valor informado</param>
        /// <param name="number">Numero a ser comparado</param>
        /// <param name="objectName">Nome da propriedade ou objeto que representa a informação</param>
        /// <param name="message">Mensagem de erro (Opcional)</param>
        /// <returns>Dado um int, adicione uma notificação se for menor ou igual ao parametro passado</returns>
        public void IfLowerOrEqualsThan(float val, float number, string objectName, string message = "")
        {
            if (val <= number)
                AddNotification(objectName, string.IsNullOrEmpty(message) ? Message.IfLowerOrEqualsThan.ToFormat(objectName, number) : message);

            
        }

        /// <summary>
        /// Dado um int, adicione uma notificação se não estiver entre alguns dois valores
        /// </summary>
        /// <param name="val">Valor informado</param>
        /// <param name="a">Menor valor</param>
        /// <param name="b">Maior valor</param>
        /// <param name="objectName">Nome da propriedade ou objeto que representa a informação</param>
        /// <param name="message">Mensagem de erro (Opcional)</param>
        /// <returns>Dado um int, adicione uma notificação se não estiver entre alguns dois valores</returns>
        public void IfNotRange(float val, float a, float b, string objectName, string message = "")
        {
            if (val < a || val > b)
                AddNotification(objectName, string.IsNullOrEmpty(message) ? Message.IfNotRange.ToFormat(objectName, a, b) : message);

            
        }

        /// <summary>
        /// Dado um int, adicione uma notificação se estiver entre alguns dois valores
        /// </summary>
        /// <param name="val">Valor informado</param>
        /// <param name="a">Menor valor</param>
        /// <param name="b">Maior valor</param>
        /// <param name="objectName">Nome da propriedade ou objeto que representa a informação</param>
        /// <param name="message">Mensagem de erro (Opcional)</param>
        /// <returns>Dado um int, adicione uma notificação se estiver entre alguns dois valores</returns>
        public void IfRange(float val, float a, float b, string objectName, string message = "")
        {
            if (val > a && val < b)
                AddNotification(objectName, string.IsNullOrEmpty(message) ? Message.IfRange.ToFormat(objectName, a, b) : message);

            
        }

        /// <summary>
        /// Dada uma string, adicione uma notificação se não for igual a
        /// </summary>
        /// <param name="val">Valor informado</param>
        /// <param name="value">Valor a ser comparado</param>
        /// <param name="objectName">Nome da propriedade ou objeto que representa a informação</param>
        /// <param name="message">Mensagem de erro (Opcional)</param>
        /// <returns>Dada uma string, adicione uma notificação se não for igual a</returns>
        public void IfNotAreEquals(float val, float value, string objectName, string message = "")
        {
        
            if (val != value)
                AddNotification(objectName, string.IsNullOrEmpty(message) ? Message.IfNotAreEquals.ToFormat(objectName, value) : message);

            
        }

        /// <summary>
        /// Dada uma string, adicione uma notificação se for igual
        /// </summary>
        /// <param name="val">Valor informado</param>
        /// <param name="value">Valor a ser comparado</param>
        /// <param name="objectName">Nome da propriedade ou objeto que representa a informação</param>
        /// <param name="message">Mensagem de erro (Opcional)</param>
        /// <returns>Dada uma string, adicione uma notificação se for igual</returns>
        public void IfAreEquals(float val, float value, string objectName, string message = "")
        {
            if (val == value)
                AddNotification(objectName, string.IsNullOrEmpty(message) ? Message.IfAreEquals.ToFormat(objectName, value) : message);

            
        }

        /// <summary>
        /// Dada um float, adicione uma notificação se for igual a zero
        /// </summary>
        /// <param name="val">Valor informado</param>
        /// <param name="objectName">Nome da propriedade ou objeto que representa a informação</param>
        /// <param name="message">Mensagem de erro (Opcional)</param>
        /// <returns>Dada um float, adicione uma notificação se for igual a zero</returns>
        public void IfEqualsZero(float val, string objectName, string message = "")
        {
            if (val == 0)
                AddNotification(objectName, string.IsNullOrEmpty(message) ? Message.IfEqualsZero.ToFormat(objectName) : message);

            
        }

        /// <summary>
        /// Dada um objeto float, adicione uma notificação se for igual null
        /// </summary>
        /// <param name="val">Valor informado</param>
        /// <param name="objectName">Nome da propriedade ou objeto que representa a informação</param>
        /// <param name="message">Mensagem de erro (Opcional)</param>
        /// <returns>Dada um objeto float, adicione uma notificação se for igual null</returns>
        public void IfNull(float? val, string objectName, string message = "")
        {
            if (val == null)
                AddNotification(objectName, string.IsNullOrEmpty(message) ? Message.IfNull.ToFormat(objectName) : message);

            
        }

        /// <summary>
        /// Dada um objeto float, adicione uma notificação se não for igual null
        /// </summary>
        /// <param name="val">Valor informado</param>
        /// <param name="objectName">Nome da propriedade ou objeto que representa a informação</param>
        /// <param name="message">Mensagem de erro (Opcional)</param>
        /// <returns>Dada um objeto float, adicione uma notificação se não for igual null</returns>
        public void IfNotNull(float? val, string objectName, string message = "")
        {
            if (val != null)
                AddNotification(objectName, string.IsNullOrEmpty(message) ? Message.IfNotNull.ToFormat(objectName) : message);
        }
    }
}