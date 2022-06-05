using DLog.Model;
using DLog.Repository;
using HotChocolate;
using HotChocolate.Types;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DLog.QueryResolver
{
    [ExtendObjectType("Query")]
    public class DLogQueryResolver
    {
        public async Task<List<DLogModel>> GetDLogs([Service] IDLogRepository dLogRepository)
        {
            return await dLogRepository.GetDLogs();
        }
    }
}