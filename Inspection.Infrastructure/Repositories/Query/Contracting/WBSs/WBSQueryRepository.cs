using Inspection.Application.Contracts.Dto.ContractingDTOs.Setup.WBSs;
using Inspection.Application.Contracts.Repositories.Query.Contracting.Setup.WBSs;
using Inspection.Domain.Models.Contracting.Setup.WBSs;
using Inspection.Infrastructure.QueryObjects.Contracting.Setup.WBSs;
using Microsoft.EntityFrameworkCore;
using NDS.Shared.Application.DataQuery;
using NDS.Shared.Application.Multitenant;
using NDS.Shared.Infrastructure.DataContext;
using NDS.Shared.Infrastructure.RepositoryBase;
using NDS.Shared.Kernel.BaseReturnTypes;
using NDS.Shared.Kernel.Exceptions;

namespace Inspection.Infrastructure.Repositories.Query.Contracting.WBSs
{
    public class WBSQueryRepository : QueryRepositoryBase<WBS>, IWBSQueryRepository
    {
        public WBSQueryRepository(
            ISqlQueryBuilder queryBuilder,
            DapperDbContext dapper,
            DbContext context,
            ITenantResolver tenantResolver,
            IExceptionManager exceptionManager)
            : base(queryBuilder, dapper, context, tenantResolver, exceptionManager)
        {
        }


        public async Task<WBS?> GetById(long id)
        {
            return await _context.Set<WBS>().Where(x => x.Id == id).FirstOrDefaultAsync();
        }



        public async Task<ReturnBase<IEnumerable<WBSReturnSearchDto>>> Search(SqlQueryOptions sqlQueryOptions)
        {
            var WBSQueryRepository = new WBSQuery(_queryBuilder, _dapper, _tenantResolver, _exceptionManager);
            return await WBSQueryRepository.Query(sqlQueryOptions);
        }
    }
}
