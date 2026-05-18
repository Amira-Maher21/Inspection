using AutoMapper;
using Inspection.Application.Contracts.Dto.EquipmentManagement.EquipmentMaintenanceAndRepairRecords;
using Inspection.Application.Contracts.Managers;
using Inspection.Application.Contracts.Repositories.Command.EquipmentManagement.EquipmentMaintenanceAndRepairRecords;
using Inspection.Application.Contracts.Services.EquipmentManagement.EquipmentMaintenanceAndRepairRecords;
using Inspection.Application.Contracts.UnitOfWork;
using Inspection.Application.Services.ServicesBase;
using Inspection.Domain.Models.EquipmentManagement.EquipmentMaintenanceAndRepairRecords;
using Inspection.Infrastructure.Repositories.Command.EquipmentManagement.EquipmentMaintenanceAndRepairRecords;
using NDS.Shared.Application.DataQuery;
using NDS.Shared.Application.Multitenant;
using NDS.Shared.Kernel.BaseReturnTypes;
using NDS.Shared.Kernel.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inspection.Application.Services.EquipmentManagement.EquipmentMaintenanceAndRepairRecords
{
   

    public class EquipmentMaintenanceAndRepairRecordService : AccountsServiceBase, IEquipmentMaintenanceAndRepairRecordService
    {
        private readonly ITenantResolver tenantResolver;

        public EquipmentMaintenanceAndRepairRecordService(IAccountUnitOfWork accountUoW, IAccountsQueriesManager queriesManager, IMapper mapper, IExceptionManager exceptionManager, ITenantResolver tenantResolver) : base(accountUoW, queriesManager, mapper, exceptionManager)
        {
            this.tenantResolver = tenantResolver;
        }
        public async Task<List<EquipmentMaintenanceAndRepairRecordDtoByInclude>> GetListAsync()
        {

            var list = await _queriesManager.EquipmentMaintenanceAndRepairRecordQueryRepository.GetAllAsync();
            return _mapper.Map<List<EquipmentMaintenanceAndRepairRecordDtoByInclude>>(list.Result);
        }
        public async Task<ReturnBase<UpdateEquipmentMaintenanceAndRepairRecordDto>> InsertEquipmentMaintenanceAndRepairRecordAsync(CreateEquipmentMaintenanceAndRepairRecordDto insertDto)
        {
            try
            {
                var entity = _mapper.Map<EquipmentMaintenanceAndRepairRecord>(insertDto);
                var TenantName = tenantResolver.GetTenantName();
                entity.Tenant_ID = TenantName;
                var insertResult = await _commands.InsertAsync(entity);
                if (!insertResult.Succeeded)
                {
                    return ReturnBase<UpdateEquipmentMaintenanceAndRepairRecordDto>.Fail(insertResult.Errors);
                }

                var saveResult = await _accountUoW.SaveAsync();
                if (!saveResult.Succeeded)
                {
                    return ReturnBase<UpdateEquipmentMaintenanceAndRepairRecordDto>.Fail(saveResult.Errors);
                }

                var resultDto = _mapper.Map<UpdateEquipmentMaintenanceAndRepairRecordDto>(entity);

                return ReturnBase<UpdateEquipmentMaintenanceAndRepairRecordDto>.Success(resultDto);
            }
            catch (Exception ex)
            {
                return ReturnBase<UpdateEquipmentMaintenanceAndRepairRecordDto>.Fail(ex, _exceptionManager);
            }
        }
        public async Task<ReturnBase<UpdateEquipmentMaintenanceAndRepairRecordDto>> UpdateEquipmentMaintenanceAndRepairRecordAsync(UpdateEquipmentMaintenanceAndRepairRecordDto updateDto, long id)
        {
            try
            {
                var entity = await _queriesManager.EquipmentMaintenanceAndRepairRecordQueryRepository.GetByIdAsync(id);
                if (entity is null)
                {
                    var error = new ReturnBaseError
                    {
                        ErrorCode = "404",
                        ErrorMessage = "EquipmentMaintenanceAndRepairRecord Not Found"
                    };
                    var listOfErrors = new List<ReturnBaseError>() { error };
                    return ReturnBase<UpdateEquipmentMaintenanceAndRepairRecordDto>.Fail(listOfErrors);
                }

                //if (updateDto.ServiceTypeId is 0)
                //    entity.ServiceTypeId = updateDto.ServiceTypeId;

                //if (updateDto.Notes is not null)
                //    entity.Notes = updateDto.Notes;
                entity = _mapper.Map<EquipmentMaintenanceAndRepairRecord>(updateDto);
                var updateResult = await _commands.UpdateAsync(entity);

                if (!updateResult.Succeeded)
                    return ReturnBase<UpdateEquipmentMaintenanceAndRepairRecordDto>.Fail(updateResult.Errors);

                var saveResult = await _accountUoW.SaveAsync();

                if (!saveResult.Succeeded)
                    return ReturnBase<UpdateEquipmentMaintenanceAndRepairRecordDto>.Fail(saveResult.Errors);

                var mappedResult = _mapper.Map<UpdateEquipmentMaintenanceAndRepairRecordDto>(entity);

                return ReturnBase<UpdateEquipmentMaintenanceAndRepairRecordDto>.Success(mappedResult);

            }
            catch (Exception ex)
            {
                return ReturnBase<UpdateEquipmentMaintenanceAndRepairRecordDto>.Fail(ex, _exceptionManager);
            }
        }
        public async Task<ReturnBase<UpdateEquipmentMaintenanceAndRepairRecordDto>> DeleteEquipmentMaintenanceAndRepairRecordAsync(long id)
        {
            try
            {
                var entity = await _queriesManager.EquipmentMaintenanceAndRepairRecordQueryRepository.GetByIdAsync(id);
                if (entity is null)
                {
                    var error = new ReturnBaseError
                    {
                        ErrorCode = "404",
                        ErrorMessage = "EquipmentMaintenanceAndRepairRecord Not Found"
                    };
                    var listOfErrors = new List<ReturnBaseError>() { error };
                    return ReturnBase<UpdateEquipmentMaintenanceAndRepairRecordDto>.Fail(listOfErrors);
                }

                var deleteResult = await _commands.DeleteByIdAsync(id);

                if (!deleteResult.Succeeded)
                    return ReturnBase<UpdateEquipmentMaintenanceAndRepairRecordDto>.Fail(deleteResult.Errors);

                var saveResult = await _accountUoW.SaveAsync();

                if (!saveResult.Succeeded)
                    return ReturnBase<UpdateEquipmentMaintenanceAndRepairRecordDto>.Fail(saveResult.Errors);

                var mappedResult = _mapper.Map<UpdateEquipmentMaintenanceAndRepairRecordDto>(entity);

                return ReturnBase<UpdateEquipmentMaintenanceAndRepairRecordDto>.Success(mappedResult);

            }
            catch (Exception ex)
            {
                return ReturnBase<UpdateEquipmentMaintenanceAndRepairRecordDto>.Fail(ex, _exceptionManager);
            }
        }
        public async Task<ReturnBase<IEnumerable<EquipmentMaintenanceAndRepairRecordDtoByInclude>>> GetEquipmentMaintenanceAndRepairRecordListAsync(SqlQueryOptions sqlQueryOptions)
        {
            try
            {
                var getResult = await _queriesManager.EquipmentMaintenanceAndRepairRecordQueryRepository.GetListAsync(sqlQueryOptions);
                if (!getResult.Succeeded)
                    return ReturnBase<IEnumerable<EquipmentMaintenanceAndRepairRecordDtoByInclude>>.Fail(getResult.Errors);

                return ReturnBase<IEnumerable<EquipmentMaintenanceAndRepairRecordDtoByInclude>>.Success(getResult.Result);
            }
            catch (Exception ex)
            {
                return ReturnBase<IEnumerable<EquipmentMaintenanceAndRepairRecordDtoByInclude>>.Fail(ex, _exceptionManager);
            }
        }
        public async Task<ReturnBase<EquipmentMaintenanceAndRepairRecordDto>> GetEquipmentMaintenanceAndRepairRecordByIdAsync(long id)
        {
            try
            {
                var entity = await _queriesManager.EquipmentMaintenanceAndRepairRecordQueryRepository.GetByIdAsync(id);
                if (entity is null)
                {
                    var error = new ReturnBaseError
                    {
                        ErrorCode = "404",
                        ErrorMessage = "EquipmentMaintenanceAndRepairRecord Not Found"
                    };
                    var listOfErrors = new List<ReturnBaseError>() { error };
                    return ReturnBase<EquipmentMaintenanceAndRepairRecordDto>.Fail(listOfErrors);
                }

                var mappedResult = _mapper.Map<EquipmentMaintenanceAndRepairRecordDto>(entity);

                return ReturnBase<EquipmentMaintenanceAndRepairRecordDto>.Success(mappedResult);
            }
            catch (Exception ex)
            {
                return ReturnBase<EquipmentMaintenanceAndRepairRecordDto>.Fail(ex, _exceptionManager);
            }
        }
        public async Task<ReturnBase<IEnumerable<EquipmentMaintenanceAndRepairRecordDtoByInclude>>> GetEquipmentMaintenanceAndRepairRecordListByIncludeAsync(SqlQueryOptions sqlQueryOptions)
        {
            try
            {
                var getResult = await _queriesManager.EquipmentMaintenanceAndRepairRecordQueryRepository.GetListIncludeNameAsync(sqlQueryOptions);
                if (!getResult.Succeeded)
                    return ReturnBase<IEnumerable<EquipmentMaintenanceAndRepairRecordDtoByInclude>>.Fail(getResult.Errors);

                return ReturnBase<IEnumerable<EquipmentMaintenanceAndRepairRecordDtoByInclude>>.Success(_mapper.Map<IEnumerable<EquipmentMaintenanceAndRepairRecordDtoByInclude>>(getResult.Result));
            }
            catch (Exception ex)
            {
                return ReturnBase<IEnumerable<EquipmentMaintenanceAndRepairRecordDtoByInclude>>.Fail(ex, _exceptionManager);
            }

        }
        //public async Task<ReturnBase<IEnumerable<EquipmentMaintenanceAndRepairRecordDtoLookUpForNames>>> GetLookUpEquipmentMaintenanceAndRepairRecordForNamesAsync(SqlQueryOptions queryOptions)
        //{
        //    var result = await this._queriesManager.EquipmentMaintenanceAndRepairRecords.GetLookUpEquipmentMaintenanceAndRepairRecordForNamesAsync(queryOptions);

        //    var mappedResult = _mapper.Map<IEnumerable<EquipmentMaintenanceAndRepairRecordDtoLookUpForNames>>(result.Result);

        //    return ReturnBase<IEnumerable<EquipmentMaintenanceAndRepairRecordDtoLookUpForNames>>.Success(mappedResult);

        //}

        private IEquipmentMaintenanceAndRepairRecordCommandRepository _commands
        {
            get { return _accountUoW.EquipmentMaintenanceAndRepairRecordCommandRepository; }
        }


    }
}

