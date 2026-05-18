using AutoMapper;
using Inspection.Application.Contracts.Dto.EquipmentManagement.EquipmentsMoreInformationDetails;
using Inspection.Application.Contracts.Managers;
using Inspection.Application.Contracts.Repositories.Command.EquipmentManagement.EquipmentsMoreInformationDetails;
using Inspection.Application.Contracts.Services.EquipmentManagement.EquipmentsMoreInformationDetails;
using Inspection.Application.Contracts.UnitOfWork;
using Inspection.Application.Services.ServicesBase;
using Inspection.Domain.Models.EquipmentManagement.EquipmentsMoreInformationDetails;
using NDS.Shared.Application.DataQuery;
using NDS.Shared.Application.Multitenant;
using NDS.Shared.Kernel.BaseReturnTypes;
using NDS.Shared.Kernel.Exceptions;

namespace Inspection.Application.Services.EquipmentManagement.EquipmentsMoreInformationDetails
{


    public class EquipmentsMoreInformationDetailService : AccountsServiceBase, IEquipmentsMoreInformationDetailService
    {
        private readonly ITenantResolver _tenantResolver;

        public EquipmentsMoreInformationDetailService(IAccountUnitOfWork accountUoW, IAccountsQueriesManager queriesManager, IMapper mapper, IExceptionManager exceptionManager, ITenantResolver tenantResolver) : base(accountUoW, queriesManager, mapper, exceptionManager)
        {
            _tenantResolver = tenantResolver;
        }
        public async Task<List<EquipmentsMoreInformationDetailDtoByInclude>> GetListAsync()
        {

            var list = await _queriesManager.EquipmentsMoreInformationDetailQueryRepository.GetAllAsync();
            return _mapper.Map<List<EquipmentsMoreInformationDetailDtoByInclude>>(list.Result);
        }
        public async Task<ReturnBase<UpdateEquipmentsMoreInformationDetailDto>> InsertEquipmentsMoreInformationDetailAsync(CreateEquipmentsMoreInformationDetailDto insertDto)
        {
            try
            {
                var entity = _mapper.Map<EquipmentsMoreInformationDetail>(insertDto);
                var TenantName = _tenantResolver.GetTenantName();
                entity.Tenant_ID = TenantName;

                var insertResult = await _commands.InsertAsync(entity);
                if (!insertResult.Succeeded)
                {
                    return ReturnBase<UpdateEquipmentsMoreInformationDetailDto>.Fail(insertResult.Errors);
                }

                var saveResult = await _accountUoW.SaveAsync();
                if (!saveResult.Succeeded)
                {
                    return ReturnBase<UpdateEquipmentsMoreInformationDetailDto>.Fail(saveResult.Errors);
                }

                var resultDto = _mapper.Map<UpdateEquipmentsMoreInformationDetailDto>(entity);

                return ReturnBase<UpdateEquipmentsMoreInformationDetailDto>.Success(resultDto);
            }
            catch (Exception ex)
            {
                return ReturnBase<UpdateEquipmentsMoreInformationDetailDto>.Fail(ex, _exceptionManager);
            }
        }
        public async Task<ReturnBase<UpdateEquipmentsMoreInformationDetailDto>> UpdateEquipmentsMoreInformationDetailAsync(UpdateEquipmentsMoreInformationDetailDto updateDto, long id)
        {
            try
            {
                var entity = await _queriesManager.EquipmentsMoreInformationDetailQueryRepository.GetByIdAsync(id);
                if (entity is null)
                {
                    var error = new ReturnBaseError
                    {
                        ErrorCode = "404",
                        ErrorMessage = "Equipments More Information Detail Not Found"
                    };
                    var listOfErrors = new List<ReturnBaseError>() { error };
                    return ReturnBase<UpdateEquipmentsMoreInformationDetailDto>.Fail(listOfErrors);
                }

                //if (updateDto.ServiceTypeId is 0)
                //    entity.ServiceTypeId = updateDto.ServiceTypeId;

                //if (updateDto.Notes is not null)
                //    entity.Notes = updateDto.Notes;
                entity = _mapper.Map<EquipmentsMoreInformationDetail>(updateDto);
                var TenantName = _tenantResolver.GetTenantName();
                entity.Tenant_ID = TenantName;
                var updateResult = await _commands.UpdateAsync(entity);

                if (!updateResult.Succeeded)
                    return ReturnBase<UpdateEquipmentsMoreInformationDetailDto>.Fail(updateResult.Errors);

                var saveResult = await _accountUoW.SaveAsync();

                if (!saveResult.Succeeded)
                    return ReturnBase<UpdateEquipmentsMoreInformationDetailDto>.Fail(saveResult.Errors);

                var mappedResult = _mapper.Map<UpdateEquipmentsMoreInformationDetailDto>(entity);

                return ReturnBase<UpdateEquipmentsMoreInformationDetailDto>.Success(mappedResult);

            }
            catch (Exception ex)
            {
                return ReturnBase<UpdateEquipmentsMoreInformationDetailDto>.Fail(ex, _exceptionManager);
            }
        }
        public async Task<ReturnBase<UpdateEquipmentsMoreInformationDetailDto>> DeleteEquipmentsMoreInformationDetailAsync(long id)
        {
            try
            {
                var entity = await _queriesManager.EquipmentsMoreInformationDetailQueryRepository.GetByIdAsync(id);
                if (entity is null)
                {
                    var error = new ReturnBaseError
                    {
                        ErrorCode = "404",
                        ErrorMessage = "EquipmentsMoreInformationDetail Not Found"
                    };
                    var listOfErrors = new List<ReturnBaseError>() { error };
                    return ReturnBase<UpdateEquipmentsMoreInformationDetailDto>.Fail(listOfErrors);
                }

                var deleteResult = await _commands.DeleteByIdAsync(id);

                if (!deleteResult.Succeeded)
                    return ReturnBase<UpdateEquipmentsMoreInformationDetailDto>.Fail(deleteResult.Errors);

                var saveResult = await _accountUoW.SaveAsync();

                if (!saveResult.Succeeded)
                    return ReturnBase<UpdateEquipmentsMoreInformationDetailDto>.Fail(saveResult.Errors);

                var mappedResult = _mapper.Map<UpdateEquipmentsMoreInformationDetailDto>(entity);

                return ReturnBase<UpdateEquipmentsMoreInformationDetailDto>.Success(mappedResult);

            }
            catch (Exception ex)
            {
                return ReturnBase<UpdateEquipmentsMoreInformationDetailDto>.Fail(ex, _exceptionManager);
            }
        }
        public async Task<ReturnBase<IEnumerable<EquipmentsMoreInformationDetailDtoByInclude>>> GetEquipmentsMoreInformationDetailListAsync(SqlQueryOptions sqlQueryOptions)
        {
            try
            {
                var getResult = await _queriesManager.EquipmentsMoreInformationDetailQueryRepository.GetListAsync(sqlQueryOptions);
                if (!getResult.Succeeded)
                    return ReturnBase<IEnumerable<EquipmentsMoreInformationDetailDtoByInclude>>.Fail(getResult.Errors);

                return ReturnBase<IEnumerable<EquipmentsMoreInformationDetailDtoByInclude>>.Success(getResult.Result);
            }
            catch (Exception ex)
            {
                return ReturnBase<IEnumerable<EquipmentsMoreInformationDetailDtoByInclude>>.Fail(ex, _exceptionManager);
            }
        }


        public async Task<ReturnBase<EquipmentsMoreInformationDetailDto>> GetEquipmentsMoreInformationDetailByIdAsync(long id)
        {
            try
            {
                var entity = await _queriesManager.EquipmentsMoreInformationDetailQueryRepository.GetByIdAsync(id);
                if (entity is null)
                {
                    var error = new ReturnBaseError
                    {
                        ErrorCode = "404",
                        ErrorMessage = "EquipmentsMoreInformationDetail Not Found"
                    };
                    var listOfErrors = new List<ReturnBaseError>() { error };
                    return ReturnBase<EquipmentsMoreInformationDetailDto>.Fail(listOfErrors);
                }

                var mappedResult = _mapper.Map<EquipmentsMoreInformationDetailDto>(entity);

                return ReturnBase<EquipmentsMoreInformationDetailDto>.Success(mappedResult);
            }
            catch (Exception ex)
            {
                return ReturnBase<EquipmentsMoreInformationDetailDto>.Fail(ex, _exceptionManager);
            }
        }
        public async Task<ReturnBase<List<EquipmentMoreInformationDetailsKeyValueDto>>> GetByEquipmentTypeIdAsync(long id)
        {
            try
            {
                var entity = await _queriesManager.EquipmentsMoreInformationDetailQueryRepository.GetByEquipmentTypeIdAsync(id);
                if (entity is null)
                {
                    var error = new ReturnBaseError
                    {
                        ErrorCode = "404",
                        ErrorMessage = "Equipments More Information Detail Not Found"
                    };
                    var listOfErrors = new List<ReturnBaseError>() { error };
                    return ReturnBase<List<EquipmentMoreInformationDetailsKeyValueDto>>.Fail(listOfErrors);
                }

                var mappedResult = _mapper.Map<List<EquipmentMoreInformationDetailsKeyValueDto>>(entity);

                return ReturnBase<List<EquipmentMoreInformationDetailsKeyValueDto>>.Success(mappedResult);
            }
            catch (Exception ex)
            {
                return ReturnBase<List<EquipmentMoreInformationDetailsKeyValueDto>>.Fail(ex, _exceptionManager);
            }
        }



        public async Task<ReturnBase<IEnumerable<EquipmentsMoreInformationDetailDtoByInclude>>> GetEquipmentsMoreInformationDetailListByIncludeAsync(SqlQueryOptions sqlQueryOptions)
        {
            try
            {
                var getResult = await _queriesManager.EquipmentsMoreInformationDetailQueryRepository.GetListIncludeNameAsync(sqlQueryOptions);
                if (!getResult.Succeeded)
                    return ReturnBase<IEnumerable<EquipmentsMoreInformationDetailDtoByInclude>>.Fail(getResult.Errors);

                return ReturnBase<IEnumerable<EquipmentsMoreInformationDetailDtoByInclude>>.Success(_mapper.Map<IEnumerable<EquipmentsMoreInformationDetailDtoByInclude>>(getResult.Result));
            }
            catch (Exception ex)
            {
                return ReturnBase<IEnumerable<EquipmentsMoreInformationDetailDtoByInclude>>.Fail(ex, _exceptionManager);
            }

        }


        private IEquipmentsMoreInformationDetailCommandRepository _commands
        {
            get { return _accountUoW.EquipmentsMoreInformationDetailCommandRepository; }
        }


    }
}
