using MediatR;
using Registration.Domain.Primitives;

namespace Registration.Application.Commands.CreateUser
{
    public class CreateUserCommand : IRequest<Result<string>>
    {
        public string Name { get; set; }
        public string Password { get; set; }
        public string PasswordConfirmation { get; set; }
    }
}