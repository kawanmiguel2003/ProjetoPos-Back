using ProjetoPos.Infra.CrossCutting.NotificationPattern.DTOs;
using FluentValidation.Results;

namespace ProjetoPos.Infra.CrossCutting.NotificationPattern.Interface
{
    public interface INotifiable
    {
        IReadOnlyCollection<Notification> Notifications { get; }

        void AddNotification(string property, string message);
        void AddNotification(Notification notification);
        void AddNotifications(IReadOnlyCollection<Notification> notifications);
        void AddNotifications(ValidationResult validationResult);
        bool IsValid();
        bool IsInvalid();
        void ClearNotifications();
    }
}
