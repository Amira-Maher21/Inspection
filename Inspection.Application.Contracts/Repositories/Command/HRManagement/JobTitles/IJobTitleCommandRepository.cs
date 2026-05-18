using Inspection.Domain.Models.HRManagement.JobTitles;
using NDS.Shared.Application.RepositoryBase;
using NDS.Shared.Kernel.BaseReturnTypes;


namespace Inspection.Application.Contracts.Repositories.Command.HRManagement.JobTitles
{
    public interface IJobTitleCommandRepository : ICommandRepository<JobTitle>
    {
        Task<ReturnBase> DeleteByIdAsync(long id);
    }
}
