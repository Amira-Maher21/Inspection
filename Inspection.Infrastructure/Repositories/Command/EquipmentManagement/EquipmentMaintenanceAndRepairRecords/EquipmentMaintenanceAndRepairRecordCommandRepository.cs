using Inspection.Application.Contracts.Dto.EquipmentManagement.EquipmentMaintenanceAndRepairRecords;
using Inspection.Application.Contracts.Repositories.Command.EquipmentManagement.EquipmentMaintenanceAndRepairRecords;
using Inspection.Domain.Models.EquipmentManagement.EquipmentMaintenanceAndRepairRecords;
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

namespace Inspection.Infrastructure.Repositories.Command.EquipmentManagement.EquipmentMaintenanceAndRepairRecords
{
    
 
    public class EquipmentMaintenanceAndRepairRecordCommandRepository : CommandRepositoryBase<EquipmentMaintenanceAndRepairRecord>, IEquipmentMaintenanceAndRepairRecordCommandRepository
    {
        public EquipmentMaintenanceAndRepairRecordCommandRepository(DbContext context, ITenantResolver tenantResolver, IExceptionManager exceptionManager) : base(context, tenantResolver, exceptionManager)
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
                    ErrorMessage = "EquipmentMaintenanceAndRepairRecord Not Found"
                };
                var listOfErrors = new List<ReturnBaseError>() { error };
                return ReturnBase.Fail(listOfErrors);
            }
            _dbSet.Remove(entity);
            return ReturnBase.Success();
        }


        public async Task<ReturnBase<CreateEquipmentMaintenanceAndRepairRecordDto>> InsertAsync(EquipmentMaintenanceAndRepairRecord input)
        {
            throw new NotImplementedException();
        }

        public Task<ReturnBase<bool>> DeleteAsync(long id)
        {
            throw new NotImplementedException();
        }

        public Task<ReturnBase<EquipmentMaintenanceAndRepairRecordDto>> GetAsync(long id)
        {
            throw new NotImplementedException();
        }

        public Task<ReturnBase<List<EquipmentMaintenanceAndRepairRecordDto>>> GetListAsync()
        {
            throw new NotImplementedException();
        }


        public Task<ReturnBase<EquipmentMaintenanceAndRepairRecordDto>> UpdateAsync(long id, UpdateEquipmentMaintenanceAndRepairRecordDto input)
        {
            throw new NotImplementedException();
        }
    }
}
//EquipmentMaintenanceAndRepairRecordCommandRepository
