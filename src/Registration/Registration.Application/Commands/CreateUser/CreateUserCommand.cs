using MediatR;
using Registration.Domain.Primitives;
using System.ComponentModel.DataAnnotations;

namespace Registration.Application.Commands.CreateUser
{
    public class CreateUserCommand : IRequest<Result<string>>
    {
        [Required]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }
        [Required]
        public string PasswordConfirmation { get; set; }
    }
}