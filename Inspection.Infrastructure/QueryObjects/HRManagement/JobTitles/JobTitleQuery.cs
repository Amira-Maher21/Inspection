using Inspection.Application.Contracts.Dto.HRManagement.JobTitles;
using NDS.Shared.Application.DataQuery;
using NDS.Shared.Application.Multitenant;
using NDS.Shared.Infrastructure.DataContext;
using NDS.Shared.Kernel.BaseReturnTypes;
using NDS.Shared.Kernel.Exceptions;

namespace Inspection.Infrastructure.QueryObjects.HRManagement.JobTitles
{
    internal class JobTitleQuery : QueryObjectBase<JobTitleDto>
    {
        public JobTitleQuery(
          ISqlQueryBuilder queryBuilder,
          DapperDbContext dapper,
          ITenantResolver tenantResolver,
          IExceptionManager exceptionManager,
          string? fiscalYear = null
      ) : base(queryBuilder, dapper, tenantResolver, exceptionManager, fiscalYear)
        {
        }
        public override async Task<ReturnBase<IEnumerable<JobTitleDto>>> Query(SqlQueryOptions queryOptions)
        {
            try
            {
                string baseTable = "HR.JobTitle";
                string baseAlias = "JT";

                // الحقول اللي عايزين نرجعها
                var selectFields = new List<string>
        {
            "JT.Id",
            "JT.Title",
            "JT.DepartmentId",
            "D.Name AS DepartmentName"
        };

                // الـ joins المطلوبة
                var joins = new List<(string JoinType, string Table, string Alias, string Condition)>
        {
            ("INNER JOIN", "HR.Department D", "", "D.Id = JT.DepartmentId")
        };

                // بناء الاستعلام
                var sql = base.ApplyJoinQuary(baseTable, baseAlias, selectFields, joins, queryOptions);

                // تنفيذ الاستعلام
                var result = await _dapper.QueryList<JobTitleDto>(sql);

                if (!result.Succeeded)
                    return ReturnBase<IEnumerable<JobTitleDto>>.Fail(result.Errors);

                // تطبيق الفلاتر
                var list = base.ApplyFilters(result.Result, queryOptions);

                return ReturnBase<IEnumerable<JobTitleDto>>.Success(list);
            }
            catch (Exception ex)
            {
                return ReturnBase<IEnumerable<JobTitleDto>>.Fail(ex, _exceptionManager);
            }
        }

        public override Task<ReturnBase<IEnumerable<JobTitleDto>>> Query(SqlQueryOptions queryOptions, string functionParameter)
        {
            throw new NotImplementedException();
        }

        public override Task<ReturnBase<IEnumerable<JobTitleDto>>> Query(SqlQueryOptions queryOptions, object[] functionParameters)
        {
            throw new NotImplementedException();
        }
    }
}