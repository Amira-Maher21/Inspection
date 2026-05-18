using Inspection.Application.Contracts.Dto.AccountingDtos.PR.MasterData.SupplierGroups;
using Inspection.Application.Contracts.Repositories.Query.Accounting.PR.Master.SupplierGroups;
using Inspection.Domain.Models.Accounting.PR.MasterData.Suppliers;
using Inspection.Infrastructure.QueryObjects.Accounting.PR.MasterData.SupplierGroups;
using Microsoft.EntityFrameworkCore;
using NDS.Shared.Application.DataQuery;
using NDS.Shared.Application.Multitenant;
using NDS.Shared.Infrastructure.DataContext;
using NDS.Shared.Infrastructure.RepositoryBase;
using NDS.Shared.Kernel.BaseReturnTypes;
using NDS.Shared.Kernel.Exceptions;

namespace Inspection.Infrastructure.Repositories.Query.Accounting.PR.Master.SupplierGroups
{
    public class SupplierGroupQueryRepository : QueryRepositoryBase<SupplierGroup>, ISupplierGroupQueryRepository
    {
        public SupplierGroupQueryRepository(ISqlQueryBuilder queryBuilder, DapperDbContext dapper, DbContext context, ITenantResolver tenantResolver, IExceptionManager exceptionManager) : base(queryBuilder, dapper, context, tenantResolver, exceptionManager)
        {
        }

        public async Task<ReturnBase<List<SupplierGroup>>> GetAll()
        {
            var result = await _context.Set<SupplierGroup>().AsNoTracking().ToListAsync();
            return ReturnBase<List<SupplierGroup>>.Success(result);
        }

        public async Task<SupplierGroup?> GetById(long id)
        {
            return await _context.Set<SupplierGroup>().Where(x => x.Id == id).FirstOrDefaultAsync();
        }



        public async Task<ReturnBase<IEnumerable<SupplierGroupReturnSearchDto>>> Search(SqlQueryOptions sqlQueryOptions)
        {
            var SupplierGroupRepository = new SupplierGroupQuery(_queryBuilder, _dapper, _tenantResolver, _exceptionManager);
            return await SupplierGroupRepository.Query(sqlQueryOptions);
        }


    }
}
