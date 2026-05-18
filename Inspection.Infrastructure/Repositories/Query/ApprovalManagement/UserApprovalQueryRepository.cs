using Inspection.Application.Contracts.Dto.ApprovalManagement.UserApproval;
using Inspection.Application.Contracts.Repositories.Query.ApprovalManagement;
using Inspection.Domain.Models.ApprovalManagement;
using Inspection.Infrastructure.QueryObjects.ApprovalManagement.UserApproval;
using Microsoft.EntityFrameworkCore;
using NDS.Shared.Application.DataQuery;
using NDS.Shared.Application.Multitenant;
using NDS.Shared.Infrastructure.DataContext;
using NDS.Shared.Infrastructure.RepositoryBase;
using NDS.Shared.Kernel.BaseReturnTypes;
using NDS.Shared.Kernel.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inspection.Infrastructure.Repositories.Query.ApprovalManagement
{
    public class UserApprovalQueryRepository : QueryRepositoryBase<User_Approval>, IUserApprovalQueryRepository
    {
        public UserApprovalQueryRepository(ISqlQueryBuilder queryBuilder, DapperDbContext dapper, DbContext context, ITenantResolver tenantResolver, IExceptionManager exceptionManager) : base(queryBuilder, dapper, context, tenantResolver, exceptionManager)
        {
        }

        public async Task<ReturnBase<IEnumerable<UserApprovalIndexItemDto>>> GetUserApprovalIndexAsync(SqlQueryOptions queryOptions)
        {
            UserApprovalIndexQuery indexQuery = new UserApprovalIndexQuery(this._queryBuilder, this._dapper, this._tenantResolver, this._exceptionManager);
            return await base.Query(indexQuery, queryOptions);
        }
    }
}
