using FluentValidation;
using Locato.API.Application.Users.Commands;

namespace Locato.API.Application.Users.Validators
{
    public class CreateNewUserCommandValidator : AbstractValidator<CreateNewUserCommand>
    {
        public CreateNewUserCommandValidator() 
        {
           RuleFor(x=>x.OrganizationId).NotNull().NotEmpty().NotEqual(0);
           RuleFor(x => x.Phone).NotNull().NotEmpty();
           RuleFor(x => x.Address).NotNull().NotEmpty();
           RuleFor(x=>x.Email).NotNull().NotEmpty();
           RuleFor(x=>x.Role).NotNull().NotEmpty();
           RuleFor(x=>x.Password).NotNull().NotEmpty();
        }
    }
}
