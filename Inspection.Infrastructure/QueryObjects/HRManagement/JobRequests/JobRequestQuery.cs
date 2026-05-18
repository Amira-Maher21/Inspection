using Inspection.Application.Contracts.Dto.HRManagement.JobRequests;
using NDS.Shared.Application.DataQuery;
using NDS.Shared.Application.Multitenant;
using NDS.Shared.Infrastructure.DataContext;
using NDS.Shared.Kernel.BaseReturnTypes;
using NDS.Shared.Kernel.Exceptions;

namespace Inspection.Infrastructure.QueryObjects.HRManagement.JobRequests
{
    internal class JobRequestQuery : QueryObjectBase<JobRequestDto>
    {
        public JobRequestQuery(
           ISqlQueryBuilder queryBuilder,
           DapperDbContext dapper,
           ITenantResolver tenantResolver,
           IExceptionManager exceptionManager,
           string? fiscalYear = null
       ) : base(queryBuilder, dapper, tenantResolver, exceptionManager, fiscalYear)
        {
        }

        public override async Task<ReturnBase<IEnumerable<JobRequestDto>>> Query(SqlQueryOptions queryOptions)
        {
            try
            {
                string baseTable = "HR.JobRequest";
                string baseAlias = "JR";

                var selectFields = new List<string>
        {
            "JR.Id",
            "JR.DepartmentId",
            "D.Name AS DepartmentName",
            "JR.JobTitleId",
            "JT.Title AS JobTitleName",
            "JR.JobDescription",
            "JR.NeededPositions",
            "JR.Status",
            "JR.RequestedAt"
        };

                var joins = new List<(string JoinType, string Table, string Alias, string Condition)>
        {
            ("INNER JOIN", "HR.Department D", "", "D.Id = JR.DepartmentId"),
            ("INNER JOIN", "HR.JobTitle JT", "", "JT.Id = JR.JobTitleId")
        };

                var sql = base.ApplyJoinQuary(baseTable, baseAlias, selectFields, joins, queryOptions);

                var result = await _dapper.QueryList<JobRequestDto>(sql);

                if (!result.Succeeded)
                    return ReturnBase<IEnumerable<JobRequestDto>>.Fail(result.Errors);

                var list = base.ApplyFilters(result.Result, queryOptions);

                return ReturnBase<IEnumerable<JobRequestDto>>.Success(list);
            }
            catch (Exception ex)
            {
                return ReturnBase<IEnumerable<JobRequestDto>>.Fail(ex, _exceptionManager);
            }
        }

        public override Task<ReturnBase<IEnumerable<JobRequestDto>>> Query(SqlQueryOptions queryOptions, string functionParameter)
        {
            throw new NotImplementedException();
        }

        public override Task<ReturnBase<IEnumerable<JobRequestDto>>> Query(SqlQueryOptions queryOptions, object[] functionParameters)
        {
            throw new NotImplementedException();
        }
    }
}
