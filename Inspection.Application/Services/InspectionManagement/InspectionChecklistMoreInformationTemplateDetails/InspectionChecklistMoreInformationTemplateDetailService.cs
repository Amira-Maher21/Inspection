using AutoMapper;
using Inspection.Application.Contracts.Dto.InspectionManagement.InspectionChecklistMoreInformationTemplateDetails;
using Inspection.Application.Contracts.Managers;
using Inspection.Application.Contracts.Repositories.Command.InspectionManagement.InspectionChecklistMoreInformationTemplateDetails;
using Inspection.Application.Contracts.Services.InspectionManagement.InspectionChecklistMoreInformationTemplateDetails;
using Inspection.Application.Contracts.UnitOfWork;
using Inspection.Application.Services.ServicesBase;
using Inspection.Domain.Models.InspectionManagement.InspectionChecklistMoreInformationTemplateDetails;
using NDS.Shared.Application.DataQuery;
using NDS.Shared.Application.Multitenant;
using NDS.Shared.Kernel.BaseReturnTypes;
using NDS.Shared.Kernel.Exceptions;

namespace Inspection.Application.Services.InspectionManagement.InspectionChecklistMoreInformationTemplateDetails
{


    public class InspectionChecklistMoreInformationTemplateDetailService : AccountsServiceBase, IInspectionChecklistMoreInformationTemplateDetailService
    {
        private readonly ITenantResolver _tenantResolver;

        public InspectionChecklistMoreInformationTemplateDetailService(IAccountUnitOfWork accountUoW, IAccountsQueriesManager queriesManager, IMapper mapper, IExceptionManager exceptionManager, ITenantResolver tenantResolver) : base(accountUoW, queriesManager, mapper, exceptionManager)
        {
            _tenantResolver = tenantResolver;
        }
        public async Task<List<InspectionChecklistMoreInformationTemplateDetailDtoByInclude>> GetListAsync()
        {

            var list = await _queriesManager.InspectionChecklistMoreInformationTemplateDetailQueryRepository.GetAllAsync();
            return _mapper.Map<List<InspectionChecklistMoreInformationTemplateDetailDtoByInclude>>(list.Result);
        }
        public async Task<ReturnBase<UpdateInspectionChecklistMoreInformationTemplateDetailDto>> InsertInspectionChecklistMoreInformationTemplateDetailAsync(CreateInspectionChecklistMoreInformationTemplateDetailDto insertDto)
        {
            try
            {
                var entity = _mapper.Map<InspectionChecklistMoreInformationTemplateDetail>(insertDto);
                var TenantName = _tenantResolver.GetTenantName();
                entity.Tenant_ID = TenantName;

                var insertResult = await _commands.InsertAsync(entity);
                if (!insertResult.Succeeded)
                {
                    return ReturnBase<UpdateInspectionChecklistMoreInformationTemplateDetailDto>.Fail(insertResult.Errors);
                }

                var saveResult = await _accountUoW.SaveAsync();
                if (!saveResult.Succeeded)
                {
                    return ReturnBase<UpdateInspectionChecklistMoreInformationTemplateDetailDto>.Fail(saveResult.Errors);
                }

                var resultDto = _mapper.Map<UpdateInspectionChecklistMoreInformationTemplateDetailDto>(entity);

                return ReturnBase<UpdateInspectionChecklistMoreInformationTemplateDetailDto>.Success(resultDto);
            }
            catch (Exception ex)
            {
                return ReturnBase<UpdateInspectionChecklistMoreInformationTemplateDetailDto>.Fail(ex, _exceptionManager);
            }
        }
        public async Task<ReturnBase<UpdateInspectionChecklistMoreInformationTemplateDetailDto>> UpdateInspectionChecklistMoreInformationTemplateDetailAsync(UpdateInspectionChecklistMoreInformationTemplateDetailDto updateDto, long id)
        {
            try
            {
                var entity = await _queriesManager.InspectionChecklistMoreInformationTemplateDetailQueryRepository.GetByIdAsync(id);
                if (entity is null)
                {
                    var error = new ReturnBaseError
                    {
                        ErrorCode = "404",
                        ErrorMessage = "InspectionChecklists More Information Detail Not Found"
                    };
                    var listOfErrors = new List<ReturnBaseError>() { error };
                    return ReturnBase<UpdateInspectionChecklistMoreInformationTemplateDetailDto>.Fail(listOfErrors);
                }

                //if (updateDto.ServiceTypeId is 0)
                //    entity.ServiceTypeId = updateDto.ServiceTypeId;

                //if (updateDto.Notes is not null)
                //    entity.Notes = updateDto.Notes;
                entity = _mapper.Map<InspectionChecklistMoreInformationTemplateDetail>(updateDto);
                var TenantName = _tenantResolver.GetTenantName();
                entity.Tenant_ID = TenantName;
                var updateResult = await _commands.UpdateAsync(entity);

                if (!updateResult.Succeeded)
                    return ReturnBase<UpdateInspectionChecklistMoreInformationTemplateDetailDto>.Fail(updateResult.Errors);

                var saveResult = await _accountUoW.SaveAsync();

                if (!saveResult.Succeeded)
                    return ReturnBase<UpdateInspectionChecklistMoreInformationTemplateDetailDto>.Fail(saveResult.Errors);

                var mappedResult = _mapper.Map<UpdateInspectionChecklistMoreInformationTemplateDetailDto>(entity);

                return ReturnBase<UpdateInspectionChecklistMoreInformationTemplateDetailDto>.Success(mappedResult);

            }
            catch (Exception ex)
            {
                return ReturnBase<UpdateInspectionChecklistMoreInformationTemplateDetailDto>.Fail(ex, _exceptionManager);
            }
        }
        public async Task<ReturnBase<UpdateInspectionChecklistMoreInformationTemplateDetailDto>> DeleteInspectionChecklistMoreInformationTemplateDetailAsync(long id)
        {
            try
            {
                var entity = await _queriesManager.InspectionChecklistMoreInformationTemplateDetailQueryRepository.GetByIdAsync(id);
                if (entity is null)
                {
                    var error = new ReturnBaseError
                    {
                        ErrorCode = "404",
                        ErrorMessage = "InspectionChecklistMoreInformationTemplateDetail Not Found"
                    };
                    var listOfErrors = new List<ReturnBaseError>() { error };
                    return ReturnBase<UpdateInspectionChecklistMoreInformationTemplateDetailDto>.Fail(listOfErrors);
                }

                var deleteResult = await _commands.DeleteByIdAsync(id);

                if (!deleteResult.Succeeded)
                    return ReturnBase<UpdateInspectionChecklistMoreInformationTemplateDetailDto>.Fail(deleteResult.Errors);

                var saveResult = await _accountUoW.SaveAsync();

                if (!saveResult.Succeeded)
                    return ReturnBase<UpdateInspectionChecklistMoreInformationTemplateDetailDto>.Fail(saveResult.Errors);

                var mappedResult = _mapper.Map<UpdateInspectionChecklistMoreInformationTemplateDetailDto>(entity);

                return ReturnBase<UpdateInspectionChecklistMoreInformationTemplateDetailDto>.Success(mappedResult);

            }
            catch (Exception ex)
            {
                return ReturnBase<UpdateInspectionChecklistMoreInformationTemplateDetailDto>.Fail(ex, _exceptionManager);
            }
        }
        public async Task<ReturnBase<IEnumerable<InspectionChecklistMoreInformationTemplateDetailDtoByInclude>>> GetInspectionChecklistMoreInformationTemplateDetailListAsync(SqlQueryOptions sqlQueryOptions)
        {
            try
            {
                var getResult = await _queriesManager.InspectionChecklistMoreInformationTemplateDetailQueryRepository.GetListAsync(sqlQueryOptions);
                if (!getResult.Succeeded)
                    return ReturnBase<IEnumerable<InspectionChecklistMoreInformationTemplateDetailDtoByInclude>>.Fail(getResult.Errors);

                return ReturnBase<IEnumerable<InspectionChecklistMoreInformationTemplateDetailDtoByInclude>>.Success(getResult.Result);
            }
            catch (Exception ex)
            {
                return ReturnBase<IEnumerable<InspectionChecklistMoreInformationTemplateDetailDtoByInclude>>.Fail(ex, _exceptionManager);
            }
        }


        public async Task<ReturnBase<InspectionChecklistMoreInformationTemplateDetailDto>> GetInspectionChecklistMoreInformationTemplateDetailByIdAsync(long id)
        {
            try
            {
                var entity = await _queriesManager.InspectionChecklistMoreInformationTemplateDetailQueryRepository.GetByIdAsync(id);
                if (entity is null)
                {
                    var error = new ReturnBaseError
                    {
                        ErrorCode = "404",
                        ErrorMessage = "InspectionChecklistMoreInformationTemplateDetail Not Found"
                    };
                    var listOfErrors = new List<ReturnBaseError>() { error };
                    return ReturnBase<InspectionChecklistMoreInformationTemplateDetailDto>.Fail(listOfErrors);
                }

                var mappedResult = _mapper.Map<InspectionChecklistMoreInformationTemplateDetailDto>(entity);

                return ReturnBase<InspectionChecklistMoreInformationTemplateDetailDto>.Success(mappedResult);
            }
            catch (Exception ex)
            {
                return ReturnBase<InspectionChecklistMoreInformationTemplateDetailDto>.Fail(ex, _exceptionManager);
            }
        }
        public async Task<ReturnBase<List<InspectionChecklistMoreInformationTemplateDetailKeyValueDto>>> GetByEquipmentTypeIdAsync(long id)
        {
            try
            {
                var entity = await _queriesManager.InspectionChecklistMoreInformationTemplateDetailQueryRepository.GetByEquipmentTypeIdAsync(id);
                if (entity is null)
                {
                    var error = new ReturnBaseError
                    {
                        ErrorCode = "404",
                        ErrorMessage = "InspectionChecklists More Information Detail Not Found"
                    };
                    var listOfErrors = new List<ReturnBaseError>() { error };
                    return ReturnBase<List<InspectionChecklistMoreInformationTemplateDetailKeyValueDto>>.Fail(listOfErrors);
                }

                var mappedResult = _mapper.Map<List<InspectionChecklistMoreInformationTemplateDetailKeyValueDto>>(entity);

                return ReturnBase<List<InspectionChecklistMoreInformationTemplateDetailKeyValueDto>>.Success(mappedResult);
            }
            catch (Exception ex)
            {
                return ReturnBase<List<InspectionChecklistMoreInformationTemplateDetailKeyValueDto>>.Fail(ex, _exceptionManager);
            }
        }



        public async Task<ReturnBase<IEnumerable<InspectionChecklistMoreInformationTemplateDetailDtoByInclude>>> GetInspectionChecklistMoreInformationTemplateDetailListByIncludeAsync(SqlQueryOptions sqlQueryOptions)
        {
            try
            {
                var getResult = await _queriesManager.InspectionChecklistMoreInformationTemplateDetailQueryRepository.GetListIncludeNameAsync(sqlQueryOptions);
                if (!getResult.Succeeded)
                    return ReturnBase<IEnumerable<InspectionChecklistMoreInformationTemplateDetailDtoByInclude>>.Fail(getResult.Errors);

                return ReturnBase<IEnumerable<InspectionChecklistMoreInformationTemplateDetailDtoByInclude>>.Success(_mapper.Map<IEnumerable<InspectionChecklistMoreInformationTemplateDetailDtoByInclude>>(getResult.Result));
            }
            catch (Exception ex)
            {
                return ReturnBase<IEnumerable<InspectionChecklistMoreInformationTemplateDetailDtoByInclude>>.Fail(ex, _exceptionManager);
            }

        }


        private IInspectionChecklistMoreInformationTemplateDetailCR _commands
        {
            get { return _accountUoW.InspectionChecklistMoreInformationTemplateDetailCR; }
        }


    }
}
