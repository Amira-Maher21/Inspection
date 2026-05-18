using Inspection.Application.Contracts.Dto.AccountingDtos.AR.MasterData.CustomerGroup;
using Inspection.Application.Contracts.Repositories.Query.Accounting.AR.MasterData;
using Inspection.Domain.Models.Accounting.AR.MasterData;
using Inspection.Infrastructure.QueryObjects.Accounting.AR.MasterData;
using Microsoft.EntityFrameworkCore;
using NDS.Shared.Application.DataQuery;
using NDS.Shared.Application.Multitenant;
using NDS.Shared.Infrastructure.DataContext;
using NDS.Shared.Infrastructure.RepositoryBase;
using NDS.Shared.Kernel.BaseReturnTypes;
using NDS.Shared.Kernel.Exceptions;

namespace Inspection.Infrastructure.Repositories.Query.Accounting.AR.MasterData
{
    public class CustomerGroupQueryRepository : QueryRepositoryBase<CustomerGroup>, ICustomerGroupQueryRepository
    {
        public CustomerGroupQueryRepository(ISqlQueryBuilder queryBuilder, DapperDbContext dapper, DbContext context, ITenantResolver tenantResolver, IExceptionManager exceptionManager) : base(queryBuilder, dapper, context, tenantResolver, exceptionManager)
        {
        }

        public async Task<ReturnBase<List<CustomerGroup>>> GetAll()
        {
            var result = await _context.Set<CustomerGroup>().AsNoTracking().ToListAsync();
            return ReturnBase<List<CustomerGroup>>.Success(result);
        }

        public async Task<CustomerGroup?> GetById(long id)
        {
            return await _context.Set<CustomerGroup>().Where(x => x.Id == id).FirstOrDefaultAsync();
        }



        public async Task<ReturnBase<IEnumerable<CustomerGroupReturnSearchDto>>> Search(SqlQueryOptions sqlQueryOptions)
        {
            var CustomerGroupRepository = new CustomerGroupQuery(_queryBuilder, _dapper, _tenantResolver, _exceptionManager);
            return await CustomerGroupRepository.Query(sqlQueryOptions);
        }


    }
}
