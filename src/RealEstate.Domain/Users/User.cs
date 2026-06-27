namespace RealEstate.Domain.Users;

using RealEstate.Domain.Common;
using RealEstate.Domain.Common.Results;
using RealEstate.Domain.Favorites;
using RealEstate.Domain.Properties;
using RealEstate.Domain.Reports;
using RealEstate.Domain.Users.Enums;
using RealEstate.Domain.Users.Notifications;

public sealed class User : AuditableEntity
{
    public string FullName { get; private set; } = string.Empty;
    public string Email { get; private set; } = string.Empty;
    public string PasswordHash { get; private set; } = string.Empty;
    public string PhoneNumber { get; private set; } = string.Empty;
    public Role Role { get; private set; }
    public bool IsActive { get; private set; } = true;

    private readonly List<Property> _properties = [];
    private readonly List<Favorite> _favorites = [];
    private readonly List<Notification> _notifications = [];
    private readonly List<Report> _reports = [];

    public IEnumerable<Property> Properties => _properties.AsReadOnly();
    public IEnumerable<Favorite> Favorites => _favorites.AsReadOnly();
    public IEnumerable<Notification> Notifications => _notifications.AsReadOnly();
    public IEnumerable<Report> Reports => _reports.AsReadOnly();

    private User() { }

    private User(Guid id, string fullName, string email, string passwordHash, string phoneNumber, Role role)
        : base(id)
    {
        FullName = fullName;
        Email = email;
        PasswordHash = passwordHash;
        PhoneNumber = phoneNumber;
        Role = role;
        IsActive = true;
    }

    public static Result<User> Create(string fullName, string email, string passwordHash, string phoneNumber, Role role)
    {
        if (string.IsNullOrWhiteSpace(fullName))
            return UserErrors.FullNameRequired;

        if (string.IsNullOrWhiteSpace(email))
            return UserErrors.EmailRequired;

        if (string.IsNullOrWhiteSpace(phoneNumber))
            return UserErrors.PhoneNumberRequired;

        if (string.IsNullOrWhiteSpace(passwordHash))
            return UserErrors.PasswordRequired;

        return new User(Guid.NewGuid(), fullName, email, passwordHash, phoneNumber, role);
    }

    public void Deactivate() => IsActive = false;
    public void Activate() => IsActive = true;
}