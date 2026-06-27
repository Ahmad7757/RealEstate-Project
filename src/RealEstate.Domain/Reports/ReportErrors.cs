using RealEstate.Domain.Common.Results;

namespace RealEstate.Domain.Reports;

public static class ReportErrors
{
    public static Error PropertyIdRequired =>
        Error.Validation("Report_PropertyId_Required", "Property ID is required");

    public static Error UserIdRequired =>
        Error.Validation("Report_UserId_Required", "User ID is required");

    public static Error NotFound =>
        Error.NotFound("Report_Not_Found", "Report not found");
}