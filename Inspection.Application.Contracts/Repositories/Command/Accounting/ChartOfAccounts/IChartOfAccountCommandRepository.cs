using Inspection.Domain.Models.Accounting.ChartOfAccounts;
using NDS.Shared.Application.RepositoryBase;
using NDS.Shared.Kernel.BaseReturnTypes;

namespace Inspection.Application.Contracts.Repositories.Command.Accounting.ChartOfAccounts
{
    public interface IChartOfAccountCommandRepository : ICommandRepository<ChartOfAccount>
    {
        Task<ReturnBase> DeleteById(long id);
        Task<bool> HasChildren(long parentId);
        Task<ChartOfAccount?> GetFirstChild(long parentId);
        Task<List<long>> GetChildAccountIds(long parentId);
    }
}