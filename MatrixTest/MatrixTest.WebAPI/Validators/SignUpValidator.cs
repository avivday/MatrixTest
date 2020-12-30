using MatrixTest.WebAPI.Models;

using FluentValidation;

namespace MatrixTest.WebAPI.Validators
{
    /// <summary>Validate the LoginModel input</summary>
    public class SignUpValidatorCollection : AbstractValidator<SignUpModel>
    {
        /// <summary>Initializes a new instance of the <see cref="SignUpValidatorCollection"/> class.</summary>
        public SignUpValidatorCollection()
        {

            RuleFor(s => s.Password)
                .NotEmpty()
                .MinimumLength(8)
                .Matches("[A-Z]").WithMessage("Password must contain at least one capital letter")
                .Matches(@"\d").WithMessage("Password must contain at least one number")
                .Matches(@"[][""!@$%^&*(){}:;<>,.?/+_=|'~\\-]").WithMessage("'Password must contain at least one special char");
        }
    }
}