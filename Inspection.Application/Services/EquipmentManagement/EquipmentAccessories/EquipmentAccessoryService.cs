using AutoMapper;
using Inspection.Application.Contracts.Dto.EquipmentManagement.EquipmentAccessories;
using Inspection.Application.Contracts.Managers;
using Inspection.Application.Contracts.Repositories.Command.EquipmentManagement.EquipmentAccessories;
using Inspection.Application.Contracts.Services.EquipmentManagement.EquipmentAccessories;
using Inspection.Application.Contracts.UnitOfWork;
using Inspection.Application.Services.ServicesBase;
using Inspection.Domain.Models.EquipmentManagement.EquipmentAccessories;
using NDS.Shared.Application.DataQuery;
using NDS.Shared.Application.Multitenant;
using NDS.Shared.Kernel.BaseReturnTypes;
using NDS.Shared.Kernel.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inspection.Application.Services.EquipmentManagement.EquipmentAccessories
{
  
    public class EquipmentAccessoryService : AccountsServiceBase, IEquipmentAccessoriesService
    {
        private readonly ITenantResolver tenantResolver;

        public EquipmentAccessoryService(IAccountUnitOfWork accountUoW, IAccountsQueriesManager queriesManager, IMapper mapper, IExceptionManager exceptionManager, ITenantResolver tenantResolver) : base(accountUoW, queriesManager, mapper, exceptionManager)
        {
            this.tenantResolver = tenantResolver;
        }
        public async Task<List<EquipmentAccessoryDtoByInclude>> GetListAsync()
        {

            var list = await _queriesManager.EquipmentAccessoriesQueryRepository.GetAllAsync();
            return _mapper.Map<List<EquipmentAccessoryDtoByInclude>>(list.Result);
        }
        public async Task<ReturnBase<UpdateEquipmentAccessoryDto>> InsertEquipmentAccessoryAsync(CreateEquipmentAccessoryDto insertDto)
        {
            try
            {
                var entity = _mapper.Map<EquipmentAccessory>(insertDto);
                var TenantName = tenantResolver.GetTenantName();
                entity.Tenant_ID = TenantName;
                var insertResult = await _commands.InsertAsync(entity);
                if (!insertResult.Succeeded)
                {
                    return ReturnBase<UpdateEquipmentAccessoryDto>.Fail(insertResult.Errors);
                }

                var saveResult = await _accountUoW.SaveAsync();
                if (!saveResult.Succeeded)
                {
                    return ReturnBase<UpdateEquipmentAccessoryDto>.Fail(saveResult.Errors);
                }

                var resultDto = _mapper.Map<UpdateEquipmentAccessoryDto>(entity);

                return ReturnBase<UpdateEquipmentAccessoryDto>.Success(resultDto);
            }
            catch (Exception ex)
            {
                return ReturnBase<UpdateEquipmentAccessoryDto>.Fail(ex, _exceptionManager);
            }
        }
        public async Task<ReturnBase<UpdateEquipmentAccessoryDto>> UpdateEquipmentAccessoryAsync(UpdateEquipmentAccessoryDto updateDto, long id)
        {
            try
            {
                var entity = await _queriesManager.EquipmentAccessoriesQueryRepository.GetByIdAsync(id);
                if (entity is null)
                {
                    var error = new ReturnBaseError
                    {
                        ErrorCode = "404",
                        ErrorMessage = "EquipmentAccessory Not Found"
                    };
                    var listOfErrors = new List<ReturnBaseError>() { error };
                    return ReturnBase<UpdateEquipmentAccessoryDto>.Fail(listOfErrors);
                }

                //if (updateDto.ServiceTypeId is 0)
                //    entity.ServiceTypeId = updateDto.ServiceTypeId;

                //if (updateDto.Notes is not null)
                //    entity.Notes = updateDto.Notes;
                entity = _mapper.Map<EquipmentAccessory>(updateDto);
                var updateResult = await _commands.UpdateAsync(entity);

                if (!updateResult.Succeeded)
                    return ReturnBase<UpdateEquipmentAccessoryDto>.Fail(updateResult.Errors);

                var saveResult = await _accountUoW.SaveAsync();

                if (!saveResult.Succeeded)
                    return ReturnBase<UpdateEquipmentAccessoryDto>.Fail(saveResult.Errors);

                var mappedResult = _mapper.Map<UpdateEquipmentAccessoryDto>(entity);

                return ReturnBase<UpdateEquipmentAccessoryDto>.Success(mappedResult);

            }
            catch (Exception ex)
            {
                return ReturnBase<UpdateEquipmentAccessoryDto>.Fail(ex, _exceptionManager);
            }
        }
        public async Task<ReturnBase<UpdateEquipmentAccessoryDto>> DeleteEquipmentAccessoryAsync(long id)
        {
            try
            {
                var entity = await _queriesManager.EquipmentAccessoriesQueryRepository.GetByIdAsync(id);
                if (entity is null)
                {
                    var error = new ReturnBaseError
                    {
                        ErrorCode = "404",
                        ErrorMessage = "EquipmentAccessory Not Found"
                    };
                    var listOfErrors = new List<ReturnBaseError>() { error };
                    return ReturnBase<UpdateEquipmentAccessoryDto>.Fail(listOfErrors);
                }

                var deleteResult = await _commands.DeleteByIdAsync(id);

                if (!deleteResult.Succeeded)
                    return ReturnBase<UpdateEquipmentAccessoryDto>.Fail(deleteResult.Errors);

                var saveResult = await _accountUoW.SaveAsync();

                if (!saveResult.Succeeded)
                    return ReturnBase<UpdateEquipmentAccessoryDto>.Fail(saveResult.Errors);

                var mappedResult = _mapper.Map<UpdateEquipmentAccessoryDto>(entity);

                return ReturnBase<UpdateEquipmentAccessoryDto>.Success(mappedResult);

            }
            catch (Exception ex)
            {
                return ReturnBase<UpdateEquipmentAccessoryDto>.Fail(ex, _exceptionManager);
            }
        }
        public async Task<ReturnBase<IEnumerable<EquipmentAccessoryDtoByInclude>>> GetEquipmentAccessoryListAsync(SqlQueryOptions sqlQueryOptions)
        {
            try
            {
                var getResult = await _queriesManager.EquipmentAccessoriesQueryRepository.GetListAsync(sqlQueryOptions);
                if (!getResult.Succeeded)
                    return ReturnBase<IEnumerable<EquipmentAccessoryDtoByInclude>>.Fail(getResult.Errors);

                return ReturnBase<IEnumerable<EquipmentAccessoryDtoByInclude>>.Success(getResult.Result);
            }
            catch (Exception ex)
            {
                return ReturnBase<IEnumerable<EquipmentAccessoryDtoByInclude>>.Fail(ex, _exceptionManager);
            }
        }
        public async Task<ReturnBase<EquipmentAccessoryDto>> GetEquipmentAccessoryByIdAsync(long id)
        {
            try
            {
                var entity = await _queriesManager.EquipmentAccessoriesQueryRepository.GetByIdAsync(id);
                if (entity is null)
                {
                    var error = new ReturnBaseError
                    {
                        ErrorCode = "404",
                        ErrorMessage = "EquipmentAccessory Not Found"
                    };
                    var listOfErrors = new List<ReturnBaseError>() { error };
                    return ReturnBase<EquipmentAccessoryDto>.Fail(listOfErrors);
                }

                var mappedResult = _mapper.Map<EquipmentAccessoryDto>(entity);

                return ReturnBase<EquipmentAccessoryDto>.Success(mappedResult);
            }
            catch (Exception ex)
            {
                return ReturnBase<EquipmentAccessoryDto>.Fail(ex, _exceptionManager);
            }
        }
        public async Task<ReturnBase<IEnumerable<EquipmentAccessoryDtoByInclude>>> GetEquipmentAccessoryListByIncludeAsync(SqlQueryOptions sqlQueryOptions)
        {
            try
            {
                var getResult = await _queriesManager.EquipmentAccessoriesQueryRepository.GetListIncludeNameAsync(sqlQueryOptions);
                if (!getResult.Succeeded)
                    return ReturnBase<IEnumerable<EquipmentAccessoryDtoByInclude>>.Fail(getResult.Errors);

                return ReturnBase<IEnumerable<EquipmentAccessoryDtoByInclude>>.Success(_mapper.Map<IEnumerable<EquipmentAccessoryDtoByInclude>>(getResult.Result));
            }
            catch (Exception ex)
            {
                return ReturnBase<IEnumerable<EquipmentAccessoryDtoByInclude>>.Fail(ex, _exceptionManager);
            }

        }
        //public async Task<ReturnBase<IEnumerable<EquipmentAccessoryDtoLookUpForNames>>> GetLookUpEquipmentAccessoryForNamesAsync(SqlQueryOptions queryOptions)
        //{
        //    var result = await this._queriesManager.EquipmentAccessorys.GetLookUpEquipmentAccessoryForNamesAsync(queryOptions);

        //    var mappedResult = _mapper.Map<IEnumerable<EquipmentAccessoryDtoLookUpForNames>>(result.Result);

        //    return ReturnBase<IEnumerable<EquipmentAccessoryDtoLookUpForNames>>.Success(mappedResult);

        //}

        private IEquipmentAccessoryCommandRepository _commands
        {
            get { return _accountUoW.EquipmentAccessoriesCommandRepository; }
        }


    }
}

