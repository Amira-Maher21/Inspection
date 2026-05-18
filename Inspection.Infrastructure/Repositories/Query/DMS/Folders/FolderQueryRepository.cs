using Inspection.Application.Contracts.Dto.DMSDTOs.FolderDTOs;
using Inspection.Application.Contracts.Repositories.Query.DMS.Folders;
using Inspection.Domain.Models.DMS.Folders;
using Microsoft.EntityFrameworkCore;
using NDS.Shared.Application.DataQuery;
using NDS.Shared.Application.Multitenant;
using NDS.Shared.Infrastructure.DataContext;
using NDS.Shared.Infrastructure.RepositoryBase;
using NDS.Shared.Kernel.BaseReturnTypes;
using NDS.Shared.Kernel.Exceptions;

namespace Inspection.Infrastructure.Repositories.Query.DMS.Folders
{
    public class FolderQueryRepository : QueryRepositoryBase<Folder>, IFolderQueryRepository
    {
        public FolderQueryRepository(ISqlQueryBuilder queryBuilder, DapperDbContext dapper, DbContext context, ITenantResolver tenantResolver, IExceptionManager exceptionManager) : base(queryBuilder, dapper, context, tenantResolver, exceptionManager)
        {
        }

        public async Task<Folder?> GetById(long id)
        {
            return await _context.Set<Folder>().Where(x => x.Id == id).FirstOrDefaultAsync();
        }

        public async Task<ReturnBase<IEnumerable<FolderReturnSearchDto>>> Search(SqlQueryOptions sqlQueryOptions, string tenantId, long companyId)
        {
            try
            {
                var result = await _context.Set<Folder>()
                    .AsNoTracking()
                    .Include(f => f.Screen)
                    .Where(f => f.Tenant_ID == tenantId && f.CompanyId == companyId)
                    .Select(f => new FolderReturnSearchDto
                    {
                        Id = f.Id,
                        Tenant_ID = f.Tenant_ID,
                        CompanyId = f.CompanyId,
                        Name = f.Name,
                        Description = f.Description,
                        ParentFolderId = f.ParentFolderId,
                        Path = f.Path,
                        FolderType = f.FolderType,

                        ScreenId = f.ScreenId,
                        ScreenName = f.Screen != null
                                        ? f.Screen.Screen_Name
                                        : string.Empty,

                        LinkedEntityId = f.LinkedEntityId,
                        IsPublic = f.IsPublic,
                        InheritPermissions = f.InheritPermissions,
                        PermissionType = f.PermissionType,

                        Icon = f.Icon,
                        Color = f.Color,
                        SortOrder = f.SortOrder,

                        In_User = f.In_User,
                        In_Date = f.In_Date,
                        Mod_User = f.Mod_User,
                        Mod_Date = f.Mod_Date
                    })
                    .ToListAsync();

                return ReturnBase<IEnumerable<FolderReturnSearchDto>>.Success(result);
            }
            catch (Exception ex)
            {
                return ReturnBase<IEnumerable<FolderReturnSearchDto>>.Fail(ex, _exceptionManager);
            }
        }

        public IQueryable<Folder> GetAll()
        {
            return _context.Set<Folder>().AsQueryable();
        }
    }
}