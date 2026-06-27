using RealEstate.Domain.Common.Results;

namespace RealEstate.Domain.Favorites;

public static class FavoriteErrors
{
    public static Error UserIdRequired =>
        Error.Validation("Favorite_UserId_Required", "User ID is required");

    public static Error PropertyIdRequired =>
        Error.Validation("Favorite_PropertyId_Required", "Property ID is required");

    public static Error NotFound =>
        Error.NotFound("Favorite_Not_Found", "Favorite not found");

    public static Error AlreadyExists =>
        Error.Conflict("Favorite_Already_Exists", "Property is already in favorites");
}