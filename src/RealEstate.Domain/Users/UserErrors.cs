namespace RealEstate.Domain.Users;

using RealEstate.Domain.Common.Results;

public static class UserErrors
{
    public static Error FullNameRequired =>
        Error.Validation("User_FullName_Required", "Full name is required");

    public static Error EmailRequired =>
        Error.Validation("User_Email_Required", "Email is required");

    public static Error PhoneNumberRequired =>
        Error.Validation("User_PhoneNumber_Required", "Phone number is required");

    public static Error PasswordRequired =>
        Error.Validation("User_Password_Required", "Password is required");

    public static Error NotFound =>
        Error.NotFound("User_Not_Found", "User not found");

    public static Error EmailAlreadyExists =>
        Error.Conflict("User_Email_Exists", "Email is already registered");
}