using Inspection.Application.Contracts.Dto.SystemDto.Taxs;
using Inspection.Application.Contracts.Repositories.Query.System;
using Inspection.Domain.Models.System.Taxes;
using Inspection.Infrastructure.QueryObjects.System.TaxQueries;
using Microsoft.EntityFrameworkCore;
using NDS.Shared.Application.DataQuery;
using NDS.Shared.Application.Multitenant;
using NDS.Shared.Infrastructure.DataContext;
using NDS.Shared.Infrastructure.RepositoryBase;
using NDS.Shared.Kernel.BaseReturnTypes;
using NDS.Shared.Kernel.Exceptions;

namespace Inspection.Infrastructure.Repositories.Query.System
{
    public class TaxTypeQueryRepository : QueryRepositoryBase<TaxType>, ITaxTypeQueryRepository
    {
        public TaxTypeQueryRepository(ISqlQueryBuilder queryBuilder, DapperDbContext dapper, DbContext context, ITenantResolver tenantResolver, IExceptionManager exceptionManager) : base(queryBuilder, dapper, context, tenantResolver, exceptionManager)
        {

        }



        public async Task<TaxType?> GetById(long id)
        {
            return await _dbSet
                .Include(c => c.TaxTypeLine)
                .FirstOrDefaultAsync(c => c.Id == id);
        }




        public async Task<IEnumerable<TaxType>> GetList(SqlQueryOptions sqlQueryOptions = null)
        {
            return await _dbSet
                        .Include(x => x.TaxTypeLine)
                        .ToListAsync();
        }



        public async Task<ReturnBase<IEnumerable<TaxReturnSearchDto>>> Search(SqlQueryOptions sqlQueryOptions)
        {
            try
            {
                var TaxQueryRepository = new TaxQuery(
                    _queryBuilder,
                    _dapper,
                    _tenantResolver,
                    _exceptionManager
                );

                var queryResult = await TaxQueryRepository.Query(sqlQueryOptions);

                if (!queryResult.Succeeded)
                    return ReturnBase<IEnumerable<TaxReturnSearchDto>>.Fail(queryResult.Errors);

                return ReturnBase<IEnumerable<TaxReturnSearchDto>>.Success(queryResult.Result);
            }
            catch (Exception ex)
            {
                return ReturnBase<IEnumerable<TaxReturnSearchDto>>.Fail(ex, _exceptionManager);
            }
        }





    }
}
