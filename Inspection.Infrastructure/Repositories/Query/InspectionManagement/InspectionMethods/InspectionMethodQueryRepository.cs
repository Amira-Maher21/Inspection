using Inspection.Application.Contracts.Dto.InspectionManagement.InspectionMethodDTOs;
using Inspection.Application.Contracts.Repositories.Query.InspectionManagement.InspectionMethods;
using Inspection.Domain.Models.InspectionManagement.InspectionMethods;
using Inspection.Infrastructure.QueryObjects.InspectionManagement.InspectionMethods;
using Microsoft.EntityFrameworkCore;
using NDS.Shared.Application.DataQuery;
using NDS.Shared.Application.Multitenant;
using NDS.Shared.Infrastructure.DataContext;
using NDS.Shared.Infrastructure.RepositoryBase;
using NDS.Shared.Kernel.BaseReturnTypes;
using NDS.Shared.Kernel.Exceptions;

namespace Inspection.Infrastructure.Repositories.Query.InspectionManagement.InspectionMethods
{
    public class InspectionMethodQueryRepository : QueryRepositoryBase<InspectionMethod>, IInspectionMethodQueryRepository
    {

        public InspectionMethodQueryRepository(ISqlQueryBuilder queryBuilder, DapperDbContext dapper, DbContext context, ITenantResolver tenantResolver, IExceptionManager exceptionManager) : base(queryBuilder, dapper, context, tenantResolver, exceptionManager)
        {
        }

        public async Task<ReturnBase<List<InspectionMethod>>> GetAll()
        {
            var result = await _context.Set<InspectionMethod>()
                .AsNoTracking().ToListAsync();
            return ReturnBase<List<InspectionMethod>>.Success(result);
        }

        public async Task<InspectionMethod?> GetById(long id)
        {
            return await _context.Set<InspectionMethod>()
                .FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<ReturnBase<IEnumerable<InspectionMethodReturnSearchDto>>> Search(SqlQueryOptions sqlQueryOptions)
        {
            var inspectionMethodRepository = new InspectionMethodQuery(_queryBuilder, _dapper, _tenantResolver, _exceptionManager);
            return await inspectionMethodRepository.Query(sqlQueryOptions);
        }
    }
}