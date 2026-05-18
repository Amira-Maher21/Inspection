using Inspection.Domain.Models.HRManagement.ApplicantCVs;
using NDS.Shared.Application.RepositoryBase;
using NDS.Shared.Kernel.BaseReturnTypes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inspection.Application.Contracts.Repositories.Command.HRManagement.ApplicantCVs
{
    public interface IApplicantCVCommandRepository : ICommandRepository<ApplicantCV>
    {
        Task<ReturnBase> DeleteByIdAsync(long id);
    }
}
