using Microsoft.AspNetCore.Identity;
using Registration.Domain.Common;
using Registration.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Registration.Infrustraction.IdentityValidators
{
    public class IdenityPasswordValidator : IPasswordValidator<User>
    {
        
        public Task<IdentityResult> ValidateAsync(UserManager<User> manager, User user, string? password)
        {
            var validator = new PasswordValidation();
            var result = ValidatePassword(password);
            return Task.FromResult(result);
        }

        private IdentityResult ValidatePassword(string password)
        {
            var validator = new PasswordValidation();
            var result = validator.Validate(password);
            if (result.IsValid)
            {
                return IdentityResult.Success;
            }
            else
            {
                var errors = result.Errors.Select(x => 
                    new IdentityError(){ Description = x.ErrorMessage }).ToArray();
                return IdentityResult.Failed(errors);
            }
        }
    }
}
