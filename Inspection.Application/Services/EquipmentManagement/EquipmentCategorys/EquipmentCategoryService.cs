using AutoMapper;
using Inspection.Application.Contracts.Dto.EquipmentManagement.EquipmentCategorys;
using Inspection.Application.Contracts.Managers;
using Inspection.Application.Contracts.Repositories.Command.EquipmentManagement.EquipmentCategorys;
using Inspection.Application.Contracts.Services.EquipmentManagement.EquipmentCategorys;
using Inspection.Application.Contracts.UnitOfWork;
using Inspection.Application.Services.ServicesBase;
using Inspection.Domain.Models.EquipmentManagement.EquipmentCategorys;
using NDS.Shared.Application.DataQuery;
using NDS.Shared.Application.Multitenant;
using NDS.Shared.Application.SharedModels;
using NDS.Shared.Kernel.BaseReturnTypes;
using NDS.Shared.Kernel.Exceptions;

namespace Inspection.Application.Services.EquipmentManagement.EquipmentCategorys
{

    public class EquipmentCategoryService : AccountsServiceBase, IEquipmentCategoryService
    {

        private readonly ITenantResolver _tenantResolver;
        public EquipmentCategoryService(IAccountUnitOfWork accountUoW, IAccountsQueriesManager queriesManager, IMapper mapper, IExceptionManager exceptionManager, ITenantResolver tenantResolver) : base(accountUoW, queriesManager, mapper, exceptionManager)
        {
            _tenantResolver = tenantResolver;
        }
        public async Task<List<EquipmentCategoryDtoByInclude>> GetListAsync()
        {

            var list = await _queriesManager.EquipmentCategoryQueryRepository.GetAllAsync();
            return _mapper.Map<List<EquipmentCategoryDtoByInclude>>(list.Result);
        }
        public async Task<ReturnBase<UpdateEquipmentCategoryDto>> InsertEquipmentCategoryAsync(CreateEquipmentCategoryDto insertDto)
        {
            try
            {

                var entity = _mapper.Map<EquipmentCategory>(insertDto);
                var TenantName = _tenantResolver.GetTenantName();
                entity.Tenant_ID = TenantName;
                var insertResult = await _commands.InsertAsync(entity);
                if (!insertResult.Succeeded)
                {
                    return ReturnBase<UpdateEquipmentCategoryDto>.Fail(insertResult.Errors);
                }

                var saveResult = await _accountUoW.SaveAsync();
                if (!saveResult.Succeeded)
                {
                    return ReturnBase<UpdateEquipmentCategoryDto>.Fail(saveResult.Errors);
                }

                var resultDto = _mapper.Map<UpdateEquipmentCategoryDto>(entity);

                return ReturnBase<UpdateEquipmentCategoryDto>.Success(resultDto);
            }
            catch (Exception ex)
            {
                return ReturnBase<UpdateEquipmentCategoryDto>.Fail(ex, _exceptionManager);
            }
        }
        public async Task<ReturnBase<UpdateEquipmentCategoryDto>> UpdateEquipmentCategoryAsync(UpdateEquipmentCategoryDto updateDto, long id)
        {
            try
            {
                var entity = await _queriesManager.EquipmentCategoryQueryRepository.GetByIdAsync(id);
                if (entity is null)
                {
                    var error = new ReturnBaseError
                    {
                        ErrorCode = "404",
                        ErrorMessage = "Equipment Type Not Found"
                    };
                    var listOfErrors = new List<ReturnBaseError>() { error };
                    return ReturnBase<UpdateEquipmentCategoryDto>.Fail(listOfErrors);
                }

                //if (updateDto.ServiceTypeId is 0)
                //    entity.ServiceTypeId = updateDto.ServiceTypeId;

                //if (updateDto.Notes is not null)
                //    entity.Notes = updateDto.Notes;

                _mapper.Map(updateDto, entity);
                var updateResult = await _commands.UpdateAsync(entity);

                if (!updateResult.Succeeded)
                    return ReturnBase<UpdateEquipmentCategoryDto>.Fail(updateResult.Errors);

                var saveResult = await _accountUoW.SaveAsync();

                if (!saveResult.Succeeded)
                    return ReturnBase<UpdateEquipmentCategoryDto>.Fail(saveResult.Errors);

                var mappedResult = _mapper.Map<UpdateEquipmentCategoryDto>(entity);

                return ReturnBase<UpdateEquipmentCategoryDto>.Success(mappedResult);

            }
            catch (Exception ex)
            {
                return ReturnBase<UpdateEquipmentCategoryDto>.Fail(ex, _exceptionManager);
            }
        }
        public async Task<ReturnBase<bool>> DeleteEquipmentCategoryAsync(long id)
        {
            try
            {
                var keys = new EntityKeyValueDictionary();
                keys.Add(new KeyValuePair<string, object>("Id", id));

                var deleteResult = await _accountUoW.EquipmentCategoryCommandRepository.DeleteAsync(keys);
                if (!deleteResult.Succeeded)
                {
                    return ReturnBase<bool>.Fail(deleteResult.Errors);
                }

                var saveResult = await _accountUoW.SaveAsync();
                if (!saveResult.Succeeded)
                {
                    return ReturnBase<bool>.Fail(saveResult.Errors);
                }

                return ReturnBase<bool>.Success(true);
            }
            catch (Exception ex)
            {
                return ReturnBase<bool>.Fail(ex, _exceptionManager);
            }
        }
        public async Task<ReturnBase<IEnumerable<EquipmentCategoryDtoByInclude>>> GetEquipmentCategoryListAsync(SqlQueryOptions sqlQueryOptions)
        {
            try
            {
                var getResult = await _queriesManager.EquipmentCategoryQueryRepository.GetListAsync(sqlQueryOptions);
                if (!getResult.Succeeded)
                    return ReturnBase<IEnumerable<EquipmentCategoryDtoByInclude>>.Fail(getResult.Errors);

                return ReturnBase<IEnumerable<EquipmentCategoryDtoByInclude>>.Success(getResult.Result);
            }
            catch (Exception ex)
            {
                return ReturnBase<IEnumerable<EquipmentCategoryDtoByInclude>>.Fail(ex, _exceptionManager);
            }
        }
        public async Task<ReturnBase<EquipmentCategoryDto>> GetEquipmentCategoryByIdAsync(long id)
        {
            try
            {
                var entity = await _queriesManager.EquipmentCategoryQueryRepository.GetByIdAsync(id);
                if (entity is null)
                {
                    var error = new ReturnBaseError
                    {
                        ErrorCode = "404",
                        ErrorMessage = "Equipment Type Not Found"
                    };
                    var listOfErrors = new List<ReturnBaseError>() { error };
                    return ReturnBase<EquipmentCategoryDto>.Fail(listOfErrors);
                }

                var mappedResult = _mapper.Map<EquipmentCategoryDto>(entity);

                return ReturnBase<EquipmentCategoryDto>.Success(mappedResult);
            }
            catch (Exception ex)
            {
                return ReturnBase<EquipmentCategoryDto>.Fail(ex, _exceptionManager);
            }
        }
        public async Task<ReturnBase<IEnumerable<EquipmentCategoryDtoByInclude>>> GetEquipmentCategoryListByIncludeAsync(SqlQueryOptions sqlQueryOptions)
        {
            try
            {
                var getResult = await _queriesManager.EquipmentCategoryQueryRepository.GetListIncludeNameAsync(sqlQueryOptions);
                if (!getResult.Succeeded)
                    return ReturnBase<IEnumerable<EquipmentCategoryDtoByInclude>>.Fail(getResult.Errors);

                return ReturnBase<IEnumerable<EquipmentCategoryDtoByInclude>>.Success(_mapper.Map<IEnumerable<EquipmentCategoryDtoByInclude>>(getResult.Result));
            }
            catch (Exception ex)
            {
                return ReturnBase<IEnumerable<EquipmentCategoryDtoByInclude>>.Fail(ex, _exceptionManager);
            }

        }
        public async Task<ReturnBase<IEnumerable<EquipmentCategoryDtoLookUpForNames>>> GetLookUpEquipmentCategoryForNamesAsync(SqlQueryOptions queryOptions)
        {
            var result = await this._queriesManager.EquipmentCategoryQueryRepository.GetLookUpEquipmentCategoryForNamesAsync(queryOptions);

            var mappedResult = _mapper.Map<IEnumerable<EquipmentCategoryDtoLookUpForNames>>(result.Result);

            return ReturnBase<IEnumerable<EquipmentCategoryDtoLookUpForNames>>.Success(mappedResult);

        }

        private IEquipmentCategoryCommandRepository _commands
        {
            get { return _accountUoW.EquipmentCategoryCommandRepository; }
        }


    }
}
