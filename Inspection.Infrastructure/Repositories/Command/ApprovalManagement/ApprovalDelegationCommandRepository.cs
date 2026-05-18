using Inspection.Application.Contracts.Repositories.Command.ApprovalManagement;
using Inspection.Domain.Models.ApprovalManagement;
using Inspection.Infrastructure.DataContext;
using NDS.Shared.Application.Multitenant;
using NDS.Shared.Application.RepositoryBase.RepositoryHelpers;
using NDS.Shared.Infrastructure.RepositoryBase;
using NDS.Shared.Kernel.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inspection.Infrastructure.Repositories.Command.ApprovalManagement
{
    internal class ApprovalDelegationCommandRepository : CommandRepositoryBase<Approval_Delegation>, IApprovalDelegationCommandRepository
    {
        public ApprovalDelegationCommandRepository(DbInspectionContext context,
                                        ITenantResolver tenantResolver,
                                        IExceptionManager exceptionManager) : base(context, tenantResolver, exceptionManager)
        {
            this._entityStructure = new EntityStructure
            {
                Key = ["ID"],

            };

        }
    }
}
