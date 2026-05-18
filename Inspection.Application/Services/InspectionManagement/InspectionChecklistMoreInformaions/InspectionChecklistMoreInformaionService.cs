using AutoMapper;
using Inspection.Application.Contracts.Dto.InspectionManagement.InspectionChecklists;
using Inspection.Application.Contracts.Managers;
using Inspection.Application.Contracts.Repositories.Command.InspectionManagement.InspectionChecklistMoreInformationDetails;
using Inspection.Application.Contracts.Repositories.Command.InspectionManagement.InspectionChecklistMoreInformations;
using Inspection.Application.Contracts.Repositories.Query.InspectionManagement.InspectionChecklistMoreInformations;
using Inspection.Application.Contracts.Services.InspectionManagement.InspectionChecklistMoreInformations;
using Inspection.Application.Contracts.UnitOfWork;
using Inspection.Application.Services.ServicesBase;
using Inspection.Domain.Models.InspectionManagement.InspectionChecklistMoreInformationDetails;
using Inspection.Domain.Models.InspectionManagement.InspectionChecklistMoreInformations;
using NDS.Shared.Application.DataQuery;
using NDS.Shared.Application.Multitenant;
using NDS.Shared.Application.SharedModels;
using NDS.Shared.Kernel.BaseReturnTypes;
using NDS.Shared.Kernel.Exceptions;

namespace Inspection.Application.Services.InspectionManagement.InspectionChecklistMoreInformations
{

    public class InspectionChecklistMoreInformationService : AccountsServiceBase, IInspectionChecklistMoreInformationService
    {
        private readonly ITenantResolver _tenantResolver;
        public InspectionChecklistMoreInformationService(IAccountUnitOfWork accountUoW, IAccountsQueriesManager queriesManager, IMapper mapper, IExceptionManager exceptionManager, ITenantResolver tenantResolver) : base(accountUoW, queriesManager, mapper, exceptionManager)
        {
            _tenantResolver = tenantResolver;
        }
        private IInspectionChecklistMoreInformationCommandRepository _commands => _accountUoW.InspectionChecklistMoreInformationCommandRepository;
        private IInspectionChecklistMoreInformationQR _queries => _queriesManager.InspectionChecklistMoreInformationQueryRepository;
        private IInspectionChecklistMoreInformationDetailCommandRepository _commandsEquipmentMoreInfoDet => _accountUoW.InspectionChecklistMoreInformationDetailCommandRepository;

        public async Task<ReturnBase<UpdateInspectionChecklistMoreInformationDto>> CreateAsync(CreateInspectionChecklistMoreInformationDto input)
        {
            try
            {
                var entity = _mapper.Map<InspectionChecklistMoreInformation>(input);
                var TenantName = _tenantResolver.GetTenantName();
                entity.Tenant_ID = TenantName;
                var result = await _commands.InsertAsync(entity);
                if (!result.Succeeded) return ReturnBase<UpdateInspectionChecklistMoreInformationDto>.Fail(result.Errors);

                var saveResult = await _accountUoW.SaveAsync();
                if (!saveResult.Succeeded)
                    return ReturnBase<UpdateInspectionChecklistMoreInformationDto>.Fail(saveResult.Errors);

                return ReturnBase<UpdateInspectionChecklistMoreInformationDto>.Success(_mapper.Map<UpdateInspectionChecklistMoreInformationDto>(entity));
            }
            catch (Exception ex)
            {
                return ReturnBase<UpdateInspectionChecklistMoreInformationDto>.Fail(ex, _exceptionManager);
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

        public async Task<ReturnBase<InspectionChecklistMoreInformationDto>> GetAsync(long id)
        {
            try
            {
                var Item = await _queries.GetByIdAsync(id);
                var itemDto = _mapper.Map<InspectionChecklistMoreInformationDto>(Item);
                return new ReturnBase<InspectionChecklistMoreInformationDto>(itemDto, true);
            }
            catch (Exception ex)
            {
                return ReturnBase<InspectionChecklistMoreInformationDto>.Fail(ex, _exceptionManager);
            }
        }


        public async Task<ReturnBase<List<InspectionChecklistMoreInformationDto>>> GetListAsync()
        {
            try
            {
                var list = await _queries.GetAllAsync();

                return ReturnBase<List<InspectionChecklistMoreInformationDto>>.Success(_mapper.Map<List<InspectionChecklistMoreInformationDto>>(list.Result));
            }
            catch (Exception ex)
            {
                return ReturnBase<List<InspectionChecklistMoreInformationDto>>.Fail(ex, _exceptionManager);
            }
        }

        public async Task<ReturnBase<List<InspectionChecklistMoreInformationDtoByInclude>>> GetListByIncludeAsync(SqlQueryOptions sqlQueryOptions)
        {
            try
            {
                var list = await _queries.GetListByIncludeAsync(sqlQueryOptions);

                return ReturnBase<List<InspectionChecklistMoreInformationDtoByInclude>>.Success(_mapper.Map<List<InspectionChecklistMoreInformationDtoByInclude>>(list));
            }
            catch (Exception ex)
            {
                return ReturnBase<List<InspectionChecklistMoreInformationDtoByInclude>>.Fail(ex, _exceptionManager);
            }
        }
        public async Task<ReturnBase<UpdateInspectionChecklistMoreInformationDto>> UpdateAsync(long id, UpdateInspectionChecklistMoreInformationDto updateDto)
        {

            try
            {
                var entity = await _queriesManager.InspectionChecklistMoreInformationQueryRepository.GetByIdAsync(id);
                var TenantName = _tenantResolver.GetTenantName();
                entity.Tenant_ID = TenantName;
                if (entity is null)
                {
                    var error = new ReturnBaseError
                    {
                        ErrorCode = "404",
                        ErrorMessage = "Inspection Checklist More Information Not Found"
                    };
                    var listOfErrors = new List<ReturnBaseError>() { error };
                    return ReturnBase<UpdateInspectionChecklistMoreInformationDto>.Fail(listOfErrors);
                }
                // Update request fields

                _mapper.Map(updateDto, entity);

                entity.InspectionChecklistMoreInformationDetails = null;

                var updateResult = await _commands.UpdateAsync(entity);
                if (!updateResult.Succeeded)

                    return ReturnBase<UpdateInspectionChecklistMoreInformationDto>.Fail(updateResult.Errors);

                List<InspectionChecklistMoreInformationDetail> finalDet = new List<InspectionChecklistMoreInformationDetail>();

                // Update details
                foreach (var detail in updateDto.InspectionChecklistMoreInformationDetails)
                {
                    detail.InspectionChecklistMoreInformationId = entity.Id;

                    detail.Tenant_ID = TenantName;


                    var existing = await _queriesManager.InspectionChecklistMoreInformationDetailQueryRepository.GetByIdAsync(detail.Id);


                    if (existing == null)
                    {
                        var insdetails = _mapper.Map<InspectionChecklistMoreInformationDetail>(detail);
                        var insertResultdet = await _commandsEquipmentMoreInfoDet.InsertAsync(insdetails);
                        if (!insertResultdet.Succeeded)
                        {
                            return ReturnBase<UpdateInspectionChecklistMoreInformationDto>.Fail(insertResultdet.Errors);
                        }

                        finalDet.Add(insdetails);

                    }
                    else
                    {
                        //var HaveChecklist = await _queriesManager.InspectionChecklistMoreInformationDetailQueryRepository.GetByIdAsync(detail.Id).Status;
                        //var HaveDataRowSheet = await _queriesManager.InspectionChecklistMoreInformationDetailQueryRepository.GetByIdAsync(detail.Id);
                        //var HaveCertificate = await _queriesManager.InspectionChecklistMoreInformationDetailQueryRepository.GetByIdAsync(detail.Id);
                        //entity.EquipmentTypeId
                        //if (HaveChecklist== detail.)
                        //{

                        //}
                        _mapper.Map(detail, existing);
                        var updateResultdet = await _commandsEquipmentMoreInfoDet.UpdateAsync(existing);
                        if (!updateResultdet.Succeeded)
                        {
                            return ReturnBase<UpdateInspectionChecklistMoreInformationDto>.Fail(updateResultdet.Errors);
                        }


                        finalDet.Add(existing);
                    }


                }
                var saveResult = await _accountUoW.SaveAsync();
                if (!saveResult.Succeeded)
                    return ReturnBase<UpdateInspectionChecklistMoreInformationDto>.Fail(saveResult.Errors);
                entity.InspectionChecklistMoreInformationDetails = finalDet;


                var mappedResult = _mapper.Map<UpdateInspectionChecklistMoreInformationDto>(entity);
                return ReturnBase<UpdateInspectionChecklistMoreInformationDto>.Success(mappedResult);
            }

            catch (Exception ex)
            {
                return ReturnBase<UpdateInspectionChecklistMoreInformationDto>.Fail(ex, _exceptionManager);
            }
        }
    }
}
