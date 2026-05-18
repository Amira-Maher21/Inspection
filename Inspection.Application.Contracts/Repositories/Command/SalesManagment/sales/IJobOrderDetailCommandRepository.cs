using Inspection.Domain.Models.Inspection.Techinal.JobOrder;
using NDS.Shared.Application.RepositoryBase;
using NDS.Shared.Kernel.BaseReturnTypes;

namespace Inspection.Application.Contracts.Repositories.Command.SalesManagment.sales
{
    public interface IJobOrderDetailCommandRepository : ICommandRepository<JobOrderLine>
    {
        Task<ReturnBase> DeleteByIdAsync(long id);

    }
}
