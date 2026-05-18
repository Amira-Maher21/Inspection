using AutoMapper;
using Inspection.Application.Contracts.Dto.AccountingDtos.Payments.JournalEntrys;
using Inspection.Application.Contracts.Dto.SharedDtos;
using Inspection.Application.Contracts.Managers;
using Inspection.Application.Contracts.Repositories.Command.Accounting.Payments.JournalEntrys;
using Inspection.Application.Contracts.Services.Accounting.Payments.JournalEntrys;
using Inspection.Application.Contracts.Services.MenuManagement.SeriesF;
using Inspection.Application.Contracts.UnitOfWork;
using Inspection.Application.Services.ServicesBase;
using Inspection.Application.Shared.ExcelTemplate;
using Inspection.Domain.Enums.Accounting.payments.JournalEntrys;
using Inspection.Domain.Models.Accounting.Payment.JournalEntryLines;
using NDS.Shared.Application.DataQuery;
using NDS.Shared.Application.Multitenant;
using NDS.Shared.Kernel.BaseReturnTypes;
using NDS.Shared.Kernel.Exceptions;

namespace Inspection.Application.Services.Accounting.Payments.JournalEntrys
{

    public class JournalEntryService : AccountsServiceBase, IJournalEntryService
    {
        private readonly ITenantResolver _tenantResolver;
        private readonly IExcelTemplateGenerator _templateGenerator;
        private readonly ISeriesService _seriesService;


        public JournalEntryService(IAccountUnitOfWork accountUoW, IAccountsQueriesManager queriesManager, IMapper mapper, IExceptionManager exceptionManager, ITenantResolver tenantResolver, IExcelTemplateGenerator templateGenerator, ISeriesService seriesService) : base(accountUoW, queriesManager, mapper, exceptionManager)
        {
            _tenantResolver = tenantResolver;
            _templateGenerator = templateGenerator;
            _seriesService = seriesService;
        }
        #region Create

        public async Task<ReturnBase<JournalEntryDto>> Create(JournalEntryCreateDto dto)
        {
            try
            {
                if (dto.JournalEntryLines == null || !dto.JournalEntryLines.Any())
                    return ReturnBase<JournalEntryDto>.Fail(new List<ReturnBaseError>
                    {
                        new() { ErrorCode = "400", ErrorMessage = "Journal Entry must contain at least one line." }
                    });

                var totalDebit = dto.JournalEntryLines.Sum(x => x.DebitAmount);
                var totalCredit = dto.JournalEntryLines.Sum(x => x.CreditAmount);

                if (totalDebit != totalCredit)
                    return ReturnBase<JournalEntryDto>.Fail(new List<ReturnBaseError>
                    {
                        new() { ErrorCode = "400", ErrorMessage = "Total Debit must equal Total Credit." }
                    });

                var entity = _mapper.Map<Domain.Models.Accounting.Payment.JonrnalEntrys.JournalEntry>(dto);
                entity.TotalDebit = totalDebit;
                entity.TotalCredit = totalCredit;
                entity.Tenant_ID = _tenantResolver.GetTenantName();

                var fiscalYear = await _queriesManager.FiscalYears.GetById(dto.FiscalYearId);

                if (fiscalYear == null)
                    return ReturnBase<JournalEntryDto>.Fail(new List<ReturnBaseError>
                    {
                        new() { ErrorCode = "400", ErrorMessage = "Fiscal year not found" }
                    });

                if (dto.JournalDate < fiscalYear.StartDate || dto.JournalDate > fiscalYear.EndDate)
                    return ReturnBase<JournalEntryDto>.Fail(new List<ReturnBaseError>
                    {
                        new() { ErrorCode = "400", ErrorMessage = "Journal date is outside fiscal year" }
                    });

                if (fiscalYear.IsClosed)
                    return ReturnBase<JournalEntryDto>.Fail(new List<ReturnBaseError>
                    {
                        new() { ErrorCode = "400", ErrorMessage = "Fiscal year is closed" }
                    });


                // SCREEN CODE
                const string SCREEN_CODE = "Journal Entry";

                var series = await _queriesManager.Series.GetByScreen_IDAsync(SCREEN_CODE);

                if (series == null || !series.IsActive)
                {
                    return ReturnBase<JournalEntryDto>.Fail(
                        new Exception($"No active series configured for screen '{SCREEN_CODE}'"),
                        _exceptionManager
                    );
                }

                entity.SeriesId = series.Id;

                // Generate series number
                var seriesResult =
                    await _seriesService.GetSeriesCodeWithCustomDateUsingSeriesDetails(
                        series.Id, entity.JournalDate
                     );

                if (!seriesResult.Succeeded || seriesResult.Result == null)
                    return ReturnBase<JournalEntryDto>.Fail(seriesResult.Errors);

                entity.JournalNo =
                    seriesResult.Result["FinelSeriesCodeAndSeriesNumber"];

                entity.RunningNumber =
                    int.Parse(seriesResult.Result["RunningNumber"]);





                entity.JournalEntryLines = _mapper.Map<List<JournalEntryLine>>(dto.JournalEntryLines);

                var insertResult = await _commands.InsertAsync(entity);
                if (!insertResult.Succeeded)
                    return ReturnBase<JournalEntryDto>.Fail(insertResult.Errors);

                var saveResult = await _accountUoW.SaveAsync();
                if (saveResult == null || !saveResult.Succeeded)
                    return ReturnBase<JournalEntryDto>.Fail(
                        saveResult?.Errors?.ToList() ?? new List<ReturnBaseError>
                        {
                            new() { ErrorCode = "500", ErrorMessage = "Save failed" }
                        });

                return ReturnBase<JournalEntryDto>.Success(_mapper.Map<JournalEntryDto>(entity));
            }
            catch (Exception ex)
            {
                return ReturnBase<JournalEntryDto>.Fail(ex, _exceptionManager);
            }
        }

        #endregion

        #region Update

        public async Task<ReturnBase<JournalEntryDto>> Update(JournalEntryUpdateDto dto)
        {
            try
            {
                var entity = await _queriesManager.JournalEntryQuery.GetById(dto.Id);
                if (entity == null)
                    return ReturnBase<JournalEntryDto>.Fail(new List<ReturnBaseError>
                    {
                        new() { ErrorCode = "404", ErrorMessage = "Journal Entry Not Found" }
                    });



                if (dto.JournalEntryLines == null || !dto.JournalEntryLines.Any())
                    return ReturnBase<JournalEntryDto>.Fail(new List<ReturnBaseError>
                    {
                        new() { ErrorCode = "400", ErrorMessage = "Journal Entry must contain at least one Journal Entry Line." }
                    });

                var totalDebit = dto.JournalEntryLines.Sum(x => x.DebitAmount);
                var totalCredit = dto.JournalEntryLines.Sum(x => x.CreditAmount);

                if (totalDebit != totalCredit)

                    return ReturnBase<JournalEntryDto>.Fail(
                       new List<ReturnBaseError>
                       {
                        new ReturnBaseError
                        {
                            ErrorCode = "400",
                            ErrorMessage = "Total Debit must equal Total Credit."
                        }
                       });
                _mapper.Map(dto, entity);

                entity.TotalDebit = totalDebit;
                entity.TotalCredit = totalCredit;

                entity.JournalEntryLines.Clear();
                entity.JournalEntryLines = _mapper.Map<List<JournalEntryLine>>(dto.JournalEntryLines);

                var updateResult = await _commands.UpdateAsync(entity);
                if (!updateResult.Succeeded)
                    return ReturnBase<JournalEntryDto>.Fail(updateResult.Errors);

                var saveResult = await _accountUoW.SaveAsync();
                if (!saveResult.Succeeded)
                    return ReturnBase<JournalEntryDto>.Fail(saveResult.Errors);

                return ReturnBase<JournalEntryDto>.Success(_mapper.Map<JournalEntryDto>(entity));
            }
            catch (Exception ex)
            {
                return ReturnBase<JournalEntryDto>.Fail(ex, _exceptionManager);
            }
        }

        #endregion

        #region Delete

        public async Task<ReturnBase<JournalEntryDto>> Delete(long id)
        {
            try
            {
                var entity = await _queriesManager.JournalEntryQuery.GetById(id);
                if (entity == null)

                    return ReturnBase<JournalEntryDto>.Fail(
                        new List<ReturnBaseError>
                        {
                        new ReturnBaseError
                        {
                            ErrorCode = "400",
                            ErrorMessage = "Journal Entry Not Found"
                        }
                        }); ;
                var deleteResult = await _commands.DeleteById(id);
                if (!deleteResult.Succeeded)
                    return ReturnBase<JournalEntryDto>.Fail(deleteResult.Errors);

                var saveResult = await _accountUoW.SaveAsync();
                if (!saveResult.Succeeded)
                    return ReturnBase<JournalEntryDto>.Fail(saveResult.Errors);

                return ReturnBase<JournalEntryDto>.Success(_mapper.Map<JournalEntryDto>(entity));
            }
            catch (Exception ex)
            {
                return ReturnBase<JournalEntryDto>.Fail(ex, _exceptionManager);
            }
        }

        #endregion

        #region GetById

        public async Task<ReturnBase<JournalEntryDto>> GetById(long id)
        {
            try
            {
                var entity = await _queriesManager.JournalEntryQuery.GetById(id);
                if (entity == null)
                    return ReturnBase<JournalEntryDto>.Fail(
                     new List<ReturnBaseError>
                     {
                        new ReturnBaseError
                        {
                            ErrorCode = "400",
                            ErrorMessage = "Journal Entry Not Found"
                        }
                     });

                return ReturnBase<JournalEntryDto>.Success(_mapper.Map<JournalEntryDto>(entity));
            }
            catch (Exception ex)
            {
                return ReturnBase<JournalEntryDto>.Fail(ex, _exceptionManager);
            }
        }

        #endregion

        #region Search

        public async Task<ReturnBase<IEnumerable<JournalEntrySearchReturnDto>>> Search(SqlQueryOptions sqlQueryOptions)
        {
            try
            {
                var result = await _queriesManager.JournalEntryQuery.Search(sqlQueryOptions);
                if (!result.Succeeded)
                    return ReturnBase<IEnumerable<JournalEntrySearchReturnDto>>.Fail(result.Errors);

                return ReturnBase<IEnumerable<JournalEntrySearchReturnDto>>.Success(result.Result);
            }
            catch (Exception ex)
            {
                return ReturnBase<IEnumerable<JournalEntrySearchReturnDto>>.Fail(ex, _exceptionManager);
            }
        }

        #endregion




        #region Posting

        public async Task<ReturnBase> PostJournalEntry(long journalEntryId)
        {
            try
            {
                var entity = await _queriesManager.JournalEntryQuery.GetById(journalEntryId);
                if (entity == null)
                    return ReturnBase.Fail(new List<ReturnBaseError>
                    {
                        new() { ErrorCode = "404", ErrorMessage = "Journal Entry Not Found" }
                    });

                var totalDebit = entity.JournalEntryLines.Sum(x => x.DebitAmount);
                var totalCredit = entity.JournalEntryLines.Sum(x => x.CreditAmount);
                if (totalDebit != totalCredit)
                    return ReturnBase.Fail(new List<ReturnBaseError>
                    {
                        new() { ErrorCode = "400", ErrorMessage = "Total Debit must equal Total Credit." }
                    });

                foreach (var line in entity.JournalEntryLines)
                {
                    if (line.DebitAmount <= 0 && line.CreditAmount <= 0)
                        return ReturnBase.Fail(new List<ReturnBaseError>
                        {
                            new() { ErrorCode = "400", ErrorMessage = $"Journal Entry Line {line.Id} has invalid amounts." }
                        });
                }


                entity.DocumentStatus = DocumentStatus.Posted;

                entity.PostingDate = DateTime.Now;

                var updateResult = await _commands.UpdateAsync(entity);
                if (!updateResult.Succeeded)
                    return ReturnBase.Fail(updateResult.Errors);

                var saveResult = await _accountUoW.SaveAsync();
                if (!saveResult.Succeeded)
                    return ReturnBase.Fail(saveResult.Errors);

                return ReturnBase.Success();
            }
            catch (Exception ex)
            {
                return ReturnBase.Fail(new List<ReturnBaseError>
        {
            new() { ErrorCode = "500", ErrorMessage = ex.Message }
        });
            }
        }

        #endregion




        // Import Journal Entries
        public async Task<ReturnBase<ImportResultDto>> ImportJournalEntries(ExcelImportRequestDto dto)
        {
            try
            {
                var finalResult = new ImportResultDto();

                var profile = new JournalEntryImportProfile();

                using var stream = dto.File.OpenReadStream();
                using var workbook = new ClosedXML.Excel.XLWorkbook(stream);
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

                var fiscalYearCache = new Dictionary<string, long>(StringComparer.OrdinalIgnoreCase);
                var branchCache = new Dictionary<string, long>(StringComparer.OrdinalIgnoreCase);
                var currencyCache = new Dictionary<string, long>(StringComparer.OrdinalIgnoreCase);
                var modeOfPaymentCache = new Dictionary<string, long>(StringComparer.OrdinalIgnoreCase);
                var templateCache = new Dictionary<string, long>(StringComparer.OrdinalIgnoreCase);

                for (int r = firstDataRow; r <= lastRow; r++)
                {
                    finalResult.ProcessedCount++;

                    var rawRow = new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase);
                    for (int c = 0; c < headers.Count; c++)
                    {
                        rawRow[headers[c]] = ws.Cell(r, c + 1).GetString().Trim();
                    }

                    var rowErrors = new List<string>();
                    JournalEntryCreateDto? createDto = null;

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
                            Errors = rowErrors.Any() ? rowErrors : new List<string> { "Row mapping failed." }
                        });
                        continue;
                    }

                    // FiscalYear
                    if (rawRow.TryGetValue("FiscalYearCode", out var fyCode) && !string.IsNullOrWhiteSpace(fyCode))
                    {
                        if (!fiscalYearCache.TryGetValue(fyCode, out var id))
                        {
                            var fy = await _queriesManager.FiscalYears.GetByCode(fyCode);
                            if (fy == null)
                                rowErrors.Add($"FiscalYear '{fyCode}' not found.");
                            else
                                fiscalYearCache[fyCode] = id = fy.Id;
                        }

                        if (fiscalYearCache.TryGetValue(fyCode, out var fid))
                            createDto.FiscalYearId = fid;
                    }

                    // Branch
                    if (rawRow.TryGetValue("BranchCode", out var branchCode) && !string.IsNullOrWhiteSpace(branchCode))
                    {
                        if (!branchCache.TryGetValue(branchCode, out var id))
                        {
                            var branch = await _queriesManager.Branches.GetByCode(branchCode);
                            if (branch == null)
                                rowErrors.Add($"Branch '{branchCode}' not found.");
                            else
                                branchCache[branchCode] = id = branch.Id;
                        }

                        if (branchCache.TryGetValue(branchCode, out var bid))
                            createDto.BranchId = bid;
                    }

                    // Currency
                    if (rawRow.TryGetValue("CurrencyCode", out var currencyCode) && !string.IsNullOrWhiteSpace(currencyCode))
                    {
                        if (!currencyCache.TryGetValue(currencyCode, out var id))
                        {
                            var curr = await _queriesManager.Currencies.GetByCode(currencyCode);
                            if (curr == null)
                                rowErrors.Add($"Currency '{currencyCode}' not found.");
                            else
                                currencyCache[currencyCode] = id = curr.Id;
                        }

                        if (currencyCache.TryGetValue(currencyCode, out var cid))
                            createDto.CurrencyId = cid;
                    }

                    // Mode Of Payment
                    //if (rawRow.TryGetValue("ModeOfPaymentCode", out var mopCode) && !string.IsNullOrWhiteSpace(mopCode))
                    //{
                    //    if (!modeOfPaymentCache.TryGetValue(mopCode, out var id))
                    //    {
                    //        var mop = await _queriesManager.ModeOfPayment.GetByCode(mopCode);
                    //        if (mop == null)
                    //            rowErrors.Add($"ModeOfPayment '{mopCode}' not found.");
                    //        else
                    //            modeOfPaymentCache[mopCode] = id = mop.Id;
                    //    }

                    //    if (modeOfPaymentCache.TryGetValue(mopCode, out var mid))
                    //        createDto.ModeOfPaymentId = mid;
                    //}

                    // Journal Entry Template
                    if (rawRow.TryGetValue("JournalEntryTemplateNumber", out var templateNo) && !string.IsNullOrWhiteSpace(templateNo))
                    {
                        if (!templateCache.TryGetValue(templateNo, out var id))
                        {
                            var template = await _queriesManager.JournalEntryTemplate.GetByNumber(templateNo);
                            if (template == null)
                                rowErrors.Add($"JournalEntryTemplate '{templateNo}' not found.");
                            else
                                templateCache[templateNo] = id = template.Id;
                        }

                        if (templateCache.TryGetValue(templateNo, out var tid))
                            createDto.JournalEntryTemplateId = tid;
                    }

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

        public async Task<ReturnBase<FileResultDto>> DownloadTemplate()
        {
            try
            {
                var content = await _templateGenerator
                    .GenerateTemplateAsync<JournalEntryImportTemplateDto>("JournalEntry");

                var file = new FileResultDto
                {
                    Content = content,
                    FileName = "JournalEntry.xlsx"
                };

                return ReturnBase<FileResultDto>.Success(file);
            }
            catch (Exception ex)
            {
                return ReturnBase<FileResultDto>.Fail(ex, _exceptionManager);
            }
        }



        private IJournalEntryCommandRepository _commands
   => _accountUoW.IJournalEntry;
    }
}




