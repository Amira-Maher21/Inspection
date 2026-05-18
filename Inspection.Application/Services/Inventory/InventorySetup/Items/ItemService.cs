using AutoMapper;
using Inspection.Application.Contracts.Dto.Inventory.InventorySetup.ItemDTOs;
using Inspection.Application.Contracts.Dto.Inventory.InventorySetup.ItemDTOs.ItemVariantAttributeDTOs;
using Inspection.Application.Contracts.Managers;
using Inspection.Application.Contracts.Repositories.Command.Inventory.InventorySetup.Items;
using Inspection.Application.Contracts.Repositories.Query.Inventory.InventorySetup.ItemAttributes;
using Inspection.Application.Contracts.Repositories.Query.Inventory.InventorySetup.Items;
using Inspection.Application.Contracts.Services.Inventory.InventorySetup.Items;
using Inspection.Application.Contracts.Services.MenuManagement.SeriesF;
using Inspection.Application.Contracts.UnitOfWork;
using Inspection.Application.Services.ServicesBase;
using Inspection.Application.Shared.ExcelTemplate;
using Inspection.Domain.Enums.InventoryEnums;
using Inspection.Domain.Enums.InventoryEnums.Items;
using Inspection.Domain.Models.Inventory.InventorySetup.ItemAttribute;
using Inspection.Domain.Models.Inventory.InventorySetup.Items;
using NDS.Shared.Application.DataQuery;
using NDS.Shared.Application.Multitenant;
using NDS.Shared.Kernel.BaseReturnTypes;
using NDS.Shared.Kernel.Exceptions;

namespace Inspection.Application.Services.Inventory.InventorySetup.Items
{
    internal class ItemService : AccountsServiceBase, IItemService
    {
        private readonly ITenantResolver _tenantResolver;
        private readonly IAccountsQueriesManager _queriesManager;
        private readonly IExcelTemplateGenerator _templateGenerator;
        private readonly ISeriesService _seriesService;


        public ItemService(
            IAccountUnitOfWork accountUoW,
            IAccountsQueriesManager queriesManager,
            IMapper mapper,
            IExceptionManager exceptionManager,
            ITenantResolver tenantResolver,
            IExcelTemplateGenerator templateGenerator, ISeriesService seriesService) : base(accountUoW, queriesManager, mapper, exceptionManager)
        {
            _queriesManager = queriesManager ?? throw new ArgumentNullException(nameof(queriesManager));
            _tenantResolver = tenantResolver;
            _templateGenerator = templateGenerator;
            _seriesService = seriesService;

        }
        private IItemCommandRepository _commands => _accountUoW.Item;
        private IItemQueryRepository _queries => _queriesManager.Items;
        private IItemVariantAttributeCommandRepository _variantCommands => _accountUoW.ItemVariantAttribute;
        private IItemVariantAttributeQueryRepository _variantQueries => _queriesManager.ItemVariantAttribute;
        private IItemAttributeQueryRepository _itemAttributeQueries => _queriesManager.ItemAttribute;

        public async Task<ReturnBase<ItemDto>> Create(ItemCreateDto dto)
        {
            try
            {
                var entity = _mapper.Map<Item>(dto);
                entity.Tenant_ID = _tenantResolver.GetTenantName();

                var validationErrors = ValidateItemBusinessRules(entity);
                if (validationErrors.Any())
                    return ReturnBase<ItemDto>.Fail(validationErrors);

                const string SCREEN_CODE = "Item";

                var series = await _queriesManager.Series.GetByScreen_IDAsync(SCREEN_CODE);

                if (series == null || !series.IsActive)
                    return ReturnBase<ItemDto>.Fail(
                        new Exception($"No active series configured for screen '{SCREEN_CODE}'"),
                        _exceptionManager);

                entity.SeriesId = series.Id;

                var seriesResult = await _seriesService
                    .GetSeriesCodeWithCustomDateUsingSeriesDetails(series.Id, DateTime.Now);

                if (!seriesResult.Succeeded || seriesResult.Result == null)
                    return ReturnBase<ItemDto>.Fail(seriesResult.Errors);

                entity.Code = seriesResult.Result["FinelSeriesCodeAndSeriesNumber"];
                entity.RunningNumber = int.Parse(seriesResult.Result["RunningNumber"]);

                CreateReorders(entity, dto);

                var insertResult = await _commands.InsertAsync(entity);
                if (!insertResult.Succeeded)
                    return ReturnBase<ItemDto>.Fail(insertResult.Errors);

                var saveResult = await _accountUoW.SaveAsync();
                if (!saveResult.Succeeded)
                    return ReturnBase<ItemDto>.Fail(saveResult.Errors);

                return ReturnBase<ItemDto>.Success(_mapper.Map<ItemDto>(entity));
            }
            catch (Exception ex)
            {
                return ReturnBase<ItemDto>.Fail(ex, _exceptionManager);
            }
        }

        public async Task<ReturnBase<ItemDto>> Update(ItemUpdateDto dto)
        {
            try
            {
                var entity = await _queriesManager.Items.GetById(dto.Id);

                if (entity == null)
                    return ReturnBase<ItemDto>.Fail(new List<ReturnBaseError>
            {
                new() { ErrorCode = "404", ErrorMessage = "Item Not Found" }
            });

                _mapper.Map(dto, entity);

                dto.HasVariant = entity.HasVariant;

                var validationErrors = ValidateItemBusinessRules(entity);
                if (validationErrors.Any())
                    return ReturnBase<ItemDto>.Fail(validationErrors);

                await UpdateReorders(entity, dto);

                var saveResult = await _accountUoW.SaveAsync();
                if (!saveResult.Succeeded)
                    return ReturnBase<ItemDto>.Fail(saveResult.Errors);

                return ReturnBase<ItemDto>.Success(_mapper.Map<ItemDto>(entity));
            }
            catch (Exception ex)
            {
                return ReturnBase<ItemDto>.Fail(ex, _exceptionManager);
            }
        }

        public async Task<ReturnBase<ItemDto>> Delete(long id)
        {
            try
            {
                var entity = await _queriesManager.Items.GetById(id);
                if (entity == null)
                    return ReturnBase<ItemDto>.Fail(new List<ReturnBaseError>
                    {
                        new() { ErrorCode = "404", ErrorMessage = "Item Not Found" }
                    });


                var updateResult = await _commands.DeleteAsync(id);
                if (!updateResult.Succeeded) return ReturnBase<ItemDto>.Fail(updateResult.Errors);

                var saveResult = await _accountUoW.SaveAsync();
                if (!saveResult.Succeeded) return ReturnBase<ItemDto>.Fail(saveResult.Errors);

                return ReturnBase<ItemDto>.Success(_mapper.Map<ItemDto>(entity));
            }
            catch (Exception ex)
            {
                return ReturnBase<ItemDto>.Fail(ex, _exceptionManager);
            }
        }

        public async Task<ReturnBase<ItemDto>> GetById(long id)
        {
            try
            {
                var entity = await _queries.GetById(id);

                if (entity == null)
                    return ReturnBase<ItemDto>.Fail(new List<ReturnBaseError>
            {
                new() { ErrorCode = "404", ErrorMessage = "Item Not Found" }
            });

                var dto = _mapper.Map<ItemDto>(entity);

                // ✅ Get Variants manually
                dto.Variants = await _variantQueries.GetVariants(id);

                return ReturnBase<ItemDto>.Success(dto);
            }
            catch (Exception ex)
            {
                return ReturnBase<ItemDto>.Fail(ex, _exceptionManager);
            }
        }
        public async Task<ReturnBase<IEnumerable<ItemReturnSearchDto>>> Search(
            SqlQueryOptions sqlQueryOptions)
        {
            try
            {
                var getResult =
                    await _queriesManager.Items.Search(sqlQueryOptions);

                if (!getResult.Succeeded)
                    return ReturnBase<IEnumerable<ItemReturnSearchDto>>
                        .Fail(getResult.Errors);

                return ReturnBase<IEnumerable<ItemReturnSearchDto>>
                    .Success(getResult.Result);
            }
            catch (Exception ex)
            {
                return ReturnBase<IEnumerable<ItemReturnSearchDto>>
                    .Fail(ex, _exceptionManager);
            }
        }

        public async Task<ReturnBase<IEnumerable<ItemReturnSearchDto>>> FilteredSearch(
            SqlQueryOptions sqlQueryOptions)
        {
            try
            {
                var getResult =
                    await _queriesManager.Items.FilteredItem(sqlQueryOptions);

                if (!getResult.Succeeded)
                    return ReturnBase<IEnumerable<ItemReturnSearchDto>>
                        .Fail(getResult.Errors);

                return ReturnBase<IEnumerable<ItemReturnSearchDto>>
                    .Success(getResult.Result);
            }
            catch (Exception ex)
            {
                return ReturnBase<IEnumerable<ItemReturnSearchDto>>
                    .Fail(ex, _exceptionManager);
            }
        }

        public async Task<ReturnBase<bool>> CreateVariants(ItemVariantAttributeCreateDto dto)
        {
            try
            {
                // 1️ Get Parent Item
                var parentItem = await _queriesManager.Items.GetById(dto.ItemId);

                if (parentItem == null)
                    return ReturnBase<bool>.Fail(new List<ReturnBaseError>
            {
                new() { ErrorCode = "404", ErrorMessage = "Item Not Found" }
            });

                // 2️ Get Attributes WITH Values (from your existing repo ✅)
                var attributeIds = dto.Attributes
                    .Select(x => x.AttributeId)
                    .Distinct()
                    .ToList();

                var attributes = new List<ItemAttribute>();

                foreach (var attrId in attributeIds)
                {
                    var attr = await _queriesManager.ItemAttribute.GetById(attrId);

                    if (attr == null)
                        return ReturnBase<bool>.Fail(new List<ReturnBaseError>
                {
                    new() { ErrorCode = "404", ErrorMessage = $"Attribute {attrId} not found" }
                });

                    attributes.Add(attr);
                }

                // 3️ Generate Combinations
                var attributeValueLists = dto.Attributes
                    .Select(x => x.ItemAttributeValueIds)
                    .ToList();

                var combinations = GenerateCombinations(attributeValueLists);

                if (!combinations.Any())
                    return ReturnBase<bool>.Success(true);

                // 4️ Get Existing Variants (for duplicate check ⚠️)
                var existingVariants = await _queriesManager.ItemVariantAttribute
                    .GetByParentItemId(dto.ItemId);

                int sequence = 1;

                foreach (var combination in combinations)
                {
                    var normalizedCombination = combination.OrderBy(x => x).ToList();

                    // 5️ 🚫 Prevent duplicates (CORRECT ✔)
                    bool exists = existingVariants.Any(v =>
                        v.AttributeValueIds.OrderBy(x => x)
                         .SequenceEqual(normalizedCombination));

                    if (exists)
                        continue;

                    // 6️ Get Attribute Values FROM MEMORY (no DB hit ✔)
                    var attrValues = attributes
                        .SelectMany(a => a.ItemAttributeValues)
                        .Where(v => normalizedCombination.Contains(v.Id))
                        .ToList();

                    // 7️ Create Variant Item
                    var variant = new Item
                    {
                        Tenant_ID = parentItem.Tenant_ID,
                        CompanyId = parentItem.CompanyId,

                        Code = $"{parentItem.Code}-{sequence:D3}",
                        SKU = parentItem.SKU != null ? $"{parentItem.SKU}-{sequence:D3}" : null,

                        Description = parentItem.Description,
                        ItemGroupId = parentItem.ItemGroupId,
                        ItemType = parentItem.ItemType,
                        UnitOfMeasureId = parentItem.UnitOfMeasureId,

                        IsStocked = parentItem.IsStocked,
                        IsSerialTracked = parentItem.IsSerialTracked,
                        IsBatchTracked = parentItem.IsBatchTracked,
                        IsExpiryTracked = parentItem.IsExpiryTracked,

                        HasVariant = false,
                        RelatedItemVariantId = parentItem.Id,

                        UnitPrice = parentItem.UnitPrice,
                        UnitCost = parentItem.UnitCost,

                        In_User = _tenantResolver.GetCommonUserData().UserName!,
                        In_Date = DateTime.Now
                    };

                    // 8️ Generate Name
                    variant.Name = $"{parentItem.Name}-{string.Join("-", attrValues.Select(x => x.AttributeValue))}";

                    // 9️ Insert Item
                    await _commands.InsertAsync(variant);

                    // 10 Prepare Variant Attributes
                    var variantAttributes = attrValues.Select(attrValue => new ItemVariantAttribute
                    {
                        Item = variant,
                        AttributeId = attrValue.ItemAttributeId,
                        ItemAttributeValueId = attrValue.Id
                    }).ToList();

                    // 11️ Save Variant Attributes
                    await _variantCommands.AddRange(variantAttributes);

                    // if you want only use the insert  only use this instead of Add Range 
                    //foreach (var entity in variantAttributes)
                    //{
                    //    await _variantCommands.InsertAsync(entity);
                    //}

                    sequence++;
                }

                // 12️ Save All
                var saveResult = await _accountUoW.SaveAsync();
                if (!saveResult.Succeeded)
                    return ReturnBase<bool>.Fail(saveResult.Errors);

                return ReturnBase<bool>.Success(true);
            }
            catch (Exception ex)
            {
                return ReturnBase<bool>.Fail(ex, _exceptionManager);
            }
        }
        public async Task<ReturnBase<List<ItemVariantAttributeDto>>> GetVariants(long itemId)
        {
            try
            {
                var result = await _queriesManager.ItemVariantAttribute.GetVariants(itemId);

                return ReturnBase<List<ItemVariantAttributeDto>>.Success(result);
            }
            catch (Exception ex)
            {
                return ReturnBase<List<ItemVariantAttributeDto>>.Fail(ex, _exceptionManager);
            }
        }

        public async Task<ReturnBase<ItemForecastResultDto>> GetItemForecastReorderQuantity(long itemId, ItemForecastPeriod period)
        {
            try
            {
                // ─ 1. Validate the item exists
                var item = await _queriesManager.Items.GetById(itemId);
                if (item is null)
                    return ReturnBase<ItemForecastResultDto>.Fail(new List<ReturnBaseError>
                    {
                        new() { ErrorCode = "404", ErrorMessage = $"Item with Id {itemId} was not found" }
                    });

                // ─ 2. Determine the look-back window
                // The enum value equals the number of months.
                int months = (int)period;
                var to = DateTime.UtcNow;
                var from = to.AddMonths(-months);

                // ─ 3. Sum QuantityOut from the InventoryLedger
                // SumOutboundQuantityAsync filters by ItemId + date range and sums
                // QuantityOut (null rows are treated as 0).
                var totalConsumed = await _queriesManager.InventoryLedger
                    .SumOutboundQuantityAsync(itemId, from, to);

                // ─ 4. Average daily consumption 
                double totalDays = (to - from).TotalDays;
                if (totalDays <= 0) totalDays = 1; // guard against edge cases

                decimal avgDailyConsumption = totalConsumed / (decimal)totalDays;

                // ─ 5. Lead-time in days (fallback: 0 days if not set)
                long leadTimeDays = item.LeadTime ?? 0;

                // ─ 6. Safety stock: item-level value, fallback to 0
                decimal safetyStock = item.SafetyStock ?? 0m;

                // ─ 7. Reorder-quantity formula 
                //   ReorderQty = (AvgDailyConsumption × LeadTimeDays) + SafetyStock
                decimal reorderQuantity = (avgDailyConsumption * leadTimeDays) + safetyStock;

                // Round to 3 decimal places — matches decimal(18,3) DB columns.
                reorderQuantity = Math.Round(reorderQuantity, 3, MidpointRounding.AwayFromZero);

                var resultDto = new ItemForecastResultDto { ReorderQuantity = reorderQuantity };
                return ReturnBase<ItemForecastResultDto>.Success(resultDto);
            }
            catch (Exception ex)
            {
                return ReturnBase<ItemForecastResultDto>.Fail(ex, _exceptionManager);
            }
        }

        // Create && Update  Reorders

        private List<ReturnBaseError> CreateReorders(Item entity, ItemCreateDto dto)
        {
            if (dto.ItemReordersPerWarehouse == null || !dto.ItemReordersPerWarehouse.Any())
            {
                entity.ItemReordersPerWarehouse = new List<ItemReorderPerWarehouse>();
                return new List<ReturnBaseError>();
            }

            entity.ItemReordersPerWarehouse =
                _mapper.Map<List<ItemReorderPerWarehouse>>(dto.ItemReordersPerWarehouse);

            foreach (var reorder in entity.ItemReordersPerWarehouse)
            {
                reorder.Item = entity;
            }

            return ValidateItemReorders(entity.ItemReordersPerWarehouse);
        }

        private async Task<List<ReturnBaseError>> UpdateReorders(Item entity, ItemUpdateDto dto)
        {
            var existing = entity.ItemReordersPerWarehouse.ToList();

            if (dto.ItemReordersPerWarehouse == null || !dto.ItemReordersPerWarehouse.Any())
            {
                await _commands.DeleteItemReordersByItemId(entity.Id);
                return new List<ReturnBaseError>();
            }

            var dtoIds = dto.ItemReordersPerWarehouse
                .Where(x => x.Id > 0)
                .Select(x => x.Id)
                .ToHashSet();

            foreach (var reorderDto in dto.ItemReordersPerWarehouse)
            {
                if (reorderDto.Id == 0)
                {
                    var newEntity = _mapper.Map<ItemReorderPerWarehouse>(reorderDto);
                    newEntity.ItemId = entity.Id;
                    entity.ItemReordersPerWarehouse.Add(newEntity);
                }
                else
                {
                    var existingEntity = existing
                        .FirstOrDefault(x => x.Id == reorderDto.Id);

                    if (existingEntity != null)
                        _mapper.Map(reorderDto, existingEntity);
                }
            }

            var removed = existing
                .Where(x => !dtoIds.Contains(x.Id))
                .Select(x => x.Id)
                .ToList();

            if (removed.Any())
                await _commands.DeleteItemReordersByIds(removed);

            return ValidateItemReorders(entity.ItemReordersPerWarehouse);
        }

        private List<ReturnBaseError> ValidateItemReorders(IEnumerable<ItemReorderPerWarehouse> reorders)
        {
            var errors = new List<ReturnBaseError>();

            foreach (var reorder in reorders)
            {
                if (reorder.ReorderLevel < 0)
                {
                    errors.Add(new ReturnBaseError
                    {
                        ErrorCode = "ITEM_REORDER_LEVEL_INVALID",
                        ErrorMessage = "Reorder Level cannot be negative."
                    });
                }

                if (reorder.ReorderQuantity < 0)
                {
                    errors.Add(new ReturnBaseError
                    {
                        ErrorCode = "ITEM_REORDER_QUANTITY_INVALID",
                        ErrorMessage = "Reorder Quantity cannot be negative."
                    });
                }

                if (reorder.SafetyStock.HasValue && reorder.SafetyStock < 0)
                {
                    errors.Add(new ReturnBaseError
                    {
                        ErrorCode = "ITEM_SAFETY_STOCK_INVALID",
                        ErrorMessage = "Safety Stock cannot be negative."
                    });
                }
            }

            return errors;
        }

        private List<ReturnBaseError> ValidateItemBusinessRules(Item entity)
        {
            var errors = new List<ReturnBaseError>();

            // CK_Item_Inventory_Rules
            if (entity.ItemType == ItemType.Inventory)
            {
                if (!entity.IsStocked || entity.UnitOfMeasureId == null)
                {
                    errors.Add(new ReturnBaseError
                    {
                        ErrorCode = "ITEM_INV_RULE",
                        ErrorMessage = "Inventory item must be stocked and must have a Unit Of Measure."
                    });
                }
            }

            // CK_Item_Service_No_Stock
            if (entity.ItemType == ItemType.Service)
            {
                if (entity.IsStocked || entity.IsSerialTracked || entity.IsBatchTracked)
                {
                    errors.Add(new ReturnBaseError
                    {
                        ErrorCode = "ITEM_SERVICE_RULE",
                        ErrorMessage = "Service items cannot have stock tracking, serial, or batch."
                    });
                }
            }

            return errors;
        }
        private List<List<long>> GenerateCombinations(List<List<long>> lists)
        {
            var result = new List<List<long>>();

            void Recurse(List<long> current, int depth)
            {
                if (depth == lists.Count)
                {
                    result.Add(new List<long>(current));
                    return;
                }

                foreach (var value in lists[depth])
                {
                    current.Add(value);
                    Recurse(current, depth + 1);
                    current.RemoveAt(current.Count - 1);
                }
            }

            Recurse(new List<long>(), 0);
            return result;
        }
    }
}
