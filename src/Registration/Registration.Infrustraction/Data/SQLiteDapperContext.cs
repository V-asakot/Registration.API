using Microsoft.Data.Sqlite;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Registration.Infrustraction.Data
{
    public class SQLiteDapperContext : DapperDataContext
    {
        protected readonly IConfiguration Configuration;

        public SQLiteDapperContext(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public override IDbConnection CreateConnection()
        {
            return new SqliteConnection(Configuration.GetConnectionString("DefaultConnection"));
        }
    }
}
