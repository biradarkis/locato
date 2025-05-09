﻿using FluentValidation;
using Locato.API.Application.Users.Commands;
using Shared.Constants;

namespace Locato.API.Application.Users.Validators
{
    public class LoginUserCommandValidator  : AbstractValidator<LoginUserCommand>
    {
        public LoginUserCommandValidator() 
        {
            RuleFor(x=>x.LoginMethod).NotNull().NotEmpty();
            When(x => x.LoginMethod == UserConstants.LOGIN_METHOD_PHONE, () =>
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
