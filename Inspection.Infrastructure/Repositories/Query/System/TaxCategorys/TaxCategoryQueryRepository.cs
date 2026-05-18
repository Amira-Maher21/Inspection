using Inspection.Application.Contracts.Dto.SystemDto.TaxCategorys;
using Inspection.Application.Contracts.Repositories.Query.System.TaxCategorys;
using Inspection.Domain.Models.System.Taxestegories;
using Inspection.Infrastructure.QueryObjects.System.TaxCategorys;
using Microsoft.EntityFrameworkCore;
using NDS.Shared.Application.DataQuery;
using NDS.Shared.Application.Multitenant;
using NDS.Shared.Infrastructure.DataContext;
using NDS.Shared.Infrastructure.RepositoryBase;
using NDS.Shared.Kernel.BaseReturnTypes;
using NDS.Shared.Kernel.Exceptions;

namespace Inspection.Infrastructure.Repositories.Query.System.TaxCategorys
{
    public class TaxCategoryQueryRepository : QueryRepositoryBase<TaxCategory>, ITaxCategoryQueryRepository

    {
        public TaxCategoryQueryRepository(ISqlQueryBuilder queryBuilder, DapperDbContext dapper, DbContext context, ITenantResolver tenantResolver, IExceptionManager exceptionManager) : base(queryBuilder, dapper, context, tenantResolver, exceptionManager)
        {
        }

        public async Task<TaxCategory?> GetByCode(string code)
        {
            return await _context.Set<TaxCategory>()
                .Where(x => x.Code == code)
                .FirstOrDefaultAsync();
        }


        public async Task<TaxCategory?> GetById(long id)
        {
            return await _context.Set<TaxCategory>().Where(x => x.Id == id).FirstOrDefaultAsync();
        }

        public async Task<ReturnBase<IEnumerable<TaxCategoryDto>>> Search(SqlQueryOptions sqlQueryOptions)
        {
            var countryQuery = new TaxCategoryQuery(
                _queryBuilder,
                _dapper,
                _tenantResolver,
                _exceptionManager
            );

            return await countryQuery.Query(sqlQueryOptions);
        }



    }
}
