using Registration.Domain.Entities;
using Registration.Domain.Primitives;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Registration.Domain.Repositories
{
    public interface IRegionQueryRepository
    {
        Task<Result<Region>> GetById(int id);
        Task<Result<IEnumerable<Region>>> GetAll(int id);
    }
}
