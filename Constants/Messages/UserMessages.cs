// Constants/Messages/UserMessages.cs
namespace eShopApi.Constants.Messages
{
    public static class UserMessages
    {
        // Field: Username
        public const string UsernameIsRequired = "Username is required.";
        public const string UsernameLengthInvalid = "Username must be between 3 and 50 characters long.";
        public const string UsernameInvalidCharacters = "Username may only contain lowercase letters, and numbers.";
        public const string UsernameNoWhitespace = "Username cannot contain spaces.";
        public const string UsernameCannotStartWithNumber = "Username cannot start with a number.";
        public const string UsernameAlreadyExists = "Username already exists.";
        // Field: Email
        public const string EmailIsRequired = "Email is required.";
        public const string EmailInvalidFormat = "Invalid email format.";
        public const string EmailAlreadyExists = "Email already exists.";
        // Field: Password
        public const string PasswordIsRequired = "Password is required.";
        public const string PasswordMinimumLength = "Password must be at least 6 characters long.";
        public const string PasswordRequiresUppercase = "Password must contain at least one uppercase letter.";
        public const string PasswordRequiresLowercase = "Password must contain at least one lowercase letter.";
        public const string PasswordRequiresDigit = "Password must contain at least one digit.";
        public const string PasswordRequiresNonAlphanumeric = "Password must contain at least one special character.";
        // Field: Confirm Password
        public const string ConfirmPasswordIsRequired = "Password confirmation is required.";
        public const string ConfirmPasswordMismatch = "Password and confirmation password do not match.";
        // Field: Firstname
        public const string FirstNameIsRequired = "First name is required.";
        public const string FirstNameLengthInvalid = "First name must be between 2 and 50 characters long.";
        // Field: Lastname
        public const string LastNameIsRequired = "Last name is required.";
        public const string LastNameLengthInvalid = "Last name must be between 2 and 50 characters long.";
        // Field: DateOfBirth
        public const string DateOfBirthIsRequired = "Date of birth is required.";
        public const string DateOfBirthMustBeInPast = "Date of birth must be a past date.";
        public const string MinimumAgeRequired = "You must be at least 18 years old to register.";
    }
}
