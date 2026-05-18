using Inspection.Application.Contracts.Dto.InspectionDto.Techinal.CertificateDTOs;
using NDS.Shared.Application.DataQuery;
using NDS.Shared.Application.Multitenant;
using NDS.Shared.Infrastructure.DataContext;
using NDS.Shared.Kernel.BaseReturnTypes;
using NDS.Shared.Kernel.Exceptions;

namespace Inspection.Infrastructure.QueryObjects.Inspection.Techinal.Certificates
{
    public class CertificateQuery : QueryObjectBase<CertificateReturnSearchDto>
    {

        public CertificateQuery(ISqlQueryBuilder queryBuilder, DapperDbContext dapper, ITenantResolver tenantResolver, IExceptionManager exceptionManager) : base(queryBuilder, dapper, tenantResolver, exceptionManager)
        {
        }

        //public override async Task<ReturnBase<IEnumerable<CertificateReturnSearchDto>>> Query(SqlQueryOptions queryOptions)
        //{
        //    try
        //    {
        //        string tableName = "Inspection.Certificate";

        //        string fields = @"
        //                    [Id],
        //                    [Tenant_ID],
        //                    [CompanyId],
        //                    [CerficateNumber],
        //                    [ChekclistId],
        //                    [IssuedByEmployeeId],
        //                    [CertificateType],
        //                    [IssueDate],
        //                    [Period],
        //                    [ExpiryDate],
        //                    [Remarks],
        //                    [DocumentStatus],
        //                    [ApprovalStatus],
        //                    [SeriesId],
        //                    [RunningNumber],
        //                    [In_User],
        //                    [In_Date],
        //                    [Mod_User],
        //                    [Mod_Date]
        //                ";

        //        QueryStringData query = await _queryBuilder.GetQueryStringDataAsync(tableName, fields, queryOptions);

        //        var result = await this._dapper.QueryList<CertificateReturnSearchDto>(query.QueryString!, query.Parameters!.ToDictionary());
        //        if (!result.Succeeded)
        //            return ReturnBase<IEnumerable<CertificateReturnSearchDto>>.Fail(result.Errors);

        //        return ReturnBase<IEnumerable<CertificateReturnSearchDto>>.Success(result.Result);
        //    }
        //    catch (Exception ex)
        //    {
        //        return ReturnBase<IEnumerable<CertificateReturnSearchDto>>.Fail(ex, _exceptionManager);
        //    }   
        //}
        public override async Task<ReturnBase<IEnumerable<CertificateReturnSearchDto>>> Query(SqlQueryOptions queryOptions)
        {
            throw new NotImplementedException();
        }
        public override Task<ReturnBase<IEnumerable<CertificateReturnSearchDto>>> Query(SqlQueryOptions queryOptions, string functionParameter)
        {
            throw new NotImplementedException();
        }

        public override Task<ReturnBase<IEnumerable<CertificateReturnSearchDto>>> Query(SqlQueryOptions queryOptions, object[] functionParameters)
        {
            throw new NotImplementedException();
        }
    }
}