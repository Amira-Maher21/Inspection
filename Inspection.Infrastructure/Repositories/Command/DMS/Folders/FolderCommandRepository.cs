using Inspection.Application.Contracts.Repositories.Command.DMS.Folders;
using Inspection.Domain.Models.DMS.Folders;
using Microsoft.EntityFrameworkCore;
using NDS.Shared.Application.Multitenant;
using NDS.Shared.Application.RepositoryBase.RepositoryHelpers;
using NDS.Shared.Infrastructure.RepositoryBase;
using NDS.Shared.Kernel.BaseReturnTypes;
using NDS.Shared.Kernel.Exceptions;

namespace Inspection.Infrastructure.Repositories.Command.DMS.Folders
{
    public class FolderCommandRepository : CommandRepositoryBase<Folder>, IFolderCommandRepository
    {
        public FolderCommandRepository(DbContext context, ITenantResolver tenantResolver, IExceptionManager exceptionManager) : base(context, tenantResolver, exceptionManager)
        {

            _entityStructure = new EntityStructure
            {
                Key = ["Id"]
            };
        }
        public async Task<ReturnBase> DeleteById(long id)
        {
            var entity = await _dbSet.Where(x => x.Id == id).FirstOrDefaultAsync();
            if (entity is null)
            {
                var error = new ReturnBaseError
                {
                    ErrorCode = "404",
                    ErrorMessage = $"Folder with Id '{id}' was not found."
                };
                var listOfErrors = new List<ReturnBaseError>() { error };
                return ReturnBase.Fail(listOfErrors);
            }
            _dbSet.Remove(entity);
            return ReturnBase.Success();
        }
        public async Task<bool> ExistsDuplicateNameAsync(string tenantId, long companyId, long? parentFolderId, string name, long? ignoreId)
        {
            return await _context.Set<Folder>()
                .AsNoTracking()
                .AnyAsync(f =>
                    (ignoreId == null || f.Id != ignoreId) &&
                    f.Tenant_ID == tenantId &&
                    f.CompanyId == companyId &&
                    f.ParentFolderId == parentFolderId &&
                    f.Name == name);
        }

    }
}