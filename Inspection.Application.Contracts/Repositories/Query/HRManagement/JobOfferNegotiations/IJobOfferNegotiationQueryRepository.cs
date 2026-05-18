using Inspection.Application.Contracts.Dto.HRManagement.Departments;
using Inspection.Application.Contracts.Dto.HRManagement.JobAdvertisements;
using Inspection.Application.Contracts.Dto.HRManagement.JobOfferNegotiations;
using Inspection.Domain.Models.HRManagement.JobAdvertisements;
using Inspection.Domain.Models.HRManagement.JobOfferNegotiations;
using NDS.Shared.Application.DataQuery;
using NDS.Shared.Application.RepositoryBase;
using NDS.Shared.Kernel.BaseReturnTypes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inspection.Application.Contracts.Repositories.Query.HRManagement.JobOfferNegotiations
{
    public interface IJobOfferNegotiationQueryRepository : IQueryRepository<JobOfferNegotiation>
    {
        Task<JobOfferNegotiation?> GetByIdAsync(long id);
        Task<ReturnBase<IEnumerable<JobOfferNegotiationDto>>> GetListAsync(SqlQueryOptions sqlQueryOptions);
        Task<ReturnBase<IEnumerable<JobOfferNegotiationDto>>> GetLookUpCompanyForNamesAsync(SqlQueryOptions queryOptions);

    }
}
