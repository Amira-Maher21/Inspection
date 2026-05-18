using AutoMapper;
using Inspection.Application.Contracts.Dto.InspectionManagement.InspectionChecklistMoreInformationTemplates;
using Inspection.Application.Contracts.Managers;
using Inspection.Application.Contracts.Repositories.Command.InspectionManagement.InspectionChecklistMoreInformationTemplateDetails;
using Inspection.Application.Contracts.Repositories.Command.InspectionManagement.InspectionChecklistMoreInformationTemplates;
using Inspection.Application.Contracts.Repositories.Query.InspectionManagement.InspectionChecklistMoreInformationTemplates;
using Inspection.Application.Contracts.Services.InspectionManagement.InspectionChecklistMoreInformationTemplates;
using Inspection.Application.Contracts.UnitOfWork;
using Inspection.Application.Services.ServicesBase;
using Inspection.Domain.Models.InspectionManagement.InspectionChecklistMoreInformationTemplateDetails;
using Inspection.Domain.Models.InspectionManagement.InspectionChecklistMoreInformationTemplates;
using NDS.Shared.Application.DataQuery;
using NDS.Shared.Application.Multitenant;
using NDS.Shared.Application.SharedModels;
using NDS.Shared.Kernel.BaseReturnTypes;
using NDS.Shared.Kernel.Exceptions;

namespace Inspection.Application.Services.InspectionManagement.InspectionChecklistMoreInformationTemplates
{


    public class InspectionChecklistMoreInformationTemplateService : AccountsServiceBase, IInspectionChecklistMoreInformationTemplateService
    {

        private readonly ITenantResolver _tenantResolver;
        public InspectionChecklistMoreInformationTemplateService(IAccountUnitOfWork accountUoW, IAccountsQueriesManager queriesManager, IMapper mapper, IExceptionManager exceptionManager, ITenantResolver tenantResolver) : base(accountUoW, queriesManager, mapper, exceptionManager)
        {
            _tenantResolver = tenantResolver;
        }
        private IInspectionChecklistMoreInformationTemplateCommandRepository _commands => _accountUoW.InspectionChecklistMoreInformationTemplateCommandRpository;
        private IInspectionChecklistMoreInformationTemplateQueryRepository _queries => _queriesManager.InspectionChecklistMoreInformationTemplateQueryRepository;
        private IInspectionChecklistMoreInformationTemplateDetailCR _commandsEquipmentMoreInfoDet => _accountUoW.InspectionChecklistMoreInformationTemplateDetailCR;

        public async Task<ReturnBase<UpdateInspectionChecklistMoreInformationTemplateDto>> CreateAsync(CreateInspectionChecklistMoreInformationTemplateDto input)
        {
            try
            {
                var entity = _mapper.Map<InspectionChecklistMoreInformationTemplate>(input);
                var TenantName = _tenantResolver.GetTenantName();
                entity.Tenant_ID = TenantName;
                var result = await _commands.InsertAsync(entity);
                if (!result.Succeeded) return ReturnBase<UpdateInspectionChecklistMoreInformationTemplateDto>.Fail(result.Errors);

                var saveResult = await _accountUoW.SaveAsync();
                if (!saveResult.Succeeded)
                    return ReturnBase<UpdateInspectionChecklistMoreInformationTemplateDto>.Fail(saveResult.Errors);

                return ReturnBase<UpdateInspectionChecklistMoreInformationTemplateDto>.Success(_mapper.Map<UpdateInspectionChecklistMoreInformationTemplateDto>(entity));
            }
            catch (Exception ex)
            {
                return ReturnBase<UpdateInspectionChecklistMoreInformationTemplateDto>.Fail(ex, _exceptionManager);
            }
        }

        public async Task<ReturnBase<bool>> DeleteAsync(long id)
        {
            try
            {
                var keys = new EntityKeyValueDictionary();
                keys.Add(new KeyValuePair<string, object>("Id", id));

                var deleteResult = await _commands.DeleteAsync(keys);
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

        public async Task<ReturnBase<InspectionChecklistMoreInformationTemplateDto>> GetAsync(long id)
        {
            try
            {
                var Item = await _queries.GetByIdAsync(id);
                var itemDto = _mapper.Map<InspectionChecklistMoreInformationTemplateDto>(Item);
                return new ReturnBase<InspectionChecklistMoreInformationTemplateDto>(itemDto, true);
            }
            catch (Exception ex)
            {
                return ReturnBase<InspectionChecklistMoreInformationTemplateDto>.Fail(ex, _exceptionManager);
            }
        }


        public async Task<ReturnBase<List<InspectionChecklistMoreInformationTemplateDto>>> GetListAsync()
        {
            try
            {
                var list = await _queries.GetAllAsync();

                return ReturnBase<List<InspectionChecklistMoreInformationTemplateDto>>.Success(_mapper.Map<List<InspectionChecklistMoreInformationTemplateDto>>(list.Result));
            }
            catch (Exception ex)
            {
                return ReturnBase<List<InspectionChecklistMoreInformationTemplateDto>>.Fail(ex, _exceptionManager);
            }
        }

        public async Task<ReturnBase<List<InspectionChecklistMoreInformationTemplateDtoByInclude>>> GetListByIncludeAsync(SqlQueryOptions sqlQueryOptions)
        {
            try
            {
                var list = await _queries.GetListByIncludeAsync(sqlQueryOptions);

                return ReturnBase<List<InspectionChecklistMoreInformationTemplateDtoByInclude>>.Success(_mapper.Map<List<InspectionChecklistMoreInformationTemplateDtoByInclude>>(list));
            }
            catch (Exception ex)
            {
                return ReturnBase<List<InspectionChecklistMoreInformationTemplateDtoByInclude>>.Fail(ex, _exceptionManager);
            }
        }
        public async Task<ReturnBase<UpdateInspectionChecklistMoreInformationTemplateDto>> UpdateAsync(long id, UpdateInspectionChecklistMoreInformationTemplateDto updateDto)
        {

            try
            {
                var entity = await _queriesManager.InspectionChecklistMoreInformationTemplateQueryRepository.GetByIdAsync(id);
                var TenantName = _tenantResolver.GetTenantName();
                entity.Tenant_ID = TenantName;
                if (entity is null)
                {
                    var error = new ReturnBaseError
                    {
                        ErrorCode = "404",
                        ErrorMessage = "Equipments More Information Not Found"
                    };
                    var listOfErrors = new List<ReturnBaseError>() { error };
                    return ReturnBase<UpdateInspectionChecklistMoreInformationTemplateDto>.Fail(listOfErrors);
                }
                // Update request fields

                _mapper.Map(updateDto, entity);

                entity.InspectionChecklistMoreInformationTemplateDetails = null;

                var updateResult = await _commands.UpdateAsync(entity);
                if (!updateResult.Succeeded)

                    return ReturnBase<UpdateInspectionChecklistMoreInformationTemplateDto>.Fail(updateResult.Errors);

                List<InspectionChecklistMoreInformationTemplateDetail> finalDet = new List<InspectionChecklistMoreInformationTemplateDetail>();

                // Update details
                foreach (var detail in updateDto.InspectionChecklistMoreInformationTemplateDetails)
                {
                    detail.InspectionChecklistMoreInformationTemplateId = entity.Id;

                    detail.Tenant_ID = TenantName;


                    var existing = await _queriesManager.InspectionChecklistMoreInformationTemplateDetailQueryRepository.GetByIdAsync(detail.Id);


                    if (existing == null)
                    {
                        var insdetails = _mapper.Map<InspectionChecklistMoreInformationTemplateDetail>(detail);
                        var insertResultdet = await _commandsEquipmentMoreInfoDet.InsertAsync(insdetails);
                        if (!insertResultdet.Succeeded)
                        {
                            return ReturnBase<UpdateInspectionChecklistMoreInformationTemplateDto>.Fail(insertResultdet.Errors);
                        }

                        finalDet.Add(insdetails);

                    }
                    else
                    {
                        //var HaveChecklist = await _queriesManager.InspectionChecklistMoreInformationTemplateDetailQueryRepository.GetByIdAsync(detail.Id).Status;
                        //var HaveDataRowSheet = await _queriesManager.InspectionChecklistMoreInformationTemplateDetailQueryRepository.GetByIdAsync(detail.Id);
                        //var HaveCertificate = await _queriesManager.InspectionChecklistMoreInformationTemplateDetailQueryRepository.GetByIdAsync(detail.Id);
                        //entity.EquipmentTypeId
                        //if (HaveChecklist== detail.)
                        //{

                        //}
                        _mapper.Map(detail, existing);
                        var updateResultdet = await _commandsEquipmentMoreInfoDet.UpdateAsync(existing);
                        if (!updateResultdet.Succeeded)
                        {
                            return ReturnBase<UpdateInspectionChecklistMoreInformationTemplateDto>.Fail(updateResultdet.Errors);
                        }


                        finalDet.Add(existing);
                    }


                }
                var saveResult = await _accountUoW.SaveAsync();
                if (!saveResult.Succeeded)
                    return ReturnBase<UpdateInspectionChecklistMoreInformationTemplateDto>.Fail(saveResult.Errors);
                entity.InspectionChecklistMoreInformationTemplateDetails = finalDet;


                var mappedResult = _mapper.Map<UpdateInspectionChecklistMoreInformationTemplateDto>(entity);
                return ReturnBase<UpdateInspectionChecklistMoreInformationTemplateDto>.Success(mappedResult);
            }

            catch (Exception ex)
            {
                return ReturnBase<UpdateInspectionChecklistMoreInformationTemplateDto>.Fail(ex, _exceptionManager);
            }
        }
    }
}
