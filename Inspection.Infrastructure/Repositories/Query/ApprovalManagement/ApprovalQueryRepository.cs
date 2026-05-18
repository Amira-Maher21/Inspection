using Inspection.Application.Contracts.Dto.ApprovalManagement;
using Inspection.Application.Contracts.Dto.ApprovalManagement.LookUpDto;
using Inspection.Application.Contracts.Repositories.Query.ApprovalManagement;
using Inspection.Domain.Models.ApprovalManagement;
using Inspection.Infrastructure.QueryObjects.ApprovalManagement;
using Microsoft.EntityFrameworkCore;
using NDS.Shared.Application.DataQuery;
using NDS.Shared.Application.Multitenant;
using NDS.Shared.Infrastructure.DataContext;
using NDS.Shared.Infrastructure.RepositoryBase;
using NDS.Shared.Kernel.BaseReturnTypes;
using NDS.Shared.Kernel.Exceptions;

namespace Inspection.Infrastructure.Repositories.Query.ApprovalManagement
{
    internal class ApprovalQueryRepository : QueryRepositoryBase<Approval>, IApprovalQueryRepository
    {
        public ApprovalQueryRepository(ISqlQueryBuilder queryBuilder, DapperDbContext dapper, DbContext context, ITenantResolver tenantResolver, IExceptionManager exceptionManager) : base(queryBuilder, dapper, context, tenantResolver, exceptionManager)
        {
        }

        public async Task<ReturnBase<IEnumerable<ApprovalDto>>> GetApprovalIndexAsync(SqlQueryOptions queryOptions)
        {
            ApprovalIndexQuery indexQuery = new ApprovalIndexQuery(this._queryBuilder, this._dapper, this._tenantResolver, this._exceptionManager);
            return await base.Query(indexQuery, queryOptions);
        }
        public async Task<ReturnBase<IEnumerable<ApprovalHlpScrScreenCodedApprovalLookUpDto>>> GetApprovalHlpScrScreenCodedApprovalLookUpAsync(SqlQueryOptions queryOptions)
        {
            ApprovalHlpScrScreenCodedApprovalLookUpQuery indexQuery = new ApprovalHlpScrScreenCodedApprovalLookUpQuery(_queryBuilder, _dapper, _tenantResolver, _exceptionManager);
            return await Query(indexQuery, queryOptions);
        }
        public async Task<ReturnBase<IEnumerable<ApprovalUser_CodeMLookUpDto>>> GetApprovalUser_CodeMLookUpAsync(SqlQueryOptions queryOptions)
        {
            ApprovalUser_CodeMLookUpQuery indexQuery = new ApprovalUser_CodeMLookUpQuery(_queryBuilder, _dapper, _tenantResolver, _exceptionManager);
            return await Query(indexQuery, queryOptions);
        }

        public async Task<ReturnBase<IEnumerable<ApprovalUser_CodeDLookUpDto>>> GetApprovalUser_CodeDLookUpAsync(SqlQueryOptions queryOptions)
        {
            ApprovalUser_CodeDLookUpQuery indexQuery = new ApprovalUser_CodeDLookUpQuery(_queryBuilder, _dapper, _tenantResolver, _exceptionManager);
            return await Query(indexQuery, queryOptions);
        }
        public async Task<ReturnBase<IEnumerable<ApprovalUserCountLookUpDto>>> GetApprovalUserCountLookUpAsync(SqlQueryOptions queryOptions)
        {
            ApprovalUserCountLookUpQuery indexQuery = new ApprovalUserCountLookUpQuery(_queryBuilder, _dapper, _tenantResolver, _exceptionManager);
            return await Query(indexQuery, queryOptions);
        }
        public async Task<Approval?> GetById(long id)
        {
            return await _context.Set<Approval>()
                .Include(x => x.Approval_ds)
                .Include(x => x.Approval_Delegations)
                .FirstOrDefaultAsync(x => x.Id == id);
        }
    }
}