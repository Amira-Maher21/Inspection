using Inspection.Application.Contracts.Dto.HRManagement.Employees;
using NDS.Shared.Application.DataQuery;
using NDS.Shared.Application.Multitenant;
using NDS.Shared.Infrastructure.DataContext;
using NDS.Shared.Kernel.BaseReturnTypes;
using NDS.Shared.Kernel.Exceptions;

namespace Inspection.Infrastructure.QueryObjects.HRManagement.Employees
{
    internal class EmployeeQuery : QueryObjectBase<EmployeeDto>
    {
        public EmployeeQuery(
            ISqlQueryBuilder queryBuilder,
            DapperDbContext dapper,
            ITenantResolver tenantResolver,
            IExceptionManager exceptionManager,
            string? fiscalYear = null
        ) : base(queryBuilder, dapper, tenantResolver, exceptionManager, fiscalYear)
        {
        }

        public override async Task<ReturnBase<IEnumerable<EmployeeDto>>> Query(SqlQueryOptions queryOptions)
        {
            try
            {
                string baseTable = "HR.Employee";
                string baseAlias = "E";

                var selectFields = new List<string>
            {
                "E.Id",
                "E.CVId",
                //"E.FullName",
                 "E.FullName AS EmployeeFullName",
                 "ACV.FullName AS ApplicantFullName",
                "E.EmployeeCode",
                "E.JobTitleId",
                "JT.Title AS JobTitleName",
                "E.DepartmentId",
                "D.Name AS DepartmentName",
                "E.PhotoUrl",
                "E.NationalId",
                "E.Qualifications",
                "E.HireDate"
            };

                var joins = new List<(string JoinType, string Table, string Alias, string Condition)>
            {
                ("LEFT JOIN", "HR.JobTitle JT", "JT", "JT.Id = E.JobTitleId"),
                ("LEFT JOIN", "HR.Department D", "D", "D.Id = E.DepartmentId"),
                ("LEFT JOIN", "HR.ApplicantCV ACV", "ACV", "ACV.Id = E.CVId")
            };

                var sql = base.ApplyJoinQuary(baseTable, baseAlias, selectFields, joins, queryOptions);

                var result = await _dapper.QueryList<EmployeeDto>(sql);

                if (!result.Succeeded)
                    return ReturnBase<IEnumerable<EmployeeDto>>.Fail(result.Errors);

                var list = base.ApplyFilters(result.Result, queryOptions);

                return ReturnBase<IEnumerable<EmployeeDto>>.Success(list);
            }
            catch (Exception ex)
            {
                return ReturnBase<IEnumerable<EmployeeDto>>.Fail(ex, _exceptionManager);
            }
        }

        public override Task<ReturnBase<IEnumerable<EmployeeDto>>> Query(SqlQueryOptions queryOptions, string functionParameter)
        {
            throw new NotImplementedException();
        }

        public override Task<ReturnBase<IEnumerable<EmployeeDto>>> Query(SqlQueryOptions queryOptions, object[] functionParameters)
        {
            throw new NotImplementedException();
        }
    }
}