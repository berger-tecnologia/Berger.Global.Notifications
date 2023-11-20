using System.Linq.Expressions;
using System.Text.RegularExpressions;
using Berger.Extensions.Abstractions;
using Berger.Extensions.Notification.Resources;

namespace Berger.Extensions.Notification
{
    public partial class Notification : INotification
    {
        /// <summary>
        /// Dada uma string, adicione uma notificação se for nula ou vazia
        /// </summary>
        /// <param name="selector">Nome da propriedade que deseja testar</param>
        /// <param name="message">Mensagem de erro (Opcional)</param>
        /// <returns>Dada uma string, adicione uma notificação se for nula ou vazia</returns>
        public void IfNullOrEmpty<T>(T model, Expression<Func<T, string>> selector, string message = "")
        {
            var val = selector.Compile().Invoke(model);
            var name = ((MemberExpression)selector.Body).Member.Name;

            if (string.IsNullOrEmpty(val))
                AddNotification(name, string.IsNullOrEmpty(message) ? Message.IfNullOrEmpty.ToFormat(name) : message);
        }

        /// <summary>
        /// Dada uma string, adicione uma notificação se for nula ou vazia ou com espaços em branco
        /// </summary>
        /// <param name="selector">Nome da propriedade que deseja testar</param>
        /// <param name="message">Mensagem de erro (Opcional)</param>
        /// <returns>Dada uma string, adicione uma notificação se for nula ou vazia ou com espaços em branco</returns>
        public void IfNullOrWhiteSpace<T>(T model, Expression<Func<T, string>> selector, string message = "")
        {
            var val = selector.Compile().Invoke(model);
            var name = ((MemberExpression)selector.Body).Member.Name;

            if (string.IsNullOrEmpty(val) || string.IsNullOrWhiteSpace(val))
                AddNotification(name, string.IsNullOrEmpty(message) ? Message.IfNullOrWhiteSpace.ToFormat(name) : message);
        }

        /// <summary>
        /// Dada uma string, adicione uma notificação se não for nula
        /// </summary>
        /// <param name="selector">Nome da propriedade que deseja testar</param>
        /// <param name="message">Mensagem de erro (Opcional)</param>
        /// <returns>Dada uma string, adicione uma notificação se não for nula</returns>
        public void IfNotNullOrEmpty<T>(T model, Expression<Func<T, string>> selector, string message = "")
        {
            var val = selector.Compile().Invoke(model);
            var name = ((MemberExpression)selector.Body).Member.Name;

            if (!string.IsNullOrEmpty(val))
                AddNotification(name, string.IsNullOrEmpty(message) ? Message.IfNotNullOrEmpty.ToFormat(name) : message);
        }

        /// <summary>
        /// Dada uma string, adicione uma notificação se for nula ou vazia ou com espaços em branco ou seu tamanho seja invalido
        /// </summary>
        /// <param name="selector">Nome da propriedade que deseja testar</param>
        /// <param name="message">Mensagem de erro (Opcional)</param>
        /// <returns>Dada uma string, adicione uma notificação se for nula ou vazia ou com espaços em branco ou seu tamanho seja invalido</returns>
        public void IfNullOrInvalidLength<T>(T model, Expression<Func<T, string>> selector, int min, int max, string message = "")
        {
            var val = selector.Compile().Invoke(model);
            var name = ((MemberExpression)selector.Body).Member.Name;

            if (string.IsNullOrEmpty(val) || string.IsNullOrWhiteSpace(val) || val.Length < min || val.Length > max)
                AddNotification(name, string.IsNullOrEmpty(message) ? Message.IfNullOrInvalidLength.ToFormat(name, min, max) : message);
        }

        /// <summary>
        /// Dada uma string, adicione uma notificação se seu comprimento for menor que o parâmetro min
        /// </summary>
        /// <param name="val">Nome da propriedade que deseja testar</param>
        /// <param name="min">Minimum Length</param>
        /// <param name="message">Mensagem de erro (Opcional)</param>
        /// <returns>Dada uma string, adicione uma notificação se seu comprimento for menor que o parâmetro min</returns>
        public void IfLengthLowerThan<T>(T model, Expression<Func<T, string>> selector, int min, string message = "")
        {
            var val = selector.Compile().Invoke(model);
            var name = ((MemberExpression)selector.Body).Member.Name;

            if (!string.IsNullOrEmpty((string)val) && val.Length < min)
                AddNotification(name, string.IsNullOrEmpty(message) ? Message.IfLengthLowerThan.ToFormat(name, min) : message);
        }

        /// <summary>
        /// Dada uma string, adicione uma notificação se seu comprimento for maior que o parâmetro max
        /// </summary>
        /// <param name="val">Nome da propriedade que deseja testar</param>
        /// <param name="min">Minimum Length</param>
        /// <param name="message">Mensagem de erro (Opcional)</param>
        /// <returns>Dada uma string, adicione uma notificação se seu comprimento for maior que o parâmetro max</returns>
        public void IfLengthGreaterThan<T>(T model, Expression<Func<T, string>> selector, int max, string message = "")
        {
            var val = selector.Compile().Invoke(model);
            var name = ((MemberExpression)selector.Body).Member.Name;

            if (!string.IsNullOrEmpty((string)val) && val.Length > max)
                AddNotification(name, string.IsNullOrEmpty(message) ? Message.IfLengthGreaterThan.ToFormat(name, max) : message);
        }

        /// <summary>
        /// Dada uma string, adicione uma notificação se seu comprimento for diferente do parâmetro length
        /// </summary>
        /// <param name="val">Nome da propriedade que deseja testar</param>
        /// <param name="length">Especific Length</param>
        /// <param name="message">Mensagem de erro (Opcional)</param>
        /// <returns>Dada uma string, adicione uma notificação se seu comprimento for diferente do parâmetro length</returns>
        public void IfLengthNoEqual<T>(T model, Expression<Func<T, string>> selector, int length, string message = "")
        {
            var val = selector.Compile().Invoke(model);
            var name = ((MemberExpression)selector.Body).Member.Name;

            if (string.IsNullOrEmpty((string)val) || val.Length != length)
                AddNotification(name, string.IsNullOrEmpty(message) ? Message.IfLengthNoEqual.ToFormat(name, length) : message);
        }

        /// <summary>
        /// Dada uma string, adicione uma notificação se não for um endereço de e-mail válido
        /// </summary>
        /// <param name="val">Nome da propriedade que deseja testar</param>
        /// <param name="message">Mensagem de erro (Opcional)</param>
        /// <returns>Dada uma string, adicione uma notificação se não for um endereço de e-mail válido</returns>
        public void IfNotEmail<T>(T model, Expression<Func<T, string>> selector, string message = "")
        {
            var val = selector.Compile().Invoke(model);
            var name = ((MemberExpression)selector.Body).Member.Name;

            if (!Regex.IsMatch((string)val, @"^\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*$"))
                AddNotification(name, string.IsNullOrEmpty(message) ? Message.IfNotEmail.ToFormat(name) : message);
        }

        /// <summary>
        /// Dada uma string, adicione uma notificação se não for um URL válida
        /// </summary>
        /// <param name="val">Nome da propriedade que deseja testar</param>
        /// <param name="message">Mensagem de erro (Opcional)</param>
        /// <returns>Dada uma string, adicione uma notificação se não for um URL válida</returns>
        public void IfNotUrl<T>(T model, Expression<Func<T, string>> selector, string message = "")
        {
            var val = selector.Compile().Invoke(model);
            var name = ((MemberExpression)selector.Body).Member.Name;

            if (!Regex.IsMatch((string)val, @"^(http:\/\/www\.|https:\/\/www\.|http:\/\/|https:\/\/)[a-z0-9]+([\-\.]{1}[a-z0-9]+)*\.[a-z]{2,5}(:[0-9]{1,5})?(\/.*)?$"))
                AddNotification(name, string.IsNullOrEmpty(message) ? Message.IfNotUrl.ToFormat(name) : message);
        }

        /// <summary>
        /// Dada uma string, adicione uma notificação se ela não contiver um texto
        /// </summary>
        /// <param name="val">Nome da propriedade que deseja testar</param>
        /// <param name="a">Lower value</param>
        /// <param name="b">Higher value</param>
        /// <param name="message">Mensagem de erro (Opcional)</param>
        /// <returns>Dada uma string, adicione uma notificação se ela não contiver um texto</returns>
        public void IfNotContains<T>(T model, Expression<Func<T, string>> selector, string text, string message = "")
        {
            var val = selector.Compile().Invoke(model);
            var name = ((MemberExpression)selector.Body).Member.Name;

            if (val == null || !val.Contains(text))
                AddNotification(name, string.IsNullOrEmpty(message) ? Message.IfNotContains.ToFormat(name, text) : message);
        }

        /// <summary>
        /// Dada uma string, adicione uma notificação se ela contiver um texto
        /// </summary>
        /// <param name="val">Nome da propriedade que deseja testar</param>
        /// <param name="a">Lower value</param>
        /// <param name="b">Higher value</param>
        /// <param name="message">Mensagem de erro (Opcional)</param>
        /// <returns>Dada uma string, adicione uma notificação se ela contiver um texto</returns>
        public void IfContains<T>(T model, Expression<Func<T, string>> selector, string text, string message = "")
        {
            var val = selector.Compile().Invoke(model);
            var name = ((MemberExpression)selector.Body).Member.Name;

            if (val.Contains(text))
                AddNotification(name, string.IsNullOrEmpty(message) ? Message.IfContains.ToFormat(name, text) : message);
        }

        /// <summary>
        /// Dada uma string, adicione uma notificação se não for um cpf válido
        /// </summary>
        /// <param name="val">Nome da propriedade que deseja testar</param>
        /// <param name="message">Mensagem de erro (Opcional)</param>
        /// <returns>Dada uma string, adicione uma notificação se não for um cpf válido</returns>
        public void IfNotCpf<T>(T model, Expression<Func<T, string>> selector, string message = "")
        {
            var cpf = selector.Compile().Invoke(model);
            var name = ((MemberExpression)selector.Body).Member.Name;

            if (string.IsNullOrWhiteSpace(cpf))
            {
                AddNotification(name, string.IsNullOrEmpty(message) ? Message.IfNotCpf.ToFormat(name) : message);
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
                AddNotification(name, string.IsNullOrEmpty(message) ? Message.IfNotCpf.ToFormat(name) : message);
            }

            tempCpf = cpf[..9];
            soma = 0;

            for (int i = 0; i < 9; i++)
                soma += int.Parse(tempCpf[i].ToString()) * multiplicador1[i];
            resto = soma % 11;
            if (resto < 2)
                resto = 0;
            else
                resto = 11 - resto;
            digito = resto.ToString();
            tempCpf += digito;
            soma = 0;
            for (int i = 0; i < 10; i++)
                soma += int.Parse(tempCpf[i].ToString()) * multiplicador2[i];
            resto = soma % 11;
            if (resto < 2)
                resto = 0;
            else
                resto = 11 - resto;
            digito += resto.ToString();
            bool isValid = cpf.EndsWith(digito);

            if (isValid == false)
            {
                AddNotification(name, string.IsNullOrEmpty(message) ? Message.IfNotCpf.ToFormat(name) : message);
            }
        }

        /// <summary>
        /// Dada uma string, adicione uma notificação se não for um Cnpj válido
        /// </summary>
        /// <param name="selector">Nome da propriedade que deseja testar</param>
        /// <param name="message">Mensagem de erro (Opcional)</param>
        /// <returns>Dada uma string, adicione uma notificação se não for um Cnpj válido</returns>
        public void IfNotCnpj<T>(T model, Expression<Func<T, string>> selector, string message = "")
        {
            var cnpj = selector.Compile().Invoke(model);
            var name = ((MemberExpression)selector.Body).Member.Name;

            if (string.IsNullOrEmpty(cnpj))
            {
                AddNotification(name, string.IsNullOrEmpty(message) ? Message.IfNotCnpj.ToFormat(name) : message);
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
                AddNotification(name, string.IsNullOrEmpty(message) ? Message.IfNotCnpj.ToFormat(name) : message);

            }
            tempCnpj = cnpj[..12];
            soma = 0;
            for (int i = 0; i < 12; i++)
                soma += int.Parse(tempCnpj[i].ToString()) * multiplicador1[i];
            resto = (soma % 11);
            if (resto < 2)
                resto = 0;
            else
                resto = 11 - resto;
            digito = resto.ToString();
            tempCnpj += digito;
            soma = 0;
            for (int i = 0; i < 13; i++)
                soma += int.Parse(tempCnpj[i].ToString()) * multiplicador2[i];
            resto = (soma % 11);
            if (resto < 2)
                resto = 0;
            else
                resto = 11 - resto;
            digito += resto.ToString();
            bool isValid = cnpj.EndsWith(digito);

            if (isValid == false)
            {
                AddNotification(name, string.IsNullOrEmpty(message) ? Message.IfNotCnpj.ToFormat(name) : message);
            }
        }

        /// <summary>
        /// Dada uma string, adicione uma notificação se não for Guid
        /// </summary>
        /// <param name="selector">Nome da propriedade que deseja testar</param>
        /// <param name="message">Mensagem de erro (Opcional)</param>
        /// <returns>Dada uma string, adicione uma notificação se não for Guid</returns>
        public void IfNotGuid<T>(T model, Expression<Func<T, string>> selector, string message = "")
        {
            var data = selector.Compile().Invoke(model);
            var name = ((MemberExpression)selector.Body).Member.Name;

            if (Guid.TryParse(data, result: out _) == false)
            {
                AddNotification(name, string.IsNullOrEmpty(message) ? Message.IfNotGuid.ToFormat(name) : message);
            }
        }

        /// <summary>
        /// Dada uma string, adicione uma notificação se não for uma data válida
        /// </summary>
        /// <param name="selector">Nome da propriedade que deseja testar</param>
        /// <param name="message">Mensagem de erro (Opcional)</param>
        /// <returns>Dada uma string, adicione uma notificação se não for uma data válida</returns>
        public void IfNotDate<T>(T model, Expression<Func<T, string>> selector, string message = "")
        {
            var val = selector.Compile().Invoke(model);
            var name = ((MemberExpression)selector.Body).Member.Name;

            if (DateTime.TryParse(val, out _) == false)
                AddNotification(name, string.IsNullOrEmpty(message) ? Message.IfNotDate.ToFormat(name) : message);
        }

        /// <summary>
        /// Dada uma string, adicione uma notificação se não for igual a
        /// </summary>
        /// <param name="selector">Nome da propriedade que deseja testar</param>
        /// <param name="val">Value to be compared</param>
        /// <param name="message">Mensagem de erro (Opcional)</param>
        /// <returns>Dada uma string, adicione uma notificação se não for igual a</returns>
        public void IfNotAreEquals<T>(T model, Expression<Func<T, string>> selector, string text, string message = "")
        {
            var val = selector.Compile().Invoke(model);
            var name = ((MemberExpression)selector.Body).Member.Name;

            if (!val.Equals(text, StringComparison.OrdinalIgnoreCase))
                AddNotification(name, string.IsNullOrEmpty(message) ? Message.IfNotAreEquals.ToFormat(name, text) : message);
        }
        /// <summary>
        /// Dada uma string, adicione uma notificação se for igual a
        /// </summary>
        /// <param name="selector">Nome da propriedade que deseja testar</param>
        /// <param name="val">Value to be compared</param>
        /// <param name="message">Mensagem de erro (Opcional)</param>
        /// <returns>Dada uma string, adicione uma notificação se for igual a</returns>
        public void IfAreEquals<T>(T model, Expression<Func<T, string>> selector, string text, string message = "")
        {
            var val = selector.Compile().Invoke(model);
            var name = ((MemberExpression)selector.Body).Member.Name;

            if (val.Equals(text, StringComparison.OrdinalIgnoreCase))
                AddNotification(name, string.IsNullOrEmpty(message) ? Message.IfAreEquals.ToFormat(name, text) : message);
        }

        /// <summary>
        /// Dada uma string, adicione uma notificação o conteudo passado não for válido para a Regex determinada
        /// </summary>
        /// <param name="val">Nome da propriedade que deseja testar</param>
        /// <param name="regex">Regex pertinente para validação</param>
        /// <param name="objectName">Nome da propriedade ou objeto que representa a informação</param>
        /// <param name="message">Mensagem de erro (Opcional)</param>
        /// <returns>Dada uma string, adicione uma notificação se não for um endereço de e-mail válido</returns>
        public void IfNotMatch<T>(T model, Expression<Func<T, string>> selector, string regex, string message = "")
        {
            var val = selector.Compile().Invoke(model);
            var name = ((MemberExpression)selector.Body).Member.Name;

            if (!Regex.IsMatch((string)val, regex))
                AddNotification(name, string.IsNullOrEmpty(message) ? Message.IfNotMatch.ToFormat(name) : message);
        }

        /// <summary>
        /// Dada uma string, adicione uma notificação se for nula ou vazia
        /// </summary>
        /// <param name="val">Valor informado</param>
        /// <param name="objectName">Nome da propriedade ou objeto que representa a informação</param>
        /// <param name="message"></param>
        /// <returns></returns>
        public void IfNullOrEmpty(string val, string objectName, string message = null)
        {
            if (string.IsNullOrEmpty(val))
                AddNotification(objectName, string.IsNullOrWhiteSpace(message) ? Message.IfNullOrEmpty.ToFormat(objectName) : message);
        }

        /// <summary>
        /// Dada uma string, adicione uma notificação se for nula ou contenha apenas espaços
        /// </summary>
        /// <param name="val">Valor informado</param>
        /// <param name="objectName">Nome da propriedade ou objeto que representa a informação</param>
        /// <param name="message"></param>
        /// <returns></returns>
        public void IfNullOrWhiteSpace(string val, string objectName, string message = "")
        {
            if (string.IsNullOrWhiteSpace(val))
                AddNotification(objectName, string.IsNullOrWhiteSpace(message) ? Message.IfNullOrWhiteSpace.ToFormat(objectName) : message);
        }

        /// <summary>
        /// Dada uma string, adicione uma notificação se não for nula
        /// </summary>
        /// <param name="val">Valor informado</param>
        /// <param name="objectName">Nome da propriedade ou objeto que representa a informação</param>
        /// <param name="message">Mensagem de erro (Opcional)</param>
        /// <returns>Dada uma string, adicione uma notificação se não for nula</returns>
        public void IfNotNullOrEmpty(string val, string objectName, string message = "")
        {
            if (!string.IsNullOrEmpty(val))
                AddNotification(objectName, string.IsNullOrWhiteSpace(message) ? Message.IfNotNullOrEmpty.ToFormat(objectName) : message);
        }

        /// <summary>
        /// Dada uma string, adicione uma notificação se for nula ou vazia ou com espaços em branco ou seu tamanho seja invalido
        /// </summary>
        /// <param name="val">Valor informado</param>
        /// <param name="objectName">Nome da propriedade ou objeto que representa a informação</param>
        /// <param name="message">Mensagem de erro (Opcional)</param>
        /// <returns>Dada uma string, adicione uma notificação se for nula ou vazia ou com espaços em branco ou seu tamanho seja invalido</returns>
        public void IfNullOrInvalidLength(string val, int min, int max, string objectName, string message = "")
        {
            if (string.IsNullOrEmpty(val) || string.IsNullOrWhiteSpace(val) || val.Length < min || val.Length > max)
                AddNotification(objectName, string.IsNullOrEmpty(message) ? Message.IfNullOrInvalidLength.ToFormat(objectName, min, max) : message);
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
        public void IfLengthLowerThan(string val, int min, string objectName, string message = "")
        {
            if (!string.IsNullOrEmpty((string)val) && val.Length < min)
                AddNotification(objectName, string.IsNullOrEmpty(message) ? Message.IfLengthLowerThan.ToFormat(objectName, min) : message);
        }

        /// <summary>
        /// Dada uma string, adicione uma notificação se seu comprimento for maior que o parâmetro max
        /// </summary>
        /// <param name="val">Nome da propriedade que deseja testar</param>
        /// <param name="min">Minimum Length</param>
        /// <param name="objectName">Nome da propriedade ou objeto que representa a informação</param>
        /// <param name="message">Mensagem de erro (Opcional)</param>
        /// <returns>Dada uma string, adicione uma notificação se seu comprimento for maior que o parâmetro max</returns>
        public void IfLengthGreaterThan(string val, int max, string objectName, string message = "")
        {
            if (!string.IsNullOrEmpty((string)val) && val.Length > max)
                AddNotification(objectName, string.IsNullOrEmpty(message) ? Message.IfLengthGreaterThan.ToFormat(objectName, max) : message);
        }

        /// <summary>
        /// Dada uma string, adicione uma notificação se seu comprimento for diferente do parâmetro length
        /// </summary>
        /// <param name="val">Nome da propriedade que deseja testar</param>
        /// <param name="length">Especific Length</param>
        /// <param name="objectName">Nome da propriedade ou objeto que representa a informação</param>
        /// <param name="message">Mensagem de erro (Opcional)</param>
        /// <returns>Dada uma string, adicione uma notificação se seu comprimento for diferente do parâmetro length</returns>
        public void IfLengthNoEqual(string val, int length, string objectName, string message = "")
        {
            if (string.IsNullOrEmpty((string)val) || val.Length != length)
                AddNotification(objectName, string.IsNullOrEmpty(message) ? Message.IfLengthNoEqual.ToFormat(objectName, length) : message);
        }

        /// <summary>
        /// Dada uma string, adicione uma notificação se não for um endereço de e-mail válido
        /// </summary>
        /// <param name="val">Nome da propriedade que deseja testar</param>
        /// <param name="objectName">Nome da propriedade ou objeto que representa a informação</param>
        /// <param name="message">Mensagem de erro (Opcional)</param>
        /// <returns>Dada uma string, adicione uma notificação se não for um endereço de e-mail válido</returns>
        public void IfNotEmail(string val, string objectName, string message = "")
        {
            if (!Regex.IsMatch((string)val, @"^\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*$"))
                AddNotification(objectName, string.IsNullOrEmpty(message) ? Message.IfNotEmail.ToFormat(objectName) : message);
        }

        /// <summary>
        /// Dada uma string, adicione uma notificação se não for um URL válida
        /// </summary>
        /// <param name="val">Nome da propriedade que deseja testar</param>
        /// <param name="objectName">Nome da propriedade ou objeto que representa a informação</param>
        /// <param name="message">Mensagem de erro (Opcional)</param>
        /// <returns>Dada uma string, adicione uma notificação se não for um URL válida</returns>
        public void IfNotUrl(string val, string objectName, string message = "")
        {
            if (!Regex.IsMatch(val, @"^(http:\/\/www\.|https:\/\/www\.|http:\/\/|https:\/\/)[a-z0-9]+([\-\.]{1}[a-z0-9]+)*\.[a-z]{2,5}(:[0-9]{1,5})?(\/.*)?$"))
                AddNotification(objectName, string.IsNullOrEmpty(message) ? Message.IfNotUrl.ToFormat(objectName) : message);
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
        public void IfNotContains(string val, string text, string objectName, string message = "")
        {
            if (val == null || !val.Contains(text))
                AddNotification(objectName, string.IsNullOrEmpty(message) ? Message.IfNotContains.ToFormat(objectName, text) : message);
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
        public void IfContains(string val, string text, string objectName, string message = "")
        {
            if (val.Contains(text))
                AddNotification(objectName, string.IsNullOrEmpty(message) ? Message.IfContains.ToFormat(objectName, text) : message);
        }

        /// <summary>
        /// Dada uma string, adicione uma notificação se não for um cpf válido
        /// </summary>
        /// <param name="val">Nome da propriedade que deseja testar</param>
        /// <param name="objectName">Nome da propriedade ou objeto que representa a informação</param>
        /// <param name="message">Mensagem de erro (Opcional)</param>
        /// <returns>Dada uma string, adicione uma notificação se não for um cpf válido</returns>
        public void IfNotCpf(string val, string objectName, string message = "")
        {
            var cpf = val;

            if (string.IsNullOrWhiteSpace(cpf))
            {
                AddNotification(objectName, string.IsNullOrEmpty(message) ? Message.IfNotCpf.ToFormat(objectName) : message);
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
                AddNotification(objectName, string.IsNullOrEmpty(message) ? Message.IfNotCpf.ToFormat(objectName) : message);
            }

            tempCpf = cpf[..9];
            soma = 0;

            for (int i = 0; i < 9; i++)
                soma += int.Parse(tempCpf[i].ToString()) * multiplicador1[i];
            resto = soma % 11;
            if (resto < 2)
                resto = 0;
            else
                resto = 11 - resto;
            digito = resto.ToString();
            tempCpf += digito;
            soma = 0;
            for (int i = 0; i < 10; i++)
                soma += int.Parse(tempCpf[i].ToString()) * multiplicador2[i];
            resto = soma % 11;
            if (resto < 2)
                resto = 0;
            else
                resto = 11 - resto;
            digito += resto.ToString();
            bool isValid = cpf.EndsWith(digito);

            if (isValid == false)
            {
                AddNotification(objectName, string.IsNullOrEmpty(message) ? Message.IfNotCpf.ToFormat(objectName) : message);
            }
        }

        /// <summary>
        /// Dada uma string, adicione uma notificação se não for um Cnpj válido
        /// </summary>
        /// <param name="val">Nome da propriedade que deseja testar</param>
        /// <param name="objectName">Nome da propriedade ou objeto que representa a informação</param>
        /// <param name="message">Mensagem de erro (Opcional)</param>
        /// <returns>Dada uma string, adicione uma notificação se não for um Cnpj válido</returns>
        public void IfNotCnpj(string val, string objectName, string message = "")
        {
            var cnpj = val;

            if (string.IsNullOrEmpty(cnpj))
            {
                AddNotification(objectName, string.IsNullOrEmpty(message) ? Message.IfNotCnpj.ToFormat(objectName) : message);

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
                AddNotification(objectName, string.IsNullOrEmpty(message) ? Message.IfNotCnpj.ToFormat(objectName) : message);

            }
            tempCnpj = cnpj[..12];
            soma = 0;
            for (int i = 0; i < 12; i++)
                soma += int.Parse(tempCnpj[i].ToString()) * multiplicador1[i];
            resto = (soma % 11);
            if (resto < 2)
                resto = 0;
            else
                resto = 11 - resto;
            digito = resto.ToString();
            tempCnpj += digito;
            soma = 0;
            for (int i = 0; i < 13; i++)
                soma += int.Parse(tempCnpj[i].ToString()) * multiplicador2[i];
            resto = (soma % 11);
            if (resto < 2)
                resto = 0;
            else
                resto = 11 - resto;
            digito += resto.ToString();
            bool isValid = cnpj.EndsWith(digito);

            if (isValid == false)
            {
                AddNotification(objectName, string.IsNullOrEmpty(message) ? Message.IfNotCnpj.ToFormat(objectName) : message);
            }
        }

        /// <summary>
        /// Dada uma string, adicione uma notificação se não for Guid
        /// </summary>
        /// <param name="val">Nome da propriedade que deseja testar</param>
        /// <param name="objectName">Nome da propriedade ou objeto que representa a informação</param>
        /// <param name="message">Mensagem de erro (Opcional)</param>
        /// <returns>Dada uma string, adicione uma notificação se não for Guid</returns>
        public void IfNotGuid(string val, string objectName, string message = "")
        {
            var data = val;
            if (Guid.TryParse(data, out _) == false)
            {
                AddNotification(objectName, string.IsNullOrEmpty(message) ? Message.IfNotGuid.ToFormat(objectName) : message);
            }
        }

        /// <summary>
        /// Dada uma string, adicione uma notificação se não for uma data válida
        /// </summary>
        /// <param name="val">Nome da propriedade que deseja testar</param>
        /// <param name="objectName">Nome da propriedade ou objeto que representa a informação</param>
        /// <param name="message">Mensagem de erro (Opcional)</param>
        /// <returns>Dada uma string, adicione uma notificação se não for uma data válida</returns>
        public void IfNotDate(string val, string objectName, string message = "")
        {
            if (DateTime.TryParse(val, out _) == false)
                AddNotification(objectName, string.IsNullOrEmpty(message) ? Message.IfNotDate.ToFormat(objectName) : message);
        }

        /// <summary>
        /// Dada uma string, adicione uma notificação se não for igual a
        /// </summary>
        /// <param name="val">Nome da propriedade que deseja testar</param>
        /// <param name="val">Value to be compared</param>
        /// <param name="objectName">Nome da propriedade ou objeto que representa a informação</param>
        /// <param name="message">Mensagem de erro (Opcional)</param>
        /// <returns>Dada uma string, adicione uma notificação se não for igual a</returns>
        public void IfNotAreEquals(string val, string text, string objectName, string message = "")
        {
            if (!val.Equals(text, StringComparison.OrdinalIgnoreCase))
                AddNotification(objectName, string.IsNullOrEmpty(message) ? Message.IfNotAreEquals.ToFormat(objectName, text) : message);
        }
        /// <summary>
        /// Dada uma string, adicione uma notificação se for igual a
        /// </summary>
        /// <param name="val">Nome da propriedade que deseja testar</param>
        /// <param name="val">Value to be compared</param>
        /// <param name="objectName">Nome da propriedade ou objeto que representa a informação</param>
        /// <param name="message">Mensagem de erro (Opcional)</param>
        /// <returns>Dada uma string, adicione uma notificação se for igual a</returns>
        public void IfAreEquals(string val, string text, string objectName, string message = "")
        {
            if (val.Equals(text, StringComparison.OrdinalIgnoreCase))
                AddNotification(objectName, string.IsNullOrEmpty(message) ? Message.IfAreEquals.ToFormat(objectName, text) : message);
        }

        /// <summary>
        /// Dada uma string, adicione uma notificação o conteudo passado não for válido para a Regex determinada
        /// </summary>
        /// <param name="val">Nome da propriedade que deseja testar</param>
        /// <param name="regex">Regex pertinente para validação</param>
        /// <param name="objectName">Nome da propriedade ou objeto que representa a informação</param>
        /// <param name="message">Mensagem de erro (Opcional)</param>
        /// <returns>Dada uma string, adicione uma notificação se não for um endereço de e-mail válido</returns>
        public void IfNotMatch(string val, string regex, string objectName, string message = "")
        {
            if (!Regex.IsMatch((string)val, regex))
                AddNotification(objectName, string.IsNullOrEmpty(message) ? Message.IfNotMatch.ToFormat(objectName) : message);
        }
    }
}