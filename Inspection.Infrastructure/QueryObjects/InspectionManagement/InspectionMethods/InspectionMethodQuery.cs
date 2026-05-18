using Inspection.Application.Contracts.Dto.InspectionManagement.InspectionMethodDTOs;
using NDS.Shared.Application.DataQuery;
using NDS.Shared.Application.Multitenant;
using NDS.Shared.Infrastructure.DataContext;
using NDS.Shared.Kernel.BaseReturnTypes;
using NDS.Shared.Kernel.Exceptions;

namespace Inspection.Infrastructure.QueryObjects.InspectionManagement.InspectionMethods
{
    public class InspectionMethodQuery : QueryObjectBase<InspectionMethodReturnSearchDto>
    {
        public InspectionMethodQuery(ISqlQueryBuilder queryBuilder, DapperDbContext dapper, ITenantResolver tenantResolver, IExceptionManager exceptionManager) : base(queryBuilder, dapper, tenantResolver, exceptionManager)
        {
        }

        public override async Task<ReturnBase<IEnumerable<InspectionMethodReturnSearchDto>>> Query(SqlQueryOptions queryOptions)
        {
            try
            {

                string tableName = "Inspection.InspectionMethod";
                string fields = "[Id],[Tenant_ID],[CompanyId],[Name], [Code],[SeriesId], [RunningNumber],[In_User],[In_Date],[Mod_User],[Mod_Date] ";
                QueryStringData query = await _queryBuilder.GetQueryStringDataAsync(tableName, fields, queryOptions);

                var result = await this._dapper.QueryList<InspectionMethodReturnSearchDto>(query.QueryString!, query.Parameters.ToDictionary());
                if (!result.Succeeded)
                    return ReturnBase<IEnumerable<InspectionMethodReturnSearchDto>>.Fail(result.Errors);

                return ReturnBase<IEnumerable<InspectionMethodReturnSearchDto>>.Success(result.Result);
            }
            catch (Exception ex)
            {
                return ReturnBase<IEnumerable<InspectionMethodReturnSearchDto>>.Fail(ex, _exceptionManager);
            }
        }

        public override Task<ReturnBase<IEnumerable<InspectionMethodReturnSearchDto>>> Query(SqlQueryOptions queryOptions, string functionParameter)
        {
            throw new NotImplementedException();
        }
        public override Task<ReturnBase<IEnumerable<InspectionMethodReturnSearchDto>>> Query(SqlQueryOptions queryOptions, object[] functionParameters)
        {
            throw new NotImplementedException();
        }
    }
}