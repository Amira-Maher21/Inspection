using AutoMapper;
using ClosedXML.Excel;
using Inspection.Application.Contracts.Dto.AccountingDtos.Assets.Setup.FixedAssetDTOs;
using Inspection.Application.Contracts.Dto.SharedDtos;
using Inspection.Application.Contracts.Managers;
using Inspection.Application.Contracts.Repositories.Command.Accounting.Assets.Setup.FixedAssets;
using Inspection.Application.Contracts.Repositories.Query.Accounting.Assets.Setup.FixedAssets;
using Inspection.Application.Contracts.Services.Accounting.Assets.Setup.FixedAssets;
using Inspection.Application.Contracts.Services.MenuManagement.SeriesF;
using Inspection.Application.Contracts.UnitOfWork;
using Inspection.Application.Services.ServicesBase;
using Inspection.Application.Shared.ExcelTemplate;
using Inspection.Application.Shared.SharedValidation;
using Inspection.Domain.Models.Accounting.Assets.Setup.FixedAssets;
using NDS.Shared.Application.DataQuery;
using NDS.Shared.Application.Multitenant;
using NDS.Shared.Kernel.BaseReturnTypes;
using NDS.Shared.Kernel.Exceptions;

namespace Inspection.Application.Services.Accounting.Assets.Setup.FixedAssets
{
    internal class FixedAssetService : AccountsServiceBase, IFixedAssetService
    {
        private readonly ITenantResolver _tenantResolver;
        private readonly IExcelTemplateGenerator _templateGenerator;
        private readonly ISeriesService _seriesService;


        public FixedAssetService(IAccountUnitOfWork accountUoW, IAccountsQueriesManager queriesManager, IMapper mapper, IExceptionManager exceptionManager, ITenantResolver tenantResolver, IExcelTemplateGenerator templateGenerator, ISeriesService seriesService
) : base(accountUoW, queriesManager, mapper, exceptionManager)
        {
            _tenantResolver = tenantResolver;
            _templateGenerator = templateGenerator;
            _seriesService = seriesService;

        }

        private IFixedAssetCommandRepository _commands => _accountUoW.FixedAsset;
        private IFixedAssetQueryRepository _queries => _queriesManager.FixedAsset;

        public async Task<ReturnBase<FixedAssetDto>> Create(FixedAssetCreateDto createDto)
        {
            try
            {
                //createDto.Code.ValidateAsCode();
                createDto.Name.ValidateAsName();
                // 🔒 Business validation
                var ruleErrors = ValidateFixedAssetBusinessRules(
                    createDto.AcquisitionDate,
                    createDto.CapitalizationDate,
                    createDto.AcquisitionCost,
                    createDto.ResidualValue,
                    createDto.UsefulLifeMonths);

                if (ruleErrors.Any())
                    return ReturnBase<FixedAssetDto>.Fail(ruleErrors);

                var entity =
                    _mapper.Map<FixedAsset>(createDto);

                entity.Tenant_ID = _tenantResolver.GetTenantName();






                // SCREEN CODE
                const string SCREEN_CODE = "Fixed Assets";

                var series = await _queriesManager.Series.GetByScreen_IDAsync(SCREEN_CODE);

                if (series == null || !series.IsActive)
                {
                    return ReturnBase<FixedAssetDto>.Fail(
                        new Exception($"No active series configured for screen '{SCREEN_CODE}'"),
                        _exceptionManager
                    );
                }

                entity.SeriesId = series.Id;

                // Generate series number
                var seriesResult =
                    await _seriesService.GetSeriesCodeWithCustomDateUsingSeriesDetails(
                        series.Id, entity.AcquisitionDate
                     );

                if (!seriesResult.Succeeded || seriesResult.Result == null)
                    return ReturnBase<FixedAssetDto>.Fail(seriesResult.Errors);

                entity.Code =
                    seriesResult.Result["FinelSeriesCodeAndSeriesNumber"];

                entity.RunningNumber =
                    int.Parse(seriesResult.Result["RunningNumber"]);

                var insertResult = await _commands.InsertAsync(entity);
                if (!insertResult.Succeeded)
                    return ReturnBase<FixedAssetDto>.Fail(insertResult.Errors);

                var saveResult = await _accountUoW.SaveAsync();
                if (!saveResult.Succeeded)
                    return ReturnBase<FixedAssetDto>.Fail(saveResult.Errors);

                var resultDto = _mapper.Map<FixedAssetDto>(entity);
                return ReturnBase<FixedAssetDto>.Success(resultDto);
            }
            catch (Exception ex)
            {
                return ReturnBase<FixedAssetDto>.Fail(ex, _exceptionManager);
            }
        }


        public async Task<ReturnBase<FixedAssetDto>> Update(FixedAssetUpdateDto updateDto)
        {
            try
            {
                //updateDto.Code.ValidateAsCode();
                updateDto.Name.ValidateAsName();
                var entity = await _queriesManager.FixedAsset.GetById(updateDto.Id);
                if (entity == null)
                {
                    return ReturnBase<FixedAssetDto>.Fail(new List<ReturnBaseError>
            {
                new()
                {
                    ErrorCode = "404",
                    ErrorMessage = "Fixed Asset Not Found"
                }
            });
                }


                entity.Tenant_ID = _tenantResolver.GetTenantName();

                // 🔒 Business validation
                var ruleErrors = ValidateFixedAssetBusinessRules(
                    updateDto.AcquisitionDate,
                    updateDto.CapitalizationDate,
                    updateDto.AcquisitionCost,
                    updateDto.ResidualValue,
                    updateDto.UsefulLifeMonths);

                if (ruleErrors.Any())
                    return ReturnBase<FixedAssetDto>.Fail(ruleErrors);

                //  Map onto existing entity (IMPORTANT)
                _mapper.Map(updateDto, entity);


                var updateResult = await _commands.UpdateAsync(entity);
                if (!updateResult.Succeeded)
                    return ReturnBase<FixedAssetDto>.Fail(updateResult.Errors);

                var saveResult = await _accountUoW.SaveAsync();
                if (!saveResult.Succeeded)
                    return ReturnBase<FixedAssetDto>.Fail(saveResult.Errors);

                var mappedResult = _mapper.Map<FixedAssetDto>(entity);
                return ReturnBase<FixedAssetDto>.Success(mappedResult);
            }
            catch (Exception ex)
            {
                return ReturnBase<FixedAssetDto>.Fail(ex, _exceptionManager);
            }
        }

        public async Task<ReturnBase<FixedAssetDto>> Delete(long id)
        {
            try
            {
                var entity = await _queriesManager.FixedAsset.GetById(id);
                if (entity is null)
                {
                    var error = new ReturnBaseError
                    {
                        ErrorCode = "404",
                        ErrorMessage = "Fixed Asset Not Found"
                    };
                    var listOfErrors = new List<ReturnBaseError>() { error };
                    return ReturnBase<FixedAssetDto>.Fail(listOfErrors);
                }

                var deleteResult = await _commands.DeleteById(id);

                if (!deleteResult.Succeeded)
                    return ReturnBase<FixedAssetDto>.Fail(deleteResult.Errors);

                var saveResult = await _accountUoW.SaveAsync();

                if (!saveResult.Succeeded)
                    return ReturnBase<FixedAssetDto>.Fail(saveResult.Errors);

                var mappedResult = _mapper.Map<FixedAssetDto>(entity);

                return ReturnBase<FixedAssetDto>.Success(mappedResult);

            }
            catch (Exception ex)
            {
                return ReturnBase<FixedAssetDto>.Fail(ex, _exceptionManager);
            }
        }

        public async Task<ReturnBase<IEnumerable<FixedAssetReturnSearchDto>>> Search(SqlQueryOptions sqlQueryOptions)
        {
            try
            {
                var getResult = await _queriesManager.FixedAsset.Search(sqlQueryOptions);
                if (!getResult.Succeeded)
                    return ReturnBase<IEnumerable<FixedAssetReturnSearchDto>>.Fail(getResult.Errors);

                var mappedResult = _mapper.Map<IEnumerable<FixedAssetReturnSearchDto>>(getResult.Result);

                return ReturnBase<IEnumerable<FixedAssetReturnSearchDto>>.Success(mappedResult);
            }
            catch (Exception ex)
            {
                return ReturnBase<IEnumerable<FixedAssetReturnSearchDto>>.Fail(ex, _exceptionManager);
            }
        }

        public async Task<ReturnBase<FixedAssetDto>> GetById(long id)
        {
            try
            {
                var entity = await _queriesManager.FixedAsset.GetById(id);
                if (entity is null)
                {
                    var error = new ReturnBaseError
                    {
                        ErrorCode = "404",
                        ErrorMessage = "Fixed Asset Not Found"
                    };
                    var listOfErrors = new List<ReturnBaseError>() { error };
                    return ReturnBase<FixedAssetDto>.Fail(listOfErrors);
                }

                var mappedResult = _mapper.Map<FixedAssetDto>(entity);

                return ReturnBase<FixedAssetDto>.Success(mappedResult);
            }
            catch (Exception ex)
            {
                return ReturnBase<FixedAssetDto>.Fail(ex, _exceptionManager);
            }
        }
        public async Task<ReturnBase<ImportResultDto>> ImportFixedAssets(ExcelImportRequestDto dto)
        {
            try
            {
                var finalResult = new ImportResultDto();
                var profile = new FixedAssetImportProfile();

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

                // =========================
                // CACHES (ALL LOOKUPS)
                // =========================
                var assetCategoryCache = new Dictionary<string, long>(StringComparer.OrdinalIgnoreCase);
                var assetGroupCache = new Dictionary<string, long>(StringComparer.OrdinalIgnoreCase);
                var assetLocationCache = new Dictionary<string, long>(StringComparer.OrdinalIgnoreCase);
                var currencyCache = new Dictionary<string, long>(StringComparer.OrdinalIgnoreCase);
                var supplierCache = new Dictionary<string, long>(StringComparer.OrdinalIgnoreCase);

                var employeeCache = new Dictionary<string, long>(StringComparer.OrdinalIgnoreCase);
                var departmentCache = new Dictionary<string, long>(StringComparer.OrdinalIgnoreCase);

                var costCenterCache = new Dictionary<string, long>(StringComparer.OrdinalIgnoreCase);
                var costUnitCache = new Dictionary<string, long>(StringComparer.OrdinalIgnoreCase);

                var operationCache = new Dictionary<string, long>(StringComparer.OrdinalIgnoreCase);
                var wbsCache = new Dictionary<string, long>(StringComparer.OrdinalIgnoreCase);
                var costCodeCache = new Dictionary<string, long>(StringComparer.OrdinalIgnoreCase);
                var activityCache = new Dictionary<string, long>(StringComparer.OrdinalIgnoreCase);

                var boqLineCache = new Dictionary<string, long>(StringComparer.OrdinalIgnoreCase);
                var subcontractBoqCache = new Dictionary<string, long>(StringComparer.OrdinalIgnoreCase);
                var productionOrderCache = new Dictionary<string, long>(StringComparer.OrdinalIgnoreCase);

                for (int r = firstDataRow; r <= lastRow; r++)
                {
                    finalResult.ProcessedCount++;

                    // =========================
                    // READ ROW
                    // =========================
                    var rawRow = new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase);

                    for (int c = 0; c < headers.Count; c++)
                        rawRow[headers[c]] = ws.Cell(r, c + 1).GetString().Trim();

                    var rowErrors = new List<string>();
                    FixedAssetCreateDto? createDto = null;

                    // =========================
                    // MAP + VALIDATE
                    // =========================
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

                    // =========================
                    // RESOLVE FK (SAME STYLE AS YOUR CATEGORY)
                    // =========================

                    #region AssetCategory (REQUIRED)
                    if (rawRow.TryGetValue("AssetCategoryCode", out var assetCategoryCode) &&
                        !string.IsNullOrWhiteSpace(assetCategoryCode))
                    {
                        if (!assetCategoryCache.TryGetValue(assetCategoryCode, out var id))
                        {
                            var entity = await _queriesManager.AssetCategory.GetByCode(assetCategoryCode);

                            if (entity == null)
                                rowErrors.Add($"AssetCategory '{assetCategoryCode}' not found.");
                            else
                                assetCategoryCache[assetCategoryCode] = id = entity.Id;
                        }

                        if (assetCategoryCache.TryGetValue(assetCategoryCode, out var finalId))
                            createDto.AssetCategoryId = finalId;
                    }
                    else
                        rowErrors.Add("AssetCategoryCode is required.");
                    #endregion

                    #region AssetGroup
                    if (rawRow.TryGetValue("AssetGroupCode", out var assetGroupCode) &&
                        !string.IsNullOrWhiteSpace(assetGroupCode))
                    {
                        if (!assetGroupCache.TryGetValue(assetGroupCode, out var id))
                        {
                            var entity = await _queriesManager.AssetCategory.GetByCode(assetGroupCode);
                            if (entity != null)
                                assetGroupCache[assetGroupCode] = id = entity.Id;
                        }

                        if (assetGroupCache.TryGetValue(assetGroupCode, out var gid))
                            createDto.AssetGroupId = gid;
                    }
                    #endregion

                    #region AssetLocation
                    if (rawRow.TryGetValue("AssetLocationCode", out var assetLocationCode) &&
                        !string.IsNullOrWhiteSpace(assetLocationCode))
                    {
                        if (!assetLocationCache.TryGetValue(assetLocationCode, out var id))
                        {
                            var entity = await _queriesManager.AssetLocation.GetByCode(assetLocationCode);
                            if (entity != null)
                                assetLocationCache[assetLocationCode] = id = entity.Id;
                        }

                        if (assetLocationCache.TryGetValue(assetLocationCode, out var lid))
                            createDto.AssetLocationId = lid;
                    }
                    #endregion

                    #region Currency
                    if (rawRow.TryGetValue("CurrencyCode", out var currencyCode) &&
                        !string.IsNullOrWhiteSpace(currencyCode))
                    {
                        if (!currencyCache.TryGetValue(currencyCode, out var id))
                        {
                            var entity = await _queriesManager.Currencies.GetByCode(currencyCode);
                            if (entity != null)
                                currencyCache[currencyCode] = id = entity.Id;
                        }

                        if (currencyCache.TryGetValue(currencyCode, out var cid))
                            createDto.CurrencyId = cid;
                    }
                    #endregion

                    #region Supplier
                    if (rawRow.TryGetValue("SupplierCode", out var supplierCode) &&
                        !string.IsNullOrWhiteSpace(supplierCode))
                    {
                        if (!supplierCache.TryGetValue(supplierCode, out var id))
                        {
                            var entity = await _queriesManager.ISupplierQueryRepo.GetByCode(supplierCode);
                            if (entity != null)
                                supplierCache[supplierCode] = id = entity.Id;
                        }

                        if (supplierCache.TryGetValue(supplierCode, out var sid))
                            createDto.SupplierId = sid;
                    }
                    #endregion

                    // =========================
                    // ERROR HANDLING
                    // =========================
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

                    // =========================
                    // CREATE
                    // =========================
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

        public async Task<ReturnBase<FileResultDto>> DownloadTemplate()
        {
            try
            {
                var content = await _templateGenerator
                    .GenerateTemplateAsync<FixedAssetImportTemplateDto>("FixedAsset");

                var file = new FileResultDto
                {
                    Content = content,
                    FileName = "FixedAsset.xlsx"
                };

                return ReturnBase<FileResultDto>.Success(file);
            }
            catch (Exception ex)
            {
                return ReturnBase<FileResultDto>.Fail(ex, _exceptionManager);
            }
        }
        private static List<ReturnBaseError> ValidateFixedAssetBusinessRules(DateTime acquisitionDate, DateTime? capitalizationDate, decimal acquisitionCost,
                                                                              decimal residualValue, int usefulLifeMonths)
        {
            var errors = new List<ReturnBaseError>();

            // 1️ Acquisition cost >= residual value
            if (acquisitionCost < residualValue)
            {
                errors.Add(new ReturnBaseError
                {
                    ErrorCode = "BUSINESS_RULE",
                    ErrorMessage = "Acquisition cost must be greater than or equal to residual value."
                });
            }

            // 2️ Useful life must be positive
            if (usefulLifeMonths <= 0)
            {
                errors.Add(new ReturnBaseError
                {
                    ErrorCode = "BUSINESS_RULE",
                    ErrorMessage = "Useful life months must be greater than zero."
                });
            }

            // 3️ Capitalization date validation
            if (capitalizationDate.HasValue &&
                capitalizationDate.Value.Date < acquisitionDate.Date)
            {
                errors.Add(new ReturnBaseError
                {
                    ErrorCode = "BUSINESS_RULE",
                    ErrorMessage = "Capitalization date cannot be before acquisition date."
                });
            }

            return errors;
        }
        public async Task<ReturnBase<FixedAssetDto>> GetByCode(string code)
        {
            try
            {
                var entity = await _queriesManager.FixedAsset.GetByCode(code);
                if (entity is null)
                {
                    return ReturnBase<FixedAssetDto>.Fail(new List<ReturnBaseError>
            {
                new ReturnBaseError
                {
                    ErrorCode = "404",
                    ErrorMessage = "Fixed Asset Code Not Found"
                }
            });
                }

                var mappedResult = _mapper.Map<FixedAssetDto>(entity);
                return ReturnBase<FixedAssetDto>.Success(mappedResult);
            }
            catch (Exception ex)
            {
                return ReturnBase<FixedAssetDto>.Fail(ex, _exceptionManager);
            }
        }

    }
}
