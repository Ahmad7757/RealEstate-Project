using RealEstate.Domain.Common.Results;

namespace RealEstate.Domain.Properties;

public static class PropertyErrors
{
    public static Error TitleRequired =>
        Error.Validation("Property_Title_Required", "Title is required");

    public static Error InvalidPrice =>
        Error.Validation("Property_Invalid_Price", "Price must be greater than zero");

    public static Error InvalidArea =>
        Error.Validation("Property_Invalid_Area", "Area must be greater than zero");

    public static Error LandTypeOnlyForLand =>
        Error.Validation("Property_LandType_Invalid", "LandType is only applicable for Land properties");

    public static Error NotFound =>
        Error.NotFound("Property_Not_Found", "Property not found");
}