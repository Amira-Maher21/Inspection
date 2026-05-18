using Inspection.Application.Contracts.Dto.EquipmentManagement.EquipmentsMoreInformationTemplates;
using NDS.Shared.Application.DataQuery;
using NDS.Shared.Application.Multitenant;
using NDS.Shared.Infrastructure.DataContext;
using NDS.Shared.Kernel.BaseReturnTypes;
using NDS.Shared.Kernel.Exceptions;

namespace Inspection.Infrastructure.QueryObjects.EquipmentManagment.EquipmentsMoreInformationTemplateTemplates
{
    internal class EquipmentsMoreInformationTemplateQuery : QueryObjectBase<EquipmentsMoreInformationTemplateReturnSearchDto>
    {
        public EquipmentsMoreInformationTemplateQuery(
            ISqlQueryBuilder queryBuilder,
            DapperDbContext dapper,
            ITenantResolver tenantResolver,
            IExceptionManager exceptionManager,
            string? fiscalYear = null)
            : base(queryBuilder, dapper, tenantResolver, exceptionManager, fiscalYear)
        {
        }

        public override async Task<ReturnBase<IEnumerable<EquipmentsMoreInformationTemplateReturnSearchDto>>> Query(SqlQueryOptions queryOptions)
        {
            try
            {
                string tableName = "Inspection.EquipmentsMoreInformationTemplate";
                string fields = "[Id],[EquipmentTypeId],[Tenant_ID]";


                var joins = new List<JoinTable>
                {
                    new JoinTable(
                        "Inspection.EquipmentType",
                        "Code EquipmentTypeCode, Name EquipmentTypeName",
                        "EquipmentTypeId Id"
                    )

                };

                var queryData = await _queryBuilder.GetQueryStringDataAsync(
                    tableName,
                    fields,
                    joins,
                    queryOptions
                );

                var result = await _dapper.QueryList<EquipmentsMoreInformationTemplateReturnSearchDto>(
                    queryData.QueryString!,
                    queryData.Parameters!.ToDictionary()
                );

                if (!result.Succeeded)
                    return ReturnBase<IEnumerable<EquipmentsMoreInformationTemplateReturnSearchDto>>.Fail(result.Errors);

                return ReturnBase<IEnumerable<EquipmentsMoreInformationTemplateReturnSearchDto>>.Success(result.Result);
            }
            catch (Exception ex)
            {
                return ReturnBase<IEnumerable<EquipmentsMoreInformationTemplateReturnSearchDto>>.Fail(ex, _exceptionManager);
            }
        }

        public override Task<ReturnBase<IEnumerable<EquipmentsMoreInformationTemplateReturnSearchDto>>> Query(SqlQueryOptions queryOptions, string functionParameter)
        {
            throw new NotImplementedException();
        }

        public override Task<ReturnBase<IEnumerable<EquipmentsMoreInformationTemplateReturnSearchDto>>> Query(SqlQueryOptions queryOptions, object[] functionParameters)
        {
            throw new NotImplementedException();
        }
    }





    //internal class EquipmentsMoreInformationTemplateQuery : QueryObjectBase<EquipmentsMoreInformationTemplateReturnSearchDto>
    //{
    //    public EquipmentsMoreInformationTemplateQuery(ISqlQueryBuilder queryBuilder, DapperDbContext dapper, ITenantResolver tenantResolver, IExceptionManager exceptionManager, string? fiscalYear = null) : base(queryBuilder, dapper, tenantResolver, exceptionManager, fiscalYear)
    //    {
    //    }

    //    public override async Task<ReturnBase<IEnumerable<EquipmentsMoreInformationTemplateReturnSearchDto>>> Query(SqlQueryOptions queryOptions)
    //    {
    //        try
    //        {
    //            string tableName = "Inspection.EquipmentsMoreInformationTemplate";
    //            string fields = "[Id],[EquipmentTypeId],[Tenant_ID]";
    //            QueryStringData query = await _queryBuilder.GetQueryStringDataAsync(tableName, fields, queryOptions);

    //            var result = await this._dapper.QueryList<EquipmentsMoreInformationTemplateReturnSearchDto>(query.QueryString!, query.Parameters!.ToDictionary());
    //            if (!result.Succeeded)
    //                return ReturnBase<IEnumerable<EquipmentsMoreInformationTemplateReturnSearchDto>>.Fail(result.Errors);

    //            return ReturnBase<IEnumerable<EquipmentsMoreInformationTemplateReturnSearchDto>>.Success(result.Result);
    //        }
    //        catch (Exception ex)
    //        {
    //            return ReturnBase<IEnumerable<EquipmentsMoreInformationTemplateReturnSearchDto>>.Fail(ex, _exceptionManager);
    //        }
    //    }

    //    public override Task<ReturnBase<IEnumerable<EquipmentsMoreInformationTemplateReturnSearchDto>>> Query(SqlQueryOptions queryOptions, string functionParameter)
    //    {
    //        throw new NotImplementedException();
    //    }

    //    public override Task<ReturnBase<IEnumerable<EquipmentsMoreInformationTemplateReturnSearchDto>>> Query(SqlQueryOptions queryOptions, object[] functionParameters)
    //    {
    //        throw new NotImplementedException();
    //    }
    //}
}