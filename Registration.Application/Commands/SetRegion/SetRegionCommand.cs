using MediatR;
using Registration.Domain.Primitives;

namespace Registration.Application.Commands.SetRegion
{

    public class SetRegionCommand : IRequest<Result>
    {
        public string UserId { get; set; }
        public int RegionId { get; set; }
    }
}