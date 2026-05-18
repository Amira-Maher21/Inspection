using Inspection.Application.Contracts.Repositories.Command.HRManagement.JobAdvertisements;
using Inspection.Application.Contracts.Repositories.Command.HRManagement.JobOfferNegotiations;
using Inspection.Domain.Models.HRManagement.JobAdvertisements;
using Inspection.Domain.Models.HRManagement.JobOfferNegotiations;
using Microsoft.EntityFrameworkCore;
using NDS.Shared.Application.Multitenant;
using NDS.Shared.Application.RepositoryBase.RepositoryHelpers;
using NDS.Shared.Infrastructure.RepositoryBase;
using NDS.Shared.Kernel.BaseReturnTypes;
using NDS.Shared.Kernel.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inspection.Infrastructure.Repositories.Command.HRManagement.JobOfferNegotiations
{
    internal class JobOfferNegotiationCommandRepository : CommandRepositoryBase<JobOfferNegotiation>, IJobOfferNegotiationCommandRepository
    {
        public JobOfferNegotiationCommandRepository(DbContext context, ITenantResolver tenantResolver, IExceptionManager exceptionManager) : base(context, tenantResolver, exceptionManager)
        {

            _entityStructure = new EntityStructure
            {
                Key = ["Id"]
            };
        }
        public async Task<ReturnBase> DeleteByIdAsync(long id)
        {
            var entity = await _dbSet.Where(x => x.Id == id).FirstOrDefaultAsync();
            if (entity is null)
            {
                var error = new ReturnBaseError
                {
                    ErrorCode = "404",
                    ErrorMessage = "Department Not Found"
                };
                var listOfErrors = new List<ReturnBaseError>() { error };
                return ReturnBase.Fail(listOfErrors);
            }
            _dbSet.Remove(entity);
            return ReturnBase.Success();
        }
    }
}