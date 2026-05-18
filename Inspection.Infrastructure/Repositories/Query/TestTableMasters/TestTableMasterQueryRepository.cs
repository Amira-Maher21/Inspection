using Inspection.Application.Contracts.Dto.TestTableMasters;
using Inspection.Application.Contracts.Repositories.Query.InspectionManagement.TestTableMasters;
using Inspection.Domain.Models.TestTableMaster;
using Inspection.Domain.Models.TestTableMasters;
using Inspection.Infrastructure.QueryObjects.TestTableMasters;
using Microsoft.EntityFrameworkCore;
using NDS.Shared.Application.DataQuery;
using NDS.Shared.Application.Multitenant;
using NDS.Shared.Infrastructure.DataContext;
using NDS.Shared.Infrastructure.RepositoryBase;
using NDS.Shared.Kernel.BaseReturnTypes;
using NDS.Shared.Kernel.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inspection.Infrastructure.Repositories.Query.TestTableMasters
{
 

 
    public class TestTableMasterQueryRepository : QueryRepositoryBase<TestTableMaster>, ITestTableMasterQueryRepository
    {
        public TestTableMasterQueryRepository(ISqlQueryBuilder sqlQueryBuilder, DapperDbContext dapperDbContext, DbContext context, ITenantResolver tenantResolver, IExceptionManager exceptionManager) : base(sqlQueryBuilder, dapperDbContext, context, tenantResolver, exceptionManager)
        {
        }

        public async Task<TestTableMaster?> GetByIdAsync(long id)
        {
            return await _context.Set<TestTableMaster>().Where(x => x.Id == id).AsNoTracking().FirstOrDefaultAsync();
        }
        //all list will work on this dto "TestTableMasterDtoByInclude"
        public async Task<ReturnBase<IEnumerable<TestTableMasterDtoByInclude>>> GetListAsync(SqlQueryOptions sqlQueryOptions)
        {
            var testTableMasterQuery = new TestTableMasterQuery(_queryBuilder, _dapper, _tenantResolver, _exceptionManager);
            return await Query(testTableMasterQuery, sqlQueryOptions);
        }


        public async Task<ReturnBase<IEnumerable<TestTableMasterDtoByInclude>>> GetListIncldeNameAsync(SqlQueryOptions sqlQueryOptions)
        {

            var testTableMasterQuery = new TestTableMasterQuery(_queryBuilder, _dapper, _tenantResolver, _exceptionManager);
            return await Query(testTableMasterQuery, sqlQueryOptions);

        }




    }

}
