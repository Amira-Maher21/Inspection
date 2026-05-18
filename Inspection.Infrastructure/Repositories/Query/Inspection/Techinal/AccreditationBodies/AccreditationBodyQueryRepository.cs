using Inspection.Application.Contracts.Dto.InspectionDto.Techinal.AccreditationBodyDTOs;
using Inspection.Application.Contracts.Repositories.Query.Inspection.Techinal.AccreditationBodies;
using Inspection.Domain.Models.Inspection.Techinal.AccreditationBodies;
using Inspection.Infrastructure.QueryObjects.Inspection.Techinal.AccreditationBodies;
using Microsoft.EntityFrameworkCore;
using NDS.Shared.Application.DataQuery;
using NDS.Shared.Application.Multitenant;
using NDS.Shared.Infrastructure.DataContext;
using NDS.Shared.Infrastructure.RepositoryBase;
using NDS.Shared.Kernel.BaseReturnTypes;
using NDS.Shared.Kernel.Exceptions;

namespace Inspection.Infrastructure.Repositories.Query.Inspection.Techinal.AccreditationBodies
{
    public class AccreditationBodyQueryRepository : QueryRepositoryBase<AccreditationBody>, IAccreditationBodyQueryRepository
    {
        public AccreditationBodyQueryRepository(ISqlQueryBuilder queryBuilder, DapperDbContext dapper, DbContext context, ITenantResolver tenantResolver, IExceptionManager exceptionManager) : base(queryBuilder, dapper, context, tenantResolver, exceptionManager)
        {
        }

        public async Task<AccreditationBody?> GetById(long id)
        {
            return await _context.Set<AccreditationBody>()
                .Include(x => x.AccreditationBodyLines).FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<ReturnBase<IEnumerable<AccreditationBodyReturnSearchDto>>> Search(SqlQueryOptions sqlQueryOptions)
        {
            var accreditationBodyRepository = new AccreditationBodyQuery(_queryBuilder, _dapper, _tenantResolver, _exceptionManager);
            return await accreditationBodyRepository.Query(sqlQueryOptions);
        }
        public IQueryable<AccreditationBody> GetAll()
        {
            return _context.Set<AccreditationBody>().AsQueryable();
        }

    }
}