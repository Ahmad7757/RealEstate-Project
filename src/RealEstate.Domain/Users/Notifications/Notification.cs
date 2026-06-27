using RealEstate.Domain.Common;
using RealEstate.Domain.Common.Results;
using RealEstate.Domain.Users.Notifications.Enums;

namespace RealEstate.Domain.Users.Notifications;

public sealed class Notification : AuditableEntity
{
    public Guid UserId { get; private set; }
    public User User { get; private set; } = null!;

    public NotificationType Type { get; private set; }
    public string Message { get; private set; } = string.Empty;
    public bool IsRead { get; private set; }

    private Notification() { }

    private Notification(Guid id, Guid userId, NotificationType type, string message)
        : base(id)
    {
        UserId = userId;
        Type = type;
        Message = message;
        IsRead = false;
    }

    public static Result<Notification> Create(Guid userId, NotificationType type, string message)
    {
        if (string.IsNullOrWhiteSpace(message))
            return NotificationErrors.MessageRequired;

        return new Notification(Guid.NewGuid(), userId, type, message);
    }

    public void MarkAsRead() => IsRead = true;
}