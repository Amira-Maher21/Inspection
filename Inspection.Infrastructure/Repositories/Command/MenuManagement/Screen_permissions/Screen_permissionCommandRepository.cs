using Inspection.Application.Contracts.Repositories.Command.MenuManagement.Screen_permissions;
using Inspection.Domain.Models.MenuManagement;
using Inspection.Infrastructure.DataContext;
using NDS.Shared.Application.Multitenant;
using NDS.Shared.Application.RepositoryBase.RepositoryHelpers;
using NDS.Shared.Infrastructure.RepositoryBase;
using NDS.Shared.Kernel.Exceptions;

namespace Inspection.Infrastructure.Repositories.Command.MenuManagement.Screen_permissions
{


    internal class Screen_permissionCommandRepository : CommandRepositoryBase<Screen_permission>, IScreen_permissionCommandRepository
    {
        public Screen_permissionCommandRepository(DbInspectionContext context,
                                        ITenantResolver tenantResolver,
                                        IExceptionManager exceptionManager) : base(context, tenantResolver, exceptionManager)
        {
            this._entityStructure = new EntityStructure
            {
                Key = ["Id"],
            };
        }

        //public Task<ReturnBase> DeleteByIdAsync(string id)
        //{
        //    _context
        //}
    }
}
