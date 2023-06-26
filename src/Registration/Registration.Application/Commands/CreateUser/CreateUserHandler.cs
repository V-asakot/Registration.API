using MediatR;
using Registration.Domain.Primitives;
using Registration.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Registration.Domain.Entities;

namespace Registration.Application.Commands.CreateUser
{
    public class CreateUserHandler : IRequestHandler<CreateUserCommand, Result<string>>
    {
        private readonly IUserRepository _repository;
        public CreateUserHandler(IUserRepository repository)
        {
            _repository = repository;
        }

        public async Task<Result<string>> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            var user = new User(request.Name);
            var res = await _repository.SignUpAsync(user, request.Password);
            return res;
        }
    }
}
