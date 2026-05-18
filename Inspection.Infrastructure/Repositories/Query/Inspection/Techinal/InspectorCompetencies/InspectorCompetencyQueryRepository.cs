using Inspection.Application.Contracts.Dto.InspectionDto.Techinal.InspectorCompetencyDTOs;
using Inspection.Application.Contracts.Repositories.Query.Inspection.Techinal.InspectorCompetencies;
using Inspection.Domain.Models.Inspection.Techinal.InspectorCompetencies;
using Inspection.Infrastructure.QueryObjects.Inspection.InspectorCompetency;
using Microsoft.EntityFrameworkCore;
using NDS.Shared.Application.DataQuery;
using NDS.Shared.Application.Multitenant;
using NDS.Shared.Infrastructure.DataContext;
using NDS.Shared.Infrastructure.RepositoryBase;
using NDS.Shared.Kernel.BaseReturnTypes;
using NDS.Shared.Kernel.Exceptions;

namespace Inspection.Infrastructure.Repositories.Query.Inspection.Techinal.InspectorCompetencies
{
    public class InspectorCompetencyQueryRepository : QueryRepositoryBase<InspectorCompetency>, IInspectorCompetencyQueryRepository
    {
        public InspectorCompetencyQueryRepository(ISqlQueryBuilder queryBuilder, DapperDbContext dapper, DbContext context, ITenantResolver tenantResolver, IExceptionManager exceptionManager) : base(queryBuilder, dapper, context, tenantResolver, exceptionManager)
        {
        }

        public async Task<InspectorCompetency?> GetById(long id)
        {
            return await _context.Set<InspectorCompetency>()
                .Include(x => x.InspectorCompetencyLines)
                .Include(v => v.InspectorAccreditation)
                .FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<ReturnBase<IEnumerable<InspectorCompetencyReturnSearchDto>>> Search(SqlQueryOptions sqlQueryOptions)
        {
            var inspectorCompetencyRepository = new InspectorCompetencyQuery(_queryBuilder, _dapper, _tenantResolver, _exceptionManager);
            return await inspectorCompetencyRepository.Query(sqlQueryOptions);
        }
        public IQueryable<InspectorCompetency> GetAll()
        {
            return _context.Set<InspectorCompetency>().AsQueryable();
        }

    }
}