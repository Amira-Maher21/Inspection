using AutoMapper;
using ClosedXML.Excel;
using Inspection.Application.Contracts.Dto.Inventory.Transaction.GoodsTransferInDTOs;
using Inspection.Application.Contracts.Dto.SharedDtos;
using Inspection.Application.Contracts.Managers;
using Inspection.Application.Contracts.Repositories.Command.Inventory.Transaction.GoodsTransferIns;
using Inspection.Application.Contracts.Repositories.Query.Inventory.Transaction.GoodsTransferIns;
using Inspection.Application.Contracts.Services.Inventory.Transaction.GoodsTransferIns;
using Inspection.Application.Contracts.Services.MenuManagement.SeriesF;
using Inspection.Application.Contracts.UnitOfWork;
using Inspection.Application.Services.ServicesBase;
using Inspection.Application.Shared.ExcelTemplate;
using Inspection.Domain.Models.Inventory.Transaction.GoodsTransferIns;
using NDS.Shared.Application.DataQuery;
using NDS.Shared.Application.Multitenant;
using NDS.Shared.Kernel.BaseReturnTypes;
using NDS.Shared.Kernel.Exceptions;

namespace Inspection.Application.Services.Inventory.Transaction.GoodsTransferIns
{
    internal class GoodsTransferInService : AccountsServiceBase, IGoodsTransferInService
    {
        private readonly ITenantResolver _tenantResolver;
        private readonly IExcelTemplateGenerator _templateGenerator;
        private readonly ISeriesService _seriesService;


        public GoodsTransferInService(
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
        private IGoodsTransferInCommandRepository _commands => _accountUoW.GoodsTransferIn;
        private IGoodsTransferInQueryRepository _queries => _queriesManager.GoodsTransferIn;

        public async Task<ReturnBase<GoodsTransferInDto>> Create(GoodsTransferInCreateDto dto)
        {
            try
            {
                var entity = _mapper.Map<GoodsTransferIn>(dto);
                entity.Tenant_ID = _tenantResolver.GetTenantName();

                // Series
                const string SCREEN_CODE = "Goods Transfer In";

                var series = await _queriesManager.Series.GetByScreen_IDAsync(SCREEN_CODE);

                if (series == null || !series.IsActive)
                    return ReturnBase<GoodsTransferInDto>.Fail(
                        new Exception($"No active series configured for screen '{SCREEN_CODE}'"),
                        _exceptionManager);

                entity.SeriesId = series.Id;

                var seriesResult = await _seriesService
                    .GetSeriesCodeWithCustomDateUsingSeriesDetails(series.Id, entity.GoodsTransferInDate);

                if (!seriesResult.Succeeded || seriesResult.Result == null)
                    return ReturnBase<GoodsTransferInDto>.Fail(seriesResult.Errors);

                entity.GoodsTransferInNumber = seriesResult.Result["FinelSeriesCodeAndSeriesNumber"];
                entity.RunningNumber = int.Parse(seriesResult.Result["RunningNumber"]);

                CreateGoodsTransferInLines(entity, dto);

                var insertResult = await _commands.InsertAsync(entity);
                if (!insertResult.Succeeded)
                    return ReturnBase<GoodsTransferInDto>.Fail(insertResult.Errors);

                var saveResult = await _accountUoW.SaveAsync();
                if (!saveResult.Succeeded)
                    return ReturnBase<GoodsTransferInDto>.Fail(saveResult.Errors);

                return ReturnBase<GoodsTransferInDto>.Success(_mapper.Map<GoodsTransferInDto>(entity));
            }
            catch (Exception ex)
            {
                return ReturnBase<GoodsTransferInDto>.Fail(ex, _exceptionManager);
            }
        }

        public async Task<ReturnBase<GoodsTransferInDto>> Update(GoodsTransferInUpdateDto dto)
        {
            try
            {
                var entity = await _queriesManager.GoodsTransferIn.GetById(dto.Id);

                if (entity == null)
                    return ReturnBase<GoodsTransferInDto>.Fail(new List<ReturnBaseError>
            {
                new() { ErrorCode = "404", ErrorMessage = $"Goods Transfer In with Id {dto.Id} was not found" }
            });

                _mapper.Map(dto, entity);

                await UpdateGoodsTransferInLines(entity, dto);

                var saveResult = await _accountUoW.SaveAsync();
                if (!saveResult.Succeeded)
                    return ReturnBase<GoodsTransferInDto>.Fail(saveResult.Errors);

                return ReturnBase<GoodsTransferInDto>.Success(_mapper.Map<GoodsTransferInDto>(entity));
            }
            catch (Exception ex)
            {
                return ReturnBase<GoodsTransferInDto>.Fail(ex, _exceptionManager);
            }
        }

        public async Task<ReturnBase<GoodsTransferInDto>> Delete(long id)
        {
            try
            {
                var entity = await _queriesManager.GoodsTransferIn.GetById(id);
                if (entity == null)
                    return ReturnBase<GoodsTransferInDto>.Fail(new List<ReturnBaseError>
                    {
                        new() { ErrorCode = "404", ErrorMessage = $"Goods Transfer In with Id {id} was not found" }
                    });


                var updateResult = await _commands.DeleteAsync(id);
                if (!updateResult.Succeeded) return ReturnBase<GoodsTransferInDto>.Fail(updateResult.Errors);

                var saveResult = await _accountUoW.SaveAsync();
                if (!saveResult.Succeeded) return ReturnBase<GoodsTransferInDto>.Fail(saveResult.Errors);

                return ReturnBase<GoodsTransferInDto>.Success(_mapper.Map<GoodsTransferInDto>(entity));
            }
            catch (Exception ex)
            {
                return ReturnBase<GoodsTransferInDto>.Fail(ex, _exceptionManager);
            }
        }

        public async Task<ReturnBase<GoodsTransferInDto>> GetById(long id)
        {
            try
            {
                var entity = await _queriesManager.GoodsTransferIn.GetById(id);
                if (entity is null)
                {
                    var error = new ReturnBaseError
                    {
                        ErrorCode = "404",
                        ErrorMessage = $"Goods Transfer In with Id '{id}' was not found."
                    };
                    var listOfErrors = new List<ReturnBaseError>() { error };
                    return ReturnBase<GoodsTransferInDto>.Fail(listOfErrors);
                }

                var mappedResult = _mapper.Map<GoodsTransferInDto>(entity);

                return ReturnBase<GoodsTransferInDto>.Success(mappedResult);
            }
            catch (Exception ex)
            {
                return ReturnBase<GoodsTransferInDto>.Fail(ex, _exceptionManager);
            }
        }

        public async Task<ReturnBase<IEnumerable<GoodsTransferInReturnSearchDto>>> Search(SqlQueryOptions sqlQueryOptions)
        {
            try
            {
                var getResult =
                    await _queriesManager.GoodsTransferIn.Search(sqlQueryOptions);

                if (!getResult.Succeeded)
                    return ReturnBase<IEnumerable<GoodsTransferInReturnSearchDto>>
                        .Fail(getResult.Errors);

                return ReturnBase<IEnumerable<GoodsTransferInReturnSearchDto>>
                    .Success(getResult.Result);
            }
            catch (Exception ex)
            {
                return ReturnBase<IEnumerable<GoodsTransferInReturnSearchDto>>
                    .Fail(ex, _exceptionManager);
            }
        }

        public async Task<ReturnBase<ImportResultDto>> ImportGoodsTransferIns(ExcelImportRequestDto dto)
        {
            try
            {
                var finalResult = new ImportResultDto();
                var profile = new GoodsTransferInImportProfile();

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
                    GoodsTransferInCreateDto? createDto = null;

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

                    // 🔴 GoodsTransferOut
                    if (rawRow.TryGetValue("GoodsTransferOutNumber", out var gtoNumber) &&
                        !string.IsNullOrWhiteSpace(gtoNumber))
                    {
                        if (!gtoCache.TryGetValue(gtoNumber, out var gtoId))
                        {
                            var gto = await _queriesManager.GoodsTransferOut.GetByGoodsTransferOutNumber(gtoNumber);
                            if (gto == null)
                                rowErrors.Add($"GoodsTransferOut '{gtoNumber}' not found.");
                            else
                                gtoCache[gtoNumber] = gtoId = gto.Id;
                        }

                        if (gtoCache.TryGetValue(gtoNumber, out var gid))
                            createDto.GoodsTransferOutId = gid;
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
                    .GenerateTemplateAsync<GoodsTransferInImportTemplateDto>("GoodsTransferIn");

                var file = new FileResultDto
                {
                    Content = content,
                    FileName = "GoodsTransferIn.xlsx"
                };

                return ReturnBase<FileResultDto>.Success(file);
            }
            catch (Exception ex)
            {
                return ReturnBase<FileResultDto>.Fail(ex, _exceptionManager);
            }
        }

        // Create && Update  Any Detail For Goods Transfer In (Lines) should be handled in these methods to make sure that all operations will be in the same transaction scope

        // GoodsTransferInLines
        private void CreateGoodsTransferInLines(GoodsTransferIn entity, GoodsTransferInCreateDto dto)
        {
            if (dto.GoodsTransferInLines == null || !dto.GoodsTransferInLines.Any())
            {
                entity.GoodsTransferInLines = new List<GoodsTransferInLine>();
                return;
            }

            entity.GoodsTransferInLines = _mapper.Map<List<GoodsTransferInLine>>(dto.GoodsTransferInLines);

            foreach (var line in entity.GoodsTransferInLines)
            {
                line.GoodsTransferIn = entity;
            }
        }

        private async Task UpdateGoodsTransferInLines(GoodsTransferIn entity, GoodsTransferInUpdateDto dto)
        {
            var existing = entity.GoodsTransferInLines.ToList();

            if (dto.GoodsTransferInLines == null || !dto.GoodsTransferInLines.Any())
            {
                var allIds = existing.Select(x => x.Id).ToList();

                if (allIds.Any())
                    await _commands.DeleteGoodsTransferInLinesByIds(allIds);
                return;
            }

            var dtoIds = dto.GoodsTransferInLines
                .Where(x => x.Id > 0)
                .Select(x => x.Id)
                .ToHashSet();

            foreach (var lineDto in dto.GoodsTransferInLines)
            {
                if (lineDto.Id == 0)
                {
                    var newEntity = _mapper.Map<GoodsTransferInLine>(lineDto);
                    newEntity.GoodsTransferInId = entity.Id;
                    entity.GoodsTransferInLines.Add(newEntity);
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
                await _commands.DeleteGoodsTransferInLinesByIds(removed);
        }
    }
}