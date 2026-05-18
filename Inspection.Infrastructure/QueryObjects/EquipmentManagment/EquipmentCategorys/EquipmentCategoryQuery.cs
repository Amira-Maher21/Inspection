using Inspection.Application.Contracts.Dto.EquipmentManagement.EquipmentCategorys;
using NDS.Shared.Application.DataQuery;
using NDS.Shared.Application.Multitenant;
using NDS.Shared.Infrastructure.DataContext;
using NDS.Shared.Kernel.BaseReturnTypes;
using NDS.Shared.Kernel.Exceptions;

namespace Inspection.Infrastructure.QueryObjects.EquipmentManagment.EquipmentCategorys
{

    internal class EquipmentCategoryQuery : QueryObjectBase<EquipmentCategoryDtoByInclude>
    {
        public EquipmentCategoryQuery(ISqlQueryBuilder queryBuilder, DapperDbContext dapper, ITenantResolver tenantResolver, IExceptionManager exceptionManager, string? fiscalYear = null) : base(queryBuilder, dapper, tenantResolver, exceptionManager, fiscalYear)
        {
        }

        public override async Task<ReturnBase<IEnumerable<EquipmentCategoryDtoByInclude>>> Query(SqlQueryOptions queryOptions)
        {
            try
            {
                string baseTable = "Inspection.EquipmentCategory";
                string baseAlias = "EqT";

                var selectFields = new List<string>
                {
                    "EqT.Id",
                    "EqT.Name"

                };

                var joins = new List<(string JoinType, string Table, string Alias, string Condition)>();

                var sql = base.ApplyJoinQuary(baseTable, baseAlias, selectFields, joins, queryOptions);

                var result = await _dapper.QueryList<EquipmentCategoryDtoByInclude>(sql);

                if (!result.Succeeded)
                    return ReturnBase<IEnumerable<EquipmentCategoryDtoByInclude>>.Fail(result.Errors);

                var list = base.ApplyFilters(result.Result, queryOptions);
                return ReturnBase<IEnumerable<EquipmentCategoryDtoByInclude>>.Success(list);
            }
            catch (Exception ex)
            {
                return ReturnBase<IEnumerable<EquipmentCategoryDtoByInclude>>.Fail(ex, _exceptionManager);
            }
        }

        public override Task<ReturnBase<IEnumerable<EquipmentCategoryDtoByInclude>>> Query(SqlQueryOptions queryOptions, string functionParameter)
        {
            throw new NotImplementedException();
        }
        public override Task<ReturnBase<IEnumerable<EquipmentCategoryDtoByInclude>>> Query(SqlQueryOptions queryOptions, object[] functionParameters)
        {
            throw new NotImplementedException();
        }
    }
}