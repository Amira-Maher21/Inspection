using Inspection.Application.Contracts.Dto.InspectionManagement.ServicesItemsF;
using NDS.Shared.Application.DataQuery;
using NDS.Shared.Application.Multitenant;
using NDS.Shared.Infrastructure.DataContext;
using NDS.Shared.Kernel.BaseReturnTypes;
using NDS.Shared.Kernel.Exceptions;

namespace Inspection.Infrastructure.QueryObjects.InspectionManagement.ServicesItemsF
{
    internal class ServicesItemsQuery : QueryObjectBase<ServiceItemIncludeDto>
    {
        public ServicesItemsQuery(ISqlQueryBuilder queryBuilder, DapperDbContext dapper, ITenantResolver tenantResolver, IExceptionManager exceptionManager, string? fiscalYear = null) : base(queryBuilder, dapper, tenantResolver, exceptionManager, fiscalYear)
        {
        }

        public override async Task<ReturnBase<IEnumerable<ServiceItemIncludeDto>>> Query(SqlQueryOptions queryOptions)
        {

            try
            {
                string baseTable = "Inspection.serviceItem";
                string baseAlias = "SItem";

                var selectFields = new List<string>
                {
                    "SItem.Id",
                    "SItem.Itemtitle",
                    "SItem.Itemcode",
                    "SItem.Itemprice",
                    "SItem.series",
                    "SItem.SubcontractorName",
                    "SItem.IsSubcontractor",
                    "SItem.InspectionMethodId",
                    "SItem.Tenant_ID",

                   "C.Name AS InspectionMethodName"

        };

                var joins = new List<(string JoinType, string Table, string Alias, string Condition)>
        {
            ("LEFT JOIN", "[Inspection].[InspectionMethod] C", "C", "C.Id = SItem.InspectionMethodId")

        };

                var sql = base.ApplyJoinQuary(baseTable, baseAlias, selectFields, joins, queryOptions);

                var result = await _dapper.QueryList<ServiceItemIncludeDto>(sql);

                if (!result.Succeeded)
                    return ReturnBase<IEnumerable<ServiceItemIncludeDto>>.Fail(result.Errors);

                var list = base.ApplyFilters(result.Result, queryOptions);
                return ReturnBase<IEnumerable<ServiceItemIncludeDto>>.Success(list);
            }
            catch (Exception ex)
            {
                return ReturnBase<IEnumerable<ServiceItemIncludeDto>>.Fail(ex, _exceptionManager);
            }
        }
        public override Task<ReturnBase<IEnumerable<ServiceItemIncludeDto>>> Query(SqlQueryOptions queryOptions, string functionParameter)
        {
            throw new NotImplementedException();
        }
        public override Task<ReturnBase<IEnumerable<ServiceItemIncludeDto>>> Query(SqlQueryOptions queryOptions, object[] functionParameters)
        {
            throw new NotImplementedException();
        }
    }
}