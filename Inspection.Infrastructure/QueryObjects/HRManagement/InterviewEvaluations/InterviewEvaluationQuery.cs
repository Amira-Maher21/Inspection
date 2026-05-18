using Inspection.Application.Contracts.Dto.HRManagement.InterviewEvaluations;
using NDS.Shared.Application.DataQuery;
using NDS.Shared.Application.Multitenant;
using NDS.Shared.Infrastructure.DataContext;
using NDS.Shared.Kernel.BaseReturnTypes;
using NDS.Shared.Kernel.Exceptions;

namespace Inspection.Infrastructure.QueryObjects.HRManagement.InterviewEvaluations
{
    public class InterviewEvaluationQuery : QueryObjectBase<InterviewEvaluationDto>
    {
        public InterviewEvaluationQuery(
            ISqlQueryBuilder queryBuilder,
            DapperDbContext dapper,
            ITenantResolver tenantResolver,
            IExceptionManager exceptionManager,
            string? fiscalYear = null
        ) : base(queryBuilder, dapper, tenantResolver, exceptionManager, fiscalYear)
        {
        }

        public override async Task<ReturnBase<IEnumerable<InterviewEvaluationDto>>> Query(SqlQueryOptions queryOptions)
        {
            try
            {
                string baseTable = "HR.InterviewEvaluation";
                string baseAlias = "D";

                var selectFields = new List<string>
        {
            "D.Id",
            "D.TechnicalEvaluation",
            "D.BehavioralEvaluation",
            "D.Notes",
            "D.InterviewerName",
            "D.InterviewDate",
            "D.Result"
        };

                var joins = new List<(string JoinType, string Table, string Alias, string Condition)>();

                var sql = base.ApplyJoinQuary(baseTable, baseAlias, selectFields, joins, queryOptions);

                var result = await _dapper.QueryList<InterviewEvaluationDto>(sql);

                if (!result.Succeeded)
                    return ReturnBase<IEnumerable<InterviewEvaluationDto>>.Fail(result.Errors);

                var list = base.ApplyFilters(result.Result, queryOptions);

                return ReturnBase<IEnumerable<InterviewEvaluationDto>>.Success(list);
            }
            catch (Exception ex)
            {
                return ReturnBase<IEnumerable<InterviewEvaluationDto>>.Fail(ex, _exceptionManager);
            }
        }
        public override Task<ReturnBase<IEnumerable<InterviewEvaluationDto>>> Query(SqlQueryOptions queryOptions, string functionParameter)
        {
            throw new NotImplementedException();
        }
        public override Task<ReturnBase<IEnumerable<InterviewEvaluationDto>>> Query(SqlQueryOptions queryOptions, object[] functionParameters)
        {
            throw new NotImplementedException();
        }
    }
}