using Inspection.Application.Contracts.Dto.InspectionManagement.InspectionTypes;
using Inspection.Application.Contracts.Repositories.Query.InspectionManagement.InspectionTypes;
using Inspection.Domain.Models.InspectionManagement.InspectionTypes;
using Inspection.Infrastructure.QueryObjects.InspectionManagement.InspectionTypes;
using Microsoft.EntityFrameworkCore;
using NDS.Shared.Application.DataQuery;
using NDS.Shared.Application.Multitenant;
using NDS.Shared.Infrastructure.DataContext;
using NDS.Shared.Infrastructure.RepositoryBase;
using NDS.Shared.Kernel.BaseReturnTypes;
using NDS.Shared.Kernel.Exceptions;

namespace Inspection.Infrastructure.Repositories.Query.InspectionManagement.InspectionTypes
{

    public class InspectionTypeQueryRepository : QueryRepositoryBase<InspectionType>, IInspectionTypeQueryRepository
    {
        public InspectionTypeQueryRepository(ISqlQueryBuilder queryBuilder, DapperDbContext dapper, DbContext context, ITenantResolver tenantResolver, IExceptionManager exceptionManager) : base(queryBuilder, dapper, context, tenantResolver, exceptionManager)
        {
        }

        public async Task<InspectionType?> GetById(long id)
        {
            return await _context.Set<InspectionType>().Where(x => x.Id == id).FirstOrDefaultAsync();
        }
        public async Task<ReturnBase<IEnumerable<InspectionTypeDto>>> Search(SqlQueryOptions sqlQueryOptions)
        {
            var inspectionTypeQueryRepository = new InspectionTypeQuery(_queryBuilder, _dapper, _tenantResolver, _exceptionManager);
            return await inspectionTypeQueryRepository.Query(sqlQueryOptions);
        }
    }
}