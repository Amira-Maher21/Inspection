 using Inspection.Application.Contracts.Repositories.Query.InspectionManagement.TestTableDetails;
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

namespace Inspection.Infrastructure.Repositories.Query.TestTableDetails
{

    public class TestTableDetailsQueryRepository : QueryRepositoryBase<TestTableDetail>, ITestTableDetailQueryRepository
    {
        public TestTableDetailsQueryRepository(ISqlQueryBuilder sqlQueryBuilder, DapperDbContext dapperDbContext, DbContext context, ITenantResolver tenantResolver, IExceptionManager exceptionManager) : base(sqlQueryBuilder, dapperDbContext, context, tenantResolver, exceptionManager)
        {
        }

        public async Task<TestTableDetail?> GetByIdAsync(long id)
        {
            return await _context.Set<TestTableDetail>().Where(x => x.Id == id).AsNoTracking().FirstOrDefaultAsync();
        }
        




    }

}
