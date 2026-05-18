using Inspection.Application.Contracts.Dto.InspectionDto.Techinal.Checklists;
using Inspection.Application.Contracts.Repositories.Query.Inspection.Techinal.Checklists;
using Inspection.Domain.Models.Inspection.Techinal.Checklists;
using Inspection.Infrastructure.QueryObjects.Inspection.Techinal.Checklists;
using Microsoft.EntityFrameworkCore;
using NDS.Shared.Application.DataQuery;
using NDS.Shared.Application.Multitenant;
using NDS.Shared.Infrastructure.DataContext;
using NDS.Shared.Infrastructure.RepositoryBase;
using NDS.Shared.Kernel.BaseReturnTypes;
using NDS.Shared.Kernel.Exceptions;

namespace Inspection.Infrastructure.Repositories.Query.Inspection.Techinal.Checklists
{
    public class ChecklistQueryRepository : QueryRepositoryBase<Checklist>, IChecklistQueryRepository
    {
        public ChecklistQueryRepository(ISqlQueryBuilder queryBuilder, DapperDbContext dapper, DbContext context, ITenantResolver tenantResolver, IExceptionManager exceptionManager) : base(queryBuilder, dapper, context, tenantResolver, exceptionManager)
        {
        }

        public async Task<ReturnBase<List<Checklist>>> GetAll()
        {
            var result = await _context.Set<Checklist>().Include(x => x.ChecklistLines).AsNoTracking().ToListAsync();
            return ReturnBase<List<Checklist>>.Success(result);
        }

        public async Task<Checklist?> GetById(long id)
        {
            return await _context.Set<Checklist>()
                 .Include(x => x.ChecklistLines)
                 .FirstOrDefaultAsync(x => x.Id == id);
        }

        public Task<Checklist?> GetChecklistTemplateById(long id)
        {
            return _context.Set<Checklist>()
                  .FirstOrDefaultAsync(x => x.ChecklistTemplateId == id);
        }

        public async Task<ReturnBase<IEnumerable<ChecklistSearchReturnDto>>> Search(SqlQueryOptions sqlQueryOptions)
        {
            var ChecklistRepository = new ChecklistQuery(_queryBuilder, _dapper, _tenantResolver, _exceptionManager);
            return await ChecklistRepository.Query(sqlQueryOptions);
        }
    }
}
