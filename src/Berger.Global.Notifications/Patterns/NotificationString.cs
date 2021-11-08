using System;
using System.Linq.Expressions;
using System.Text.RegularExpressions;
using Berger.Global.Notifications.Resources;
using Berger.Global.Notifications.Extensions;

namespace Berger.Global.Notifications.Patterns
{
    public partial class Notification<T> where T : Notifiable
    {
        /// <summary>
        /// Dada uma string, adicione uma notificação se for nula ou vazia
        /// </summary>
        /// <param name="selector">Nome da propriedade que deseja testar</param>
        /// <param name="message">Mensagem de erro (Opcional)</param>
        /// <returns>Dada uma string, adicione uma notificação se for nula ou vazia</returns>
        public Notification<T> IfNullOrEmpty(Expression<Func<T, string>> selector, string message = "")
        {
            var val = selector.Compile().Invoke(_notifiable);
            var name = ((MemberExpression)selector.Body).Member.Name;

            if (string.IsNullOrEmpty(val))
                _notifiable.AddNotification(name, string.IsNullOrEmpty(message) ? Message.IfNullOrEmpty.ToFormat(name) : message);

            return this;
        }

        /// <summary>
        /// Dada uma string, adicione uma notificação se for nula ou vazia ou com espaços em branco
        /// </summary>
        /// <param name="selector">Nome da propriedade que deseja testar</param>
        /// <param name="message">Mensagem de erro (Opcional)</param>
        /// <returns>Dada uma string, adicione uma notificação se for nula ou vazia ou com espaços em branco</returns>
        public Notification<T> IfNullOrWhiteSpace(Expression<Func<T, string>> selector, string message = "")
        {
            var val = selector.Compile().Invoke(_notifiable);
            var name = ((MemberExpression)selector.Body).Member.Name;

            if (string.IsNullOrEmpty(val) || string.IsNullOrWhiteSpace(val))
                _notifiable.AddNotification(name, string.IsNullOrEmpty(message) ? Message.IfNullOrWhiteSpace.ToFormat(name) : message);

            return this;
        }

        /// <summary>
        /// Dada uma string, adicione uma notificação se não for nula
        /// </summary>
        /// <param name="selector">Nome da propriedade que deseja testar</param>
        /// <param name="message">Mensagem de erro (Opcional)</param>
        /// <returns>Dada uma string, adicione uma notificação se não for nula</returns>
        public Notification<T> IfNotNullOrEmpty(Expression<Func<T, string>> selector, string message = "")
        {
            var val = selector.Compile().Invoke(_notifiable);
            var name = ((MemberExpression)selector.Body).Member.Name;

            if (!string.IsNullOrEmpty(val))
                _notifiable.AddNotification(name, string.IsNullOrEmpty(message) ? Message.IfNotNullOrEmpty.ToFormat(name) : message);

            return this;
        }

        /// <summary>
        /// Dada uma string, adicione uma notificação se for nula ou vazia ou com espaços em branco ou seu tamanho seja invalido
        /// </summary>
        /// <param name="selector">Nome da propriedade que deseja testar</param>
        /// <param name="message">Mensagem de erro (Opcional)</param>
        /// <returns>Dada uma string, adicione uma notificação se for nula ou vazia ou com espaços em branco ou seu tamanho seja invalido</returns>
        public Notification<T> IfNullOrInvalidLength(Expression<Func<T, string>> selector, int min, int max, string message = "")
        {
            var val = selector.Compile().Invoke(_notifiable);
            var name = ((MemberExpression)selector.Body).Member.Name;

            if (string.IsNullOrEmpty(val) || string.IsNullOrWhiteSpace(val) || val.Length < min || val.Length > max)
                _notifiable.AddNotification(name, string.IsNullOrEmpty(message) ? Message.IfNullOrInvalidLength.ToFormat(name, min, max) : message);

            return this;
        }

        /// <summary>
        /// Dada uma string, adicione uma notificação se seu comprimento for menor que o parâmetro min
        /// </summary>
        /// <param name="val">Nome da propriedade que deseja testar</param>
        /// <param name="min">Minimum Length</param>
        /// <param name="message">Mensagem de erro (Opcional)</param>
        /// <returns>Dada uma string, adicione uma notificação se seu comprimento for menor que o parâmetro min</returns>
        public Notification<T> IfLengthLowerThan(Expression<Func<T, string>> selector, int min, string message = "")
        {
            var val = selector.Compile().Invoke(_notifiable);
            var name = ((MemberExpression)selector.Body).Member.Name;

            if (!string.IsNullOrEmpty((string)val) && val.Length < min)
                _notifiable.AddNotification(name, string.IsNullOrEmpty(message) ? Message.IfLengthLowerThan.ToFormat(name, min) : message);

            return this;
        }

        /// <summary>
        /// Dada uma string, adicione uma notificação se seu comprimento for maior que o parâmetro max
        /// </summary>
        /// <param name="val">Nome da propriedade que deseja testar</param>
        /// <param name="min">Minimum Length</param>
        /// <param name="message">Mensagem de erro (Opcional)</param>
        /// <returns>Dada uma string, adicione uma notificação se seu comprimento for maior que o parâmetro max</returns>
        public Notification<T> IfLengthGreaterThan(Expression<Func<T, string>> selector, int max, string message = "")
        {
            var val = selector.Compile().Invoke(_notifiable);
            var name = ((MemberExpression)selector.Body).Member.Name;

            if (!string.IsNullOrEmpty((string)val) && val.Length > max)
                _notifiable.AddNotification(name, string.IsNullOrEmpty(message) ? Message.IfLengthGreaterThan.ToFormat(name, max) : message);

            return this;
        }

        /// <summary>
        /// Dada uma string, adicione uma notificação se seu comprimento for diferente do parâmetro length
        /// </summary>
        /// <param name="val">Nome da propriedade que deseja testar</param>
        /// <param name="length">Especific Length</param>
        /// <param name="message">Mensagem de erro (Opcional)</param>
        /// <returns>Dada uma string, adicione uma notificação se seu comprimento for diferente do parâmetro length</returns>
        public Notification<T> IfLengthNoEqual(Expression<Func<T, string>> selector, int length, string message = "")
        {
            var val = selector.Compile().Invoke(_notifiable);
            var name = ((MemberExpression)selector.Body).Member.Name;

            if (string.IsNullOrEmpty((string)val) || val.Length != length)
                _notifiable.AddNotification(name, string.IsNullOrEmpty(message) ? Message.IfLengthNoEqual.ToFormat(name, length) : message);

            return this;
        }

        /// <summary>
        /// Dada uma string, adicione uma notificação se não for um endereço de e-mail válido
        /// </summary>
        /// <param name="val">Nome da propriedade que deseja testar</param>
        /// <param name="message">Mensagem de erro (Opcional)</param>
        /// <returns>Dada uma string, adicione uma notificação se não for um endereço de e-mail válido</returns>
        public Notification<T> IfNotEmail(Expression<Func<T, string>> selector, string message = "")
        {
            var val = selector.Compile().Invoke(_notifiable);
            var name = ((MemberExpression)selector.Body).Member.Name;

            if (!Regex.IsMatch((string)val, @"^\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*$"))
                _notifiable.AddNotification(name, string.IsNullOrEmpty(message) ? Message.IfNotEmail.ToFormat(name) : message);

            return this;
        }

        /// <summary>
        /// Dada uma string, adicione uma notificação se não for um URL válida
        /// </summary>
        /// <param name="val">Nome da propriedade que deseja testar</param>
        /// <param name="message">Mensagem de erro (Opcional)</param>
        /// <returns>Dada uma string, adicione uma notificação se não for um URL válida</returns>
        public Notification<T> IfNotUrl(Expression<Func<T, string>> selector, string message = "")
        {
            var val = selector.Compile().Invoke(_notifiable);
            var name = ((MemberExpression)selector.Body).Member.Name;

            if (!Regex.IsMatch((string)val, @"^(http:\/\/www\.|https:\/\/www\.|http:\/\/|https:\/\/)[a-z0-9]+([\-\.]{1}[a-z0-9]+)*\.[a-z]{2,5}(:[0-9]{1,5})?(\/.*)?$"))
                _notifiable.AddNotification(name, string.IsNullOrEmpty(message) ? Message.IfNotUrl.ToFormat(name) : message);

            return this;
        }

        /// <summary>
        /// Dada uma string, adicione uma notificação se ela não contiver um texto
        /// </summary>
        /// <param name="val">Nome da propriedade que deseja testar</param>
        /// <param name="a">Lower value</param>
        /// <param name="b">Higher value</param>
        /// <param name="message">Mensagem de erro (Opcional)</param>
        /// <returns>Dada uma string, adicione uma notificação se ela não contiver um texto</returns>
        public Notification<T> IfNotContains(Expression<Func<T, string>> selector, string text, string message = "")
        {
            var val = selector.Compile().Invoke(_notifiable);
            var name = ((MemberExpression)selector.Body).Member.Name;

            if (val == null || !val.Contains(text))
                _notifiable.AddNotification(name, string.IsNullOrEmpty(message) ? Message.IfNotContains.ToFormat(name, text) : message);

            return this;
        }

        /// <summary>
        /// Dada uma string, adicione uma notificação se ela contiver um texto
        /// </summary>
        /// <param name="val">Nome da propriedade que deseja testar</param>
        /// <param name="a">Lower value</param>
        /// <param name="b">Higher value</param>
        /// <param name="message">Mensagem de erro (Opcional)</param>
        /// <returns>Dada uma string, adicione uma notificação se ela contiver um texto</returns>
        public Notification<T> IfContains(Expression<Func<T, string>> selector, string text, string message = "")
        {
            var val = selector.Compile().Invoke(_notifiable);
            var name = ((MemberExpression)selector.Body).Member.Name;

            if (val.Contains(text))
                _notifiable.AddNotification(name, string.IsNullOrEmpty(message) ? Message.IfContains.ToFormat(name, text) : message);

            return this;
        }

        /// <summary>
        /// Dada uma string, adicione uma notificação se não for um cpf válido
        /// </summary>
        /// <param name="val">Nome da propriedade que deseja testar</param>
        /// <param name="message">Mensagem de erro (Opcional)</param>
        /// <returns>Dada uma string, adicione uma notificação se não for um cpf válido</returns>
        public Notification<T> IfNotCpf(Expression<Func<T, string>> selector, string message = "")
        {
            var cpf = selector.Compile().Invoke(_notifiable);
            var name = ((MemberExpression)selector.Body).Member.Name;

            if (string.IsNullOrWhiteSpace(cpf))
            {
                _notifiable.AddNotification(name, string.IsNullOrEmpty(message) ? Message.IfNotCpf.ToFormat(name) : message);
                return this;
            }

            int[] multiplicador1 = new int[9] { 10, 9, 8, 7, 6, 5, 4, 3, 2 };
            int[] multiplicador2 = new int[10] { 11, 10, 9, 8, 7, 6, 5, 4, 3, 2 };
            string tempCpf;
            string digito;
            int soma;
            int resto;
            cpf = cpf.Trim();
            cpf = cpf.Replace(".", "").Replace("-", "");
            if (cpf.Length != 11)
            {
                _notifiable.AddNotification(name, string.IsNullOrEmpty(message) ? Message.IfNotCpf.ToFormat(name) : message);
                return this;
            }

            tempCpf = cpf.Substring(0, 9);
            soma = 0;

            for (int i = 0; i < 9; i++)
                soma += int.Parse(tempCpf[i].ToString()) * multiplicador1[i];
            resto = soma % 11;
            if (resto < 2)
                resto = 0;
            else
                resto = 11 - resto;
            digito = resto.ToString();
            tempCpf = tempCpf + digito;
            soma = 0;
            for (int i = 0; i < 10; i++)
                soma += int.Parse(tempCpf[i].ToString()) * multiplicador2[i];
            resto = soma % 11;
            if (resto < 2)
                resto = 0;
            else
                resto = 11 - resto;
            digito = digito + resto.ToString();
            bool isValid = cpf.EndsWith(digito);

            if (isValid == false)
            {
                _notifiable.AddNotification(name, string.IsNullOrEmpty(message) ? Message.IfNotCpf.ToFormat(name) : message);
                return this;
            }

            return this;
        }

        /// <summary>
        /// Dada uma string, adicione uma notificação se não for um Cnpj válido
        /// </summary>
        /// <param name="selector">Nome da propriedade que deseja testar</param>
        /// <param name="message">Mensagem de erro (Opcional)</param>
        /// <returns>Dada uma string, adicione uma notificação se não for um Cnpj válido</returns>
        public Notification<T> IfNotCnpj(Expression<Func<T, string>> selector, string message = "")
        {
            var cnpj = selector.Compile().Invoke(_notifiable);
            var name = ((MemberExpression)selector.Body).Member.Name;

            if (string.IsNullOrEmpty(cnpj))
            {
                _notifiable.AddNotification(name, string.IsNullOrEmpty(message) ? Message.IfNotCnpj.ToFormat(name) : message);
                return this;
            }

            int[] multiplicador1 = new int[12] { 5, 4, 3, 2, 9, 8, 7, 6, 5, 4, 3, 2 };
            int[] multiplicador2 = new int[13] { 6, 5, 4, 3, 2, 9, 8, 7, 6, 5, 4, 3, 2 };
            int soma;
            int resto;
            string digito;
            string tempCnpj;
            cnpj = cnpj.Trim();
            cnpj = cnpj.Replace(".", "").Replace("-", "").Replace("/", "");
            if (cnpj.Length != 14)
            {
                _notifiable.AddNotification(name, string.IsNullOrEmpty(message) ? Message.IfNotCnpj.ToFormat(name) : message);
                return this;
            }
            tempCnpj = cnpj.Substring(0, 12);
            soma = 0;
            for (int i = 0; i < 12; i++)
                soma += int.Parse(tempCnpj[i].ToString()) * multiplicador1[i];
            resto = (soma % 11);
            if (resto < 2)
                resto = 0;
            else
                resto = 11 - resto;
            digito = resto.ToString();
            tempCnpj = tempCnpj + digito;
            soma = 0;
            for (int i = 0; i < 13; i++)
                soma += int.Parse(tempCnpj[i].ToString()) * multiplicador2[i];
            resto = (soma % 11);
            if (resto < 2)
                resto = 0;
            else
                resto = 11 - resto;
            digito = digito + resto.ToString();
            bool isValid = cnpj.EndsWith(digito);

            if (isValid == false)
            {
                _notifiable.AddNotification(name, string.IsNullOrEmpty(message) ? Message.IfNotCnpj.ToFormat(name) : message);
                return this;
            }

            return this;
        }

        /// <summary>
        /// Dada uma string, adicione uma notificação se não for Guid
        /// </summary>
        /// <param name="selector">Nome da propriedade que deseja testar</param>
        /// <param name="message">Mensagem de erro (Opcional)</param>
        /// <returns>Dada uma string, adicione uma notificação se não for Guid</returns>
        public Notification<T> IfNotGuid(Expression<Func<T, string>> selector, string message = "")
        {
            var data = selector.Compile().Invoke(_notifiable);
            var name = ((MemberExpression)selector.Body).Member.Name;

            Guid x;

            if (Guid.TryParse(data, out x) == false)
            {
                _notifiable.AddNotification(name, string.IsNullOrEmpty(message) ? Message.IfNotGuid.ToFormat(name) : message);
            }
            return this;
        }

        /// <summary>
        /// Dada uma string, adicione uma notificação se não for uma data válida
        /// </summary>
        /// <param name="selector">Nome da propriedade que deseja testar</param>
        /// <param name="message">Mensagem de erro (Opcional)</param>
        /// <returns>Dada uma string, adicione uma notificação se não for uma data válida</returns>
        public Notification<T> IfNotDate(Expression<Func<T, string>> selector, string message = "")
        {
            var val = selector.Compile().Invoke(_notifiable);
            var name = ((MemberExpression)selector.Body).Member.Name;

            DateTime dt;

            if (DateTime.TryParse(val, out dt) == false)
                _notifiable.AddNotification(name, string.IsNullOrEmpty(message) ? Message.IfNotDate.ToFormat(name) : message);

            return this;
        }

        /// <summary>
        /// Dada uma string, adicione uma notificação se não for igual a
        /// </summary>
        /// <param name="selector">Nome da propriedade que deseja testar</param>
        /// <param name="val">Value to be compared</param>
        /// <param name="message">Mensagem de erro (Opcional)</param>
        /// <returns>Dada uma string, adicione uma notificação se não for igual a</returns>
        public Notification<T> IfNotAreEquals(Expression<Func<T, string>> selector, string text, string message = "")
        {
            var val = selector.Compile().Invoke(_notifiable);
            var name = ((MemberExpression)selector.Body).Member.Name;

            if (!val.Equals(text, StringComparison.OrdinalIgnoreCase))
                _notifiable.AddNotification(name, string.IsNullOrEmpty(message) ? Message.IfNotAreEquals.ToFormat(name, text) : message);

            return this;
        }
        /// <summary>
        /// Dada uma string, adicione uma notificação se for igual a
        /// </summary>
        /// <param name="selector">Nome da propriedade que deseja testar</param>
        /// <param name="val">Value to be compared</param>
        /// <param name="message">Mensagem de erro (Opcional)</param>
        /// <returns>Dada uma string, adicione uma notificação se for igual a</returns>
        public Notification<T> IfAreEquals(Expression<Func<T, string>> selector, string text, string message = "")
        {
            var val = selector.Compile().Invoke(_notifiable);
            var name = ((MemberExpression)selector.Body).Member.Name;

            if (val.Equals(text, StringComparison.OrdinalIgnoreCase))
                _notifiable.AddNotification(name, string.IsNullOrEmpty(message) ? Message.IfAreEquals.ToFormat(name, text) : message);

            return this;
        }

        /// <summary>
        /// Dada uma string, adicione uma notificação o conteudo passado não for válido para a Regex determinada
        /// </summary>
        /// <param name="val">Nome da propriedade que deseja testar</param>
        /// <param name="regex">Regex pertinente para validação</param>
        /// <param name="objectName">Nome da propriedade ou objeto que representa a informação</param>
        /// <param name="message">Mensagem de erro (Opcional)</param>
        /// <returns>Dada uma string, adicione uma notificação se não for um endereço de e-mail válido</returns>
        public Notification<T> IfNotMatch(Expression<Func<T, string>> selector, string regex, string message = "")
        {
            var val = selector.Compile().Invoke(_notifiable);
            var name = ((MemberExpression)selector.Body).Member.Name;

            if (!Regex.IsMatch((string)val, regex))
                _notifiable.AddNotification(name, string.IsNullOrEmpty(message) ? Message.IfNotMatch.ToFormat(name) : message);

            return this;
        }

        /// <summary>
        /// Dada uma string, adicione uma notificação se for nula ou vazia
        /// </summary>
        /// <param name="val">Valor informado</param>
        /// <param name="objectName">Nome da propriedade ou objeto que representa a informação</param>
        /// <param name="message"></param>
        /// <returns></returns>
        public Notification<T> IfNullOrEmpty(string val, string objectName, string message = null)
        {
            if (string.IsNullOrEmpty(val))
                _notifiable.AddNotification(objectName, string.IsNullOrWhiteSpace(message) ? Message.IfNullOrEmpty.ToFormat(objectName) : message);

            return this;
        }

        /// <summary>
        /// Dada uma string, adicione uma notificação se for nula ou contenha apenas espaços
        /// </summary>
        /// <param name="val">Valor informado</param>
        /// <param name="objectName">Nome da propriedade ou objeto que representa a informação</param>
        /// <param name="message"></param>
        /// <returns></returns>
        public Notification<T> IfNullOrWhiteSpace(string val, string objectName, string message = "")
        {
            if (string.IsNullOrWhiteSpace(val))
                _notifiable.AddNotification(objectName, string.IsNullOrWhiteSpace(message) ? Message.IfNullOrWhiteSpace.ToFormat(objectName) : message);

            return this;
        }

        /// <summary>
        /// Dada uma string, adicione uma notificação se não for nula
        /// </summary>
        /// <param name="val">Valor informado</param>
        /// <param name="objectName">Nome da propriedade ou objeto que representa a informação</param>
        /// <param name="message">Mensagem de erro (Opcional)</param>
        /// <returns>Dada uma string, adicione uma notificação se não for nula</returns>
        public Notification<T> IfNotNullOrEmpty(string val, string objectName, string message = "")
        {
            if (!string.IsNullOrEmpty(val))
                _notifiable.AddNotification(objectName, string.IsNullOrWhiteSpace(message) ? Message.IfNotNullOrEmpty.ToFormat(objectName) : message);

            return this;
        }

        /// <summary>
        /// Dada uma string, adicione uma notificação se for nula ou vazia ou com espaços em branco ou seu tamanho seja invalido
        /// </summary>
        /// <param name="val">Valor informado</param>
        /// <param name="objectName">Nome da propriedade ou objeto que representa a informação</param>
        /// <param name="message">Mensagem de erro (Opcional)</param>
        /// <returns>Dada uma string, adicione uma notificação se for nula ou vazia ou com espaços em branco ou seu tamanho seja invalido</returns>
        public Notification<T> IfNullOrInvalidLength(string val, int min, int max, string objectName, string message = "")
        {
            if (string.IsNullOrEmpty(val) || string.IsNullOrWhiteSpace(val) || val.Length < min || val.Length > max)
                _notifiable.AddNotification(objectName, string.IsNullOrEmpty(message) ? Message.IfNullOrInvalidLength.ToFormat(objectName, min, max) : message);

            return this;
        }


        ///////////////////////////////////////
        /// <summary>
        /// Dada uma string, adicione uma notificação se seu comprimento for menor que o parâmetro min
        /// </summary>
        /// <param name="val">Nome da propriedade que deseja testar</param>
        /// <param name="min">Minimum Length</param>
        /// <param name="objectName">Nome da propriedade ou objeto que representa a informação</param>
        /// <param name="message">Mensagem de erro (Opcional)</param>
        /// <returns>Dada uma string, adicione uma notificação se seu comprimento for menor que o parâmetro min</returns>
        public Notification<T> IfLengthLowerThan(string val, int min, string objectName, string message = "")
        {
            if (!string.IsNullOrEmpty((string)val) && val.Length < min)
                _notifiable.AddNotification(objectName, string.IsNullOrEmpty(message) ? Message.IfLengthLowerThan.ToFormat(objectName, min) : message);

            return this;
        }

        /// <summary>
        /// Dada uma string, adicione uma notificação se seu comprimento for maior que o parâmetro max
        /// </summary>
        /// <param name="val">Nome da propriedade que deseja testar</param>
        /// <param name="min">Minimum Length</param>
        /// <param name="objectName">Nome da propriedade ou objeto que representa a informação</param>
        /// <param name="message">Mensagem de erro (Opcional)</param>
        /// <returns>Dada uma string, adicione uma notificação se seu comprimento for maior que o parâmetro max</returns>
        public Notification<T> IfLengthGreaterThan(string val, int max, string objectName, string message = "")
        {
            if (!string.IsNullOrEmpty((string)val) && val.Length > max)
                _notifiable.AddNotification(objectName, string.IsNullOrEmpty(message) ? Message.IfLengthGreaterThan.ToFormat(objectName, max) : message);

            return this;
        }

        /// <summary>
        /// Dada uma string, adicione uma notificação se seu comprimento for diferente do parâmetro length
        /// </summary>
        /// <param name="val">Nome da propriedade que deseja testar</param>
        /// <param name="length">Especific Length</param>
        /// <param name="objectName">Nome da propriedade ou objeto que representa a informação</param>
        /// <param name="message">Mensagem de erro (Opcional)</param>
        /// <returns>Dada uma string, adicione uma notificação se seu comprimento for diferente do parâmetro length</returns>
        public Notification<T> IfLengthNoEqual(string val, int length, string objectName, string message = "")
        {
            if (string.IsNullOrEmpty((string)val) || val.Length != length)
                _notifiable.AddNotification(objectName, string.IsNullOrEmpty(message) ? Message.IfLengthNoEqual.ToFormat(objectName, length) : message);

            return this;
        }

        /// <summary>
        /// Dada uma string, adicione uma notificação se não for um endereço de e-mail válido
        /// </summary>
        /// <param name="val">Nome da propriedade que deseja testar</param>
        /// <param name="objectName">Nome da propriedade ou objeto que representa a informação</param>
        /// <param name="message">Mensagem de erro (Opcional)</param>
        /// <returns>Dada uma string, adicione uma notificação se não for um endereço de e-mail válido</returns>
        public Notification<T> IfNotEmail(string val, string objectName, string message = "")
        {
            if (!Regex.IsMatch((string)val, @"^\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*$"))
                _notifiable.AddNotification(objectName, string.IsNullOrEmpty(message) ? Message.IfNotEmail.ToFormat(objectName) : message);

            return this;
        }

        /// <summary>
        /// Dada uma string, adicione uma notificação se não for um URL válida
        /// </summary>
        /// <param name="val">Nome da propriedade que deseja testar</param>
        /// <param name="objectName">Nome da propriedade ou objeto que representa a informação</param>
        /// <param name="message">Mensagem de erro (Opcional)</param>
        /// <returns>Dada uma string, adicione uma notificação se não for um URL válida</returns>
        public Notification<T> IfNotUrl(string val, string objectName, string message = "")
        {
            if (!Regex.IsMatch(val, @"^(http:\/\/www\.|https:\/\/www\.|http:\/\/|https:\/\/)[a-z0-9]+([\-\.]{1}[a-z0-9]+)*\.[a-z]{2,5}(:[0-9]{1,5})?(\/.*)?$"))
                _notifiable.AddNotification(objectName, string.IsNullOrEmpty(message) ? Message.IfNotUrl.ToFormat(objectName) : message);

            return this;
        }

        /// <summary>
        /// Dada uma string, adicione uma notificação se ela não contiver um texto
        /// </summary>
        /// <param name="val">Nome da propriedade que deseja testar</param>
        /// <param name="a">Lower value</param>
        /// <param name="b">Higher value</param>
        /// <param name="objectName">Nome da propriedade ou objeto que representa a informação</param>
        /// <param name="message">Mensagem de erro (Opcional)</param>
        /// <returns>Dada uma string, adicione uma notificação se ela não contiver um texto</returns>
        public Notification<T> IfNotContains(string val, string text, string objectName, string message = "")
        {
            if (val == null || !val.Contains(text))
                _notifiable.AddNotification(objectName, string.IsNullOrEmpty(message) ? Message.IfNotContains.ToFormat(objectName, text) : message);

            return this;
        }

        /// <summary>
        /// Dada uma string, adicione uma notificação se ela contiver um texto
        /// </summary>
        /// <param name="val">Nome da propriedade que deseja testar</param>
        /// <param name="a">Lower value</param>
        /// <param name="b">Higher value</param>
        /// <param name="objectName">Nome da propriedade ou objeto que representa a informação</param>
        /// <param name="message">Mensagem de erro (Opcional)</param>
        /// <returns>Dada uma string, adicione uma notificação se ela contiver um texto</returns>
        public Notification<T> IfContains(string val, string text, string objectName, string message = "")
        {
            if (val.Contains(text))
                _notifiable.AddNotification(objectName, string.IsNullOrEmpty(message) ? Message.IfContains.ToFormat(objectName, text) : message);

            return this;
        }

        /// <summary>
        /// Dada uma string, adicione uma notificação se não for um cpf válido
        /// </summary>
        /// <param name="val">Nome da propriedade que deseja testar</param>
        /// <param name="objectName">Nome da propriedade ou objeto que representa a informação</param>
        /// <param name="message">Mensagem de erro (Opcional)</param>
        /// <returns>Dada uma string, adicione uma notificação se não for um cpf válido</returns>
        public Notification<T> IfNotCpf(string val, string objectName, string message = "")
        {
            var cpf = val;


            if (string.IsNullOrWhiteSpace(cpf))
            {
                _notifiable.AddNotification(objectName, string.IsNullOrEmpty(message) ? Message.IfNotCpf.ToFormat(objectName) : message);
                return this;
            }

            int[] multiplicador1 = new int[9] { 10, 9, 8, 7, 6, 5, 4, 3, 2 };
            int[] multiplicador2 = new int[10] { 11, 10, 9, 8, 7, 6, 5, 4, 3, 2 };
            string tempCpf;
            string digito;
            int soma;
            int resto;
            cpf = cpf.Trim();
            cpf = cpf.Replace(".", "").Replace("-", "");
            if (cpf.Length != 11)
            {
                _notifiable.AddNotification(objectName, string.IsNullOrEmpty(message) ? Message.IfNotCpf.ToFormat(objectName) : message);
                return this;
            }

            tempCpf = cpf.Substring(0, 9);
            soma = 0;

            for (int i = 0; i < 9; i++)
                soma += int.Parse(tempCpf[i].ToString()) * multiplicador1[i];
            resto = soma % 11;
            if (resto < 2)
                resto = 0;
            else
                resto = 11 - resto;
            digito = resto.ToString();
            tempCpf = tempCpf + digito;
            soma = 0;
            for (int i = 0; i < 10; i++)
                soma += int.Parse(tempCpf[i].ToString()) * multiplicador2[i];
            resto = soma % 11;
            if (resto < 2)
                resto = 0;
            else
                resto = 11 - resto;
            digito = digito + resto.ToString();
            bool isValid = cpf.EndsWith(digito);

            if (isValid == false)
            {
                _notifiable.AddNotification(objectName, string.IsNullOrEmpty(message) ? Message.IfNotCpf.ToFormat(objectName) : message);
                return this;
            }

            return this;
        }

        /// <summary>
        /// Dada uma string, adicione uma notificação se não for um Cnpj válido
        /// </summary>
        /// <param name="val">Nome da propriedade que deseja testar</param>
        /// <param name="objectName">Nome da propriedade ou objeto que representa a informação</param>
        /// <param name="message">Mensagem de erro (Opcional)</param>
        /// <returns>Dada uma string, adicione uma notificação se não for um Cnpj válido</returns>
        public Notification<T> IfNotCnpj(string val, string objectName, string message = "")
        {
            var cnpj = val;

            if (string.IsNullOrEmpty(cnpj))
            {
                _notifiable.AddNotification(objectName, string.IsNullOrEmpty(message) ? Message.IfNotCnpj.ToFormat(objectName) : message);
                return this;
            }

            int[] multiplicador1 = new int[12] { 5, 4, 3, 2, 9, 8, 7, 6, 5, 4, 3, 2 };
            int[] multiplicador2 = new int[13] { 6, 5, 4, 3, 2, 9, 8, 7, 6, 5, 4, 3, 2 };
            int soma;
            int resto;
            string digito;
            string tempCnpj;
            cnpj = cnpj.Trim();
            cnpj = cnpj.Replace(".", "").Replace("-", "").Replace("/", "");
            if (cnpj.Length != 14)
            {
                _notifiable.AddNotification(objectName, string.IsNullOrEmpty(message) ? Message.IfNotCnpj.ToFormat(objectName) : message);
                return this;
            }
            tempCnpj = cnpj.Substring(0, 12);
            soma = 0;
            for (int i = 0; i < 12; i++)
                soma += int.Parse(tempCnpj[i].ToString()) * multiplicador1[i];
            resto = (soma % 11);
            if (resto < 2)
                resto = 0;
            else
                resto = 11 - resto;
            digito = resto.ToString();
            tempCnpj = tempCnpj + digito;
            soma = 0;
            for (int i = 0; i < 13; i++)
                soma += int.Parse(tempCnpj[i].ToString()) * multiplicador2[i];
            resto = (soma % 11);
            if (resto < 2)
                resto = 0;
            else
                resto = 11 - resto;
            digito = digito + resto.ToString();
            bool isValid = cnpj.EndsWith(digito);

            if (isValid == false)
            {
                _notifiable.AddNotification(objectName, string.IsNullOrEmpty(message) ? Message.IfNotCnpj.ToFormat(objectName) : message);
                return this;
            }

            return this;
        }

        /// <summary>
        /// Dada uma string, adicione uma notificação se não for Guid
        /// </summary>
        /// <param name="val">Nome da propriedade que deseja testar</param>
        /// <param name="objectName">Nome da propriedade ou objeto que representa a informação</param>
        /// <param name="message">Mensagem de erro (Opcional)</param>
        /// <returns>Dada uma string, adicione uma notificação se não for Guid</returns>
        public Notification<T> IfNotGuid(string val, string objectName, string message = "")
        {
            var data = val;

            Guid x;

            if (Guid.TryParse(data, out x) == false)
            {
                _notifiable.AddNotification(objectName, string.IsNullOrEmpty(message) ? Message.IfNotGuid.ToFormat(objectName) : message);
            }
            return this;
        }

        /// <summary>
        /// Dada uma string, adicione uma notificação se não for uma data válida
        /// </summary>
        /// <param name="val">Nome da propriedade que deseja testar</param>
        /// <param name="objectName">Nome da propriedade ou objeto que representa a informação</param>
        /// <param name="message">Mensagem de erro (Opcional)</param>
        /// <returns>Dada uma string, adicione uma notificação se não for uma data válida</returns>
        public Notification<T> IfNotDate(string val, string objectName, string message = "")
        {
            DateTime dt;

            if (DateTime.TryParse(val, out dt) == false)
                _notifiable.AddNotification(objectName, string.IsNullOrEmpty(message) ? Message.IfNotDate.ToFormat(objectName) : message);

            return this;
        }

        /// <summary>
        /// Dada uma string, adicione uma notificação se não for igual a
        /// </summary>
        /// <param name="val">Nome da propriedade que deseja testar</param>
        /// <param name="val">Value to be compared</param>
        /// <param name="objectName">Nome da propriedade ou objeto que representa a informação</param>
        /// <param name="message">Mensagem de erro (Opcional)</param>
        /// <returns>Dada uma string, adicione uma notificação se não for igual a</returns>
        public Notification<T> IfNotAreEquals(string val, string text, string objectName, string message = "")
        {
            if (!val.Equals(text, StringComparison.OrdinalIgnoreCase))
                _notifiable.AddNotification(objectName, string.IsNullOrEmpty(message) ? Message.IfNotAreEquals.ToFormat(objectName, text) : message);

            return this;
        }
        /// <summary>
        /// Dada uma string, adicione uma notificação se for igual a
        /// </summary>
        /// <param name="val">Nome da propriedade que deseja testar</param>
        /// <param name="val">Value to be compared</param>
        /// <param name="objectName">Nome da propriedade ou objeto que representa a informação</param>
        /// <param name="message">Mensagem de erro (Opcional)</param>
        /// <returns>Dada uma string, adicione uma notificação se for igual a</returns>
        public Notification<T> IfAreEquals(string val, string text, string objectName, string message = "")
        {
            if (val.Equals(text, StringComparison.OrdinalIgnoreCase))
                _notifiable.AddNotification(objectName, string.IsNullOrEmpty(message) ? Message.IfAreEquals.ToFormat(objectName, text) : message);

            return this;
        }


        /// <summary>
        /// Dada uma string, adicione uma notificação o conteudo passado não for válido para a Regex determinada
        /// </summary>
        /// <param name="val">Nome da propriedade que deseja testar</param>
        /// <param name="regex">Regex pertinente para validação</param>
        /// <param name="objectName">Nome da propriedade ou objeto que representa a informação</param>
        /// <param name="message">Mensagem de erro (Opcional)</param>
        /// <returns>Dada uma string, adicione uma notificação se não for um endereço de e-mail válido</returns>
        public Notification<T> IfNotMatch(string val, string regex, string objectName, string message = "")
        {
            if (!Regex.IsMatch((string)val, regex))
                _notifiable.AddNotification(objectName, string.IsNullOrEmpty(message) ? Message.IfNotMatch.ToFormat(objectName) : message);

            return this;
        }
    }
}