using Inspection.Application.Contracts.Dto.AccountingDtos.AccountingSetupDtos.AccountingPeriodDTOs;
using Inspection.Application.Contracts.Repositories.Query.Accounting.AccountSetup.AccountingPeriods;
using Inspection.Application.Contracts.Repositories.Query.Posting;
using Inspection.Domain.Models.Accounting.AccountingSetup.AccountingPeriods;
using Inspection.Domain.Models.Accounting.PostingEngine;
using Inspection.Infrastructure.QueryObjects.Accounting.AccountSetup.AccountingPeriods;
using Microsoft.EntityFrameworkCore;
using NDS.Shared.Application.DataQuery;
using NDS.Shared.Application.Multitenant;
using NDS.Shared.Infrastructure.DataContext;
using NDS.Shared.Infrastructure.RepositoryBase;
using NDS.Shared.Kernel.BaseReturnTypes;
using NDS.Shared.Kernel.Exceptions;

namespace Inspection.Infrastructure.Repositories.Query.Accounting.AccountSetup.AccountingPeriods
{
    public class PostingAccountMappingQueryRepository : QueryRepositoryBase<PostingAccountMapping>, IPostingAccountMappingQueryRepository
    {
        public PostingAccountMappingQueryRepository(ISqlQueryBuilder queryBuilder, DapperDbContext dapper, DbContext context, ITenantResolver tenantResolver, IExceptionManager exceptionManager) : base(queryBuilder, dapper, context, tenantResolver, exceptionManager)
        {
        }

        public async Task<List<PostingAccountMapping>> GetByDocumentCode(string documentCode)
        {
            //return await _context.Set<PostingAccountMapping>().Where(x => x.PostingDocumentType.DocumentCode == documentCode).ToListAsync();

            return await _context.Set<PostingAccountMapping>()
                .Include(x => x.PostingDocumentType)
                .Where(x => x.PostingDocumentType.DocumentCode == documentCode)
                .OrderBy(x => x.Priority)
                .ToListAsync();
        }
    }
}