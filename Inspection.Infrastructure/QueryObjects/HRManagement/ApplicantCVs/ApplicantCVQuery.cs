using Inspection.Application.Contracts.Dto.HRManagement.ApplicantCVs;
using NDS.Shared.Application.DataQuery;
using NDS.Shared.Application.Multitenant;
using NDS.Shared.Infrastructure.DataContext;
using NDS.Shared.Kernel.BaseReturnTypes;
using NDS.Shared.Kernel.Exceptions;

namespace Inspection.Infrastructure.QueryObjects.HRManagement.ApplicantCVs
{
    internal class ApplicantCVQuery : QueryObjectBase<ApplicantCVDto>
    {
        public ApplicantCVQuery(
            ISqlQueryBuilder queryBuilder,
            DapperDbContext dapper,
            ITenantResolver tenantResolver,
            IExceptionManager exceptionManager,
            string? fiscalYear = null
        ) : base(queryBuilder, dapper, tenantResolver, exceptionManager, fiscalYear)
        {
        }

        //public override async Task<ReturnBase<IEnumerable<ApplicantCVDto>>> Query(SqlQueryOptions queryOptions)
        //{
        //    try
        //    {
        //        string baseTable = "ApplicantCVs";
        //        string baseAlias = "A";

        //        var selectFields = new List<string>
        //    {

        //        "A.Id",
        //        "A.FullName",
        //        "A.Phone AS PhoneNumber",
        //        "A.Email",
        //        "A.Status",
        //        "J.Id AS JobTitleId",
        //        "J.Title AS JobTitleName"
        //    };

        //        var joins = new List<(string JoinType, string Table, string Alias, string Condition)>
        //    {
        //        ("LEFT JOIN", "JobRequests JR", "JR", "JR.Id = A.JobRequestId"),
        //        ("LEFT JOIN", "JobTitles J", "J", "J.Id = JR.JobTitleId")
        //    };

        //        var sql = base.ApplyJoinQuary(baseTable, baseAlias, selectFields, joins, queryOptions);

        //        var result = await _dapper.QueryList<ApplicantCVDto>(sql);

        //        if (!result.Succeeded)
        //            return ReturnBase<IEnumerable<ApplicantCVDto>>.Fail(result.Errors);

        //        var list = base.ApplyFilters(result.Result, queryOptions);

        //        return ReturnBase<IEnumerable<ApplicantCVDto>>.Success(list);
        //    }
        //    catch (Exception ex)
        //    {
        //        return ReturnBase<IEnumerable<ApplicantCVDto>>.Fail(ex, _exceptionManager);
        //    }
        //}
        public override async Task<ReturnBase<IEnumerable<ApplicantCVDto>>> Query(SqlQueryOptions queryOptions)
        {
            try
            {
                string baseTable = "HR.ApplicantCV";
                string baseAlias = "A";

                var selectFields = new List<string>
        {
            "A.Id",
            "A.FullName",
            "A.Email",
            "A.Phone",
            "A.Status",
            "A.IsInterviewed",
            "JR.Id AS JobRequestId",
            "J.Title AS JobRequestTitle"
        };

                var joins = new List<(string JoinType, string Table, string Alias, string Condition)>
        {
            ("LEFT JOIN", "HR.JobRequest JR", "JR", "JR.Id = A.JobRequestId"),
            ("LEFT JOIN", "HR.JobTitle J", "J", "J.Id = JR.JobTitleId")
        };

                var sql = base.ApplyJoinQuary(baseTable, baseAlias, selectFields, joins, queryOptions);

                var result = await _dapper.QueryList<ApplicantCVDto>(sql);

                if (!result.Succeeded)
                    return ReturnBase<IEnumerable<ApplicantCVDto>>.Fail(result.Errors);

                var list = base.ApplyFilters(result.Result, queryOptions);

                return ReturnBase<IEnumerable<ApplicantCVDto>>.Success(list);
            }
            catch (Exception ex)
            {
                return ReturnBase<IEnumerable<ApplicantCVDto>>.Fail(ex, _exceptionManager);
            }
        }


        public override Task<ReturnBase<IEnumerable<ApplicantCVDto>>> Query(SqlQueryOptions queryOptions, string functionParameter)
        {
            throw new NotImplementedException();
        }

        public override Task<ReturnBase<IEnumerable<ApplicantCVDto>>> Query(SqlQueryOptions queryOptions, object[] functionParameters)
        {
            throw new NotImplementedException();
        }
    }
}