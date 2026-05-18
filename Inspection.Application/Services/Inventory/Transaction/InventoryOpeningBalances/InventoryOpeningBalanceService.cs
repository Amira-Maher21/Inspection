using AutoMapper;
using ClosedXML.Excel;
using Inspection.Application.Contracts.Dto.Inventory.Transaction.InventoryOpeningBalanceDTOs;
using Inspection.Application.Contracts.Dto.Inventory.Transaction.InventoryOpeningBalanceDTOs.InventoryOpeningBalanceLineDTOs;
using Inspection.Application.Contracts.Dto.SharedDtos;
using Inspection.Application.Contracts.Managers;
using Inspection.Application.Contracts.Repositories.Command.Inventory.Transaction.InventoryOpeningBalances;
using Inspection.Application.Contracts.Repositories.Query.Inventory.Transaction.InventoryOpeningBalances;
using Inspection.Application.Contracts.Services.Inventory.Transaction.InventoryOpeningBalances;
using Inspection.Application.Contracts.Services.MenuManagement.SeriesF;
using Inspection.Application.Contracts.UnitOfWork;
using Inspection.Application.Services.ServicesBase;
using Inspection.Application.Shared.ExcelTemplate;
using Inspection.Domain.Models.Inventory.Transaction.InventoryOpeningsBalance;
using NDS.Shared.Application.DataQuery;
using NDS.Shared.Application.Multitenant;
using NDS.Shared.Kernel.BaseReturnTypes;
using NDS.Shared.Kernel.Exceptions;

namespace Inspection.Application.Services.Inventory.Transaction.InventoryOpeningBalances
{
    public class InventoryOpeningBalanceService : AccountsServiceBase, IInventoryOpeningBalanceService
    {
        private readonly ITenantResolver _tenantResolver;
        private readonly IExcelTemplateGenerator _templateGenerator;
        private readonly ISeriesService _seriesService;


        public InventoryOpeningBalanceService(
            IAccountUnitOfWork accountUoW,
            IAccountsQueriesManager queriesManager,
            IMapper mapper,
            IExceptionManager exceptionManager,
            ITenantResolver tenantResolver,
            IExcelTemplateGenerator templateGenerator, ISeriesService seriesService) : base(accountUoW, queriesManager, mapper, exceptionManager)
        {
            _tenantResolver = tenantResolver;
            _templateGenerator = templateGenerator;
            _seriesService = seriesService;

        }
        private IInventoryOpeningBalanceCommandRepository _commands => _accountUoW.InventoryOpeningBalance;
        private IInventoryOpeningBalanceQueryRepository _queries => _queriesManager.InventoryOpeningBalance;

        public async Task<ReturnBase<InventoryOpeningBalanceDto>> Create(InventoryOpeningBalanceCreateDto dto)
        {
            try
            {
                //  BUSINESS RULE VALIDATION (LINES)
                var lineErrors = ValidateInventoryLineSerialQtyRule(dto.InventoryOpeningBalanceLines);

                if (lineErrors.Any())
                    return ReturnBase<InventoryOpeningBalanceDto>.Fail(lineErrors);

                var entity = _mapper.Map<InventoryOpeningBalance>(dto);
                entity.Tenant_ID = _tenantResolver.GetTenantName();

                entity.SetAsNormalOpening();

                CreateInventoryOpeningBalanceLines(entity, dto);

                var insertResult = await _commands.InsertAsync(entity);
                if (!insertResult.Succeeded)
                    return ReturnBase<InventoryOpeningBalanceDto>.Fail(insertResult.Errors);

                var saveResult = await _accountUoW.SaveAsync();
                if (!saveResult.Succeeded)
                    return ReturnBase<InventoryOpeningBalanceDto>.Fail(saveResult.Errors);

                return ReturnBase<InventoryOpeningBalanceDto>.Success(
                    _mapper.Map<InventoryOpeningBalanceDto>(entity));
            }
            catch (Exception ex)
            {
                return ReturnBase<InventoryOpeningBalanceDto>.Fail(ex, _exceptionManager);
            }
        }

        public async Task<ReturnBase<InventoryOpeningBalanceDto>> Update(InventoryOpeningBalanceUpdateDto dto)
        {
            try
            {
                var entity = await _queriesManager.InventoryOpeningBalance.GetById(dto.Id);

                if (entity == null)
                {
                    return ReturnBase<InventoryOpeningBalanceDto>.Fail(new List<ReturnBaseError>
            {
                new()
                {
                    ErrorCode = "404",
                    ErrorMessage = $"Inventory Opening Balance with Id {dto.Id} was not found"
                }
            });
                }

                // ENTITY VALIDATION
                var validationErrors = ValidateInventoryOpeningBalanceForUpdate(entity);
                if (validationErrors.Any())
                    return ReturnBase<InventoryOpeningBalanceDto>.Fail(validationErrors);

                // LINE BUSINESS RULE VALIDATION (NEW)
                var lineErrors = ValidateInventoryLineSerialQtyRule(dto.InventoryOpeningBalanceLines);
                if (lineErrors.Any())
                    return ReturnBase<InventoryOpeningBalanceDto>.Fail(lineErrors);

                // Map changes
                _mapper.Map(dto, entity);

                // Update lines
                await UpdateInventoryOpeningBalanceLines(entity, dto);

                // Save
                var saveResult = await _accountUoW.SaveAsync();
                if (!saveResult.Succeeded)
                    return ReturnBase<InventoryOpeningBalanceDto>.Fail(saveResult.Errors);

                return ReturnBase<InventoryOpeningBalanceDto>.Success(
                    _mapper.Map<InventoryOpeningBalanceDto>(entity));
            }
            catch (Exception ex)
            {
                return ReturnBase<InventoryOpeningBalanceDto>.Fail(ex, _exceptionManager);
            }
        }
        private List<ReturnBaseError> ValidateInventoryOpeningBalanceForUpdate(InventoryOpeningBalance entity)
        {
            var errors = new List<ReturnBaseError>();

            // Rule: Cannot modify YearEndCarryForward documents
            if (entity.YearEndCarryForward)
            {
                errors.Add(new ReturnBaseError
                {
                    ErrorCode = "IOB_LOCKED",
                    ErrorMessage = "This Inventory Opening Balance was generated from Year End Carry Forward and cannot be modified."
                });
            }

            return errors;
        }

        public async Task<ReturnBase<InventoryOpeningBalanceDto>> Delete(long id)
        {
            try
            {
                var entity = await _queriesManager.InventoryOpeningBalance.GetById(id);
                if (entity == null)
                    return ReturnBase<InventoryOpeningBalanceDto>.Fail(new List<ReturnBaseError>
                    {
                        new() { ErrorCode = "404", ErrorMessage = $"Inventory Opening Balance with Id {id} was not found" }
                    });


                var updateResult = await _commands.DeleteAsync(id);
                if (!updateResult.Succeeded) return ReturnBase<InventoryOpeningBalanceDto>.Fail(updateResult.Errors);

                var saveResult = await _accountUoW.SaveAsync();
                if (!saveResult.Succeeded) return ReturnBase<InventoryOpeningBalanceDto>.Fail(saveResult.Errors);

                return ReturnBase<InventoryOpeningBalanceDto>.Success(_mapper.Map<InventoryOpeningBalanceDto>(entity));
            }
            catch (Exception ex)
            {
                return ReturnBase<InventoryOpeningBalanceDto>.Fail(ex, _exceptionManager);
            }
        }

        public async Task<ReturnBase<InventoryOpeningBalanceDto>> GetById(long id)
        {
            try
            {
                var entity = await _queriesManager.InventoryOpeningBalance.GetById(id);
                if (entity is null)
                {
                    var error = new ReturnBaseError
                    {
                        ErrorCode = "404",
                        ErrorMessage = $"Inventory Opening Balance with Id '{id}' was not found."
                    };
                    var listOfErrors = new List<ReturnBaseError>() { error };
                    return ReturnBase<InventoryOpeningBalanceDto>.Fail(listOfErrors);
                }

                var mappedResult = _mapper.Map<InventoryOpeningBalanceDto>(entity);

                return ReturnBase<InventoryOpeningBalanceDto>.Success(mappedResult);
            }
            catch (Exception ex)
            {
                return ReturnBase<InventoryOpeningBalanceDto>.Fail(ex, _exceptionManager);
            }
        }

        public async Task<ReturnBase<IEnumerable<InventoryOpeningBalanceReturnSearchDto>>> Search(SqlQueryOptions sqlQueryOptions)
        {
            try
            {
                var getResult =
                    await _queriesManager.InventoryOpeningBalance.Search(sqlQueryOptions);

                if (!getResult.Succeeded)
                    return ReturnBase<IEnumerable<InventoryOpeningBalanceReturnSearchDto>>
                        .Fail(getResult.Errors);

                return ReturnBase<IEnumerable<InventoryOpeningBalanceReturnSearchDto>>
                    .Success(getResult.Result);
            }
            catch (Exception ex)
            {
                return ReturnBase<IEnumerable<InventoryOpeningBalanceReturnSearchDto>>
                    .Fail(ex, _exceptionManager);
            }
        }

        public async Task<ReturnBase<ImportResultDto>> ImportInventoryOpeningBalances(ExcelImportRequestDto dto)
        {
            try
            {
                var finalResult = new ImportResultDto();
                var profile = new InventoryOpeningBalanceImportProfile();

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

                // 🔥 CACHES
                var warehouseCache = new Dictionary<string, long>(StringComparer.OrdinalIgnoreCase);
                var fiscalYearCache = new Dictionary<string, long>(StringComparer.OrdinalIgnoreCase);
                var branchCache = new Dictionary<string, long>(StringComparer.OrdinalIgnoreCase);
                var currencyCache = new Dictionary<string, long>(StringComparer.OrdinalIgnoreCase);

                for (int r = firstDataRow; r <= lastRow; r++)
                {
                    finalResult.ProcessedCount++;

                    var rawRow = new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase);
                    for (int c = 0; c < headers.Count; c++)
                        rawRow[headers[c]] = ws.Cell(r, c + 1).GetString().Trim();

                    var rowErrors = new List<string>();
                    InventoryOpeningBalanceCreateDto? createDto = null;

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

                    // 🔴 Warehouse
                    if (rawRow.TryGetValue("WarehouseCode", out var whCode))
                    {
                        if (!warehouseCache.TryGetValue(whCode, out var id))
                        {
                            var entity = await _queriesManager.Warehouses.GetByCode(whCode);
                            if (entity == null)
                                rowErrors.Add($"Warehouse '{whCode}' not found.");
                            else
                                warehouseCache[whCode] = id = entity.Id;
                        }

                        if (warehouseCache.TryGetValue(whCode, out var wid))
                            createDto.WarehouseId = wid;
                    }

                    // 🔴 FiscalYear
                    if (rawRow.TryGetValue("FiscalYearCode", out var fyCode))
                    {
                        if (!fiscalYearCache.TryGetValue(fyCode, out var id))
                        {
                            var entity = await _queriesManager.FiscalYears.GetByCode(fyCode);
                            if (entity == null)
                                rowErrors.Add($"FiscalYear '{fyCode}' not found.");
                            else
                                fiscalYearCache[fyCode] = id = entity.Id;
                        }

                        if (fiscalYearCache.TryGetValue(fyCode, out var fid))
                            createDto.FiscalYearId = fid;
                    }

                    // 🔴 Branch
                    if (rawRow.TryGetValue("BranchCode", out var branchCode))
                    {
                        if (!branchCache.TryGetValue(branchCode, out var id))
                        {
                            var entity = await _queriesManager.Branches.GetByCode(branchCode);
                            if (entity == null)
                                rowErrors.Add($"Branch '{branchCode}' not found.");
                            else
                                branchCache[branchCode] = id = entity.Id;
                        }

                        if (branchCache.TryGetValue(branchCode, out var bid))
                            createDto.BranchId = bid;
                    }

                    // 🔴 Currency
                    if (rawRow.TryGetValue("CurrencyCode", out var currencyCode))
                    {
                        if (!currencyCache.TryGetValue(currencyCode, out var id))
                        {
                            var entity = await _queriesManager.Currencies.GetByCode(currencyCode);
                            if (entity == null)
                                rowErrors.Add($"Currency '{currencyCode}' not found.");
                            else
                                currencyCache[currencyCode] = id = entity.Id;
                        }

                        if (currencyCache.TryGetValue(currencyCode, out var cid))
                            createDto.CurrencyId = cid;
                    }

                    // ❌ Errors
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

                    // ✅ Create
                    var result = await Create(createDto);
                    if (!result.Succeeded)
                    {
                        finalResult.FailedRows.Add(new ImportRowErrorDto
                        {
                            RowNumber = r,
                            RawRowData = string.Join(" | ", rawRow.Select(kv => $"{kv.Key}:{kv.Value}")),
                            Errors = result.Errors.Select(e => $"{e.ErrorCode}: {e.ErrorMessage}").ToList()
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
                    .GenerateTemplateAsync<InventoryOpeningBalanceImportTemplateDto>("InventoryOpeningBalance");

                var file = new FileResultDto
                {
                    Content = content,
                    FileName = "InventoryOpeningBalance.xlsx"
                };

                return ReturnBase<FileResultDto>.Success(file);
            }
            catch (Exception ex)
            {
                return ReturnBase<FileResultDto>.Fail(ex, _exceptionManager);
            }
        }

        // Create && Update  Any Detail For Inventory Opening Balance (Lines) should be handled in these methods to make sure that all operations will be in the same transaction scope

        // InventoryOpeningBalanceLines
        private void CreateInventoryOpeningBalanceLines(InventoryOpeningBalance entity, InventoryOpeningBalanceCreateDto dto)
        {
            if (dto.InventoryOpeningBalanceLines == null || !dto.InventoryOpeningBalanceLines.Any())
            {
                entity.InventoryOpeningBalanceLines = new List<InventoryOpeningBalanceLine>();
                return;
            }

            entity.InventoryOpeningBalanceLines = _mapper.Map<List<InventoryOpeningBalanceLine>>(dto.InventoryOpeningBalanceLines);

            foreach (var line in entity.InventoryOpeningBalanceLines)
            {
                line.InventoryOpeningBalance = entity;
            }
        }

        private async Task UpdateInventoryOpeningBalanceLines(InventoryOpeningBalance entity, InventoryOpeningBalanceUpdateDto dto)
        {
            var existing = entity.InventoryOpeningBalanceLines.ToList();

            if (dto.InventoryOpeningBalanceLines == null || !dto.InventoryOpeningBalanceLines.Any())
            {
                var allIds = existing.Select(x => x.Id).ToList();

                if (allIds.Any())
                    await _commands.DeleteInventoryOpeningBalanceLinesByIds(allIds);
                return;
            }

            var dtoIds = dto.InventoryOpeningBalanceLines
                .Where(x => x.Id > 0)
                .Select(x => x.Id)
                .ToHashSet();

            foreach (var lineDto in dto.InventoryOpeningBalanceLines)
            {
                if (lineDto.Id == 0)
                {
                    var newEntity = _mapper.Map<InventoryOpeningBalanceLine>(lineDto);
                    newEntity.InventoryOpeningBalanceId = entity.Id;
                    entity.InventoryOpeningBalanceLines.Add(newEntity);
                }
                else
                {
                    var existingEntity = existing.FirstOrDefault(x => x.Id == lineDto.Id);

                    if (existingEntity != null)
                        _mapper.Map(lineDto, existingEntity);
                }
            }

            var removed = existing
                .Where(x => !dtoIds.Contains(x.Id))
                .Select(x => x.Id)
                .ToList();

            if (removed.Any())
                await _commands.DeleteInventoryOpeningBalanceLinesByIds(removed);
        }
        private List<ReturnBaseError> ValidateInventoryLineSerialQtyRule(
       IEnumerable<IInventoryLineHasSerialAndQty> lines)
        {
            var errors = new List<ReturnBaseError>();

            if (lines == null || !lines.Any())
                return errors;

            int index = 0;

            foreach (var line in lines)
            {
                index++;

                if (!string.IsNullOrWhiteSpace(line.SerialNumber) && line.Quantity != 1)
                {
                    errors.Add(new ReturnBaseError
                    {
                        ErrorCode = "INV_LINE_SERIAL_QTY",
                        ErrorMessage = $"Line {index}: If SerialNumber is provided, Quantity must be 1."
                    });
                }
            }

            return errors;
        }



    }
}