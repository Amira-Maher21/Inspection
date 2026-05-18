using Inspection.Domain.Models.ApprovalManagement;
using NDS.Shared.Application.RepositoryBase;

namespace Inspection.Application.Contracts.Repositories.Command.ApprovalManagement
{
    public interface IApprovalCommandRepository : ICommandRepository<Approval>
    {
        Task InsertWithDetailsAsync(Approval approval);
        //Task<ReturnBase> DeleteApprovalDetailsByIds(List<long> ids);

    }
}
