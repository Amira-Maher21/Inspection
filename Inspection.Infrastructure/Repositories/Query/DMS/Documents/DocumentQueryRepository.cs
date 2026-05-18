using Inspection.Application.Contracts.Dto.DMSDTOs.DocumentDTOs;
using Inspection.Application.Contracts.Repositories.Query.DMS.Documents;
using Inspection.Domain.Models.DMS.Documents;
using Microsoft.EntityFrameworkCore;
using NDS.Shared.Application.DataQuery;
using NDS.Shared.Application.Multitenant;
using NDS.Shared.Infrastructure.DataContext;
using NDS.Shared.Infrastructure.RepositoryBase;
using NDS.Shared.Kernel.BaseReturnTypes;
using NDS.Shared.Kernel.Exceptions;

namespace Inspection.Infrastructure.Repositories.Query.DMS.Documents
{
    public class DocumentQueryRepository : QueryRepositoryBase<Document>, IDocumentQueryRepository
    {
        public DocumentQueryRepository(ISqlQueryBuilder queryBuilder, DapperDbContext dapper, DbContext context, ITenantResolver tenantResolver, IExceptionManager exceptionManager) : base(queryBuilder, dapper, context, tenantResolver, exceptionManager)
        {
        }

        public async Task<Document?> GetById(long id)
        {
            return await _context.Set<Document>()
                                 .Include(x => x.DocumentTags)
                                 .Include(x => x.DocumentEntityLinks)
                                 .FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<ReturnBase<IEnumerable<DocumentSearchReturnDto>>> Search(SqlQueryOptions sqlQueryOptions, string tenantId, long companyId)
        {
            try
            {
                var result = await _context.Set<Document>()
                    .AsNoTracking()
                    .Include(d => d.Folder)
                    .Include(d => d.DocumentTags) // needed for TagIds
                    .Where(d =>
                        d.Tenant_ID == tenantId &&
                        d.CompanyId == companyId)
                    .Select(d => new DocumentSearchReturnDto
                    {
                        Id = d.Id,
                        Tenant_ID = d.Tenant_ID,
                        CompanyId = d.CompanyId,

                        // Identity
                        DocumentNumber = d.DocumentNumber,
                        Title = d.Title,
                        Description = d.Description,

                        // File info
                        OriginalFilename = d.OriginalFilename,
                        FileExtension = d.FileExtension,
                        MimeType = d.MimeType,
                        FileSize = d.FileSize,
                        FileHash = d.FileHash,

                        // Storage
                        StorageType = d.StorageType,
                        URL = d.URL,
                        StoragePath = d.StoragePath,
                        StorageBucket = d.StorageBucket,

                        // Folder
                        FolderId = d.FolderId,
                        FolderName = d.Folder != null
                                        ? d.Folder.Name
                                        : string.Empty,

                        // Metadata
                        DocumentDate = d.DocumentDate,

                        // Versioning
                        VersionNumber = d.VersionNumber,
                        IsLatestVersion = d.IsLatestVersion,
                        ParentDocumentId = d.ParentDocumentId,

                        // ✅ MANY-TO-MANY TAG IDS
                        TagIds = d.DocumentTags
                                    .Select(dt => dt.TagId)
                                    .ToList(),

                        // Search & analytics
                        SearchableContent = d.SearchableContent,
                        ViewCount = d.ViewCount,
                        DownloadCount = d.DownloadCount,
                        ShareCount = d.ShareCount,
                        LastAccessedAt = d.LastAccessedAt,
                        LastAccessedById = d.LastAccessedById,

                        // Audit
                        In_User = d.In_User,
                        In_Date = d.In_Date,
                        Mod_User = d.Mod_User,
                        Mod_Date = d.Mod_Date
                    })
                    .ToListAsync();

                return ReturnBase<IEnumerable<DocumentSearchReturnDto>>
                    .Success(result);
            }
            catch (Exception ex)
            {
                return ReturnBase<IEnumerable<DocumentSearchReturnDto>>
                    .Fail(ex, _exceptionManager);
            }
        }

    }
}