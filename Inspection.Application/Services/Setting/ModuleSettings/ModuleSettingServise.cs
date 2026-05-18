using AutoMapper;
using Inspection.Application.Contracts.Dto.Setting.ModuleSettings;
using Inspection.Application.Contracts.Managers;
using Inspection.Application.Contracts.Repositories.Command.Setting.ModuleSettings;
using Inspection.Application.Contracts.Services.Setting.ModuleSettings;
using Inspection.Application.Contracts.UnitOfWork;
using Inspection.Application.Services.ServicesBase;
using Inspection.Domain.Models.Seeting.ModuleSettings;
using NDS.Shared.Application.DataQuery;
using NDS.Shared.Application.Multitenant;
using NDS.Shared.Kernel.BaseReturnTypes;
using NDS.Shared.Kernel.Exceptions;

namespace Inspection.Application.Services.Setting.ModuleSettings
{
    public class ModuleSettingServise : AccountsServiceBase, IModuleSettingServise
    {
        public ModuleSettingServise(
      IAccountUnitOfWork accountUoW,
      IAccountsQueriesManager queriesManager,
      IMapper mapper,
      IExceptionManager exceptionManager,
      ITenantResolver tenantResolver)
      : base(accountUoW, queriesManager, mapper, exceptionManager)
        {
            _tenantResolver = tenantResolver;
        }
        private readonly ITenantResolver _tenantResolver;

        public async Task<ReturnBase<ModuleSettingDto>> Create(ModuleSettingCreateDto dto)
        {
            try
            {
                var entity = _mapper.Map<ModuleSetting>(dto);
                entity.Tenant_ID = _tenantResolver.GetTenantName();

                var insertResult = await _commands.InsertAsync(entity);
                if (!insertResult.Succeeded)
                    return ReturnBase<ModuleSettingDto>.Fail(insertResult.Errors);

                var saveResult = await _accountUoW.SaveAsync();
                if (!saveResult.Succeeded)
                    return ReturnBase<ModuleSettingDto>.Fail(saveResult.Errors);

                return ReturnBase<ModuleSettingDto>
                    .Success(_mapper.Map<ModuleSettingDto>(entity));
            }
            catch (Exception ex)
            {
                return ReturnBase<ModuleSettingDto>.Fail(ex, _exceptionManager);
            }
        }

        public async Task<ReturnBase<ModuleSettingDto>> Update(ModuleSettingUpdateDto dto)
        {
            try
            {
                var entity = await _queriesManager.ModuleSetting.GetById(dto.Id);


                if (entity is null)
                {
                    return ReturnBase<ModuleSettingDto>.Fail(new List<ReturnBaseError>
                    {
                        new() { ErrorCode = "404", ErrorMessage = "ModuleSetting Not Found" }
                    });
                }

                entity.Tenant_ID = _tenantResolver.GetTenantName();
                _mapper.Map(dto, entity);

                var updateResult = await _commands.UpdateAsync(entity);
                if (!updateResult.Succeeded)
                    return ReturnBase<ModuleSettingDto>.Fail(updateResult.Errors);

                var saveResult = await _accountUoW.SaveAsync();
                if (!saveResult.Succeeded)
                    return ReturnBase<ModuleSettingDto>.Fail(saveResult.Errors);

                return ReturnBase<ModuleSettingDto>
                    .Success(_mapper.Map<ModuleSettingDto>(entity));
            }
            catch (Exception ex)
            {
                return ReturnBase<ModuleSettingDto>.Fail(ex, _exceptionManager);
            }
        }

        public async Task<ReturnBase<ModuleSettingDto>> Delete(long id)
        {
            try
            {
                var entity = await _queriesManager.ModuleSetting
                    .GetById(id);

                if (entity is null)
                {
                    return ReturnBase<ModuleSettingDto>.Fail(new List<ReturnBaseError>
                    {
                        new() { ErrorCode = "404", ErrorMessage = "ModuleSetting Not Found" }
                    });
                }

                var mappedResult = _mapper.Map<ModuleSettingDto>(entity);

                var deleteResult = await _commands.DeleteById(id);
                if (!deleteResult.Succeeded)
                    return ReturnBase<ModuleSettingDto>.Fail(deleteResult.Errors);

                var saveResult = await _accountUoW.SaveAsync();
                if (!saveResult.Succeeded)
                    return ReturnBase<ModuleSettingDto>.Fail(saveResult.Errors);

                return ReturnBase<ModuleSettingDto>.Success(mappedResult);
            }
            catch (Exception ex)
            {
                return ReturnBase<ModuleSettingDto>.Fail(ex, _exceptionManager);
            }
        }

        public async Task<ReturnBase<ModuleSettingDto>> GetById(long id)
        {
            try
            {
                var entity = await _queriesManager.ModuleSetting
                    .GetById(id);

                if (entity is null)
                {
                    return ReturnBase<ModuleSettingDto>.Fail(new List<ReturnBaseError>
                    {
                        new() { ErrorCode = "404", ErrorMessage = "ModuleSetting Not Found" }
                    });
                }

                return ReturnBase<ModuleSettingDto>
                    .Success(_mapper.Map<ModuleSettingDto>(entity));
            }
            catch (Exception ex)
            {
                return ReturnBase<ModuleSettingDto>.Fail(ex, _exceptionManager);
            }
        }



        public async Task<ReturnBase<IEnumerable<ModuleSettingReturnSearchDto>>>
            Search(SqlQueryOptions sqlQueryOptions)
        {
            try
            {
                var result = await _queriesManager.ModuleSetting
                    .Search(sqlQueryOptions);

                if (!result.Succeeded)
                    return ReturnBase<IEnumerable<ModuleSettingReturnSearchDto>>
                        .Fail(result.Errors);

                return ReturnBase<IEnumerable<ModuleSettingReturnSearchDto>>
                    .Success(result.Result);
            }
            catch (Exception ex)
            {
                return ReturnBase<IEnumerable<ModuleSettingReturnSearchDto>>
                    .Fail(ex, _exceptionManager);
            }
        }

        private IModuleSettingCommandRepository _commands
            => _accountUoW.ModuleSetting;
    }
}
