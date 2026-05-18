using Inspection.Application.Contracts.Dto.InspectionManagement.InspectionRequestDetailF;
using Inspection.Application.Contracts.Dto.InspectionManagement.InspectionRequests;
using Inspection.Application.Contracts.Dto.InspectionManagement.InspectionRequestSubcontractorDetailF;
using NDS.Shared.Application.DataQuery;
using NDS.Shared.Application.Multitenant;
using NDS.Shared.Infrastructure.DataContext;
using NDS.Shared.Kernel.BaseReturnTypes;
using NDS.Shared.Kernel.Exceptions;
using System.Text;

namespace Inspection.Infrastructure.QueryObjects.InspectionManagement.InspectionRequest
{
    public class InspectionRequestQuery : QueryObjectBase<InspectionRequestDtoByInclude>
    {

        public InspectionRequestQuery(ISqlQueryBuilder queryBuilder, DapperDbContext dapper, ITenantResolver tenantResolver, IExceptionManager exceptionManager, string? fiscalYear = null) : base(queryBuilder, dapper, tenantResolver, exceptionManager, fiscalYear)
        {
        }
        public override async Task<ReturnBase<IEnumerable<InspectionRequestDtoByInclude>>> Query(SqlQueryOptions queryOptions)
        {

            try
            {
                string baseTable = "Inspection.InspectionRequest";
                string baseAlias = "R";

                var selectFields = new List<string>
                {
                    "R.Id",
                    "R.Tenant_ID",
                    "R.CompanyId",
                    "R.RequestNumber",
                    "R.RequestDate",

                    "R.CustomerId",
                    "R.LocationId",
                    "R.ContactPersonId",
                    "R.CustomerProjectId",
                    "R.InspectionTypeId",
                    "R.SeriesId",
                    "R.RunningNumber",
                    "R.RequestedInspectionDate",

                    "R.DocumentStatus",
                    "R.ApprovalStatus",
                    "R.DocumentStatusCancelledDescription",
                    "R.Remarks",

                    // Lookup Names
                    "C.Name AS CustomerName",
                    "L.Location AS LocationName",
                    "CC.ContactName AS ContactPersonName",
                    "P.ProjectName AS CustomerProjectName",
                    "IT.Name AS InspectionTypeName",
                };

                var joins = new List<(string JoinType, string Table, string Alias, string Condition)>
                {
                    ("LEFT JOIN", "[Accounting].[Customer] C", "C", "C.Id = R.CustomerId"),
                    ("LEFT JOIN", "[Inspection].[CustomerLocation] L", "L", "L.Id = R.LocationId"),
                    ("LEFT JOIN", "[Accounting].[CustomerContact] CC", "CC", "CC.Id = R.ContactPersonId"),
                    ("LEFT JOIN", "[Inspection].[CustomerProject] P", "P", "P.Id = R.CustomerProjectId"),
                    ("LEFT JOIN", "[Inspection].[InspectionType] IT", "IT", "IT.Id = R.InspectionTypeId"),
                };

                var sb = new StringBuilder();
                sb.AppendLine($"SELECT {string.Join(", ", selectFields)}");
                sb.AppendLine($"FROM {baseTable} {baseAlias}");

                foreach (var join in joins)
                    sb.AppendLine($"{join.JoinType} {join.Table} ON {join.Condition}");

                bool hasOrder = false;
                if (queryOptions?.Sorts != null && queryOptions.Sorts.Any())
                {
                    var orders = queryOptions.Sorts
                        .Select(s => $"{s.FieldName} {(s.IsAscending.HasValue && s.IsAscending.Value ? "ASC" : "DESC")}");
                    sb.AppendLine("ORDER BY " + string.Join(", ", orders));
                    hasOrder = true;
                }
                else
                {
                    sb.AppendLine($"ORDER BY {baseAlias}.Id DESC");
                    hasOrder = true;
                }

                string sql = sb.ToString();

                var headerResult =
                    await _dapper.QueryList<InspectionRequestDtoByInclude>(sql);

                if (!headerResult.Succeeded)
                    return ReturnBase<IEnumerable<InspectionRequestDtoByInclude>>
                        .Fail(headerResult.Errors);

                var requests =
                    base.ApplyFilters(headerResult.Result, queryOptions).ToList();

                if (!requests.Any())
                    return ReturnBase<IEnumerable<InspectionRequestDtoByInclude>>
                        .Success(requests);

                var requestIds = requests.Select(r => r.Id).ToArray();

                #region ===== DETAILS QUERY =====

                var detailsSql = @"
                    SELECT
                        Id,
                        InspectionRequestId,
                        ItemId,
                        InspectionMethodId,
                        Quantity,
                        Price,
                        IsSubcontractor,
                        Status
                    FROM [Inspection].[InspectionRequestLines]
                    WHERE InspectionRequestId IN @Ids
                    ";

                var detailsResult =
                    await _dapper.QueryList<InspectionRequestLinesDto>(
                        detailsSql,
                        new Dictionary<string, object>
                        {
                            { "Ids", requestIds }
                        }
                    );

                if (!detailsResult.Succeeded)
                    return ReturnBase<IEnumerable<InspectionRequestDtoByInclude>>
                        .Fail(detailsResult.Errors);

                #endregion

                #region ===== ATTACH CHILDREN =====

                //foreach (var request in requests)
                //{
                //    request.InspectionRequestLines =
                //        detailsResult.Result
                //            .Where(d => d.InspectionRequestId == request.Id)
                //            .ToList();

                //}

                var lookup = (detailsResult.Result ?? Enumerable.Empty<InspectionRequestLinesDto>())
                    .ToLookup(d => d.InspectionRequestId);

                foreach (var request in requests)
                {
                    request.InspectionRequestLines = lookup[request.Id].ToList();
                }

                #endregion


                return ReturnBase<IEnumerable<InspectionRequestDtoByInclude>>.Success(requests);
            }
            catch (Exception ex)
            {
                return ReturnBase<IEnumerable<InspectionRequestDtoByInclude>>.Fail(ex, _exceptionManager);
            }
        }


        public override Task<ReturnBase<IEnumerable<InspectionRequestDtoByInclude>>> Query(SqlQueryOptions queryOptions, object[] functionParameters)
        {
            throw new NotImplementedException();
        }

        public override Task<ReturnBase<IEnumerable<InspectionRequestDtoByInclude>>> Query(SqlQueryOptions queryOptions, string functionParameter)
        {
            throw new NotImplementedException();
        }

    }
}