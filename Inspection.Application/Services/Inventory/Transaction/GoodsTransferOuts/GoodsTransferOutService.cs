using AutoMapper;
using ClosedXML.Excel;
using Inspection.Application.Contracts.Dto.Inventory.Transaction.GoodsTransferOutDTOs;
using Inspection.Application.Contracts.Dto.SharedDtos;
using Inspection.Application.Contracts.Managers;
using Inspection.Application.Contracts.Repositories.Command.Inventory.Transaction.GoodsTransferOuts;
using Inspection.Application.Contracts.Repositories.Query.Inventory.Transaction.GoodsTransferOuts;
using Inspection.Application.Contracts.Services.Inventory.Transaction.GoodsTransferOuts;
using Inspection.Application.Contracts.Services.MenuManagement.SeriesF;
using Inspection.Application.Contracts.UnitOfWork;
using Inspection.Application.Services.ServicesBase;
using Inspection.Application.Shared.ExcelTemplate;
using Inspection.Domain.Models.Inventory.Transaction.GoodsTransferOuts;
using NDS.Shared.Application.DataQuery;
using NDS.Shared.Application.Multitenant;
using NDS.Shared.Kernel.BaseReturnTypes;
using NDS.Shared.Kernel.Exceptions;

namespace Inspection.Application.Services.Inventory.Transaction.GoodsTransferOuts
{
    internal class GoodsTransferOutService : AccountsServiceBase, IGoodsTransferOutService
    {
        private readonly ITenantResolver _tenantResolver;
        private readonly IExcelTemplateGenerator _templateGenerator;
        private readonly ISeriesService _seriesService;


        public GoodsTransferOutService(
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
        private IGoodsTransferOutCommandRepository _commands => _accountUoW.GoodsTransferOut;
        private IGoodsTransferOutQueryRepository _queries => _queriesManager.GoodsTransferOut;

        public async Task<ReturnBase<GoodsTransferOutDto>> Create(GoodsTransferOutCreateDto dto)
        {
            try
            {
                var entity = _mapper.Map<GoodsTransferOut>(dto);
                entity.Tenant_ID = _tenantResolver.GetTenantName();

                // Series
                const string SCREEN_CODE = "Goods Transfer Out";

                var series = await _queriesManager.Series.GetByScreen_IDAsync(SCREEN_CODE);

                if (series == null || !series.IsActive)
                    return ReturnBase<GoodsTransferOutDto>.Fail(
                        new Exception($"No active series configured for screen '{SCREEN_CODE}'"),
                        _exceptionManager);

                entity.SeriesId = series.Id;

                var seriesResult = await _seriesService
                    .GetSeriesCodeWithCustomDateUsingSeriesDetails(series.Id, entity.GoodsTransferOutDate);

                if (!seriesResult.Succeeded || seriesResult.Result == null)
                    return ReturnBase<GoodsTransferOutDto>.Fail(seriesResult.Errors);

                entity.GoodsTransferOutNumber = seriesResult.Result["FinelSeriesCodeAndSeriesNumber"];
                entity.RunningNumber = int.Parse(seriesResult.Result["RunningNumber"]);

                CreateGoodsTransferOutLines(entity, dto);

                var insertResult = await _commands.InsertAsync(entity);
                if (!insertResult.Succeeded)
                    return ReturnBase<GoodsTransferOutDto>.Fail(insertResult.Errors);

                var saveResult = await _accountUoW.SaveAsync();
                if (!saveResult.Succeeded)
                    return ReturnBase<GoodsTransferOutDto>.Fail(saveResult.Errors);

                return ReturnBase<GoodsTransferOutDto>.Success(_mapper.Map<GoodsTransferOutDto>(entity));
            }
            catch (Exception ex)
            {
                return ReturnBase<GoodsTransferOutDto>.Fail(ex, _exceptionManager);
            }
        }

        public async Task<ReturnBase<GoodsTransferOutDto>> Update(GoodsTransferOutUpdateDto dto)
        {
            try
            {
                var entity = await _queriesManager.GoodsTransferOut.GetById(dto.Id);

                if (entity == null)
                    return ReturnBase<GoodsTransferOutDto>.Fail(new List<ReturnBaseError>
            {
                new() { ErrorCode = "404", ErrorMessage = $"Goods Transfer Out with Id {dto.Id} was not found" }
            });

                _mapper.Map(dto, entity);

                await UpdateGoodsTransferOutLines(entity, dto);

                var saveResult = await _accountUoW.SaveAsync();
                if (!saveResult.Succeeded)
                    return ReturnBase<GoodsTransferOutDto>.Fail(saveResult.Errors);

                return ReturnBase<GoodsTransferOutDto>.Success(_mapper.Map<GoodsTransferOutDto>(entity));
            }
            catch (Exception ex)
            {
                return ReturnBase<GoodsTransferOutDto>.Fail(ex, _exceptionManager);
            }
        }

        public async Task<ReturnBase<GoodsTransferOutDto>> Delete(long id)
        {
            try
            {
                var entity = await _queriesManager.GoodsTransferOut.GetById(id);
                if (entity == null)
                    return ReturnBase<GoodsTransferOutDto>.Fail(new List<ReturnBaseError>
                    {
                        new() { ErrorCode = "404", ErrorMessage = $"Goods Transfer Out with Id {id} was not found" }
                    });


                var updateResult = await _commands.DeleteAsync(id);
                if (!updateResult.Succeeded) return ReturnBase<GoodsTransferOutDto>.Fail(updateResult.Errors);

                var saveResult = await _accountUoW.SaveAsync();
                if (!saveResult.Succeeded) return ReturnBase<GoodsTransferOutDto>.Fail(saveResult.Errors);

                return ReturnBase<GoodsTransferOutDto>.Success(_mapper.Map<GoodsTransferOutDto>(entity));
            }
            catch (Exception ex)
            {
                return ReturnBase<GoodsTransferOutDto>.Fail(ex, _exceptionManager);
            }
        }

        public async Task<ReturnBase<GoodsTransferOutDto>> GetById(long id)
        {
            try
            {
                var entity = await _queriesManager.GoodsTransferOut.GetById(id);
                if (entity is null)
                {
                    var error = new ReturnBaseError
                    {
                        ErrorCode = "404",
                        ErrorMessage = $"Goods Transfer Out with Id '{id}' was not found."
                    };
                    var listOfErrors = new List<ReturnBaseError>() { error };
                    return ReturnBase<GoodsTransferOutDto>.Fail(listOfErrors);
                }

                var mappedResult = _mapper.Map<GoodsTransferOutDto>(entity);

                return ReturnBase<GoodsTransferOutDto>.Success(mappedResult);
            }
            catch (Exception ex)
            {
                return ReturnBase<GoodsTransferOutDto>.Fail(ex, _exceptionManager);
            }
        }

        public async Task<ReturnBase<IEnumerable<GoodsTransferOutReturnSearchDto>>> Search(SqlQueryOptions sqlQueryOptions)
        {
            try
            {
                var getResult =
                    await _queriesManager.GoodsTransferOut.Search(sqlQueryOptions);

                if (!getResult.Succeeded)
                    return ReturnBase<IEnumerable<GoodsTransferOutReturnSearchDto>>
                        .Fail(getResult.Errors);

                return ReturnBase<IEnumerable<GoodsTransferOutReturnSearchDto>>
                    .Success(getResult.Result);
            }
            catch (Exception ex)
            {
                return ReturnBase<IEnumerable<GoodsTransferOutReturnSearchDto>>
                    .Fail(ex, _exceptionManager);
            }
        }

        public async Task<ReturnBase<ImportResultDto>> ImportGoodsTransferOuts(ExcelImportRequestDto dto)
        {
            try
            {
                var finalResult = new ImportResultDto();
                var profile = new GoodsTransferOutImportProfile();

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

                // CACHES
                var branchCache = new Dictionary<string, long>(StringComparer.OrdinalIgnoreCase);
                var warehouseCache = new Dictionary<string, long>(StringComparer.OrdinalIgnoreCase);

                for (int r = firstDataRow; r <= lastRow; r++)
                {
                    finalResult.ProcessedCount++;

                    var rawRow = new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase);
                    for (int c = 0; c < headers.Count; c++)
                        rawRow[headers[c]] = ws.Cell(r, c + 1).GetString().Trim();

                    var rowErrors = new List<string>();
                    GoodsTransferOutCreateDto? createDto = null;

                    // Map & Validate
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

                    // Branch
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

                    // Warehouse From
                    if (rawRow.TryGetValue("WareHouseFromCode", out var whFromCode) &&
                        !string.IsNullOrWhiteSpace(whFromCode))
                    {
                        if (!warehouseCache.TryGetValue(whFromCode, out var whId))
                        {
                            var wh = await _queriesManager.Warehouses.GetByCode(whFromCode);
                            if (wh == null)
                                rowErrors.Add($"WarehouseFrom '{whFromCode}' not found.");
                            else
                                warehouseCache[whFromCode] = whId = wh.Id;
                        }

                        if (warehouseCache.TryGetValue(whFromCode, out var wid))
                            createDto.WareHouseFromId = wid;
                    }

                    // Warehouse To (Optional)
                    if (rawRow.TryGetValue("WareHouseToCode", out var whToCode) &&
                        !string.IsNullOrWhiteSpace(whToCode))
                    {
                        if (!warehouseCache.TryGetValue(whToCode, out var whId))
                        {
                            var wh = await _queriesManager.Warehouses.GetByCode(whToCode);
                            if (wh == null)
                                rowErrors.Add($"WarehouseTo '{whToCode}' not found.");
                            else
                                warehouseCache[whToCode] = whId = wh.Id;
                        }

                        if (warehouseCache.TryGetValue(whToCode, out var wid))
                            createDto.WareHouseId = wid;
                    }

                    // Errors
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

                    // Create
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
                    .GenerateTemplateAsync<GoodsTransferOutImportTemplateDto>("GoodsTransferOut");

                var file = new FileResultDto
                {
                    Content = content,
                    FileName = "GoodsTransferOut.xlsx"
                };

                return ReturnBase<FileResultDto>.Success(file);
            }
            catch (Exception ex)
            {
                return ReturnBase<FileResultDto>.Fail(ex, _exceptionManager);
            }
        }

        // Create && Update  Any Detail For Goods Transfer Out (Lines) should be handled in these methods to make sure that all operations will be in the same transaction scope

        // GoodsTransferOutLines
        private void CreateGoodsTransferOutLines(GoodsTransferOut entity, GoodsTransferOutCreateDto dto)
        {
            if (dto.GoodsTransferOutLines == null || !dto.GoodsTransferOutLines.Any())
            {
                entity.GoodsTransferOutLines = new List<GoodsTransferOutLine>();
                return;
            }

            entity.GoodsTransferOutLines = _mapper.Map<List<GoodsTransferOutLine>>(dto.GoodsTransferOutLines);

            foreach (var line in entity.GoodsTransferOutLines)
            {
                line.GoodsTransferOut = entity;
            }
        }

        private async Task UpdateGoodsTransferOutLines(GoodsTransferOut entity, GoodsTransferOutUpdateDto dto)
        {
            var existing = entity.GoodsTransferOutLines.ToList();

            if (dto.GoodsTransferOutLines == null || !dto.GoodsTransferOutLines.Any())
            {
                var allIds = existing.Select(x => x.Id).ToList();

                if (allIds.Any())
                    await _commands.DeleteGoodsTransferOutLinesByIds(allIds);
                return;
            }

            var dtoIds = dto.GoodsTransferOutLines
                .Where(x => x.Id > 0)
                .Select(x => x.Id)
                .ToHashSet();

            foreach (var lineDto in dto.GoodsTransferOutLines)
            {
                if (lineDto.Id == 0)
                {
                    var newEntity = _mapper.Map<GoodsTransferOutLine>(lineDto);
                    newEntity.GoodsTransferOutId = entity.Id;
                    entity.GoodsTransferOutLines.Add(newEntity);
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
                await _commands.DeleteGoodsTransferOutLinesByIds(removed);
        }
    }
}