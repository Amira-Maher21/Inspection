using Inspection.Application.Contracts.Dto.InspectionManagement.InspectionRequestDetailF;
using NDS.Shared.Application.DataQuery;
using NDS.Shared.Application.Multitenant;
using NDS.Shared.Infrastructure.DataContext;
using NDS.Shared.Kernel.BaseReturnTypes;
using NDS.Shared.Kernel.Exceptions;

namespace Inspection.Infrastructure.QueryObjects.InspectionManagement.InspectionRequestDetailF
{
    internal class InspectionRequestDetailQuery : QueryObjectBase<InspectionRequestLinesDtoByInclude>
    {
        public InspectionRequestDetailQuery(ISqlQueryBuilder queryBuilder, DapperDbContext dapper, ITenantResolver tenantResolver, IExceptionManager exceptionManager, string? fiscalYear = null) : base(queryBuilder, dapper, tenantResolver, exceptionManager, fiscalYear)
        {
        }

        public override async Task<ReturnBase<IEnumerable<InspectionRequestLinesDtoByInclude>>> Query(SqlQueryOptions queryOptions)
        {
            try
            {

                string tableName = "Inspection.InspectionRequestLines";
                string fields = "[Id], [ItemId], [Amount], [InspectionMethodId], [InspectionRequestId]";
                QueryStringData query = await _queryBuilder.GetQueryStringDataAsync(tableName, fields, queryOptions);

                var result = await this._dapper.QueryList<InspectionRequestLinesDtoByInclude>(query.QueryString!, query.Parameters.ToDictionary());
                if (!result.Succeeded)
                    return ReturnBase<IEnumerable<InspectionRequestLinesDtoByInclude>>.Fail(result.Errors);

                return ReturnBase<IEnumerable<InspectionRequestLinesDtoByInclude>>.Success(result.Result);
            }
            catch (Exception ex)
            {
                return ReturnBase<IEnumerable<InspectionRequestLinesDtoByInclude>>.Fail(ex, _exceptionManager);
            }
        }

        public override Task<ReturnBase<IEnumerable<InspectionRequestLinesDtoByInclude>>> Query(SqlQueryOptions queryOptions, string functionParameter)
        {
            throw new NotImplementedException();
        }
        public override Task<ReturnBase<IEnumerable<InspectionRequestLinesDtoByInclude>>> Query(SqlQueryOptions queryOptions, object[] functionParameters)
        {
            throw new NotImplementedException();
        }
    }
}