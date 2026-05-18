using Inspection.Application.Contracts.Dto.EquipmentManagement.EquipmentPreventiveMaintenances;
using Inspection.Application.Contracts.Repositories.Command.EquipmentManagement.EquipmentPreventiveMaintenances;
using Inspection.Domain.Models.EquipmentManagement.EquipmentPreventiveMaintenances;
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

namespace Inspection.Infrastructure.Repositories.Command.EquipmentManagement.EquipmentPreventiveMaintenances
{
 

    public class EquipmentPreventiveMaintenanceCommandRepository : CommandRepositoryBase<EquipmentPreventiveMaintenance>, IEquipmentPreventiveMaintenanceCommandRepository
    {
        public EquipmentPreventiveMaintenanceCommandRepository(DbContext context, ITenantResolver tenantResolver, IExceptionManager exceptionManager) : base(context, tenantResolver, exceptionManager)
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
                    ErrorMessage = "EquipmentPreventiveMaintenance Not Found"
                };
                var listOfErrors = new List<ReturnBaseError>() { error };
                return ReturnBase.Fail(listOfErrors);
            }
            _dbSet.Remove(entity);
            return ReturnBase.Success();
        }


        public async Task<ReturnBase<CreateEquipmentPreventiveMaintenanceDto>> InsertAsync(EquipmentPreventiveMaintenance input)
        {
            throw new NotImplementedException();
        }

        public Task<ReturnBase<bool>> DeleteAsync(long id)
        {
            throw new NotImplementedException();
        }

        public Task<ReturnBase<EquipmentPreventiveMaintenanceDto>> GetAsync(long id)
        {
            throw new NotImplementedException();
        }

        public Task<ReturnBase<List<EquipmentPreventiveMaintenanceDto>>> GetListAsync()
        {
            throw new NotImplementedException();
        }


        public Task<ReturnBase<EquipmentPreventiveMaintenanceDto>> UpdateAsync(long id, UpdateEquipmentPreventiveMaintenanceDto input)
        {
            throw new NotImplementedException();
        }
    }
}
//EquipmentPreventiveMaintenanceCommandRepository