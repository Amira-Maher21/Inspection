using Inspection.Application.Contracts.Repositories.Query.InspectionManagement.InspectionReports;
using Inspection.Domain.Models.InspectionManagement.InspectionReports;
using Inspection.Infrastructure.DataContext;
using Microsoft.EntityFrameworkCore;
using NDS.Shared.Application.DataQuery;
using NDS.Shared.Application.Multitenant;
using NDS.Shared.Application.RepositoryBase;
using NDS.Shared.Infrastructure.DataContext;
using NDS.Shared.Infrastructure.RepositoryBase;
using NDS.Shared.Kernel.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inspection.Infrastructure.Repositories.Query.InspectionManagement.InspectionReports
{
    public class InspectionReportQueryRepository : QueryRepositoryBase<InspectionReport>, IInspectionReportQueryRepository
    {
        public InspectionReportQueryRepository(ISqlQueryBuilder sqlQueryBuilder, DapperDbContext dapperDbContext, DbContext context, ITenantResolver tenantResolver, IExceptionManager exceptionManager) : base(sqlQueryBuilder, dapperDbContext, context, tenantResolver, exceptionManager)
        {
        }

        //public async Task<InspectionReport?> GetByIdAsync(Guid id)
        //{
        //    var entity = await _dbSet.Where(x => x.Id == id).FirstOrDefaultAsync();
        //    return entity;
        //}
    }
}
