using RealEstate.Domain.Common;
using RealEstate.Domain.Common.Results;
using RealEstate.Domain.Properties;
using RealEstate.Domain.Reports.Enums;
using RealEstate.Domain.Users;

namespace RealEstate.Domain.Reports;

public sealed class Report : AuditableEntity
{
    public Guid PropertyId { get; private set; }
    public Property Property { get; private set; } = null!;

    public Guid ReportedByUserId { get; private set; }
    public User ReportedByUser { get; private set; } = null!;

    public ReportReason Reason { get; private set; }
    public string? Description { get; private set; }
    public ReportStatus Status { get; private set; }

    private Report() { }

    private Report(Guid id, Guid propertyId, Guid reportedByUserId, ReportReason reason, string? description)
        : base(id)
    {
        PropertyId = propertyId;
        ReportedByUserId = reportedByUserId;
        Reason = reason;
        Description = description;
        Status = ReportStatus.Pending;
    }

    public static Result<Report> Create(Guid propertyId, Guid reportedByUserId, ReportReason reason, string? description)
    {
        if (propertyId == Guid.Empty)
            return ReportErrors.PropertyIdRequired;

        if (reportedByUserId == Guid.Empty)
            return ReportErrors.UserIdRequired;

        return new Report(Guid.NewGuid(), propertyId, reportedByUserId, reason, description);
    }

    public void MarkAsReviewed() => Status = ReportStatus.Reviewed;
    public void MarkAsResolved() => Status = ReportStatus.Resolved;
    public void MarkAsDismissed() => Status = ReportStatus.Dismissed;
}