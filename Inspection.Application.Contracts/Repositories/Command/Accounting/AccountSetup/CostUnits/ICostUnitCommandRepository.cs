using Inspection.Domain.Models.Accounting.AccountingSetup.CostUnits;
using NDS.Shared.Application.RepositoryBase;
using NDS.Shared.Kernel.BaseReturnTypes;

namespace Inspection.Application.Contracts.Repositories.Command.Accounting.AccountSetup.CostUnits
{
    public interface ICostUnitCommandRepository : ICommandRepository<CostUnit>
    {
        Task<ReturnBase> DeleteById(long id);
        Task<bool> HasChildren(long parentCostUnitId);
        Task<CostUnit?> GetFirstChild(long parentCostUnitId);
        Task<List<long>> GetChildCostUnitIds(long parentCostUnitId);
    }
}