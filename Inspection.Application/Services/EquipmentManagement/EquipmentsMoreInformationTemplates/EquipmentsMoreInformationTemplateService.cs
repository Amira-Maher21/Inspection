using AutoMapper;
using Inspection.Application.Contracts.Dto.EquipmentManagement.EquipmentsMoreInformationTemplates;
using Inspection.Application.Contracts.Managers;
using Inspection.Application.Contracts.Repositories.Command.EquipmentManagement.EquipmentsMoreInformationTemplateDetails;
using Inspection.Application.Contracts.Repositories.Command.EquipmentManagement.EquipmentsMoreInformationTemplateTemplateTemplates;
using Inspection.Application.Contracts.Repositories.Query.EquipmentManagement.EquipmentsMoreInformationTemplateTemplates;
using Inspection.Application.Contracts.Services.EquipmentManagement.EquipmentsMoreInformationTemplateTemplates;
using Inspection.Application.Contracts.UnitOfWork;
using Inspection.Application.Services.ServicesBase;
using Inspection.Domain.Models.EquipmentManagement.EquipmentsMoreInformationTemplateDetails;
using Inspection.Domain.Models.EquipmentManagement.EquipmentsMoreInfoTemplates;
using NDS.Shared.Application.DataQuery;
using NDS.Shared.Application.Multitenant;
using NDS.Shared.Application.SharedModels;
using NDS.Shared.Kernel.BaseReturnTypes;
using NDS.Shared.Kernel.Exceptions;

namespace Inspection.Application.Services.EquipmentManagement.EquipmentsMoreInformationTemplates
{
    public class EquipmentsMoreInformationTemplateService : AccountsServiceBase, IEquipmentsMoreInformationTemplateService
    {
        private readonly ITenantResolver _tenantResolver;
        public EquipmentsMoreInformationTemplateService(IAccountUnitOfWork accountUoW, IAccountsQueriesManager queriesManager, IMapper mapper, IExceptionManager exceptionManager, ITenantResolver tenantResolver) : base(accountUoW, queriesManager, mapper, exceptionManager)
        {
            _tenantResolver = tenantResolver;
        }
        private IEquipmentsMoreInformationTemplateCommandRepository _commands => _accountUoW.EquipmentsMoreInformationTemplateCommandRepository;
        private IEquipmentsMoreInformationTemplateQueryRepository _queries => _queriesManager.EquipmentsMoreInformationTemplateQueryRepository;
        private IEquipmentsMoreInformationTemplateDetailCommandRepository _commandsEquipmentMoreInfoDet => _accountUoW.EquipmentsMoreInformationTemplateDetailCommandRepository;

        //

        public async Task<ReturnBase<IEnumerable<EquipmentsMoreInformationTemplateReturnSearchDto>>> Search(SqlQueryOptions sqlQueryOptions)
        {
            try
            {
                var getResult = await _queries.Search(sqlQueryOptions);

                if (!getResult.Succeeded)
                    return ReturnBase<IEnumerable<EquipmentsMoreInformationTemplateReturnSearchDto>>.Fail(getResult.Errors);

                return ReturnBase<IEnumerable<EquipmentsMoreInformationTemplateReturnSearchDto>>.Success(getResult.Result);
            }
            catch (Exception ex)
            {
                return ReturnBase<IEnumerable<EquipmentsMoreInformationTemplateReturnSearchDto>>.Fail(ex, _exceptionManager);
            }
        }

        public async Task<ReturnBase<UpdateEquipmentsMoreInformationTemplateDto>> CreateAsync(CreateEquipmentsMoreInformationTemplateDto input)
        {
            try
            {
                var entity = _mapper.Map<EquipmentsMoreInformationTemplate>(input);
                var TenantName = _tenantResolver.GetTenantName();
                entity.Tenant_ID = TenantName;
                var result = await _commands.InsertAsync(entity);
                if (!result.Succeeded) return ReturnBase<UpdateEquipmentsMoreInformationTemplateDto>.Fail(result.Errors);

                var saveResult = await _accountUoW.SaveAsync();
                if (!saveResult.Succeeded)
                    return ReturnBase<UpdateEquipmentsMoreInformationTemplateDto>.Fail(saveResult.Errors);

                return ReturnBase<UpdateEquipmentsMoreInformationTemplateDto>.Success(_mapper.Map<UpdateEquipmentsMoreInformationTemplateDto>(entity));
            }
            catch (Exception ex)
            {
                return ReturnBase<UpdateEquipmentsMoreInformationTemplateDto>.Fail(ex, _exceptionManager);
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

        public async Task<ReturnBase<EquipmentsMoreInformationTemplateDto>> GetAsync(long id)
        {
            try
            {
                var Item = await _queries.GetByIdAsync(id);
                var itemDto = _mapper.Map<EquipmentsMoreInformationTemplateDto>(Item);
                return new ReturnBase<EquipmentsMoreInformationTemplateDto>(itemDto, true);
            }
            catch (Exception ex)
            {
                return ReturnBase<EquipmentsMoreInformationTemplateDto>.Fail(ex, _exceptionManager);
            }
        }


        public async Task<ReturnBase<List<EquipmentsMoreInformationTemplateDto>>> GetListAsync()
        {
            try
            {
                var list = await _queries.GetAllAsync();

                return ReturnBase<List<EquipmentsMoreInformationTemplateDto>>.Success(_mapper.Map<List<EquipmentsMoreInformationTemplateDto>>(list.Result));
            }
            catch (Exception ex)
            {
                return ReturnBase<List<EquipmentsMoreInformationTemplateDto>>.Fail(ex, _exceptionManager);
            }
        }

        //public async Task<ReturnBase<List<EquipmentsMoreInformationTemplateDtoByInclude>>> GetListByIncludeAsync(SqlQueryOptions sqlQueryOptions)
        //{
        //    try
        //    {
        //        var list = await _queries.GetListByIncludeAsync(sqlQueryOptions);

        //        return ReturnBase<List<EquipmentsMoreInformationTemplateDtoByInclude>>.Success(_mapper.Map<List<EquipmentsMoreInformationTemplateDtoByInclude>>(list));
        //    }
        //    catch (Exception ex)
        //    {
        //        return ReturnBase<List<EquipmentsMoreInformationTemplateDtoByInclude>>.Fail(ex, _exceptionManager);
        //    }
        //}
        public async Task<ReturnBase<UpdateEquipmentsMoreInformationTemplateDto>> UpdateAsync(long id, UpdateEquipmentsMoreInformationTemplateDto updateDto)
        {

            try
            {
                var entity = await _queriesManager.EquipmentsMoreInformationTemplateQueryRepository.GetByIdAsync(id);
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
                    return ReturnBase<UpdateEquipmentsMoreInformationTemplateDto>.Fail(listOfErrors);
                }
                // Update request fields

                _mapper.Map(updateDto, entity);

                entity.EquipmentsMoreInformationTemplateDetails = null;

                var updateResult = await _commands.UpdateAsync(entity);
                if (!updateResult.Succeeded)

                    return ReturnBase<UpdateEquipmentsMoreInformationTemplateDto>.Fail(updateResult.Errors);

                List<EquipmentsMoreInformationTemplateDetail> finalDet = new List<EquipmentsMoreInformationTemplateDetail>();

                // Update details
                foreach (var detail in updateDto.EquipmentsMoreInformationTemplateDetails)
                {
                    detail.EquipmentsMoreInformationTemplateId = entity.Id;

                    detail.Tenant_ID = TenantName;


                    var existing = await _queriesManager.EquipmentsMoreInformationTemplateDetailQueryRepository.GetByIdAsync(detail.Id);


                    if (existing == null)
                    {
                        var insdetails = _mapper.Map<EquipmentsMoreInformationTemplateDetail>(detail);
                        var insertResultdet = await _commandsEquipmentMoreInfoDet.InsertAsync(insdetails);
                        if (!insertResultdet.Succeeded)
                        {
                            return ReturnBase<UpdateEquipmentsMoreInformationTemplateDto>.Fail(insertResultdet.Errors);
                        }

                        finalDet.Add(insdetails);

                    }
                    else
                    {
                        //var HaveChecklist = await _queriesManager.EquipmentsMoreInformationTemplateDetailQueryRepository.GetByIdAsync(detail.Id).Status;
                        //var HaveDataRowSheet = await _queriesManager.EquipmentsMoreInformationTemplateDetailQueryRepository.GetByIdAsync(detail.Id);
                        //var HaveCertificate = await _queriesManager.EquipmentsMoreInformationTemplateDetailQueryRepository.GetByIdAsync(detail.Id);
                        //entity.EquipmentTypeId
                        //if (HaveChecklist== detail.)
                        //{

                        //}
                        _mapper.Map(detail, existing);
                        var updateResultdet = await _commandsEquipmentMoreInfoDet.UpdateAsync(existing);
                        if (!updateResultdet.Succeeded)
                        {
                            return ReturnBase<UpdateEquipmentsMoreInformationTemplateDto>.Fail(updateResultdet.Errors);
                        }


                        finalDet.Add(existing);
                    }


                }
                var saveResult = await _accountUoW.SaveAsync();
                if (!saveResult.Succeeded)
                    return ReturnBase<UpdateEquipmentsMoreInformationTemplateDto>.Fail(saveResult.Errors);
                entity.EquipmentsMoreInformationTemplateDetails = finalDet;


                var mappedResult = _mapper.Map<UpdateEquipmentsMoreInformationTemplateDto>(entity);
                return ReturnBase<UpdateEquipmentsMoreInformationTemplateDto>.Success(mappedResult);
            }

            catch (Exception ex)
            {
                return ReturnBase<UpdateEquipmentsMoreInformationTemplateDto>.Fail(ex, _exceptionManager);
            }
        }
    }
}
