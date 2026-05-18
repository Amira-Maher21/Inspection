using Inspection.Application.Contracts.Dto.ContractingDTOs.Setup.BOQDTOs.BOQLineDTOs;
using NDS.Shared.Application.DataQuery;
using NDS.Shared.Application.Multitenant;
using NDS.Shared.Infrastructure.DataContext;
using NDS.Shared.Kernel.BaseReturnTypes;
using NDS.Shared.Kernel.Exceptions;

namespace Inspection.Infrastructure.QueryObjects.Contracting.Setup.BOQs
{
    public class BOQLineQuery : QueryObjectBase<BOQLineDto>
    {
        public BOQLineQuery(ISqlQueryBuilder queryBuilder, DapperDbContext dapper, ITenantResolver tenantResolver, IExceptionManager exceptionManager) : base(queryBuilder, dapper, tenantResolver, exceptionManager)
        {
        }


        public override async Task<ReturnBase<IEnumerable<BOQLineDto>>> Query(SqlQueryOptions queryOptions)
        {
            try
            {
                string tableName = "Contracting.BOQLine";
                string fields = "[Id],[BOQId], [BOQItemCode] ,[Description],[UnitId],[Quantity],[Rate],[Amount],[WBSId],[CostCodeId],[In_User],[In_Date],[Mod_User],[Mod_Date]";
                QueryStringData query = await _queryBuilder.GetQueryStringDataAsync(tableName, fields, queryOptions);

                var result = await this._dapper.QueryList<BOQLineDto>(query.QueryString!, query.Parameters.ToDictionary());
                if (!result.Succeeded)
                    return ReturnBase<IEnumerable<BOQLineDto>>.Fail(result.Errors);

                return ReturnBase<IEnumerable<BOQLineDto>>.Success(result.Result);
            }
            catch (Exception ex)
            {
                return ReturnBase<IEnumerable<BOQLineDto>>.Fail(ex, _exceptionManager);
            }
        }

        public override Task<ReturnBase<IEnumerable<BOQLineDto>>> Query(SqlQueryOptions queryOptions, string functionParameter)
        {
            throw new NotImplementedException();
        }

        public override Task<ReturnBase<IEnumerable<BOQLineDto>>> Query(SqlQueryOptions queryOptions, object[] functionParameters)
        {
            throw new NotImplementedException();
        }
    }
}