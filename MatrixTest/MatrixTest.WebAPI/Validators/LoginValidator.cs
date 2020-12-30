using MatrixTest.WebAPI.Models;

using FluentValidation;

namespace MatrixTest.WebAPI.Validators
{
    /// <summary>Validate the LoginModel input</summary>
    public class LoginValidatonCollection : AbstractValidator<LoginModel>
    {
        /// <summary>Initializes a new instance of the <see cref="LoginValidatonCollection"/> class.</summary>
        public LoginValidatonCollection()
        {

            RuleFor(x => x.Password)
                .NotEmpty()
                .MinimumLength(8);
        }
    }
}