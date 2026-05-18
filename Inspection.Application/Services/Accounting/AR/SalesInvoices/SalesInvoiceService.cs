using AutoMapper;
using ClosedXML.Excel;
using Inspection.Application.Contracts.Dto.AccountingDtos.AR.SalesInvoiceLines;
using Inspection.Application.Contracts.Dto.AccountingDtos.AR.SalesInvoices;
using Inspection.Application.Contracts.Dto.SharedDtos;
using Inspection.Application.Contracts.Managers;
using Inspection.Application.Contracts.Repositories.Command.Accounting.AR.SalesInvoices;
using Inspection.Application.Contracts.Repositories.Query.Accounting.AR.SalesInvoices;
using Inspection.Application.Contracts.Services.Accounting.AR.SalesInvoices;
using Inspection.Application.Contracts.Services.MenuManagement.SeriesF;
using Inspection.Application.Contracts.UnitOfWork;
using Inspection.Application.Services.ServicesBase;
using Inspection.Application.Shared.ExcelTemplate;
using Inspection.Domain.Models.Accounting.AR.SalesInvoices;
using NDS.Shared.Application.DataQuery;
using NDS.Shared.Application.Multitenant;
using NDS.Shared.Kernel.BaseReturnTypes;
using NDS.Shared.Kernel.Exceptions;

namespace Inspection.Application.Services.Accounting.AR.SalesInvoices
{

    public class SalesInvoiceService : AccountsServiceBase, ISalesInvoiceService
    {
        private readonly ITenantResolver _tenantResolver;
        private readonly IAccountsQueriesManager _queriesManager;

        private readonly IExcelTemplateGenerator _templateGenerator;

        private readonly ISeriesService _seriesService;


        public SalesInvoiceService(
            IAccountUnitOfWork accountUoW,
            IAccountsQueriesManager queriesManager,
            IMapper mapper,
            IExceptionManager exceptionManager,
            ITenantResolver tenantResolver,
            IExcelTemplateGenerator templateGenerator
            , ISeriesService seriesService
        )
            : base(accountUoW, queriesManager, mapper, exceptionManager)
        {
            _queriesManager = queriesManager ?? throw new ArgumentNullException(nameof(queriesManager));

            _tenantResolver = tenantResolver;
            _templateGenerator = templateGenerator;
            _seriesService = seriesService;

        }



        private ISalesInvoiceCommandRepository _commands => _accountUoW.SalesInvoice;

        private ISalesInvoiceQueryRepository _queries => _queriesManager.SalesInvoice ?? throw new NullReferenceException("ISupplierQueryRepo is null");



        public async Task<ReturnBase<List<SalesInvoiceLineDto>>> GetAllLines()
        {
            try
            {
                var result = await _queries.GetAll();

                if (!result.Succeeded)
                    return ReturnBase<List<SalesInvoiceLineDto>>.Fail(result.Errors);

                var mapped = _mapper.Map<List<SalesInvoiceLineDto>>(result.Result);

                return ReturnBase<List<SalesInvoiceLineDto>>.Success(mapped);
            }
            catch (Exception ex)
            {
                return ReturnBase<List<SalesInvoiceLineDto>>.Fail(ex, _exceptionManager);
            }
        }


        public async Task<ReturnBase<SalesInvoiceDto>> Create(SalesInvoiceCreateDto dto)
        {
            try
            {
                var entity = _mapper.Map<SalesInvoice>(dto);
                entity.Tenant_ID = _tenantResolver.GetTenantName();

                // SCREEN CODE
                const string SCREEN_CODE = "Sales Invoice";

                var series = await _queriesManager.Series.GetByScreen_IDAsync(SCREEN_CODE);

                if (series == null || !series.IsActive)
                {
                    return ReturnBase<SalesInvoiceDto>.Fail(
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
                    return ReturnBase<SalesInvoiceDto>.Fail(seriesResult.Errors);

                entity.InvoiceNo =
                    seriesResult.Result["FinelSeriesCodeAndSeriesNumber"];

                entity.RunningNumber =
                    int.Parse(seriesResult.Result["RunningNumber"]);


                CreateSalesInvoiceLines(entity, dto);
                CreateSalesInvoiceAdjustments(entity, dto);
                CreateSalesInvoiceSalesPersons(entity, dto);
                var insertResult = await _commands.InsertAsync(entity);
                if (!insertResult.Succeeded)
                    return ReturnBase<SalesInvoiceDto>.Fail(insertResult.Errors);

                var saveResult = await _accountUoW.SaveAsync();
                if (saveResult == null)
                    return ReturnBase<SalesInvoiceDto>.Fail(new List<ReturnBaseError>
            {
                new() { ErrorCode = "500", ErrorMessage = "SaveAsync returned null" }
            });

                if (!saveResult.Succeeded)
                    return ReturnBase<SalesInvoiceDto>.Fail(
                        saveResult.Errors?.ToList() ??
                        new List<ReturnBaseError>
                        {
                    new() { ErrorCode = "500", ErrorMessage = "Save failed" }
                        });

                return ReturnBase<SalesInvoiceDto>.Success(_mapper.Map<SalesInvoiceDto>(entity));
            }
            catch (Exception ex)
            {
                return ReturnBase<SalesInvoiceDto>.Fail(ex, _exceptionManager);
            }
        }


        public async Task<ReturnBase<SalesInvoiceDto>> Update(SalesInvoiceUpdateDto dto)
        {
            try
            {

                var entity = await _queriesManager.SalesInvoice.GetById(dto.Id);
                if (entity == null)
                {
                    return ReturnBase<SalesInvoiceDto>.Fail(new List<ReturnBaseError>
            {
                new() { ErrorCode = "404", ErrorMessage = "SalesInvoice Not Found" }
            });
                }

                entity.Tenant_ID = _tenantResolver.GetTenantName();

                // MAIN FIELDS
                _mapper.Map(dto, entity);

                // CONTACTS
                await UpdateSalesInvoiceLines(entity, dto);
                await UpdateSalesInvoiceAdjustments(entity, dto);
                await UpdateSalesInvoiceSalesPersons(entity, dto);



                var saveResult = await _accountUoW.SaveAsync();
                if (!saveResult.Succeeded)
                    return ReturnBase<SalesInvoiceDto>.Fail(saveResult.Errors);

                return ReturnBase<SalesInvoiceDto>.Success(_mapper.Map<SalesInvoiceDto>(entity));
            }
            catch (Exception ex)
            {
                return ReturnBase<SalesInvoiceDto>.Fail(ex, _exceptionManager);
            }
        }
        //Update List
        private async Task UpdateSalesInvoiceLines(SalesInvoice entity, SalesInvoiceUpdateDto dto)
        {
            var existingContacts = entity.SalesInvoiceLines.ToList();

            if (dto.SalesInvoiceLines == null || !dto.SalesInvoiceLines.Any())
            {
                await _commands.DeleteSalesInvoiceLinesBySalesInvoiceId(entity.Id);
                return;
            }

            var dtoIds = dto.SalesInvoiceLines
                .Where(x => x.Id > 0)
                .Select(x => x.Id)
                .ToHashSet();

            foreach (var contactDto in dto.SalesInvoiceLines)
            {
                if (contactDto.Id == 0)
                {
                    var newContact = _mapper.Map<SalesInvoiceLine>(contactDto);
                    newContact.SalesInvoiceId = entity.Id;
                    entity.SalesInvoiceLines.Add(newContact);
                }
                else
                {
                    var existing = existingContacts.FirstOrDefault(x => x.Id == contactDto.Id);
                    if (existing != null)
                        _mapper.Map(contactDto, existing);
                }
            }

            var removedIds = existingContacts
                .Where(x => !dtoIds.Contains(x.Id))
                .Select(x => x.Id)
                .ToList();

            if (removedIds.Any())
                await _commands.DeleteSalesInvoiceLinesByIds(removedIds);
        }


        private async Task UpdateSalesInvoiceAdjustments(SalesInvoice entity, SalesInvoiceUpdateDto dto)
        {
            var existingContacts = entity.SalesInvoiceSalesAdjustments.ToList();

            if (dto.SalesInvoiceSalesAdjustments == null || !dto.SalesInvoiceSalesAdjustments.Any())
            {
                await _commands.DeleteSalesInvoiceSalesAdjustmentsByAdjustmentId(entity.Id);
                return;
            }

            var dtoIds = dto.SalesInvoiceSalesAdjustments
                .Where(x => x.Id > 0)
                .Select(x => x.Id)
                .ToHashSet();

            foreach (var contactDto in dto.SalesInvoiceSalesAdjustments)
            {
                if (contactDto.Id == 0)
                {
                    var newContact = _mapper.Map<SalesInvoiceSalesAdjustment>(contactDto);
                    newContact.SalesInvoiceId = entity.Id;
                    entity.SalesInvoiceSalesAdjustments.Add(newContact);
                }
                else
                {
                    var existing = existingContacts.FirstOrDefault(x => x.Id == contactDto.Id);
                    if (existing != null)
                        _mapper.Map(contactDto, existing);
                }
            }

            var removedIds = existingContacts
                .Where(x => !dtoIds.Contains(x.Id))
                .Select(x => x.Id)
                .ToList();

            if (removedIds.Any())
                await _commands.DeleteSalesInvoiceSalesAdjustmentsByIds(removedIds);
        }



        private async Task UpdateSalesInvoiceSalesPersons(SalesInvoice entity, SalesInvoiceUpdateDto dto)
        {
            var existingContacts = entity.SalesInvoiceSalesPersons.ToList();

            if (dto.SalesInvoiceSalesPersons == null || !dto.SalesInvoiceSalesPersons.Any())
            {
                await _commands.DeleteSalesInvoiceSalesPersonsBySalesPersonId(entity.Id);
                return;
            }

            var dtoIds = dto.SalesInvoiceSalesPersons
                .Where(x => x.Id > 0)
                .Select(x => x.Id)
                .ToHashSet();

            foreach (var contactDto in dto.SalesInvoiceSalesPersons)
            {
                if (contactDto.Id == 0)
                {
                    var newContact = _mapper.Map<SalesInvoiceSalesPerson>(contactDto);
                    newContact.SalesInvoiceId = entity.Id;
                    entity.SalesInvoiceSalesPersons.Add(newContact);
                }
                else
                {
                    var existing = existingContacts.FirstOrDefault(x => x.Id == contactDto.Id);
                    if (existing != null)
                        _mapper.Map(contactDto, existing);
                }
            }

            var removedIds = existingContacts
                .Where(x => !dtoIds.Contains(x.Id))
                .Select(x => x.Id)
                .ToList();

            if (removedIds.Any())
                await _commands.DeleteSalesInvoiceSalesPersonsByIds(removedIds);
        }



        public async Task<ReturnBase<SalesInvoiceDto>> GetById(long id)
        {
            try
            {
                var entity = await _queries.GetById(id);
                if (entity == null)
                    return ReturnBase<SalesInvoiceDto>.Fail(new List<ReturnBaseError>
                    {
                        new() { ErrorCode = "404", ErrorMessage = "SalesInvoice Not Found" }
                    });

                return ReturnBase<SalesInvoiceDto>.Success(_mapper.Map<SalesInvoiceDto>(entity));
            }
            catch (Exception ex)
            {
                return ReturnBase<SalesInvoiceDto>.Fail(ex, _exceptionManager);
            }
        }


        public async Task<ReturnBase<SalesInvoiceDto>> Delete(long id)
        {
            try
            {
                var entity = await _queriesManager.SalesInvoice.GetById(id);
                if (entity is null)
                {
                    var error = new ReturnBaseError
                    {
                        ErrorCode = "404",
                        ErrorMessage = "SalesInvoice Not Found"
                    };
                    var listOfErrors = new List<ReturnBaseError>() { error };
                    return ReturnBase<SalesInvoiceDto>.Fail(listOfErrors);
                }

                var deleteResult = await _commands.DeleteById(id);

                if (!deleteResult.Succeeded)
                    return ReturnBase<SalesInvoiceDto>.Fail(deleteResult.Errors);

                var saveResult = await _accountUoW.SaveAsync();

                if (!saveResult.Succeeded)
                    return ReturnBase<SalesInvoiceDto>.Fail(saveResult.Errors);

                var mappedResult = _mapper.Map<SalesInvoiceDto>(entity);

                return ReturnBase<SalesInvoiceDto>.Success(mappedResult);

            }
            catch (Exception ex)
            {
                return ReturnBase<SalesInvoiceDto>.Fail(ex, _exceptionManager);
            }
        }


        public async Task<ReturnBase<IEnumerable<SalesInvoiceReturnSearchDto>>> Search(SqlQueryOptions sqlQueryOptions)
        {
            try
            {
                var result = await _queries.Search(sqlQueryOptions);
                if (!result.Succeeded) return ReturnBase<IEnumerable<SalesInvoiceReturnSearchDto>>.Fail(result.Errors);

                var mapped = result.Result.Select(c => _mapper.Map<SalesInvoiceReturnSearchDto>(c)).ToList();
                return ReturnBase<IEnumerable<SalesInvoiceReturnSearchDto>>.Success(mapped);
            }
            catch (Exception ex)
            {
                return ReturnBase<IEnumerable<SalesInvoiceReturnSearchDto>>.Fail(ex, _exceptionManager);
            }
        }

        //Add List 

        private void CreateSalesInvoiceLines(SalesInvoice entity, SalesInvoiceCreateDto dto)
        {
            if (dto.SalesInvoiceLines == null || !dto.SalesInvoiceLines.Any())
            {
                entity.SalesInvoiceLines = new List<SalesInvoiceLine>();
                return;
            }

            entity.SalesInvoiceLines = _mapper.Map<List<SalesInvoiceLine>>(dto.SalesInvoiceLines);

            foreach (var line in entity.SalesInvoiceLines)
            {
                line.SalesInvoice = entity;
            }
        }



        private void CreateSalesInvoiceAdjustments(SalesInvoice entity, SalesInvoiceCreateDto dto)
        {
            if (dto.SalesInvoiceSalesAdjustments == null || !dto.SalesInvoiceSalesAdjustments.Any())
            {
                entity.SalesInvoiceSalesAdjustments = new List<SalesInvoiceSalesAdjustment>();
                return;
            }

            entity.SalesInvoiceSalesAdjustments =
                _mapper.Map<List<SalesInvoiceSalesAdjustment>>(dto.SalesInvoiceSalesAdjustments);

            foreach (var adj in entity.SalesInvoiceSalesAdjustments)
            {
                adj.SalesInvoice = entity;
            }
        }

        private void CreateSalesInvoiceSalesPersons(SalesInvoice entity, SalesInvoiceCreateDto dto)
        {
            if (dto.SalesInvoiceSalesPersons == null || !dto.SalesInvoiceSalesPersons.Any())
            {
                entity.SalesInvoiceSalesPersons = new List<SalesInvoiceSalesPerson>();
                return;
            }

            entity.SalesInvoiceSalesPersons =
                _mapper.Map<List<SalesInvoiceSalesPerson>>(dto.SalesInvoiceSalesPersons);

            foreach (var sp in entity.SalesInvoiceSalesPersons)
            {
                sp.SalesInvoice = entity;
            }
        }



        public async Task<ReturnBase<FileResultDto>> DownloadSalesInvoiceTemplate()
        {
            try
            {
                var content = await _templateGenerator
                    .GenerateTemplateAsync<SalesInvoiceImportTemplateDto>("SalesInvoice");

                return ReturnBase<FileResultDto>.Success(new FileResultDto
                {
                    Content = content,
                    FileName = "SalesInvoice.xlsx"
                });
            }
            catch (Exception ex)
            {
                return ReturnBase<FileResultDto>.Fail(ex, _exceptionManager);
            }
        }
        public async Task<ReturnBase<ImportResultDto>> ImportSalesInvoice(ExcelImportRequestDto dto)
        {
            try
            {
                var finalResult = new ImportResultDto();
                var profile = new SalesInvoiceImportProfile();

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

                for (int r = firstDataRow; r <= lastRow; r++)
                {
                    finalResult.ProcessedCount++;

                    var rawRow = new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase);

                    for (int c = 0; c < headers.Count; c++)
                        rawRow[headers[c]] = ws.Cell(r, c + 1).GetString().Trim();

                    var rowErrors = new List<string>();
                    SalesInvoiceCreateDto? createDto = null;

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

                    // ================= LOOKUPS =================

                    // Customer (REQUIRED)
                    if (rawRow.TryGetValue("CustomerCode", out var customerCode) &&
                        !string.IsNullOrWhiteSpace(customerCode))
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
                    else
                    {
                        rowErrors.Add("CustomerCode is required.");
                    }

                    // Branch (REQUIRED)

                    if (rawRow.TryGetValue("BranchCode", out var branchCode))
                    {
                        var branch = await _queriesManager.Branches.GetByCode(branchCode);
                        if (branch == null)
                            rowErrors.Add($"Branch '{branchCode}' not found.");
                        else
                            createDto.BranchId = branch.Id;
                    }

                    // Warehouse (REQUIRED)

                    if (rawRow.TryGetValue("WarehouseCode", out var warehouseCode) &&
                    !string.IsNullOrWhiteSpace(warehouseCode))
                    {
                        var wh = await _queriesManager.Warehouses.GetByCode(warehouseCode);
                        if (wh == null)
                            rowErrors.Add($"Warehouse '{warehouseCode}' not found.");
                        else
                            createDto.WarehouseId = wh.Id;
                    }


                    // Currency (REQUIRED)
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

                    // PaymentTerm (REQUIRED)
                    if (rawRow.TryGetValue("PaymentTermsCode", out var PaymentTermsCode))
                    {
                        if (!paymentTermCache.TryGetValue(PaymentTermsCode, out var PaymentTermsId))
                        {
                            var pt = await _queriesManager.PaymentTerms.GetByCode(PaymentTermsCode);

                            if (pt == null)
                                rowErrors.Add($"PaymentTerm '{PaymentTermsCode}' not found.");
                            else
                                paymentTermCache[PaymentTermsCode] = PaymentTermsId = pt.Id;
                        }

                        if (paymentTermCache.TryGetValue(PaymentTermsCode, out var pid))
                            createDto.PaymentTermsId = pid;
                    }

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
