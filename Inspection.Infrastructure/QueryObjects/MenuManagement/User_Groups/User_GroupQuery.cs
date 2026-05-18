using Inspection.Application.Contracts.Dto.MenuManagement.User_Groups;
using NDS.Shared.Application.DataQuery;
using NDS.Shared.Application.Multitenant;
using NDS.Shared.Infrastructure.DataContext;
using NDS.Shared.Kernel.BaseReturnTypes;
using NDS.Shared.Kernel.Exceptions;

namespace Inspection.Infrastructure.QueryObjects.MenuManagement.User_Groups
{



    internal class User_GroupQuery : QueryObjectBase<User_GroupReturnSearchDto>
    {
        public User_GroupQuery(
            ISqlQueryBuilder queryBuilder,
            DapperDbContext dapper,
            ITenantResolver tenantResolver,
            IExceptionManager exceptionManager,
            string? fiscalYear = null
        ) : base(queryBuilder, dapper, tenantResolver, exceptionManager, fiscalYear)
        {
        }



        public override async Task<ReturnBase<IEnumerable<User_GroupReturnSearchDto>>> Query(SqlQueryOptions queryOptions)
        {
            try
            {
                string baseTable = "Sec.User_Group";
                string baseAlias = "ICKL";

                var selectFields = new List<string>
            {
                "ICKL.Id",
                "ICKL.ChecklistNumber",
                "ICKL.JobOrderId",
                "ICKL.CustomerId",
                "ICKL.EquipmentTypeId",
                "ICKL.CompanyId",
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
                 "ICKL.Series",

                   "JO.JobOrderNo",

                    "ET.Name as EquipmentTypeName",

                    "E.Description as EquipmentName",
                    "E.SerialNumber as EquipmentSerialNumber",
                    "E.EquipmentNo as EquipmentEquipmentNo",
                    "E.Description as EquipmentDescription",
                    "E.PurchaseDate as EquipmentPurchaseDate",
                    "E.ExpiryDate as EquipmentExpiryDate",

                     "C.Name CustomerName",
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

                var result = await _dapper.QueryList<User_GroupReturnSearchDto>(sql);

                if (!result.Succeeded)
                    return ReturnBase<IEnumerable<User_GroupReturnSearchDto>>.Fail(result.Errors);

                var list = base.ApplyFilters(result.Result, queryOptions);

                return ReturnBase<IEnumerable<User_GroupReturnSearchDto>>.Success(list);
            }
            catch (Exception ex)
            {
                return ReturnBase<IEnumerable<User_GroupReturnSearchDto>>.Fail(ex, _exceptionManager);
            }
        }

        public override Task<ReturnBase<IEnumerable<User_GroupReturnSearchDto>>> Query(SqlQueryOptions queryOptions, string functionParameter)
        {
            throw new NotImplementedException();
        }

        public override Task<ReturnBase<IEnumerable<User_GroupReturnSearchDto>>> Query(SqlQueryOptions queryOptions, object[] functionParameters)
        {
            throw new NotImplementedException();
        }
    }

}
