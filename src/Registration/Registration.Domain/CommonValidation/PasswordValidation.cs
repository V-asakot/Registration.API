using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Registration.Domain.Common
{
    /// <summary>
    /// Общий валидатор,что может ипользовать как валидатор пароля Identity из слоя инфраструктуры, так и при валидации коамнд в слое приложения
    /// </summary>
    public class PasswordValidation : AbstractValidator<string>
    {
        public PasswordValidation()
        {
            RuleFor(x => x).MinimumLength(6).WithMessage("Password too short");
            var hasNumber = new Regex(@"[0-9]+");
            RuleFor(x => x).Must(hasNumber.IsMatch).WithMessage("Password must include numbers");
            var hasUpperChar = new Regex(@"[A-Z]+|[А-Я]+");
            RuleFor(x => x).Must(hasUpperChar.IsMatch).WithMessage("Password must include upper case");
        }
    }
}
