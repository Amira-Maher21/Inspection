using NDS.Shared.Application.DataQuery;
using NDS.Shared.Application.Multitenant;
using NDS.Shared.Infrastructure.DataContext;
using NDS.Shared.Kernel.BaseReturnTypes;
using NDS.Shared.Kernel.Exceptions;

namespace Inspection.Infrastructure.QueryObjects
{
    internal abstract class BaseQueryObject<TResult> : IQueryObject<TResult>
    {
        protected readonly ISqlQueryBuilder _queryBuilder;
        protected readonly DapperDbContext _dapper;
        protected readonly ITenantResolver _tenantResolver;
        protected readonly IExceptionManager _exceptionManager;
        protected string? _fiscalYear;

        protected BaseQueryObject(ISqlQueryBuilder queryBuilder,
                                    DapperDbContext dapper,
                                    ITenantResolver tenantResolver,
                                    IExceptionManager exceptionManager,
                                    string? fiscalYear = null)
        {
            _queryBuilder = queryBuilder;
            _dapper = dapper;
            _tenantResolver = tenantResolver;
            _exceptionManager = exceptionManager;
            _fiscalYear = fiscalYear;
        }

        public abstract Task<ReturnBase<IEnumerable<TResult>>> Query(SqlQueryOptions queryOptions);

        public abstract Task<ReturnBase<IEnumerable<TResult>>> Query(SqlQueryOptions queryOptions, object[] functionParameters);

    }
}