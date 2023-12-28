using FluentValidation;
using Locato.Web.Application.Users.Commands;

namespace Locato.Web.Application.Users.Validators
{
    public class LoginUserCommandValidator  : AbstractValidator<LoginUserCommand>
    {
        public LoginUserCommandValidator() 
        {
            RuleFor(x=>x.IdType).NotNull().NotEmpty();
            When(x => x.IdType == "Phone", () =>
            {
                RuleFor(x => x.UserId).NotNull().NotEmpty().WithMessage("UserId is required");
                RuleFor(x => x.UserId).MaximumLength(16).WithMessage("Invalid Phone Number");

            }).Otherwise(() =>
            {
                RuleFor(x => x.UserId).NotNull().NotEmpty().WithMessage("UserId is required");
                RuleFor(x => x.UserId).EmailAddress().WithMessage("Invalid Email Address");
            });

            RuleFor(x => x.Password).NotNull().NotEmpty().WithMessage("Password is required");
        }
    }
}
