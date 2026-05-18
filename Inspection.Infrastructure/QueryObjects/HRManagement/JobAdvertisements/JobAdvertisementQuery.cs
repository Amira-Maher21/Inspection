using Inspection.Application.Contracts.Dto.HRManagement.JobAdvertisements;
using NDS.Shared.Application.DataQuery;
using NDS.Shared.Application.Multitenant;
using NDS.Shared.Infrastructure.DataContext;
using NDS.Shared.Kernel.BaseReturnTypes;
using NDS.Shared.Kernel.Exceptions;

namespace Inspection.Infrastructure.QueryObjects.HRManagement.JobAdvertisements
{
    public class JobAdvertisementQuery : QueryObjectBase<JobAdvertisementDto>
    {
        public JobAdvertisementQuery(
            ISqlQueryBuilder queryBuilder,
            DapperDbContext dapper,
            ITenantResolver tenantResolver,
            IExceptionManager exceptionManager,
            string? fiscalYear = null
        ) : base(queryBuilder, dapper, tenantResolver, exceptionManager, fiscalYear)
        {
        }

        public override async Task<ReturnBase<IEnumerable<JobAdvertisementDto>>> Query(SqlQueryOptions queryOptions)
        {
            try
            {
                string baseTable = "HR.JobAdvertisement";
                string baseAlias = "D";


                var selectFields = new List<string>
    {
        "D.Id",
        "D.JobRequestId",
        "D.Platform",
        "D.Url",
        "D.PostedAt",
        "JR.Status AS JobRequestStatus",
        "Jt.Title AS JobTitle"
    };


                var joins = new List<(string JoinType, string Table, string Alias, string Condition)>
    {
        ("INNER JOIN", "HR.JobRequest JR", "JR", "JR.Id = D.JobRequestId"),
        ("INNER JOIN", "HR.JobTitle Jt", "Jt", "Jt.Id = JR.JobTitleId")
    };

                var sql = base.ApplyJoinQuary(baseTable, baseAlias, selectFields, joins, queryOptions);


                var result = await _dapper.QueryList<JobAdvertisementDto>(sql);

                if (!result.Succeeded)
                    return ReturnBase<IEnumerable<JobAdvertisementDto>>.Fail(result.Errors);


                var list = base.ApplyFilters(result.Result, queryOptions);

                return ReturnBase<IEnumerable<JobAdvertisementDto>>.Success(list);
            }
            catch (Exception ex)
            {
                return ReturnBase<IEnumerable<JobAdvertisementDto>>.Fail(ex, _exceptionManager);
            }

        }

        public override Task<ReturnBase<IEnumerable<JobAdvertisementDto>>> Query(SqlQueryOptions queryOptions, string functionParameter)
        {
            throw new NotImplementedException();
        }

        public override Task<ReturnBase<IEnumerable<JobAdvertisementDto>>> Query(SqlQueryOptions queryOptions, object[] functionParameters)
        {
            throw new NotImplementedException();
        }
    }
}