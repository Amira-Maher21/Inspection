using AutoMapper;
using Inspection.Application.Contracts.Dto.InspectionManagement.InspectionChecklistMoreInformationDetails;
using Inspection.Application.Contracts.Managers;
using Inspection.Application.Contracts.Repositories.Command.InspectionManagement.InspectionChecklistMoreInformationDetails;
using Inspection.Application.Contracts.Services.InspectionManagement.InspectionChecklistMoreInformationDetails;
using Inspection.Application.Contracts.UnitOfWork;
using Inspection.Application.Services.ServicesBase;
using Inspection.Domain.Models.InspectionManagement.InspectionChecklistMoreInformationDetails;
using NDS.Shared.Application.DataQuery;
using NDS.Shared.Application.Multitenant;
using NDS.Shared.Kernel.BaseReturnTypes;
using NDS.Shared.Kernel.Exceptions;

namespace Inspection.Application.Services.InspectionManagement.InspectionChecklistMoreInformationDetails
{


    public class InspectionChecklistMoreInformationDetailService : AccountsServiceBase, IInspectionChecklistMoreInformationDetailService
    {
        private readonly ITenantResolver _tenantResolver;

        public InspectionChecklistMoreInformationDetailService(IAccountUnitOfWork accountUoW, IAccountsQueriesManager queriesManager, IMapper mapper, IExceptionManager exceptionManager, ITenantResolver tenantResolver) : base(accountUoW, queriesManager, mapper, exceptionManager)
        {
            _tenantResolver = tenantResolver;
        }
        public async Task<List<InspectionChecklistMoreInformationDetailDtoByInclude>> GetListAsync()
        {

            var list = await _queriesManager.InspectionChecklistMoreInformationDetailQueryRepository.GetAllAsync();
            return _mapper.Map<List<InspectionChecklistMoreInformationDetailDtoByInclude>>(list.Result);
        }
        public async Task<ReturnBase<UpdateInspectionChecklistMoreInformationDetailDto>> InsertInspectionChecklistMoreInformationDetailAsync(CreateInspectionChecklistMoreInformationDetailDto insertDto)
        {
            try
            {
                var entity = _mapper.Map<InspectionChecklistMoreInformationDetail>(insertDto);
                var TenantName = _tenantResolver.GetTenantName();
                entity.Tenant_ID = TenantName;

                var insertResult = await _commands.InsertAsync(entity);
                if (!insertResult.Succeeded)
                {
                    return ReturnBase<UpdateInspectionChecklistMoreInformationDetailDto>.Fail(insertResult.Errors);
                }

                var saveResult = await _accountUoW.SaveAsync();
                if (!saveResult.Succeeded)
                {
                    return ReturnBase<UpdateInspectionChecklistMoreInformationDetailDto>.Fail(saveResult.Errors);
                }

                var resultDto = _mapper.Map<UpdateInspectionChecklistMoreInformationDetailDto>(entity);

                return ReturnBase<UpdateInspectionChecklistMoreInformationDetailDto>.Success(resultDto);
            }
            catch (Exception ex)
            {
                return ReturnBase<UpdateInspectionChecklistMoreInformationDetailDto>.Fail(ex, _exceptionManager);
            }
        }
        public async Task<ReturnBase<UpdateInspectionChecklistMoreInformationDetailDto>> UpdateInspectionChecklistMoreInformationDetailAsync(UpdateInspectionChecklistMoreInformationDetailDto updateDto, long id)
        {
            try
            {
                var entity = await _queriesManager.InspectionChecklistMoreInformationDetailQueryRepository.GetByIdAsync(id);
                if (entity is null)
                {
                    var error = new ReturnBaseError
                    {
                        ErrorCode = "404",
                        ErrorMessage = "Inspection Checklists More Information Detail Not Found"
                    };
                    var listOfErrors = new List<ReturnBaseError>() { error };
                    return ReturnBase<UpdateInspectionChecklistMoreInformationDetailDto>.Fail(listOfErrors);
                }

                //if (updateDto.ServiceTypeId is 0)
                //    entity.ServiceTypeId = updateDto.ServiceTypeId;

                //if (updateDto.Notes is not null)
                //    entity.Notes = updateDto.Notes;
                entity = _mapper.Map<InspectionChecklistMoreInformationDetail>(updateDto);
                var TenantName = _tenantResolver.GetTenantName();
                entity.Tenant_ID = TenantName;
                var updateResult = await _commands.UpdateAsync(entity);

                if (!updateResult.Succeeded)
                    return ReturnBase<UpdateInspectionChecklistMoreInformationDetailDto>.Fail(updateResult.Errors);

                var saveResult = await _accountUoW.SaveAsync();

                if (!saveResult.Succeeded)
                    return ReturnBase<UpdateInspectionChecklistMoreInformationDetailDto>.Fail(saveResult.Errors);

                var mappedResult = _mapper.Map<UpdateInspectionChecklistMoreInformationDetailDto>(entity);

                return ReturnBase<UpdateInspectionChecklistMoreInformationDetailDto>.Success(mappedResult);

            }
            catch (Exception ex)
            {
                return ReturnBase<UpdateInspectionChecklistMoreInformationDetailDto>.Fail(ex, _exceptionManager);
            }
        }
        public async Task<ReturnBase<UpdateInspectionChecklistMoreInformationDetailDto>> DeleteInspectionChecklistMoreInformationDetailAsync(long id)
        {
            try
            {
                var entity = await _queriesManager.InspectionChecklistMoreInformationDetailQueryRepository.GetByIdAsync(id);
                if (entity is null)
                {
                    var error = new ReturnBaseError
                    {
                        ErrorCode = "404",
                        ErrorMessage = "InspectionChecklistMoreInformation Detail Not Found"
                    };
                    var listOfErrors = new List<ReturnBaseError>() { error };
                    return ReturnBase<UpdateInspectionChecklistMoreInformationDetailDto>.Fail(listOfErrors);
                }

                var deleteResult = await _commands.DeleteByIdAsync(id);

                if (!deleteResult.Succeeded)
                    return ReturnBase<UpdateInspectionChecklistMoreInformationDetailDto>.Fail(deleteResult.Errors);

                var saveResult = await _accountUoW.SaveAsync();

                if (!saveResult.Succeeded)
                    return ReturnBase<UpdateInspectionChecklistMoreInformationDetailDto>.Fail(saveResult.Errors);

                var mappedResult = _mapper.Map<UpdateInspectionChecklistMoreInformationDetailDto>(entity);

                return ReturnBase<UpdateInspectionChecklistMoreInformationDetailDto>.Success(mappedResult);

            }
            catch (Exception ex)
            {
                return ReturnBase<UpdateInspectionChecklistMoreInformationDetailDto>.Fail(ex, _exceptionManager);
            }
        }
        public async Task<ReturnBase<IEnumerable<InspectionChecklistMoreInformationDetailDtoByInclude>>> GetInspectionChecklistMoreInformationDetailListAsync(SqlQueryOptions sqlQueryOptions)
        {
            try
            {
                var getResult = await _queriesManager.InspectionChecklistMoreInformationDetailQueryRepository.GetListAsync(sqlQueryOptions);
                if (!getResult.Succeeded)
                    return ReturnBase<IEnumerable<InspectionChecklistMoreInformationDetailDtoByInclude>>.Fail(getResult.Errors);

                return ReturnBase<IEnumerable<InspectionChecklistMoreInformationDetailDtoByInclude>>.Success(getResult.Result);
            }
            catch (Exception ex)
            {
                return ReturnBase<IEnumerable<InspectionChecklistMoreInformationDetailDtoByInclude>>.Fail(ex, _exceptionManager);
            }
        }


        public async Task<ReturnBase<InspectionChecklistMoreInformationDetailDto>> GetInspectionChecklistMoreInformationDetailByIdAsync(long id)
        {
            try
            {
                var entity = await _queriesManager.InspectionChecklistMoreInformationDetailQueryRepository.GetByIdAsync(id);
                if (entity is null)
                {
                    var error = new ReturnBaseError
                    {
                        ErrorCode = "404",
                        ErrorMessage = "InspectionChecklistMoreInformationDetail Not Found"
                    };
                    var listOfErrors = new List<ReturnBaseError>() { error };
                    return ReturnBase<InspectionChecklistMoreInformationDetailDto>.Fail(listOfErrors);
                }

                var mappedResult = _mapper.Map<InspectionChecklistMoreInformationDetailDto>(entity);

                return ReturnBase<InspectionChecklistMoreInformationDetailDto>.Success(mappedResult);
            }
            catch (Exception ex)
            {
                return ReturnBase<InspectionChecklistMoreInformationDetailDto>.Fail(ex, _exceptionManager);
            }
        }
        public async Task<ReturnBase<List<InspectionChecklistMoreInformationDetailsKeyValueDto>>> GetByEquipmentTypeIdAsync(long id)
        {
            try
            {
                var entity = await _queriesManager.InspectionChecklistMoreInformationDetailQueryRepository.GetByEquipmentTypeIdAsync(id);
                if (entity is null)
                {
                    var error = new ReturnBaseError
                    {
                        ErrorCode = "404",
                        ErrorMessage = "Inspection Checklist More Information Detail Not Found"
                    };
                    var listOfErrors = new List<ReturnBaseError>() { error };
                    return ReturnBase<List<InspectionChecklistMoreInformationDetailsKeyValueDto>>.Fail(listOfErrors);
                }


                var mappedResult = _mapper.Map<List<InspectionChecklistMoreInformationDetailsKeyValueDto>>(entity);

                return ReturnBase<List<InspectionChecklistMoreInformationDetailsKeyValueDto>>.Success(mappedResult);
            }
            catch (Exception ex)
            {
                return ReturnBase<List<InspectionChecklistMoreInformationDetailsKeyValueDto>>.Fail(ex, _exceptionManager);
            }
        }



        public async Task<ReturnBase<IEnumerable<InspectionChecklistMoreInformationDetailDtoByInclude>>> GetInspectionChecklistMoreInformationDetailListByIncludeAsync(SqlQueryOptions sqlQueryOptions)
        {
            try
            {
                var getResult = await _queriesManager.InspectionChecklistMoreInformationDetailQueryRepository.GetListIncludeNameAsync(sqlQueryOptions);
                if (!getResult.Succeeded)
                    return ReturnBase<IEnumerable<InspectionChecklistMoreInformationDetailDtoByInclude>>.Fail(getResult.Errors);

                return ReturnBase<IEnumerable<InspectionChecklistMoreInformationDetailDtoByInclude>>.Success(_mapper.Map<IEnumerable<InspectionChecklistMoreInformationDetailDtoByInclude>>(getResult.Result));
            }
            catch (Exception ex)
            {
                return ReturnBase<IEnumerable<InspectionChecklistMoreInformationDetailDtoByInclude>>.Fail(ex, _exceptionManager);
            }

        }


        private IInspectionChecklistMoreInformationDetailCommandRepository _commands
        {
            get { return _accountUoW.InspectionChecklistMoreInformationDetailCommandRepository; }
        }


    }
}
