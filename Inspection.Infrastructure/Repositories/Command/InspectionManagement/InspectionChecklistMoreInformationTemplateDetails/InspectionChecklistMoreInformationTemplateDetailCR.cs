using Inspection.Application.Contracts.Dto.InspectionManagement.InspectionChecklistMoreInformationTemplateDetails;
using Inspection.Application.Contracts.Repositories.Command.InspectionManagement.InspectionChecklistMoreInformationTemplateDetails;
using Inspection.Domain.Models.InspectionManagement.InspectionChecklistMoreInformationTemplateDetails;
using Microsoft.EntityFrameworkCore;
using NDS.Shared.Application.Multitenant;
using NDS.Shared.Application.RepositoryBase.RepositoryHelpers;
using NDS.Shared.Infrastructure.RepositoryBase;
using NDS.Shared.Kernel.BaseReturnTypes;
using NDS.Shared.Kernel.Exceptions;

namespace Inspection.Infrastructure.Repositories.Command.InspectionManagement.InspectionChecklistMoreInformationTemplateDetails
{



    public class InspectionChecklistMoreInformationTemplateDetailCR : CommandRepositoryBase<InspectionChecklistMoreInformationTemplateDetail>, IInspectionChecklistMoreInformationTemplateDetailCR
    {
        public InspectionChecklistMoreInformationTemplateDetailCR(DbContext context, ITenantResolver tenantResolver, IExceptionManager exceptionManager) : base(context, tenantResolver, exceptionManager)
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
                    ErrorMessage = "Equipments More Information Template Detail Not Found"
                };
                var listOfErrors = new List<ReturnBaseError>() { error };
                return ReturnBase.Fail(listOfErrors);
            }
            _dbSet.Remove(entity);
            return ReturnBase.Success();
        }


        public async Task<ReturnBase<CreateInspectionChecklistMoreInformationTemplateDetailDto>> InsertAsync(InspectionChecklistMoreInformationTemplateDetail input)
        {
            throw new NotImplementedException();
        }

        public Task<ReturnBase<bool>> DeleteAsync(long id)
        {
            throw new NotImplementedException();
        }

        public Task<ReturnBase<InspectionChecklistMoreInformationTemplateDetailDto>> GetAsync(long id)
        {
            throw new NotImplementedException();
        }

        public Task<ReturnBase<List<InspectionChecklistMoreInformationTemplateDetailDto>>> GetListAsync()
        {
            throw new NotImplementedException();
        }


        public Task<ReturnBase<InspectionChecklistMoreInformationTemplateDetailDto>> UpdateAsync(long id, UpdateInspectionChecklistMoreInformationTemplateDetailDto input)
        {
            throw new NotImplementedException();
        }
    }
}
//InspectionChecklistMoreInformationTemplateDetailCommandRepository