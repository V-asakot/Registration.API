using Registration.Infrustraction.Repositories.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Registration.Domain.Repositories;
using Registration.Infrustraction.Data;
using Registration.Domain.Primitives;
using Registration.Domain.Entities;
using Dapper;
using System.Data;

namespace Registration.Infrustraction.Repositories
{
    internal class RegionQueryRepository: QueryRepository, IRegionQueryRepository
    {
        public RegionQueryRepository(DapperDataContext context) : base(context)
        {
        }

        public async Task<Result<IEnumerable<Region>>> GetAll(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<Result<Region>> GetById(int id)
        {
            try
            {
                var query = "SELECT * FROM REGIONS WHERE Id = @Id";
                var parameters = new DynamicParameters();
                parameters.Add("Id", id, DbType.Int64);

                using (var connection = CreateConnection())
                {
                    var res = await connection.QueryFirstOrDefaultAsync<Region>(query, parameters);
                    return Result.Ok(res);
                }
            }
            catch (Exception exp)
            {
                return Result.Fail<Region>("Operation failed. Try later");
            }
        }
    }
}
