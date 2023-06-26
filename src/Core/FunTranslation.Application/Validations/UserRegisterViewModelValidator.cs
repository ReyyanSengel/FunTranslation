using FluentValidation;
using FunTranslation.Application.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FunTranslation.Application.Validations
{
    public class UserRegisterViewModelValidator : AbstractValidator<UserRegisterViewModel>
    {
        public UserRegisterViewModelValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty()
                .NotNull()
                .WithMessage("Name is required");

            RuleFor(x => x.SurName)
               .NotEmpty()
               .NotNull()
               .WithMessage("SurName is required");

            RuleFor(x => x.UserName)
               .NotEmpty()
               .NotNull()
               .WithMessage("UserName is required");

            RuleFor(x => x.Email)
               .NotEmpty()
               .NotNull()
               .WithMessage("Email is required")
               .EmailAddress().WithMessage("You must enter an email address");

            RuleFor(x => x.Password)
               .NotEmpty()
               .WithMessage("Please enter the password");

            RuleFor(x => x.ConfirmPassword)
               .NotEmpty()
               .WithMessage("Please enter the confirmation password");

            RuleFor(x => x).Custom((x, context) =>
            {
                if (x.Password != x.ConfirmPassword)
                {
                    context.AddFailure(nameof(x.Password), "Passwords should match");
                }
            });




        }
    }
}
