using AutoMapper;
using Inspection.Application.Contracts.Dto.ContractingDTOs.Setup.CostCodes;
using Inspection.Application.Contracts.Managers;
using Inspection.Application.Contracts.Repositories.Command.Contracting.Setup.CostCodes;
using Inspection.Application.Contracts.Services.Contracting.Setup.CostCodes;
using Inspection.Application.Contracts.UnitOfWork;
using Inspection.Application.Services.ServicesBase;
using Inspection.Application.Shared.ExcelTemplate;
using Inspection.Domain.Models.Contracting.Setup.CostCodes;
using NDS.Shared.Application.DataQuery;
using NDS.Shared.Application.Multitenant;
using NDS.Shared.Kernel.BaseReturnTypes;
using NDS.Shared.Kernel.Exceptions;

namespace Inspection.Application.Services.Contracting.Setup.CostCodes
{
    public class CostCodeService : AccountsServiceBase, ICostCodeService
    {
        private readonly ITenantResolver _tenantResolver;

        public CostCodeService(
     IAccountUnitOfWork uow,
     IAccountsQueriesManager queriesManager,
     IMapper mapper,
     IExceptionManager exceptionManager,
     ITenantResolver tenantResolver,
     IExcelTemplateGenerator templateGenerator)

             : base(uow, queriesManager, mapper, exceptionManager)
        {
            _tenantResolver = tenantResolver;
        }
        private ICostCodeCommandRepository _commands => _accountUoW.CostCode;



        public async Task<ReturnBase<CostCodeDto>> Create(CostCodeCreateDto dto)
        {
            try
            {
                var ruleError = await ValidateRules(dto.ParentCostCodeId);
                if (ruleError != null)
                    return ReturnBase<CostCodeDto>.Fail(
                        new List<ReturnBaseError> { ruleError });

                var entity = _mapper.Map<CostCode>(dto);
                entity.Tenant_ID = _tenantResolver.GetTenantName();
                entity.IsLeaf = false;

                var insert = await _commands.InsertAsync(entity);
                if (!insert.Succeeded)
                    return ReturnBase<CostCodeDto>.Fail(insert.Errors);

                if (dto.ParentCostCodeId.HasValue)
                    await SetParentIsLeaf(dto.ParentCostCodeId.Value, false);

                var save = await _accountUoW.SaveAsync();
                if (!save.Succeeded)
                    return ReturnBase<CostCodeDto>.Fail(save.Errors);

                return ReturnBase<CostCodeDto>.Success(_mapper.Map<CostCodeDto>(entity));
            }
            catch (Exception ex)
            {
                return ReturnBase<CostCodeDto>.Fail(ex, _exceptionManager);
            }
        }

        public async Task<ReturnBase<CostCodeDto>> Update(CostCodeUpdateDto dto)
        {
            try
            {
                var entity = await _queriesManager.CostCode.GetById(dto.Id);
                if (entity == null)
                    return NotFound();

                var ruleError = await ValidateRules(dto.ParentCostCodeId, entity);
                if (ruleError != null)
                    return ReturnBase<CostCodeDto>.Fail(
                        new List<ReturnBaseError> { ruleError });

                if (entity.ParentCostCodeId != dto.ParentCostCodeId)
                {
                    if (entity.ParentCostCodeId.HasValue)
                        await TryRestoreParentLeaf(entity.ParentCostCodeId.Value);

                    if (dto.ParentCostCodeId.HasValue)
                        await SetParentIsLeaf(dto.ParentCostCodeId.Value, false);
                }

                entity.Tenant_ID = _tenantResolver.GetTenantName();

                _mapper.Map(dto, entity);

                var update = await _commands.UpdateAsync(entity);
                if (!update.Succeeded)
                    return ReturnBase<CostCodeDto>.Fail(update.Errors);

                var save = await _accountUoW.SaveAsync();
                if (!save.Succeeded)
                    return ReturnBase<CostCodeDto>.Fail(save.Errors);

                return ReturnBase<CostCodeDto>.Success(_mapper.Map<CostCodeDto>(entity));
            }
            catch (Exception ex)
            {
                return ReturnBase<CostCodeDto>.Fail(ex, _exceptionManager);
            }
        }

        public async Task<ReturnBase<CostCodeDto>> Delete(long id)
        {
            try
            {
                var entity = await _queriesManager.CostCode.GetById(id);
                if (entity == null)
                    return NotFound();

                if (await _commands.HasChildren(id))
                {
                    return ReturnBase<CostCodeDto>.Fail(
                        new List<ReturnBaseError>
                        {
                            new ReturnBaseError
                            {
                                ErrorCode = "BUSINESS_RULE",
                                ErrorMessage = "Cannot delete cost code that has children."
                            }
                        });
                }

                var parentId = entity.ParentCostCodeId;

                var delete = await _commands.DeleteById(id);
                if (!delete.Succeeded)
                    return ReturnBase<CostCodeDto>.Fail(delete.Errors);

                if (parentId.HasValue)
                    await TryRestoreParentLeaf(parentId.Value);

                var save = await _accountUoW.SaveAsync();
                if (!save.Succeeded)
                    return ReturnBase<CostCodeDto>.Fail(save.Errors);

                return ReturnBase<CostCodeDto>.Success(_mapper.Map<CostCodeDto>(entity));
            }
            catch (Exception ex)
            {
                return ReturnBase<CostCodeDto>.Fail(ex, _exceptionManager);
            }
        }

        public async Task<ReturnBase<CostCodeDto>> GetById(long id)
        {
            try
            {
                var entity = await _queriesManager.CostCode.GetById(id);
                if (entity == null)
                    return NotFound();

                return ReturnBase<CostCodeDto>.Success(
                    _mapper.Map<CostCodeDto>(entity));
            }
            catch (Exception ex)
            {
                return ReturnBase<CostCodeDto>.Fail(ex, _exceptionManager);
            }
        }



        public async Task<ReturnBase<IEnumerable<CostCodeReturnSearchDto>>> Search(SqlQueryOptions options)
        {
            try
            {
                var result = await _queriesManager.CostCode.Search(options);
                if (!result.Succeeded)
                    return ReturnBase<IEnumerable<CostCodeReturnSearchDto>>.Fail(result.Errors);

                return ReturnBase<IEnumerable<CostCodeReturnSearchDto>>.Success(result.Result);
            }
            catch (Exception ex)
            {
                return ReturnBase<IEnumerable<CostCodeReturnSearchDto>>.Fail(ex, _exceptionManager);
            }
        }

        private async Task SetParentIsLeaf(long parentId, bool isLeaf)
        {
            var parent = await _queriesManager.CostCode.GetById(parentId);
            if (parent != null)
                parent.IsLeaf = isLeaf;
        }

        private async Task TryRestoreParentLeaf(long parentId)
        {
            var hasChildren = await _commands.HasChildren(parentId);
            if (!hasChildren)
            {
                var parent = await _queriesManager.CostCode.GetById(parentId);
                if (parent != null)
                    parent.IsLeaf = false;
            }
        }

        private ReturnBase<CostCodeDto> NotFound()
        {
            return ReturnBase<CostCodeDto>.Fail(
                new List<ReturnBaseError>
                {
                    new ReturnBaseError
                    {
                        ErrorCode = "404",
                        ErrorMessage = "Cost Code Not Found"
                    }
                });
        }

        private Task<ReturnBaseError?> ValidateRules(long? parentId, CostCode? existing = null)
        {
            if (parentId.HasValue &&
                existing != null &&
                parentId.Value == existing.Id)
            {
                return Task.FromResult<ReturnBaseError?>(new ReturnBaseError
                {
                    ErrorCode = "BUSINESS_RULE",
                    ErrorMessage = "Cost code cannot be parent of itself."
                });
            }

            return Task.FromResult<ReturnBaseError?>(null);
        }
    }
}