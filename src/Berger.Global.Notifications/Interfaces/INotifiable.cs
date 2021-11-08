using System;
using System.Collections.Generic;

namespace Berger.Global.Notifications.Interfaces
{
    public interface INotifiable : IDisposable
    {
        IReadOnlyCollection<NotificationBody> Notifications { get; }

        /// <summary>
        /// Adiciona uma notificação
        /// </summary>
        /// <param name="property">Nome da propriedade que está sendo testada</param>
        /// <param name="message">Mensagem personalizada</param>
        void AddNotification(string property, string message);

        /// <summary>
        /// Adiciona uma notificação
        /// </summary>
        /// <param name="notification">Objeto de notificação que deseja adicionar</param>
        void AddNotification(NotificationBody notification);
        /// <summary>
        /// Adiciona uma lista de notificações
        /// </summary>
        /// <param name="notifications">Lista de notificações que deseja adicionar</param>
        void AddNotifications(IReadOnlyCollection<NotificationBody> notifications);

        /// <summary>
        /// Adiciona uma coleção de objetos notificaveis na classe principal
        /// </summary>
        /// <param name="objects">Objetos notificáveis</param>
        void AddNotifications(params Notifiable[] objects);
        /// <summary>
        /// Adiciona uma lista de notificações
        /// </summary>
        /// <param name="notifications">Lista de notificações que deseja adicionar</param>
        void AddNotifications(IList<NotificationBody> notifications);

        /// <summary>
        /// Adiciona uma lista de notificações
        /// </summary>
        /// <param name="notifications">Lista de notificações que deseja adicionar</param>
        void AddNotifications(ICollection<NotificationBody> notifications);
        /// <summary>
        /// Verifica se o objeto notificável é valido
        /// </summary>
        /// <returns>Retornar true quando o objeto é valido, ou seja, não possui notificações.</returns>
        bool IsValid();

        /// <summary>
        /// Verifica se existe notificações para o objeto, tornando o objeto em inválido
        /// </summary>
        /// <returns></returns>
        bool IsInvalid();

        /// <summary>
        /// Limpa todas as notificações do objeto
        /// </summary>
        void ClearNotifications();
    }
}