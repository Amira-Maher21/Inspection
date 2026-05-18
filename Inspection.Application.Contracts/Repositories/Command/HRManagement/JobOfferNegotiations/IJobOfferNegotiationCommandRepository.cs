using Inspection.Domain.Models.HRManagement.JobAdvertisements;
using Inspection.Domain.Models.HRManagement.JobOfferNegotiations;
using NDS.Shared.Application.RepositoryBase;
using NDS.Shared.Kernel.BaseReturnTypes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inspection.Application.Contracts.Repositories.Command.HRManagement.JobOfferNegotiations
{
    public interface IJobOfferNegotiationCommandRepository : ICommandRepository<JobOfferNegotiation>
    {
        Task<ReturnBase> DeleteByIdAsync(long id);

    }
}
