using AutoMapper;
using Inspection.Application.Contracts.Dto.InspectionManagement.InspectionChecklists;
using Inspection.Application.Contracts.Managers;
using Inspection.Application.Contracts.Repositories.Command.InspectionManagement.InspectionChecklistMoreInformationDetails;
using Inspection.Application.Contracts.Repositories.Command.InspectionManagement.InspectionChecklistMoreInformations;
using Inspection.Application.Contracts.Repositories.Command.InspectionManagement.InspectionChecklists;
using Inspection.Application.Contracts.Repositories.Query.InspectionManagement.InspectionChecklistMoreInformationDetails;
using Inspection.Application.Contracts.Repositories.Query.InspectionManagement.InspectionChecklistMoreInformations;
using Inspection.Application.Contracts.Repositories.Query.InspectionManagement.InspectionChecklists;
using Inspection.Application.Contracts.Services.InspectionManagement.InspectionChecklists;
using Inspection.Application.Contracts.UnitOfWork;
using Inspection.Application.Services.ServicesBase;
using Inspection.Domain.Models.InspectionManagement.InspectionChecklists;
using NDS.Shared.Application.DataQuery;
using NDS.Shared.Application.Multitenant;
using NDS.Shared.Application.SharedModels;
using NDS.Shared.Kernel.BaseReturnTypes;
using NDS.Shared.Kernel.Exceptions;

namespace Inspection.Application.Services.InspectionManagement.InspectionChecklists
{
    internal class InspectionChecklistService : AccountsServiceBase, IInspectionChecklistService
    {
        private readonly ITenantResolver _tenantResolver;

        public InspectionChecklistService(IAccountUnitOfWork accountUoW, IAccountsQueriesManager queriesManager, IMapper mapper, IExceptionManager exceptionManager, ITenantResolver tenantResolver) : base(accountUoW, queriesManager, mapper, exceptionManager)
        {
            _tenantResolver = tenantResolver;

        }

        private IInspectionChecklistCommandRepository _commands => _accountUoW.InspectionChecklistCommandRepository;
        private IInspectionChecklistsQueryRepository _queries => _queriesManager.InspectionChecklistQueryRepository;
        private IInspectionChecklistMoreInformationDetailQR _MoreInfoDetQueries => _queriesManager.InspectionChecklistMoreInformationDetailQueryRepository;
        private IInspectionChecklistMoreInformationQR _MoreInfoQueries => _queriesManager.InspectionChecklistMoreInformationQueryRepository;

        private IInspectionChecklistMoreInformationCommandRepository _commandsInspectionChecklistsMoreInformations => _accountUoW.InspectionChecklistMoreInformationCommandRepository;
        private IInspectionChecklistMoreInformationDetailCommandRepository _commandsInspectionChecklistsMoreInformationDetail => _accountUoW.InspectionChecklistMoreInformationDetailCommandRepository;


        public async Task<ReturnBase<InspectionChecklistDto>> GetAsync(long id)
        {
            var Exobj = await _queries.GetByIdAsync(id);
            var obj = _mapper.Map<InspectionChecklistDto>(Exobj);
            if (obj is not null)
            {

                return new ReturnBase<InspectionChecklistDto>(obj, true);
            }
            return ReturnBase<InspectionChecklistDto>.Fail();

        }

        public async Task<ReturnBase<List<InspectionChecklistDtoByInclude>>> GetListByIncludeAsync(SqlQueryOptions sqlQueryOptions)
        {
            try
            {
                var list = await _queries.GetListByIncludeAsync(sqlQueryOptions);

                return ReturnBase<List<InspectionChecklistDtoByInclude>>.Success(_mapper.Map<List<InspectionChecklistDtoByInclude>>(list));
            }
            catch (Exception ex)
            {
                return ReturnBase<List<InspectionChecklistDtoByInclude>>.Fail(ex, _exceptionManager);
            }
        }
        public async Task<ReturnBase<List<InspectionChecklistDto>>> GetListAsync()
        {
            try
            {
                var result = await _queries.GetAllAsync();
                if (!result.Succeeded)
                    return ReturnBase<List<InspectionChecklistDto>>.Fail(result.Errors);

                var dtoList = _mapper.Map<List<InspectionChecklistDto>>(result.Result);
                return ReturnBase<List<InspectionChecklistDto>>.Success(dtoList);
            }
            catch (Exception ex)
            {
                return ReturnBase<List<InspectionChecklistDto>>.Fail(ex, _exceptionManager);
            }
        }
        public async Task<ReturnBase<UpdateInspectionChecklistDto>> CreateAsync(CreateInspectionChecklistDto dto)
        {
            try
            {
                var entity = _mapper.Map<InspectionChecklist>(dto);
                var TenantName = _tenantResolver.GetTenantName();
                entity.Tenant_ID = TenantName;
                var result = await _commands.InsertAsync(entity);
                if (!result.Succeeded)
                    return ReturnBase<UpdateInspectionChecklistDto>.Fail(result.Errors);

                var save = await _accountUoW.SaveAsync();
                if (!save.Succeeded)
                    return ReturnBase<UpdateInspectionChecklistDto>.Fail(save.Errors);

                // Return mapped result

                var dd = _mapper.Map<UpdateInspectionChecklistDto>(entity);
                return ReturnBase<UpdateInspectionChecklistDto>.Success(dd);
            }
            catch (Exception ex)
            {
                return ReturnBase<UpdateInspectionChecklistDto>.Fail(ex, _exceptionManager);
            }
        }

        public async Task<ReturnBase<UpdateInspectionChecklistDto>> UpdateAsync(long id, UpdateInspectionChecklistDto dto)
        {
            try
            {
                var entity = await _queries.GetByIdAsync(id);

                if (entity == null) return ReturnBase<UpdateInspectionChecklistDto>.Fail();

                _mapper.Map(dto, entity);
                var TenantName = _tenantResolver.GetTenantName();
                entity.Tenant_ID = TenantName;
                var updateResult = await _commands.UpdateAsync(entity);
                if (!updateResult.Succeeded)
                    return ReturnBase<UpdateInspectionChecklistDto>.Fail(updateResult.Errors);

                foreach (var infoDto in dto.InspectionChecklistMoreInformations)
                {
                    var infoEntity = entity.InspectionChecklistMoreInformations
                        .FirstOrDefault(m => m.Id == infoDto.Id);

                    if (infoEntity == null) continue;

                    foreach (var detailDto in infoDto.InspectionChecklistMoreInformationDetails)
                    {
                        var detailEntity = infoEntity.InspectionChecklistMoreInformationDetails
                            .FirstOrDefault(d => d.Id == detailDto.Id);

                        if (detailEntity == null) continue;

                        // Only update KeyValue in details
                        detailEntity.KeyValue = detailDto.KeyValue;
                        var fin = await _commandsInspectionChecklistsMoreInformationDetail.UpdateAsync(detailEntity);
                        if (!fin.Succeeded)
                            return ReturnBase<UpdateInspectionChecklistDto>.Fail(fin.Errors);
                    }
                }
                var saveResult = await _accountUoW.SaveAsync();
                if (!saveResult.Succeeded) return ReturnBase<UpdateInspectionChecklistDto>.Fail(saveResult.Errors);

                return ReturnBase<UpdateInspectionChecklistDto>.Success(_mapper.Map<UpdateInspectionChecklistDto>(entity));
            }
            catch (Exception ex)
            {
                return ReturnBase<UpdateInspectionChecklistDto>.Fail(ex, _exceptionManager);
            }
        }



        public async Task<ReturnBase<bool>> DeleteAsync(long id)
        {
            try
            {
                var keys = new EntityKeyValueDictionary();
                keys.Add(new KeyValuePair<string, object>("Id", id));

                var deleteResult = await _accountUoW.InspectionChecklistCommandRepository.DeleteAsync(keys);
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


    }
}
