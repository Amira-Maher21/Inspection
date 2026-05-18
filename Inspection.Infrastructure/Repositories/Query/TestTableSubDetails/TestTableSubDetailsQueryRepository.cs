using Inspection.Application.Contracts.Repositories.Query.InspectionManagement.TestTableMasters;
using Inspection.Domain.Models.TestTableMasters;
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

namespace Inspection.Infrastructure.Repositories.Query.TestTableSubDetails 
{
   


    public class TestTableSubDetailsQueryRepository : QueryRepositoryBase<TestTableSubDetail>, ITestTableSubDetailsQueryRepository
    {
        public TestTableSubDetailsQueryRepository(ISqlQueryBuilder sqlQueryBuilder, DapperDbContext dapperDbContext, DbContext context, ITenantResolver tenantResolver, IExceptionManager exceptionManager) : base(sqlQueryBuilder, dapperDbContext, context, tenantResolver, exceptionManager)
        {
        }

        public async Task<TestTableSubDetail?> GetByIdAsync(long id)
        {
            return await _context.Set<TestTableSubDetail>().Where(x => x.Id == id).AsNoTracking().FirstOrDefaultAsync();
        }
        //all list will work on this dto "TestTableSubDetailsDtoByInclude"
        //public async Task<ReturnBase<IEnumerable<TestTableSubDetailsDtoByInclude>>> GetListAsync(SqlQueryOptions sqlQueryOptions)
        //{
        //    var testTableSubDetailsQuery = new TestTableSubDetailsQuery(_queryBuilder, _dapper, _tenantResolver, _exceptionManager);
        //    return await Query(testTableSubDetailsQuery, sqlQueryOptions);
        //}


        //public async Task<ReturnBase<IEnumerable<TestTableSubDetailsDtoByInclude>>> GetListIncldeNameAsync(SqlQueryOptions sqlQueryOptions)
        //{

        //    var testTableSubDetailsQuery = new TestTableSubDetailsQuery(_queryBuilder, _dapper, _tenantResolver, _exceptionManager);
        //    return await Query(testTableSubDetailsQuery, sqlQueryOptions);

        //}




    }

}
