using AutoMapper;
using Inspection.Application.Contracts.Dto.Inventory.InventorySetup.WarehouseLocations;
using Inspection.Application.Contracts.Managers;
using Inspection.Application.Contracts.Repositories.Command.Inventory.InventorySetup.WarehouseLocations;
using Inspection.Application.Contracts.Repositories.Query.Inventory.InventorySetup.WarehouseLocations;
using Inspection.Application.Contracts.Services.Inventory.InventorySetup.WarehouseLocations;
using Inspection.Application.Contracts.UnitOfWork;
using Inspection.Application.Services.ServicesBase;
using Inspection.Application.Shared.ExcelTemplate;
using Inspection.Domain.Models.Inventory.InventorySetup.WarehouseLocations;
using NDS.Shared.Application.DataQuery;
using NDS.Shared.Application.Multitenant;
using NDS.Shared.Kernel.BaseReturnTypes;
using NDS.Shared.Kernel.Exceptions;

namespace Inspection.Application.Services.Inventory.InventorySetup.WarehouseLocations
{
    public class WarehouseLocationService : AccountsServiceBase, IWarehouseLocationService
    {
        private readonly ITenantResolver _tenantResolver;
        private readonly IExcelTemplateGenerator _templateGenerator;


        public WarehouseLocationService(
            IAccountUnitOfWork accountUoW,
            IAccountsQueriesManager queriesManager,
            IMapper mapper,
            IExceptionManager exceptionManager,
            ITenantResolver tenantResolver,
            IExcelTemplateGenerator templateGenerator
        ) : base(accountUoW, queriesManager, mapper, exceptionManager)
        {
            _tenantResolver = tenantResolver;
            _templateGenerator = templateGenerator;
        }

        private IWarehouseLocationCommandRepository _commands => _accountUoW.WarehouseLocation;

        private IWarehouseLocationQueryRepository _queries => _queriesManager.WarehouseLocationQuery;





        public async Task<ReturnBase<WarehouseLocationDto>> Create(WarehouseLocationCreateDto dto)
        {
            try
            {
                var ruleError = await ValidateRules(dto.ParentLocationId);
                if (ruleError != null)
                    return ReturnBase<WarehouseLocationDto>.Fail(new[] { ruleError });

                var entity = _mapper.Map<WarehouseLocation>(dto);
                entity.Tenant_ID = _tenantResolver.GetTenantName();

                entity.IsLeaf = !dto.ParentLocationId.HasValue;

                var insertResult = await _commands.InsertAsync(entity);
                if (!insertResult.Succeeded)
                    return ReturnBase<WarehouseLocationDto>.Fail(insertResult.Errors);

                if (dto.ParentLocationId.HasValue)
                    await SetParentIsLeaf(dto.ParentLocationId.Value, false);

                var saveResult = await _accountUoW.SaveAsync();
                if (!saveResult.Succeeded)
                    return ReturnBase<WarehouseLocationDto>.Fail(saveResult.Errors);

                return ReturnBase<WarehouseLocationDto>.Success(
                    _mapper.Map<WarehouseLocationDto>(entity));
            }
            catch (Exception ex)
            {
                return ReturnBase<WarehouseLocationDto>.Fail(ex, _exceptionManager);
            }
        }

        public async Task<ReturnBase<WarehouseLocationDto>> Update(WarehouseLocationUpdateDto dto, long id)
        {
            try
            {
                var entity = await _queries.GetById(id);
                if (entity == null)
                    return NotFound();

                var ruleError = await ValidateRules(dto.ParentLocationId, entity);
                if (ruleError != null)
                    return ReturnBase<WarehouseLocationDto>.Fail(new[] { ruleError });

                if (entity.ParentLocationId != dto.ParentLocationId)
                {
                    if (entity.ParentLocationId.HasValue)
                        await TryRestoreParentMain(entity.ParentLocationId.Value);

                    if (dto.ParentLocationId.HasValue)
                        await SetParentIsLeaf(dto.ParentLocationId.Value, false);
                }


                entity.Tenant_ID = _tenantResolver.GetTenantName();

                _mapper.Map(dto, entity);

                //entity.IsLeaf = !dto.ParentLocationId.HasValue;

                var hasChildren = await _commands.HasChildren(entity.Id);
                entity.IsLeaf = !hasChildren;

                var updateResult = await _commands.UpdateAsync(entity);
                if (!updateResult.Succeeded)
                    return ReturnBase<WarehouseLocationDto>.Fail(updateResult.Errors);

                var saveResult = await _accountUoW.SaveAsync();
                if (!saveResult.Succeeded)
                    return ReturnBase<WarehouseLocationDto>.Fail(saveResult.Errors);

                return ReturnBase<WarehouseLocationDto>.Success(
                    _mapper.Map<WarehouseLocationDto>(entity));
            }
            catch (Exception ex)
            {
                return ReturnBase<WarehouseLocationDto>.Fail(ex, _exceptionManager);
            }
        }

        public async Task<ReturnBase<WarehouseLocationDto>> Delete(long id)
        {
            try
            {
                var entity = await _queries.GetById(id);
                if (entity == null)
                    return NotFound();

                if (await _commands.HasChildren(id))
                {
                    return ReturnBase<WarehouseLocationDto>.Fail(new[]
                    {
                    new ReturnBaseError
                    {
                        ErrorCode = "BUSINESS_RULE",
                        ErrorMessage = "Cannot delete Warehouse Location that has sub Warehouse Locations."
                    }
                });
                }

                var parentId = entity.ParentLocationId;

                var deleteResult = await _commands.DeleteById(id);
                if (!deleteResult.Succeeded)
                    return ReturnBase<WarehouseLocationDto>.Fail(deleteResult.Errors);

                if (parentId.HasValue)
                    await TryRestoreParentMain(parentId.Value);

                var saveResult = await _accountUoW.SaveAsync();
                if (!saveResult.Succeeded)
                    return ReturnBase<WarehouseLocationDto>.Fail(saveResult.Errors);

                return ReturnBase<WarehouseLocationDto>.Success(
                    _mapper.Map<WarehouseLocationDto>(entity));
            }
            catch (Exception ex)
            {
                return ReturnBase<WarehouseLocationDto>.Fail(ex, _exceptionManager);
            }
        }

        public async Task<ReturnBase<WarehouseLocationDto>> GetById(long id)
        {
            try
            {
                var entity = await _queries.GetById(id);
                if (entity == null)
                    return NotFound();

                return ReturnBase<WarehouseLocationDto>.Success(
                    _mapper.Map<WarehouseLocationDto>(entity));
            }
            catch (Exception ex)
            {
                return ReturnBase<WarehouseLocationDto>.Fail(ex, _exceptionManager);
            }
        }

        public async Task<ReturnBase<IEnumerable<WarehouseLocationSearchReturnDto>>> Search(SqlQueryOptions options)
        {
            try
            {
                var result = await _queries.Search(options);
                if (!result.Succeeded)
                    return ReturnBase<IEnumerable<WarehouseLocationSearchReturnDto>>.Fail(result.Errors);

                return ReturnBase<IEnumerable<WarehouseLocationSearchReturnDto>>.Success(
                    _mapper.Map<IEnumerable<WarehouseLocationSearchReturnDto>>(result.Result));
            }
            catch (Exception ex)
            {
                return ReturnBase<IEnumerable<WarehouseLocationSearchReturnDto>>.Fail(ex, _exceptionManager);
            }
        }

        private async Task SetParentIsLeaf(long parentId, bool isMain)
        {
            var parent = await _queries.GetById(parentId);
            if (parent != null)
                parent.IsLeaf = isMain;
        }

        private async Task TryRestoreParentMain(long parentId)
        {
            var hasChildren = await _commands.HasChildren(parentId);
            if (!hasChildren)
            {
                var parent = await _queries.GetById(parentId);
                if (parent != null)
                    parent.IsLeaf = true;
            }
        }

        private ReturnBase<WarehouseLocationDto> NotFound()
        {
            return ReturnBase<WarehouseLocationDto>.Fail(new[]
            {
            new ReturnBaseError
            {
                ErrorCode = "404",
                ErrorMessage = "Warehouse Location Not Found"
            }
        });
        }

        private Task<ReturnBaseError?> ValidateRules(
            long? parentId,
            WarehouseLocation? existing = null)
        {
            if (parentId.HasValue &&
                existing != null &&
                parentId.Value == existing.Id)
            {
                return Task.FromResult<ReturnBaseError?>(new ReturnBaseError
                {
                    ErrorCode = "BUSINESS_RULE",
                    ErrorMessage = "Warehouse Location cannot be parent of itself."
                });
            }

            return Task.FromResult<ReturnBaseError?>(null);
        }

        public async Task<ReturnBase<WarehouseLocationDto>> GetByCode(string code)
        {
            try
            {
                var entity = await _queries.GetByCode(code);
                if (entity == null)
                    return ReturnBase<WarehouseLocationDto>.Fail(new[]
                    {
                new ReturnBaseError { ErrorCode = "404", ErrorMessage = "Cost Center Not Found" }
            });

                return ReturnBase<WarehouseLocationDto>.Success(_mapper.Map<WarehouseLocationDto>(entity));
            }
            catch (Exception ex)
            {
                return ReturnBase<WarehouseLocationDto>.Fail(ex, _exceptionManager);
            }
        }

        public async Task<List<WarehouseLocationDto>> GetAll()
        {
            var list = await _queries.GetAllAsync();
            return _mapper.Map<List<WarehouseLocationDto>>(list.Result);
        }




        public async Task<ReturnBase<IEnumerable<WarehouseLocationSelectDto>>> Select(SqlQueryOptions sqlQueryOptions)
        {
            try
            {
                var getResult = await _queries.Select(sqlQueryOptions);
                if (!getResult.Succeeded)
                    return ReturnBase<IEnumerable<WarehouseLocationSelectDto>>.Fail(getResult.Errors);

                var mappedResult = _mapper.Map<IEnumerable<WarehouseLocationSelectDto>>(getResult.Result);

                return ReturnBase<IEnumerable<WarehouseLocationSelectDto>>.Success(mappedResult);
            }
            catch (Exception ex)
            {
                return ReturnBase<IEnumerable<WarehouseLocationSelectDto>>.Fail(ex, _exceptionManager);
            }
        }


    }

}
