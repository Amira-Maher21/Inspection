using Inspection.Application.Contracts.Dto.MenuManagement.AreaF;
using NDS.Shared.Application.DataQuery;
using NDS.Shared.Application.Multitenant;
using NDS.Shared.Infrastructure.DataContext;
using NDS.Shared.Kernel.BaseReturnTypes;
using NDS.Shared.Kernel.Exceptions;

namespace Inspection.Infrastructure.QueryObjects.MenuManagement.AreaF
{
    internal class AreaesQuery : QueryObjectBase<AreaIncludeDto>
    {
        public AreaesQuery(ISqlQueryBuilder queryBuilder, DapperDbContext dapper, ITenantResolver tenantResolver, IExceptionManager exceptionManager, string? fiscalYear = null) : base(queryBuilder, dapper, tenantResolver, exceptionManager, fiscalYear)
        {
        }


        public override async Task<ReturnBase<IEnumerable<AreaIncludeDto>>> Query(SqlQueryOptions queryOptions)
        {

            try
            {
                string baseTable = "Inspection.Area";
                string baseAlias = "A";

                var selectFields = new List<string>
                {
                    "A.Id",
                    "A.Name"

                };

                var joins = new List<(string JoinType, string Table, string Alias, string Condition)>();

                var sql = base.ApplyJoinQuary(baseTable, baseAlias, selectFields, joins, queryOptions);

                var result = await _dapper.QueryList<AreaIncludeDto>(sql);

                if (!result.Succeeded)
                    return ReturnBase<IEnumerable<AreaIncludeDto>>.Fail(result.Errors);

                var list = base.ApplyFilters(result.Result, queryOptions);
                return ReturnBase<IEnumerable<AreaIncludeDto>>.Success(list);
            }
            catch (Exception ex)
            {
                return ReturnBase<IEnumerable<AreaIncludeDto>>.Fail(ex, _exceptionManager);
            }
        }


        public override Task<ReturnBase<IEnumerable<AreaIncludeDto>>> Query(SqlQueryOptions queryOptions, string functionParameter)
        {
            throw new NotImplementedException();
        }

        public override Task<ReturnBase<IEnumerable<AreaIncludeDto>>> Query(SqlQueryOptions queryOptions, object[] functionParameters)
        {
            throw new NotImplementedException();
        }
    }
}
