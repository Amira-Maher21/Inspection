using Inspection.Application.Contracts.Dto.DMSDTOs.FolderPermissionDTOs;
using Inspection.Application.Contracts.Repositories.Query.DMS.FolderPermissions;
using Inspection.Domain.Models.DMS.FolderPermissions;
using Microsoft.EntityFrameworkCore;
using NDS.Shared.Application.DataQuery;
using NDS.Shared.Application.Multitenant;
using NDS.Shared.Infrastructure.DataContext;
using NDS.Shared.Infrastructure.RepositoryBase;
using NDS.Shared.Kernel.BaseReturnTypes;
using NDS.Shared.Kernel.Exceptions;

namespace Inspection.Infrastructure.Repositories.Query.DMS.FolderPermissions
{
    public class FolderPermissionQueryRepository : QueryRepositoryBase<FolderPermission>, IFolderPermissionQueryRepository
    {
        public FolderPermissionQueryRepository(ISqlQueryBuilder queryBuilder, DapperDbContext dapper, DbContext context, ITenantResolver tenantResolver, IExceptionManager exceptionManager) : base(queryBuilder, dapper, context, tenantResolver, exceptionManager)
        {
        }

        public async Task<FolderPermission?> GetById(long id)
        {
            return await _context.Set<FolderPermission>().Where(x => x.Id == id).FirstOrDefaultAsync();
        }

        public async Task<ReturnBase<IEnumerable<FolderPermissionReturnSearchDto>>> Search(
        SqlQueryOptions sqlQueryOptions,
        string tenantId,
        long companyId)
        {
            try
            {
                var result = await _context.Set<FolderPermission>()
                    .AsNoTracking()
                    .Include(fp => fp.Folder)
                    //.Include(fp => fp.UserGroup)
                    .Where(fp =>
                        fp.Tenant_ID == tenantId &&
                        fp.CompanyId == companyId)
                    .Select(fp => new FolderPermissionReturnSearchDto
                    {
                        Id = fp.Id,
                        Tenant_ID = fp.Tenant_ID,
                        CompanyId = fp.CompanyId,

                        // Permissions
                        CanView = fp.CanView,
                        CanDownload = fp.CanDownload,
                        CanUpload = fp.CanUpload,
                        CanEdit = fp.CanEdit,
                        CanDelete = fp.CanDelete,
                        CanShare = fp.CanShare,
                        CanManage = fp.CanManage,

                        // Validity
                        ValidFrom = fp.ValidFrom,
                        ValidUntil = fp.ValidUntil,

                        // Folder info
                        FolderId = fp.FolderId,
                        FolderName = fp.Folder != null
                                        ? fp.Folder.Name
                                        : string.Empty,

                        // User Group info
                        UserGroupId = fp.UserGroupId,
                        UserGroupName = fp.UserGroup != null
                                            ? fp.UserGroup.User_group_Name
                                            : null,

                        // Audit
                        In_User = fp.In_User,
                        In_Date = fp.In_Date,
                        Mod_User = fp.Mod_User,
                        Mod_Date = fp.Mod_Date
                    })
                    .ToListAsync();

                return ReturnBase<IEnumerable<FolderPermissionReturnSearchDto>>
                    .Success(result);
            }
            catch (Exception ex)
            {
                return ReturnBase<IEnumerable<FolderPermissionReturnSearchDto>>
                    .Fail(ex, _exceptionManager);
            }
        }

        public IQueryable<FolderPermission> GetAll()
        {
            return _context.Set<FolderPermission>().AsQueryable();
        }
    }
}