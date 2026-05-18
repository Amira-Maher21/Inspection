using Inspection.Application.Contracts.Dto.DMSDTOs.DocumentCommentDTOs;
using NDS.Shared.Application.DataQuery;
using NDS.Shared.Application.Multitenant;
using NDS.Shared.Infrastructure.DataContext;
using NDS.Shared.Kernel.BaseReturnTypes;
using NDS.Shared.Kernel.Exceptions;

namespace Inspection.Infrastructure.QueryObjects.DMS.DocumentComments
{
    public class DocumentCommentQuery : QueryObjectBase<DocumentCommentReturnSearchDto>
    {
        public DocumentCommentQuery(
            ISqlQueryBuilder queryBuilder,
            DapperDbContext dapper,
            ITenantResolver tenantResolver,
            IExceptionManager exceptionManager,
            string? fiscalYear = null) : base(queryBuilder, dapper, tenantResolver, exceptionManager, fiscalYear)
        {
        }

        public override async Task<ReturnBase<IEnumerable<DocumentCommentReturnSearchDto>>> Query(SqlQueryOptions queryOptions)
        {
            try
            {
                var tableName = "DMS.DocumentComment";

                var selectFields = new[]
                {
                    "Id",
                    "Tenant_ID",
                    "CompanyId",
                    "CommentText",
                    "IsResolved",
                    "ParentCommentId",
                    "DocumentId",
                    "UserId",
                    "ResolvedById",
                    "ResolvedAt"
                };

                var documentJoin = new JoinTable(
                     "DMS.Document",
                     "Description DocumentDescription , Title DocumentTitle",
                     "DocumentId Id"

                 );

                var userJoin = new JoinTable(
                    "Sec.User_Code",
                    "User_ID UserCode,User_Name UserName",
                    "UserId Id"
                );

                var ResolvedByJoin = new JoinTable(
                    "Sec.User_Code",
                    "User_ID ResolvedByCode,User_Name ResolvedByName",
                    "ResolvedById Id"
                );

                var queryData = await _queryBuilder.GetQueryStringDataAsync(
                    tableName,
                    string.Join(", ", selectFields),
                    new List<JoinTable>
                    {
                        documentJoin,
                        userJoin,
                        ResolvedByJoin
                    },
                    queryOptions
                );

                var result = await _dapper.QueryList<DocumentCommentReturnSearchDto>(
                    queryData.QueryString!,
                    queryData.Parameters!.ToDictionary()
                );

                if (!result.Succeeded)
                    return ReturnBase<IEnumerable<DocumentCommentReturnSearchDto>>.Fail(result.Errors);

                return ReturnBase<IEnumerable<DocumentCommentReturnSearchDto>>.Success(result.Result);
            }
            catch (Exception ex)
            {
                return ReturnBase<IEnumerable<DocumentCommentReturnSearchDto>>.Fail(ex, _exceptionManager);
            }
        }

        public override Task<ReturnBase<IEnumerable<DocumentCommentReturnSearchDto>>> Query(SqlQueryOptions queryOptions, string functionParameter)
            => throw new NotImplementedException();

        public override Task<ReturnBase<IEnumerable<DocumentCommentReturnSearchDto>>> Query(SqlQueryOptions queryOptions, object[] functionParameters)
            => throw new NotImplementedException();
    }
}
