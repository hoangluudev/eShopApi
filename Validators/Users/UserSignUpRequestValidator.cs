using FluentValidation;
using static eShopApi.Constants.Messages.UserMessages;
using eShopApi.Repositories.Interfaces;
using eShopApi.Dtos.Requests.User;

namespace eShopApi.Validators.Users
{
    public class UserSignUpRequestValidator : AbstractValidator<UserSignUpRequestDto>
    {
        private readonly IUserRepository _userRepository;

        public UserSignUpRequestValidator(IUserRepository userRepository)
        {
            _userRepository = userRepository;
            // Rule for Username
            RuleFor(x => x.Username)
                .NotEmpty().WithMessage(UsernameIsRequired)
                .Length(3, 50).WithMessage(UsernameLengthInvalid)
                .Matches("^[a-z][a-z0-9]*$").WithMessage(UsernameInvalidCharacters)
                .MustAsync(BeUniqueUsername).WithMessage(UsernameAlreadyExists);

            // Rule for Email
            RuleFor(x => x.Email)
                .NotEmpty().WithMessage(EmailIsRequired)
                .EmailAddress().WithMessage(EmailInvalidFormat)
                .MustAsync(BeUniqueEmail).WithMessage(EmailAlreadyExists);

            // Rule for Password
            RuleFor(x => x.Password)
                .NotEmpty().WithMessage(PasswordIsRequired)
                .MinimumLength(6).WithMessage(PasswordMinimumLength)
                .Matches("[A-Z]").WithMessage(PasswordRequiresUppercase)
                .Matches("[a-z]").WithMessage(PasswordRequiresLowercase)
                .Matches("[0-9]").WithMessage(PasswordRequiresDigit)
                .Matches("[^a-zA-Z0-9]").WithMessage(PasswordRequiresNonAlphanumeric);

            // Rule for ConfirmPassword
            RuleFor(x => x.ConfirmPassword)
                .NotEmpty().WithMessage(ConfirmPasswordIsRequired)
                .Equal(x => x.Password).WithMessage(ConfirmPasswordMismatch);

            // Rule for FirstName
            RuleFor(x => x.FirstName)
                .NotEmpty().WithMessage(FirstNameIsRequired)
                .Length(2, 50).WithMessage(FirstNameLengthInvalid);

            // Rule for LastName
            RuleFor(x => x.LastName)
                .NotEmpty().WithMessage(LastNameIsRequired)
                .Length(2, 50).WithMessage(LastNameLengthInvalid);

        }
        // --- Custom Validation Methods ---
        private static bool StartWithLetter(string username)
        {
            return !char.IsDigit(username[0]);
        }
        private static bool ContainNoWhitespace(string username)
        {
            return !username.Contains(' ');
        }
        private async Task<bool> BeUniqueUsername(string username, CancellationToken cancellationToken)
        {
            return await _userRepository.UserExistsAsync(username);
        }
        private async Task<bool> BeUniqueEmail(string email, CancellationToken cancellationToken)
        {
            return await _userRepository.EmailExistsAsync(email);
        }
    }
}