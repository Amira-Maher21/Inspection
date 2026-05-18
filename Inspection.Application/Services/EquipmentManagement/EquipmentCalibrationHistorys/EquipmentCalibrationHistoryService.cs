using AutoMapper;
using Inspection.Application.Contracts.Dto.EquipmentManagement.EquipmentCalibrationHistorys;
using Inspection.Application.Contracts.Managers;
using Inspection.Application.Contracts.Repositories.Command.EquipmentManagement.EquipmentCalibrationHistorys;
using Inspection.Application.Contracts.Services.EquipmentManagement.EquipmentCalibrationHistorys;
using Inspection.Application.Contracts.UnitOfWork;
using Inspection.Application.Services.ServicesBase;
using Inspection.Domain.Models.EquipmentManagement.EquipmentCalibrationHistorys;
using NDS.Shared.Application.DataQuery;
using NDS.Shared.Application.Multitenant;
using NDS.Shared.Kernel.BaseReturnTypes;
using NDS.Shared.Kernel.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inspection.Application.Services.EquipmentManagement.EquipmentCalibrationHistorys
{
  

    public class EquipmentCalibrationHistoryService : AccountsServiceBase, IEquipmentCalibrationHistoryService
    {
        private readonly ITenantResolver tenantResolver;

        public EquipmentCalibrationHistoryService(IAccountUnitOfWork accountUoW, IAccountsQueriesManager queriesManager, IMapper mapper, IExceptionManager exceptionManager, ITenantResolver tenantResolver) : base(accountUoW, queriesManager, mapper, exceptionManager)
        {
            this.tenantResolver = tenantResolver;
        }
        public async Task<List<EquipmentCalibrationHistoryDtoByInclude>> GetListAsync()
        {

            var list = await _queriesManager.EquipmentCalibrationHistoryQueryRepository.GetAllAsync();
            return _mapper.Map<List<EquipmentCalibrationHistoryDtoByInclude>>(list.Result);
        }
        public async Task<ReturnBase<UpdateEquipmentCalibrationHistoryDto>> InsertEquipmentCalibrationHistoryAsync(CreateEquipmentCalibrationHistoryDto insertDto)
        {
            try
            {
                var entity = _mapper.Map<EquipmentCalibrationHistory>(insertDto);
                var TenantName = tenantResolver.GetTenantName();
                entity.Tenant_ID = TenantName;
                var insertResult = await _commands.InsertAsync(entity);
                if (!insertResult.Succeeded)
                {
                    return ReturnBase<UpdateEquipmentCalibrationHistoryDto>.Fail(insertResult.Errors);
                }

                var saveResult = await _accountUoW.SaveAsync();
                if (!saveResult.Succeeded)
                {
                    return ReturnBase<UpdateEquipmentCalibrationHistoryDto>.Fail(saveResult.Errors);
                }

                var resultDto = _mapper.Map<UpdateEquipmentCalibrationHistoryDto>(entity);

                return ReturnBase<UpdateEquipmentCalibrationHistoryDto>.Success(resultDto);
            }
            catch (Exception ex)
            {
                return ReturnBase<UpdateEquipmentCalibrationHistoryDto>.Fail(ex, _exceptionManager);
            }
        }
        public async Task<ReturnBase<UpdateEquipmentCalibrationHistoryDto>> UpdateEquipmentCalibrationHistoryAsync(UpdateEquipmentCalibrationHistoryDto updateDto, long id)
        {
            try
            {
                var entity = await _queriesManager.EquipmentCalibrationHistoryQueryRepository.GetByIdAsync(id);
                if (entity is null)
                {
                    var error = new ReturnBaseError
                    {
                        ErrorCode = "404",
                        ErrorMessage = "EquipmentCalibrationHistory Not Found"
                    };
                    var listOfErrors = new List<ReturnBaseError>() { error };
                    return ReturnBase<UpdateEquipmentCalibrationHistoryDto>.Fail(listOfErrors);
                }

                //if (updateDto.ServiceTypeId is 0)
                //    entity.ServiceTypeId = updateDto.ServiceTypeId;

                //if (updateDto.Notes is not null)
                //    entity.Notes = updateDto.Notes;
                entity = _mapper.Map<EquipmentCalibrationHistory>(updateDto);
                var updateResult = await _commands.UpdateAsync(entity);

                if (!updateResult.Succeeded)
                    return ReturnBase<UpdateEquipmentCalibrationHistoryDto>.Fail(updateResult.Errors);

                var saveResult = await _accountUoW.SaveAsync();

                if (!saveResult.Succeeded)
                    return ReturnBase<UpdateEquipmentCalibrationHistoryDto>.Fail(saveResult.Errors);

                var mappedResult = _mapper.Map<UpdateEquipmentCalibrationHistoryDto>(entity);

                return ReturnBase<UpdateEquipmentCalibrationHistoryDto>.Success(mappedResult);

            }
            catch (Exception ex)
            {
                return ReturnBase<UpdateEquipmentCalibrationHistoryDto>.Fail(ex, _exceptionManager);
            }
        }
        public async Task<ReturnBase<UpdateEquipmentCalibrationHistoryDto>> DeleteEquipmentCalibrationHistoryAsync(long id)
        {
            try
            {
                var entity = await _queriesManager.EquipmentCalibrationHistoryQueryRepository.GetByIdAsync(id);
                if (entity is null)
                {
                    var error = new ReturnBaseError
                    {
                        ErrorCode = "404",
                        ErrorMessage = "EquipmentCalibrationHistory Not Found"
                    };
                    var listOfErrors = new List<ReturnBaseError>() { error };
                    return ReturnBase<UpdateEquipmentCalibrationHistoryDto>.Fail(listOfErrors);
                }

                var deleteResult = await _commands.DeleteByIdAsync(id);

                if (!deleteResult.Succeeded)
                    return ReturnBase<UpdateEquipmentCalibrationHistoryDto>.Fail(deleteResult.Errors);

                var saveResult = await _accountUoW.SaveAsync();

                if (!saveResult.Succeeded)
                    return ReturnBase<UpdateEquipmentCalibrationHistoryDto>.Fail(saveResult.Errors);

                var mappedResult = _mapper.Map<UpdateEquipmentCalibrationHistoryDto>(entity);

                return ReturnBase<UpdateEquipmentCalibrationHistoryDto>.Success(mappedResult);

            }
            catch (Exception ex)
            {
                return ReturnBase<UpdateEquipmentCalibrationHistoryDto>.Fail(ex, _exceptionManager);
            }
        }
        public async Task<ReturnBase<IEnumerable<EquipmentCalibrationHistoryDtoByInclude>>> GetEquipmentCalibrationHistoryListAsync(SqlQueryOptions sqlQueryOptions)
        {
            try
            {
                var getResult = await _queriesManager.EquipmentCalibrationHistoryQueryRepository.GetListAsync(sqlQueryOptions);
                if (!getResult.Succeeded)
                    return ReturnBase<IEnumerable<EquipmentCalibrationHistoryDtoByInclude>>.Fail(getResult.Errors);

                return ReturnBase<IEnumerable<EquipmentCalibrationHistoryDtoByInclude>>.Success(getResult.Result);
            }
            catch (Exception ex)
            {
                return ReturnBase<IEnumerable<EquipmentCalibrationHistoryDtoByInclude>>.Fail(ex, _exceptionManager);
            }
        }
        public async Task<ReturnBase<EquipmentCalibrationHistoryDto>> GetEquipmentCalibrationHistoryByIdAsync(long id)
        {
            try
            {
                var entity = await _queriesManager.EquipmentCalibrationHistoryQueryRepository.GetByIdAsync(id);
                if (entity is null)
                {
                    var error = new ReturnBaseError
                    {
                        ErrorCode = "404",
                        ErrorMessage = "EquipmentCalibrationHistory Not Found"
                    };
                    var listOfErrors = new List<ReturnBaseError>() { error };
                    return ReturnBase<EquipmentCalibrationHistoryDto>.Fail(listOfErrors);
                }

                var mappedResult = _mapper.Map<EquipmentCalibrationHistoryDto>(entity);

                return ReturnBase<EquipmentCalibrationHistoryDto>.Success(mappedResult);
            }
            catch (Exception ex)
            {
                return ReturnBase<EquipmentCalibrationHistoryDto>.Fail(ex, _exceptionManager);
            }
        }
        public async Task<ReturnBase<IEnumerable<EquipmentCalibrationHistoryDtoByInclude>>> GetEquipmentCalibrationHistoryListByIncludeAsync(SqlQueryOptions sqlQueryOptions)
        {
            try
            {
                var getResult = await _queriesManager.EquipmentCalibrationHistoryQueryRepository.GetListIncludeNameAsync(sqlQueryOptions);
                if (!getResult.Succeeded)
                    return ReturnBase<IEnumerable<EquipmentCalibrationHistoryDtoByInclude>>.Fail(getResult.Errors);

                return ReturnBase<IEnumerable<EquipmentCalibrationHistoryDtoByInclude>>.Success(_mapper.Map<IEnumerable<EquipmentCalibrationHistoryDtoByInclude>>(getResult.Result));
            }
            catch (Exception ex)
            {
                return ReturnBase<IEnumerable<EquipmentCalibrationHistoryDtoByInclude>>.Fail(ex, _exceptionManager);
            }

        }
        //public async Task<ReturnBase<IEnumerable<EquipmentCalibrationHistoryDtoLookUpForNames>>> GetLookUpEquipmentCalibrationHistoryForNamesAsync(SqlQueryOptions queryOptions)
        //{
        //    var result = await this._queriesManager.EquipmentCalibrationHistorys.GetLookUpEquipmentCalibrationHistoryForNamesAsync(queryOptions);

        //    var mappedResult = _mapper.Map<IEnumerable<EquipmentCalibrationHistoryDtoLookUpForNames>>(result.Result);

        //    return ReturnBase<IEnumerable<EquipmentCalibrationHistoryDtoLookUpForNames>>.Success(mappedResult);

        //}

        private IEquipmentCalibrationHistoryCommandRepository _commands
        {
            get { return _accountUoW.EquipmentCalibrationHistoryCommandRepository; }
        }


    }
}

