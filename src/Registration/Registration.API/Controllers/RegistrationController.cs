using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Registration.Application.Commands.CreateUser;
using Registration.Domain.Primitives;

namespace Registration.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RegistrationController : ControllerBase
    {
        private readonly IMediator _mediator;
        public RegistrationController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<Result<string>> GetProducts(CreateUserCommand command)
        {
            var res = await _mediator.Send(command);
            return res;
        }

    }
}
