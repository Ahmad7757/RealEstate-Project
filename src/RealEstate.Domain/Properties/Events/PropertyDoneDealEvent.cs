// PropertyDoneDealEvent.cs
namespace RealEstate.Domain.Properties.Events;

using RealEstate.Domain.Common;
using RealEstate.Domain.Properties.Enums;

public sealed record PropertyDoneDealEvent(
    Guid PropertyId,
    Guid OwnerId,
    ListingType DealType) : DomainEvent;