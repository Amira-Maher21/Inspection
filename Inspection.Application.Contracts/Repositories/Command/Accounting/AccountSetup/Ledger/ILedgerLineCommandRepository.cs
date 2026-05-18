using Inspection.Domain.Models.Inventory.Ledger;
using NDS.Shared.Application.RepositoryBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inspection.Application.Contracts.Repositories.Command.Accounting.AccountSetup.LedgerCommandRepository
{
    public interface ILedgerLineCommandRepository : ICommandRepository<LedgerLine>
    {
    }
}
