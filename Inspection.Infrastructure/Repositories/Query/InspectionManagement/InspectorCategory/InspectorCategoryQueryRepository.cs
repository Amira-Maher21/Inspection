using Inspection.Application.Contracts.Dto.InspectionManagement.InspectorCategory;
using Inspection.Application.Contracts.Repositories.Query.InspectionManagement.InspectorCategory;
using Inspection.Infrastructure.QueryObjects.InspectionManagement.InspectorCategory;
using Microsoft.EntityFrameworkCore;
using NDS.Shared.Application.DataQuery;
using NDS.Shared.Application.Multitenant;
using NDS.Shared.Infrastructure.DataContext;
using NDS.Shared.Infrastructure.RepositoryBase;
using NDS.Shared.Kernel.BaseReturnTypes;
using NDS.Shared.Kernel.Exceptions;

namespace Inspection.Infrastructure.Repositories.Query.InspectionManagement.InspectorCategory
{
    public class InspectorCategoryQueryRepository : QueryRepositoryBase<Domain.Models.InspectionManagement.InspectorCategories.InspectorCategory>, IInspectorCategoryQueryRepository
    {
        public InspectorCategoryQueryRepository(ISqlQueryBuilder sqlQueryBuilder, DapperDbContext dapperDbContext, DbContext context, ITenantResolver tenantResolver, IExceptionManager exceptionManager) : base(sqlQueryBuilder, dapperDbContext, context, tenantResolver, exceptionManager)
        {
        }

        public async Task<Domain.Models.InspectionManagement.InspectorCategories.InspectorCategory?> GetById(long id)
        {
            return await _context.Set<Domain.Models.InspectionManagement.InspectorCategories.InspectorCategory>().Where(x => x.Id == id).FirstOrDefaultAsync();
        }
        public async Task<ReturnBase<IEnumerable<InspectorCategoryDto>>> Search(SqlQueryOptions sqlQueryOptions)
        {
            var inspectorCategoryQueryRepository = new InspectorCategoryQuery(_queryBuilder, _dapper, _tenantResolver, _exceptionManager);
            return await inspectorCategoryQueryRepository.Query(sqlQueryOptions);
        }
        public async Task<IEnumerable<InspectorCategoryGetListDto>> GetListAsync()
        {
            return await _dbSet
                .Select(x => new InspectorCategoryGetListDto
                {
                    Id = x.Id,
                    Name = x.Name,
                    Tenant_ID = x.Tenant_ID
                })
                .ToListAsync();
        }

        public Task<Domain.Models.InspectionManagement.InspectorCategories.InspectorCategory?> GetByCode(string code)
        {
            return _context.Set<Domain.Models.InspectionManagement.InspectorCategories.InspectorCategory>().Where(x => x.Code == code).FirstOrDefaultAsync();
        }
    }
}