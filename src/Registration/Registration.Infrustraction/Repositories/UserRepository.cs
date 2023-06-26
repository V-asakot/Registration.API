using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Registration.Domain.Entities;
using Registration.Domain.Primitives;
using Registration.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Registration.Infrustraction.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly UserManager<User> _userManager;
        private readonly ApplicationDbContext _context;

        public UserRepository(UserManager<User> userManager,
            ApplicationDbContext context)
        {
            _userManager = userManager;
            _context = context;
        }

        public async Task<Result<string>> SignUpAsync(User user, string password)
        {
            var result = await _userManager.CreateAsync(user, password);
            if (!result.Succeeded)
                return Result.Fail<string>("User not created");
            return Result.Ok(user.Id);
        }

        public async Task<Result> SetUserRegion(string userId, Region region)
        {
            var user = await _userManager.FindByIdAsync(userId);
            if (user is null)
                return Result.Fail<string>("Failed setting user region");

            user.Region = region;
            await _context.SaveChangesAsync();
            return Result<Region>.Ok();
        }
    }
}
