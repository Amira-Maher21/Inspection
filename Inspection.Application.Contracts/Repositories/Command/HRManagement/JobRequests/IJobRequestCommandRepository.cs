using Inspection.Domain.Models.HRManagement.JobRequests;
using NDS.Shared.Application.RepositoryBase;
using NDS.Shared.Kernel.BaseReturnTypes;


namespace Inspection.Application.Contracts.Repositories.Command.HRManagement.JobRequests
{
    public interface IJobRequestCommandRepository : ICommandRepository<JobRequest>
    {
        Task<ReturnBase> DeleteByIdAsync(long id);
    }
}
