using Inspection.Application.Contracts.Dto.EquipmentManagement.EquipmentsMoreInformationDetails;
using Inspection.Application.Contracts.Repositories.Command.EquipmentManagement.EquipmentsMoreInformationDetails;
using Inspection.Domain.Models.EquipmentManagement.EquipmentsMoreInformationDetails;
using Microsoft.EntityFrameworkCore;
using NDS.Shared.Application.Multitenant;
using NDS.Shared.Application.RepositoryBase.RepositoryHelpers;
using NDS.Shared.Infrastructure.RepositoryBase;
using NDS.Shared.Kernel.BaseReturnTypes;
using NDS.Shared.Kernel.Exceptions;

namespace Inspection.Infrastructure.Repositories.Command.EquipmentManagement.EquipmentsMoreInformationDetails
{


    public class EquipmentsMoreInformationDetailCommandRepository : CommandRepositoryBase<EquipmentsMoreInformationDetail>, IEquipmentsMoreInformationDetailCommandRepository
    {
        public EquipmentsMoreInformationDetailCommandRepository(DbContext context, ITenantResolver tenantResolver, IExceptionManager exceptionManager) : base(context, tenantResolver, exceptionManager)
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


        public async Task<ReturnBase<CreateEquipmentsMoreInformationDetailDto>> InsertAsync(EquipmentsMoreInformationDetail input)
        {
            throw new NotImplementedException();
        }

        public Task<ReturnBase<bool>> DeleteAsync(long id)
        {
            throw new NotImplementedException();
        }

        public Task<ReturnBase<EquipmentsMoreInformationDetailDto>> GetAsync(long id)
        {
            throw new NotImplementedException();
        }

        public Task<ReturnBase<List<EquipmentsMoreInformationDetailDto>>> GetListAsync()
        {
            throw new NotImplementedException();
        }


        public Task<ReturnBase<EquipmentsMoreInformationDetailDto>> UpdateAsync(long id, UpdateEquipmentsMoreInformationDetailDto input)
        {
            throw new NotImplementedException();
        }
    }
}
//EquipmentsMoreInformationDetailCommandRepository