using Inspection.Application.Contracts.Dto.HRManagement.Departments;
using NDS.Shared.Application.DataQuery;
using NDS.Shared.Application.Multitenant;
using NDS.Shared.Infrastructure.DataContext;
using NDS.Shared.Kernel.BaseReturnTypes;
using NDS.Shared.Kernel.Exceptions;

namespace Inspection.Infrastructure.QueryObjects.HRManagement.Departments
{
    internal class DepartmentQuery : QueryObjectBase<DepartmentDto>
    {
        public DepartmentQuery(
            ISqlQueryBuilder queryBuilder,
            DapperDbContext dapper,
            ITenantResolver tenantResolver,
            IExceptionManager exceptionManager,
            string? fiscalYear = null
        ) : base(queryBuilder, dapper, tenantResolver, exceptionManager, fiscalYear)
        {
        }

        public override async Task<ReturnBase<IEnumerable<DepartmentDto>>> Query(SqlQueryOptions queryOptions)
        {
            try
            {
                string baseTable = "HR.Department";
                string baseAlias = "D";

                var selectFields = new List<string>
            {
                "D.Id",
                "D.Name"
             };

                var joins = new List<(string JoinType, string Table, string Alias, string Condition)>();

                var sql = base.ApplyJoinQuary(baseTable, baseAlias, selectFields, joins, queryOptions);

                var result = await _dapper.QueryList<DepartmentDto>(sql);

                if (!result.Succeeded)
                    return ReturnBase<IEnumerable<DepartmentDto>>.Fail(result.Errors);

                var list = base.ApplyFilters(result.Result, queryOptions);

                return ReturnBase<IEnumerable<DepartmentDto>>.Success(list);
            }
            catch (Exception ex)
            {
                return ReturnBase<IEnumerable<DepartmentDto>>.Fail(ex, _exceptionManager);
            }
        }

        public override Task<ReturnBase<IEnumerable<DepartmentDto>>> Query(SqlQueryOptions queryOptions, string functionParameter)
        {
            throw new NotImplementedException();
        }

        public override Task<ReturnBase<IEnumerable<DepartmentDto>>> Query(SqlQueryOptions queryOptions, object[] functionParameters)
        {
            throw new NotImplementedException();
        }
    }
}