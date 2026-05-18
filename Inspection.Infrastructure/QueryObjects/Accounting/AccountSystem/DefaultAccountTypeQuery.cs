using Inspection.Application.Contracts.Dto.AccountingDtos.AccountSystemDto.DefaultAccountTypeDto;
using NDS.Shared.Application.DataQuery;
using NDS.Shared.Application.Multitenant;
using NDS.Shared.Infrastructure.DataContext;
using NDS.Shared.Kernel.BaseReturnTypes;
using NDS.Shared.Kernel.Exceptions;

namespace Inspection.Infrastructure.QueryObjects.Accounting.AccountingSystem
{
    public class DefaultAccountTypeQuery : QueryObjectBase<DefaultAccountTypeReturnSearchDto>
    {
        public DefaultAccountTypeQuery(
            ISqlQueryBuilder queryBuilder,
            DapperDbContext dapper,
            ITenantResolver tenantResolver,
            IExceptionManager exceptionManager,
            string? fiscalYear = null)
            : base(queryBuilder, dapper, tenantResolver, exceptionManager, fiscalYear)
        {
        }

        public override async Task<ReturnBase<IEnumerable<DefaultAccountTypeReturnSearchDto>>> Query(SqlQueryOptions queryOptions)
        {
            try
            {
                var tableName = "Accounting.DefaultAccountType";

                var selectFields = new[]
                {
                    "Id",
                    "Code",
                    "VATOUTPUT",
                    "Name",
                    "EntityType",
                    "ProgramId"
                };

                var programJoin = new JoinTable(
                   "Syst.Program",
                   "ProgramName ",
                   "ProgramId Program_ID"
               );

                var queryData = await _queryBuilder.GetQueryStringDataAsync(
                    tableName,
                    string.Join(", ", selectFields),
                    new List<JoinTable> { programJoin },
                    queryOptions
                );

                var result = await _dapper.QueryList<DefaultAccountTypeReturnSearchDto>(
                    queryData.QueryString!,
                    queryData.Parameters!.ToDictionary()
                );

                if (!result.Succeeded)
                    return ReturnBase<IEnumerable<DefaultAccountTypeReturnSearchDto>>.Fail(result.Errors);

                return ReturnBase<IEnumerable<DefaultAccountTypeReturnSearchDto>>.Success(result.Result);
            }
            catch (Exception ex)
            {
                return ReturnBase<IEnumerable<DefaultAccountTypeReturnSearchDto>>.Fail(ex, _exceptionManager);
            }
        }

        public override Task<ReturnBase<IEnumerable<DefaultAccountTypeReturnSearchDto>>> Query(SqlQueryOptions queryOptions, string functionParameter)
            => throw new NotImplementedException();

        public override Task<ReturnBase<IEnumerable<DefaultAccountTypeReturnSearchDto>>> Query(SqlQueryOptions queryOptions, object[] functionParameters)
            => throw new NotImplementedException();
    }
}
