using Inspection.Domain.Models.Accounting.AccountingSetup;
using NDS.Shared.Application.RepositoryBase;
using NDS.Shared.Kernel.BaseReturnTypes;

namespace Inspection.Application.Contracts.Repositories.Command.Accounting.AccountSetup
{
    public interface ICostCenterCommandRepository : ICommandRepository<CostCenter>
    {
        Task<ReturnBase> DeleteById(long id);
        Task<bool> HasChildren(long parentId);

    }
}