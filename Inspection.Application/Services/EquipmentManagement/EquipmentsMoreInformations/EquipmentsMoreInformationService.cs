using AutoMapper;
using Inspection.Application.Contracts.Dto.EquipmentManagement.EquipmentsMoreInformations;
using Inspection.Application.Contracts.Managers;
using Inspection.Application.Contracts.Repositories.Command.EquipmentManagement.EquipmentsMoreInformationDetails;
using Inspection.Application.Contracts.Repositories.Command.EquipmentManagement.EquipmentsMoreInformations;

using Inspection.Application.Contracts.Repositories.Query.EquipmentManagement.EquipmentsMoreInformations;
using Inspection.Application.Contracts.Services.EquipmentManagement.EquipmentsMoreInformations;
using Inspection.Application.Contracts.UnitOfWork;
using Inspection.Application.Services.ServicesBase;
using Inspection.Domain.Models.EquipmentManagement.EquipmentsMoreInfo;
using Inspection.Domain.Models.EquipmentManagement.EquipmentsMoreInformationDetails;

using NDS.Shared.Application.DataQuery;
using NDS.Shared.Application.Multitenant;
using NDS.Shared.Application.SharedModels;
using NDS.Shared.Kernel.BaseReturnTypes;
using NDS.Shared.Kernel.Exceptions;

namespace Inspection.Application.Services.EquipmentManagement.EquipmentsMoreInformations
{

    public class EquipmentsMoreInformationService : AccountsServiceBase, IEquipmentsMoreInformationService
    {
        private readonly ITenantResolver _tenantResolver;
        public EquipmentsMoreInformationService(IAccountUnitOfWork accountUoW, IAccountsQueriesManager queriesManager, IMapper mapper, IExceptionManager exceptionManager, ITenantResolver tenantResolver) : base(accountUoW, queriesManager, mapper, exceptionManager)
        {
            _tenantResolver = tenantResolver;
        }
        private IEquipmentsMoreInformationCommandRepository _commands => _accountUoW.EquipmentsMoreInformation;
        private IEquipmentsMoreInformationQueryRepository _queries => _queriesManager.EquipmentsMoreInformation;
        private IEquipmentsMoreInformationDetailCommandRepository _commandsEquipmentMoreInfoDet => _accountUoW.EquipmentsMoreInformationDetailCommandRepository;

        public async Task<ReturnBase<UpdateEquipmentsMoreInformationDto>> CreateAsync(CreateEquipmentsMoreInformationDto input)
        {
            try
            {
                var entity = _mapper.Map<EquipmentsMoreInformation>(input);
                var TenantName = _tenantResolver.GetTenantName();
                entity.Tenant_ID = TenantName;
                var result = await _commands.InsertAsync(entity);
                if (!result.Succeeded) return ReturnBase<UpdateEquipmentsMoreInformationDto>.Fail(result.Errors);

                var saveResult = await _accountUoW.SaveAsync();
                if (!saveResult.Succeeded)
                    return ReturnBase<UpdateEquipmentsMoreInformationDto>.Fail(saveResult.Errors);

                return ReturnBase<UpdateEquipmentsMoreInformationDto>.Success(_mapper.Map<UpdateEquipmentsMoreInformationDto>(entity));
            }
            catch (Exception ex)
            {
                return ReturnBase<UpdateEquipmentsMoreInformationDto>.Fail(ex, _exceptionManager);
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

        public async Task<ReturnBase<EquipmentsMoreInformationDto>> GetAsync(long id)
        {
            try
            {
                var Item = await _queries.GetByIdAsync(id);
                var itemDto = _mapper.Map<EquipmentsMoreInformationDto>(Item);
                return new ReturnBase<EquipmentsMoreInformationDto>(itemDto, true);
            }
            catch (Exception ex)
            {
                return ReturnBase<EquipmentsMoreInformationDto>.Fail(ex, _exceptionManager);
            }
        }


        public async Task<ReturnBase<List<EquipmentsMoreInformationDto>>> GetListAsync()
        {
            try
            {
                var list = await _queries.GetAllAsync();

                return ReturnBase<List<EquipmentsMoreInformationDto>>.Success(_mapper.Map<List<EquipmentsMoreInformationDto>>(list.Result));
            }
            catch (Exception ex)
            {
                return ReturnBase<List<EquipmentsMoreInformationDto>>.Fail(ex, _exceptionManager);
            }
        }

        public async Task<ReturnBase<List<EquipmentsMoreInformationIncludeDto>>> GetListByIncludeAsync(SqlQueryOptions sqlQueryOptions)
        {
            try
            {
                var list = await _queries.GetListByIncludeAsync(sqlQueryOptions);

                return ReturnBase<List<EquipmentsMoreInformationIncludeDto>>.Success(_mapper.Map<List<EquipmentsMoreInformationIncludeDto>>(list));
            }
            catch (Exception ex)
            {
                return ReturnBase<List<EquipmentsMoreInformationIncludeDto>>.Fail(ex, _exceptionManager);
            }
        }
        public async Task<ReturnBase<UpdateEquipmentsMoreInformationDto>> UpdateAsync(long id, UpdateEquipmentsMoreInformationDto updateDto)
        {

            try
            {
                var entity = await _queriesManager.EquipmentsMoreInformation.GetByIdAsync(id);
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
                    return ReturnBase<UpdateEquipmentsMoreInformationDto>.Fail(listOfErrors);
                }
                // Update request fields

                _mapper.Map(updateDto, entity);

                entity.EquipmentsMoreInformationDetails = null;

                var updateResult = await _commands.UpdateAsync(entity);
                if (!updateResult.Succeeded)

                    return ReturnBase<UpdateEquipmentsMoreInformationDto>.Fail(updateResult.Errors);

                List<EquipmentsMoreInformationDetail> finalDet = new List<EquipmentsMoreInformationDetail>();

                // Update details
                foreach (var detail in updateDto.EquipmentsMoreInformationDetails)
                {
                    detail.EquipmentsMoreInformationId = entity.Id;

                    detail.Tenant_ID = TenantName;


                    var existing = await _queriesManager.EquipmentsMoreInformationDetailQueryRepository.GetByIdAsync(detail.Id);


                    if (existing == null)
                    {
                        var insdetails = _mapper.Map<EquipmentsMoreInformationDetail>(detail);
                        var insertResultdet = await _commandsEquipmentMoreInfoDet.InsertAsync(insdetails);
                        if (!insertResultdet.Succeeded)
                        {
                            return ReturnBase<UpdateEquipmentsMoreInformationDto>.Fail(insertResultdet.Errors);
                        }

                        finalDet.Add(insdetails);

                    }
                    else
                    {
                        //var HaveChecklist = await _queriesManager.EquipmentsMoreInformationDetailQueryRepository.GetByIdAsync(detail.Id).Status;
                        //var HaveDataRowSheet = await _queriesManager.EquipmentsMoreInformationDetailQueryRepository.GetByIdAsync(detail.Id);
                        //var HaveCertificate = await _queriesManager.EquipmentsMoreInformationDetailQueryRepository.GetByIdAsync(detail.Id);
                        //entity.EquipmentTypeId
                        //if (HaveChecklist== detail.)
                        //{

                        //}
                        _mapper.Map(detail, existing);
                        var updateResultdet = await _commandsEquipmentMoreInfoDet.UpdateAsync(existing);
                        if (!updateResultdet.Succeeded)
                        {
                            return ReturnBase<UpdateEquipmentsMoreInformationDto>.Fail(updateResultdet.Errors);
                        }


                        finalDet.Add(existing);
                    }


                }
                var saveResult = await _accountUoW.SaveAsync();
                if (!saveResult.Succeeded)
                    return ReturnBase<UpdateEquipmentsMoreInformationDto>.Fail(saveResult.Errors);
                entity.EquipmentsMoreInformationDetails = finalDet;


                var mappedResult = _mapper.Map<UpdateEquipmentsMoreInformationDto>(entity);
                return ReturnBase<UpdateEquipmentsMoreInformationDto>.Success(mappedResult);
            }

            catch (Exception ex)
            {
                return ReturnBase<UpdateEquipmentsMoreInformationDto>.Fail(ex, _exceptionManager);
            }
        }
    }
}
