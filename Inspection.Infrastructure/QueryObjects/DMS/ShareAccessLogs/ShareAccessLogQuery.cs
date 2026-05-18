using Inspection.Application.Contracts.Dto.DMSDTOs.ShareAccessLogs;
using NDS.Shared.Application.DataQuery;
using NDS.Shared.Application.Multitenant;
using NDS.Shared.Infrastructure.DataContext;
using NDS.Shared.Kernel.BaseReturnTypes;
using NDS.Shared.Kernel.Exceptions;

namespace Inspection.Infrastructure.QueryObjects.DMS.ShareAccessLogs
{
    internal class ShareAccessLogQuery : QueryObjectBase<ShareAccessLogReturnSearchDto>
    {
        public ShareAccessLogQuery(
            ISqlQueryBuilder queryBuilder,
            DapperDbContext dapper,
            ITenantResolver tenantResolver,
            IExceptionManager exceptionManager,
            string? fiscalYear = null)
            : base(queryBuilder, dapper, tenantResolver, exceptionManager, fiscalYear)
        {
        }

        public override async Task<ReturnBase<IEnumerable<ShareAccessLogReturnSearchDto>>> Query(SqlQueryOptions queryOptions)
        {
            try
            {
                string tableName = "DMS.ShareAccessLog";

                string fields = @"
                    [Id],
                    [Tenant_ID],
                    [CompanyId],
                    [AccessedAt],
                    [AccessIp],
                    [UserAgent],
                    [Action],
                    [DocumentShareId],
                    [In_User],
                    [In_Date],
                    [Mod_User],
                    [Mod_Date]";

                //var joins = new List<JoinTable>
                //{
                //     new JoinTable(
                //         "DMS.DocumentShare",
                //         "ShareToken",
                //         "DocumentShareId Id"
                //     )
                //};

                var queryData = await _queryBuilder.GetQueryStringDataAsync(
                    tableName,
                    fields,
                    //joins,
                    queryOptions
                );

                var result = await _dapper.QueryList<ShareAccessLogReturnSearchDto>(
                    queryData.QueryString!,
                    queryData.Parameters!.ToDictionary()
                );

                if (!result.Succeeded)
                    return ReturnBase<IEnumerable<ShareAccessLogReturnSearchDto>>.Fail(result.Errors);

                return ReturnBase<IEnumerable<ShareAccessLogReturnSearchDto>>.Success(result.Result);
            }
            catch (Exception ex)
            {
                return ReturnBase<IEnumerable<ShareAccessLogReturnSearchDto>>.Fail(ex, _exceptionManager);
            }
        }

        public override Task<ReturnBase<IEnumerable<ShareAccessLogReturnSearchDto>>> Query(SqlQueryOptions queryOptions, string functionParameter)
        {
            throw new NotImplementedException();
        }

        public override Task<ReturnBase<IEnumerable<ShareAccessLogReturnSearchDto>>> Query(SqlQueryOptions queryOptions, object[] functionParameters)
        {
            throw new NotImplementedException();
        }
    }
}