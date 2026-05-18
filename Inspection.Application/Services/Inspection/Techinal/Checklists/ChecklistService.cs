using AutoMapper;
using ClosedXML.Excel;
using Inspection.Application.Contracts.Dto.InspectionDto.Techinal.Checklists;
using Inspection.Application.Contracts.Dto.SharedDtos;
using Inspection.Application.Contracts.Managers;
using Inspection.Application.Contracts.Repositories.Command.Inspection.Techinal.Checklists;
using Inspection.Application.Contracts.Services.Inspection.Techinal.Checklists;
using Inspection.Application.Contracts.Services.MenuManagement.SeriesF;
using Inspection.Application.Contracts.UnitOfWork;
using Inspection.Application.Services.ServicesBase;
using Inspection.Application.Shared.ExcelTemplate;
using Inspection.Domain.Models.Inspection.Techinal.ChecklistLines;
using Inspection.Domain.Models.Inspection.Techinal.Checklists;
using NDS.Shared.Application.DataQuery;
using NDS.Shared.Application.Multitenant;
using NDS.Shared.Kernel.BaseReturnTypes;
using NDS.Shared.Kernel.Exceptions;

namespace Inspection.Application.Services.Inspection.Techinal.Checklists
{
    public class ChecklistService : AccountsServiceBase, IChecklistService
    {
        private readonly ITenantResolver _tenantResolver;
        private readonly IExcelTemplateGenerator _templateGenerator;
        private readonly ISeriesService _seriesService;

        public ChecklistService(IAccountUnitOfWork accountUoW,
            IAccountsQueriesManager queriesManager, IMapper mapper,
            ITenantResolver tenantResolver, IExceptionManager exceptionManager,
            IExcelTemplateGenerator templateGenerator,
            ISeriesService seriesService) : base(accountUoW, queriesManager, mapper, exceptionManager)
        {
            this._tenantResolver = tenantResolver;
            this._templateGenerator = templateGenerator;
            this._seriesService = seriesService;

        }

        public async Task<ReturnBase<ChecklistDto>> Create(ChecklistCreateDto createDto)
        {
            try
            {
                const string SCREEN_CODE = "Checklist";

                var series = await _queriesManager.Series
                    .GetByScreen_IDAsync(SCREEN_CODE);

                if (series == null || !series.IsActive)
                {
                    return ReturnBase<ChecklistDto>.Fail(
                        new Exception($"No active series for '{SCREEN_CODE}'"),
                        _exceptionManager);
                }

                var seriesResult =
                    await this._seriesService
                        .GetSeriesCodeWithCustomDateUsingSeriesDetails(
                            series.Id,
                            DateTime.UtcNow);

                if (!seriesResult.Succeeded || seriesResult.Result == null)
                    return ReturnBase<ChecklistDto>.Fail(seriesResult.Errors);
                var entity = _mapper.Map<Checklist>(createDto);

                entity.Tenant_ID = _tenantResolver.GetTenantName();
                entity.SeriesId = series.Id;
                entity.ChecklistNumber =
                    seriesResult.Result["FinelSeriesCodeAndSeriesNumber"];
                entity.RunningNumber =
                    int.Parse(seriesResult.Result["RunningNumber"]);
                if (createDto.ChecklistLines != null && createDto.ChecklistLines.Any())
                {
                    entity.ChecklistLines = _mapper.Map<List<ChecklistLine>>(createDto.ChecklistLines);

                    foreach (var varient in entity.ChecklistLines)
                    {
                        varient.Checklist = entity;
                    }
                }
                else
                {
                    entity.ChecklistLines = new List<ChecklistLine>();
                }

                var insertResult = await _commands.InsertAsync(entity);
                if (!insertResult.Succeeded)
                    return ReturnBase<ChecklistDto>.Fail(insertResult.Errors);

                var saveResult = await _accountUoW.SaveAsync();
                if (saveResult == null)
                    return ReturnBase<ChecklistDto>.Fail(new List<ReturnBaseError>
            {
                new() { ErrorCode = "500", ErrorMessage = "SaveAsync returned null" }
            });

                if (!saveResult.Succeeded)
                    return ReturnBase<ChecklistDto>.Fail(
                        saveResult.Errors?.ToList() ??
                        new List<ReturnBaseError>
                        {
                    new() { ErrorCode = "500", ErrorMessage = "Save failed" }
                        });

                return ReturnBase<ChecklistDto>.Success(_mapper.Map<ChecklistDto>(entity));
            }
            catch (Exception ex)
            {
                return ReturnBase<ChecklistDto>.Fail(ex, _exceptionManager);
            }
        }

        public async Task<ReturnBase<ChecklistDto>> Update(ChecklistUpdateDto dto)
        {
            try
            {
                var tenantId = _tenantResolver.GetTenantName();

                var entity = await _queriesManager.Checklists.GetById(dto.Id);
                if (entity == null)
                {
                    return ReturnBase<ChecklistDto>.Fail(new List<ReturnBaseError>
                    {
                        new() { ErrorCode = "404", ErrorMessage = "Checklist Not Found" }
                    });
                }

                // Update Checklist main fields
                _mapper.Map(dto, entity);

                var existingVariants = entity.ChecklistLines.ToList();

                // Case 1: User sent NO variants → HARD DELETE ALL
                if (dto.ChecklistLines == null || !dto.ChecklistLines.Any())
                {
                    await _commands.DeleteDetailsByChecklistId(entity.Id);
                }
                else
                {
                    var dtoVariantIds = dto.ChecklistLines
                        .Where(v => v.Id > 0)
                        .Select(v => v.Id)
                        .ToHashSet();

                    // CREATE & UPDATE
                    foreach (var variantDto in dto.ChecklistLines)
                    {
                        // CREATE
                        if (variantDto.Id == 0)
                        {
                            var newVariant = _mapper.Map<ChecklistLine>(variantDto);
                            newVariant.ChecklistId = entity.Id;
                            entity.ChecklistLines.Add(newVariant);
                        }
                        else
                        {
                            // UPDATE
                            var existingVariant =
                                existingVariants.FirstOrDefault(v => v.Id == variantDto.Id);

                            if (existingVariant != null)
                            {
                                _mapper.Map(variantDto, existingVariant);
                            }
                        }
                    }

                    // HARD DELETE removed variants
                    var removedVariants = existingVariants
                        .Where(v => !dtoVariantIds.Contains(v.Id))
                        .Select(v => v.Id)
                        .ToList();

                    if (removedVariants.Any())
                    {
                        await _commands.DeleteDetailsByIds(removedVariants);
                    }
                }

                // Save
                var saveResult = await _accountUoW.SaveAsync();
                if (!saveResult.Succeeded)
                    return ReturnBase<ChecklistDto>.Fail(saveResult.Errors);

                entity.Tenant_ID = _tenantResolver.GetTenantName();

                return ReturnBase<ChecklistDto>.Success(_mapper.Map<ChecklistDto>(entity));
            }
            catch (Exception ex)
            {
                return ReturnBase<ChecklistDto>.Fail(ex, _exceptionManager);
            }
        }




        public async Task<ReturnBase<ChecklistDto>> Delete(long id)
        {
            try
            {
                var entity = await _queriesManager.Checklists.GetById(id);
                if (entity == null)
                    return ReturnBase<ChecklistDto>.Fail(new List<ReturnBaseError>
                    {
                        new() { ErrorCode = "404", ErrorMessage = "Checklist Not Found" }
                    });


                var updateResult = await _commands.DeleteAsync(id);
                if (!updateResult.Succeeded) return ReturnBase<ChecklistDto>.Fail(updateResult.Errors);

                var saveResult = await _accountUoW.SaveAsync();
                if (!saveResult.Succeeded) return ReturnBase<ChecklistDto>.Fail(saveResult.Errors);

                return ReturnBase<ChecklistDto>.Success(_mapper.Map<ChecklistDto>(entity));
            }
            catch (Exception ex)
            {
                return ReturnBase<ChecklistDto>.Fail(ex, _exceptionManager);
            }
        }

        public async Task<ReturnBase<IEnumerable<ChecklistSearchReturnDto>>> Search(SqlQueryOptions sqlQueryOptions)
        {
            try
            {
                var getResult = await _queriesManager.Checklists.Search(sqlQueryOptions);
                if (!getResult.Succeeded)
                    return ReturnBase<IEnumerable<ChecklistSearchReturnDto>>.Fail(getResult.Errors);

                return ReturnBase<IEnumerable<ChecklistSearchReturnDto>>.Success(getResult.Result);
            }
            catch (Exception ex)
            {
                return ReturnBase<IEnumerable<ChecklistSearchReturnDto>>.Fail(ex, _exceptionManager);
            }
        }
        public async Task<ReturnBase<ChecklistDto>> GetById(long id)
        {
            try
            {
                var entity = await _queriesManager.Checklists.GetById(id);
                if (entity is null)
                {
                    var error = new ReturnBaseError
                    {
                        ErrorCode = "404",
                        ErrorMessage = "Checklist Not Found"
                    };
                    var listOfErrors = new List<ReturnBaseError>() { error };
                    return ReturnBase<ChecklistDto>.Fail(listOfErrors);
                }

                var mappedResult = _mapper.Map<ChecklistDto>(entity);

                return ReturnBase<ChecklistDto>.Success(mappedResult);
            }
            catch (Exception ex)
            {
                return ReturnBase<ChecklistDto>.Fail(ex, _exceptionManager);
            }
        }




        //public async Task<ReturnBase<ChecklistDto>> GetByCode(string code)
        //{
        //    try
        //    {
        //       // var entity = await _queriesManager.Checklists.GetByCode(code);
        //        if (entity == null)
        //        {
        //            var error = new ReturnBaseError
        //            {
        //                ErrorCode = "404",
        //                ErrorMessage = "Checklist Not Found"
        //            };
        //            return ReturnBase<ChecklistDto>.Fail(new List<ReturnBaseError> { error });
        //        }

        //        var mappedResult = _mapper.Map<ChecklistDto>(entity);
        //        return ReturnBase<ChecklistDto>.Success(mappedResult);
        //    }
        //    catch (Exception ex)
        //    {
        //        return ReturnBase<ChecklistDto>.Fail(ex, _exceptionManager);
        //    }
        //}


        //Import Dynamic Companies
        public async Task<ReturnBase<ImportResultDto>> ImportChecklist(ExcelImportRequestDto dto)
        {
            try
            {
                var result = new ImportResultDto();
                var profile = new ChecklistImportProfile();

                using var stream = dto.File.OpenReadStream();
                using var workbook = new XLWorkbook(stream);
                var ws = workbook.Worksheets.First();

                var headerRow = ws.FirstRowUsed()
                    ?? throw new InvalidOperationException("Excel file has no header.");

                var headers = headerRow.Cells()
                    .Select(c => c.GetString().Trim())
                    .Where(h => !string.IsNullOrWhiteSpace(h))
                    .ToList();

                var firstRow = headerRow.RowNumber() + 1;
                var lastRow = ws.LastRowUsed()?.RowNumber() ?? firstRow - 1;

                // FK caches
                var standardCache = new Dictionary<string, long>(StringComparer.OrdinalIgnoreCase);
                var inspectionTypeCache = new Dictionary<string, long>(StringComparer.OrdinalIgnoreCase);
                var companyCache = new Dictionary<string, long>(StringComparer.OrdinalIgnoreCase);
                var checklistTemplateCache = new Dictionary<string, long>(StringComparer.OrdinalIgnoreCase);
                var equipmentCache = new Dictionary<string, long>(StringComparer.OrdinalIgnoreCase);
                var inspectorCache = new Dictionary<string, long>(StringComparer.OrdinalIgnoreCase);

                for (int r = firstRow; r <= lastRow; r++)
                {
                    result.ProcessedCount++;

                    var rawRow = new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase);
                    for (int c = 0; c < headers.Count; c++)
                        rawRow[headers[c]] = ws.Cell(r, c + 1).GetString().Trim();

                    var rowErrors = new List<string>();
                    ChecklistCreateDto? createDto = null;

                    try
                    {
                        createDto = await profile.MapAsync(rawRow, rowErrors);
                        await profile.ValidateAsync(createDto, rawRow, rowErrors);
                    }
                    catch (Exception ex)
                    {
                        rowErrors.Add(ex.Message);
                    }

                    // ---------- Standard ----------
                    if (rawRow.TryGetValue("StandardCode", out var standardCode) &&
                        !string.IsNullOrWhiteSpace(standardCode))
                    {
                        if (!standardCache.TryGetValue(standardCode, out var standardId))
                        {
                            var standard = await _queriesManager.InspectionStandards.GetByCode(standardCode);
                            if (standard == null)
                                rowErrors.Add($"Standard '{standardCode}' not found.");
                            else
                                standardCache[standardCode] = standardId = standard.Id;
                        }

                        if (standardCache.TryGetValue(standardCode, out var id))
                            createDto!.StandardId = id;
                    }

                    // ---------- Company ----------
                    if (rawRow.TryGetValue("CompanyCode", out var companyCode) &&
                        !string.IsNullOrWhiteSpace(companyCode))
                    {
                        if (!companyCache.TryGetValue(companyCode, out var companyId))
                        {
                            var company = await _queriesManager.Companies.GetByCode(companyCode);
                            if (company == null)
                                rowErrors.Add($"Company '{companyCode}' not found.");
                            else
                                companyCache[companyCode] = companyId = company.Id;
                        }

                        if (companyCache.TryGetValue(companyCode, out var id))
                            createDto!.CompanyId = id;
                    }

                    // ---------- InspectionType ----------
                    if (rawRow.TryGetValue("InspectionTypeCode", out var inspectionTypeCode) &&
                        !string.IsNullOrWhiteSpace(inspectionTypeCode))
                    {
                        //if (!inspectionTypeCache.TryGetValue(inspectionTypeCode, out var inspectionTypeId))
                        //{
                        //    var inspectionType = await _queriesManager.InspectionTypes.GetByCode(inspectionTypeCode);
                        //    if (inspectionType == null)
                        //        rowErrors.Add($"InspectionType '{inspectionTypeCode}' not found.");
                        //    else
                        //        inspectionTypeCache[inspectionTypeCode] =
                        //            inspectionTypeId = inspectionType.Id;
                        //}

                        if (inspectionTypeCache.TryGetValue(inspectionTypeCode, out var id))
                            createDto!.InspectionTypeId = id;
                    }

                    // ---------- ChecklistTemplate ----------
                    if (rawRow.TryGetValue("ChecklistTemplateCode", out var templateCode) &&
                        !string.IsNullOrWhiteSpace(templateCode))
                    {
                        if (!checklistTemplateCache.TryGetValue(templateCode, out var templateId))
                        {
                            var template = await _queriesManager.ChecklistTemplates.GetByCode(templateCode);
                            if (template == null)
                                rowErrors.Add($"ChecklistTemplate '{templateCode}' not found.");
                            else
                                checklistTemplateCache[templateCode] =
                                    templateId = template.Id;
                        }

                        if (checklistTemplateCache.TryGetValue(templateCode, out var id))
                            createDto!.ChecklistTemplateId = id;
                    }

                    // ---------- Equipment ---------- no code in this class
                    if (rawRow.TryGetValue("EquipmentCode", out var equipmentCode) &&
                        !string.IsNullOrWhiteSpace(equipmentCode))
                    {
                        if (!equipmentCache.TryGetValue(equipmentCode, out var equipmentId))
                        {
                            //var equipment = await _queriesManager.Equipment.GetByCode(equipmentCode);
                            //if (equipment == null)
                            //    rowErrors.Add($"Equipment '{equipmentCode}' not found.");
                            //else
                            //    equipmentCache[equipmentCode] =
                            //        equipmentId = equipment.Id;
                        }

                        if (equipmentCache.TryGetValue(equipmentCode, out var id))
                            createDto!.EquipmentId = id;
                    }

                    // ---------- Inspector ----------
                    if (rawRow.TryGetValue("InspectorCode", out var inspectorCode) &&
                        !string.IsNullOrWhiteSpace(inspectorCode))
                    {
                        if (!inspectorCache.TryGetValue(inspectorCode, out var inspectorId))
                        {
                            var inspector = await _queriesManager.Inspector.GetByCode(inspectorCode);
                            if (inspector == null)
                                rowErrors.Add($"Inspector '{inspectorCode}' not found.");
                            else
                                inspectorCache[inspectorCode] =
                                    inspectorId = inspector.Id;
                        }

                        if (inspectorCache.TryGetValue(inspectorCode, out var id))
                            createDto!.InspectorId = id;
                    }

                    // ---------- Errors ----------
                    if (rowErrors.Any())
                    {
                        result.FailedRows.Add(new ImportRowErrorDto
                        {
                            RowNumber = r,
                            RawRowData = string.Join(" | ", rawRow.Select(x => $"{x.Key}:{x.Value}")),
                            Errors = rowErrors
                        });
                        continue;
                    }

                    // ---------- Create ----------
                    var createResult = await Create(createDto!);
                    if (!createResult.Succeeded)
                    {
                        result.FailedRows.Add(new ImportRowErrorDto
                        {
                            RowNumber = r,
                            RawRowData = string.Join(" | ", rawRow.Select(x => $"{x.Key}:{x.Value}")),
                            Errors = createResult.Errors
                                .Select(e => $"{e.ErrorCode}: {e.ErrorMessage}")
                                .ToList()
                        });
                        continue;
                    }

                    result.CreatedCount++;
                }

                return ReturnBase<ImportResultDto>.Success(result);
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
                    .GenerateTemplateAsync<ChecklistImportTemplateDto>("Checklist");

                var file = new FileResultDto
                {
                    Content = content,
                    FileName = "Checklist.xlsx"
                };

                return ReturnBase<FileResultDto>.Success(file);
            }
            catch (Exception ex)
            {
                return ReturnBase<FileResultDto>.Fail(ex, _exceptionManager);
            }
        }


        private IChecklistCommandRepository _commands
        {
            get { return _accountUoW.Checklist; }
        }
    }

}

