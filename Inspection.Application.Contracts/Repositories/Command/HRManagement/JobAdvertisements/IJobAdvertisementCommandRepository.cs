using Inspection.Domain.Models.HRManagement.InterviewEvaluations;
using Inspection.Domain.Models.HRManagement.JobAdvertisements;
using NDS.Shared.Application.RepositoryBase;
using NDS.Shared.Kernel.BaseReturnTypes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inspection.Application.Contracts.Repositories.Command.HRManagement.JobAdvertisements
{
    public interface IJobAdvertisementCommandRepository : ICommandRepository<JobAdvertisement>
    {
        Task<ReturnBase> DeleteByIdAsync(long id);
    }
}
