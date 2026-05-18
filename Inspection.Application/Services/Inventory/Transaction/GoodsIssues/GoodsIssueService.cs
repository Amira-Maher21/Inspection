using AutoMapper;
using ClosedXML.Excel;
using Inspection.Application.Contracts.Dto.Inventory.Transaction.GoodsIssues;
using Inspection.Application.Contracts.Dto.SharedDtos;
using Inspection.Application.Contracts.Managers;
using Inspection.Application.Contracts.Repositories.Command.Inventory.Transaction.GoodsIssues;
using Inspection.Application.Contracts.Repositories.Query.Inventory.Transaction.GoodsIssues;
using Inspection.Application.Contracts.Services.Inventory.Transaction.GoodsIssues;
using Inspection.Application.Contracts.Services.MenuManagement.SeriesF;
using Inspection.Application.Contracts.UnitOfWork;
using Inspection.Application.Services.ServicesBase;
using Inspection.Application.Shared.ExcelTemplate;
using Inspection.Domain.Models.Inventory.Transaction.GoodsIssues;
using Inspection.Domain.Models.Inventory.Transaction.GoodsIssues.GoodsIssueLines;
using NDS.Shared.Application.DataQuery;
using NDS.Shared.Application.Multitenant;
using NDS.Shared.Kernel.BaseReturnTypes;
using NDS.Shared.Kernel.Exceptions;

namespace Inspection.Application.Services.Inventory.Transaction.GoodsIssues
{
    public class GoodsIssueService : AccountsServiceBase, IGoodsIssueService
    {
        private readonly ITenantResolver _tenantResolver;
        private readonly IAccountsQueriesManager _queriesManager;

        private readonly IExcelTemplateGenerator _templateGenerator;

        private readonly ISeriesService _seriesService;


        public GoodsIssueService(
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


        private IGoodsIssueCommandRepository _commands => _accountUoW.GoodsIssue;

        private IGoodsIssueQueryRepository _queries => _queriesManager.GoodsIssue ?? throw new NullReferenceException("IGoodsIssueQueryRepository is null");




        public async Task<ReturnBase<GoodsIssueDto>> Create(GoodsIssueCreateDto dto)
        {
            try
            {
                var entity = _mapper.Map<GoodsIssue>(dto);
                entity.Tenant_ID = _tenantResolver.GetTenantName();

                const string SCREEN_CODE = "Goods Issue";
                var series = await _queriesManager.Series.GetByScreen_IDAsync(SCREEN_CODE);

                if (series == null || !series.IsActive)
                    return ReturnBase<GoodsIssueDto>.Fail(new Exception($"No active series configured for screen '{SCREEN_CODE}'"), _exceptionManager);

                entity.SeriesId = series.Id;

                var seriesResult = await _seriesService.GetSeriesCodeWithCustomDateUsingSeriesDetails(series.Id, entity.GoodsIssueDate);
                if (!seriesResult.Succeeded || seriesResult.Result == null)
                    return ReturnBase<GoodsIssueDto>.Fail(seriesResult.Errors);

                entity.GoodsIssueNo = seriesResult.Result["FinelSeriesCodeAndSeriesNumber"];
                entity.RunningNumber = int.Parse(seriesResult.Result["RunningNumber"]);

                CreateGoodsIssueLines(entity, dto);

                var insertResult = await _commands.InsertAsync(entity);
                if (!insertResult.Succeeded)
                    return ReturnBase<GoodsIssueDto>.Fail(insertResult.Errors);

                var saveResult = await _accountUoW.SaveAsync();
                if (!saveResult.Succeeded)
                    return ReturnBase<GoodsIssueDto>.Fail(saveResult.Errors);

                return ReturnBase<GoodsIssueDto>.Success(_mapper.Map<GoodsIssueDto>(entity));
            }
            catch (Exception ex)
            {
                return ReturnBase<GoodsIssueDto>.Fail(ex, _exceptionManager);
            }
        }

        public async Task<ReturnBase<GoodsIssueDto>> Update(GoodsIssueUpdateDto dto)
        {
            try
            {
                var entity = await _queries.GetById(dto.Id);
                if (entity == null)
                    return ReturnBase<GoodsIssueDto>.Fail(new List<ReturnBaseError>
                    { new()

                    { ErrorCode = "404", ErrorMessage = "GoodsIssue Not Found" }
                    });

                entity.Tenant_ID = _tenantResolver.GetTenantName();
                _mapper.Map(dto, entity);

                await UpdateGoodsIssueLines(entity, dto);

                var saveResult = await _accountUoW.SaveAsync();
                if (!saveResult.Succeeded)
                    return ReturnBase<GoodsIssueDto>.Fail(saveResult.Errors);

                return ReturnBase<GoodsIssueDto>.Success(_mapper.Map<GoodsIssueDto>(entity));
            }
            catch (Exception ex)
            {
                return ReturnBase<GoodsIssueDto>.Fail(ex, _exceptionManager);
            }
        }

        public async Task<ReturnBase<GoodsIssueDto>> GetById(long id)
        {
            try
            {
                var entity = await _queries.GetById(id);
                if (entity == null)
                    return ReturnBase<GoodsIssueDto>.Fail(new List<ReturnBaseError> { new() { ErrorCode = "404", ErrorMessage = "GoodsIssue Not Found" } });

                return ReturnBase<GoodsIssueDto>.Success(_mapper.Map<GoodsIssueDto>(entity));
            }
            catch (Exception ex)
            {
                return ReturnBase<GoodsIssueDto>.Fail(ex, _exceptionManager);
            }
        }

        public async Task<ReturnBase<GoodsIssueDto>> Delete(long id)
        {
            try
            {
                var entity = await _queries.GetById(id);
                if (entity == null)
                    return ReturnBase<GoodsIssueDto>.Fail(new List<ReturnBaseError> { new() { ErrorCode = "404", ErrorMessage = "GoodsIssue Not Found" } });

                var deleteResult = await _commands.DeleteById(id);
                if (!deleteResult.Succeeded)
                    return ReturnBase<GoodsIssueDto>.Fail(deleteResult.Errors);

                var saveResult = await _accountUoW.SaveAsync();
                if (!saveResult.Succeeded)
                    return ReturnBase<GoodsIssueDto>.Fail(saveResult.Errors);

                return ReturnBase<GoodsIssueDto>.Success(_mapper.Map<GoodsIssueDto>(entity));
            }
            catch (Exception ex)
            {
                return ReturnBase<GoodsIssueDto>.Fail(ex, _exceptionManager);
            }
        }

        public async Task<ReturnBase<IEnumerable<GoodsIssueReturnSearchDto>>> Search(SqlQueryOptions sqlQueryOptions)
        {
            try
            {
                var result = await _queries.Search(sqlQueryOptions);
                if (!result.Succeeded)
                    return ReturnBase<IEnumerable<GoodsIssueReturnSearchDto>>.Fail(result.Errors);

                var mapped = result.Result.Select(c => _mapper.Map<GoodsIssueReturnSearchDto>(c)).ToList();
                return ReturnBase<IEnumerable<GoodsIssueReturnSearchDto>>.Success(mapped);
            }
            catch (Exception ex)
            {
                return ReturnBase<IEnumerable<GoodsIssueReturnSearchDto>>.Fail(ex, _exceptionManager);
            }
        }

        // ----------------- Lines -----------------
        private void CreateGoodsIssueLines(GoodsIssue entity, GoodsIssueCreateDto dto)
        {
            if (dto.GoodsIssueLines == null || !dto.GoodsIssueLines.Any())
            {
                entity.GoodsIssueLines = new List<GoodsIssueLine>();
                return;
            }

            entity.GoodsIssueLines = _mapper.Map<List<GoodsIssueLine>>(dto.GoodsIssueLines);
            foreach (var line in entity.GoodsIssueLines)
                line.GoodsIssue = entity;
        }




        private async Task UpdateGoodsIssueLines(GoodsIssue entity, GoodsIssueUpdateDto dto)
        {
            var existingLines = entity.GoodsIssueLines.ToList();
            if (dto.GoodsIssueLines == null || !dto.GoodsIssueLines.Any())
            {
                await _commands.DeleteGoodsIssueLineByGoodsIssueId(entity.Id);
                return;
            }

            var dtoIds = dto.GoodsIssueLines.Where(x => x.Id > 0).Select(x => x.Id).ToHashSet();

            foreach (var lineDto in dto.GoodsIssueLines)
            {
                if (lineDto.Id == 0)
                {
                    var newLine = _mapper.Map<GoodsIssueLine>(lineDto);
                    newLine.GoodsIssueId = entity.Id;
                    entity.GoodsIssueLines.Add(newLine);
                }
                else
                {
                    var existing = existingLines.FirstOrDefault(x => x.Id == lineDto.Id);
                    if (existing != null)
                        _mapper.Map(lineDto, existing);
                }
            }

            var removedIds = existingLines.Where(x => !dtoIds.Contains(x.Id)).Select(x => x.Id).ToList();
            if (removedIds.Any())
                await _commands.DeleteGoodsIssueLineByIds(removedIds);
        }

        // ----------------- Template & Import -----------------
        public async Task<ReturnBase<FileResultDto>> DownloadGoodsIssueTemplate()
        {
            try
            {
                var content = await _templateGenerator
                    .GenerateTemplateAsync<GoodsIssueImportTemplateDto>("GoodsIssue");

                return ReturnBase<FileResultDto>.Success(new FileResultDto
                {
                    Content = content,
                    FileName = "GoodsIssue.xlsx"
                });
            }
            catch (Exception ex)
            {
                return ReturnBase<FileResultDto>.Fail(ex, _exceptionManager);
            }
        }

        public async Task<ReturnBase<ImportResultDto>> ImportGoodsIssue(ExcelImportRequestDto dto)
        {
            try
            {
                var finalResult = new ImportResultDto();
                var profile = new GoodsIssueImportProfile();

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

                var warehouseCache = new Dictionary<string, long>(StringComparer.OrdinalIgnoreCase);
                var branchCache = new Dictionary<string, long>(StringComparer.OrdinalIgnoreCase);

                for (int r = firstDataRow; r <= lastRow; r++)
                {
                    finalResult.ProcessedCount++;

                    var rawRow = new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase);
                    for (int c = 0; c < headers.Count; c++)
                        rawRow[headers[c]] = ws.Cell(r, c + 1).GetString().Trim();

                    var rowErrors = new List<string>();
                    GoodsIssueCreateDto? createDto = null;

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
                    // Warehouse (REQUIRED)
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
                    else
                    {
                        rowErrors.Add("WarehouseCode is required.");
                    }

                    // Branch (REQUIRED)
                    if (rawRow.TryGetValue("BranchCode", out var branchCode) &&
                        !string.IsNullOrWhiteSpace(branchCode))
                    {
                        if (!branchCache.TryGetValue(branchCode, out var branchId))
                        {
                            var item = await _queriesManager.Branches.GetByCode(branchCode);
                            if (item == null)
                                rowErrors.Add($"Branch '{branchCode}' not found.");
                            else
                                branchCache[branchCode] = branchId = item.Id;
                        }

                        if (branchCache.TryGetValue(branchCode, out var iid))
                            createDto.BranchId = iid;
                    }
                    else
                    {
                        rowErrors.Add("ItemCode is required.");
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
                            Errors = createResult.Errors.Select(e => $"{e.ErrorCode}: {e.ErrorMessage}").ToList()
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
