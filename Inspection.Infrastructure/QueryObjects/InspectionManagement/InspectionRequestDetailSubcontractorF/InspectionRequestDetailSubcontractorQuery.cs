using Inspection.Application.Contracts.Dto.InspectionManagement.InspectionRequestSubcontractorDetailF;
using NDS.Shared.Application.DataQuery;
using NDS.Shared.Application.Multitenant;
using NDS.Shared.Infrastructure.DataContext;
using NDS.Shared.Kernel.BaseReturnTypes;
using NDS.Shared.Kernel.Exceptions;

namespace Inspection.Infrastructure.QueryObjects.InspectionManagement.InspectionRequestDetailSubcontractorF
{

    internal class InspectionRequestDetailSubcontractorQuery : QueryObjectBase<InspectionRequestSubcontractorDetailDtoByInclude>
    {
        public InspectionRequestDetailSubcontractorQuery(ISqlQueryBuilder queryBuilder, DapperDbContext dapper, ITenantResolver tenantResolver, IExceptionManager exceptionManager, string? fiscalYear = null) : base(queryBuilder, dapper, tenantResolver, exceptionManager, fiscalYear)
        {
        }

        public override async Task<ReturnBase<IEnumerable<InspectionRequestSubcontractorDetailDtoByInclude>>> Query(SqlQueryOptions queryOptions)
        {
            try
            {

                string tableName = "Inspection.InspectionRequestSubcontractorDetail";
                string fields = "[Id], [ServiceItemId],[SubcontractorName],[Amount], [InspectionMethodId], InspectionRequestId]";
                QueryStringData query = await _queryBuilder.GetQueryStringDataAsync(tableName, fields, queryOptions);

                var result = await this._dapper.QueryList<InspectionRequestSubcontractorDetailDtoByInclude>(query.QueryString!, query.Parameters.ToDictionary());
                if (!result.Succeeded)
                    return ReturnBase<IEnumerable<InspectionRequestSubcontractorDetailDtoByInclude>>.Fail(result.Errors);

                return ReturnBase<IEnumerable<InspectionRequestSubcontractorDetailDtoByInclude>>.Success(result.Result);
            }
            catch (Exception ex)
            {
                return ReturnBase<IEnumerable<InspectionRequestSubcontractorDetailDtoByInclude>>.Fail(ex, _exceptionManager);
            }
        }



        public override Task<ReturnBase<IEnumerable<InspectionRequestSubcontractorDetailDtoByInclude>>> Query(SqlQueryOptions queryOptions, string functionParameter)
        {
            throw new NotImplementedException();
        }

        public override Task<ReturnBase<IEnumerable<InspectionRequestSubcontractorDetailDtoByInclude>>> Query(SqlQueryOptions queryOptions, object[] functionParameters)
        {
            throw new NotImplementedException();
        }
    }
}
