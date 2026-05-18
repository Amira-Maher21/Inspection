using Inspection.Application.Contracts.Dto.AccountingDtos.AccountSystemDto.DefaultAccountTypeDto;
using Inspection.Application.Contracts.Repositories.Query.Accounting.AccountSystem;
using Inspection.Domain.Models.Accounting.AccountingSystem;
using Inspection.Infrastructure.QueryObjects.Accounting.AccountingSystem;
using Microsoft.EntityFrameworkCore;
using NDS.Shared.Application.DataQuery;
using NDS.Shared.Application.Multitenant;
using NDS.Shared.Infrastructure.DataContext;
using NDS.Shared.Infrastructure.RepositoryBase;
using NDS.Shared.Kernel.BaseReturnTypes;
using NDS.Shared.Kernel.Exceptions;

namespace Inspection.Infrastructure.Repositories.Query.Accounting.AccountSystem
{
    public class DefaultAccountTypeQueryRepository : QueryRepositoryBase<DefaultAccountType>, IDefaultAccountTypeQueryRepository
    {
        public DefaultAccountTypeQueryRepository(ISqlQueryBuilder queryBuilder, DapperDbContext dapper, DbContext context, ITenantResolver tenantResolver, IExceptionManager exceptionManager) : base(queryBuilder, dapper, context, tenantResolver, exceptionManager)
        {
        }

        public async Task<ReturnBase<List<DefaultAccountType>>> GetAll()
        {
            var result = await _context.Set<DefaultAccountType>().AsNoTracking().ToListAsync();
            return ReturnBase<List<DefaultAccountType>>.Success(result);
        }

        public async Task<DefaultAccountType?> GetById(long id)
        {
            return await _context.Set<DefaultAccountType>().Where(x => x.Id == id).FirstOrDefaultAsync();
        }



        public async Task<ReturnBase<IEnumerable<DefaultAccountTypeReturnSearchDto>>> Search(SqlQueryOptions sqlQueryOptions)
        {
            var defaultAccountTypeRepository = new DefaultAccountTypeQuery(_queryBuilder, _dapper, _tenantResolver, _exceptionManager);
            return await defaultAccountTypeRepository.Query(sqlQueryOptions);
        }


    }
}
