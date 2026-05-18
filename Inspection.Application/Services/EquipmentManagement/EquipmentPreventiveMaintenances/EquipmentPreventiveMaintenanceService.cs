using AutoMapper;
using Inspection.Application.Contracts.Dto.EquipmentManagement.EquipmentPreventiveMaintenances;
using Inspection.Application.Contracts.Managers;
using Inspection.Application.Contracts.Repositories.Command.EquipmentManagement.EquipmentPreventiveMaintenances;
using Inspection.Application.Contracts.Services.EquipmentManagement.EquipmentPreventiveMaintenances;
using Inspection.Application.Contracts.UnitOfWork;
using Inspection.Application.Services.ServicesBase;
using Inspection.Domain.Models.EquipmentManagement.EquipmentPreventiveMaintenances;
using NDS.Shared.Application.DataQuery;
using NDS.Shared.Application.Multitenant;
using NDS.Shared.Kernel.BaseReturnTypes;
using NDS.Shared.Kernel.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inspection.Application.Services.EquipmentManagement.EquipmentPreventiveMaintenances
{
 


    public class EquipmentPreventiveMaintenanceService : AccountsServiceBase, IEquipmentPreventiveMaintenanceService
    {
        private readonly ITenantResolver tenantResolver;

        public EquipmentPreventiveMaintenanceService(IAccountUnitOfWork accountUoW, IAccountsQueriesManager queriesManager, IMapper mapper, IExceptionManager exceptionManager, ITenantResolver tenantResolver) : base(accountUoW, queriesManager, mapper, exceptionManager)
        {
            this.tenantResolver = tenantResolver;
        }
        public async Task<List<EquipmentPreventiveMaintenanceDtoByInclude>> GetListAsync()
        {

            var list = await _queriesManager.EquipmentPreventiveMaintenanceQueryRepository.GetAllAsync();
            return _mapper.Map<List<EquipmentPreventiveMaintenanceDtoByInclude>>(list.Result);
        }
        public async Task<ReturnBase<UpdateEquipmentPreventiveMaintenanceDto>> InsertEquipmentPreventiveMaintenanceAsync(CreateEquipmentPreventiveMaintenanceDto insertDto)
        {
            try
            {
                var entity = _mapper.Map<EquipmentPreventiveMaintenance>(insertDto);
                var TenantName = tenantResolver.GetTenantName();
                entity.Tenant_ID = TenantName;
                var insertResult = await _commands.InsertAsync(entity);
                if (!insertResult.Succeeded)
                {
                    return ReturnBase<UpdateEquipmentPreventiveMaintenanceDto>.Fail(insertResult.Errors);
                }

                var saveResult = await _accountUoW.SaveAsync();
                if (!saveResult.Succeeded)
                {
                    return ReturnBase<UpdateEquipmentPreventiveMaintenanceDto>.Fail(saveResult.Errors);
                }

                var resultDto = _mapper.Map<UpdateEquipmentPreventiveMaintenanceDto>(entity);

                return ReturnBase<UpdateEquipmentPreventiveMaintenanceDto>.Success(resultDto);
            }
            catch (Exception ex)
            {
                return ReturnBase<UpdateEquipmentPreventiveMaintenanceDto>.Fail(ex, _exceptionManager);
            }
        }
        public async Task<ReturnBase<UpdateEquipmentPreventiveMaintenanceDto>> UpdateEquipmentPreventiveMaintenanceAsync(UpdateEquipmentPreventiveMaintenanceDto updateDto, long id)
        {
            try
            {
                var entity = await _queriesManager.EquipmentPreventiveMaintenanceQueryRepository.GetByIdAsync(id);
                if (entity is null)
                {
                    var error = new ReturnBaseError
                    {
                        ErrorCode = "404",
                        ErrorMessage = "EquipmentPreventiveMaintenance Not Found"
                    };
                    var listOfErrors = new List<ReturnBaseError>() { error };
                    return ReturnBase<UpdateEquipmentPreventiveMaintenanceDto>.Fail(listOfErrors);
                }

                //if (updateDto.ServiceTypeId is 0)
                //    entity.ServiceTypeId = updateDto.ServiceTypeId;

                //if (updateDto.Notes is not null)
                //    entity.Notes = updateDto.Notes;
                entity = _mapper.Map<EquipmentPreventiveMaintenance>(updateDto);
                var updateResult = await _commands.UpdateAsync(entity);

                if (!updateResult.Succeeded)
                    return ReturnBase<UpdateEquipmentPreventiveMaintenanceDto>.Fail(updateResult.Errors);

                var saveResult = await _accountUoW.SaveAsync();

                if (!saveResult.Succeeded)
                    return ReturnBase<UpdateEquipmentPreventiveMaintenanceDto>.Fail(saveResult.Errors);

                var mappedResult = _mapper.Map<UpdateEquipmentPreventiveMaintenanceDto>(entity);

                return ReturnBase<UpdateEquipmentPreventiveMaintenanceDto>.Success(mappedResult);

            }
            catch (Exception ex)
            {
                return ReturnBase<UpdateEquipmentPreventiveMaintenanceDto>.Fail(ex, _exceptionManager);
            }
        }
        public async Task<ReturnBase<UpdateEquipmentPreventiveMaintenanceDto>> DeleteEquipmentPreventiveMaintenanceAsync(long id)
        {
            try
            {
                var entity = await _queriesManager.EquipmentPreventiveMaintenanceQueryRepository.GetByIdAsync(id);
                if (entity is null)
                {
                    var error = new ReturnBaseError
                    {
                        ErrorCode = "404",
                        ErrorMessage = "EquipmentPreventiveMaintenance Not Found"
                    };
                    var listOfErrors = new List<ReturnBaseError>() { error };
                    return ReturnBase<UpdateEquipmentPreventiveMaintenanceDto>.Fail(listOfErrors);
                }

                var deleteResult = await _commands.DeleteByIdAsync(id);

                if (!deleteResult.Succeeded)
                    return ReturnBase<UpdateEquipmentPreventiveMaintenanceDto>.Fail(deleteResult.Errors);

                var saveResult = await _accountUoW.SaveAsync();

                if (!saveResult.Succeeded)
                    return ReturnBase<UpdateEquipmentPreventiveMaintenanceDto>.Fail(saveResult.Errors);

                var mappedResult = _mapper.Map<UpdateEquipmentPreventiveMaintenanceDto>(entity);

                return ReturnBase<UpdateEquipmentPreventiveMaintenanceDto>.Success(mappedResult);

            }
            catch (Exception ex)
            {
                return ReturnBase<UpdateEquipmentPreventiveMaintenanceDto>.Fail(ex, _exceptionManager);
            }
        }
        public async Task<ReturnBase<IEnumerable<EquipmentPreventiveMaintenanceDtoByInclude>>> GetEquipmentPreventiveMaintenanceListAsync(SqlQueryOptions sqlQueryOptions)
        {
            try
            {
                var getResult = await _queriesManager.EquipmentPreventiveMaintenanceQueryRepository.GetListAsync(sqlQueryOptions);
                if (!getResult.Succeeded)
                    return ReturnBase<IEnumerable<EquipmentPreventiveMaintenanceDtoByInclude>>.Fail(getResult.Errors);

                return ReturnBase<IEnumerable<EquipmentPreventiveMaintenanceDtoByInclude>>.Success(getResult.Result);
            }
            catch (Exception ex)
            {
                return ReturnBase<IEnumerable<EquipmentPreventiveMaintenanceDtoByInclude>>.Fail(ex, _exceptionManager);
            }
        }
        public async Task<ReturnBase<EquipmentPreventiveMaintenanceDto>> GetEquipmentPreventiveMaintenanceByIdAsync(long id)
        {
            try
            {
                var entity = await _queriesManager.EquipmentPreventiveMaintenanceQueryRepository.GetByIdAsync(id);
                if (entity is null)
                {
                    var error = new ReturnBaseError
                    {
                        ErrorCode = "404",
                        ErrorMessage = "EquipmentPreventiveMaintenance Not Found"
                    };
                    var listOfErrors = new List<ReturnBaseError>() { error };
                    return ReturnBase<EquipmentPreventiveMaintenanceDto>.Fail(listOfErrors);
                }

                var mappedResult = _mapper.Map<EquipmentPreventiveMaintenanceDto>(entity);

                return ReturnBase<EquipmentPreventiveMaintenanceDto>.Success(mappedResult);
            }
            catch (Exception ex)
            {
                return ReturnBase<EquipmentPreventiveMaintenanceDto>.Fail(ex, _exceptionManager);
            }
        }
        public async Task<ReturnBase<IEnumerable<EquipmentPreventiveMaintenanceDtoByInclude>>> GetEquipmentPreventiveMaintenanceListByIncludeAsync(SqlQueryOptions sqlQueryOptions)
        {
            try
            {
                var getResult = await _queriesManager.EquipmentPreventiveMaintenanceQueryRepository.GetListIncludeNameAsync(sqlQueryOptions);
                if (!getResult.Succeeded)
                    return ReturnBase<IEnumerable<EquipmentPreventiveMaintenanceDtoByInclude>>.Fail(getResult.Errors);

                return ReturnBase<IEnumerable<EquipmentPreventiveMaintenanceDtoByInclude>>.Success(_mapper.Map<IEnumerable<EquipmentPreventiveMaintenanceDtoByInclude>>(getResult.Result));
            }
            catch (Exception ex)
            {
                return ReturnBase<IEnumerable<EquipmentPreventiveMaintenanceDtoByInclude>>.Fail(ex, _exceptionManager);
            }

        }
        //public async Task<ReturnBase<IEnumerable<EquipmentPreventiveMaintenanceDtoLookUpForNames>>> GetLookUpEquipmentPreventiveMaintenanceForNamesAsync(SqlQueryOptions queryOptions)
        //{
        //    var result = await this._queriesManager.EquipmentPreventiveMaintenances.GetLookUpEquipmentPreventiveMaintenanceForNamesAsync(queryOptions);

        //    var mappedResult = _mapper.Map<IEnumerable<EquipmentPreventiveMaintenanceDtoLookUpForNames>>(result.Result);

        //    return ReturnBase<IEnumerable<EquipmentPreventiveMaintenanceDtoLookUpForNames>>.Success(mappedResult);

        //}

        private IEquipmentPreventiveMaintenanceCommandRepository _commands
        {
            get { return _accountUoW.EquipmentPreventiveMaintenanceCommandRepository; }
        }


    }
}

