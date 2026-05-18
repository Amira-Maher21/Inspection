using AutoMapper;
using Inspection.Application.Contracts.Dto.ContractingDTOs.Setup.Divisions;
using Inspection.Application.Contracts.Managers;
using Inspection.Application.Contracts.Repositories.Command.Contracting.Setup.Divisions;
using Inspection.Application.Contracts.Services.Contracting.Setup.Divisions;
using Inspection.Application.Contracts.UnitOfWork;
using Inspection.Application.Services.ServicesBase;
using Inspection.Application.Shared.ExcelTemplate;
using Inspection.Domain.Models.Contracting.Setup.Divisions;
using NDS.Shared.Application.DataQuery;
using NDS.Shared.Application.Multitenant;
using NDS.Shared.Kernel.BaseReturnTypes;
using NDS.Shared.Kernel.Exceptions;

namespace Inspection.Application.Services.Contracting.Setup.Divisions
{
    public class DivisionService : AccountsServiceBase, IDivisionService
    {
        private readonly ITenantResolver _tenantResolver;

        public DivisionService(
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

        private IDivisionCommandRepository _commands => _accountUoW.Division;

        public async Task<ReturnBase<DivisionDto>> Create(DivisionCreateDto dto)
        {
            try
            {
                var ruleError = await ValidateRules(dto.ParentDivisionId);
                if (ruleError != null)
                    return ReturnBase<DivisionDto>.Fail(
                        new List<ReturnBaseError> { ruleError });

                var entity = _mapper.Map<Division>(dto);
                entity.Tenant_ID = _tenantResolver.GetTenantName();
                entity.IsLeaf = false;

                var insert = await _commands.InsertAsync(entity);
                if (!insert.Succeeded)
                    return ReturnBase<DivisionDto>.Fail(insert.Errors);

                if (dto.ParentDivisionId.HasValue)
                    await SetParentIsLeaf(dto.ParentDivisionId.Value, false);

                var save = await _accountUoW.SaveAsync();
                if (!save.Succeeded)
                    return ReturnBase<DivisionDto>.Fail(save.Errors);

                return ReturnBase<DivisionDto>.Success(_mapper.Map<DivisionDto>(entity));
            }
            catch (Exception ex)
            {
                return ReturnBase<DivisionDto>.Fail(ex, _exceptionManager);
            }
        }

        public async Task<ReturnBase<DivisionDto>> Update(DivisionUpdateDto dto)
        {
            try
            {
                var entity = await _queriesManager.Division.GetById(dto.Id);
                if (entity == null)
                    return NotFound();

                var ruleError = await ValidateRules(dto.ParentDivisionId, entity);
                if (ruleError != null)
                    return ReturnBase<DivisionDto>.Fail(
                        new List<ReturnBaseError> { ruleError });

                if (entity.ParentDivisionId != dto.ParentDivisionId)
                {
                    if (entity.ParentDivisionId.HasValue)
                        await TryRestoreParentLeaf(entity.ParentDivisionId.Value);

                    if (dto.ParentDivisionId.HasValue)
                        await SetParentIsLeaf(dto.ParentDivisionId.Value, false);
                }

                entity.Tenant_ID = _tenantResolver.GetTenantName();

                _mapper.Map(dto, entity);

                var update = await _commands.UpdateAsync(entity);
                if (!update.Succeeded)
                    return ReturnBase<DivisionDto>.Fail(update.Errors);

                var save = await _accountUoW.SaveAsync();
                if (!save.Succeeded)
                    return ReturnBase<DivisionDto>.Fail(save.Errors);

                return ReturnBase<DivisionDto>.Success(_mapper.Map<DivisionDto>(entity));
            }
            catch (Exception ex)
            {
                return ReturnBase<DivisionDto>.Fail(ex, _exceptionManager);
            }
        }

        public async Task<ReturnBase<DivisionDto>> Delete(long id)
        {
            try
            {
                var entity = await _queriesManager.Division.GetById(id);
                if (entity == null)
                    return NotFound();

                if (await _commands.HasChildren(id))
                {
                    return ReturnBase<DivisionDto>.Fail(
                        new List<ReturnBaseError>
                        {
                            new ReturnBaseError
                            {
                                ErrorCode = "BUSINESS_RULE",
                                ErrorMessage = "Cannot delete division that has children."
                            }
                        });
                }

                var parentId = entity.ParentDivisionId;

                var delete = await _commands.DeleteById(id);
                if (!delete.Succeeded)
                    return ReturnBase<DivisionDto>.Fail(delete.Errors);

                if (parentId.HasValue)
                    await TryRestoreParentLeaf(parentId.Value);

                var save = await _accountUoW.SaveAsync();
                if (!save.Succeeded)
                    return ReturnBase<DivisionDto>.Fail(save.Errors);

                return ReturnBase<DivisionDto>.Success(_mapper.Map<DivisionDto>(entity));
            }
            catch (Exception ex)
            {
                return ReturnBase<DivisionDto>.Fail(ex, _exceptionManager);
            }
        }

        public async Task<ReturnBase<DivisionDto>> GetById(long id)
        {
            try
            {
                var entity = await _queriesManager.Division.GetById(id);
                if (entity == null)
                    return NotFound();

                return ReturnBase<DivisionDto>.Success(
                    _mapper.Map<DivisionDto>(entity));
            }
            catch (Exception ex)
            {
                return ReturnBase<DivisionDto>.Fail(ex, _exceptionManager);
            }
        }



        public async Task<ReturnBase<IEnumerable<DivisionReturnSearchDto>>> Search(SqlQueryOptions options)
        {
            try
            {
                var result = await _queriesManager.Division.Search(options);
                if (!result.Succeeded)
                    return ReturnBase<IEnumerable<DivisionReturnSearchDto>>.Fail(result.Errors);

                return ReturnBase<IEnumerable<DivisionReturnSearchDto>>.Success(result.Result);
            }
            catch (Exception ex)
            {
                return ReturnBase<IEnumerable<DivisionReturnSearchDto>>.Fail(ex, _exceptionManager);
            }
        }

        private async Task SetParentIsLeaf(long parentId, bool isLeaf)
        {
            var parent = await _queriesManager.Division.GetById(parentId);
            if (parent != null)
                parent.IsLeaf = isLeaf;
        }

        private async Task TryRestoreParentLeaf(long parentId)
        {
            var hasChildren = await _commands.HasChildren(parentId);
            if (!hasChildren)
            {
                var parent = await _queriesManager.Division.GetById(parentId);
                if (parent != null)
                    parent.IsLeaf = false;
            }
        }

        private ReturnBase<DivisionDto> NotFound()
        {
            return ReturnBase<DivisionDto>.Fail(
                new List<ReturnBaseError>
                {
                    new ReturnBaseError
                    {
                        ErrorCode = "404",
                        ErrorMessage = "Division Not Found"
                    }
                });
        }

        private Task<ReturnBaseError?> ValidateRules(long? parentId, Division? existing = null)
        {
            if (parentId.HasValue &&
                existing != null &&
                parentId.Value == existing.Id)
            {
                return Task.FromResult<ReturnBaseError?>(new ReturnBaseError
                {
                    ErrorCode = "BUSINESS_RULE",
                    ErrorMessage = "Division cannot be parent of itself."
                });
            }

            return Task.FromResult<ReturnBaseError?>(null);
        }
    }
}