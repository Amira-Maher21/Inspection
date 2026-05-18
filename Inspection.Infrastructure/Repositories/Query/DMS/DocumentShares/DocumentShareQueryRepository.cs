using Inspection.Application.Contracts.Dto.DMSDTOs.DocumentShares;
using Inspection.Application.Contracts.Repositories.Query.DMS.DocumentShares;
using Inspection.Domain.Models.DMS.DocumentShares;
using Inspection.Infrastructure.QueryObjects.DMS.DocumentShares;
using Microsoft.EntityFrameworkCore;
using NDS.Shared.Application.DataQuery;
using NDS.Shared.Application.Multitenant;
using NDS.Shared.Infrastructure.DataContext;
using NDS.Shared.Infrastructure.RepositoryBase;
using NDS.Shared.Kernel.BaseReturnTypes;
using NDS.Shared.Kernel.Exceptions;

namespace Inspection.Infrastructure.Repositories.Query.DMS.DocumentShares
{


    public class DocumentShareQueryRepository : QueryRepositoryBase<DocumentShare>, IDocumentShareQueryRepository
    {
        public DocumentShareQueryRepository(ISqlQueryBuilder queryBuilder, DapperDbContext dapper, DbContext context, ITenantResolver tenantResolver, IExceptionManager exceptionManager) : base(queryBuilder, dapper, context, tenantResolver, exceptionManager)
        {

        }

        public async Task<DocumentShare?> GetById(long id)
        {
            return await _dbSet.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<IEnumerable<DocumentShare>> GetList(SqlQueryOptions sqlQueryOptions = null)
        {
            return await _dbSet.ToListAsync();
        }





        public async Task<ReturnBase<IEnumerable<DocumentShareReturnSearchDto>>> Search(SqlQueryOptions sqlQueryOptions)
        {
            var TaxQueryRepository = new DocumentShareQuery(_queryBuilder, _dapper, _tenantResolver, _exceptionManager);
            return await TaxQueryRepository.Query(sqlQueryOptions);
        }
    }
}
