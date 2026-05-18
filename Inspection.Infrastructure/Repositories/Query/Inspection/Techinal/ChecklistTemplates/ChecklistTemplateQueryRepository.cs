using Inspection.Application.Contracts.Dto.InspectionDto.Techinal.ChecklistTemplates;
using Inspection.Application.Contracts.Repositories.Query.Inspection.Techinal.ChecklistTemplates;
using Inspection.Domain.Models.Inspection.Techinal.ChecklistTemplates;
using Inspection.Infrastructure.QueryObjects.Inspection.Techinal.ChecklistTemplates;
using Microsoft.EntityFrameworkCore;
using NDS.Shared.Application.DataQuery;
using NDS.Shared.Application.Multitenant;
using NDS.Shared.Infrastructure.DataContext;
using NDS.Shared.Infrastructure.RepositoryBase;
using NDS.Shared.Kernel.BaseReturnTypes;
using NDS.Shared.Kernel.Exceptions;

namespace Inspection.Infrastructure.Repositories.Query.Inspection.Techinal.ChecklistTemplates
{
    public class ChecklistTemplateQueryRepository : QueryRepositoryBase<ChecklistTemplate>, IChecklistTemplateQueryRepository
    {
        public ChecklistTemplateQueryRepository(ISqlQueryBuilder queryBuilder, DapperDbContext dapper, DbContext context, ITenantResolver tenantResolver, IExceptionManager exceptionManager) : base(queryBuilder, dapper, context, tenantResolver, exceptionManager)
        {

        }

        public async Task<ChecklistTemplate?> GetByCode(string code)
        {
            return await _context.Set<ChecklistTemplate>().Where(x => x.ChecklistTemplateNumber == code).FirstOrDefaultAsync();
        }

        public async Task<ChecklistTemplate?> GetById(long id)
        {
            return await _context.Set<ChecklistTemplate>()
                .Include(x => x.ChecklistTemplateLines)
                .FirstOrDefaultAsync(x => x.Id == id);
        }


        public async Task<ReturnBase<IEnumerable<ChecklistTemplateSearchReturnDto>>> Search(SqlQueryOptions sqlQueryOptions)
        {
            var CurrencyQueryRepository = new ChecklistTemplateQuery(_queryBuilder, _dapper, _tenantResolver, _exceptionManager);
            return await CurrencyQueryRepository.Query(sqlQueryOptions);
        }
    }

}
