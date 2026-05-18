using Inspection.Application.Contracts.Dto.InspectionManagement.InspectionRequestSubcontractorDetailF;
using Inspection.Application.Contracts.Repositories.Command.InspectionManagement.InspectionRequestDetailSubcontractorF;
using Inspection.Domain.Models.InspectionManagement.InspectionRequests;
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

namespace Inspection.Infrastructure.Repositories.Command.InspectionManagement.InspectionRequestDetailSubcontractorF
{
 

    public class InspectionRequestDetailSubcontractorCommandRepository : CommandRepositoryBase<InspectionRequestSubcontractorDetail>, IInspectionRequestDetailSubcontractorCommandRepository
    {
        DbContext _context;
        public InspectionRequestDetailSubcontractorCommandRepository(DbContext context, ITenantResolver tenantResolver, IExceptionManager exceptionManager) : base(context, tenantResolver, exceptionManager)
        {
            _context = context;
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
                    ErrorMessage = "Inspection Request Detail Not Found"
                };
                var listOfErrors = new List<ReturnBaseError>() { error };
                return ReturnBase.Fail(listOfErrors);
            }
            _dbSet.Remove(entity);
            return ReturnBase.Success();
        }


        public async Task<ReturnBase<CreateInspectionRequestSubcontractorDetailDto>> InsertAsync(InspectionRequestSubcontractorDetail input)
        {
            throw new NotImplementedException();
        }

        public Task<ReturnBase<bool>> DeleteAsync(long id)
        {
            throw new NotImplementedException();
        }

        public Task<ReturnBase<InspectionRequestSubcontractorDetailDto>> GetAsync(long id)
        {
            throw new NotImplementedException();
        }

        public Task<ReturnBase<List<InspectionRequestSubcontractorDetailDto>>> GetListAsync()
        {
            throw new NotImplementedException();
        }


        public Task<ReturnBase<InspectionRequestSubcontractorDetailDto>> UpdateAsync(long id, UpdateInspectionRequestSubcontractorDetailDto input)
        {
            throw new NotImplementedException();
        }
    }
}
 