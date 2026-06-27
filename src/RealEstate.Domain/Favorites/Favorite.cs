using RealEstate.Domain.Common;
using RealEstate.Domain.Common.Results;
using RealEstate.Domain.Properties;
using RealEstate.Domain.Users;

namespace RealEstate.Domain.Favorites;

public sealed class Favorite : AuditableEntity
{
    public Guid UserId { get; private set; }
    public User User { get; private set; } = null!;
    public Guid PropertyId { get; private set; }
    public Property Property { get; private set; } = null!;

    private Favorite() { }

    private Favorite(Guid id, Guid userId, Guid propertyId) : base(id)
    {
        UserId = userId;
        PropertyId = propertyId;
    }

    public static Result<Favorite> Create(Guid userId, Guid propertyId)
    {
        if (userId == Guid.Empty)
            return FavoriteErrors.UserIdRequired;

        if (propertyId == Guid.Empty)
            return FavoriteErrors.PropertyIdRequired;

        return new Favorite(Guid.NewGuid(), userId, propertyId);
    }
}