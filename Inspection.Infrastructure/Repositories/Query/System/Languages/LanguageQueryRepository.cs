using Inspection.Application.Contracts.Dto.SystemDto.Languages;
using Inspection.Application.Contracts.Repositories.Query.System.Languages;
using Inspection.Domain.Models.System.Languages;
using Inspection.Infrastructure.QueryObjects.System.Languages;
using Microsoft.EntityFrameworkCore;
using NDS.Shared.Application.DataQuery;
using NDS.Shared.Application.Multitenant;
using NDS.Shared.Infrastructure.DataContext;
using NDS.Shared.Infrastructure.RepositoryBase;
using NDS.Shared.Kernel.BaseReturnTypes;
using NDS.Shared.Kernel.Exceptions;

namespace Inspection.Infrastructure.Repositories.Query.System.Languages
{

    public class LanguageQueryRepository : QueryRepositoryBase<Language>, ILanguageQueryRepository
    {
        public LanguageQueryRepository(ISqlQueryBuilder queryBuilder, DapperDbContext dapper, DbContext context, ITenantResolver tenantResolver, IExceptionManager exceptionManager) : base(queryBuilder, dapper, context, tenantResolver, exceptionManager)
        {

        }



        public async Task<Language?> GetById(string LocaleCode)
        {
            return await _dbSet
                 .FirstOrDefaultAsync(c => c.LocaleCode == LocaleCode);
        }



        public async Task<IEnumerable<Language>> GetList(SqlQueryOptions sqlQueryOptions = null)
        {
            return await _dbSet
                         .ToListAsync();
        }



        public async Task<ReturnBase<IEnumerable<LanguageReturnSearchDto>>> Search(SqlQueryOptions sqlQueryOptions)
        {
            try
            {
                var TaxQueryRepository = new LanguageQuery(
                    _queryBuilder,
                    _dapper,
                    _tenantResolver,
                    _exceptionManager
                );

                var queryResult = await TaxQueryRepository.Query(sqlQueryOptions);

                if (!queryResult.Succeeded)
                    return ReturnBase<IEnumerable<LanguageReturnSearchDto>>.Fail(queryResult.Errors);

                return ReturnBase<IEnumerable<LanguageReturnSearchDto>>.Success(queryResult.Result);
            }
            catch (Exception ex)
            {
                return ReturnBase<IEnumerable<LanguageReturnSearchDto>>.Fail(ex, _exceptionManager);
            }
        }





    }

}
