using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Registration.Domain.Common;

namespace Registration.Application.Commands.CreateUser
{
    public class CreateUserValidation : AbstractValidator<CreateUserCommand>
    {
        public CreateUserValidation()
        {
            RuleFor(x => x.Name).NotEmpty().EmailAddress();
            RuleFor(x => x.Password).Equal(x => x.PasswordConfirmation);
            RuleFor(x => x.Password).SetInheritanceValidator(v =>
                v.Add(new PasswordValidation()));
        }
    }
}
