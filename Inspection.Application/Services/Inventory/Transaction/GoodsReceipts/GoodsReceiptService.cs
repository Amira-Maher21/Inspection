using AutoMapper;
using ClosedXML.Excel;
using Inspection.Application.Contracts.Dto.Inventory.Transaction.GoodsReceipts;
using Inspection.Application.Contracts.Dto.SharedDtos;
using Inspection.Application.Contracts.Event;
using Inspection.Application.Contracts.Managers;
using Inspection.Application.Contracts.Repositories.Command.Inventory.Transaction.GoodsReceipts;
using Inspection.Application.Contracts.Repositories.Query.Inventory.Transaction.GoodsReceipts;
using Inspection.Application.Contracts.Services.Inventory.Transaction.GoodsReceipts;
using Inspection.Application.Contracts.Services.MenuManagement.SeriesF;
using Inspection.Application.Contracts.UnitOfWork;
using Inspection.Application.Services.ServicesBase;
using Inspection.Application.Shared.ExcelTemplate;
using Inspection.Domain.Models.Inventory.Transaction.GoodsReceipts;
using Inspection.Domain.Models.Inventory.Transaction.GoodsReceipts.GoodsReceiptLines;
using Microsoft.Extensions.DependencyInjection;
using NDS.Shared.Application.DataQuery;
using NDS.Shared.Application.Multitenant;
using NDS.Shared.Kernel.BaseReturnTypes;
using NDS.Shared.Kernel.Exceptions;

namespace Inspection.Application.Services.Inventory.Transaction.GoodsReceipts
{
    public class GoodsReceiptService : AccountsServiceBase, IGoodsReceiptService
    {
        private readonly ITenantResolver _tenantResolver;
        private readonly IAccountsQueriesManager _queriesManager;
        private readonly IExcelTemplateGenerator _templateGenerator;
        private readonly ISeriesService _seriesService;

        //  private readonly IEventHandler<GoodsReceiptPostedEvent> _eventHandler;
        //  private readonly IEventBus _eventBus;
        private readonly IServiceProvider _serviceProvider;
        public GoodsReceiptService(
            IAccountUnitOfWork accountUoW,
            IAccountsQueriesManager queriesManager,
            IMapper mapper,
            IExceptionManager exceptionManager,
            ITenantResolver tenantResolver,
            IExcelTemplateGenerator templateGenerator,
            IServiceProvider serviceProvider,
             ISeriesService seriesService
             //IEventHandler<GoodsReceiptPostedEvent> eventHandler,
             /* IEventBus eventBus*/) : base(accountUoW, queriesManager, mapper, exceptionManager)
        {
            _queriesManager = queriesManager ?? throw new ArgumentNullException(nameof(queriesManager));
            _tenantResolver = tenantResolver;
            _templateGenerator = templateGenerator;
            _serviceProvider = serviceProvider;
            _seriesService = seriesService;

            //_eventHandler = eventHandler;
            // _eventBus = eventBus;
        }

        private IGoodsReceiptCommandRepository _commands => _accountUoW.GoodsReceipt;
        private IGoodsReceiptQueryRepository _queries => _queriesManager.GoodsReceipts;


        public async Task<ReturnBase<GoodsReceiptDto>> Create(GoodsReceiptCreateDto dto)
        {
            try
            {
                var validation = ValidateCreateAttribute(dto);
                if (!validation.Succeeded)
                    return ReturnBase<GoodsReceiptDto>.Fail(validation.Errors);
                var entity = _mapper.Map<GoodsReceipt>(dto);

                entity.Tenant_ID = _tenantResolver.GetTenantName();


                // Series
                const string SCREEN_CODE = "Goods Receipt";

                var series = await _queriesManager.Series.GetByScreen_IDAsync(SCREEN_CODE);

                if (series == null || !series.IsActive)
                    return ReturnBase<GoodsReceiptDto>.Fail(
                        new Exception($"No active series configured for screen '{SCREEN_CODE}'"),
                        _exceptionManager);

                entity.SeriesId = series.Id;

                var seriesResult = await _seriesService
                    .GetSeriesCodeWithCustomDateUsingSeriesDetails(series.Id, entity.GoodsReceiptDate);

                if (!seriesResult.Succeeded || seriesResult.Result == null)
                    return ReturnBase<GoodsReceiptDto>.Fail(seriesResult.Errors);

                entity.GoodsReceiptNo = seriesResult.Result["FinelSeriesCodeAndSeriesNumber"];
                entity.RunningNumber = int.Parse(seriesResult.Result["RunningNumber"]);



                if (dto.GoodsReceiptLines != null && dto.GoodsReceiptLines.Any())
                {
                    entity.GoodsReceiptLines = _mapper.Map<List<GoodsReceiptLine>>(dto.GoodsReceiptLines);

                    foreach (var varient in entity.GoodsReceiptLines)
                    {
                        varient.GoodsReceipt = entity;
                    }
                }
                else
                {
                    entity.GoodsReceiptLines = new List<GoodsReceiptLine>();
                }


                var insertResult = await _commands.InsertAsync(entity);
                if (!insertResult.Succeeded)
                    return ReturnBase<GoodsReceiptDto>.Fail(insertResult.Errors);


                var saveResult = await _accountUoW.SaveAsync();
                if (saveResult == null)
                    return ReturnBase<GoodsReceiptDto>.Fail(new List<ReturnBaseError>
                    {
                        new() { ErrorCode = "500", ErrorMessage = "SaveAsync returned null" }
                        });

                if (!saveResult.Succeeded)
                    return ReturnBase<GoodsReceiptDto>.Fail(
                        saveResult.Errors?.ToList() ??
                        new List<ReturnBaseError>
                        {
                    new() { ErrorCode = "500", ErrorMessage = "Save failed" }
                        });
                //if (entity.Status == true)
                //{
                //    var postedEvent = new GoodsReceiptPostedEvent(entity.Id, entity.Tenant_ID,"1");
                //    try
                //    {
                //        await _eventBus.Publish(postedEvent);
                //    }
                //    catch (Exception ex)
                //    {
                //        return ReturnBase<GoodsReceiptDto>.Fail(ex, _exceptionManager);
                //    }
                //}

                var postedEvent = new GoodsReceiptPostedEvent(entity.Id, entity.Tenant_ID, "1");
                try
                {
                    var handlers = _serviceProvider.GetServices<IEventHandler<GoodsReceiptPostedEvent>>();
                    foreach (var handler in handlers)
                    {
                        await handler.Handle(postedEvent);
                    }
                }
                catch (Exception ex)
                {
                    return ReturnBase<GoodsReceiptDto>.Fail(ex, _exceptionManager);
                }


                await _accountUoW.SaveAsync();



                return ReturnBase<GoodsReceiptDto>.Success(_mapper.Map<GoodsReceiptDto>(entity));
            }
            catch (Exception ex)
            {
                return ReturnBase<GoodsReceiptDto>.Fail(ex, _exceptionManager);
            }
        }


        public async Task<ReturnBase<GoodsReceiptDto>> Update(GoodsReceiptUpdateDto dto)
        {
            try
            {
                var validation = ValidateUpdateAttribute(dto);
                if (!validation.Succeeded)
                    return ReturnBase<GoodsReceiptDto>.Fail(validation.Errors);
                var entity = await _queriesManager.GoodsReceipts.GetById(dto.Id);
                if (entity == null)
                {
                    return ReturnBase<GoodsReceiptDto>.Fail(new List<ReturnBaseError>
                    {
                        new() { ErrorCode = "404", ErrorMessage = "GoodsReceipt Not Found" }
                    });
                }

                // Update GoodsReceipt main fields
                _mapper.Map(dto, entity);

                var existingLines = entity.GoodsReceiptLines.ToList();

                // Case 1: User sent NO Lines → HARD DELETE ALL
                if (dto.GoodsReceiptLines == null || !dto.GoodsReceiptLines.Any())
                {
                    await _commands.DeleteGoodsReceiptLineByItemGoodsReceiptId(entity.Id);
                }
                else
                {
                    var dtoLionetIds = dto.GoodsReceiptLines
                        .Where(v => v.Id > 0)
                        .Select(v => v.Id)
                        .ToHashSet();

                    // CREATE & UPDATE
                    foreach (var lineDto in dto.GoodsReceiptLines)
                    {
                        // CREATE
                        if (lineDto.Id == 0)
                        {
                            var newLine = _mapper.Map<GoodsReceiptLine>(lineDto);
                            newLine.GoodsReceiptId = entity.Id;
                            entity.GoodsReceiptLines.Add(newLine);
                        }
                        else
                        {
                            // UPDATE
                            var existingLine =
                                existingLines.FirstOrDefault(v => v.Id == lineDto.Id);

                            if (existingLine != null)
                            {
                                _mapper.Map(lineDto, existingLine);
                            }
                        }
                    }

                    // HARD DELETE removed Lines
                    var removedLines = existingLines
                        .Where(v => !dtoLionetIds.Contains(v.Id))
                        .Select(v => v.Id)
                        .ToList();

                    if (removedLines.Any())
                    {
                        await _commands.DeleteGoodsReceiptLineByIds(removedLines);
                    }
                }

                // Save
                var saveResult = await _accountUoW.SaveAsync();
                if (!saveResult.Succeeded)
                    return ReturnBase<GoodsReceiptDto>.Fail(saveResult.Errors);

                entity.Tenant_ID = _tenantResolver.GetTenantName();

                //if (entity.Status == true)
                //{
                //    var postedEvent = new GoodsReceiptPostedEvent(entity.Id, entity.Tenant_ID);
                //    try
                //    {
                //        await _eventBus.Publish(postedEvent);
                //    }
                //    catch (Exception ex)
                //    {
                //        return ReturnBase<GoodsReceiptDto>.Fail(ex, _exceptionManager);
                //    }
                //}
                //if (entity.Status == true)
                //{
                //    var postedEvent = new GoodsReceiptPostedEvent(entity.Id, entity.Tenant_ID, "1");
                //    try
                //    {
                //        var handlers = _serviceProvider.GetServices<IEventHandler<GoodsReceiptPostedEvent>>();
                //        foreach (var handler in handlers)
                //        {
                //            await handler.Handle(postedEvent);
                //        }
                //    }
                //    catch (Exception ex)
                //    {
                //        return ReturnBase<GoodsReceiptDto>.Fail(ex, _exceptionManager);
                //    }
                //}



                return ReturnBase<GoodsReceiptDto>.Success(_mapper.Map<GoodsReceiptDto>(entity));
            }
            catch (Exception ex)
            {
                return ReturnBase<GoodsReceiptDto>.Fail(ex, _exceptionManager);
            }
        }

        public async Task<ReturnBase<GoodsReceiptDto>> Delete(long id)
        {
            try
            {
                var entity = await _queriesManager.GoodsReceipts.GetById(id);
                if (entity == null)
                    return ReturnBase<GoodsReceiptDto>.Fail(new List<ReturnBaseError>
                    {
                        new() { ErrorCode = "404", ErrorMessage = "GoodsReceipt Not Found" }
                    });


                var updateResult = await _commands.DeleteAsync(id);
                if (!updateResult.Succeeded) return ReturnBase<GoodsReceiptDto>.Fail(updateResult.Errors);

                var saveResult = await _accountUoW.SaveAsync();
                if (!saveResult.Succeeded) return ReturnBase<GoodsReceiptDto>.Fail(saveResult.Errors);

                return ReturnBase<GoodsReceiptDto>.Success(_mapper.Map<GoodsReceiptDto>(entity));
            }
            catch (Exception ex)
            {
                return ReturnBase<GoodsReceiptDto>.Fail(ex, _exceptionManager);
            }
        }

        public async Task<ReturnBase<GoodsReceiptDto>> GetById(long id)
        {
            try
            {
                var entity = await _queries.GetById(id);
                if (entity == null)
                    return ReturnBase<GoodsReceiptDto>.Fail(new List<ReturnBaseError>
                    {
                        new() { ErrorCode = "404", ErrorMessage = "GoodsReceipt Not Found" }
                    });

                return ReturnBase<GoodsReceiptDto>.Success(_mapper.Map<GoodsReceiptDto>(entity));
            }
            catch (Exception ex)
            {
                return ReturnBase<GoodsReceiptDto>.Fail(ex, _exceptionManager);
            }
        }
        public async Task<ReturnBase<IEnumerable<GoodsReceiptReturnSearchDto>>> Search(SqlQueryOptions sqlQueryOptions)
        {
            try
            {
                var result = await _queries.Search(sqlQueryOptions);
                if (!result.Succeeded) return ReturnBase<IEnumerable<GoodsReceiptReturnSearchDto>>.Fail(result.Errors);

                var mapped = result.Result.Select(c => _mapper.Map<GoodsReceiptReturnSearchDto>(c)).ToList();
                return ReturnBase<IEnumerable<GoodsReceiptReturnSearchDto>>.Success(mapped);
            }
            catch (Exception ex)
            {
                return ReturnBase<IEnumerable<GoodsReceiptReturnSearchDto>>.Fail(ex, _exceptionManager);
            }
        }
        private ReturnBase ValidateCreateAttribute(GoodsReceiptCreateDto dto)
        {
            if (dto == null)
            {
                return ReturnBase.Fail(new List<ReturnBaseError>
        {
            new() { ErrorCode = "400", ErrorMessage = "GoodsReceipt data is null" }
        });
            }

            if (dto.WarehouseId <= 0)
            {
                return ReturnBase.Fail(new List<ReturnBaseError>
        {
            new() { ErrorCode = "400", ErrorMessage = "Invalid WarehouseId" }
        });
            }



            if (dto.GoodsReceiptDate == DateTime.MinValue)
            {
                return ReturnBase.Fail(new List<ReturnBaseError>
        {
            new() { ErrorCode = "400", ErrorMessage = "Invalid PostingDate" }
        });
            }

            if (dto.CompanyId <= 0)
            {
                return ReturnBase.Fail(new List<ReturnBaseError>
        {
            new() { ErrorCode = "400", ErrorMessage = "Invalid CompanyId" }
        });
            }

            //    if (dto.Status == null)
            //    {
            //        return ReturnBase.Fail(new List<ReturnBaseError>
            //{
            //    new() { ErrorCode = "400", ErrorMessage = "Invalid Status" }
            //});
            //    }

            if (dto.GoodsReceiptLines != null)
            {
                foreach (var line in dto.GoodsReceiptLines)
                {
                    if (line.ItemId <= 0)
                    {
                        return ReturnBase.Fail(new List<ReturnBaseError>
            {
                new() { ErrorCode = "400", ErrorMessage = "ItemId is mandatory" }
            });
                    }

                    if (line.UnitOfMeasureId <= 0)
                    {
                        return ReturnBase.Fail(new List<ReturnBaseError>
            {
                new() { ErrorCode = "400", ErrorMessage = "Unit Of Measure is mandatory" }
            });
                    }

                    if (line.Quantity <= 0)
                    {
                        return ReturnBase.Fail(new List<ReturnBaseError>
            {
                new() { ErrorCode = "400", ErrorMessage = "Quantity must be greater than zero" }
            });
                    }



                    if (line.TotalCost <= 0)
                    {
                        return ReturnBase.Fail(new List<ReturnBaseError>
            {
                new() { ErrorCode = "400", ErrorMessage = "TotalCost must be greater than zero" }
            });
                    }
                }
            }



            return ReturnBase.Success();
        }
        private ReturnBase ValidateUpdateAttribute(GoodsReceiptUpdateDto dto)
        {
            if (dto == null)
            {
                return ReturnBase.Fail(new List<ReturnBaseError>
        {
            new() { ErrorCode = "400", ErrorMessage = "GoodsReceipt data is null" }
        });
            }

            if (dto.WarehouseId <= 0)
            {
                return ReturnBase.Fail(new List<ReturnBaseError>
        {
            new() { ErrorCode = "400", ErrorMessage = "Invalid WarehouseId" }
        });
            }



            if (dto.CompanyId <= 0)
            {
                return ReturnBase.Fail(new List<ReturnBaseError>
        {
            new() { ErrorCode = "400", ErrorMessage = "Invalid CompanyId" }
        });
            }

            //    if (dto.Status == null)
            //    {
            //        return ReturnBase.Fail(new List<ReturnBaseError>
            //{
            //    new() { ErrorCode = "400", ErrorMessage = "Invalid Status" }
            //});
            //    }

            if (dto.GoodsReceiptLines != null)
            {
                foreach (var line in dto.GoodsReceiptLines)
                {
                    if (line.ItemId <= 0)
                    {
                        return ReturnBase.Fail(new List<ReturnBaseError>
            {
                new() { ErrorCode = "400", ErrorMessage = "ItemId is mandatory" }
            });
                    }

                    if (line.UnitOfMeasureId <= 0)
                    {
                        return ReturnBase.Fail(new List<ReturnBaseError>
            {
                new() { ErrorCode = "400", ErrorMessage = "Unit Of Measure is mandatory" }
            });
                    }

                    if (line.Quantity <= 0)
                    {
                        return ReturnBase.Fail(new List<ReturnBaseError>
            {
                new() { ErrorCode = "400", ErrorMessage = "Quantity must be greater than zero" }
            });
                    }



                    if (line.TotalCost <= 0)
                    {
                        return ReturnBase.Fail(new List<ReturnBaseError>
            {
                new() { ErrorCode = "400", ErrorMessage = "TotalCost must be greater than zero" }
            });
                    }
                }
            }

            return ReturnBase.Success();
        }






        public async Task<ReturnBase<ImportResultDto>> ImportGoodsReceipts(ExcelImportRequestDto dto)
        {
            try
            {
                var finalResult = new ImportResultDto();
                var profile = new GoodsReceiptImportProfile();

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
                    GoodsReceiptCreateDto? createDto = null;

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



                    // Warehouse To (Optional)
                    if (rawRow.TryGetValue("WarehouseCode", out var whToCode) &&
                        !string.IsNullOrWhiteSpace(whToCode))
                    {
                        if (!warehouseCache.TryGetValue(whToCode, out var whId))
                        {
                            var wh = await _queriesManager.Warehouses.GetByCode(whToCode);
                            if (wh == null)
                                rowErrors.Add($"Warehouse '{whToCode}' not found.");
                            else
                                warehouseCache[whToCode] = whId = wh.Id;
                        }

                        if (warehouseCache.TryGetValue(whToCode, out var wid))
                            createDto.WarehouseId = wid;
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
                    .GenerateTemplateAsync<GoodsReceiptImportTemplateDto>("GoodsReceipt");

                var file = new FileResultDto
                {
                    Content = content,
                    FileName = " GoodsReceipts.xlsx"
                };

                return ReturnBase<FileResultDto>.Success(file);
            }
            catch (Exception ex)
            {
                return ReturnBase<FileResultDto>.Fail(ex, _exceptionManager);
            }
        }

    }
}