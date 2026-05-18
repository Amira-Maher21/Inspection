using AutoMapper;
using ClosedXML.Excel;
using Inspection.Application.Contracts.Dto.AccountingDtos.AR.SalesInvoices;
using Inspection.Application.Contracts.Dto.AccountingDtos.PR.PurchaseInvoices;
using Inspection.Application.Contracts.Dto.SharedDtos;
using Inspection.Application.Contracts.Managers;
using Inspection.Application.Contracts.Repositories.Command.Accounting.PR.PurchaseInvoices;
using Inspection.Application.Contracts.Repositories.Query.Accounting.PR.PurchaseInvoices;
using Inspection.Application.Contracts.Services.Accounting.PR.PurchaseInvoices;
using Inspection.Application.Contracts.Services.MenuManagement.SeriesF;
using Inspection.Application.Contracts.UnitOfWork;
using Inspection.Application.Services.ServicesBase;
using Inspection.Application.Shared.ExcelTemplate;
using Inspection.Domain.Models.Accounting.PR.PurchaseInvoices;
using NDS.Shared.Application.DataQuery;
using NDS.Shared.Application.Multitenant;
using NDS.Shared.Kernel.BaseReturnTypes;
using NDS.Shared.Kernel.Exceptions;

namespace Inspection.Application.Services.Accounting.PR.PurchaseInvoices
{
    public class PurchaseInvoiceService : AccountsServiceBase, IPurchaseInvoiceService
    {
        private readonly ITenantResolver _tenantResolver;
        private readonly IAccountsQueriesManager _queriesManager;
        private readonly ISeriesService _seriesService;
        private readonly IExcelTemplateGenerator _templateGenerator;

        public PurchaseInvoiceService(
            IAccountUnitOfWork accountUoW,
            IAccountsQueriesManager queriesManager,
            IMapper mapper,
            IExceptionManager exceptionManager,
            IExcelTemplateGenerator templateGenerator,
            ITenantResolver tenantResolver,
            ISeriesService seriesService
        ) : base(accountUoW, queriesManager, mapper, exceptionManager)
        {
            _queriesManager = queriesManager;
            _tenantResolver = tenantResolver;
            _seriesService = seriesService;
            _templateGenerator = templateGenerator;
        }

        private IPurchaseInvoiceCommandRepository _commands => _accountUoW.PurchaseInvoice;
        private IPurchaseInvoiceQueryRepository _queries => _queriesManager.PurchaseInvoice;

        public async Task<ReturnBase<PurchaseInvoiceDto>> Create(PurchaseInvoiceCreateDto dto)
        {
            try
            {
                var entity = _mapper.Map<PurchaseInvoice>(dto);
                entity.Tenant_ID = _tenantResolver.GetTenantName();

                // SCREEN CODE
                const string SCREEN_CODE = "Purchase Invoice";

                var series = await _queriesManager.Series.GetByScreen_IDAsync(SCREEN_CODE);

                if (series == null || !series.IsActive)
                {
                    return ReturnBase<PurchaseInvoiceDto>.Fail(
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
                    return ReturnBase<PurchaseInvoiceDto>.Fail(seriesResult.Errors);

                entity.InvoiceNo =
                    seriesResult.Result["FinelSeriesCodeAndSeriesNumber"];

                entity.RunningNumber =
                    int.Parse(seriesResult.Result["RunningNumber"]);


                CreateLines(entity, dto);
                CreateAdjustments(entity, dto);
                var insertResult = await _commands.InsertAsync(entity);
                if (!insertResult.Succeeded)
                    return ReturnBase<PurchaseInvoiceDto>.Fail(insertResult.Errors);

                var saveResult = await _accountUoW.SaveAsync();
                if (saveResult == null)
                    return ReturnBase<PurchaseInvoiceDto>.Fail(new List<ReturnBaseError>
                        {
                            new() { ErrorCode = "500", ErrorMessage = "SaveAsync returned null" }
                        });

                if (!saveResult.Succeeded)
                    return ReturnBase<PurchaseInvoiceDto>.Fail(
                        saveResult.Errors?.ToList() ??
                        new List<ReturnBaseError>
                        {
                    new() { ErrorCode = "500", ErrorMessage = "Save failed" }
                        });

                return ReturnBase<PurchaseInvoiceDto>.Success(_mapper.Map<PurchaseInvoiceDto>(entity));
            }
            catch (Exception ex)
            {
                return ReturnBase<PurchaseInvoiceDto>.Fail(ex, _exceptionManager);
            }
        }


        public async Task<ReturnBase<PurchaseInvoiceDto>> Update(PurchaseInvoiceUpdateDto dto)
        {
            try
            {

                var entity = await _queriesManager.PurchaseInvoice.GetById(dto.Id);
                if (entity == null)
                {
                    return ReturnBase<PurchaseInvoiceDto>.Fail(new List<ReturnBaseError>
            {
                new() { ErrorCode = "404", ErrorMessage = "SalesInvoice Not Found" }
            });
                }

                entity.Tenant_ID = _tenantResolver.GetTenantName();

                // MAIN FIELDS
                _mapper.Map(dto, entity);

                // CONTACTS
                await UpdateLines(entity, dto);
                await UpdateAdjustments(entity, dto);



                var saveResult = await _accountUoW.SaveAsync();
                if (!saveResult.Succeeded)
                    return ReturnBase<PurchaseInvoiceDto>.Fail(saveResult.Errors);

                return ReturnBase<PurchaseInvoiceDto>.Success(_mapper.Map<PurchaseInvoiceDto>(entity));
            }
            catch (Exception ex)
            {
                return ReturnBase<PurchaseInvoiceDto>.Fail(ex, _exceptionManager);
            }
        }

        public async Task<ReturnBase<PurchaseInvoiceDto>> Delete(long id)
        {
            try
            {
                var entity = await _queriesManager.PurchaseInvoice.GetById(id);
                if (entity is null)
                {
                    var error = new ReturnBaseError
                    {
                        ErrorCode = "404",
                        ErrorMessage = "Purchase Invoice Not Found"
                    };
                    var listOfErrors = new List<ReturnBaseError>() { error };
                    return ReturnBase<PurchaseInvoiceDto>.Fail(listOfErrors);
                }

                var deleteResult = await _commands.DeleteById(id);

                if (!deleteResult.Succeeded)
                    return ReturnBase<PurchaseInvoiceDto>.Fail(deleteResult.Errors);

                var saveResult = await _accountUoW.SaveAsync();

                if (!saveResult.Succeeded)
                    return ReturnBase<PurchaseInvoiceDto>.Fail(saveResult.Errors);

                var mappedResult = _mapper.Map<PurchaseInvoiceDto>(entity);

                return ReturnBase<PurchaseInvoiceDto>.Success(mappedResult);

            }
            catch (Exception ex)
            {
                return ReturnBase<PurchaseInvoiceDto>.Fail(ex, _exceptionManager);
            }
        }

        public async Task<ReturnBase<PurchaseInvoiceDto>> GetById(long id)
        {
            try
            {
                var entity = await _queries.GetById(id);
                if (entity == null)
                    return ReturnBase<PurchaseInvoiceDto>.Fail(new List<ReturnBaseError>
                    {
                        new() { ErrorCode = "404", ErrorMessage = "Purchase Invoice  Not Found" }
                    });

                return ReturnBase<PurchaseInvoiceDto>.Success(_mapper.Map<PurchaseInvoiceDto>(entity));
            }
            catch (Exception ex)
            {
                return ReturnBase<PurchaseInvoiceDto>.Fail(ex, _exceptionManager);
            }
        }


        public async Task<ReturnBase<IEnumerable<PurchaseInvoiceReturnSearchDto>>> Search(SqlQueryOptions sqlQueryOptions)
        {
            try
            {
                var result = await _queries.Search(sqlQueryOptions);
                if (!result.Succeeded) return ReturnBase<IEnumerable<PurchaseInvoiceReturnSearchDto>>.Fail(result.Errors);

                var mapped = result.Result.Select(c => _mapper.Map<PurchaseInvoiceReturnSearchDto>(c)).ToList();
                return ReturnBase<IEnumerable<PurchaseInvoiceReturnSearchDto>>.Success(mapped);
            }
            catch (Exception ex)
            {
                return ReturnBase<IEnumerable<PurchaseInvoiceReturnSearchDto>>.Fail(ex, _exceptionManager);
            }
        }


        private void CreateLines(PurchaseInvoice entity, PurchaseInvoiceCreateDto dto)
        {
            if (dto.InvoiceLines == null || !dto.InvoiceLines.Any())
            {
                entity.InvoiceLines = new List<PurchaseInvoiceLine>();
                return;
            }

            entity.InvoiceLines = _mapper.Map<List<PurchaseInvoiceLine>>(dto.InvoiceLines);

            foreach (var line in entity.InvoiceLines)
            {
                line.PurchaseInvoice = entity;
            }
        }

        private void CreateAdjustments(PurchaseInvoice entity, PurchaseInvoiceCreateDto dto)
        {
            if (dto.Adjustments == null || !dto.Adjustments.Any())
            {
                entity.Adjustments = new List<PurchaseInvoiceAdjustment>();
                return;
            }

            entity.Adjustments = _mapper.Map<List<PurchaseInvoiceAdjustment>>(dto.Adjustments);

            foreach (var adj in entity.Adjustments)
            {
                adj.PurchaseInvoice = entity;
            }
        }






        private async Task UpdateLines(PurchaseInvoice entity, PurchaseInvoiceUpdateDto dto)
        {
            var existing = entity.InvoiceLines.ToList();

            if (dto.InvoiceLines == null || !dto.InvoiceLines.Any())
            {
                await _commands.DeleteInvoiceLinesByPurchaseInvoiceId(entity.Id);
                return;
            }

            var dtoIds = dto.InvoiceLines
                .Where(x => x.Id > 0)
                .Select(x => x.Id)
                .ToHashSet();

            foreach (var item in dto.InvoiceLines)
            {
                if (item.Id == 0)
                {
                    var newItem = _mapper.Map<PurchaseInvoiceLine>(item);
                    newItem.PurchaseInvoiceId = entity.Id;
                    entity.InvoiceLines.Add(newItem);
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
                await _commands.DeleteInvoiceLinesByIds(removedIds);
        }


        private async Task UpdateAdjustments(PurchaseInvoice entity, PurchaseInvoiceUpdateDto dto)
        {
            var existing = entity.Adjustments.ToList();

            if (dto.Adjustments == null || !dto.Adjustments.Any())
            {
                await _commands.DeleteAdjustmentsByPurchaseInvoiceId(entity.Id);
                return;
            }

            var dtoIds = dto.Adjustments
                .Where(x => x.Id > 0)
                .Select(x => x.Id)
                .ToHashSet();

            foreach (var item in dto.Adjustments)
            {
                if (item.Id == 0)
                {
                    var newItem = _mapper.Map<PurchaseInvoiceAdjustment>(item);
                    newItem.PurchaseInvoiceId = entity.Id;
                    entity.Adjustments.Add(newItem);
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
                await _commands.DeleteAdjustmentsByIds(removedIds);
        }


        // ================= TEMPLATE =================
        public async Task<ReturnBase<FileResultDto>> DownloadPurchaseInvoiceTemplate()
        {
            try
            {
                var content = await _templateGenerator
                    .GenerateTemplateAsync<SalesInvoiceImportTemplateDto>("Purchase Invoice");

                return ReturnBase<FileResultDto>.Success(new FileResultDto
                {
                    Content = content,
                    FileName = "Purchase Invoice.xlsx"
                });
            }
            catch (Exception ex)
            {
                return ReturnBase<FileResultDto>.Fail(ex, _exceptionManager);
            }
        }
        public async Task<ReturnBase<ImportResultDto>> ImportPurchaseInvoice(ExcelImportRequestDto dto)
        {
            try
            {
                var finalResult = new ImportResultDto();
                var profile = new PurchaseInvoiceImportProfile();

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

                var supplierCache = new Dictionary<string, long>(StringComparer.OrdinalIgnoreCase);
                var currencyCache = new Dictionary<string, long>(StringComparer.OrdinalIgnoreCase);
                var paymentTermCache = new Dictionary<string, long>(StringComparer.OrdinalIgnoreCase);
                var branchCache = new Dictionary<string, long>(StringComparer.OrdinalIgnoreCase);
                var warehouseCache = new Dictionary<string, long>(StringComparer.OrdinalIgnoreCase);
                var salesPersonCache = new Dictionary<string, long>(StringComparer.OrdinalIgnoreCase);
                var salesOrderCache = new Dictionary<string, long>(StringComparer.OrdinalIgnoreCase);

                for (int r = firstDataRow; r <= lastRow; r++)
                {
                    finalResult.ProcessedCount++;

                    var rawRow = new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase);

                    for (int c = 0; c < headers.Count; c++)
                        rawRow[headers[c]] = ws.Cell(r, c + 1).GetString().Trim();

                    var rowErrors = new List<string>();
                    PurchaseInvoiceCreateDto? createDto = null;

                    // ================= MAP + VALIDATE =================
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


                    #region  LOOKUPS





                    // ===== Branch (REQUIRED) =====
                    if (rawRow.TryGetValue("BranchCode", out var branchCode) &&
                         !string.IsNullOrWhiteSpace(branchCode))
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
                    else
                    {
                        rowErrors.Add("BranchCode is required.");
                    }

                    // ===== Currency (REQUIRED) =====
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


                    // ===== PaymentTerms (REQUIRED) =====
                    if (rawRow.TryGetValue("PaymentTermsCode", out var paymentTermsCode))
                    {
                        if (!paymentTermCache.TryGetValue(paymentTermsCode, out var ptId))
                        {
                            var pt = await _queriesManager.PaymentTerms.GetByCode(paymentTermsCode);

                            if (pt == null)
                                rowErrors.Add($"PaymentTerms '{paymentTermsCode}' not found.");
                            else
                                paymentTermCache[paymentTermsCode] = ptId = pt.Id;
                        }

                        if (paymentTermCache.TryGetValue(paymentTermsCode, out var pid))
                            createDto.PaymentTermId = pid;
                    }


                    // ===== Warehouse (OPTIONAL) =====
                    if (rawRow.TryGetValue("WarehouseCode", out var warehouseCode) &&
                             !string.IsNullOrWhiteSpace(warehouseCode))
                    {
                        if (!warehouseCache.TryGetValue(warehouseCode, out var warehouseId))
                        {
                            var warehouse = await _queriesManager.Warehouses.GetByCode(warehouseCode);
                            if (warehouse == null)
                                rowErrors.Add($"Warehouse '{warehouseCode}' not found.");
                            else
                                warehouseCache[warehouseCode] = warehouseId = warehouse.Id;
                        }

                        if (warehouseCache.TryGetValue(warehouseCode, out var wid))
                            createDto.WarehouseId = wid;
                    }


                    // ===== SalesPerson (OPTIONAL) =====
                    if (rawRow.TryGetValue("SalesPersonCode", out var salesPersonCode) &&
                              !string.IsNullOrWhiteSpace(salesPersonCode))
                    {
                        if (!salesPersonCache.TryGetValue(salesPersonCode, out var spId))
                        {
                            var sp = await _queriesManager.SalesPerson.GetByCode(salesPersonCode);
                            if (sp == null)
                                rowErrors.Add($"SalesPerson '{salesPersonCode}' not found.");
                            else
                                salesPersonCache[salesPersonCode] = spId = sp.Id;
                        }

                        if (salesPersonCache.TryGetValue(salesPersonCode, out var sid))
                            createDto.SalesPersonId = sid;
                    }


                    // ===== SalesOrder (OPTIONAL) =====
                    if (rawRow.TryGetValue("SalesOrderCode", out var salesOrderCode) &&
                                  !string.IsNullOrWhiteSpace(salesOrderCode))
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


                    #endregion



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

                    // ================= CREATE =================
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