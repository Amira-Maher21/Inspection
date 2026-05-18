using Inspection.Application.Contracts.Dto.DMSDTOs.DocumentCommentDTOs;
using Inspection.Application.Contracts.Repositories.Query.DMS.DocumentComments;
using Inspection.Domain.Models.DMS.DocumentComments;
using Inspection.Infrastructure.QueryObjects.DMS.DocumentComments;
using Microsoft.EntityFrameworkCore;
using NDS.Shared.Application.DataQuery;
using NDS.Shared.Application.Multitenant;
using NDS.Shared.Infrastructure.DataContext;
using NDS.Shared.Infrastructure.RepositoryBase;
using NDS.Shared.Kernel.BaseReturnTypes;
using NDS.Shared.Kernel.Exceptions;

namespace Inspection.Infrastructure.Repositories.Query.DMS.DocumentComments
{
    public class DocumentCommentQueryRepository : QueryRepositoryBase<DocumentComment>, IDocumentCommentQueryRepository
    {
        public DocumentCommentQueryRepository(ISqlQueryBuilder queryBuilder, DapperDbContext dapper, DbContext context, ITenantResolver tenantResolver, IExceptionManager exceptionManager) : base(queryBuilder, dapper, context, tenantResolver, exceptionManager)
        {
        }

        public async Task<DocumentComment?> GetById(long id)
        {
            return await _context.Set<DocumentComment>().FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<ReturnBase<IEnumerable<DocumentCommentReturnSearchDto>>> Search(SqlQueryOptions sqlQueryOptions)
        {
            var documentCommentRepository = new DocumentCommentQuery(_queryBuilder, _dapper, _tenantResolver, _exceptionManager);
            return await documentCommentRepository.Query(sqlQueryOptions);
        }
    }
}