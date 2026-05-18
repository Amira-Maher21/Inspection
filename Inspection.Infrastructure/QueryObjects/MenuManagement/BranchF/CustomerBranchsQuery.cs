using Inspection.Application.Contracts.Dto.MenuManagement.BranchF;
using NDS.Shared.Application.DataQuery;
using NDS.Shared.Application.Multitenant;
using NDS.Shared.Infrastructure.DataContext;
using NDS.Shared.Kernel.BaseReturnTypes;
using NDS.Shared.Kernel.Exceptions;

namespace Inspection.Infrastructure.QueryObjects.MenuManagement.BranchF
{
    internal class CustomerBranchsQuery : QueryObjectBase<CustomerBranchIncludeDto>
    {
        public CustomerBranchsQuery(ISqlQueryBuilder queryBuilder, DapperDbContext dapper, ITenantResolver tenantResolver, IExceptionManager exceptionManager, string? fiscalYear = null) : base(queryBuilder, dapper, tenantResolver, exceptionManager, fiscalYear)
        {
        }

        public override async Task<ReturnBase<IEnumerable<CustomerBranchIncludeDto>>> Query(SqlQueryOptions queryOptions)
        {

            try
            {
                string baseTable = "Inspection.CustomerBranch";
                string baseAlias = "B";

                var selectFields = new List<string>
                {
                    "B.Id",
                    "B.NameAr",
                    "B.NameEn",
                    "B.Address",
                    "B.Phone",


                };

                var joins = new List<(string JoinType, string Table, string Alias, string Condition)>();

                var sql = base.ApplyJoinQuary(baseTable, baseAlias, selectFields, joins, queryOptions);

                var result = await _dapper.QueryList<CustomerBranchIncludeDto>(sql);

                if (!result.Succeeded)
                    return ReturnBase<IEnumerable<CustomerBranchIncludeDto>>.Fail(result.Errors);

                var list = base.ApplyFilters(result.Result, queryOptions);
                return ReturnBase<IEnumerable<CustomerBranchIncludeDto>>.Success(list);
            }
            catch (Exception ex)
            {
                return ReturnBase<IEnumerable<CustomerBranchIncludeDto>>.Fail(ex, _exceptionManager);
            }
        }

        public override Task<ReturnBase<IEnumerable<CustomerBranchIncludeDto>>> Query(SqlQueryOptions queryOptions, string functionParameter)
        {
            throw new NotImplementedException();
        }

        public override Task<ReturnBase<IEnumerable<CustomerBranchIncludeDto>>> Query(SqlQueryOptions queryOptions, object[] functionParameters)
        {
            throw new NotImplementedException();
        }
    }
}