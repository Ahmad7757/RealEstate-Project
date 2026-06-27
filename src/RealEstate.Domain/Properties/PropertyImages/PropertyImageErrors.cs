namespace RealEstate.Domain.Properties.PropertyImages;

using RealEstate.Domain.Common.Results;

public static class PropertyImageErrors
{
    public static Error UrlRequired =>
        Error.Validation("PropertyImage_Url_Required", "Image URL is required");

    public static Error InvalidDisplayOrder =>
        Error.Validation("PropertyImage_Invalid_DisplayOrder", "Display order must be zero or greater");

    public static Error NotFound =>
        Error.NotFound("PropertyImage_Not_Found", "Property image not found");
}