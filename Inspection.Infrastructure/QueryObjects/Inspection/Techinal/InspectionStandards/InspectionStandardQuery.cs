using Inspection.Application.Contracts.Dto.InspectionDto.Techinal.InspectionStandards;
using NDS.Shared.Application.DataQuery;
using NDS.Shared.Application.Multitenant;
using NDS.Shared.Infrastructure.DataContext;
using NDS.Shared.Kernel.BaseReturnTypes;
using NDS.Shared.Kernel.Exceptions;

namespace Inspection.Infrastructure.QueryObjects.Inspection.Techinal.InspectionStandards
{
    public class InspectionStandardQuery : QueryObjectBase<InspectionStandardReturnSearchDto>
    {
        public InspectionStandardQuery(ISqlQueryBuilder queryBuilder, DapperDbContext dapper, ITenantResolver tenantResolver, IExceptionManager exceptionManager) : base(queryBuilder, dapper, tenantResolver, exceptionManager)
        {
        }
        public override async Task<ReturnBase<IEnumerable<InspectionStandardReturnSearchDto>>> Query(SqlQueryOptions queryOptions)
        {
            try
            {

                string tableName = "Inspection.InspectionStandard";
                string fields = "[Id], [Name],[Code], [Tenant_ID],[Authority],[Version],[Scope],[CompanyId]";


                var joinTableName = "Sec.Company";
                var joinSelectFields = "Code CompanyCode, Name CompanyName";
                var joinField = "CompanyId Id";

                var joinTable = new JoinTable(
                    joinTableName,
                    joinSelectFields,
                    joinField
                );

                var queryData = await _queryBuilder.GetQueryStringDataAsync(
                    tableName,
                    string.Join(", ", fields),
                    new List<JoinTable> { joinTable },
                    queryOptions
                );

                var queryResult =
                    await _dapper.QueryList<InspectionStandardReturnSearchDto>(
                        queryData.QueryString!,
                        queryData.Parameters!.ToDictionary()
                    );

                return queryResult;
            }
            catch (Exception ex)
            {
                return ReturnBase<IEnumerable<InspectionStandardReturnSearchDto>>
                    .Fail(ex, _exceptionManager);
            }
        }

        ////   public override async Task<ReturnBase<IEnumerable<InspectionStandardDto>>> Query(
        //SqlQueryOptions queryOptions)
        //   {
        //       try
        //       {
        //           // =========================
        //           // 1️⃣ Build JOIN
        //           // =========================

        //           var joinBuilder = new SqlQueryJoinBuilder();

        //           joinBuilder.AddLeftOuterJoin(
        //               mainTable: "InspectionStandard",
        //               mainJoinField: "UnitOfMeasureId",
        //               joinTable: "UnitOfMeasure",
        //               joinTableAlias: "UOM",
        //               joinField: "Id"
        //           );

        //           // =========================
        //           // 2️⃣ InspectionStandards + UOM
        //           // =========================

        //           var tableName = "InspectionStandard";

        //           var fields = @"
        //       InspectionStandard.[Id],
        //       InspectionStandard.[Tenant_ID],
        //       InspectionStandard.[CompanyId],

        //       InspectionStandard.[Code],
        //       InspectionStandard.[Name],
        //       InspectionStandard.[Description],

        //       InspectionStandard.[InspectionStandardGroupId],
        //       InspectionStandard.[InspectionStandardType],
        //       InspectionStandard.[UnitOfMeasureId],

        //       UOM.[Name] AS UnitOfMeasureName,
        //       UOM.[Code] AS UnitOfMeasureCode,

        //       InspectionStandard.[IsStocked],
        //       InspectionStandard.[IsSerialTracked],
        //       InspectionStandard.[IsBatchTracked],
        //       InspectionStandard.[IsExpiryTracked],

        //       InspectionStandard.[DefaultWarehouseId],

        //       InspectionStandard.[MinStockLevel],
        //       InspectionStandard.[MaxStockLevel],
        //       InspectionStandard.[ReorderLevel],
        //       InspectionStandard.[LeadTime],

        //       InspectionStandard.[Weight],
        //       InspectionStandard.[Volume],
        //       InspectionStandard.[UnitPrice],

        //       InspectionStandard.[BarCode],
        //       InspectionStandard.[Photo],

        //       InspectionStandard.[BrandId],
        //       InspectionStandard.[ModelId],
        //       InspectionStandard.[ColorId],
        //       InspectionStandard.[SizeId],

        //       InspectionStandard.[Disabled]
        //   ";

        //           var queryData = await _queryBuilder.GetQueryStringDataAsync(
        //               tableName,
        //               fields,
        //               queryOptions,
        //               joinBuilder
        //           );

        //           var InspectionStandardsResult = await _dapper.QueryList<InspectionStandardDto>(
        //               queryData.QueryString!,
        //               queryData.Parameters!.ToDictionary()
        //           );

        //           if (!InspectionStandardsResult.Succeeded)
        //               return ReturnBase<IEnumerable<InspectionStandardDto>>.Fail(InspectionStandardsResult.Errors);

        //           var InspectionStandards = InspectionStandardsResult.Result.ToList();

        //           if (!InspectionStandards.Any())
        //               return ReturnBase<IEnumerable<InspectionStandardDto>>.Success(InspectionStandards);

        //           // =========================
        //           // 3️⃣ InspectionStandard Variants
        //           // =========================

        //           const string variantsSql = @"
        //       SELECT *
        //       FROM InspectionStandardVariant
        //       WHERE InspectionStandardId IN @InspectionStandardIds
        //   ";

        //           var parameters = new Dictionary<string, object>
        //   {
        //       { "InspectionStandardIds", InspectionStandards.Select(i => i.Id).ToArray() }
        //   };

        //           var variantsResult = await _dapper.QueryList<InspectionStandardVariantDto>(
        //               variantsSql,
        //               parameters
        //           );

        //           if (!variantsResult.Succeeded)
        //               return ReturnBase<IEnumerable<InspectionStandardDto>>.Fail(variantsResult.Errors);

        //           // =========================
        //           // 4️⃣ Mapping
        //           // =========================

        //           var variantsLookup = variantsResult.Result
        //               .GroupBy(v => v.InspectionStandardId)
        //               .ToDictionary(g => g.Key, g => g.ToList());

        //           foreach (var InspectionStandard in InspectionStandards)
        //           {
        //               InspectionStandard.InspectionStandardVariants =
        //                   variantsLookup.TryGetValue(InspectionStandard.Id, out var variants)
        //                       ? variants
        //                       : new List<InspectionStandardVariantDto>();
        //           }

        //           return ReturnBase<IEnumerable<InspectionStandardDto>>.Success(InspectionStandards);
        //       }
        //       catch (Exception ex)
        //       {
        //           return ReturnBase<IEnumerable<InspectionStandardDto>>.Fail(ex, _exceptionManager);
        //       }
        //   }


        public override Task<ReturnBase<IEnumerable<InspectionStandardReturnSearchDto>>> Query(SqlQueryOptions queryOptions, string functionParameter)
        {
            throw new NotImplementedException();
        }

        public override Task<ReturnBase<IEnumerable<InspectionStandardReturnSearchDto>>> Query(SqlQueryOptions queryOptions, object[] functionParameters)
        {
            throw new NotImplementedException();
        }
    }
}