using Inspection.Application.Contracts.Dto.ContractingDTOs.Setup.CommitmentDTOs;
using NDS.Shared.Application.DataQuery;
using NDS.Shared.Application.Multitenant;
using NDS.Shared.Infrastructure.DataContext;
using NDS.Shared.Kernel.BaseReturnTypes;
using NDS.Shared.Kernel.Exceptions;

namespace Inspection.Infrastructure.QueryObjects.Constracting.Setup.Commitments
{
    public class CommitmentQuery : QueryObjectBase<CommitmentReturnSearchDto>
    {
        public CommitmentQuery(ISqlQueryBuilder queryBuilder, DapperDbContext dapper, ITenantResolver tenantResolver, IExceptionManager exceptionManager) : base(queryBuilder, dapper, tenantResolver, exceptionManager)
        {
        }

        public override async Task<ReturnBase<IEnumerable<CommitmentReturnSearchDto>>> Query(SqlQueryOptions queryOptions)
        {
            try
            {
                string tableName = "Contracting.Commitment";
                var selectFields = new[]
                {
                    "Id",
                    "Tenant_ID",
                    "CompanyId",
                    "OperationId",
                    "CommitmentType",
                    "DocumentNo",
                    "SupplierId",
                    "CommitmentDate",
                    "DocumentStatus",
                    "TotalAmount",

                    "In_User",
                    "In_Date",
                    "Mod_User",
                    "Mod_Date"
                };



                // Joins
                var supplierJoin = new JoinTable
                    ("Accounting.Supplier",
                    "Code SupplierCode, Name SupplierName",
                    "SupplierId Id");


                var queryData = await _queryBuilder.GetQueryStringDataAsync(
                            tableName,
                            string.Join(", ", selectFields),
                            new List<JoinTable>
                            {
                                supplierJoin,
                            }
                            ,
                           queryOptions
                        );

                var queryResult = await _dapper.QueryList<CommitmentReturnSearchDto>(
                    queryData.QueryString!,
                    queryData.Parameters!.ToDictionary()
                );

                return ReturnBase<IEnumerable<CommitmentReturnSearchDto>>.Success(queryResult.Result);
            }
            catch (Exception ex)
            {
                return ReturnBase<IEnumerable<CommitmentReturnSearchDto>>.Fail(ex, _exceptionManager);
            }
        }

        public override Task<ReturnBase<IEnumerable<CommitmentReturnSearchDto>>> Query(SqlQueryOptions queryOptions, string functionParameter)
        {
            throw new NotImplementedException();
        }

        public override Task<ReturnBase<IEnumerable<CommitmentReturnSearchDto>>> Query(SqlQueryOptions queryOptions, object[] functionParameters)
        {
            throw new NotImplementedException();
        }
    }
}