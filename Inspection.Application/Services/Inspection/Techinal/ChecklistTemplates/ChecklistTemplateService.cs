using AutoMapper;
using ClosedXML.Excel;
using Inspection.Application.Contracts.Dto.InspectionDto.Techinal.ChecklistTemplates;
using Inspection.Application.Contracts.Dto.SharedDtos;
using Inspection.Application.Contracts.Managers;
using Inspection.Application.Contracts.Repositories.Command.Inspection.Techinal.ChecklistTemplates;
using Inspection.Application.Contracts.Services.Inspection.Techinal.ChecklistTemplates;
using Inspection.Application.Contracts.Services.MenuManagement.SeriesF;
using Inspection.Application.Contracts.UnitOfWork;
using Inspection.Application.Services.ServicesBase;
using Inspection.Application.Shared.ExcelTemplate;
using Inspection.Domain.Models.Inspection.Techinal.ChecklistTemplates;
using NDS.Shared.Application.DataQuery;
using NDS.Shared.Application.Multitenant;
using NDS.Shared.Kernel.BaseReturnTypes;
using NDS.Shared.Kernel.Exceptions;

namespace Inspection.Application.Services.Inspection.Techinal.ChecklistTemplates
{
    internal class ChecklistTemplateService : AccountsServiceBase, IChecklistTemplateService
    {
        private readonly ITenantResolver _tenantResolver;
        private readonly IExcelTemplateGenerator _templateGenerator;
        private readonly ISeriesService _seriesService;

        public ChecklistTemplateService(IAccountUnitOfWork accountUoW,
            IAccountsQueriesManager queriesManager, IMapper mapper,
            ITenantResolver tenantResolver, IExceptionManager exceptionManager,
            IExcelTemplateGenerator templateGenerator,
            ISeriesService seriesService) : base(accountUoW, queriesManager, mapper, exceptionManager)
        {
            this._tenantResolver = tenantResolver;
            this._templateGenerator = templateGenerator;
            this._seriesService = seriesService;

        }

        public async Task<ReturnBase<ChecklistTemplateDto>> Create(ChecklistTemplateCreateDto createDto)
        {
            try
            {
                const string SCREEN_CODE = "Checklist Template";

                var series = await _queriesManager.Series
                    .GetByScreen_IDAsync(SCREEN_CODE);

                if (series == null || !series.IsActive)
                {
                    return ReturnBase<ChecklistTemplateDto>.Fail(
                        new Exception($"No active series for '{SCREEN_CODE}'"),
                        _exceptionManager);
                }

                var seriesResult =
                    await this._seriesService
                        .GetSeriesCodeWithCustomDateUsingSeriesDetails(
                            series.Id,
                            DateTime.UtcNow);

                if (!seriesResult.Succeeded || seriesResult.Result == null)
                    return ReturnBase<ChecklistTemplateDto>.Fail(seriesResult.Errors);
                var entity = _mapper.Map<ChecklistTemplate>(createDto);

                entity.Tenant_ID = _tenantResolver.GetTenantName();
                entity.SeriesId = series.Id;
                entity.ChecklistTemplateNumber =
                    seriesResult.Result["FinelSeriesCodeAndSeriesNumber"];
                entity.RunningNumber =
                    int.Parse(seriesResult.Result["RunningNumber"]);
                if (createDto.ChecklistTemplateLines != null && createDto.ChecklistTemplateLines.Any())
                {
                    entity.ChecklistTemplateLines = _mapper.Map<List<ChecklistTemplateLine>>(createDto.ChecklistTemplateLines);

                    foreach (var varient in entity.ChecklistTemplateLines)
                    {
                        varient.ChecklistTemplate = entity;
                    }
                }
                else
                {
                    entity.ChecklistTemplateLines = new List<ChecklistTemplateLine>();
                }

                var insertResult = await _commands.InsertAsync(entity);
                if (!insertResult.Succeeded)
                    return ReturnBase<ChecklistTemplateDto>.Fail(insertResult.Errors);

                var saveResult = await _accountUoW.SaveAsync();
                if (saveResult == null)
                    return ReturnBase<ChecklistTemplateDto>.Fail(new List<ReturnBaseError>
            {
                new() { ErrorCode = "500", ErrorMessage = "SaveAsync returned null" }
            });

                if (!saveResult.Succeeded)
                    return ReturnBase<ChecklistTemplateDto>.Fail(
                        saveResult.Errors?.ToList() ??
                        new List<ReturnBaseError>
                        {
                    new() { ErrorCode = "500", ErrorMessage = "Save failed" }
                        });

                return ReturnBase<ChecklistTemplateDto>.Success(_mapper.Map<ChecklistTemplateDto>(entity));
            }
            catch (Exception ex)
            {
                return ReturnBase<ChecklistTemplateDto>.Fail(ex, _exceptionManager);
            }
        }


        public async Task<ReturnBase<ChecklistTemplateDto>> Update(ChecklistTemplateUpdateDto dto)
        {
            try
            {
                var tenantId = _tenantResolver.GetTenantName();
                var used = await _queriesManager.Checklists.GetChecklistTemplateById(dto.Id);
                if (used != null)
                {

                    return ReturnBase<ChecklistTemplateDto>.Fail(new List<ReturnBaseError>
                    {
                        new() { ErrorCode = "500", ErrorMessage = "ChecklistTemplate is being used" }
                    });
                }
                var entity = await _queriesManager.ChecklistTemplates.GetById(dto.Id);
                if (entity == null)
                {
                    return ReturnBase<ChecklistTemplateDto>.Fail(new List<ReturnBaseError>
                    {
                        new() { ErrorCode = "404", ErrorMessage = "ChecklistTemplate Not Found" }
                    });
                }

                // Update ChecklistTemplate main fields
                _mapper.Map(dto, entity);

                var existingVariants = entity.ChecklistTemplateLines.ToList();

                // Case 1: User sent NO variants → HARD DELETE ALL
                if (dto.ChecklistTemplateLines == null || !dto.ChecklistTemplateLines.Any())
                {
                    await _commands.DeleteDetailsByChecklistTemplateId(entity.Id);
                }
                else
                {
                    var dtoVariantIds = dto.ChecklistTemplateLines
                        .Where(v => v.Id > 0)
                        .Select(v => v.Id)
                        .ToHashSet();

                    // CREATE & UPDATE
                    foreach (var variantDto in dto.ChecklistTemplateLines)
                    {
                        // CREATE
                        if (variantDto.Id == 0)
                        {
                            var newVariant = _mapper.Map<ChecklistTemplateLine>(variantDto);
                            newVariant.ChecklistTemplateId = entity.Id;
                            entity.ChecklistTemplateLines.Add(newVariant);
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
                    return ReturnBase<ChecklistTemplateDto>.Fail(saveResult.Errors);

                entity.Tenant_ID = _tenantResolver.GetTenantName();

                return ReturnBase<ChecklistTemplateDto>.Success(_mapper.Map<ChecklistTemplateDto>(entity));
            }
            catch (Exception ex)
            {
                return ReturnBase<ChecklistTemplateDto>.Fail(ex, _exceptionManager);
            }
        }

        public async Task<ReturnBase<ChecklistTemplateDto>> Delete(long id)
        {
            try
            {
                var entity = await _queriesManager.ChecklistTemplates.GetById(id);

                if (entity == null)
                {
                    return ReturnBase<ChecklistTemplateDto>.Fail(new List<ReturnBaseError>
            {
                new() { ErrorCode = "404", ErrorMessage = "ChecklistTemplate Not Found" }
            });
                }

                var used = await _queriesManager.Checklists.GetChecklistTemplateById(id);

                if (used != null)
                {
                    return ReturnBase<ChecklistTemplateDto>.Fail(new List<ReturnBaseError>
            {
                new() { ErrorCode = "409", ErrorMessage = "ChecklistTemplate is being used" }
            });
                }

                var deleteResult = await _commands.DeleteById(id);

                if (!deleteResult.Succeeded)
                    return ReturnBase<ChecklistTemplateDto>.Fail(deleteResult.Errors);

                var saveResult = await _accountUoW.SaveAsync();

                if (!saveResult.Succeeded)
                    return ReturnBase<ChecklistTemplateDto>.Fail(saveResult.Errors);

                return ReturnBase<ChecklistTemplateDto>.Success(_mapper.Map<ChecklistTemplateDto>(entity));
            }
            catch (Exception ex)
            {
                return ReturnBase<ChecklistTemplateDto>.Fail(ex, _exceptionManager);
            }
        }
        public async Task<ReturnBase<IEnumerable<ChecklistTemplateSearchReturnDto>>> Search(SqlQueryOptions sqlQueryOptions)
        {
            try
            {
                var getResult = await _queriesManager.ChecklistTemplates.Search(sqlQueryOptions);
                if (!getResult.Succeeded)
                    return ReturnBase<IEnumerable<ChecklistTemplateSearchReturnDto>>.Fail(getResult.Errors);

                return ReturnBase<IEnumerable<ChecklistTemplateSearchReturnDto>>.Success(getResult.Result);
            }
            catch (Exception ex)
            {
                return ReturnBase<IEnumerable<ChecklistTemplateSearchReturnDto>>.Fail(ex, _exceptionManager);
            }
        }
        public async Task<ReturnBase<ChecklistTemplateDto>> GetById(long id)
        {
            try
            {
                var entity = await _queriesManager.ChecklistTemplates.GetById(id);
                if (entity is null)
                {
                    var error = new ReturnBaseError
                    {
                        ErrorCode = "404",
                        ErrorMessage = "ChecklistTemplate Not Found"
                    };
                    var listOfErrors = new List<ReturnBaseError>() { error };
                    return ReturnBase<ChecklistTemplateDto>.Fail(listOfErrors);
                }

                var mappedResult = _mapper.Map<ChecklistTemplateDto>(entity);

                return ReturnBase<ChecklistTemplateDto>.Success(mappedResult);
            }
            catch (Exception ex)
            {
                return ReturnBase<ChecklistTemplateDto>.Fail(ex, _exceptionManager);
            }
        }




        //public async Task<ReturnBase<ChecklistTemplateTemplateTemplateDto>> GetByCode(string code)
        //{
        //    try
        //    {
        //       // var entity = await _queriesManager.ChecklistTemplateTemplateTemplates.GetByCode(code);
        //        if (entity == null)
        //        {
        //            var error = new ReturnBaseError
        //            {
        //                ErrorCode = "404",
        //                ErrorMessage = "ChecklistTemplateTemplateTemplate Not Found"
        //            };
        //            return ReturnBase<ChecklistTemplateTemplateTemplateDto>.Fail(new List<ReturnBaseError> { error });
        //        }

        //        var mappedResult = _mapper.Map<ChecklistTemplateTemplateTemplateDto>(entity);
        //        return ReturnBase<ChecklistTemplateTemplateTemplateDto>.Success(mappedResult);
        //    }
        //    catch (Exception ex)
        //    {
        //        return ReturnBase<ChecklistTemplateTemplateTemplateDto>.Fail(ex, _exceptionManager);
        //    }
        //}


        //Import Dynamic Companies
        public async Task<ReturnBase<ImportResultDto>> ImportChecklistTemplate(ExcelImportRequestDto dto)
        {
            try
            {
                var result = new ImportResultDto();
                var profile = new ChecklistTemplateImportProfile();

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

                // 🔹 FK caches
                var standardCache = new Dictionary<string, long>(StringComparer.OrdinalIgnoreCase);
                var equipmentTypeCache = new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase);
                var companyCache = new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase);

                for (int r = firstRow; r <= lastRow; r++)
                {
                    result.ProcessedCount++;

                    var rawRow = new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase);
                    for (int c = 0; c < headers.Count; c++)
                        rawRow[headers[c]] = ws.Cell(r, c + 1).GetString().Trim();

                    var rowErrors = new List<string>();
                    ChecklistTemplateCreateDto? createDto = null;

                    try
                    {
                        createDto = await profile.MapAsync(rawRow, rowErrors);
                        await profile.ValidateAsync(createDto, rawRow, rowErrors);
                    }
                    catch (Exception ex)
                    {
                        rowErrors.Add(ex.Message);
                    }

                    // ---------- Resolve StandardCode ----------
                    if (rawRow.TryGetValue("StandardCode", out var standardCode) &&
                        !string.IsNullOrWhiteSpace(standardCode))
                    {
                        if (!standardCache.TryGetValue(standardCode, out var standardId))
                        {
                            var standard = await _queriesManager.ChecklistTemplates.GetByCode(standardCode);
                            if (standard == null)
                                rowErrors.Add($"ChecklistTemplate '{standardCode}' not found.");
                            else
                                standardCache[standardCode] = standardId = standard.Id;
                        }

                        if (standardCache.TryGetValue(standardCode, out var sid))
                            createDto!.StandardId = sid;
                    }
                    // ---------- Resolve CompanyCode ----------
                    if (rawRow.TryGetValue("CompanyCode", out var companyCode) &&
                        !string.IsNullOrWhiteSpace(companyCode))
                    {
                        if (!companyCache.TryGetValue(companyCode, out var companyId))
                        {
                            var company = await _queriesManager.Companies.GetByCode(companyCode);
                            if (company == null)
                                rowErrors.Add($"Company '{companyCode}' not found.");
                            else
                                companyCache[companyCode] = companyId = company.Id.ToString();
                        }

                        if (companyCache.TryGetValue(companyCode, out var cid))
                            createDto!.CompanyId = long.Parse(cid);
                    }



                    // ---------- Resolve EquipmentTypeCode ----------
                    if (rawRow.TryGetValue("EquipmentTypeCode", out var equipmentTypeCode) &&
                        !string.IsNullOrWhiteSpace(equipmentTypeCode))
                    {
                        if (!equipmentTypeCache.TryGetValue(equipmentTypeCode, out var equipmentTypeId))
                        {
                            var equipmentType = await _queriesManager.EquipmentTypes.GetByCode(equipmentTypeCode);
                            if (equipmentType == null)
                                rowErrors.Add($"EquipmentType '{equipmentTypeCode}' not found.");
                            else
                                equipmentTypeCache[equipmentTypeCode] = equipmentTypeId = equipmentType.Id.ToString();
                        }

                        if (equipmentTypeCache.TryGetValue(equipmentTypeCode, out var eid))
                            createDto!.EquipmentTypeId = long.Parse(eid);
                    }

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
                    .GenerateTemplateAsync<ChecklistTemplateImportTemplateDto>("ChecklistTemplate");

                var file = new FileResultDto
                {
                    Content = content,
                    FileName = "ChecklistTemplate.xlsx"
                };

                return ReturnBase<FileResultDto>.Success(file);
            }
            catch (Exception ex)
            {
                return ReturnBase<FileResultDto>.Fail(ex, _exceptionManager);
            }
        }

        public async Task<Domain.Models.Inspection.Techinal.ChecklistTemplates.ChecklistTemplate> GetByCode(string code)
        {
            return await _queriesManager.ChecklistTemplates.GetByCode(code);

        }



        private IChecklistTemplateCommandRepository _commands
        {
            get { return _accountUoW.ChecklistTemplate; }
        }
    }

}
