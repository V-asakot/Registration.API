using System.ComponentModel.DataAnnotations;
using MediatR;
using Registration.Domain.Primitives;

namespace Registration.Application.Commands.SetRegion
{

    public class SetRegionCommand : IRequest<Result>
    {
        [Required]
        public string UserId { get; set; }
        [Required]
        public int RegionId { get; set; }
    }
}