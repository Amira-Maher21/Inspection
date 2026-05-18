using Inspection.Application.Contracts.Dto.Manufacturing.Setup.ProductionOrderDTOs;
using NDS.Shared.Application.DataQuery;
using NDS.Shared.Application.Multitenant;
using NDS.Shared.Infrastructure.DataContext;
using NDS.Shared.Kernel.BaseReturnTypes;
using NDS.Shared.Kernel.Exceptions;

namespace Inspection.Infrastructure.QueryObjects.Manufacturing.Setup.ProductionOrder
{
    public class ProductionOrderQuery : QueryObjectBase<ProductionOrderReturnSearchDto>
    {
        public ProductionOrderQuery(ISqlQueryBuilder queryBuilder, DapperDbContext dapper, ITenantResolver tenantResolver, IExceptionManager exceptionManager) : base(queryBuilder, dapper, tenantResolver, exceptionManager)
        {
        }

        public override async Task<ReturnBase<IEnumerable<ProductionOrderReturnSearchDto>>> Query(SqlQueryOptions queryOptions)
        {
            try
            {
                string tableName = "Manufacturing.ProductionOrder";
                var selectFields = new[]
                {
                    "Id",
                    "Tenant_ID",
                    "OrderNumber",
                    "OrderDate",
                    "DocumentStatus",
                    "ExpectedAmount",
                    "OperationId",

                    "In_User",
                    "In_Date",
                    "Mod_User",
                    "Mod_Date"
                };



                //Joins
                var operationJoin = new JoinTable
                            ("Sec.Operation",
                            "Code OperationCode, Name OperationName",
                            "OperationId Id");


                var queryData = await _queryBuilder.GetQueryStringDataAsync(
                            tableName,
                            string.Join(", ", selectFields),
                            new List<JoinTable>
                            {
                                operationJoin
                            }
                            ,
                           queryOptions
                        );

                var queryResult = await _dapper.QueryList<ProductionOrderReturnSearchDto>(
                    queryData.QueryString!,
                    queryData.Parameters!.ToDictionary()
                );

                return ReturnBase<IEnumerable<ProductionOrderReturnSearchDto>>.Success(queryResult.Result);
            }
            catch (Exception ex)
            {
                return ReturnBase<IEnumerable<ProductionOrderReturnSearchDto>>.Fail(ex, _exceptionManager);
            }
        }

        public override Task<ReturnBase<IEnumerable<ProductionOrderReturnSearchDto>>> Query(SqlQueryOptions queryOptions, string functionParameter)
        {
            throw new NotImplementedException();
        }

        public override Task<ReturnBase<IEnumerable<ProductionOrderReturnSearchDto>>> Query(SqlQueryOptions queryOptions, object[] functionParameters)
        {
            throw new NotImplementedException();
        }
    }
}