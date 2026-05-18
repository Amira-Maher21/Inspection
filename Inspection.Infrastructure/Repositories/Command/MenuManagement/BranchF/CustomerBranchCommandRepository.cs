using Inspection.Application.Contracts.Repositories.Command.MenuManagement.BranchF;
using Inspection.Domain.Models.MenuManagement;
using Microsoft.EntityFrameworkCore;
using NDS.Shared.Application.Multitenant;
using NDS.Shared.Application.RepositoryBase.RepositoryHelpers;
using NDS.Shared.Infrastructure.RepositoryBase;
using NDS.Shared.Kernel.Exceptions;

namespace Inspection.Infrastructure.Repositories.Command.MenuManagement.BranchF
{
    public class CustomerBranchCommandRepository : CommandRepositoryBase<CustomerBranch>, ICustomerBranchCommandRepository
    {
        public CustomerBranchCommandRepository(DbContext context, ITenantResolver tenantResolver, IExceptionManager exceptionManager) : base(context, tenantResolver, exceptionManager)
        {

            _entityStructure = new EntityStructure
            {
                Key = ["Id"]
            };
        }

    }
}
