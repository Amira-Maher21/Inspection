using AutoMapper;
using Inspection.Application.Contracts.Dto.Inventory.ItemGroupS;
using Inspection.Application.Contracts.Managers;
using Inspection.Application.Contracts.Repositories.Command.Inventory.ItemGroups;
using Inspection.Application.Contracts.Services.Inventory.ItemGroups;
using Inspection.Application.Contracts.Services.MenuManagement.SeriesF;
using Inspection.Application.Contracts.UnitOfWork;
using Inspection.Application.Services.ServicesBase;
using Inspection.Application.Shared.ExcelTemplate;
using Inspection.Domain.Models.Inventory.ItemGroups;
using NDS.Shared.Application.DataQuery;
using NDS.Shared.Application.Multitenant;
using NDS.Shared.Kernel.BaseReturnTypes;
using NDS.Shared.Kernel.Exceptions;

namespace Inspection.Application.Services.Inventory.ItemGroups
{


    public class ItemGroupService : AccountsServiceBase, IItemGroupService
    {
        private readonly ITenantResolver _tenantResolver;
        private readonly IExcelTemplateGenerator _templateGenerator;
        private readonly ISeriesService _seriesService;


        public ItemGroupService(IAccountUnitOfWork accountUoW,
            IAccountsQueriesManager queriesManager,
            IMapper mapper, IExceptionManager exceptionManager,
            ITenantResolver tenantResolver,
            IExcelTemplateGenerator templateGenerator,
            ISeriesService seriesService) : base(accountUoW, queriesManager, mapper, exceptionManager)
        {
            _tenantResolver = tenantResolver;
            _templateGenerator = templateGenerator;
            _seriesService = seriesService;
        }

        public async Task<ReturnBase<ItemGroupDto>> Create(ItemGroupCreateDto dto)
        {
            try
            {
                var ruleError = await ValidateRules(dto.ParentGroupId);
                if (ruleError != null)
                    return ReturnBase<ItemGroupDto>.Fail(
                       new List<ReturnBaseError> { ruleError });

                var entity = _mapper.Map<ItemGroup>(dto);
                entity.Tenant_ID = _tenantResolver.GetTenantName();
                entity.IsLeaf = true; // default



                // SCREEN CODE
                const string SCREEN_CODE = "Item Group";

                var series = await _queriesManager.Series.GetByScreen_IDAsync(SCREEN_CODE);

                if (series == null || !series.IsActive)
                {
                    return ReturnBase<ItemGroupDto>.Fail(
                        new Exception($"No active series configured for screen '{SCREEN_CODE}'"),
                        _exceptionManager
                    );
                }

                entity.SeriesId = series.Id;


                // Generate series number
                var seriesResult =
                    await _seriesService.GetSeriesCodeWithCustomDateUsingSeriesDetails(
                        series.Id, null
                     );

                if (!seriesResult.Succeeded || seriesResult.Result == null)
                    return ReturnBase<ItemGroupDto>.Fail(seriesResult.Errors);

                entity.Code = seriesResult.Result["FinelSeriesCodeAndSeriesNumber"];

                entity.RunningNumber = int.Parse(seriesResult.Result["RunningNumber"]);


                var insertResult = await _commands.InsertAsync(entity);
                if (!insertResult.Succeeded)
                    return ReturnBase<ItemGroupDto>.Fail(insertResult.Errors);

                if (dto.ParentGroupId.HasValue)
                    await SetParentIsLeaf(dto.ParentGroupId.Value, false);

                var saveResult = await _accountUoW.SaveAsync();
                if (!saveResult.Succeeded)
                    return ReturnBase<ItemGroupDto>.Fail(saveResult.Errors);

                return ReturnBase<ItemGroupDto>.Success(_mapper.Map<ItemGroupDto>(entity));
            }
            catch (Exception ex)
            {
                return ReturnBase<ItemGroupDto>.Fail(ex, _exceptionManager);
            }
        }

        public async Task<ReturnBase<ItemGroupDto>> Update(ItemGroupUpdateDto dto)
        {
            try
            {
                var entity = await _queriesManager.ItemGroup.GetById(dto.Id);
                if (entity == null)
                    return NotFound();

                var ruleError = await ValidateRules(dto.ParentGroupId, entity);
                if (ruleError != null)
                    return ReturnBase<ItemGroupDto>.Fail(
                      new List<ReturnBaseError> { ruleError });

                if (entity.ParentGroupId != dto.ParentGroupId)
                {
                    if (entity.ParentGroupId.HasValue)
                        await TryRestoreParentLeaf(entity.ParentGroupId.Value);

                    if (dto.ParentGroupId.HasValue)
                        await SetParentIsLeaf(dto.ParentGroupId.Value, false);
                }
                entity.Tenant_ID = _tenantResolver.GetTenantName();

                _mapper.Map(dto, entity);

                var updateResult = await _commands.UpdateAsync(entity);
                if (!updateResult.Succeeded)
                    return ReturnBase<ItemGroupDto>.Fail(updateResult.Errors);

                var saveResult = await _accountUoW.SaveAsync();
                if (!saveResult.Succeeded)
                    return ReturnBase<ItemGroupDto>.Fail(saveResult.Errors);

                return ReturnBase<ItemGroupDto>.Success(_mapper.Map<ItemGroupDto>(entity));
            }
            catch (Exception ex)
            {
                return ReturnBase<ItemGroupDto>.Fail(ex, _exceptionManager);
            }
        }

        public async Task<ReturnBase<ItemGroupDto>> Delete(long id)
        {
            try
            {
                var entity = await _queriesManager.ItemGroup.GetById(id);
                if (entity == null)
                    return NotFound();

                if (await _commands.HasChildren(id))
                {

                    return ReturnBase<ItemGroupDto>.Fail(
                           new List<ReturnBaseError>
                           {
                        new ReturnBaseError
                        {
                             ErrorCode = "BUSINESS_RULE",
                                ErrorMessage = "Cannot delete item group that has sub-groups."
                        }
                           });
                }

                var parentId = entity.ParentGroupId;

                var deleteResult = await _commands.DeleteById(id);
                if (!deleteResult.Succeeded)
                    return ReturnBase<ItemGroupDto>.Fail(deleteResult.Errors);

                if (parentId.HasValue)
                    await TryRestoreParentLeaf(parentId.Value);

                var saveResult = await _accountUoW.SaveAsync();
                if (!saveResult.Succeeded)
                    return ReturnBase<ItemGroupDto>.Fail(saveResult.Errors);

                return ReturnBase<ItemGroupDto>.Success(_mapper.Map<ItemGroupDto>(entity));
            }
            catch (Exception ex)
            {
                return ReturnBase<ItemGroupDto>.Fail(ex, _exceptionManager);
            }
        }
        public async Task<ReturnBase<ItemGroupDto>> GetById(long id)
        {
            try
            {
                var entity = await _queriesManager.ItemGroup.GetById(id);
                if (entity == null)
                    return NotFound();

                return ReturnBase<ItemGroupDto>.Success(
                    _mapper.Map<ItemGroupDto>(entity));
            }
            catch (Exception ex)
            {
                return ReturnBase<ItemGroupDto>.Fail(ex, _exceptionManager);
            }
        }

        public async Task<ReturnBase<List<ItemGroupDto>>> GetAll()
        {
            try
            {
                var result = await _queriesManager.ItemGroup.GetAll();
                if (!result.Succeeded)
                    return ReturnBase<List<ItemGroupDto>>.Fail(result.Errors);

                return ReturnBase<List<ItemGroupDto>>.Success(
                    _mapper.Map<List<ItemGroupDto>>(result.Result));
            }
            catch (Exception ex)
            {
                return ReturnBase<List<ItemGroupDto>>.Fail(ex, _exceptionManager);
            }
        }

        public async Task<ReturnBase<IEnumerable<ItemGroupReturnSearchDto>>> Search(SqlQueryOptions options)
        {
            try
            {
                var result = await _queriesManager.ItemGroup.Search(options);
                if (!result.Succeeded)
                    return ReturnBase<IEnumerable<ItemGroupReturnSearchDto>>.Fail(result.Errors);

                return ReturnBase<IEnumerable<ItemGroupReturnSearchDto>>.Success(result.Result);
            }
            catch (Exception ex)
            {
                return ReturnBase<IEnumerable<ItemGroupReturnSearchDto>>.Fail(ex, _exceptionManager);
            }
        }

        private async Task SetParentIsLeaf(long parentId, bool isLeaf)
        {
            var parent = await _queriesManager.ItemGroup.GetById(parentId);
            if (parent != null)
                parent.IsLeaf = isLeaf;
        }

        private async Task TryRestoreParentLeaf(long parentId)
        {
            var hasOtherChildren = await _commands.HasChildren(parentId);
            if (!hasOtherChildren)
            {
                var parent = await _queriesManager.ItemGroup.GetById(parentId);
                if (parent != null)
                    parent.IsLeaf = true;
            }
        }

        private ReturnBase<ItemGroupDto> NotFound()
        {
            return ReturnBase<ItemGroupDto>.Fail(
                new List<ReturnBaseError>
                {
            new ReturnBaseError
            {
                ErrorCode = "404",
                ErrorMessage = "Item Group Not Found"
            }
                });
        }


        private IItemGroupCommandRepository _commands => _accountUoW.ItemGroup;


        private Task<ReturnBaseError?> ValidateRules(long? parentGroupId, ItemGroup? existing = null)
        {
            if (parentGroupId.HasValue &&
                existing != null &&
                parentGroupId.Value == existing.Id)
            {
                return Task.FromResult<ReturnBaseError?>(new ReturnBaseError
                {
                    ErrorCode = "BUSINESS_RULE",
                    ErrorMessage = "Item group cannot be parent of itself."
                });
            }

            return Task.FromResult<ReturnBaseError?>(null);
        }

    }
}