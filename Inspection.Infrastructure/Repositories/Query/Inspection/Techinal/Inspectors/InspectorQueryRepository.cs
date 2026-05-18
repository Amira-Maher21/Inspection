using Inspection.Application.Contracts.Dto.InspectionDto.Techinal.InspectorDTOs;
using Inspection.Application.Contracts.Repositories.Query.Inspection.Techinal.Inspector;
using Inspection.Domain.Models.Inspection.Techinal.Inspectors;
using Inspection.Infrastructure.QueryObjects.Inspection.Techinal.Inspectors;
using Microsoft.EntityFrameworkCore;
using NDS.Shared.Application.DataQuery;
using NDS.Shared.Application.Multitenant;
using NDS.Shared.Infrastructure.DataContext;
using NDS.Shared.Infrastructure.RepositoryBase;
using NDS.Shared.Kernel.BaseReturnTypes;
using NDS.Shared.Kernel.Exceptions;

namespace Inspection.Infrastructure.Repositories.Query.Inspection.Techinal.Inspectors
{
    public class InspectorQueryRepository : QueryRepositoryBase<Inspector>, IInspectorQueryRepository
    {
        public InspectorQueryRepository(ISqlQueryBuilder queryBuilder, DapperDbContext dapper, DbContext context, ITenantResolver tenantResolver, IExceptionManager exceptionManager) : base(queryBuilder, dapper, context, tenantResolver, exceptionManager)
        {
        }

        public async Task<Inspector?> GetById(long id)
        {
            return await _context.Set<Inspector>().Where(x => x.Id == id).FirstOrDefaultAsync();
        }

        public async Task<ReturnBase<IEnumerable<InspectorReturnSearchDto>>> Search(SqlQueryOptions sqlQueryOptions)
        {
            var inspectorRepository = new InspectorQuery(_queryBuilder, _dapper, _tenantResolver, _exceptionManager);
            return await inspectorRepository.Query(sqlQueryOptions);
        }
        public IQueryable<Inspector> GetAll()
        {
            return _context.Set<Inspector>().AsQueryable();
        }
        public async Task<IEnumerable<InspectorGetListDto>> GetListAsync()
        {
            return await _context
                .Set<Inspector>()
                .Select(x => new InspectorGetListDto
                {
                    Id = x.Id,
                    Tenant_ID = x.Tenant_ID,
                    CompanyId = x.CompanyId,
                    Code = x.Code,
                    FirstName = x.FirstName,
                    LastName = x.LastName,

                    InspectorCategoryCode = x.InspectorCategory.Code,
                    InspectorCategoryName = x.InspectorCategory.Name
                })
                .ToListAsync();
        }


        public async Task<Inspector?> GetByCode(string code)
        {
            return await _context.Set<Inspector>().Where(x => x.Code == code).FirstOrDefaultAsync();
        }
    }
}