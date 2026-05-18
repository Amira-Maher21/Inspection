using Inspection.Application.Contracts.Dto.DMSDTOs.TagDTOs;
using Inspection.Application.Contracts.Repositories.Query.DMS.Tags;
using Inspection.Domain.Models.DMS.Tags;
using Microsoft.EntityFrameworkCore;
using NDS.Shared.Application.DataQuery;
using NDS.Shared.Application.Multitenant;
using NDS.Shared.Infrastructure.DataContext;
using NDS.Shared.Infrastructure.RepositoryBase;
using NDS.Shared.Kernel.BaseReturnTypes;
using NDS.Shared.Kernel.Exceptions;

namespace Inspection.Infrastructure.Repositories.Query.DMS.Tags
{
    public class TagQueryRepository : QueryRepositoryBase<Tag>, ITagQueryRepository
    {
        public TagQueryRepository(ISqlQueryBuilder queryBuilder, DapperDbContext dapper, DbContext context, ITenantResolver tenantResolver, IExceptionManager exceptionManager) : base(queryBuilder, dapper, context, tenantResolver, exceptionManager)
        {
        }

        public async Task<Tag?> GetById(long id)
        {
            return await _context.Set<Tag>().Where(x => x.Id == id).FirstOrDefaultAsync();
        }

        public async Task<ReturnBase<IEnumerable<TagReturnSearchDto>>> Search(SqlQueryOptions sqlQueryOptions, string tenantId, long companyId)
        {
            try
            {
                var query = _context.Set<Tag>()
                    .AsNoTracking()
                    .Where(t =>
                        t.Tenant_ID == tenantId &&
                        t.CompanyId == companyId);

                var result = await query
                    .Select(t => new TagReturnSearchDto
                    {
                        Id = t.Id,
                        Tenant_ID = t.Tenant_ID,
                        CompanyId = t.CompanyId,
                        Name = t.Name,
                        Color = t.Color,

                        In_User = t.In_User,
                        In_Date = t.In_Date,
                        Mod_User = t.Mod_User,
                        Mod_Date = t.Mod_Date
                    })
                    .ToListAsync();

                return ReturnBase<IEnumerable<TagReturnSearchDto>>
                    .Success(result);
            }
            catch (Exception ex)
            {
                return ReturnBase<IEnumerable<TagReturnSearchDto>>
                    .Fail(ex, _exceptionManager);
            }
        }
    }
}