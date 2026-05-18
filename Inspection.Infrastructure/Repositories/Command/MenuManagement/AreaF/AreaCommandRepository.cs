using Inspection.Application.Contracts.Repositories.Command.MenuManagement.AreaF;
using Inspection.Application.Contracts.Repositories.Command.MenuManagement.BranchF;
using Inspection.Domain.Models.MenuManagement;
using Microsoft.EntityFrameworkCore;
using NDS.Shared.Application.Multitenant;
using NDS.Shared.Application.RepositoryBase.RepositoryHelpers;
using NDS.Shared.Infrastructure.RepositoryBase;
using NDS.Shared.Kernel.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inspection.Infrastructure.Repositories.Command.MenuManagement.AreaF
{
    public class AreaCommandRepository : CommandRepositoryBase<Area>, IAreaCommandRepository
    {
        public AreaCommandRepository(DbContext context, ITenantResolver tenantResolver, IExceptionManager exceptionManager) : base(context, tenantResolver, exceptionManager)
        {

            _entityStructure = new EntityStructure
            {
                Key = ["Id"]
            };
        }

    }
}
