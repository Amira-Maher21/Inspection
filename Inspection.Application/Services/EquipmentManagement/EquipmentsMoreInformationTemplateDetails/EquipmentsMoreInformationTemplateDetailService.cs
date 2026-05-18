using AutoMapper;
using Inspection.Application.Contracts.Dto.EquipmentManagement.EquipmentsMoreInformationTemplateDetails;
using Inspection.Application.Contracts.Managers;
using Inspection.Application.Contracts.Repositories.Command.EquipmentManagement.EquipmentsMoreInformationTemplateDetails;
using Inspection.Application.Contracts.Services.EquipmentManagement.EquipmentsMoreInformationTemplateDetails;
using Inspection.Application.Contracts.UnitOfWork;
using Inspection.Application.Services.ServicesBase;
using Inspection.Domain.Models.EquipmentManagement.EquipmentsMoreInformationTemplateDetails;
using NDS.Shared.Application.DataQuery;
using NDS.Shared.Application.Multitenant;
using NDS.Shared.Kernel.BaseReturnTypes;
using NDS.Shared.Kernel.Exceptions;

namespace Inspection.Application.Services.EquipmentManagement.EquipmentsMoreInformationTemplateDetails
{


    public class EquipmentsMoreInformationTemplateDetailService : AccountsServiceBase, IEquipmentsMoreInformationTemplateDetailService
    {
        private readonly ITenantResolver _tenantResolver;

        public EquipmentsMoreInformationTemplateDetailService(IAccountUnitOfWork accountUoW, IAccountsQueriesManager queriesManager, IMapper mapper, IExceptionManager exceptionManager, ITenantResolver tenantResolver) : base(accountUoW, queriesManager, mapper, exceptionManager)
        {
            _tenantResolver = tenantResolver;
        }
        public async Task<List<EquipmentsMoreInformationTemplateDetailDtoByInclude>> GetListAsync()
        {

            var list = await _queriesManager.EquipmentsMoreInformationTemplateDetailQueryRepository.GetAllAsync();
            return _mapper.Map<List<EquipmentsMoreInformationTemplateDetailDtoByInclude>>(list.Result);
        }
        public async Task<ReturnBase<UpdateEquipmentsMoreInformationTemplateDetailDto>> InsertEquipmentsMoreInformationTemplateDetailAsync(CreateEquipmentsMoreInformationTemplateDetailDto insertDto)
        {
            try
            {
                var entity = _mapper.Map<EquipmentsMoreInformationTemplateDetail>(insertDto);
                var TenantName = _tenantResolver.GetTenantName();
                entity.Tenant_ID = TenantName;

                var insertResult = await _commands.InsertAsync(entity);
                if (!insertResult.Succeeded)
                {
                    return ReturnBase<UpdateEquipmentsMoreInformationTemplateDetailDto>.Fail(insertResult.Errors);
                }

                var saveResult = await _accountUoW.SaveAsync();
                if (!saveResult.Succeeded)
                {
                    return ReturnBase<UpdateEquipmentsMoreInformationTemplateDetailDto>.Fail(saveResult.Errors);
                }

                var resultDto = _mapper.Map<UpdateEquipmentsMoreInformationTemplateDetailDto>(entity);

                return ReturnBase<UpdateEquipmentsMoreInformationTemplateDetailDto>.Success(resultDto);
            }
            catch (Exception ex)
            {
                return ReturnBase<UpdateEquipmentsMoreInformationTemplateDetailDto>.Fail(ex, _exceptionManager);
            }
        }
        public async Task<ReturnBase<UpdateEquipmentsMoreInformationTemplateDetailDto>> UpdateEquipmentsMoreInformationTemplateDetailAsync(UpdateEquipmentsMoreInformationTemplateDetailDto updateDto, long id)
        {
            try
            {
                var entity = await _queriesManager.EquipmentsMoreInformationTemplateDetailQueryRepository.GetByIdAsync(id);
                if (entity is null)
                {
                    var error = new ReturnBaseError
                    {
                        ErrorCode = "404",
                        ErrorMessage = "Equipments More Information Detail Not Found"
                    };
                    var listOfErrors = new List<ReturnBaseError>() { error };
                    return ReturnBase<UpdateEquipmentsMoreInformationTemplateDetailDto>.Fail(listOfErrors);
                }

                //if (updateDto.ServiceTypeId is 0)
                //    entity.ServiceTypeId = updateDto.ServiceTypeId;

                //if (updateDto.Notes is not null)
                //    entity.Notes = updateDto.Notes;
                entity = _mapper.Map<EquipmentsMoreInformationTemplateDetail>(updateDto);
                var TenantName = _tenantResolver.GetTenantName();
                entity.Tenant_ID = TenantName;
                var updateResult = await _commands.UpdateAsync(entity);

                if (!updateResult.Succeeded)
                    return ReturnBase<UpdateEquipmentsMoreInformationTemplateDetailDto>.Fail(updateResult.Errors);

                var saveResult = await _accountUoW.SaveAsync();

                if (!saveResult.Succeeded)
                    return ReturnBase<UpdateEquipmentsMoreInformationTemplateDetailDto>.Fail(saveResult.Errors);

                var mappedResult = _mapper.Map<UpdateEquipmentsMoreInformationTemplateDetailDto>(entity);

                return ReturnBase<UpdateEquipmentsMoreInformationTemplateDetailDto>.Success(mappedResult);

            }
            catch (Exception ex)
            {
                return ReturnBase<UpdateEquipmentsMoreInformationTemplateDetailDto>.Fail(ex, _exceptionManager);
            }
        }
        public async Task<ReturnBase<UpdateEquipmentsMoreInformationTemplateDetailDto>> DeleteEquipmentsMoreInformationTemplateDetailAsync(long id)
        {
            try
            {
                var entity = await _queriesManager.EquipmentsMoreInformationTemplateDetailQueryRepository.GetByIdAsync(id);
                if (entity is null)
                {
                    var error = new ReturnBaseError
                    {
                        ErrorCode = "404",
                        ErrorMessage = "EquipmentsMoreInformationTemplateDetail Not Found"
                    };
                    var listOfErrors = new List<ReturnBaseError>() { error };
                    return ReturnBase<UpdateEquipmentsMoreInformationTemplateDetailDto>.Fail(listOfErrors);
                }

                var deleteResult = await _commands.DeleteByIdAsync(id);

                if (!deleteResult.Succeeded)
                    return ReturnBase<UpdateEquipmentsMoreInformationTemplateDetailDto>.Fail(deleteResult.Errors);

                var saveResult = await _accountUoW.SaveAsync();

                if (!saveResult.Succeeded)
                    return ReturnBase<UpdateEquipmentsMoreInformationTemplateDetailDto>.Fail(saveResult.Errors);

                var mappedResult = _mapper.Map<UpdateEquipmentsMoreInformationTemplateDetailDto>(entity);

                return ReturnBase<UpdateEquipmentsMoreInformationTemplateDetailDto>.Success(mappedResult);

            }
            catch (Exception ex)
            {
                return ReturnBase<UpdateEquipmentsMoreInformationTemplateDetailDto>.Fail(ex, _exceptionManager);
            }
        }
        public async Task<ReturnBase<IEnumerable<EquipmentsMoreInformationTemplateDetailDtoByInclude>>> GetEquipmentsMoreInformationTemplateDetailListAsync(SqlQueryOptions sqlQueryOptions)
        {
            try
            {
                var getResult = await _queriesManager.EquipmentsMoreInformationTemplateDetailQueryRepository.GetListAsync(sqlQueryOptions);
                if (!getResult.Succeeded)
                    return ReturnBase<IEnumerable<EquipmentsMoreInformationTemplateDetailDtoByInclude>>.Fail(getResult.Errors);

                return ReturnBase<IEnumerable<EquipmentsMoreInformationTemplateDetailDtoByInclude>>.Success(getResult.Result);
            }
            catch (Exception ex)
            {
                return ReturnBase<IEnumerable<EquipmentsMoreInformationTemplateDetailDtoByInclude>>.Fail(ex, _exceptionManager);
            }
        }


        public async Task<ReturnBase<EquipmentsMoreInformationTemplateDetailDto>> GetEquipmentsMoreInformationTemplateDetailByIdAsync(long id)
        {
            try
            {
                var entity = await _queriesManager.EquipmentsMoreInformationTemplateDetailQueryRepository.GetByIdAsync(id);
                if (entity is null)
                {
                    var error = new ReturnBaseError
                    {
                        ErrorCode = "404",
                        ErrorMessage = "EquipmentsMoreInformationTemplateDetail Not Found"
                    };
                    var listOfErrors = new List<ReturnBaseError>() { error };
                    return ReturnBase<EquipmentsMoreInformationTemplateDetailDto>.Fail(listOfErrors);
                }

                var mappedResult = _mapper.Map<EquipmentsMoreInformationTemplateDetailDto>(entity);

                return ReturnBase<EquipmentsMoreInformationTemplateDetailDto>.Success(mappedResult);
            }
            catch (Exception ex)
            {
                return ReturnBase<EquipmentsMoreInformationTemplateDetailDto>.Fail(ex, _exceptionManager);
            }
        }
        public async Task<ReturnBase<List<EquipmentMoreInformationTemplateDetailsKeyValueDto>>> GetByEquipmentTypeIdAsync(long id)
        {
            try
            {
                var entity = await _queriesManager.EquipmentsMoreInformationTemplateDetailQueryRepository.GetByEquipmentTypeIdAsync(id);
                if (entity is null)
                {
                    var error = new ReturnBaseError
                    {
                        ErrorCode = "404",
                        ErrorMessage = "Equipments More Information Detail Not Found"
                    };
                    var listOfErrors = new List<ReturnBaseError>() { error };
                    return ReturnBase<List<EquipmentMoreInformationTemplateDetailsKeyValueDto>>.Fail(listOfErrors);
                }

                var mappedResult = _mapper.Map<List<EquipmentMoreInformationTemplateDetailsKeyValueDto>>(entity);

                return ReturnBase<List<EquipmentMoreInformationTemplateDetailsKeyValueDto>>.Success(mappedResult);
            }
            catch (Exception ex)
            {
                return ReturnBase<List<EquipmentMoreInformationTemplateDetailsKeyValueDto>>.Fail(ex, _exceptionManager);
            }
        }



        public async Task<ReturnBase<IEnumerable<EquipmentsMoreInformationTemplateDetailDtoByInclude>>> GetEquipmentsMoreInformationTemplateDetailListByIncludeAsync(SqlQueryOptions sqlQueryOptions)
        {
            try
            {
                var getResult = await _queriesManager.EquipmentsMoreInformationTemplateDetailQueryRepository.GetListIncludeNameAsync(sqlQueryOptions);
                if (!getResult.Succeeded)
                    return ReturnBase<IEnumerable<EquipmentsMoreInformationTemplateDetailDtoByInclude>>.Fail(getResult.Errors);

                return ReturnBase<IEnumerable<EquipmentsMoreInformationTemplateDetailDtoByInclude>>.Success(_mapper.Map<IEnumerable<EquipmentsMoreInformationTemplateDetailDtoByInclude>>(getResult.Result));
            }
            catch (Exception ex)
            {
                return ReturnBase<IEnumerable<EquipmentsMoreInformationTemplateDetailDtoByInclude>>.Fail(ex, _exceptionManager);
            }

        }
        //public async Task<ReturnBase<IEnumerable<EquipmentsMoreInformationTemplateDetailDtoLookUpForNames>>> GetLookUpEquipmentsMoreInformationTemplateDetailForNamesAsync(SqlQueryOptions queryOptions)
        //{
        //    var result = await this._queriesManager.EquipmentsMoreInformationTemplateDetails.GetLookUpEquipmentsMoreInformationTemplateDetailForNamesAsync(queryOptions);

        //    var mappedResult = _mapper.Map<IEnumerable<EquipmentsMoreInformationTemplateDetailDtoLookUpForNames>>(result.Result);

        //    return ReturnBase<IEnumerable<EquipmentsMoreInformationTemplateDetailDtoLookUpForNames>>.Success(mappedResult);

        //}

        private IEquipmentsMoreInformationTemplateDetailCommandRepository _commands
        {
            get { return _accountUoW.EquipmentsMoreInformationTemplateDetailCommandRepository; }
        }


    }
}
