namespace RealEstate.Domain.Properties.PropertyImages;

using RealEstate.Domain.Common;
using RealEstate.Domain.Common.Results;

public sealed class PropertyImage : AuditableEntity
{
    public Guid PropertyId { get; private set; }
    public Property Property { get; private set; } = null!;

    public string ImageUrl { get; private set; } = string.Empty;
    public bool IsMain { get; private set; }
    public int DisplayOrder { get; private set; }

    private PropertyImage() { }

    private PropertyImage(Guid id, Guid propertyId, string imageUrl, bool isMain, int displayOrder)
        : base(id)
    {
        PropertyId = propertyId;
        ImageUrl = imageUrl;
        IsMain = isMain;
        DisplayOrder = displayOrder;
    }

    public static Result<PropertyImage> Create(Guid propertyId, string imageUrl, bool isMain, int displayOrder)
    {
        if (string.IsNullOrWhiteSpace(imageUrl))
            return PropertyImageErrors.UrlRequired;

        if (displayOrder < 0)
            return PropertyImageErrors.InvalidDisplayOrder;

        return new PropertyImage(Guid.NewGuid(), propertyId, imageUrl, isMain, displayOrder);
    }
}