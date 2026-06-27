using MediatR;
namespace RealEstate.Domain.Common;
public abstract record DomainEvent : INotification;