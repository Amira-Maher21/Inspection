using AutoMapper;
using Inspection.Application.Contracts.Dto.AccountingDtos.Assets.Setup.AssetLocations;
using Inspection.Application.Contracts.Managers;
using Inspection.Application.Contracts.Repositories.Command.Accounting.Assets.Setup.AssetLocations;
using Inspection.Application.Contracts.Services.Accounting.Assets.Setup.AssetLocations;
using Inspection.Application.Contracts.UnitOfWork;
using Inspection.Application.Services.ServicesBase;
using Inspection.Application.Shared.ExcelTemplate;
using Inspection.Application.Shared.SharedValidation;
using Inspection.Domain.Models.Accounting.Assets.Setup.AssetLocations;
using NDS.Shared.Application.DataQuery;
using NDS.Shared.Application.Multitenant;
using NDS.Shared.Kernel.BaseReturnTypes;
using NDS.Shared.Kernel.Exceptions;

namespace Inspection.Application.Services.Accounting.Assets.Setup.AssetLocations
{

    public class AssetLocationService : AccountsServiceBase, IAssetLocationService
    {
        private readonly ITenantResolver _tenantResolver;
        private readonly IExcelTemplateGenerator _templateGenerator;
        private IAssetLocationCommandRepository _commands => _accountUoW.AssetLocation;

        public AssetLocationService(IAccountUnitOfWork accountUoW,
            IAccountsQueriesManager queriesManager,
            IMapper mapper, IExceptionManager exceptionManager, ITenantResolver tenantResolver,
            IExcelTemplateGenerator templateGenerator
            )
            : base(accountUoW, queriesManager, mapper, exceptionManager)
        {
            _tenantResolver = tenantResolver;
            _templateGenerator = templateGenerator;

        }

        public async Task<ReturnBase<AssetLocationDto>> Create(AssetLocationCreateDto dto)
        {
            try
            {
                var ruleError = await ValidateRules(dto.ParentLocationId);
                if (ruleError != null)
                    return ReturnBase<AssetLocationDto>.Fail(new List<ReturnBaseError> { ruleError });

                dto.LocationName.ValidateAsName();

                var entity = _mapper.Map<AssetLocation>(dto);
                entity.Tenant_ID = _tenantResolver.GetTenantName();
                entity.IsLeaf = true;

                if (dto.ParentLocationId.HasValue)
                    await SetParentIsLeaf(dto.ParentLocationId.Value, false);

                var insertResult = await _commands.InsertAsync(entity);
                if (!insertResult.Succeeded)
                    return ReturnBase<AssetLocationDto>.Fail(insertResult.Errors);

                var saveResult = await _accountUoW.SaveAsync();
                if (!saveResult.Succeeded)
                    return ReturnBase<AssetLocationDto>.Fail(saveResult.Errors);

                return ReturnBase<AssetLocationDto>.Success(_mapper.Map<AssetLocationDto>(entity));
            }
            catch (Exception ex)
            {
                return ReturnBase<AssetLocationDto>.Fail(ex, _exceptionManager);
            }
        }

        public async Task<ReturnBase<AssetLocationDto>> Update(AssetLocationUpdateDto dto)
        {
            try
            {
                var entity = await _queriesManager.AssetLocation.GetById(dto.Id);
                if (entity == null)
                {
                    var error = new ReturnBaseError
                    {
                        ErrorCode = "404",
                        ErrorMessage = "Asset Location Not Found"
                    };
                    var listOfErrors = new List<ReturnBaseError>() { error };
                    return ReturnBase<AssetLocationDto>.Fail(listOfErrors);
                }

                var ruleError = await ValidateRules(dto.ParentLocationId, entity);
                if (ruleError != null)
                    return ReturnBase<AssetLocationDto>.Fail(new List<ReturnBaseError> { ruleError });

                if (entity.ParentLocationId != dto.ParentLocationId)
                {
                    if (entity.ParentLocationId.HasValue)
                        await TryRestoreParentLeaf(entity.ParentLocationId.Value);

                    if (dto.ParentLocationId.HasValue)
                        await SetParentIsLeaf(dto.ParentLocationId.Value, false);
                }

                _mapper.Map(dto, entity);

                var updateResult = await _commands.UpdateAsync(entity);
                if (!updateResult.Succeeded)
                    return ReturnBase<AssetLocationDto>.Fail(updateResult.Errors);

                var saveResult = await _accountUoW.SaveAsync();
                if (!saveResult.Succeeded)
                    return ReturnBase<AssetLocationDto>.Fail(saveResult.Errors);

                return ReturnBase<AssetLocationDto>.Success(_mapper.Map<AssetLocationDto>(entity));
            }
            catch (Exception ex)
            {
                return ReturnBase<AssetLocationDto>.Fail(ex, _exceptionManager);
            }
        }

        public async Task<ReturnBase<AssetLocationDto>> Delete(long id)
        {
            try
            {
                var entity = await _queriesManager.AssetLocation.GetById(id);
                if (entity == null)
                {
                    var error = new ReturnBaseError
                    {
                        ErrorCode = "404",
                        ErrorMessage = "AssetLocation Not Found"
                    };
                    var listOfErrors = new List<ReturnBaseError>() { error };
                    return ReturnBase<AssetLocationDto>.Fail(listOfErrors);
                }

                if (await _commands.HasChildren(id))
                {
                    return ReturnBase<AssetLocationDto>.Fail(new List<ReturnBaseError>
                    {
                        new()
                        {
                            ErrorCode = "BUSINESS_RULE",
                            ErrorMessage = "Cannot delete location that has children."
                        }
                    });
                }

                var parentId = entity.ParentLocationId;

                var deleteResult = await _commands.DeleteById(id);
                if (!deleteResult.Succeeded)
                    return ReturnBase<AssetLocationDto>.Fail(deleteResult.Errors);

                if (parentId.HasValue)
                    await TryRestoreParentLeaf(parentId.Value);

                var saveResult = await _accountUoW.SaveAsync();
                if (!saveResult.Succeeded)
                    return ReturnBase<AssetLocationDto>.Fail(saveResult.Errors);

                return ReturnBase<AssetLocationDto>.Success(_mapper.Map<AssetLocationDto>(entity));
            }
            catch (Exception ex)
            {
                return ReturnBase<AssetLocationDto>.Fail(ex, _exceptionManager);
            }
        }


        public async Task<ReturnBase<IEnumerable<AssetLocationReturnSearchDto>>> Search(SqlQueryOptions sqlQueryOptions)
        {
            try
            {
                var getResult =
                    await _queriesManager.AssetLocation.Search(sqlQueryOptions);

                if (!getResult.Succeeded)
                    return ReturnBase<IEnumerable<AssetLocationReturnSearchDto>>
                        .Fail(getResult.Errors);

                return ReturnBase<IEnumerable<AssetLocationReturnSearchDto>>
                    .Success(getResult.Result);
            }
            catch (Exception ex)
            {
                return ReturnBase<IEnumerable<AssetLocationReturnSearchDto>>
                    .Fail(ex, _exceptionManager);
            }
        }

        public async Task<ReturnBase<AssetLocationDto>> GetById(long id)
        {
            try
            {
                var entity = await _queriesManager.AssetLocation.GetById(id);
                if (entity is null)
                {
                    var error = new ReturnBaseError
                    {
                        ErrorCode = "404",
                        ErrorMessage = "Asset Location Not Found"
                    };
                    var listOfErrors = new List<ReturnBaseError>() { error };
                    return ReturnBase<AssetLocationDto>.Fail(listOfErrors);
                }

                var mappedResult = _mapper.Map<AssetLocationDto>(entity);

                return ReturnBase<AssetLocationDto>.Success(mappedResult);
            }
            catch (Exception ex)
            {
                return ReturnBase<AssetLocationDto>.Fail(ex, _exceptionManager);
            }
        }

        public async Task<ReturnBase<AssetLocationDto>> GetByCode(string code)
        {
            try
            {
                var entity = await _queriesManager.AssetLocation.GetByCode(code);
                if (entity is null)
                {
                    var error = new ReturnBaseError
                    {
                        ErrorCode = "404",
                        ErrorMessage = "Asset Category Not Found"
                    };
                    var listOfErrors = new List<ReturnBaseError>() { error };
                    return ReturnBase<AssetLocationDto>.Fail(listOfErrors);
                }

                var mappedResult = _mapper.Map<AssetLocationDto>(entity);

                return ReturnBase<AssetLocationDto>.Success(mappedResult);
            }
            catch (Exception ex)
            {
                return ReturnBase<AssetLocationDto>.Fail(ex, _exceptionManager);
            }
        }

        private async Task<ReturnBaseError?> ValidateRules(long? parentId, AssetLocation? existing = null)
        {
            // self parent
            if (parentId.HasValue &&
                existing != null &&
                parentId.Value == existing.Id)
            {
                return new ReturnBaseError
                {
                    ErrorCode = "BUSINESS_RULE",
                    ErrorMessage = "Asset location cannot be parent of itself."
                };
            }

            // circular check
            var isCircular = await IsCircular(parentId, existing?.Id);
            if (isCircular)
            {
                return new ReturnBaseError
                {
                    ErrorCode = "BUSINESS_RULE",
                    ErrorMessage = "Circular reference is not allowed."
                };
            }

            return null;
        }

        private async Task SetParentIsLeaf(long parentId, bool isLeaf)
        {
            var parent = await _queriesManager.AssetLocation.GetById(parentId);
            if (parent != null)
                parent.IsLeaf = isLeaf;
        }

        private async Task TryRestoreParentLeaf(long parentId)
        {
            var hasChildren = await _commands.HasChildren(parentId);
            if (!hasChildren)
            {
                var parent = await _queriesManager.AssetLocation.GetById(parentId);
                if (parent != null)
                    parent.IsLeaf = true;
            }
        }

        private async Task<bool> IsCircular(long? parentId, long? currentId)
        {
            if (!parentId.HasValue)
                return false;

            while (parentId.HasValue)
            {
                if (currentId.HasValue && parentId.Value == currentId.Value)
                    return true;

                var parent = await _queriesManager.AssetLocation.GetById(parentId.Value);
                parentId = parent?.ParentLocationId;
            }

            return false;
        }

    }
}



