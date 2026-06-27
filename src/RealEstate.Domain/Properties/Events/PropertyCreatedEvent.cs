using RealEstate.Domain.Common;

namespace RealEstate.Domain.Properties.Events;

public sealed record PropertyCreatedEvent(Guid PropertyId) : DomainEvent;