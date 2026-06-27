// PropertyStatusChangedEvent.cs
namespace RealEstate.Domain.Properties.Events;

using RealEstate.Domain.Common;
using RealEstate.Domain.Properties.Enums;

public sealed record PropertyStatusChangedEvent(
    Guid PropertyId,
    Guid OwnerId,
    PropertyStatus NewStatus,
    string? Notes = null) : DomainEvent;