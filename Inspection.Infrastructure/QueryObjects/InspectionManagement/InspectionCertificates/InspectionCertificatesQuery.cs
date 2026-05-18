using Inspection.Application.Contracts.Dto.InspectionManagement.InspectionCertificates;
using NDS.Shared.Application.DataQuery;
using NDS.Shared.Application.Multitenant;
using NDS.Shared.Infrastructure.DataContext;
using NDS.Shared.Kernel.BaseReturnTypes;
using NDS.Shared.Kernel.Exceptions;

namespace Inspection.Infrastructure.QueryObjects.InspectionManagement.InspectionCertificates
{

    internal class InspectionCertificatesQuery : QueryObjectBase<InspectionCertificateDtoByInclude>
    {
        public InspectionCertificatesQuery(
            ISqlQueryBuilder queryBuilder,
            DapperDbContext dapper,
            ITenantResolver tenantResolver,
            IExceptionManager exceptionManager,
            string? fiscalYear = null
        ) : base(queryBuilder, dapper, tenantResolver, exceptionManager, fiscalYear)
        {
        }

        public override async Task<ReturnBase<IEnumerable<InspectionCertificateDtoByInclude>>> Query(SqlQueryOptions queryOptions)
        {
            try
            {
                string baseTable = "Inspection.InspectionCertificate";
                string baseAlias = "ICERTF";

                var selectFields = new List<string>
            {
                "ICERTF.Id",
                "ICERTF.CertificateNumber",
                "ICERTF.IssueDate",
                "ICERTF.InspectionChecklistId",
                "ICERTF.Series",
                "ICERTF.Tenant_ID",

                "ICKL.JobOrderId",
                "ICKL.CustomerId",
                "ICKL.EquipmentTypeId",
                "ICKL.EquipmentId",
                "ICKL.InspectionTypeId",
                "ICKL.LocationId",
                "ICKL.CustomerProjectId",
                "ICKL.InspectorId",
                "ICKL.InspectionMethodId",
                "ICKL.PreviousInspectionDate",
                "ICKL.InspectionDate",
                "ICKL.ExpireDate",
                "ICKL.TimeSheetNo",
                "ICKL.StickerNo",
                "ICKL.RemarksAndRecommendations",
                "ICKL.Status",
                "ICKL.RefferenceStandard",


                   "JO.JobOrderNo",

                    "ET.Name as EquipmentTypeName",

                    "E.Description as EquipmentName",
                    "E.SerialNumber as EquipmentSerialNumber",
                    "E.EquipmentNo as EquipmentEquipmentNo",
                    "E.Description as EquipmentDescription",
                    "E.PurchaseDate as EquipmentPurchaseDate",
                    "E.ExpiryDate as EquipmentExpiryDate",

                     "C.Name as CustomerName",

                     "C.Email",
                     "C.Address",
                     "C.Mobile",
                     "C.Phone",

                     "Comp.Name CompanyName",


                     "InsTy.ArName InspectionTypeArabicName",
                     "InsTy.EnName InspectionTypeEnglishName",

                     "Loc.Name LocationName",

                     "Proj.Name CustomerProjectName",

                     "Inspr.Name InspectorName",

                    "InspMeth.Name InspectionMethodName"

            };

                var joins = new List<(string JoinType, string Table, string Alias, string Condition)>
                     {
            ("LEFT JOIN", "[Inspection].[InspectionChecklist] ICKL", "ICKL", "ICKL.Id = ICERTF.InspectionChecklistId"),

            ("LEFT JOIN", "[Sec].[Company] Comp", "Comp", "Comp.Id = ICKL.CompanyId"),
            ("LEFT JOIN", "[Accounting].[Customer] C", "C", "C.Id = ICKL.CustomerId"),
            ("LEFT JOIN", "[Inspection].[Equipment] E", "E", "E.Id = ICKL.EquipmentId"),
            ("LEFT JOIN", "[Inspection].[JobOrder] JO", "JO", "JO.Id = ICKL.JobOrderId"),
            ("LEFT JOIN", "[Inspection].[EquipmentType] ET", "ET", "ET.Id = ICKL.EquipmentTypeId"),
            ("LEFT JOIN", "[Inspection].[InspectionType] InsTy", "InsTy", "InsTy.Id = ICKL.InspectionTypeId"),
            ("LEFT JOIN", "[Inspection].[CustomerLocation] Loc", "Loc", "Loc.Id = ICKL.LocationId"),
            ("LEFT JOIN", "[Inspection].[CustomerProject] Proj", "Proj", "Proj.Id = ICKL.CustomerProjectId"),
            ("LEFT JOIN", "[Inspection].[Inspector] Inspr", "Inspr", "Inspr.Id = ICKL.InspectorId"),
            ("LEFT JOIN", "[Inspection].[InspectionMethod] InspMeth", "InspMeth", "InspMeth.Id = ICKL.InspectionMethodId"),
        };

                var sql = base.ApplyJoinQuary(baseTable, baseAlias, selectFields, joins, queryOptions);

                var result = await _dapper.QueryList<InspectionCertificateDtoByInclude>(sql);

                if (!result.Succeeded)
                    return ReturnBase<IEnumerable<InspectionCertificateDtoByInclude>>.Fail(result.Errors);

                var list = base.ApplyFilters(result.Result, queryOptions);

                return ReturnBase<IEnumerable<InspectionCertificateDtoByInclude>>.Success(list);
            }
            catch (Exception ex)
            {
                return ReturnBase<IEnumerable<InspectionCertificateDtoByInclude>>.Fail(ex, _exceptionManager);
            }
        }

        public override Task<ReturnBase<IEnumerable<InspectionCertificateDtoByInclude>>> Query(SqlQueryOptions queryOptions, string functionParameter)
        {
            throw new NotImplementedException();
        }
        public override Task<ReturnBase<IEnumerable<InspectionCertificateDtoByInclude>>> Query(SqlQueryOptions queryOptions, object[] functionParameters)
        {
            throw new NotImplementedException();
        }
    }

}