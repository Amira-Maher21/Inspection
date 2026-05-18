using Inspection.Application.Contracts.Dto.AccountingDtos.AccountingSetupDtos.CostCenterDTOs;
using Inspection.Application.Contracts.Repositories.Query.Accounting.AccountSetup;
using Inspection.Domain.Models.Accounting.AccountingSetup;
using Inspection.Infrastructure.QueryObjects.Accounting.AccountSetup;
using Microsoft.EntityFrameworkCore;
using NDS.Shared.Application.DataQuery;
using NDS.Shared.Application.Multitenant;
using NDS.Shared.Infrastructure.DataContext;
using NDS.Shared.Infrastructure.RepositoryBase;
using NDS.Shared.Kernel.BaseReturnTypes;
using NDS.Shared.Kernel.Exceptions;

namespace Inspection.Infrastructure.Repositories.Query.Accounting.AccountSetup
{
    public class CostCenterQueryRepository : QueryRepositoryBase<CostCenter>, ICostCenterQueryRepository
    {
        public CostCenterQueryRepository(ISqlQueryBuilder queryBuilder, DapperDbContext dapper, DbContext context, ITenantResolver tenantResolver, IExceptionManager exceptionManager) : base(queryBuilder, dapper, context, tenantResolver, exceptionManager)
        {
        }

        public async Task<CostCenter?> GetById(long id)
        {
            return await _context.Set<CostCenter>().Where(x => x.Id == id).FirstOrDefaultAsync();

        }
        public async Task<CostCenter?> GetByCode(string code)
        {
            return await _context.Set<CostCenter>().Where(x => x.Code == code).FirstOrDefaultAsync();
        }

        public async Task<ReturnBase<IEnumerable<CostCenterReturnSearchDto>>> GetCompanyIdAndName(SqlQueryOptions queryOptions)
        {
            var CostCenterRepository = new CostCenterQuery(_queryBuilder, _dapper, _tenantResolver, _exceptionManager);

            return await CostCenterRepository.Query(queryOptions);

        }


        public async Task<ReturnBase<IEnumerable<CostCenterReturnSearchDto>>> Search(SqlQueryOptions sqlQueryOptions)
        {
            try
            {
                var customerQuery = new CostCenterQuery(
                    _queryBuilder,
                    _dapper,
                    _tenantResolver,
                    _exceptionManager
                );

                var queryResult = await customerQuery.Query(sqlQueryOptions);

                if (!queryResult.Succeeded)
                    return ReturnBase<IEnumerable<CostCenterReturnSearchDto>>.Fail(queryResult.Errors);

                return ReturnBase<IEnumerable<CostCenterReturnSearchDto>>.Success(queryResult.Result);
            }
            catch (Exception ex)
            {
                return ReturnBase<IEnumerable<CostCenterReturnSearchDto>>.Fail(ex, _exceptionManager);
            }
        }

    }
}