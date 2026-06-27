
using RealEstate.Domain.Common;
using RealEstate.Domain.Common.Results;
using RealEstate.Domain.Favorites;
using RealEstate.Domain.Properties.Enums;
using RealEstate.Domain.Properties.PropertyImages;
using RealEstate.Domain.Reports;
using RealEstate.Domain.Users;
using RealEstate.Domain.VerificationRequests;

namespace RealEstate.Domain.Properties;

public sealed class Property : AuditableEntity
{
    public Guid OwnerId { get; private set; }
    public User Owner { get; private set; } = null!;

    public string Title { get; private set; } = string.Empty;
    public string Description { get; private set; } = string.Empty;

    public PropertyType PropertyType { get; private set; }
    public LandType? LandType { get; private set; }
    public ListingType ListingType { get; private set; }
    public LegalStatus LegalStatus { get; private set; }
    public PropertyStatus Status { get; private set; }

    public decimal Price { get; private set; }
    public double Area { get; private set; }

    // Geographic
    public Governorate Governorate { get; private set; }
    public City City { get; private set; }
    public string District { get; private set; } = string.Empty;
    public string Street { get; private set; } = string.Empty;

    private readonly List<PropertyImage> _images = [];
    private readonly List<VerificationRequest> _verificationRequests = [];
    private readonly List<Favorite> _favorites = [];
    private readonly List<Report> _reports = [];

    public IEnumerable<PropertyImage> Images => _images.AsReadOnly();
    public IEnumerable<VerificationRequest> VerificationRequests => _verificationRequests.AsReadOnly();
    public IEnumerable<Favorite> Favorites => _favorites.AsReadOnly();
    public IEnumerable<Report> Reports => _reports.AsReadOnly();

    private Property() { }

    private Property(
        Guid id,
        Guid ownerId,
        string title,
        string description,
        PropertyType propertyType,
        LandType? landType,
        ListingType listingType,
        LegalStatus legalStatus,
        decimal price,
        double area,
        Governorate governorate,
        City city,
        string district,
        string street) : base(id)
    {
        OwnerId = ownerId;
        Title = title;
        Description = description;
        PropertyType = propertyType;
        LandType = landType;
        ListingType = listingType;
        LegalStatus = legalStatus;
        Status = PropertyStatus.PendingVerification;
        Price = price;
        Area = area;
        Governorate = governorate;
        City = city;
        District = district;
        Street = street;
    }

    public static Result<Property> Create(
        Guid ownerId,
        string title,
        string description,
        PropertyType propertyType,
        LandType? landType,
        ListingType listingType,
        LegalStatus legalStatus,
        decimal price,
        double area,
        Governorate governorate,
        City city,
        string district,
        string street)
    {
        if (string.IsNullOrWhiteSpace(title))
            return PropertyErrors.TitleRequired;

        if (price <= 0)
            return PropertyErrors.InvalidPrice;

        if (area <= 0)
            return PropertyErrors.InvalidArea;

        if (propertyType != PropertyType.Land && landType is not null)
            return PropertyErrors.LandTypeOnlyForLand;

        return new Property(
            Guid.NewGuid(), ownerId, title, description,
            propertyType, landType, listingType, legalStatus,
            price, area, governorate, city, district, street);
    }
}