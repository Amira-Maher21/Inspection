using AutoMapper;
using ClosedXML.Excel;
using Inspection.Application.Contracts.Dto.SalesManagment.sales.Transactions.DeliveryNotes;
using Inspection.Application.Contracts.Dto.SharedDtos;
using Inspection.Application.Contracts.Managers;
using Inspection.Application.Contracts.Repositories.Command.SalesManagment.sales.DeliveryNotes;
using Inspection.Application.Contracts.Repositories.Query.SalesManagment.Transactions.DeliveryNotes;
using Inspection.Application.Contracts.Services.MenuManagement.SeriesF;
using Inspection.Application.Contracts.Services.SalesManagment.sales.DeliveryNotes;
using Inspection.Application.Contracts.UnitOfWork;
using Inspection.Application.Services.ServicesBase;
using Inspection.Application.Shared.ExcelTemplate;
using Inspection.Domain.Models.SalesManagment.Transaction.DeliveryNotes;
using NDS.Shared.Application.DataQuery;
using NDS.Shared.Application.Multitenant;
using NDS.Shared.Kernel.BaseReturnTypes;
using NDS.Shared.Kernel.Exceptions;

namespace Inspection.Application.Services.SalesManagment.Transactions.DeliveryNotes
{
    public class DeliveryNoteService : AccountsServiceBase, IDeliveryNoteService
    {
        private readonly ITenantResolver _tenantResolver;
        private readonly ISeriesService _seriesService;
        private readonly IAccountsQueriesManager _queriesManager;
        private readonly IExcelTemplateGenerator _templateGenerator;
        public DeliveryNoteService(
            IAccountUnitOfWork uow,
            IAccountsQueriesManager queriesManager,
            IMapper mapper,
            IExceptionManager exceptionManager,
            ITenantResolver tenantResolver,
            ISeriesService seriesService,
           IExcelTemplateGenerator templateGenerator

        ) : base(uow, queriesManager, mapper, exceptionManager)
        {
            _tenantResolver = tenantResolver;
            _seriesService = seriesService;
            _queriesManager = queriesManager;
            _templateGenerator = templateGenerator;

        }

        private IDeliveryNoteCommandRepository _commands => _accountUoW.DeliveryNote;
        private IDeliveryNoteQueryRepository _queries => _queriesManager.DeliveryNote;

        public async Task<ReturnBase<DeliveryNoteDto>> Create(DeliveryNoteCreateDto dto)
        {
            try
            {
                var entity = _mapper.Map<DeliveryNote>(dto);
                entity.Tenant_ID = _tenantResolver.GetTenantName();

                // ===== SERIES =====
                const string SCREEN_CODE = "Delivery Note";

                var series = await _queriesManager.Series.GetByScreen_IDAsync(SCREEN_CODE);

                if (series == null || !series.IsActive)
                    return ReturnBase<DeliveryNoteDto>.Fail(
                        new Exception($"No active series for '{SCREEN_CODE}'"),
                        _exceptionManager
                    );

                entity.SeriesId = series.Id;

                var seriesResult =
                    await _seriesService.GetSeriesCodeWithCustomDateUsingSeriesDetails(
                        series.Id, null
                    );

                if (!seriesResult.Succeeded || seriesResult.Result == null)
                    return ReturnBase<DeliveryNoteDto>.Fail(seriesResult.Errors);

                entity.DeliveryNoteNo =
                    seriesResult.Result["FinelSeriesCodeAndSeriesNumber"];

                entity.RunningNumber =
                    int.Parse(seriesResult.Result["RunningNumber"]);

                // ===== LINES =====
                CreateLines(entity, dto);

                // ===== INSERT =====
                var insertResult = await _commands.InsertAsync(entity);
                if (!insertResult.Succeeded)
                    return ReturnBase<DeliveryNoteDto>.Fail(insertResult.Errors);

                var saveResult = await _accountUoW.SaveAsync();
                if (!saveResult.Succeeded)
                    return ReturnBase<DeliveryNoteDto>.Fail(saveResult.Errors);

                return ReturnBase<DeliveryNoteDto>.Success(_mapper.Map<DeliveryNoteDto>(entity));
            }
            catch (Exception ex)
            {
                return ReturnBase<DeliveryNoteDto>.Fail(ex, _exceptionManager);
            }
        }

        public async Task<ReturnBase<DeliveryNoteDto>> Update(DeliveryNoteUpdateDto dto)
        {
            try
            {
                var entity = await _queries.GetById(dto.Id);

                if (entity == null)
                    return ReturnBase<DeliveryNoteDto>.Fail(new List<ReturnBaseError>
                    {
                        new() { ErrorCode = "404", ErrorMessage = "DeliveryNote Not Found" }
                    });

                entity.Tenant_ID = _tenantResolver.GetTenantName();

                _mapper.Map(dto, entity);

                await UpdateLines(entity, dto);

                var saveResult = await _accountUoW.SaveAsync();
                if (!saveResult.Succeeded)
                    return ReturnBase<DeliveryNoteDto>.Fail(saveResult.Errors);

                return ReturnBase<DeliveryNoteDto>.Success(_mapper.Map<DeliveryNoteDto>(entity));
            }
            catch (Exception ex)
            {
                return ReturnBase<DeliveryNoteDto>.Fail(ex, _exceptionManager);
            }
        }

        public async Task<ReturnBase<DeliveryNoteDto>> Delete(long id)
        {
            try
            {
                var entity = await _queries.GetById(id);

                if (entity == null)
                    return ReturnBase<DeliveryNoteDto>.Fail(new List<ReturnBaseError>
                    {
                        new() { ErrorCode = "404", ErrorMessage = "DeliveryNote Not Found" }
                    });

                var deleteResult = await _commands.DeleteById(id);
                if (!deleteResult.Succeeded)
                    return ReturnBase<DeliveryNoteDto>.Fail(deleteResult.Errors);

                var saveResult = await _accountUoW.SaveAsync();
                if (!saveResult.Succeeded)
                    return ReturnBase<DeliveryNoteDto>.Fail(saveResult.Errors);

                return ReturnBase<DeliveryNoteDto>.Success(_mapper.Map<DeliveryNoteDto>(entity));
            }
            catch (Exception ex)
            {
                return ReturnBase<DeliveryNoteDto>.Fail(ex, _exceptionManager);
            }
        }

        public async Task<ReturnBase<DeliveryNoteDto>> GetById(long id)
        {
            try
            {
                var entity = await _queries.GetById(id);

                if (entity == null)
                    return ReturnBase<DeliveryNoteDto>.Fail(new List<ReturnBaseError>
                    {
                        new() { ErrorCode = "404", ErrorMessage = "DeliveryNote Not Found" }
                    });

                return ReturnBase<DeliveryNoteDto>.Success(_mapper.Map<DeliveryNoteDto>(entity));
            }
            catch (Exception ex)
            {
                return ReturnBase<DeliveryNoteDto>.Fail(ex, _exceptionManager);
            }
        }

        public async Task<ReturnBase<IEnumerable<DeliveryNoteReturnSearchDto>>> Search(SqlQueryOptions options)
        {
            try
            {
                var result = await _queries.Search(options);

                if (!result.Succeeded)
                    return ReturnBase<IEnumerable<DeliveryNoteReturnSearchDto>>.Fail(result.Errors);

                return ReturnBase<IEnumerable<DeliveryNoteReturnSearchDto>>.Success(result.Result);
            }
            catch (Exception ex)
            {
                return ReturnBase<IEnumerable<DeliveryNoteReturnSearchDto>>.Fail(ex, _exceptionManager);
            }
        }



        // ================= PRIVATE =================

        private void CreateLines(DeliveryNote entity, DeliveryNoteCreateDto dto)
        {
            if (dto.DeliveryNoteLines == null || !dto.DeliveryNoteLines.Any())
            {
                entity.DeliveryNoteLines = new List<DeliveryNoteLine>();
                return;
            }

            entity.DeliveryNoteLines =
                _mapper.Map<List<DeliveryNoteLine>>(dto.DeliveryNoteLines);

            foreach (var line in entity.DeliveryNoteLines)
            {
                line.DeliveryNote = entity;
            }
        }

        private async Task UpdateLines(DeliveryNote entity, DeliveryNoteUpdateDto dto)
        {
            var existing = entity.DeliveryNoteLines.ToList();

            if (dto.DeliveryNoteLines == null || !dto.DeliveryNoteLines.Any())
            {
                await _commands.DeleteDeliveryNoteLinesByDeliveryNoteId(entity.Id);
                return;
            }

            var dtoIds = dto.DeliveryNoteLines
                .Where(x => x.Id > 0)
                .Select(x => x.Id)
                .ToHashSet();

            foreach (var item in dto.DeliveryNoteLines)
            {
                if (item.Id == 0)
                {
                    var newItem = _mapper.Map<DeliveryNoteLine>(item);
                    newItem.DeliveryNoteId = entity.Id;
                    entity.DeliveryNoteLines.Add(newItem);
                }
                else
                {
                    var existingItem = existing.FirstOrDefault(x => x.Id == item.Id);
                    if (existingItem != null)
                        _mapper.Map(item, existingItem);
                }
            }

            var removedIds = existing
                .Where(x => !dtoIds.Contains(x.Id))
                .Select(x => x.Id)
                .ToList();

            if (removedIds.Any())
                await _commands.DeleteDeliveryNoteLinesByIds(removedIds);
        }




        public async Task<ReturnBase<FileResultDto>> DownloadDeliveryNoteTemplate()
        {
            try
            {
                var content = await _templateGenerator
                    .GenerateTemplateAsync<DeliveryNoteImportTemplateDto>("Delivery Note");

                return ReturnBase<FileResultDto>.Success(new FileResultDto
                {
                    Content = content,
                    FileName = "Delivery Note.xlsx"
                });
            }
            catch (Exception ex)
            {
                return ReturnBase<FileResultDto>.Fail(ex, _exceptionManager);
            }
        }



        public async Task<ReturnBase<ImportResultDto>> ImportDeliveryNote(ExcelImportRequestDto dto)
        {
            try
            {
                var finalResult = new ImportResultDto();
                var profile = new DeliveryNoteImportProfile();

                using var stream = dto.File.OpenReadStream();
                using var workbook = new XLWorkbook(stream);
                var ws = workbook.Worksheets.First();

                var headerRow = ws.FirstRowUsed();
                if (headerRow == null)
                    throw new InvalidOperationException("Excel file has no header row.");

                var headers = headerRow.Cells()
                    .Select(c => c.GetString().Trim())
                    .Where(h => !string.IsNullOrWhiteSpace(h))
                    .ToList();

                var firstDataRow = headerRow.RowNumber() + 1;
                var lastRow = ws.LastRowUsed()?.RowNumber() ?? firstDataRow - 1;

                var customerCache = new Dictionary<string, long>(StringComparer.OrdinalIgnoreCase);
                var currencyCache = new Dictionary<string, long>(StringComparer.OrdinalIgnoreCase);
                var paymentTermCache = new Dictionary<string, long>(StringComparer.OrdinalIgnoreCase);
                var branchCache = new Dictionary<string, long>(StringComparer.OrdinalIgnoreCase);
                var warehouseCache = new Dictionary<string, long>(StringComparer.OrdinalIgnoreCase);
                var salesOrderCache = new Dictionary<string, long>(StringComparer.OrdinalIgnoreCase);

                // ✅ NEW
                var salesInvoiceCache = new Dictionary<string, long>(StringComparer.OrdinalIgnoreCase);

                for (int r = firstDataRow; r <= lastRow; r++)
                {
                    finalResult.ProcessedCount++;

                    var rawRow = new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase);

                    for (int c = 0; c < headers.Count; c++)
                        rawRow[headers[c]] = ws.Cell(r, c + 1).GetString().Trim();

                    var rowErrors = new List<string>();
                    DeliveryNoteCreateDto? createDto = null;

                    // MAP + VALIDATE
                    try
                    {
                        createDto = await profile.MapAsync(rawRow, rowErrors);
                        await profile.ValidateAsync(createDto, rawRow, rowErrors);
                    }
                    catch (Exception ex)
                    {
                        rowErrors.Add(ex.Message);
                    }

                    if (createDto == null)
                    {
                        finalResult.FailedRows.Add(new ImportRowErrorDto
                        {
                            RowNumber = r,
                            RawRowData = string.Join(" | ", rawRow.Select(kv => $"{kv.Key}:{kv.Value}")),
                            Errors = rowErrors.Any() ? rowErrors : new() { "Row mapping failed." }
                        });
                        continue;
                    }

                    // ================= LOOKUPS =================

                    // Customer
                    if (rawRow.TryGetValue("CustomerCode", out var customerCode))
                    {
                        if (!customerCache.TryGetValue(customerCode, out var customerId))
                        {
                            var customer = await _queriesManager.CustomerQuery.GetByCode(customerCode);
                            if (customer == null)
                                rowErrors.Add($"Customer '{customerCode}' not found.");
                            else
                                customerCache[customerCode] = customerId = customer.Id;
                        }

                        if (customerCache.TryGetValue(customerCode, out var cid))
                            createDto.CustomerId = cid;
                    }

                    // Branch
                    if (rawRow.TryGetValue("BranchCode", out var branchCode))
                    {
                        if (!branchCache.TryGetValue(branchCode, out var branchId))
                        {
                            var branch = await _queriesManager.Branches.GetByCode(branchCode);
                            if (branch == null)
                                rowErrors.Add($"Branch '{branchCode}' not found.");
                            else
                                branchCache[branchCode] = branchId = branch.Id;
                        }

                        if (branchCache.TryGetValue(branchCode, out var bid))
                            createDto.BranchId = bid;
                    }

                    // Currency
                    if (rawRow.TryGetValue("CurrencyCode", out var currencyCode))
                    {
                        if (!currencyCache.TryGetValue(currencyCode, out var currencyId))
                        {
                            var currency = await _queriesManager.Currencies.GetByCode(currencyCode);
                            if (currency == null)
                                rowErrors.Add($"Currency '{currencyCode}' not found.");
                            else
                                currencyCache[currencyCode] = currencyId = currency.Id;
                        }

                        if (currencyCache.TryGetValue(currencyCode, out var cid))
                            createDto.CurrencyId = cid;
                    }

                    // PaymentTerms
                    if (rawRow.TryGetValue("PaymentTermsCode", out var paymentTermsCode))
                    {
                        if (!paymentTermCache.TryGetValue(paymentTermsCode, out var ptId))
                        {
                            var pt = await _queriesManager.PaymentTerms.GetByCode(paymentTermsCode);
                            if (pt == null)
                                rowErrors.Add($"PaymentTerm '{paymentTermsCode}' not found.");
                            else
                                paymentTermCache[paymentTermsCode] = ptId = pt.Id;
                        }

                        if (paymentTermCache.TryGetValue(paymentTermsCode, out var pid))
                            createDto.PaymentTermId = pid;
                    }

                    // Warehouse
                    if (rawRow.TryGetValue("WarehouseCode", out var warehouseCode))
                    {
                        if (!warehouseCache.TryGetValue(warehouseCode, out var wid))
                        {
                            var warehouse = await _queriesManager.Warehouses.GetByCode(warehouseCode);
                            if (warehouse == null)
                                rowErrors.Add($"Warehouse '{warehouseCode}' not found.");
                            else
                                warehouseCache[warehouseCode] = wid = warehouse.Id;
                        }

                        if (warehouseCache.TryGetValue(warehouseCode, out var w))
                            createDto.WarehouseId = w;
                    }

                    // SalesOrder
                    if (rawRow.TryGetValue("SalesOrderCode", out var salesOrderCode))
                    {
                        if (!salesOrderCache.TryGetValue(salesOrderCode, out var soId))
                        {
                            var so = await _queriesManager.SalesOrder.GetByCode(salesOrderCode);
                            if (so == null)
                                rowErrors.Add($"SalesOrder '{salesOrderCode}' not found.");
                            else
                                salesOrderCache[salesOrderCode] = soId = so.Id;
                        }

                        if (salesOrderCache.TryGetValue(salesOrderCode, out var oid))
                            createDto.SalesOrderId = oid;
                    }

                    // ✅ NEW: SalesInvoice
                    if (rawRow.TryGetValue("SalesInvoiceCode", out var salesInvoiceCode))
                    {
                        if (!salesInvoiceCache.TryGetValue(salesInvoiceCode, out var siId))
                        {
                            var si = await _queriesManager.SalesInvoice.GetByCode(salesInvoiceCode);
                            if (si == null)
                                rowErrors.Add($"SalesInvoice '{salesInvoiceCode}' not found.");
                            else
                                salesInvoiceCache[salesInvoiceCode] = siId = si.Id;
                        }

                        if (salesInvoiceCache.TryGetValue(salesInvoiceCode, out var sid))
                            createDto.SalesInvoiceId = sid;
                    }

                    // ================= FIX NULLS =================
                    createDto.Notes ??= "";
                    createDto.ShipmentAddress ??= "";

                    // ================= ERRORS =================
                    if (rowErrors.Any())
                    {
                        finalResult.FailedRows.Add(new ImportRowErrorDto
                        {
                            RowNumber = r,
                            RawRowData = string.Join(" | ", rawRow.Select(kv => $"{kv.Key}:{kv.Value}")),
                            Errors = rowErrors
                        });
                        continue;
                    }

                    // CREATE
                    var createResult = await Create(createDto);

                    if (!createResult.Succeeded)
                    {
                        finalResult.FailedRows.Add(new ImportRowErrorDto
                        {
                            RowNumber = r,
                            RawRowData = string.Join(" | ", rawRow.Select(kv => $"{kv.Key}:{kv.Value}")),
                            Errors = createResult.Errors
                                .Select(e => $"{e.ErrorCode}: {e.ErrorMessage}")
                                .ToList()
                        });
                        continue;
                    }

                    finalResult.CreatedCount++;
                }

                return ReturnBase<ImportResultDto>.Success(finalResult);
            }
            catch (Exception ex)
            {
                return ReturnBase<ImportResultDto>.Fail(ex, _exceptionManager);
            }
        }
    }
}
