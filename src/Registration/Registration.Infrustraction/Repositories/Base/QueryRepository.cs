using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Registration.Infrustraction.Data;

namespace Registration.Infrustraction.Repositories.Base
{
    public abstract class QueryRepository
    {
        private DapperDataContext _context;

        public QueryRepository(DapperDataContext context)
        {
            _context = context;
        }

        protected IDbConnection CreateConnection()
        {
           return _context.CreateConnection();
        }
    }
}
