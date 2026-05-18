using AutoMapper;
using Inspection.Application.Contracts.Dto.SharedDtos;
using Inspection.Application.Contracts.Dto.SystemConfigurationDTOs.CityDTOs;
using Inspection.Application.Contracts.Managers;
using Inspection.Application.Contracts.Repositories.Command.SystemConfigurations.Cities;
using Inspection.Application.Contracts.Services.SystemConfigurations.Cities;
using Inspection.Application.Contracts.UnitOfWork;
using Inspection.Application.Services.ServicesBase;
using Inspection.Application.Shared.ExcelTemplate;
using Inspection.Application.Shared.SharedValidation;
using Inspection.Domain.Models.SystemConfigurations.Cities;
using NDS.Shared.Application.DataQuery;
using NDS.Shared.Application.Multitenant;
using NDS.Shared.Kernel.BaseReturnTypes;
using NDS.Shared.Kernel.Exceptions;

namespace Inspection.Application.Services.SystemConfigurations.Cities
{
    public class CityService : AccountsServiceBase, ICityService
    {
        private readonly ITenantResolver _tenantResolver;
        private readonly IExcelTemplateGenerator _templateGenerator;

        public CityService(IAccountUnitOfWork accountUoW, IAccountsQueriesManager queriesManager, IMapper mapper, IExceptionManager exceptionManager, ITenantResolver tenantResolver, IExcelTemplateGenerator templateGenerator) : base(accountUoW, queriesManager, mapper, exceptionManager)
        {
            _tenantResolver = tenantResolver;
            _templateGenerator = templateGenerator;
        }
        public async Task<List<CityDto>> GetAll()
        {

            var list = await _queriesManager.Cities.GetAllAsync();
            return _mapper.Map<List<CityDto>>(list.Result);
        }
        public async Task<ReturnBase<CityDto>> Create(CityCreateDto createDto)
        {
            try
            {
                createDto.Code.ValidateAsCode();
                createDto.Name.ValidateAsName();
                var entity = _mapper.Map<City>(createDto);
                var TenantName = _tenantResolver.GetTenantName();
                entity.Tenant_ID = TenantName;

                var insertResult = await _commands.InsertAsync(entity);
                if (!insertResult.Succeeded)
                {
                    return ReturnBase<CityDto>.Fail(insertResult.Errors);
                }

                var saveResult = await _accountUoW.SaveAsync();
                if (!saveResult.Succeeded)
                {
                    return ReturnBase<CityDto>.Fail(saveResult.Errors);
                }

                var resultDto = _mapper.Map<CityDto>(entity);

                return ReturnBase<CityDto>.Success(resultDto);
            }
            catch (Exception ex)
            {
                return ReturnBase<CityDto>.Fail(ex, _exceptionManager);
            }
        }

        public async Task<ReturnBase<CityDto>> Update(CityUpdateDto updateDto)
        {
            try
            {
                updateDto.Code.ValidateAsCode();
                updateDto.Name.ValidateAsName();
                var entity = await _queriesManager.Cities.GetById(updateDto.Id);
                if (entity is null)
                {
                    var error = new ReturnBaseError
                    {
                        ErrorCode = "404",
                        ErrorMessage = "City Not Found"
                    };
                    var listOfErrors = new List<ReturnBaseError>() { error };
                    return ReturnBase<CityDto>.Fail(listOfErrors);
                }

                entity.Tenant_ID = _tenantResolver.GetTenantName();

                _mapper.Map(updateDto, entity);
                //entity = _mapper.Map<City>(updateDto);
                var updateResult = await _commands.UpdateAsync(entity);

                if (!updateResult.Succeeded)
                    return ReturnBase<CityDto>.Fail(updateResult.Errors);

                var saveResult = await _accountUoW.SaveAsync();

                if (!saveResult.Succeeded)
                    return ReturnBase<CityDto>.Fail(saveResult.Errors);

                var mappedResult = _mapper.Map<CityDto>(entity);

                return ReturnBase<CityDto>.Success(mappedResult);

            }
            catch (Exception ex)
            {
                return ReturnBase<CityDto>.Fail(ex, _exceptionManager);
            }
        }

        public async Task<ReturnBase<CityDto>> Delete(long id)
        {
            try
            {
                var entity = await _queriesManager.Cities.GetById(id);
                if (entity is null)
                {
                    var error = new ReturnBaseError
                    {
                        ErrorCode = "404",
                        ErrorMessage = "City Not Found"
                    };
                    var listOfErrors = new List<ReturnBaseError>() { error };
                    return ReturnBase<CityDto>.Fail(listOfErrors);
                }

                var deleteResult = await _commands.DeleteById(id);

                if (!deleteResult.Succeeded)
                    return ReturnBase<CityDto>.Fail(deleteResult.Errors);

                var saveResult = await _accountUoW.SaveAsync();

                if (!saveResult.Succeeded)
                    return ReturnBase<CityDto>.Fail(saveResult.Errors);

                var mappedResult = _mapper.Map<CityDto>(entity);

                return ReturnBase<CityDto>.Success(mappedResult);

            }
            catch (Exception ex)
            {
                return ReturnBase<CityDto>.Fail(ex, _exceptionManager);
            }
        }

        public async Task<ReturnBase<IEnumerable<CitySearchReturnDto>>> Search(SqlQueryOptions sqlQueryOptions)
        {
            try
            {
                var getResult = await _queriesManager.Cities.Search(sqlQueryOptions);
                if (!getResult.Succeeded)
                    return ReturnBase<IEnumerable<CitySearchReturnDto>>.Fail(getResult.Errors);

                return ReturnBase<IEnumerable<CitySearchReturnDto>>.Success(getResult.Result);
            }
            catch (Exception ex)
            {
                return ReturnBase<IEnumerable<CitySearchReturnDto>>.Fail(ex, _exceptionManager);
            }
        }


        public async Task<ReturnBase<CityDto>> GetById(long id)
        {
            try
            {
                var entity = await _queriesManager.Cities.GetById(id);
                if (entity is null)
                {
                    var error = new ReturnBaseError
                    {
                        ErrorCode = "404",
                        ErrorMessage = "City Not Found"
                    };
                    var listOfErrors = new List<ReturnBaseError>() { error };
                    return ReturnBase<CityDto>.Fail(listOfErrors);
                }

                var mappedResult = _mapper.Map<CityDto>(entity);

                return ReturnBase<CityDto>.Success(mappedResult);
            }
            catch (Exception ex)
            {
                return ReturnBase<CityDto>.Fail(ex, _exceptionManager);
            }
        }
        public async Task<ReturnBase<CityDto>> GetByCode(string code)
        {
            try
            {
                var entity = await _queriesManager.Cities.GetByCode(code);
                if (entity is null)
                {
                    var error = new ReturnBaseError
                    {
                        ErrorCode = "404",
                        ErrorMessage = "City Not Found"
                    };
                    var listOfErrors = new List<ReturnBaseError>() { error };
                    return ReturnBase<CityDto>.Fail(listOfErrors);
                }

                var mappedResult = _mapper.Map<CityDto>(entity);

                return ReturnBase<CityDto>.Success(mappedResult);
            }
            catch (Exception ex)
            {
                return ReturnBase<CityDto>.Fail(ex, _exceptionManager);
            }
        }

        //public async Task<ReturnBase<ImportResultDto>> ImportFromExcel(IFormFile file)
        //{
        //    try
        //    {
        //        var result = new ImportResultDto();
        //        using var stream = file.OpenReadStream();
        //        using var workbook = new XLWorkbook(stream);
        //        var ws = workbook.Worksheets.First(); // choose first sheet

        //        // Determine header row 
        //        var headerRow = 1;
        //        var firstDataRow = headerRow + 1;
        //        var lastRow = ws.LastRowUsed()?.RowNumber() ?? 0;

        //        // Map column names expected
        //        var colIndexByName = new Dictionary<string, int>(StringComparer.OrdinalIgnoreCase);
        //        var lastColumn = ws.Row(headerRow).LastCellUsed().Address.ColumnNumber;
        //        for (int c = 1; c <= lastColumn; c++)
        //        {
        //            var cellVal = ws.Cell(headerRow, c).GetString().Trim();
        //            if (!string.IsNullOrWhiteSpace(cellVal) && !colIndexByName.ContainsKey(cellVal))
        //                colIndexByName[cellVal] = c;
        //        }

        //        for (int r = firstDataRow; r <= lastRow; r++)
        //        {
        //            result.ProcessedCount++;
        //            var rowErrors = new ImportRowErrorDto { RowNumber = r };
        //            var rawRowSnapshot = new List<string>();

        //            try
        //            {
        //                // Helper to read cell by column name
        //                string Read(string name)
        //                {
        //                    if (!colIndexByName.TryGetValue(name, out var ci))
        //                        return string.Empty;
        //                    var val = ws.Cell(r, ci).GetString().Trim();
        //                    rawRowSnapshot.Add($"{name}:{val}");
        //                    return val;
        //                }

        //                var createDto = new CompanyCreateDto
        //                {
        //                    Tenant_ID = Read("Tenant_ID"),
        //                    Code = Read("Code"),
        //                    Name = Read("Name"),
        //                    Address = Read("Address"),
        //                    PhoneNumber = Read("PhoneNumber"),
        //                    Email = Read("Email"),
        //                    Website = string.IsNullOrWhiteSpace(Read("Website")) ? null : Read("Website"),
        //                    Logo = string.IsNullOrWhiteSpace(Read("Logo")) ? null : Read("Logo"),
        //                    IndustrySector = string.IsNullOrWhiteSpace(Read("IndustrySector")) ? null : Read("IndustrySector"),
        //                    LegalRegistrationNumber = Read("LegalRegistrationNumber"),
        //                    TaxIdNumber = Read("TaxIdNumber"),
        //                    CommercialRegisterNumber = Read("CommercialRegisterNumber"),
        //                    IsHolding = ParseBool(Read("IsHolding")),
        //                    IsSubsidiary = ParseBool(Read("IsSubsidiary")),
        //                    IsActive = ParseBool(Read("IsActive"), defaultValue: true),
        //                    // Country/City/Currency will be resolved below from codes read:
        //                    CountryId = 0,
        //                    CityId = 0,
        //                    CurrencyId = 0
        //                };

        //                // Resolve FK codes (user provides codes like "EGP" or "USD" or "CairoCode")
        //                var countryCode = Read("CountryCode");
        //                var cityCode = Read("CityCode");
        //                var currencyCode = Read("CurrencyCode");


        //                //if (!string.IsNullOrWhiteSpace(currencyCode))
        //                //{
        //                //    var currencyId = await ResolveCurrencyIdByCode(currencyCode);
        //                //    if (currencyId == null)
        //                //        rowErrors.Errors.Add($"Currency code '{currencyCode}' not found.");
        //                //    else
        //                //        createDto.CurrencyId = currencyId.Value;
        //                //}
        //                //else
        //                //{
        //                //    // if currency not provided, you may set default currency id (optional)
        //                //    // leave 0 or choose default
        //                //}

        //                //if (!string.IsNullOrWhiteSpace(countryCode))
        //                //{
        //                //    var countryId = await ResolveCountryIdByCode(countryCode);
        //                //    if (countryId == null)
        //                //        rowErrors.Errors.Add($"Country code '{countryCode}' not found.");
        //                //    else
        //                //        createDto.CountryId = countryId.Value;
        //                //}

        //                //if (!string.IsNullOrWhiteSpace(cityCode))
        //                //{
        //                //    var cityId = await ResolveCityIdByCode(cityCode);
        //                //    if (cityId == null)
        //                //        rowErrors.Errors.Add($"City code '{cityCode}' not found.");
        //                //    else
        //                //        createDto.CityId = cityId.Value;
        //                //}


        //                // If any FK resolution error → collect and continue
        //                if (rowErrors.Errors.Count > 0)
        //                {
        //                    rowErrors.RawRowData = string.Join(" | ", rawRowSnapshot);
        //                    result.FailedRows.Add(rowErrors);
        //                    continue;
        //                }

        //                // Now call existing Create method which performs domain validation & persist
        //                var createResult = await Create(createDto); // your existing CompanyService.Create()
        //                if (!createResult.Succeeded)
        //                {
        //                    // collect errors
        //                    rowErrors.RawRowData = string.Join(" | ", rawRowSnapshot);

        //                    // flatten errors into strings
        //                    foreach (var err in createResult.Errors)
        //                        rowErrors.Errors.Add($"{err.ErrorCode}: {err.ErrorMessage}");

        //                    result.FailedRows.Add(rowErrors);
        //                    continue; // continue to next row
        //                }

        //                result.CreatedCount++;
        //            }
        //            catch (Exception exRow)
        //            {
        //                // Unexpected row-level exception: collect then continue
        //                rowErrors.RawRowData ??= "";
        //                rowErrors.RawRowData += $" (unexpected error row processing)";
        //                rowErrors.Errors.Add(exRow.Message);
        //                result.FailedRows.Add(rowErrors);
        //                continue;
        //            }
        //        }

        //        return ReturnBase<ImportResultDto>.Success(result);
        //    }
        //    catch (Exception ex)
        //    {
        //        return ReturnBase<ImportResultDto>.Fail(ex, _exceptionManager);
        //    }
        //}

        //// helper local method
        //private static bool ParseBool(string s, bool defaultValue = false)
        //{
        //    if (string.IsNullOrWhiteSpace(s))
        //        return defaultValue;

        //    if (bool.TryParse(s, out var b)) return b;

        //    // accept 1/0, yes/no, Y/N
        //    s = s.Trim().ToLowerInvariant();
        //    if (s == "1" || s == "yes" || s == "y" || s == "true" || s == "t") return true;
        //    if (s == "0" || s == "no" || s == "n" || s == "false" || s == "f") return false;
        //    return defaultValue;
        //}



        //Import Dynamic Companies

        //public async Task<ReturnBase<ImportResultDto>> ImportCompanies(ExcelImportRequestDto dto)
        //{
        //    try
        //    {
        //        var finalResult = new ImportResultDto();

        //        // 1) Create import profile
        //        var profile = new CompanyImportProfile(dto.ColumnOrder);

        //        // 2) Open Excel
        //        using var stream = dto.File.OpenReadStream();
        //        using var workbook = new XLWorkbook(stream);
        //        var ws = workbook.Worksheets.First();

        //        var headerRow = ws.FirstRowUsed()?.RowNumber() ?? 1;
        //        var firstDataRow = headerRow + 1;
        //        var lastRow = ws.LastRowUsed()?.RowNumber() ?? 0;
        //        int colCount = dto.ColumnOrder.Count;

        //        // FK caches
        //        var currencyCache = new Dictionary<string, long>(System.StringComparer.OrdinalIgnoreCase);
        //        var countryCache = new Dictionary<string, long>(System.StringComparer.OrdinalIgnoreCase);
        //        var cityCache = new Dictionary<string, long>(System.StringComparer.OrdinalIgnoreCase);

        //        // 3) Process each row
        //        for (int r = firstDataRow; r <= lastRow; r++)
        //        {
        //            finalResult.ProcessedCount++;
        //            var rawRow = new Dictionary<string, string>(System.StringComparer.OrdinalIgnoreCase);
        //            for (int c = 0; c < colCount; c++)
        //            {
        //                rawRow[dto.ColumnOrder[c]] = ws.Cell(r, c + 1).GetString().Trim();
        //            }

        //            var rowErrors = new List<string>();

        //            // Map & Validate
        //            CompanyCreateDto createDto;
        //            try
        //            {
        //                createDto = await profile.MapAsync(rawRow, rowErrors);
        //                await profile.ValidateAsync(createDto, rawRow, rowErrors);
        //            }
        //            catch (System.Exception ex)
        //            {
        //                rowErrors.Add($"Mapping/Validation error: {ex.Message}");
        //                finalResult.FailedRows.Add(new ImportRowErrorDto
        //                {
        //                    RowNumber = r,
        //                    RawRowData = string.Join(" | ", rawRow.Select(kv => $"{kv.Key}:{kv.Value}")),
        //                    Errors = rowErrors
        //                });
        //                continue;
        //            }

        //            //// Resolve FK: Currency
        //            //if (rawRow.TryGetValue("CurrencyCode", out var currencyCode) && !string.IsNullOrWhiteSpace(currencyCode))
        //            //{
        //            //    if (!currencyCache.TryGetValue(currencyCode, out var id))
        //            //    {
        //            //        var curr = await _queriesManager.Currencies.GetByCode(currencyCode.Trim());
        //            //        if (curr == null) rowErrors.Add($"Currency '{currencyCode}' not found.");
        //            //        else
        //            //        {
        //            //            id = curr.Id;
        //            //            currencyCache[currencyCode] = id;
        //            //        }
        //            //    }
        //            //    if (currencyCache.TryGetValue(currencyCode, out var currencyId)) createDto.CurrencyId = currencyId;
        //            //}

        //            //// Resolve FK: Country
        //            //if (rawRow.TryGetValue("CountryCode", out var countryCode) && !string.IsNullOrWhiteSpace(countryCode))
        //            //{
        //            //    if (!countryCache.TryGetValue(countryCode, out var id))
        //            //    {
        //            //        var c = await _queriesManager.Countries.GetByCode(countryCode.Trim());
        //            //        if (c == null) rowErrors.Add($"Country '{countryCode}' not found.");
        //            //        else
        //            //        {
        //            //            id = c.Id;
        //            //            countryCache[countryCode] = id;
        //            //        }
        //            //    }
        //            //    if (countryCache.TryGetValue(countryCode, out var countryId)) createDto.CountryId = countryId;
        //            //}

        //            //// Resolve FK: City
        //            //if (rawRow.TryGetValue("CityCode", out var cityCode) && !string.IsNullOrWhiteSpace(cityCode))
        //            //{
        //            //    if (!cityCache.TryGetValue(cityCode, out var id))
        //            //    {
        //            //        var ci = await _queriesManager.Cities.GetByCode(cityCode.Trim());
        //            //        if (ci == null) rowErrors.Add($"City '{cityCode}' not found.");
        //            //        else
        //            //        {
        //            //            id = ci.Id;
        //            //            cityCache[cityCode] = id;
        //            //        }
        //            //    }
        //            //    if (cityCache.TryGetValue(cityCode, out var cityId)) createDto.CityId = cityId;
        //            //}

        //            if (rowErrors.Any())
        //            {
        //                finalResult.FailedRows.Add(new ImportRowErrorDto
        //                {
        //                    RowNumber = r,
        //                    RawRowData = string.Join(" | ", rawRow.Select(kv => $"{kv.Key}:{kv.Value}")),
        //                    Errors = rowErrors
        //                });
        //                continue;
        //            }

        //            // Call existing Create method
        //            var createResult = await Create(createDto);
        //            if (!createResult.Succeeded)
        //            {
        //                var errs = createResult.Errors.Select(e => $"{e.ErrorCode}: {e.ErrorMessage}").ToList();
        //                finalResult.FailedRows.Add(new ImportRowErrorDto
        //                {
        //                    RowNumber = r,
        //                    RawRowData = string.Join(" | ", rawRow.Select(kv => $"{kv.Key}:{kv.Value}")),
        //                    Errors = errs
        //                });
        //                continue;
        //            }

        //            finalResult.CreatedCount++;
        //        }

        //        return ReturnBase<ImportResultDto>.Success(finalResult);
        //    }
        //    catch (System.Exception ex)
        //    {
        //        return ReturnBase<ImportResultDto>.Fail(ex, _exceptionManager);
        //    }
        //}

        public async Task<ReturnBase<FileResultDto>> DownloadTemplate()
        {
            try
            {
                var content = await _templateGenerator
                    .GenerateTemplateAsync<CityImportTemplateDto>("City");

                var file = new FileResultDto
                {
                    Content = content,
                    FileName = "City.xlsx"
                };

                return ReturnBase<FileResultDto>.Success(file);
            }
            catch (Exception ex)
            {
                return ReturnBase<FileResultDto>.Fail(ex, _exceptionManager);
            }
        }

        //private ICompanyQueryRepository _queries
        //{
        //    get { return _accountUoW.Company; }
        //}
        private ICityCommandRepository _commands
        {
            get { return _accountUoW.City; }
        }
    }
}