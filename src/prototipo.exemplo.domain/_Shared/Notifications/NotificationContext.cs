using FluentValidation.Results;
using Prototipo.Exemplo.Domain._Shared.Validations;

namespace Prototipo.Exemplo.Domain._Shared.Notifications;

public interface INotificationContext
{
    public IReadOnlyCollection<Notification> Notifications { get; }
    public bool HasNotifications { get; }

    public void AddNotification(string propertyName, string errorCode, string message);
    public void AddNotifications(ValidationResult validationResult);
    public void AddNotifications(IEnumerable<InfoValidation> infoValidations);
}

public class NotificationContext : INotificationContext
{
    private readonly List<Notification> notifications;
    public IReadOnlyCollection<Notification> Notifications => notifications;
    public bool HasNotifications => notifications.Any();


    public NotificationContext()
    {
        notifications = new List<Notification>();
    }


    public void AddNotification(string propertyName, string errorCode, string message) => notifications.Add(new Notification(propertyName, errorCode, message));

    public void AddNotifications(ValidationResult validationResult)
    {
        foreach (var error in validationResult.Errors)
        {
            AddNotification(error.PropertyName, error.ErrorCode, error.ErrorMessage);
        }
    }

    public void AddNotifications(IEnumerable<InfoValidation> infoValidations)
    {
        foreach (var infoValidation in infoValidations)
        {
            AddNotification(infoValidation.Atributo, infoValidation.Regra, infoValidation.Mensagem);
        }
    }
}