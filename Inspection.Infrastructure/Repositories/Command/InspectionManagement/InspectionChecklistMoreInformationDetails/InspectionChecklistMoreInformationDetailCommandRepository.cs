using Inspection.Application.Contracts.Dto.InspectionManagement.InspectionChecklistMoreInformationDetails;
using Inspection.Application.Contracts.Repositories.Command.InspectionManagement.InspectionChecklistMoreInformationDetails;
using Inspection.Domain.Models.InspectionManagement.InspectionChecklistMoreInformationDetails;
using Microsoft.EntityFrameworkCore;
using NDS.Shared.Application.Multitenant;
using NDS.Shared.Application.RepositoryBase.RepositoryHelpers;
using NDS.Shared.Infrastructure.RepositoryBase;
using NDS.Shared.Kernel.BaseReturnTypes;
using NDS.Shared.Kernel.Exceptions;

namespace Inspection.Infrastructure.Repositories.Command.InspectionManagement.InspectionChecklistMoreInformationDetails
{

    public class InspectionChecklistMoreInformationDetailCommandRepository : CommandRepositoryBase<InspectionChecklistMoreInformationDetail>, IInspectionChecklistMoreInformationDetailCommandRepository
    {
        public InspectionChecklistMoreInformationDetailCommandRepository(DbContext context, ITenantResolver tenantResolver, IExceptionManager exceptionManager) : base(context, tenantResolver, exceptionManager)
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
                    ErrorMessage = "Equipments More Information Detail Not Found"
                };
                var listOfErrors = new List<ReturnBaseError>() { error };
                return ReturnBase.Fail(listOfErrors);
            }
            _dbSet.Remove(entity);
            return ReturnBase.Success();
        }


        public async Task<ReturnBase<CreateInspectionChecklistMoreInformationDetailDto>> InsertAsync(InspectionChecklistMoreInformationDetail input)
        {
            throw new NotImplementedException();
        }

        public Task<ReturnBase<bool>> DeleteAsync(long id)
        {
            throw new NotImplementedException();
        }

        public Task<ReturnBase<InspectionChecklistMoreInformationDetailDto>> GetAsync(long id)
        {
            throw new NotImplementedException();
        }

        public Task<ReturnBase<List<InspectionChecklistMoreInformationDetailDto>>> GetListAsync()
        {
            throw new NotImplementedException();
        }


        public Task<ReturnBase<InspectionChecklistMoreInformationDetailDto>> UpdateAsync(long id, UpdateInspectionChecklistMoreInformationDetailDto input)
        {
            throw new NotImplementedException();
        }
    }
}
//InspectionChecklistMoreInformationDetailCommandRepository