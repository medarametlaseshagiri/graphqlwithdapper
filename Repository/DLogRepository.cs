using Dapper;
using DLog.Model;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace DLog.Repository
{
    public interface IDLogRepository
    {
        public Task<List<DLogModel>> GetDLogs();
    }
    public class DLogRepository : IDLogRepository
    {
        IConfiguration configuration = null;
        private IDbConnection Connection
        {
            get
            {
                return new SqlConnection(configuration.GetConnectionString("SqlServer"));
            }
        }
        public DLogRepository(IConfiguration configuration)
        {
            this.configuration = configuration;
        }
        public async Task<List<DLogModel>> GetDLogs()
        {
            using(var connection = Connection)
            {
                var query = "Select * from SHPViewDlogWithAudit";
                var dLogs = await connection.QueryAsync<DLogModel>(query);
                return dLogs.ToList();
            }
        }
    }
}
