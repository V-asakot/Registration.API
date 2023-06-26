using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Registration.Application.Commands.CreateUser;
using Registration.Application.Commands.SetRegion;
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

        [HttpPost("createUser")]
        public async Task<Result<string>> CreateUser(CreateUserCommand command)
        {
            var res = await _mediator.Send(command);
            return res;
        }

        [HttpPost("setUserRegion")]
        public async Task<Result> SetUserRegion(SetRegionCommand command)
        {
            var res = await _mediator.Send(command);
            return res;
        }

    }
}
