using AutoMapper;
using Inspection.Application.Contracts.Dto.ContractingDTOs.Setup.WBSs;
using Inspection.Application.Contracts.Managers;
using Inspection.Application.Contracts.Repositories.Command.Contracting.WBSs;
using Inspection.Application.Contracts.Services.Contracting.Setup.WBSs;
using Inspection.Application.Contracts.Services.MenuManagement.SeriesF;
using Inspection.Application.Contracts.UnitOfWork;
using Inspection.Application.Services.ServicesBase;
using Inspection.Domain.Models.Contracting.Setup.WBSs;
using NDS.Shared.Application.DataQuery;
using NDS.Shared.Application.Multitenant;
using NDS.Shared.Kernel.BaseReturnTypes;
using NDS.Shared.Kernel.Exceptions;

namespace Inspection.Application.Services.Contracting.Setup.WBSs
{
    public class WBSService : AccountsServiceBase, IWBSService
    {
        private readonly ITenantResolver _tenantResolver;
        private readonly ISeriesService _seriesService;

        public WBSService(
            IAccountUnitOfWork accountUoW,
            IAccountsQueriesManager queriesManager,
            IMapper mapper,
            IExceptionManager exceptionManager,
            ITenantResolver tenantResolver,
            ISeriesService seriesService)

            : base(accountUoW, queriesManager, mapper, exceptionManager)
        {
            _tenantResolver = tenantResolver;
            _seriesService = seriesService;
        }

        private IWBSCommandRepository _commands => _accountUoW.WBS;

        public async Task<ReturnBase<WBSDto>> Create(WBSCreateDto dto)
        {
            try
            {
                var ruleError = await ValidateRules(dto.ParentWBSId);
                if (ruleError != null)
                    return ReturnBase<WBSDto>.Fail(new List<ReturnBaseError> { ruleError });

                var entity = _mapper.Map<WBS>(dto);
                entity.Tenant_ID = _tenantResolver.GetTenantName();
                entity.IsLeaf = false;



                var insert = await _commands.InsertAsync(entity);
                if (!insert.Succeeded)
                    return ReturnBase<WBSDto>.Fail(insert.Errors);

                if (dto.ParentWBSId.HasValue)
                    await SetParentIsLeaf(dto.ParentWBSId.Value, false);

                var save = await _accountUoW.SaveAsync();
                if (!save.Succeeded)
                    return ReturnBase<WBSDto>.Fail(save.Errors);

                return ReturnBase<WBSDto>.Success(_mapper.Map<WBSDto>(entity));
            }
            catch (Exception ex)
            {
                return ReturnBase<WBSDto>.Fail(ex, _exceptionManager);
            }
        }

        public async Task<ReturnBase<WBSDto>> Update(WBSUpdateDto dto)
        {
            try
            {
                var entity = await _queriesManager.WBS.GetById(dto.Id);
                if (entity == null)
                    return NotFound();

                var ruleError = await ValidateRules(dto.ParentWBSId, entity);
                if (ruleError != null)
                    return ReturnBase<WBSDto>.Fail(new List<ReturnBaseError> { ruleError });

                if (entity.ParentWBSId != dto.ParentWBSId)
                {
                    if (entity.ParentWBSId.HasValue)
                        await TryRestoreParentLeaf(entity.ParentWBSId.Value);

                    if (dto.ParentWBSId.HasValue)
                        await SetParentIsLeaf(dto.ParentWBSId.Value, false);
                }

                entity.Tenant_ID = _tenantResolver.GetTenantName();

                _mapper.Map(dto, entity);

                var update = await _commands.UpdateAsync(entity);
                if (!update.Succeeded)
                    return ReturnBase<WBSDto>.Fail(update.Errors);

                var save = await _accountUoW.SaveAsync();
                if (!save.Succeeded)
                    return ReturnBase<WBSDto>.Fail(save.Errors);

                return ReturnBase<WBSDto>.Success(_mapper.Map<WBSDto>(entity));
            }
            catch (Exception ex)
            {
                return ReturnBase<WBSDto>.Fail(ex, _exceptionManager);
            }
        }

        public async Task<ReturnBase<WBSDto>> Delete(long id)
        {
            try
            {
                var entity = await _queriesManager.WBS.GetById(id);
                if (entity == null)
                    return NotFound();

                if (await _commands.HasChildren(id))
                {
                    return ReturnBase<WBSDto>.Fail(new List<ReturnBaseError>
                    {
                        new ReturnBaseError
                        {
                            ErrorCode = "BUSINESS_RULE",
                            ErrorMessage = "Cannot delete WBS that has children."
                        }
                    });
                }

                var parentId = entity.ParentWBSId;

                var delete = await _commands.DeleteById(id);
                if (!delete.Succeeded)
                    return ReturnBase<WBSDto>.Fail(delete.Errors);

                if (parentId.HasValue)
                    await TryRestoreParentLeaf(parentId.Value);

                var save = await _accountUoW.SaveAsync();
                if (!save.Succeeded)
                    return ReturnBase<WBSDto>.Fail(save.Errors);

                return ReturnBase<WBSDto>.Success(_mapper.Map<WBSDto>(entity));
            }
            catch (Exception ex)
            {
                return ReturnBase<WBSDto>.Fail(ex, _exceptionManager);
            }
        }

        public async Task<ReturnBase<WBSDto>> GetById(long id)
        {
            try
            {
                var entity = await _queriesManager.WBS.GetById(id);
                if (entity == null)
                    return NotFound();

                return ReturnBase<WBSDto>.Success(_mapper.Map<WBSDto>(entity));
            }
            catch (Exception ex)
            {
                return ReturnBase<WBSDto>.Fail(ex, _exceptionManager);
            }
        }



        public async Task<ReturnBase<IEnumerable<WBSReturnSearchDto>>> Search(SqlQueryOptions options)
        {
            try
            {
                var result = await _queriesManager.WBS.Search(options);
                if (!result.Succeeded)
                    return ReturnBase<IEnumerable<WBSReturnSearchDto>>.Fail(result.Errors);

                return ReturnBase<IEnumerable<WBSReturnSearchDto>>.Success(result.Result);
            }
            catch (Exception ex)
            {
                return ReturnBase<IEnumerable<WBSReturnSearchDto>>.Fail(ex, _exceptionManager);
            }
        }

        private async Task SetParentIsLeaf(long parentId, bool isLeaf)
        {
            var parent = await _queriesManager.WBS.GetById(parentId);
            if (parent != null)
                parent.IsLeaf = isLeaf;
        }

        private async Task TryRestoreParentLeaf(long parentId)
        {
            var hasChildren = await _commands.HasChildren(parentId);
            if (!hasChildren)
            {
                var parent = await _queriesManager.WBS.GetById(parentId);
                if (parent != null)
                    parent.IsLeaf = false;
            }
        }

        private ReturnBase<WBSDto> NotFound()
        {
            return ReturnBase<WBSDto>.Fail(new List<ReturnBaseError>
            {
                new ReturnBaseError
                {
                    ErrorCode = "404",
                    ErrorMessage = "WBS Not Found"
                }
            });
        }

        private Task<ReturnBaseError?> ValidateRules(long? parentId, WBS? existing = null)
        {
            if (parentId.HasValue && existing != null && parentId == existing.Id)
            {
                return Task.FromResult<ReturnBaseError?>(new ReturnBaseError
                {
                    ErrorCode = "BUSINESS_RULE",
                    ErrorMessage = "WBS cannot be parent of itself."
                });
            }

            return Task.FromResult<ReturnBaseError?>(null);
        }
    }
}