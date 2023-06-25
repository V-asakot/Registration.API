using MediatR;
using Registration.Domain.Entities;
using Registration.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Registration.Domain.Primitives;

namespace Registration.Application.Commands.SetRegion
{
    public class SetRegionHandler : IRequestHandler<SetRegionCommand, Result>
    {
        private readonly IUserRepository _userRepository;
        private readonly IRegionQueryRepository _regionRepository;
        public SetRegionHandler(IUserRepository userRepository, 
            IRegionQueryRepository regionRepository)
        {
            _userRepository = userRepository;
            _regionRepository = regionRepository;
        }

        public async Task<Result> Handle(SetRegionCommand request, CancellationToken cancellationToken)
        {
            var regionResult = await _regionRepository.GetById(request.RegionId);
            if (!regionResult.Success) 
                return regionResult;
            return await _userRepository.SetUserRegion(request.UserId, regionResult.Data);
        }
    }
}
