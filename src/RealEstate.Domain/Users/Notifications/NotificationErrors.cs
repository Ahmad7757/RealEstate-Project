using RealEstate.Domain.Common.Results;

namespace RealEstate.Domain.Users.Notifications;

public static class NotificationErrors
{
    public static Error MessageRequired =>
        Error.Validation("Notification_Message_Required", "Message is required");

    public static Error NotFound =>
        Error.NotFound("Notification_Not_Found", "Notification not found");
}