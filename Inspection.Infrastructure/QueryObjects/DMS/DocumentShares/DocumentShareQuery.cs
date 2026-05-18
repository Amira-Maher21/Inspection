using Inspection.Application.Contracts.Dto.DMSDTOs.DocumentShares;
using NDS.Shared.Application.DataQuery;
using NDS.Shared.Application.Multitenant;
using NDS.Shared.Infrastructure.DataContext;
using NDS.Shared.Kernel.BaseReturnTypes;
using NDS.Shared.Kernel.Exceptions;

namespace Inspection.Infrastructure.QueryObjects.DMS.DocumentShares
{

    internal class DocumentShareQuery : QueryObjectBase<DocumentShareReturnSearchDto>
    {
        public DocumentShareQuery(
            ISqlQueryBuilder queryBuilder,
            DapperDbContext dapper,
            ITenantResolver tenantResolver,
            IExceptionManager exceptionManager,
            string? fiscalYear = null)
            : base(queryBuilder, dapper, tenantResolver, exceptionManager, fiscalYear)
        {
        }

        public override async Task<ReturnBase<IEnumerable<DocumentShareReturnSearchDto>>> Query(SqlQueryOptions queryOptions)
        {
            try
            {
                string tableName = "DMS.DocumentShare";

                string fields = @"
                    [Id],
                    [CompanyId],
                    [DocumentId]  ,
                    [SharedById],
                    [SharedWithId],
                    [ShareType]  ,
                    [ShareToken],
                    [Email],
                    [CanView],
                    [CanDownload],
                    [CanEdit],
                    [RequirePassword],
                    [PasswordHash],
                    [ExpiresAt],
                    [LastAccessedAt],
                    [AccessCount],
                    [IsActive],
                    [RevokedAt],
                    [RevokedById],
                    [Tenant_ID],
                    [In_User],
                    [In_Date],
                    [Mod_User],
                    [Mod_Date]";
                var joins = new List<JoinTable>
                {
                    // SharedBy
                    new JoinTable(
                        "Sec.User_Code",
                        " User_Name  SharedByName",
                        "SharedById Id"
                    ),
                    //Code SharedByCode,
                    // SharedWith
                    new JoinTable(
                        "Sec.User_Code",
                        " User_Name  SharedWithName",
                        "SharedWithId Id"
                    ),
                    //Code SharedWithCode,
                    // RevokedBy
                    new JoinTable(
                        "DMS.Document",
                         "DocumentNumber DocumentCode, Title  DocumentName ",
                        "RevokedById Id"
                    ),
                     new JoinTable(
                        "Sec.User_Code",
                         "User_Name  RevokedByName",
                        "RevokedById Id"
                    )


                };
                //"Code RevokedByCode,
                var queryData = await _queryBuilder.GetQueryStringDataAsync(
                    tableName,
                    fields,
                    joins,
                    queryOptions
                );

                var result = await _dapper.QueryList<DocumentShareReturnSearchDto>(
                    queryData.QueryString!,
                    queryData.Parameters!.ToDictionary()
                );

                if (!result.Succeeded)
                    return ReturnBase<IEnumerable<DocumentShareReturnSearchDto>>.Fail(result.Errors);

                return ReturnBase<IEnumerable<DocumentShareReturnSearchDto>>.Success(result.Result);
            }
            catch (Exception ex)
            {
                return ReturnBase<IEnumerable<DocumentShareReturnSearchDto>>.Fail(ex, _exceptionManager);
            }
        }

        public override Task<ReturnBase<IEnumerable<DocumentShareReturnSearchDto>>> Query(SqlQueryOptions queryOptions, string functionParameter)
        {
            throw new NotImplementedException();
        }

        public override Task<ReturnBase<IEnumerable<DocumentShareReturnSearchDto>>> Query(SqlQueryOptions queryOptions, object[] functionParameters)
        {
            throw new NotImplementedException();
        }
    }
}