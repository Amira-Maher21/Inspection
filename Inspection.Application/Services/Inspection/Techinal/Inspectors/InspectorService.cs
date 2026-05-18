using AutoMapper;
using ClosedXML.Excel;
using Inspection.Application.Contracts.Dto.InspectionDto.Techinal.InspectorDTOs;
using Inspection.Application.Contracts.Dto.SharedDtos;
using Inspection.Application.Contracts.Managers;
using Inspection.Application.Contracts.Repositories.Command.Inspection.Techinal.Inspector;
using Inspection.Application.Contracts.Services.Inspection.Techinal.Inspectors;
using Inspection.Application.Contracts.Services.MenuManagement.SeriesF;
using Inspection.Application.Contracts.UnitOfWork;
using Inspection.Application.Services.ServicesBase;
using Inspection.Application.Shared.ExcelTemplate;
using Inspection.Application.Shared.SharedValidaion;
using Inspection.Application.Shared.SharedValidation;
using Inspection.Domain.Models.Inspection.Techinal.Inspectors;
using NDS.Shared.Application.DataQuery;
using NDS.Shared.Application.Multitenant;
using NDS.Shared.Kernel.BaseReturnTypes;
using NDS.Shared.Kernel.Exceptions;

namespace Inspection.Application.Services.Inspection.Techinal.Inspectors
{
    internal class InspectorService : AccountsServiceBase, IInspectorService
    {
        private readonly ITenantResolver _tenantResolver;
        private readonly IExcelTemplateGenerator _templateGenerator;
        private readonly ISeriesService _seriesService;

        public InspectorService(IAccountUnitOfWork accountUoW, IAccountsQueriesManager queriesManager, IMapper mapper, IExceptionManager exceptionManager, ITenantResolver tenantResolver, IExcelTemplateGenerator templateGenerator, ISeriesService seriesService) : base(accountUoW, queriesManager, mapper, exceptionManager)
        {
            _tenantResolver = tenantResolver;
            _templateGenerator = templateGenerator;
            _seriesService = seriesService;

        }

        public async Task<ReturnBase<InspectorDto>> Create(InspectorCreateDto createDto)
        {
            try
            {
                //createDto.Code.ValidateAsCode();
                createDto.FirstName.ValidateAsName();
                var entity = _mapper.Map<Inspector>(createDto);
                entity.Tenant_ID = _tenantResolver.GetTenantName();


                // SCREEN CODE
                const string SCREEN_CODE = "Inspector";

                var series = await _queriesManager.Series.GetByScreen_IDAsync(SCREEN_CODE);

                if (series == null || !series.IsActive)
                {
                    return ReturnBase<InspectorDto>.Fail(
                        new Exception($"No active series configured for screen '{SCREEN_CODE}'"),
                        _exceptionManager
                    );
                }

                entity.SeriesId = series.Id;

                // Generate series number
                var seriesResult =
                    await _seriesService.GetSeriesCodeWithCustomDateUsingSeriesDetails(
                        series.Id,
                        entity.HireDate
                    );

                if (!seriesResult.Succeeded || seriesResult.Result == null)
                    return ReturnBase<InspectorDto>.Fail(seriesResult.Errors);

                entity.Code =
                    seriesResult.Result["FinelSeriesCodeAndSeriesNumber"];

                entity.RunningNumber =
                    int.Parse(seriesResult.Result["RunningNumber"]);


                var insertResult = await _commands.InsertAsync(entity);
                if (!insertResult.Succeeded)
                {
                    return ReturnBase<InspectorDto>.Fail(insertResult.Errors);
                }

                var saveResult = await _accountUoW.SaveAsync();
                if (!saveResult.Succeeded)
                {
                    return ReturnBase<InspectorDto>.Fail(saveResult.Errors);
                }

                var resultDto = _mapper.Map<InspectorDto>(entity);

                return ReturnBase<InspectorDto>.Success(resultDto);
            }
            catch (Exception ex)
            {
                return ReturnBase<InspectorDto>.Fail(ex, _exceptionManager);
            }
        }

        public async Task<ReturnBase<InspectorDto>> Update(InspectorUpdateDto updateDto)
        {
            try
            {
                if (updateDto.Email != null)
                { EmailValidator.Validate(updateDto.Email); }
                //updateDto.Code.ValidateAsCode();
                updateDto.FirstName.ValidateAsName();

                var entity = await _queriesManager.Inspector.GetById(updateDto.Id);

                if (entity is null)
                {
                    var error = new ReturnBaseError
                    {
                        ErrorCode = "404",
                        ErrorMessage = $"Inspector with Id {updateDto.Id} was not found"
                    };
                    var listOfErrors = new List<ReturnBaseError>() { error };
                    return ReturnBase<InspectorDto>.Fail(listOfErrors);
                }
                entity.Tenant_ID = _tenantResolver.GetTenantName();

                _mapper.Map(updateDto, entity);

                var updateResult = await _commands.UpdateAsync(entity);

                if (!updateResult.Succeeded)
                    return ReturnBase<InspectorDto>.Fail(updateResult.Errors);

                var saveResult = await _accountUoW.SaveAsync();

                if (!saveResult.Succeeded)
                    return ReturnBase<InspectorDto>.Fail(saveResult.Errors);

                var mappedResult = _mapper.Map<InspectorDto>(entity);

                return ReturnBase<InspectorDto>.Success(mappedResult);

            }
            catch (Exception ex)
            {
                return ReturnBase<InspectorDto>.Fail(ex, _exceptionManager);
            }
        }


        public async Task<ReturnBase<InspectorDto>> Delete(long id)
        {
            try
            {
                var entity = await _queriesManager.Inspector.GetById(id);
                if (entity is null)
                {
                    var error = new ReturnBaseError
                    {
                        ErrorCode = "404",
                        ErrorMessage = $"Inspector with Id {id} was not found"
                    };
                    var listOfErrors = new List<ReturnBaseError>() { error };
                    return ReturnBase<InspectorDto>.Fail(listOfErrors);
                }

                var deleteResult = await _commands.DeleteById(id);

                if (!deleteResult.Succeeded)
                    return ReturnBase<InspectorDto>.Fail(deleteResult.Errors);

                var saveResult = await _accountUoW.SaveAsync();

                if (!saveResult.Succeeded)
                    return ReturnBase<InspectorDto>.Fail(saveResult.Errors);

                var mappedResult = _mapper.Map<InspectorDto>(entity);

                return ReturnBase<InspectorDto>.Success(mappedResult);

            }
            catch (Exception ex)
            {
                return ReturnBase<InspectorDto>.Fail(ex, _exceptionManager);
            }
        }

        public async Task<ReturnBase<IEnumerable<InspectorReturnSearchDto>>> Search(SqlQueryOptions sqlQueryOptions)
        {
            try
            {
                var getResult = await _queriesManager.Inspector.Search(sqlQueryOptions);
                if (!getResult.Succeeded)
                    return ReturnBase<IEnumerable<InspectorReturnSearchDto>>.Fail(getResult.Errors);

                return ReturnBase<IEnumerable<InspectorReturnSearchDto>>.Success(getResult.Result);
            }
            catch (Exception ex)
            {
                return ReturnBase<IEnumerable<InspectorReturnSearchDto>>.Fail(ex, _exceptionManager);
            }
        }

        public async Task<ReturnBase<InspectorDto>> GetById(long id)
        {
            try
            {
                var entity = await _queriesManager.Inspector.GetById(id);
                if (entity is null)
                {
                    var error = new ReturnBaseError
                    {
                        ErrorCode = "404",
                        ErrorMessage = $"Inspector with Id {id} was not found"
                    };
                    var listOfErrors = new List<ReturnBaseError>() { error };
                    return ReturnBase<InspectorDto>.Fail(listOfErrors);
                }

                var mappedResult = _mapper.Map<InspectorDto>(entity);

                return ReturnBase<InspectorDto>.Success(mappedResult);
            }
            catch (Exception ex)
            {
                return ReturnBase<InspectorDto>.Fail(ex, _exceptionManager);
            }
        }

        //Import Dynamic Inspectors
        public async Task<ReturnBase<ImportResultDto>> ImportInspectors(ExcelImportRequestDto dto)
        {
            try
            {
                var result = new ImportResultDto();
                var profile = new InspectorImportProfile();

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
                var employeeCache = new Dictionary<string, long>(StringComparer.OrdinalIgnoreCase);
                var userCache = new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase);
                var inspectorCategoryCache = new Dictionary<string, long>(StringComparer.OrdinalIgnoreCase);
                var companyCache = new Dictionary<string, long>(StringComparer.OrdinalIgnoreCase);

                for (int r = firstRow; r <= lastRow; r++)
                {
                    result.ProcessedCount++;

                    var rawRow = new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase);
                    for (int c = 0; c < headers.Count; c++)
                        rawRow[headers[c]] = ws.Cell(r, c + 1).GetString().Trim();

                    var rowErrors = new List<string>();
                    InspectorCreateDto? createDto = null;

                    try
                    {
                        createDto = await profile.MapAsync(rawRow, rowErrors);
                        await profile.ValidateAsync(createDto, rawRow, rowErrors);
                    }
                    catch (Exception ex)
                    {
                        rowErrors.Add(ex.Message);
                    }

                    // ---------- Resolve Employee ----------
                    if (rawRow.TryGetValue("EmployeeCode", out var empCode) &&
                        !string.IsNullOrWhiteSpace(empCode))
                    {
                        if (!employeeCache.TryGetValue(empCode, out var empId))
                        {
                            var emp = await _queriesManager.EmployeeQueryRepository.GetByCode(empCode);
                            if (emp == null)
                                rowErrors.Add($"Employee '{empCode}' not found.");
                            else
                                employeeCache[empCode] = empId = emp.Id;
                        }

                        if (employeeCache.TryGetValue(empCode, out var eid))
                            createDto!.EmployeeId = eid;
                    }

                    // ---------- Resolve User ----------
                    if (rawRow.TryGetValue("User_Code", out var User_Code) &&
                        !string.IsNullOrWhiteSpace(User_Code))
                    {
                        if (!userCache.TryGetValue(User_Code, out var userId))
                        {
                            var user = await _queriesManager.User_CodeQueryRepository.GetByCode(User_Code);
                            if (user == null)
                                rowErrors.Add($"User '{User_Code}' not found.");
                            else
                                userCache[User_Code] = userId = user.User_ID;
                        }

                        if (userCache.TryGetValue(User_Code, out var uid))
                        {
                            if (long.TryParse(uid, out var parsedUserId))
                                createDto!.User_CodeId = parsedUserId;
                            else
                                rowErrors.Add($"UserId '{uid}' is not a valid long value.");
                        }
                    }
                    // ---------- Resolve InspectorCategoryCode  ----------
                    if (rawRow.TryGetValue("InspectorCategoryCode", out var inspectorCategoryCode) &&
                        !string.IsNullOrWhiteSpace(inspectorCategoryCode))
                    {
                        if (!inspectorCategoryCache.TryGetValue(inspectorCategoryCode, out var inspectorCategoryId))
                        {
                            var inspectorCategory = await _queriesManager.InspectorCategory.GetByCode(inspectorCategoryCode);
                            if (inspectorCategory == null)
                                rowErrors.Add($"InspectorCategory '{inspectorCategoryCode}' not found.");
                            else
                                inspectorCategoryCache[inspectorCategoryCode] = inspectorCategoryId = inspectorCategory.Id;
                        }

                        if (inspectorCategoryCache.TryGetValue(inspectorCategoryCode, out var uid))
                            createDto!.InspectorCategoryId = uid;
                    }
                    // ---------- Resolve Company  ----------
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

                        if (companyCache.TryGetValue(companyCode, out var cid))
                            createDto!.CompanyId = cid;
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
                    .GenerateTemplateAsync<InspectorImportTemplateDto>("Inspector");

                var file = new FileResultDto
                {
                    Content = content,
                    FileName = "Inspector.xlsx"
                };

                return ReturnBase<FileResultDto>.Success(file);
            }
            catch (Exception ex)
            {
                return ReturnBase<FileResultDto>.Fail(ex, _exceptionManager);
            }
        }

        public async Task<Inspector> GetByCode(string code)
        {
            return await _queriesManager.Inspector.GetByCode(code);
        }

        private IInspectorCommandRepository _commands
        {
            get { return _accountUoW.Inspector; }
        }


        public async Task<ReturnBase<IEnumerable<InspectorGetListDto>>> GetListAsync()
        {
            try
            {
                var list = await _queriesManager.Inspector.GetListAsync();

                return ReturnBase<IEnumerable<InspectorGetListDto>>
                    .Success(list);
            }
            catch (Exception ex)
            {
                return ReturnBase<IEnumerable<InspectorGetListDto>>
                    .Fail(ex, _exceptionManager);
            }
        }

    }
}