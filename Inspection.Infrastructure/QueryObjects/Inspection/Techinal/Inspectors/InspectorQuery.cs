using Inspection.Application.Contracts.Dto.InspectionDto.Techinal.InspectorDTOs;
using NDS.Shared.Application.DataQuery;
using NDS.Shared.Application.Multitenant;
using NDS.Shared.Infrastructure.DataContext;
using NDS.Shared.Kernel.BaseReturnTypes;
using NDS.Shared.Kernel.Exceptions;

namespace Inspection.Infrastructure.QueryObjects.Inspection.Techinal.Inspectors
{
    public class InspectorQuery : QueryObjectBase<InspectorReturnSearchDto>
    {
        public InspectorQuery(ISqlQueryBuilder queryBuilder, DapperDbContext dapper, ITenantResolver tenantResolver, IExceptionManager exceptionManager) : base(queryBuilder, dapper, tenantResolver, exceptionManager)
        {
        }

        public override async Task<ReturnBase<IEnumerable<InspectorReturnSearchDto>>> Query(SqlQueryOptions queryOptions)
        {
            try
            {
                string tableName = "Inspection.Inspector";

                var selectFields = new[]
                {
                    "Id",
                    "Tenant_ID",
                    "CompanyId",
                    "EmployeeId",
                    "User_CodeId",
                    "InspectorCategoryId",
                    "Code",
                    "FirstName",
                    "LastName",
                    "Email",
                    "Phone",
                    "HireDate",
                    "Disabled",
                    "QualificationNotes",
                    "Remarks",
                    "In_User",
                    "In_Date",
                    "Mod_User",
                    "Mod_Date"
               };

                // Joins
                var employeeJoin = new JoinTable(
                    "HR.Employee",
                    "EmployeeCode EmployeeCode, FullName EmployeeName",
                    "EmployeeId Id"
                    );
                var userJoin = new JoinTable(
                    "Sec.User_Code",
                    "Id User_CodeId, User_Name UserName",
                    "User_CodeId Id"
                    );

                var inspectorCategoryJoin = new JoinTable(
                    "Inspection.InspectorCategory",
                    "Code InspectorCategoryCode, Name InspectorCategoryName",
                    "InspectorCategoryId Id"
                    );


                var queryData = await _queryBuilder.GetQueryStringDataAsync(
                    tableName,
                    string.Join(", ", selectFields),
                    new List<JoinTable> { employeeJoin, userJoin, inspectorCategoryJoin },
                    queryOptions
                );

                var queryResult = await _dapper.QueryList<InspectorReturnSearchDto>(
                    queryData.QueryString!,
                    queryData.Parameters!.ToDictionary()
                );

                return ReturnBase<IEnumerable<InspectorReturnSearchDto>>.Success(queryResult.Result);
            }
            catch (Exception ex)
            {
                return ReturnBase<IEnumerable<InspectorReturnSearchDto>>.Fail(ex, _exceptionManager);
            }
        }
        public override Task<ReturnBase<IEnumerable<InspectorReturnSearchDto>>> Query(SqlQueryOptions queryOptions, string functionParameter)
        {
            throw new NotImplementedException();
        }

        public override Task<ReturnBase<IEnumerable<InspectorReturnSearchDto>>> Query(SqlQueryOptions queryOptions, object[] functionParameters)
        {
            throw new NotImplementedException();
        }
    }
}