using AutoMapper;
using Inspection.Application.Contracts.Dto.AccountingDtos.AccountingSetupDtos.AccountingPeriodDTOs;
using Inspection.Application.Contracts.Managers;
using Inspection.Application.Contracts.Repositories.Command.Accounting.AccountSetup.AccountingPeriods;
using Inspection.Application.Contracts.Services.Accounting.AccountSetup.AccountingPeriods;
using Inspection.Application.Contracts.UnitOfWork;
using Inspection.Application.Services.ServicesBase;
using Inspection.Application.Shared.ExcelTemplate;
using Inspection.Application.Shared.SharedValidation;
using Inspection.Domain.Models.Accounting.AccountingSetup.AccountingPeriods;
using Microsoft.EntityFrameworkCore;
using NDS.Shared.Application.DataQuery;
using NDS.Shared.Application.Multitenant;
using NDS.Shared.Kernel.BaseReturnTypes;
using NDS.Shared.Kernel.Exceptions;

namespace Inspection.Application.Services.Accounting.AccountSetup.AccountingPeriods
{
    internal class AccountingPeriodService : AccountsServiceBase, IAccountingPeriodService
    {
        private readonly ITenantResolver _tenantResolver;
        private readonly IExcelTemplateGenerator _templateGenerator;

        public AccountingPeriodService(IAccountUnitOfWork accountUoW, IAccountsQueriesManager queriesManager, IMapper mapper, IExceptionManager exceptionManager, ITenantResolver tenantResolver, IExcelTemplateGenerator templateGenerator) : base(accountUoW, queriesManager, mapper, exceptionManager)
        {
            _tenantResolver = tenantResolver;
            _templateGenerator = templateGenerator;
        }

        public async Task<ReturnBase<AccountingPeriodDto>> Create(AccountingPeriodCreateDto createDto)
        {
            try
            {
                createDto.Code.ValidateAsCode();
                var ruleError = ValidateAccountingPeriodDates(
                   createDto.StartDate,
                   createDto.EndDate,
                   createDto.LockDate);

                if (ruleError != null)
                {
                    return ReturnBase<AccountingPeriodDto>.Fail(
                        new List<ReturnBaseError> { ruleError });
                }

                var entity = _mapper.Map<AccountingPeriod>(createDto);
                entity.Tenant_ID = _tenantResolver.GetTenantName();

                var queryable = _queriesManager.AccountingPeriods.GetAll();
                var overlapError = await ValidateAccountingPeriodAsync(
                    queryable,
                    entity
                );

                if (overlapError != null)
                {
                    return ReturnBase<AccountingPeriodDto>.Fail(new[] { overlapError });
                }

                var insertResult = await _commands.InsertAsync(entity);
                if (!insertResult.Succeeded)
                    return ReturnBase<AccountingPeriodDto>.Fail(insertResult.Errors);

                var saveResult = await _accountUoW.SaveAsync();
                if (!saveResult.Succeeded)
                    return ReturnBase<AccountingPeriodDto>.Fail(saveResult.Errors);

                var resultDto = _mapper.Map<AccountingPeriodDto>(entity);
                return ReturnBase<AccountingPeriodDto>.Success(resultDto);
            }
            catch (Exception ex)
            {
                return ReturnBase<AccountingPeriodDto>.Fail(ex, _exceptionManager);
            }
        }

        public async Task<ReturnBase<AccountingPeriodDto>> Update(AccountingPeriodUpdateDto updateDto)
        {
            try
            {
                updateDto.Code.ValidateAsCode();
                var entity = await _queriesManager.AccountingPeriods.GetById(updateDto.Id);
                if (entity is null)
                {
                    return ReturnBase<AccountingPeriodDto>.Fail(new List<ReturnBaseError>
                    {
                        new ReturnBaseError
                        {
                            ErrorCode = "404",
                            ErrorMessage = "Accounting Period Not Found"
                        }
                    });
                }


                entity.Tenant_ID = _tenantResolver.GetTenantName();


                //  Validate business rules
                var ruleError = ValidateAccountingPeriodDates(
                    updateDto.StartDate,
                    updateDto.EndDate,
                    updateDto.LockDate);

                if (ruleError != null)
                {
                    return ReturnBase<AccountingPeriodDto>.Fail(
                        new List<ReturnBaseError> { ruleError });
                }
                var queryable = _queriesManager.AccountingPeriods.GetAll();
                var overlapError = await ValidateAccountingPeriodAsync(
                    queryable,
                    entity
                );
                // Map INTO existing entity (do not replace)
                _mapper.Map(updateDto, entity);

                var updateResult = await _commands.UpdateAsync(entity);
                if (!updateResult.Succeeded)
                    return ReturnBase<AccountingPeriodDto>.Fail(updateResult.Errors);

                var saveResult = await _accountUoW.SaveAsync();
                if (!saveResult.Succeeded)
                    return ReturnBase<AccountingPeriodDto>.Fail(saveResult.Errors);

                var mappedResult = _mapper.Map<AccountingPeriodDto>(entity);
                return ReturnBase<AccountingPeriodDto>.Success(mappedResult);
            }
            catch (Exception ex)
            {
                return ReturnBase<AccountingPeriodDto>.Fail(ex, _exceptionManager);
            }
        }

        public async Task<ReturnBase<AccountingPeriodDto>> Delete(long id)
        {
            try
            {
                var entity = await _queriesManager.AccountingPeriods.GetById(id);
                if (entity is null)
                {
                    var error = new ReturnBaseError
                    {
                        ErrorCode = "404",
                        ErrorMessage = "Accounting Period Not Found"
                    };
                    var listOfErrors = new List<ReturnBaseError>() { error };
                    return ReturnBase<AccountingPeriodDto>.Fail(listOfErrors);
                }

                var deleteResult = await _commands.DeleteById(id);

                if (!deleteResult.Succeeded)
                    return ReturnBase<AccountingPeriodDto>.Fail(deleteResult.Errors);

                var saveResult = await _accountUoW.SaveAsync();

                if (!saveResult.Succeeded)
                    return ReturnBase<AccountingPeriodDto>.Fail(saveResult.Errors);

                var mappedResult = _mapper.Map<AccountingPeriodDto>(entity);

                return ReturnBase<AccountingPeriodDto>.Success(mappedResult);

            }
            catch (Exception ex)
            {
                return ReturnBase<AccountingPeriodDto>.Fail(ex, _exceptionManager);
            }
        }

        public async Task<ReturnBase<IEnumerable<AccountingPeriodReturnSearchDto>>> Search(SqlQueryOptions sqlQueryOptions)
        {
            try
            {
                var getResult = await _queriesManager.AccountingPeriods.Search(sqlQueryOptions);
                if (!getResult.Succeeded)
                    return ReturnBase<IEnumerable<AccountingPeriodReturnSearchDto>>.Fail(getResult.Errors);

                return ReturnBase<IEnumerable<AccountingPeriodReturnSearchDto>>.Success(getResult.Result);
            }
            catch (Exception ex)
            {
                return ReturnBase<IEnumerable<AccountingPeriodReturnSearchDto>>.Fail(ex, _exceptionManager);
            }
        }

        public async Task<ReturnBase<AccountingPeriodDto>> GetById(long id)
        {
            try
            {
                var entity = await _queriesManager.AccountingPeriods.GetById(id);
                if (entity is null)
                {
                    var error = new ReturnBaseError
                    {
                        ErrorCode = "404",
                        ErrorMessage = "Accounting Period Not Found"
                    };
                    var listOfErrors = new List<ReturnBaseError>() { error };
                    return ReturnBase<AccountingPeriodDto>.Fail(listOfErrors);
                }

                var mappedResult = _mapper.Map<AccountingPeriodDto>(entity);

                return ReturnBase<AccountingPeriodDto>.Success(mappedResult);
            }
            catch (Exception ex)
            {
                return ReturnBase<AccountingPeriodDto>.Fail(ex, _exceptionManager);
            }
        }

        //Import Dynamic Cost Units
        //public async Task<ReturnBase<ImportResultDto>> ImportCostUnits(ExcelImportRequestDto dto)
        //{
        //    try
        //    {
        //        var finalResult = new ImportResultDto();

        //        var profile = new AccountingPeriodImportProfile();

        //        using var stream = dto.File.OpenReadStream();
        //        using var workbook = new XLWorkbook(stream);
        //        var ws = workbook.Worksheets.First();

        //        var headerRow = ws.FirstRowUsed();
        //        if (headerRow == null)
        //            throw new InvalidOperationException("Excel file has no header row.");

        //        var headers = headerRow.Cells()
        //            .Select(c => c.GetString().Trim())
        //            .Where(h => !string.IsNullOrWhiteSpace(h))
        //            .ToList();

        //        var firstDataRow = headerRow.RowNumber() + 1;
        //        var lastRow = ws.LastRowUsed()?.RowNumber() ?? firstDataRow - 1;

        //        for (int r = firstDataRow; r <= lastRow; r++)
        //        {
        //            finalResult.ProcessedCount++;

        //            var rawRow = new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase);
        //            for (int c = 0; c < headers.Count; c++)
        //            {
        //                rawRow[headers[c]] = ws.Cell(r, c + 1).GetString().Trim();
        //            }

        //            var rowErrors = new List<string>();
        //            AccountingPeriodCreateDto? createDto = null;

        //            try
        //            {
        //                createDto = await profile.MapAsync(rawRow, rowErrors);
        //                await profile.ValidateAsync(createDto, rawRow, rowErrors);
        //            }
        //            catch (Exception ex)
        //            {
        //                rowErrors.Add(ex.Message);
        //            }

        //            if (createDto == null)
        //            {
        //                finalResult.FailedRows.Add(new ImportRowErrorDto
        //                {
        //                    RowNumber = r,
        //                    RawRowData = string.Join(" | ", rawRow.Select(kv => $"{kv.Key}:{kv.Value}")),
        //                    Errors = rowErrors.Any()
        //                        ? rowErrors
        //                        : new List<string> { "Row mapping failed." }
        //                });
        //                continue;
        //            }

        //            if (rowErrors.Any())
        //            {
        //                finalResult.FailedRows.Add(new ImportRowErrorDto
        //                {
        //                    RowNumber = r,
        //                    RawRowData = string.Join(" | ", rawRow.Select(kv => $"{kv.Key}:{kv.Value}")),
        //                    Errors = rowErrors
        //                });
        //                continue;
        //            }

        //            var createResult = await Create(createDto);
        //            if (!createResult.Succeeded)
        //            {
        //                finalResult.FailedRows.Add(new ImportRowErrorDto
        //                {
        //                    RowNumber = r,
        //                    RawRowData = string.Join(" | ", rawRow.Select(kv => $"{kv.Key}:{kv.Value}")),
        //                    Errors = createResult.Errors
        //                        .Select(e => $"{e.ErrorCode}: {e.ErrorMessage}")
        //                        .ToList()
        //                });
        //                continue;
        //            }

        //            finalResult.CreatedCount++;
        //        }

        //        return ReturnBase<ImportResultDto>.Success(finalResult);
        //    }
        //    catch (Exception ex)
        //    {
        //        return ReturnBase<ImportResultDto>.Fail(ex, _exceptionManager);
        //    }
        //}

        //public async Task<ReturnBase<FileResultDto>> DownloadTemplate()
        //{
        //    try
        //    {
        //        var content = await _templateGenerator
        //            .GenerateTemplateAsync<AccountingPeriodImportTemplateDto>("AccountingPeriod");

        //        var file = new FileResultDto
        //        {
        //            Content = content,
        //            FileName = "AccountingPeriod.xlsx"
        //        };

        //        return ReturnBase<FileResultDto>.Success(file);
        //    }
        //    catch (Exception ex)
        //    {
        //        return ReturnBase<FileResultDto>.Fail(ex, _exceptionManager);
        //    }
        //}

        private ReturnBaseError? ValidateAccountingPeriodDates(
              DateTime startDate,
              DateTime endDate,
              DateTime lockDate)
        {
            if (endDate < startDate)
            {
                return new ReturnBaseError
                {
                    ErrorCode = "INVALID_DATE_RANGE",
                    ErrorMessage = "End Date must be greater than or equal to Start Date."
                };
            }

            if (lockDate < startDate || lockDate > endDate)
            {
                return new ReturnBaseError
                {
                    ErrorCode = "INVALID_LOCK_DATE",
                    ErrorMessage = "Lock Date must be between Start Date and End Date."
                };
            }

            return null;
        }
        private async Task<ReturnBaseError?> ValidateAccountingPeriodAsync(
         IQueryable<AccountingPeriod> query,
         AccountingPeriod period,
         long? excludeId = null)
        {
            var hasOverlap = await query.AnyAsync(x =>
                x.Tenant_ID == period.Tenant_ID &&
                x.CompanyId == period.CompanyId &&
                x.FiscalYearId == period.FiscalYearId &&
                (!excludeId.HasValue || x.Id != excludeId.Value) &&
                period.StartDate.Date <= x.EndDate.Date &&
                period.EndDate.Date >= x.StartDate.Date
            );

            return hasOverlap
                ? new ReturnBaseError
                {
                    ErrorCode = "ACCOUNTING_PERIOD_OVERLAP",
                    ErrorMessage = "Accounting period dates overlap with an existing period."
                }
                : null;
        }
        private IAccountingPeriodCommandRepository _commands
        {
            get { return _accountUoW.AccountingPeriod; }
        }



    }
}