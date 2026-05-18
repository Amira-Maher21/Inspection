using Inspection.Application.Contracts.Dto.InspectionDto.Techinal.AccreditationBodyDTOs;
using NDS.Shared.Application.DataQuery;
using NDS.Shared.Application.Multitenant;
using NDS.Shared.Infrastructure.DataContext;
using NDS.Shared.Kernel.BaseReturnTypes;
using NDS.Shared.Kernel.Exceptions;

namespace Inspection.Infrastructure.QueryObjects.Inspection.Techinal.AccreditationBodies
{
    public class AccreditationBodyQuery : QueryObjectBase<AccreditationBodyReturnSearchDto>
    {
        public AccreditationBodyQuery(ISqlQueryBuilder queryBuilder, DapperDbContext dapper, ITenantResolver tenantResolver, IExceptionManager exceptionManager) : base(queryBuilder, dapper, tenantResolver, exceptionManager)
        {
        }

        public override async Task<ReturnBase<IEnumerable<AccreditationBodyReturnSearchDto>>> Query(SqlQueryOptions queryOptions)
        {
            try
            {
                string tableName = "Inspection.AccreditationBody";

                var selectFields = new[]
                {
                    "Id",
                    "Tenant_ID",
                    "CompanyId",
                    "Code",
                    "Name",
                    "WebsiteUrl",
                    "IsInternationallyRecognized",
                    "CountryId",
                    "In_User",
                    "In_Date",
                    "Mod_User",
                    "Mod_Date"
               };

                // Joins
                var countryJoin = new JoinTable(
                    "Sec.Country",
                    "Code CountryCode, Name CountryName",
                    "CountryId Id"
                    );

                var queryData = await _queryBuilder.GetQueryStringDataAsync(
                    tableName,
                    string.Join(", ", selectFields),
                    new List<JoinTable> { countryJoin },
                    queryOptions
                );

                var queryResult = await _dapper.QueryList<AccreditationBodyReturnSearchDto>(
                    queryData.QueryString!,
                    queryData.Parameters!.ToDictionary()
                );

                return ReturnBase<IEnumerable<AccreditationBodyReturnSearchDto>>.Success(queryResult.Result);
            }
            catch (Exception ex)
            {
                return ReturnBase<IEnumerable<AccreditationBodyReturnSearchDto>>.Fail(ex, _exceptionManager);
            }
        }
        public override Task<ReturnBase<IEnumerable<AccreditationBodyReturnSearchDto>>> Query(SqlQueryOptions queryOptions, string functionParameter)
        {
            throw new NotImplementedException();
        }

        public override Task<ReturnBase<IEnumerable<AccreditationBodyReturnSearchDto>>> Query(SqlQueryOptions queryOptions, object[] functionParameters)
        {
            throw new NotImplementedException();
        }
    }
}