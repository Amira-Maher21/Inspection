using Inspection.Application.Contracts.Dto.InspectionDto.Techinal.InspectionStandards;
using Inspection.Application.Contracts.Repositories.Query.Inspection.Techinal.InspectionStandards;
using Inspection.Domain.Models.Inspection.Techinal.InspectionStandards;
using Inspection.Infrastructure.QueryObjects.Inspection.Techinal.InspectionStandards;
using Microsoft.EntityFrameworkCore;
using NDS.Shared.Application.DataQuery;
using NDS.Shared.Application.Multitenant;
using NDS.Shared.Infrastructure.DataContext;
using NDS.Shared.Infrastructure.RepositoryBase;
using NDS.Shared.Kernel.BaseReturnTypes;
using NDS.Shared.Kernel.Exceptions;

namespace Inspection.Infrastructure.Repositories.Query.Inspection.Techinal.InspectionStandards
{
    public class InspectionStandardQueryRepository : QueryRepositoryBase<InspectionStandard>, IInspectionStandardQueryRepository
    {
        public InspectionStandardQueryRepository(ISqlQueryBuilder queryBuilder, DapperDbContext dapper, DbContext context, ITenantResolver tenantResolver, IExceptionManager exceptionManager) : base(queryBuilder, dapper, context, tenantResolver, exceptionManager)
        {
        }

        public async Task<ReturnBase<List<InspectionStandard>>> GetAll()
        {
            var result = await _context.Set<InspectionStandard>().Include(x => x.InspectionStandardApplicabilityRules).AsNoTracking().ToListAsync();
            return ReturnBase<List<InspectionStandard>>.Success(result);
        }

        public async Task<InspectionStandard?> GetById(long id)
        {
            return await _context.Set<InspectionStandard>()
                 .Include(x => x.InspectionStandardApplicabilityRules)
                 .FirstOrDefaultAsync(x => x.Id == id);
        }
        public async Task<InspectionStandard?> GetByCode(string code)
        {
            return await _context.Set<InspectionStandard>().Where(x => x.Code == code).FirstOrDefaultAsync();
        }
        public async Task<ReturnBase<IEnumerable<InspectionStandardReturnSearchDto>>> Search(SqlQueryOptions sqlQueryOptions)
        {
            var InspectionStandardRepository = new InspectionStandardQuery(_queryBuilder, _dapper, _tenantResolver, _exceptionManager);
            return await InspectionStandardRepository.Query(sqlQueryOptions);
        }
    }
}