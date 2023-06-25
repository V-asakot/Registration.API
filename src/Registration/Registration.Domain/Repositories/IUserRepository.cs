using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Registration.Domain.Entities;
using Registration.Domain.Primitives;

namespace Registration.Domain.Repositories
{
    public interface IUserRepository
    {
        Task<Result<string>> SignUpAsync(User user, string password);
        Task<Result> SetUserRegion(string userId, Region region);
    }
}
