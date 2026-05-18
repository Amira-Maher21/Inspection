using Inspection.Application.Contracts.Dto.InspectionManagement.InspectionTypes;
using NDS.Shared.Application.DataQuery;
using NDS.Shared.Application.Multitenant;
using NDS.Shared.Infrastructure.DataContext;
using NDS.Shared.Kernel.BaseReturnTypes;
using NDS.Shared.Kernel.Exceptions;

namespace Inspection.Infrastructure.QueryObjects.InspectionManagement.InspectionTypes
{

    internal class InspectionTypeQuery : QueryObjectBase<InspectionTypeDto>
    {
        public InspectionTypeQuery(ISqlQueryBuilder queryBuilder, DapperDbContext dapper, ITenantResolver tenantResolver, IExceptionManager exceptionManager) : base(queryBuilder, dapper, tenantResolver, exceptionManager)
        {
        }
        public override async Task<ReturnBase<IEnumerable<InspectionTypeDto>>> Query(SqlQueryOptions queryOptions)
        {
            try
            {
                string tableName = "Inspection.InspectionType";
                string fields = "[Id],[Tenant_ID],[CompanyId], [Code],[Name],[In_User],[In_Date],[Mod_User],[Mod_Date]";
                QueryStringData query = await _queryBuilder.GetQueryStringDataAsync(tableName, fields, queryOptions);

                var result = await this._dapper.QueryList<InspectionTypeDto>(query.QueryString!, query.Parameters.ToDictionary());
                if (!result.Succeeded)
                    return ReturnBase<IEnumerable<InspectionTypeDto>>.Fail(result.Errors);

                return ReturnBase<IEnumerable<InspectionTypeDto>>.Success(result.Result);
            }
            catch (Exception ex)
            {
                return ReturnBase<IEnumerable<InspectionTypeDto>>.Fail(ex, _exceptionManager);
            }
        }

        public override Task<ReturnBase<IEnumerable<InspectionTypeDto>>> Query(SqlQueryOptions queryOptions, string functionParameter)
        {
            throw new NotImplementedException();
        }
        public override Task<ReturnBase<IEnumerable<InspectionTypeDto>>> Query(SqlQueryOptions queryOptions, object[] functionParameters)
        {
            throw new NotImplementedException();
        }
    }
}