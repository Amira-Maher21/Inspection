using Inspection.Application.Contracts.Dto.EquipmentManagement.EquipmentCalibrationHistorys;
using Inspection.Application.Contracts.Repositories.Command.EquipmentManagement.EquipmentCalibrationHistorys;
using Inspection.Domain.Models.EquipmentManagement.EquipmentCalibrationHistorys;
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

namespace Inspection.Infrastructure.Repositories.Command.EquipmentManagement.EquipmentCalibrationHistorys
{
  

 

    public class EquipmentCalibrationHistoryCommandRepository : CommandRepositoryBase<EquipmentCalibrationHistory>, IEquipmentCalibrationHistoryCommandRepository
    {
        public EquipmentCalibrationHistoryCommandRepository(DbContext context, ITenantResolver tenantResolver, IExceptionManager exceptionManager) : base(context, tenantResolver, exceptionManager)
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
                    ErrorMessage = "EquipmentCalibrationHistory Not Found"
                };
                var listOfErrors = new List<ReturnBaseError>() { error };
                return ReturnBase.Fail(listOfErrors);
            }
            _dbSet.Remove(entity);
            return ReturnBase.Success();
        }


        public async Task<ReturnBase<CreateEquipmentCalibrationHistoryDto>> InsertAsync(EquipmentCalibrationHistory input)
        {
            throw new NotImplementedException();
        }

        public Task<ReturnBase<bool>> DeleteAsync(long id)
        {
            throw new NotImplementedException();
        }

        public Task<ReturnBase<EquipmentCalibrationHistoryDto>> GetAsync(long id)
        {
            throw new NotImplementedException();
        }

        public Task<ReturnBase<List<EquipmentCalibrationHistoryDto>>> GetListAsync()
        {
            throw new NotImplementedException();
        }


        public Task<ReturnBase<EquipmentCalibrationHistoryDto>> UpdateAsync(long id, UpdateEquipmentCalibrationHistoryDto input)
        {
            throw new NotImplementedException();
        }
    }
}
//EquipmentCalibrationHistoryCommandRepository
