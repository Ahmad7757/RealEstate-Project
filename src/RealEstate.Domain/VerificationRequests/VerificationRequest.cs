using RealEstate.Domain.Common;
using RealEstate.Domain.Common.Results;
using RealEstate.Domain.Properties;
using RealEstate.Domain.Users;
using RealEstate.Domain.VerificationRequests.Enums;

namespace RealEstate.Domain.VerificationRequests;

public sealed class VerificationRequest : AuditableEntity
{
    public Guid PropertyId { get; private set; }
    public Property Property { get; private set; } = null!;

    public Guid? ReviewedByUserId { get; private set; }
    public User? ReviewedByUser { get; private set; }

    public VerificationStatus Status { get; private set; }
    public string? Notes { get; private set; }
    public DateTime? ReviewedAt { get; private set; }

    private VerificationRequest() { }

    private VerificationRequest(Guid id, Guid propertyId) : base(id)
    {
        PropertyId = propertyId;
        Status = VerificationStatus.Pending;
    }

    public static Result<VerificationRequest> Create(Guid propertyId)
    {
        if (propertyId == Guid.Empty)
            return VerificationRequestErrors.PropertyIdRequired;

        return new VerificationRequest(Guid.NewGuid(), propertyId);
    }

    public Result<Success> Approve(Guid reviewedByUserId)
    {
        if (Status != VerificationStatus.Pending)
            return VerificationRequestErrors.AlreadyReviewed;

        Status = VerificationStatus.Approved;
        ReviewedByUserId = reviewedByUserId;
        ReviewedAt = DateTime.UtcNow;
        
        return Result.Success;
    }

    public Result<Success> Reject(Guid reviewedByUserId, string reason)
    {
        if (Status != VerificationStatus.Pending)
            return VerificationRequestErrors.AlreadyReviewed;

        if (string.IsNullOrWhiteSpace(reason))
            return VerificationRequestErrors.ReasonRequired;

        Status = VerificationStatus.Rejected;
        ReviewedByUserId = reviewedByUserId;
        ReviewedAt = DateTime.UtcNow;
        Notes = reason;
        
        return Result.Success;
    }

    public Result<Success> RequestEdits(Guid reviewedByUserId, string notes)
    {
        if (Status != VerificationStatus.Pending)
            return VerificationRequestErrors.AlreadyReviewed;

        if (string.IsNullOrWhiteSpace(notes))
            return VerificationRequestErrors.NotesRequired;

        Status = VerificationStatus.NeedsEdits;
        ReviewedByUserId = reviewedByUserId;
        ReviewedAt = DateTime.UtcNow;
        Notes = notes;
        
        return Result.Success;
    }
}