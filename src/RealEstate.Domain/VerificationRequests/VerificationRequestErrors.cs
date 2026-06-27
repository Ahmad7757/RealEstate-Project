using RealEstate.Domain.Common.Results;

namespace RealEstate.Domain.VerificationRequests;

public static class VerificationRequestErrors
{
    public static Error PropertyIdRequired =>
        Error.Validation("VerificationRequest_PropertyId_Required", "Property ID is required");

    public static Error AlreadyReviewed =>
        Error.Conflict("VerificationRequest_Already_Reviewed", "This request has already been reviewed");

    public static Error ReasonRequired =>
        Error.Validation("VerificationRequest_Reason_Required", "Rejection reason is required");

    public static Error NotesRequired =>
        Error.Validation("VerificationRequest_Notes_Required", "Notes are required when requesting edits");

    public static Error NotFound =>
        Error.NotFound("VerificationRequest_Not_Found", "Verification request not found");
}