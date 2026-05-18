using AutoMapper;
using ClosedXML.Excel;
using Inspection.Application.Contracts.Dto.Inventory.Transaction.InventoryAdjustmentDTOs;
using Inspection.Application.Contracts.Dto.SharedDtos;
using Inspection.Application.Contracts.Managers;
using Inspection.Application.Contracts.Repositories.Command.Inventory.Transaction.InventoryAdjustments;
using Inspection.Application.Contracts.Repositories.Query.Inventory.Transaction.InventoryAdjustments;
using Inspection.Application.Contracts.Services.Inventory.Transaction.InventoryAdjustments;
using Inspection.Application.Contracts.Services.MenuManagement.SeriesF;
using Inspection.Application.Contracts.UnitOfWork;
using Inspection.Application.Services.ServicesBase;
using Inspection.Application.Shared.ExcelTemplate;
using Inspection.Domain.Models.Inventory.Transaction.InventoryAdjustments;
using NDS.Shared.Application.DataQuery;
using NDS.Shared.Application.Multitenant;
using NDS.Shared.Kernel.BaseReturnTypes;
using NDS.Shared.Kernel.Exceptions;

namespace Inspection.Application.Services.Inventory.Transaction.InventoryAdjustments
{
    public class InventoryAdjustmentService : AccountsServiceBase, IInventoryAdjustmentService
    {
        private readonly ITenantResolver _tenantResolver;
        private readonly IExcelTemplateGenerator _templateGenerator;
        private readonly ISeriesService _seriesService;

        public InventoryAdjustmentService(
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
        private IInventoryAdjustmentCommandRepository _commands => _accountUoW.InventoryAdjustment;
        private IInventoryAdjustmentQueryRepository _queries => _queriesManager.InventoryAdjustment;

        public async Task<ReturnBase<InventoryAdjustmentDto>> Create(InventoryAdjustmentCreateDto dto)
        {
            try
            {
                var entity = _mapper.Map<InventoryAdjustment>(dto);
                entity.Tenant_ID = _tenantResolver.GetTenantName();

                // Series
                const string SCREEN_CODE = "Inventory Adjustment";

                var series = await _queriesManager.Series.GetByScreen_IDAsync(SCREEN_CODE);

                if (series == null || !series.IsActive)
                    return ReturnBase<InventoryAdjustmentDto>.Fail(
                        new Exception($"No active series configured for screen '{SCREEN_CODE}'"),
                        _exceptionManager);

                entity.SeriesId = series.Id;

                var seriesResult = await _seriesService
                    .GetSeriesCodeWithCustomDateUsingSeriesDetails(series.Id, entity.InventoryAdjustmentDate);

                if (!seriesResult.Succeeded || seriesResult.Result == null)
                    return ReturnBase<InventoryAdjustmentDto>.Fail(seriesResult.Errors);

                entity.InventoryAdjustmentNumber = seriesResult.Result["FinelSeriesCodeAndSeriesNumber"];
                entity.RunningNumber = int.Parse(seriesResult.Result["RunningNumber"]);

                CreateInventoryAdjustmentLines(entity, dto);

                var insertResult = await _commands.InsertAsync(entity);
                if (!insertResult.Succeeded)
                    return ReturnBase<InventoryAdjustmentDto>.Fail(insertResult.Errors);

                var saveResult = await _accountUoW.SaveAsync();
                if (!saveResult.Succeeded)
                    return ReturnBase<InventoryAdjustmentDto>.Fail(saveResult.Errors);

                return ReturnBase<InventoryAdjustmentDto>.Success(_mapper.Map<InventoryAdjustmentDto>(entity));
            }
            catch (Exception ex)
            {
                return ReturnBase<InventoryAdjustmentDto>.Fail(ex, _exceptionManager);
            }
        }

        public async Task<ReturnBase<InventoryAdjustmentDto>> Update(InventoryAdjustmentUpdateDto dto)
        {
            try
            {
                var entity = await _queriesManager.InventoryAdjustment.GetById(dto.Id);

                if (entity == null)
                    return ReturnBase<InventoryAdjustmentDto>.Fail(new List<ReturnBaseError>
            {
                new() { ErrorCode = "404", ErrorMessage = $"Inventory Adjustment with Id {dto.Id} was not found" }
            });

                _mapper.Map(dto, entity);

                await UpdateInventoryAdjustmentLines(entity, dto);

                var saveResult = await _accountUoW.SaveAsync();
                if (!saveResult.Succeeded)
                    return ReturnBase<InventoryAdjustmentDto>.Fail(saveResult.Errors);

                return ReturnBase<InventoryAdjustmentDto>.Success(_mapper.Map<InventoryAdjustmentDto>(entity));
            }
            catch (Exception ex)
            {
                return ReturnBase<InventoryAdjustmentDto>.Fail(ex, _exceptionManager);
            }
        }

        public async Task<ReturnBase<InventoryAdjustmentDto>> Delete(long id)
        {
            try
            {
                var entity = await _queriesManager.InventoryAdjustment.GetById(id);
                if (entity == null)
                    return ReturnBase<InventoryAdjustmentDto>.Fail(new List<ReturnBaseError>
                    {
                        new() { ErrorCode = "404", ErrorMessage = $"Inventory Adjustment with Id {id} was not found" }
                    });


                var updateResult = await _commands.DeleteAsync(id);
                if (!updateResult.Succeeded) return ReturnBase<InventoryAdjustmentDto>.Fail(updateResult.Errors);

                var saveResult = await _accountUoW.SaveAsync();
                if (!saveResult.Succeeded) return ReturnBase<InventoryAdjustmentDto>.Fail(saveResult.Errors);

                return ReturnBase<InventoryAdjustmentDto>.Success(_mapper.Map<InventoryAdjustmentDto>(entity));
            }
            catch (Exception ex)
            {
                return ReturnBase<InventoryAdjustmentDto>.Fail(ex, _exceptionManager);
            }
        }

        public async Task<ReturnBase<InventoryAdjustmentDto>> GetById(long id)
        {
            try
            {
                var entity = await _queriesManager.InventoryAdjustment.GetById(id);
                if (entity is null)
                {
                    var error = new ReturnBaseError
                    {
                        ErrorCode = "404",
                        ErrorMessage = $"Inventory Adjustment with Id '{id}' was not found."
                    };
                    var listOfErrors = new List<ReturnBaseError>() { error };
                    return ReturnBase<InventoryAdjustmentDto>.Fail(listOfErrors);
                }

                var mappedResult = _mapper.Map<InventoryAdjustmentDto>(entity);

                return ReturnBase<InventoryAdjustmentDto>.Success(mappedResult);
            }
            catch (Exception ex)
            {
                return ReturnBase<InventoryAdjustmentDto>.Fail(ex, _exceptionManager);
            }
        }

        public async Task<ReturnBase<IEnumerable<InventoryAdjustmentReturnSearchDto>>> Search(SqlQueryOptions sqlQueryOptions)
        {
            try
            {
                var getResult =
                    await _queriesManager.InventoryAdjustment.Search(sqlQueryOptions);

                if (!getResult.Succeeded)
                    return ReturnBase<IEnumerable<InventoryAdjustmentReturnSearchDto>>
                        .Fail(getResult.Errors);

                return ReturnBase<IEnumerable<InventoryAdjustmentReturnSearchDto>>
                    .Success(getResult.Result);
            }
            catch (Exception ex)
            {
                return ReturnBase<IEnumerable<InventoryAdjustmentReturnSearchDto>>
                    .Fail(ex, _exceptionManager);
            }
        }

        public async Task<ReturnBase<ImportResultDto>> ImportInventoryAdjustments(ExcelImportRequestDto dto)
        {
            try
            {
                var finalResult = new ImportResultDto();
                var profile = new InventoryAdjustmentImportProfile();

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
                var branchCache = new Dictionary<string, long>(StringComparer.OrdinalIgnoreCase);
                var warehouseCache = new Dictionary<string, long>(StringComparer.OrdinalIgnoreCase);
                var gtoCache = new Dictionary<string, long>(StringComparer.OrdinalIgnoreCase);

                for (int r = firstDataRow; r <= lastRow; r++)
                {
                    finalResult.ProcessedCount++;

                    var rawRow = new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase);
                    for (int c = 0; c < headers.Count; c++)
                        rawRow[headers[c]] = ws.Cell(r, c + 1).GetString().Trim();

                    var rowErrors = new List<string>();
                    InventoryAdjustmentCreateDto? createDto = null;

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

                    // 🔴 Branch
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

                    // 🔴 Warehouse
                    if (rawRow.TryGetValue("WareHouseCode", out var whCode) &&
                        !string.IsNullOrWhiteSpace(whCode))
                    {
                        if (!warehouseCache.TryGetValue(whCode, out var whId))
                        {
                            var wh = await _queriesManager.Warehouses.GetByCode(whCode);
                            if (wh == null)
                                rowErrors.Add($"Warehouse '{whCode}' not found.");
                            else
                                warehouseCache[whCode] = whId = wh.Id;
                        }

                        if (warehouseCache.TryGetValue(whCode, out var wid))
                            createDto.WareHouseId = wid;
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
                    .GenerateTemplateAsync<InventoryAdjustmentImportTemplateDto>("InventoryAdjustment");

                var file = new FileResultDto
                {
                    Content = content,
                    FileName = "InventoryAdjustment.xlsx"
                };

                return ReturnBase<FileResultDto>.Success(file);
            }
            catch (Exception ex)
            {
                return ReturnBase<FileResultDto>.Fail(ex, _exceptionManager);
            }
        }

        // Create && Update  Any Detail For Inventory Adjustment (Lines) should be handled in these methods to make sure that all operations will be in the same transaction scope

        // GoodsTransferInLines
        private void CreateInventoryAdjustmentLines(InventoryAdjustment entity, InventoryAdjustmentCreateDto dto)
        {
            if (dto.InventoryAdjustmentLines == null || !dto.InventoryAdjustmentLines.Any())
            {
                entity.InventoryAdjustmentLines = new List<InventoryAdjustmentLine>();
                return;
            }

            entity.InventoryAdjustmentLines = _mapper.Map<List<InventoryAdjustmentLine>>(dto.InventoryAdjustmentLines);

            foreach (var line in entity.InventoryAdjustmentLines)
            {
                line.InventoryAdjustment = entity;
            }
        }

        private async Task UpdateInventoryAdjustmentLines(InventoryAdjustment entity, InventoryAdjustmentUpdateDto dto)
        {
            var existing = entity.InventoryAdjustmentLines.ToList();

            if (dto.InventoryAdjustmentLines == null || !dto.InventoryAdjustmentLines.Any())
            {
                var allIds = existing.Select(x => x.Id).ToList();

                if (allIds.Any())
                    await _commands.DeleteInventoryAdjustmentLinesByIds(allIds);
                return;
            }

            var dtoIds = dto.InventoryAdjustmentLines
                .Where(x => x.Id > 0)
                .Select(x => x.Id)
                .ToHashSet();

            foreach (var lineDto in dto.InventoryAdjustmentLines)
            {
                if (lineDto.Id == 0)
                {
                    var newEntity = _mapper.Map<InventoryAdjustmentLine>(lineDto);
                    newEntity.InventoryAdjustmentId = entity.Id;
                    entity.InventoryAdjustmentLines.Add(newEntity);
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
                await _commands.DeleteInventoryAdjustmentLinesByIds(removed);
        }
    }
}