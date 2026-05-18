using Inspection.Application.Contracts.Repositories.Command.Accounting.AccountSetup.ILedgerCommandRepository;
using Inspection.Application.Contracts.Repositories.Command.Accounting.AccountSetup.LedgerCommandRepository;
using Inspection.Domain.Models.Inventory.Ledger;
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

namespace Inspection.Infrastructure.Repositories.Command.Accounting.AccountSetup.LedgerCommandRepository
{
    public class LedgerLineCommandRepository : CommandRepositoryBase<LedgerLine>, ILedgerLineCommandRepository
    {
        public LedgerLineCommandRepository(DbContext context, ITenantResolver tenantResolver, IExceptionManager exceptionManager) : base(context, tenantResolver, exceptionManager)
        {

            _entityStructure = new EntityStructure
            {
                Key = ["Id"]
            };
        }
    }
}
