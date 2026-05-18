using AutoMapper;
using Inspection.Application.Contracts.Dto.AccountingDtos.AccountBalance;
using Inspection.Application.Contracts.Dto.Inventory.System.InventoryBalance;
using Inspection.Application.Contracts.Dto.Inventory.System.InventoryCostLayers;
using Inspection.Application.Contracts.Dto.Inventory.System.InventoryLedgers;
using Inspection.Application.Contracts.Dto.Posting;
using Inspection.Application.Contracts.Managers;
using Inspection.Application.Contracts.Posting;
using Inspection.Application.Contracts.Repositories.Command.Inventory.InventorySetup.ItemAttributes;
using Inspection.Application.Contracts.Repositories.Query.Accounting.Payments.JournalEntrys;
using Inspection.Application.Contracts.Repositories.Query.Inventory.Transaction.GoodsReceipts;
using Inspection.Application.Contracts.Repositories.Query.Posting;
using Inspection.Application.Contracts.Services.Accounting.AccountBalances;
using Inspection.Application.Contracts.Services.Inventory.System.InventoryBalances;
using Inspection.Application.Contracts.Services.Inventory.System.InventoryCostLayers;
using Inspection.Application.Contracts.Services.Inventory.System.InventoryLedgers;
using Inspection.Application.Contracts.UnitOfWork;
using Inspection.Application.Posting.Posting.Handlers;
using Inspection.Application.Services.Accounting.AccountBalanceServices;
using Inspection.Application.Services.ServicesBase;
using Inspection.Domain.Enums;
using Inspection.Domain.Enums.Posting;
using Inspection.Domain.Event;
using Inspection.Domain.Models.Accounting.PostingEngine;
using Inspection.Domain.Models.Inventory.Ledger;
using Inspection.Domain.Models.Inventory.System.InventoryLedgers;
using Microsoft.Extensions.DependencyInjection;
using NDS.Shared.Application.Multitenant;
using NDS.Shared.Kernel.Exceptions;

namespace Inspection.Application.Posting.Posting.Engine
{
    public class PostingEngine : AccountsServiceBase, IPostingEngine
    {
        private readonly IServiceProvider _serviceProvider;
        private readonly Dictionary<string, Func<IServiceProvider, object>> _repositoryFactories;

        private readonly IAccountBalanceService _accountBalanceService;

        public PostingEngine(
            IAccountUnitOfWork accountUoW,
            IAccountsQueriesManager queriesManager,
            IMapper mapper,
            IAccountBalanceService accountBalanceService,
            IExceptionManager exceptionManager,
            ITenantResolver tenantResolver,
            IServiceProvider serviceProvider
        )
            : base(accountUoW, queriesManager, mapper, exceptionManager)
        {
            _serviceProvider = serviceProvider ?? throw new ArgumentNullException(nameof(serviceProvider));

            _accountBalanceService = accountBalanceService ?? throw new ArgumentNullException(nameof(accountBalanceService));

            // Register repository factories for each document type
            _repositoryFactories = new Dictionary<string, Func<IServiceProvider, object>>
            {
                ["JournalEntry"] = sp => sp.GetService<IJournalEntryQueryRepository>(),
                ["GoodsReceipt"] = sp => sp.GetService<IGoodsReceiptQueryRepository>(),

            };
        }

        public async Task PostAsync<TEntity>(TEntity entity) where TEntity : class, IPostingEntity
        {
            if (entity.Posting == PostingEnum.Posted)
                throw new InvalidOperationException($"Document {entity.GetType().Name} with ID {GetEntityId(entity)} is already posted");

            var handlers = _serviceProvider.GetServices<IPostingHandler<TEntity>>();

            if (!handlers.Any())
                throw new Exception($"No Posting Handlers found for {typeof(TEntity).Name}");

            foreach (var handler in handlers)
            {
                await handler.HandleAsync(entity);
            }

            //Save changes after all handlers have executed
           var saveResult = await _accountUoW.SaveAsync();

            if (!saveResult.Succeeded)
            {
                throw new Exception("Failed to save changes after posting.");
            }
        }

        public async Task<IPostingEntity> GetPostingDocument(string documentCode, long id)
        {
            if (!_repositoryFactories.ContainsKey(documentCode))
                throw new Exception($"Unsupported document type: {documentCode}");

            var repository = _repositoryFactories[documentCode](_serviceProvider);

            // Use reflection to call GetById method
            var method = repository.GetType().GetMethod("GetById");
            if (method == null)
                throw new Exception($"Repository for {documentCode} does not have GetById method");

            // Invoke the method and get the Task object
            var task = (Task)method.Invoke(repository, new object[] { id });

            await task.ConfigureAwait(false);

            // Get the result property
            var resultProperty = task.GetType().GetProperty("Result");
            if (resultProperty == null)
                throw new Exception("Could not get result from task");

            // Get the actual result and cast it to IPostingEntity
            var document = resultProperty.GetValue(task) as IPostingEntity;

            if (document == null)
                throw new Exception($"{documentCode} with ID {id} not found.");

            return document;
        }

        public async Task<PostingResult> PostAllUnpostedDocumentsAsync()
        {
            var results = new PostingResult
            {
                StartTime = DateTime.UtcNow,
                ProcessedDocuments = new List<ProcessedDocumentInfo>()
            };

            foreach (var documentType in _repositoryFactories.Keys)
            {
                await ProcessDocumentTypeAsync(documentType, results);
            }

            // Save all changes at once
            //if (results.SuccessCount > 0)
            //{
            //    var saveResult = await _accountUoW.SaveAsync();
            //    if (!saveResult.Succeeded)
            //    {
            //        throw new Exception($"Failed to save changes after posting: {string.Join(", ", saveResult.Errors)}");
            //    }
            //}

            results.EndTime = DateTime.UtcNow;
            results.TotalDuration = results.EndTime - results.StartTime;

            return results;
        }

        public async Task<PostingResult> PostUnpostedDocumentsByTypeAsync(string documentCode)
        {
            if (!_repositoryFactories.ContainsKey(documentCode))
                throw new Exception($"Unsupported document type: {documentCode}");

            var results = new PostingResult
            {
                StartTime = DateTime.UtcNow,
                ProcessedDocuments = new List<ProcessedDocumentInfo>()
            };

            await ProcessDocumentTypeAsync(documentCode, results);

            results.EndTime = DateTime.UtcNow;
            results.TotalDuration = results.EndTime - results.StartTime;

            return results;
        }

        private async Task ProcessDocumentTypeAsync(string documentCode, PostingResult results)
        {
            var repository = _repositoryFactories[documentCode](_serviceProvider);

            // Get the actual type of the repository
            var repositoryType = repository.GetType();

            // Find the method that returns Task<IEnumerable<T>>
            var method = repositoryType.GetMethod("GetUnpostedDocumentsAsync");
            if (method == null)
                return;

            // Get the return type (Task<IEnumerable<T>>)
            var returnType = method.ReturnType;

            // Get the generic argument (T)
            var entityType = returnType.GetGenericArguments()[0].GetGenericArguments()[0];

            // Create a generic method to process this document type
            var processMethod = typeof(PostingEngine)
                .GetMethod(nameof(ProcessDocumentsOfType), System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance)
                ?.MakeGenericMethod(entityType);

            if (processMethod != null)
            {
                await (Task)processMethod.Invoke(this, new object[] { repository, documentCode, results });
            }
        }

        private async Task ProcessDocumentsOfType<TEntity>(
            object repository,
            string documentCode,
            PostingResult results) where TEntity : class, IPostingEntity
        {
            // Cast repository to the correct type with a generic method
            var getUnpostedMethod = repository.GetType().GetMethod("GetUnpostedDocumentsAsync");

            // Invoke and await properly
            var documents = await (Task<IEnumerable<TEntity>>)getUnpostedMethod.Invoke(repository, null);

            foreach (var document in documents.Where(d => d.Posting != PostingEnum.Posted))
            {
                try
                {
                    await PostAsync(document);

                    results.SuccessCount++;
                    results.ProcessedDocuments.Add(new ProcessedDocumentInfo
                    {
                        DocumentCode = documentCode,
                        DocumentId = GetEntityId(document),
                        Status = "Success",
                        ProcessedAt = DateTime.UtcNow
                    });
                }
                catch (Exception ex)
                {
                    results.FailureCount++;
                    results.ProcessedDocuments.Add(new ProcessedDocumentInfo
                    {
                        DocumentCode = documentCode,
                        DocumentId = GetEntityId(document),
                        Status = "Failed",
                        ErrorMessage = ex.Message,
                        ProcessedAt = DateTime.UtcNow
                    });
                }
            }
        }

        private long GetEntityId(IPostingEntity entity)
        {
            var property = entity.GetType().GetProperty("Id");
            return property != null ? (long)property.GetValue(entity) : 0;
        }

        // Inventory mapping function
        #region Generic Mapping Engine

        private TValue GetPropertyValue<TValue>(object obj, string propertyName)
        {
            if (obj == null) return default;
            var property = obj.GetType().GetProperty(propertyName);
            if (property == null) return default;
            return (TValue)property.GetValue(obj);
        }

        private void SetPropertyValue(object obj, string propertyName, object value)
        {
            if (obj == null) return;
            var property = obj.GetType().GetProperty(propertyName);
            if (property != null && property.CanWrite)
            {
                property.SetValue(obj, value);
            }
        }

        #endregion

        #region Inventory Ledger Functions

        public async Task InventoryLedgerMapping<TEntity, TLine>(
            TEntity entity,
            InventoryLedgerCreateDto dto)
            where TEntity : class
            where TLine : class
        {

            // استخراج الـ Lines من الـ Entity
            var lines = GetPropertyValue<IEnumerable<TLine>>(entity, "GoodsReceiptLines") ??
                       GetPropertyValue<IEnumerable<TLine>>(entity, "SalesInvoiceLines") ??
                       GetPropertyValue<IEnumerable<TLine>>(entity, "Lines");

            // Validate Document before Posting
            ValidateDocumentForPosting(entity, lines);

            var ledgerService = _serviceProvider.GetRequiredService<IInventoryLedgerService>();


            var oldEntries = await ledgerService.GetByReferenceDocumentId(
                GetPropertyValue<long>(entity, "Id")
            );

            foreach (var old in oldEntries.Where(x => !x.IsCancelled))
            {
                await ReverseEntry(old);
            }

            //foreach (var line in lines)
            //{
            //    // استخراج القيم من الـ Entity والـ Line
            //    long itemId = GetPropertyValue<long>(line, "ItemId");
            //    long? itemVariantId = GetPropertyValue<long?>(line, "ItemVariantId");
            //    long warehouseId = GetPropertyValue<long>(entity, "WarehouseId");
            //    long? warehouseLocationId = GetPropertyValue<long?>(line, "WarehouseLocationId");
            //    decimal quantity = GetPropertyValue<decimal>(line, "Quantity");
            //    decimal unitCost = GetPropertyValue<decimal>(line, "UnitCost");
            //    long uomId = GetPropertyValue<long>(line, "UomId");
            //    DateTime transactionDate = GetPropertyValue<DateTime>(entity, "ReceiptDate") != default ?
            //        GetPropertyValue<DateTime>(entity, "ReceiptDate") :
            //        GetPropertyValue<DateTime>(entity, "InvoiceDate");
            //    DateTime postingDate = GetPropertyValue<DateTime>(entity, "PostingDate");
            //    long ReferenceDocumentId = GetPropertyValue<long>(entity, "Id");
            //    long branchId = GetPropertyValue<long>(entity, "BranchId");



            //    // تعيين القيم في الـ DTO
            //    SetPropertyValue(dto, "WarehouseId", warehouseId);
            //    SetPropertyValue(dto, "WarehouseLocationId", warehouseLocationId);
            //    SetPropertyValue(dto, "ItemId", itemId);
            //    SetPropertyValue(dto, "ItemVariantId", itemVariantId);
            //    SetPropertyValue(dto, "UnitOfMeasureId", uomId);
            //    SetPropertyValue(dto, "QuantityIn", quantity);
            //    SetPropertyValue(dto, "UnitCost", unitCost);
            //    SetPropertyValue(dto, "TransactionDate", transactionDate);
            //    SetPropertyValue(dto, "PostingDate", postingDate);
            //    SetPropertyValue(dto, "ReferenceDocumentId", ReferenceDocumentId);
            //    SetPropertyValue(dto, "BranchId", branchId);

            //    SetPropertyValue(dto, "CostingMethod", "FIFO");

            //    string transactionType = entity.GetType().Name switch
            //    {
            //        "GoodsReceipt" => "Purchase",
            //        "SalesInvoice" => "Sales",
            //        _ => "Other"
            //    };
            //    SetPropertyValue(dto, "TransactionType", transactionType);

            //    // التحقق من وجود سجل قديم
            //    var existingLedger = await ledgerService.GetByItemAsync(
            //        itemId: itemId,
            //        warehouseId: warehouseId,
            //        warehouseLocationId: warehouseLocationId
            //    );

            //    //if (existingLedger != null)
            //    //{
            //    //    // تحديث السجل الموجود
            //    //    decimal totalQty = (existingLedger.QuantityIn ?? 0) + quantity;
            //    //    decimal totalCost = ((existingLedger.QuantityIn ?? 0) * (existingLedger.UnitCost ?? 0)) +
            //    //                       (quantity * unitCost);
            //    //    decimal newUnitCost = totalQty > 0 ? totalCost / totalQty : 0;

            //    //    // Map من الـ existing entity إلى Update DTO
            //    //    var updateDto = new InventoryLedgerUpdateDto
            //    //    {
            //    //        Id = existingLedger.Id,
            //    //        BranchId = existingLedger.BranchId,
            //    //        WarehouseId = existingLedger.WarehouseId,
            //    //        WarehouseLocationId = existingLedger.WarehouseLocationId,
            //    //        ItemId = existingLedger.ItemId,
            //    //        UnitOfMeasureId = existingLedger.UnitOfMeasureId,
            //    //        QuantityIn = totalQty,
            //    //        UnitCost = newUnitCost,
            //    //        TransactionDate = transactionDate,
            //    //        PostingDate = postingDate,
            //    //        TransactionType = existingLedger.TransactionType,
            //    //        SourceType = existingLedger.SourceType,
            //    //        ReferenceDocumentId = existingLedger.ReferenceDocumentId,
            //    //        //CostingMethod = existingLedger.CostingMethod ?? CostingMethodEnum.FIFO,
            //    //        CostingMethod = existingLedger.CostingMethod,
            //    //    };

            //    //    await ledgerService.Update(updateDto);
            //    //}
            //    //else
            //    //{
            //    //    // إنشاء سجل جديد باستخدام DTO
            //    //    await ledgerService.Create(dto);
            //    //}
            //}

            var affectedKeys = new HashSet<string>();

            foreach (var line in lines)
            {
                long itemId = GetPropertyValue<long>(line, "ItemId");
                long warehouseId = GetPropertyValue<long>(entity, "WarehouseId");
                long? locationId = GetPropertyValue<long?>(line, "WarehouseLocationId");

                decimal quantity = GetPropertyValue<decimal>(line, "Quantity");
                decimal unitCost = GetPropertyValue<decimal>(line, "UnitCost");
                long uomId = GetPropertyValue<long>(line, "UomId");

                DateTime transactionDate = GetPropertyValue<DateTime>(entity, "ReceiptDate");
                DateTime postingDate = GetPropertyValue<DateTime>(entity, "PostingDate");
                long refId = GetPropertyValue<long>(entity, "Id");
                long branchId = GetPropertyValue<long>(entity, "BranchId");

                //var mapping = await GetPostingMapping("GoodsReceipt");

                var documentCode = entity.GetType().Name;
                var mapping = await GetPostingMapping(documentCode);

                await InsertInventoryLedgerEntry(
                    itemId,
                    warehouseId,
                    locationId,
                    quantity,
                    unitCost,
                    mapping.Direction,
                    uomId,
                    transactionDate,
                    postingDate,
                    refId,
                    branchId,
                    "Purchase"
                );

                // track unique keys
                var key = $"{itemId}_{warehouseId}_{locationId}";
                affectedKeys.Add(key);
            }

            // 🔥 Recalculate مرة واحدة لكل key
            foreach (var key in affectedKeys)
            {
                var parts = key.Split('_');

                await RecalculateBalance(
                    long.Parse(parts[0]),
                    long.Parse(parts[1]),
                    string.IsNullOrEmpty(parts[2]) ? null : long.Parse(parts[2])
                );
            }
        }

        private async Task InsertInventoryLedgerEntry(
            long itemId,
            long warehouseId,
            long? warehouseLocationId,
            decimal quantity,
            decimal unitCost,
            QuantityDirectionEnum direction,
            long uomId,
            DateTime transactionDate,
            DateTime postingDate,
            long referenceDocumentId,
            long branchId,
            string transactionType)
        {
            var ledgerService = _serviceProvider.GetRequiredService<IInventoryLedgerService>();

            decimal qtyIn = direction == QuantityDirectionEnum.QuantityIn ? quantity : 0;
            decimal qtyOut = direction == QuantityDirectionEnum.QuantityOut ? quantity : 0;

            var lastEntry = await ledgerService.GetLastEntryAsync(itemId, warehouseId, warehouseLocationId);
            decimal previousBalance = lastEntry?.BalanceAfter ?? 0;

            //  منع الـ Negative Stock
            if (direction == QuantityDirectionEnum.QuantityOut && quantity > previousBalance)
            {
                throw new Exception(
                    $"Negative stock not allowed. ItemId: {itemId}, Available: {previousBalance}, Requested: {quantity}"
                );
            }

            var dto = new InventoryLedgerCreateDto
            {
                ItemId = itemId,
                WarehouseId = warehouseId,
                WarehouseLocationId = warehouseLocationId,
                UnitOfMeasureId = uomId,
                QuantityIn = qtyIn,
                QuantityOut = qtyOut,
                UnitCost = unitCost,
                TransactionValue = quantity * unitCost,
                TransactionDate = transactionDate,
                PostingDate = postingDate,
                ReferenceDocumentId = referenceDocumentId,
                BranchId = branchId,
                TransactionType = transactionType,
                BalanceAfter = previousBalance + qtyIn - qtyOut,
                CostingMethod = CostingMethodEnum.FIFO
            };

            await ledgerService.Create(dto);
        }

        private async Task ReverseEntry(InventoryLedger old)
        {
            var ledgerService = _serviceProvider.GetRequiredService<IInventoryLedgerService>();

            var reverseDto = new InventoryLedgerCreateDto
            {
                ItemId = old.ItemId,
                WarehouseId = old.WarehouseId,
                WarehouseLocationId = old.WarehouseLocationId,
                UnitOfMeasureId = old.UnitOfMeasureId,
                QuantityIn = old.QuantityOut,
                QuantityOut = old.QuantityIn,
                UnitCost = old.UnitCost,
                TransactionValue = old.TransactionValue,
                TransactionDate = DateTime.UtcNow,
                PostingDate = DateTime.UtcNow,
                ReferenceDocumentId = old.ReferenceDocumentId,
                BranchId = old.BranchId,
                TransactionType = "Reverse",
                IsCancelled = true
            };

            await ledgerService.Create(reverseDto);

            // mark old
            await ledgerService.MarkAsCancelled(old.Id);
        }

        private async Task RecalculateBalance(long itemId, long warehouseId, long? locationId)
        {
            var ledgerService = _serviceProvider.GetRequiredService<IInventoryLedgerService>();

            var entries = await ledgerService.GetEntriesForItem(itemId, warehouseId, locationId);

            decimal running = 0;

            foreach (var e in entries.OrderBy(x => x.PostingDate).ThenBy(x => x.Id))
            {
                running += (e.QuantityIn ?? 0) - (e.QuantityOut ?? 0);

                await ledgerService.UpdateBalanceOnly(e.Id, running);
            }
        }

        private async Task<PostingAccountMapping> GetPostingMapping(string documentCode)
        {
            var mappingRepo = _serviceProvider.GetRequiredService<IPostingAccountMappingQueryRepository>();

            var mappings = await mappingRepo.GetByDocumentCode(documentCode);

            var inventoryMapping = mappings.FirstOrDefault(x => x.IsInventory);

            if (inventoryMapping == null)
                throw new Exception($"No Inventory Mapping found for {documentCode}");

            return inventoryMapping;
        }
        #endregion

        #region Inventory Cost Layer Functions

        public async Task InventoryCostLayerMapping<TEntity, TLine>(
            TEntity entity,
            InventoryCostLayerCreateDto dto)
            where TEntity : class
            where TLine : class
        {
            var costLayerService = _serviceProvider.GetRequiredService<IInventoryCostLayersService>();

            var lines = GetPropertyValue<IEnumerable<TLine>>(entity, "GoodsReceiptLines") ??
                       GetPropertyValue<IEnumerable<TLine>>(entity, "SalesInvoiceLines") ??
                       GetPropertyValue<IEnumerable<TLine>>(entity, "Lines");

            // Validate Document before Posting
            ValidateDocumentForPosting(entity, lines);

            foreach (var line in lines)
            {
                long itemId = GetPropertyValue<long>(line, "ItemId");
                long? itemVariantId = GetPropertyValue<long?>(line, "ItemVariantId");
                long companyId = GetPropertyValue<long>(entity, "CompanyId");
                long warehouseId = GetPropertyValue<long>(entity, "WarehouseId");
                decimal quantity = GetPropertyValue<decimal>(line, "Quantity");
                decimal unitCost = GetPropertyValue<decimal>(line, "UnitCost");
                long referenceDocumentId = GetPropertyValue<long>(entity, "Id");
                DateTime transactionDate = GetPropertyValue<DateTime>(entity, "PostingDate");

                // التحقق من وجود سجل قديم
                var existingLayer = await costLayerService.GetByKey(itemId, warehouseId);

                if (existingLayer != null)
                {
                    var updatedDto = new InventoryCostLayerUpdateDto
                    {
                        Id = existingLayer.Id,
                        ItemId = existingLayer.ItemId,
                        CompanyId = existingLayer.CompanyId,
                        WarehouseId = existingLayer.WarehouseId,
                        QuantityIn = existingLayer.QuantityIn + quantity,
                        QuantityOut = existingLayer.QuantityOut,
                        RemainingQty = existingLayer.RemainingQty + quantity,
                        UnitCost = ((existingLayer.QuantityIn * existingLayer.UnitCost) + (quantity * unitCost)) / (existingLayer.QuantityIn + quantity),
                        ReferenceDocumentId = existingLayer.ReferenceDocumentId,
                        TransactionDate = existingLayer.TransactionDate
                    };

                    var updateResult = await costLayerService.Update(updatedDto);
                    if (!updateResult.Succeeded)
                    {
                        throw new Exception($"Failed to update Inventory Cost Layer: {string.Join(", ", updateResult.Errors)}");
                    }
                }
                else
                {
                    SetPropertyValue(dto, "CompanyId", companyId);
                    SetPropertyValue(dto, "WarehouseId", warehouseId);
                    SetPropertyValue(dto, "ItemId", itemId);
                    SetPropertyValue(dto, "ItemVariantId", itemVariantId);
                    SetPropertyValue(dto, "QuantityIn", quantity);
                    SetPropertyValue(dto, "QuantityOut", 0m);
                    SetPropertyValue(dto, "RemainingQty", quantity);
                    SetPropertyValue(dto, "UnitCost", unitCost);
                    SetPropertyValue(dto, "ReferenceDocumentId", referenceDocumentId);
                    SetPropertyValue(dto, "TransactionDate", transactionDate);

                    var createResult = await costLayerService.Create(dto);
                    if (!createResult.Succeeded)
                    {
                        throw new Exception($"Failed to create Inventory Cost Layer: {string.Join(", ", createResult.Errors)}");
                    }
                }
            }
        }

        #endregion

        #region Inventory Balance Functions

        public async Task InventoryBalanceMapping<TEntity, TLine>(
            TEntity entity,
            InventoryBalanceCreateDto dto)
            where TEntity : class
            where TLine : class
        {
            var balanceService = _serviceProvider.GetRequiredService<IInventoryBalanceService>();

            // استخراج الـ Lines من الـ Entity
            var lines = GetPropertyValue<IEnumerable<TLine>>(entity, "GoodsReceiptLines") ??
                       GetPropertyValue<IEnumerable<TLine>>(entity, "SalesInvoiceLines") ??
                       GetPropertyValue<IEnumerable<TLine>>(entity, "Lines");

            // Validate Document before Posting
            ValidateDocumentForPosting(entity, lines);

            foreach (var line in lines)
            {
                await ProcessInventoryBalance(entity, line, dto, balanceService);
            }
        }

        /// <summary>
        /// معالجة Inventory Balance للـ Line الواحد - نفس منطق UpdateInventoryBalance
        /// </summary>
        private async Task ProcessInventoryBalance<TEntity, TLine>(
            TEntity entity,
            TLine line,
            InventoryBalanceCreateDto dto,
            IInventoryBalanceService balanceService)
            where TEntity : class
            where TLine : class
        {
            long itemId = GetPropertyValue<long>(line, "ItemId");
            long? itemVariantId = GetPropertyValue<long?>(line, "ItemVariantId");
            long warehouseId = GetPropertyValue<long>(entity, "WarehouseId");
            long? warehouseLocationId = GetPropertyValue<long?>(line, "WarehouseLocationId");
            decimal quantity = GetPropertyValue<decimal>(line, "Quantity");
            decimal unitCost = GetPropertyValue<decimal>(line, "UnitCost");
            long uomId = GetPropertyValue<long>(line, "UomId");

            var existingBalance = await balanceService.GetByKey(
                itemId,
                warehouseId,
                warehouseLocationId
            );

            if (existingBalance == null)
            {
                SetPropertyValue(dto, "ItemId", itemId);
                SetPropertyValue(dto, "ItemVariantId", itemVariantId);
                SetPropertyValue(dto, "WarehouseId", warehouseId);
                SetPropertyValue(dto, "WarehouseLocationId", warehouseLocationId);
                SetPropertyValue(dto, "BaseUoMId", uomId);
                SetPropertyValue(dto, "Quantity", quantity);
                SetPropertyValue(dto, "ReservedQuantity", 0m);
                SetPropertyValue(dto, "AvailableQuantity", quantity);
                SetPropertyValue(dto, "AverageCost", unitCost);

                var createResult = await balanceService.Create(dto);
                if (!createResult.Succeeded)
                {
                    throw new Exception($"Failed to create Inventory Balance: {string.Join(", ", createResult.Errors)}");
                }
            }
            else
            {
                existingBalance.Increase(quantity, unitCost);
                existingBalance.Mod_Date = DateTime.UtcNow;
                existingBalance.Mod_User = "system";

                var updateDto = new InventoryBalanceUpdateDto
                {
                    Id = existingBalance.Id,
                    ItemId = existingBalance.ItemId,
                    WarehouseId = existingBalance.WarehouseId,
                    WarehouseLocationId = existingBalance.WarehouseLocationId,
                    BaseUoMId = existingBalance.BaseUoMId,
                    Quantity = existingBalance.Quantity,
                    ReservedQuantity = existingBalance.ReservedQuantity,
                    AvailableQuantity = existingBalance.AvailableQuantity,
                    AverageCost = existingBalance.AverageCost
                };

                var updateResult = await balanceService.Update(updateDto);
                if (!updateResult.Succeeded)
                {
                    throw new Exception($"Failed to update Inventory Balance: {string.Join(", ", updateResult.Errors)}");
                }
            }
        }

        #endregion


        private void ValidateDocumentForPosting<TEntity>(TEntity entity, IEnumerable<object> lines) where TEntity : class
        {
            if (lines == null)
            {
                throw new InvalidOperationException($"No lines property found in entity of type {typeof(TEntity).Name}");
            }

            if (!lines.Any())
            {
                long documentId = GetPropertyValue<long>(entity, "Id");
                throw new InvalidOperationException($"Cannot post {typeof(TEntity).Name} with ID {documentId} because it has no lines");
            }

            // التحقق من أن المستند ليس posted بالفعل
            var postingStatus = GetPropertyValue<PostingEnum>(entity, "Posting");
            if (postingStatus == PostingEnum.Posted)
            {
                long documentId = GetPropertyValue<long>(entity, "Id");
                throw new InvalidOperationException($"Document {typeof(TEntity).Name} with ID {documentId} is already posted");
            }
        }

        public async Task UpdateAccountBalance(Ledger ledger)
        {
            var tenantId = ledger.Tenant_ID;

            var groupedLines = ledger.LedgerLines
                .Where(x => x.ChartOfAccountId.HasValue)
                .GroupBy(x => x.ChartOfAccountId.Value);

            foreach (var group in groupedLines)
            {
                var chartOfAccountId = group.Key;

                var totalDebit = group.Sum(x => x.DebitAmount);
                var totalCredit = group.Sum(x => x.CreditAmount);

                var existing = await _accountBalanceService.GetByItemAsync(
                    tenantId,
                    ledger.CompanyId,
                    chartOfAccountId
                );

                if (existing == null)
                {
                    var createDto = new AccountBalanceCreateDto
                    {
                        Tenant_ID = ledger.Tenant_ID,
                        CompanyId = ledger.CompanyId,
                        ChartOfAccountId = chartOfAccountId,
                        TotalDebit = totalDebit,
                        TotalCredit = totalCredit
                    };

                    var result = await _accountBalanceService.Create(createDto);

                    if (!result.Succeeded)
                        throw new Exception($"Failed to create AccountBalance: {string.Join(",", result.Errors)}");
                }
                else
                {
                    var updateDto = new AccountBalanceUpdateDto
                    {
                        Id = existing.Id,
                        Tenant_ID = ledger.Tenant_ID,
                        CompanyId = existing.CompanyId,
                        ChartOfAccountId = existing.ChartOfAccountId,
                        TotalDebit = existing.TotalDebit + totalDebit,
                        TotalCredit = existing.TotalCredit + totalCredit
                    };

                    var result = await _accountBalanceService.Update(updateDto);

                    if (!result.Succeeded)
                        throw new Exception($"Failed to update AccountBalance: {string.Join(",", result.Errors)}");
                }
            }
        }


        // Reverse Posting
        public async Task<long> ReverseLedgerAsync(long ledgerId)
        {
            var originalLedger = await _queriesManager.Ledger.GetByIdAsync(ledgerId);

            if (originalLedger == null)
                throw new Exception("Ledger not found");

            if (originalLedger.ReverseLedgerId != null)
                throw new Exception("Ledger already reversed");

            // Create reversed ledger
            var reversedLedger = new Ledger
            {
                Tenant_ID = originalLedger.Tenant_ID,
                CompanyId = originalLedger.CompanyId,
                DocumentCode = originalLedger.DocumentCode,
                ReferenceDocumentId = originalLedger.ReferenceDocumentId,
                DocumentDate = originalLedger.DocumentDate,
                PostingDate = DateTime.UtcNow,
                PostingDocumentTypeId = originalLedger.PostingDocumentTypeId,

                CurrencyId = originalLedger.CurrencyId,
                OfficialCurrencyId = originalLedger.OfficialCurrencyId,
                ReportingCurrencyId = originalLedger.ReportingCurrencyId,

                ExchangeRate = originalLedger.ExchangeRate,
                ExchangeRateOfficialCurrency = originalLedger.ExchangeRateOfficialCurrency,
                ExchangeRateReportingCurrency = originalLedger.ExchangeRateReportingCurrency,

                BranchId = originalLedger.BranchId,
                PostedDate = DateTime.UtcNow,

                ReverseLedgerId = originalLedger.Id,

                In_Date = DateTime.UtcNow,
                In_User = "Yousry"
            };

            // Reverse lines
            foreach (var line in originalLedger.LedgerLines)
            {
                var reversedLine = new LedgerLine
                {
                    ChartOfAccountId = line.ChartOfAccountId,
                    CustomerId = line.CustomerId,
                    SupplierId = line.SupplierId,
                    CostCenterId = line.CostCenterId,
                    OperationId = line.OperationId,

                    // SWITCH VALUES
                    DebitAmount = line.CreditAmount,
                    CreditAmount = line.DebitAmount,

                    BaseDebitAmount = line.BaseCreditAmount,
                    BaseCreditAmount = line.BaseDebitAmount,

                    ReportingDebitAmount = line.ReportingCreditAmount,
                    ReportingCreditAmount = line.ReportingDebitAmount,

                    OfficialDebitAmount = line.OfficialCreditAmount,
                    OfficialCreditAmount = line.OfficialDebitAmount,

                    In_Date = DateTime.UtcNow,
                    In_User = "Yousry"
                };

                reversedLedger.LedgerLines.Add(reversedLine);
            }

            reversedLedger.TotalDebit = reversedLedger.LedgerLines.Sum(x => x.DebitAmount);
            reversedLedger.TotalCredit = reversedLedger.LedgerLines.Sum(x => x.CreditAmount);

            var insertResult = await _accountUoW.Ledger.InsertAsync(reversedLedger);
            if (!insertResult.Succeeded)
                throw new Exception("Failed to insert reversed ledger");

            await _accountUoW.SaveAsync();

            originalLedger.ReverseLedgerId = reversedLedger.Id;

            var updateResult = await _accountUoW.Ledger.UpdateAsync(originalLedger);
            if (!updateResult.Succeeded)
                throw new Exception("Failed to update original ledger");

            await CancelDocument(originalLedger);

            await UpdateAccountBalance(reversedLedger);

            await _accountUoW.SaveAsync();

            return reversedLedger.Id;
        }

        private async Task CancelDocument(Ledger ledger)
        {
            if (ledger.DocumentCode == "JournalEntry")
            {
                var doc = await _queriesManager.JournalEntryQuery
                    .GetById(ledger.ReferenceDocumentId);

                if (doc != null)
                {
                    doc.Posting = PostingEnum.Cancelled;

                    var result = await _accountUoW.IJournalEntry.UpdateAsync(doc);
                    if (!result.Succeeded)
                        throw new Exception("Failed to cancel JournalEntry");
                }
            }

            // future:
            // if GoodsReceipt → cancel
        }


    }


}