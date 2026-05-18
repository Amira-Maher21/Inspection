using AutoMapper;
using ClosedXML.Excel;
using Inspection.Application.Contracts.Dto.SharedDtos;
using Inspection.Application.Contracts.Dto.SystemConfigurationDTOs.CompanyDTOs;
using Inspection.Application.Contracts.Managers;
using Inspection.Application.Contracts.Repositories.Command.SystemConfigurations.Companies;
using Inspection.Application.Contracts.Services.SystemConfigurations.Companies;
using Inspection.Application.Contracts.UnitOfWork;
using Inspection.Application.Services.ServicesBase;
using Inspection.Application.Shared.ExcelTemplate;
using Inspection.Application.Shared.SharedValidaion;
using Inspection.Application.Shared.SharedValidation;
using Inspection.Domain.Models.SystemConfigurations.Companies;
using Microsoft.AspNetCore.Http;
using NDS.Shared.Application.DataQuery;
using NDS.Shared.Application.Multitenant;
using NDS.Shared.Kernel.BaseReturnTypes;
using NDS.Shared.Kernel.Exceptions;

namespace Inspection.Application.Services.SystemConfigurations.Companies
{
    public class CompanyService : AccountsServiceBase, ICompanyService
    {
        private readonly ITenantResolver _tenantResolver;
        private readonly IExcelTemplateGenerator _templateGenerator;

        public CompanyService(IAccountUnitOfWork accountUoW, IAccountsQueriesManager queriesManager, IMapper mapper, IExceptionManager exceptionManager, ITenantResolver tenantResolver, IExcelTemplateGenerator templateGenerator) : base(accountUoW, queriesManager, mapper, exceptionManager)
        {
            _tenantResolver = tenantResolver;
            _templateGenerator = templateGenerator;
        }
        public async Task<List<CompanyDto>> GetAll()
        {

            var list = await _queriesManager.Companies.GetAllAsync();
            return _mapper.Map<List<CompanyDto>>(list.Result);
        }
        public async Task<ReturnBase<CompanyDto>> Create(CompanyCreateDto createDto)
        {
            try
            {
                if (!string.IsNullOrWhiteSpace(createDto.Email))
                {
                    EmailValidator.Validate(createDto.Email);
                }

                createDto.Code.ValidateAsCode();
                createDto.Name.ValidateAsName();
                var entity = _mapper.Map<Company>(createDto);

                // Validate CountryId & CityId
                var fkValidation = await ValidateCountryAndCity(createDto.CountryId, createDto.CityId);
                if (fkValidation != null)
                    return fkValidation;

                var TenantName = _tenantResolver.GetTenantName();
                entity.Tenant_ID = TenantName;

                var insertResult = await _commands.InsertAsync(entity);
                if (!insertResult.Succeeded)
                {
                    return ReturnBase<CompanyDto>.Fail(insertResult.Errors);
                }

                var saveResult = await _accountUoW.SaveAsync();
                if (!saveResult.Succeeded)
                {
                    return ReturnBase<CompanyDto>.Fail(saveResult.Errors);
                }

                var resultDto = _mapper.Map<CompanyDto>(entity);

                return ReturnBase<CompanyDto>.Success(resultDto);
            }
            catch (Exception ex)
            {
                return ReturnBase<CompanyDto>.Fail(ex, _exceptionManager);
            }
        }

        public async Task<ReturnBase<CompanyDto>> Update(CompanyUpdateDto updateDto)
        {
            try
            {
                if (!string.IsNullOrWhiteSpace(updateDto.Email))
                {
                    EmailValidator.Validate(updateDto.Email);
                }
                updateDto.Code.ValidateAsCode();
                updateDto.Name.ValidateAsName();

                var entity = await _queriesManager.Companies.GetById(updateDto.Id);
                if (entity is null)
                {
                    var error = new ReturnBaseError
                    {
                        ErrorCode = "404",
                        ErrorMessage = "Company Not Found"
                    };
                    var listOfErrors = new List<ReturnBaseError>() { error };
                    return ReturnBase<CompanyDto>.Fail(listOfErrors);
                }

                updateDto.Code.ValidateAsCode();
                updateDto.Name.ValidateAsName();

                // Validate CountryId & CityId
                var fkValidation = await ValidateCountryAndCity(updateDto.CountryId, updateDto.CityId);
                if (fkValidation != null)
                    return fkValidation;

                entity.Tenant_ID = _tenantResolver.GetTenantName();

                _mapper.Map(updateDto, entity);
                //entity = _mapper.Map<Company>(updateDto);
                var updateResult = await _commands.UpdateAsync(entity);

                if (!updateResult.Succeeded)
                    return ReturnBase<CompanyDto>.Fail(updateResult.Errors);

                var saveResult = await _accountUoW.SaveAsync();

                if (!saveResult.Succeeded)
                    return ReturnBase<CompanyDto>.Fail(saveResult.Errors);

                var mappedResult = _mapper.Map<CompanyDto>(entity);

                return ReturnBase<CompanyDto>.Success(mappedResult);

            }
            catch (Exception ex)
            {
                return ReturnBase<CompanyDto>.Fail(ex, _exceptionManager);
            }
        }



        private async Task<ReturnBase<CompanyDto>?> ValidateCountryAndCity(long? countryId, long? cityId)
        {
            var errors = new List<ReturnBaseError>();

            // 1️⃣ Validate Country
            if (countryId.HasValue)
            {
                var countryExists = await _queriesManager.Counteris.ExistsAsync(countryId.Value);
                if (!countryExists)
                {
                    errors.Add(new ReturnBaseError
                    {
                        ErrorCode = "400",
                        ErrorMessage = $"Country with Id {countryId.Value} does not exist."
                    });
                }
            }

            // 2️⃣ Validate City + Relation
            if (cityId.HasValue)
            {
                var city = await _queriesManager.Cities.GetById(cityId.Value);

                if (city == null)
                {
                    errors.Add(new ReturnBaseError
                    {
                        ErrorCode = "400",
                        ErrorMessage = $"City with Id {cityId.Value} does not exist."
                    });
                }
                else if (countryId.HasValue && city.CountryId != countryId.Value)
                {
                    errors.Add(new ReturnBaseError
                    {
                        ErrorCode = "400",
                        ErrorMessage = $"City '{city.Name}' does not belong to CountryId {countryId.Value}."
                    });
                }
            }

            if (errors.Any())
                return ReturnBase<CompanyDto>.Fail(errors);

            return null;
        }




        public async Task<ReturnBase<CompanyDto>> Delete(long id)
        {
            try
            {
                var entity = await _queriesManager.Companies.GetById(id);
                if (entity is null)
                {
                    var error = new ReturnBaseError
                    {
                        ErrorCode = "404",
                        ErrorMessage = "Company Not Found"
                    };
                    var listOfErrors = new List<ReturnBaseError>() { error };
                    return ReturnBase<CompanyDto>.Fail(listOfErrors);
                }



                var deleteResult = await _commands.DeleteById(id);

                if (!deleteResult.Succeeded)
                    return ReturnBase<CompanyDto>.Fail(deleteResult.Errors);

                var saveResult = await _accountUoW.SaveAsync();

                if (!saveResult.Succeeded)
                    return ReturnBase<CompanyDto>.Fail(saveResult.Errors);

                var mappedResult = _mapper.Map<CompanyDto>(entity);

                return ReturnBase<CompanyDto>.Success(mappedResult);

            }
            catch (Exception ex)
            {
                return ReturnBase<CompanyDto>.Fail(ex, _exceptionManager);
            }
        }

        public async Task<ReturnBase<IEnumerable<CompanyReturnSearchDto>>> Search(SqlQueryOptions sqlQueryOptions)
        {
            try
            {
                var getResult = await _queriesManager.Companies.Search(sqlQueryOptions);
                if (!getResult.Succeeded)
                    return ReturnBase<IEnumerable<CompanyReturnSearchDto>>.Fail(getResult.Errors);

                return ReturnBase<IEnumerable<CompanyReturnSearchDto>>.Success(getResult.Result);
            }
            catch (Exception ex)
            {
                return ReturnBase<IEnumerable<CompanyReturnSearchDto>>.Fail(ex, _exceptionManager);
            }
        }


        public async Task<ReturnBase<CompanyDto>> GetById(long id)
        {
            try
            {
                var entity = await _queriesManager.Companies.GetById(id);
                if (entity is null)
                {
                    var error = new ReturnBaseError
                    {
                        ErrorCode = "404",
                        ErrorMessage = "Company Not Found"
                    };
                    var listOfErrors = new List<ReturnBaseError>() { error };
                    return ReturnBase<CompanyDto>.Fail(listOfErrors);
                }

                var mappedResult = _mapper.Map<CompanyDto>(entity);

                return ReturnBase<CompanyDto>.Success(mappedResult);
            }
            catch (Exception ex)
            {
                return ReturnBase<CompanyDto>.Fail(ex, _exceptionManager);
            }
        }
        public async Task<Company> GetByCode(string code)
        {

            var entity = await _queriesManager.Companies.GetByCode(code);
            return entity;

        }

        public async Task<ReturnBase<IEnumerable<CompanyIdNameDto>>> GetIdAndName(SqlQueryOptions queryOptions)
        {
            var result = await this._queriesManager.Companies.GetCompanyIdAndName(queryOptions);

            var mappedResult = _mapper.Map<IEnumerable<CompanyIdNameDto>>(result.Result);

            return ReturnBase<IEnumerable<CompanyIdNameDto>>.Success(mappedResult);
        }
        public async Task<ReturnBase<ImportResultDto>> ImportFromExcel(IFormFile file)
        {
            try
            {
                var result = new ImportResultDto();
                using var stream = file.OpenReadStream();
                using var workbook = new XLWorkbook(stream);
                var ws = workbook.Worksheets.First(); // choose first sheet

                // Determine header row 
                var headerRow = 1;
                var firstDataRow = headerRow + 1;
                var lastRow = ws.LastRowUsed()?.RowNumber() ?? 0;

                // Map column names expected
                var colIndexByName = new Dictionary<string, int>(StringComparer.OrdinalIgnoreCase);
                var lastColumn = ws.Row(headerRow).LastCellUsed().Address.ColumnNumber;
                for (int c = 1; c <= lastColumn; c++)
                {
                    var cellVal = ws.Cell(headerRow, c).GetString().Trim();
                    if (!string.IsNullOrWhiteSpace(cellVal) && !colIndexByName.ContainsKey(cellVal))
                        colIndexByName[cellVal] = c;
                }

                // Useful column names expected in Excel (adapt to your template)
                // e.g.: "Tenant_ID", "Code", "Name", "Address", "PhoneNumber", "Email",
                // "Website", "Logo", "IndustrySector",
                // "LegalRegistrationNumber","TaxIdNumber","CommercialRegisterNumber",
                // "IsHolding","IsSubsidiary","IsActive",
                // "CountryCode","CityCode","CurrencyCode"
                // NOTE: For FK columns we expect "CountryCode", "CityCode", "CurrencyCode"
                // (user provides codes; service converts to Ids).

                for (int r = firstDataRow; r <= lastRow; r++)
                {
                    result.ProcessedCount++;
                    var rowErrors = new ImportRowErrorDto { RowNumber = r };
                    var rawRowSnapshot = new List<string>();

                    try
                    {
                        // Helper to read cell by column name
                        string Read(string name)
                        {
                            if (!colIndexByName.TryGetValue(name, out var ci))
                                return string.Empty;
                            var val = ws.Cell(r, ci).GetString().Trim();
                            rawRowSnapshot.Add($"{name}:{val}");
                            return val;
                        }


                        var createDto = new CompanyCreateDto
                        {
                            //Tenant_ID = Read("Tenant_ID"),
                            Code = Read("Code"),
                            Name = Read("Name"),
                            Address = Read("Address"),
                            PhoneNumber = Read("PhoneNumber"),
                            Email = Read("Email"),
                            Website = string.IsNullOrWhiteSpace(Read("Website")) ? null : Read("Website"),
                            IndustrySector = string.IsNullOrWhiteSpace(Read("IndustrySector")) ? null : Read("IndustrySector"),
                            BuildingNumber = string.IsNullOrWhiteSpace(Read("BuildingNumber")) ? null : Read("BuildingNumber"),
                            Street = string.IsNullOrWhiteSpace(Read("Street")) ? null : Read("Street"),
                            Zone = string.IsNullOrWhiteSpace(Read("Zone")) ? null : Read("Zone"),
                            TaxIdNumber = Read("TaxIdNumber"),
                            CommercialRegisterNumber = Read("CommercialRegisterNumber"),


                            BaseCurrencyId = 0,
                            OfficialCurrencyId = 0,
                            ReportingCurrencyId = 0,


                            CountryId = 0,
                            CityId = 0,


                            DefaultTaxTypeId = 0,
                            DefaultTaxType2Id = 0,


                            InventoryAccountId = 0,
                            CogsAccountId = 0,
                            AdjustmentAccountId = 0,
                            RevenueAccountId = 0,
                            PurchaseAccountId = 0,
                            PurchaseReturnAccountId = 0,
                            SalesReturnAccountId = 0,
                            GoodsReceivedNotInvoicedAccountId = 0,
                            WipAccountId = 0,

                            // 🔴 Costing Method
                            CostingMethodEnum = null,

                            // 🔴 Flags
                            ActiveCostCenter = ParseBool(Read("ActiveCostCenter")),
                            ActiveCostUnit = ParseBool(Read("ActiveCostUnit")),
                            ActiveOperation = ParseBool(Read("ActiveOperation")),
                            ActiveWBS = ParseBool(Read("ActiveWBS")),
                            ActiveCostCode = ParseBool(Read("ActiveCostCode")),
                            ActiveActivity = ParseBool(Read("ActiveActivity")),
                            ActiveBOQItem = ParseBool(Read("ActiveBOQItem")),
                            ActiveSubcontractBOQ = ParseBool(Read("ActiveSubcontractBOQ")),
                            ActiveProductionOrder = ParseBool(Read("ActiveProductionOrder"))



                            // Country/City/Currency will be resolved below from codes read:
                            //CountryId = 0,
                            //CityId = 0,
                            //BaseCurrencyId = 0,
                            //OfficialCurrencyId = 0,

                        };

                        // Resolve FK codes (user provides codes like "EGP" or "USD" or "CairoCode")
                        var countryCode = Read("CountryCode");
                        var cityCode = Read("CityCode");
                        var currencyCode = Read("CurrencyCode");


                        //if (!string.IsNullOrWhiteSpace(currencyCode))
                        //{
                        //    var currencyId = await ResolveCurrencyIdByCode(currencyCode);
                        //    if (currencyId == null)
                        //        rowErrors.Errors.Add($"Currency code '{currencyCode}' not found.");
                        //    else
                        //        createDto.CurrencyId = currencyId.Value;
                        //}
                        //else
                        //{
                        //    // if currency not provided, you may set default currency id (optional)
                        //    // leave 0 or choose default
                        //}

                        //if (!string.IsNullOrWhiteSpace(countryCode))
                        //{
                        //    var countryId = await ResolveCountryIdByCode(countryCode);
                        //    if (countryId == null)
                        //        rowErrors.Errors.Add($"Country code '{countryCode}' not found.");
                        //    else
                        //        createDto.CountryId = countryId.Value;
                        //}

                        //if (!string.IsNullOrWhiteSpace(cityCode))
                        //{
                        //    var cityId = await ResolveCityIdByCode(cityCode);
                        //    if (cityId == null)
                        //        rowErrors.Errors.Add($"City code '{cityCode}' not found.");
                        //    else
                        //        createDto.CityId = cityId.Value;
                        //}


                        // If any FK resolution error → collect and continue
                        if (rowErrors.Errors.Count > 0)
                        {
                            rowErrors.RawRowData = string.Join(" | ", rawRowSnapshot);
                            result.FailedRows.Add(rowErrors);
                            continue;
                        }

                        // Now call existing Create method which performs domain validation & persist
                        var createResult = await Create(createDto); // your existing CompanyService.Create()
                        if (!createResult.Succeeded)
                        {
                            // collect errors
                            rowErrors.RawRowData = string.Join(" | ", rawRowSnapshot);

                            // flatten errors into strings
                            foreach (var err in createResult.Errors)
                                rowErrors.Errors.Add($"{err.ErrorCode}: {err.ErrorMessage}");

                            result.FailedRows.Add(rowErrors);
                            continue; // continue to next row
                        }

                        result.CreatedCount++;
                    }
                    catch (Exception exRow)
                    {
                        // Unexpected row-level exception: collect then continue
                        rowErrors.RawRowData ??= "";
                        rowErrors.RawRowData += $" (unexpected error row processing)";
                        rowErrors.Errors.Add(exRow.Message);
                        result.FailedRows.Add(rowErrors);
                        continue;
                    }
                }

                return ReturnBase<ImportResultDto>.Success(result);
            }
            catch (Exception ex)
            {
                return ReturnBase<ImportResultDto>.Fail(ex, _exceptionManager);
            }
        }

        // helper local method
        private static bool ParseBool(string s, bool defaultValue = false)
        {
            if (string.IsNullOrWhiteSpace(s))
                return defaultValue;

            if (bool.TryParse(s, out var b)) return b;

            // accept 1/0, yes/no, Y/N
            s = s.Trim().ToLowerInvariant();
            if (s == "1" || s == "yes" || s == "y" || s == "true" || s == "t") return true;
            if (s == "0" || s == "no" || s == "n" || s == "false" || s == "f") return false;
            return defaultValue;
        }

        //Import Dynamic Companies
        public async Task<ReturnBase<ImportResultDto>> ImportCompanies(ExcelImportRequestDto dto)
        {
            try
            {
                var finalResult = new ImportResultDto();

                var profile = new CompanyImportProfile();

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

                var currencyCache = new Dictionary<string, long>(StringComparer.OrdinalIgnoreCase);
                var countryCache = new Dictionary<string, long>(StringComparer.OrdinalIgnoreCase);
                var cityCache = new Dictionary<string, long>(StringComparer.OrdinalIgnoreCase);

                for (int r = firstDataRow; r <= lastRow; r++)
                {
                    finalResult.ProcessedCount++;

                    var rawRow = new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase);
                    for (int c = 0; c < headers.Count; c++)
                    {
                        rawRow[headers[c]] = ws.Cell(r, c + 1).GetString().Trim();
                    }

                    var rowErrors = new List<string>();
                    CompanyCreateDto? createDto = null;

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
                            Errors = rowErrors.Any()
                                ? rowErrors
                                : new List<string> { "Row mapping failed." }
                        });
                        continue;
                    }

                    // ---------- Currency ----------
                    if (rawRow.TryGetValue("CurrencyCode", out var currencyCode) &&
                        !string.IsNullOrWhiteSpace(currencyCode))
                    {
                        if (!currencyCache.TryGetValue(currencyCode, out var id))
                        {
                            var curr = await _queriesManager.Currencies.GetByCode(currencyCode);
                            if (curr == null)
                                rowErrors.Add($"Currency '{currencyCode}' not found.");
                            else
                                currencyCache[currencyCode] = id = curr.Id;
                        }

                        if (currencyCache.TryGetValue(currencyCode, out var cid))
                            createDto.BaseCurrencyId = cid;
                    }

                    // ---------- Country ----------
                    if (rawRow.TryGetValue("CountryCode", out var countryCode) &&
                        !string.IsNullOrWhiteSpace(countryCode))
                    {
                        if (!countryCache.TryGetValue(countryCode, out var id))
                        {
                            var country = await _queriesManager.Counteris.GetByCode(countryCode);
                            if (country == null)
                                rowErrors.Add($"Country '{countryCode}' not found.");
                            else
                                countryCache[countryCode] = id = country.Id;
                        }

                        if (countryCache.TryGetValue(countryCode, out var cid))
                            createDto.CountryId = cid;
                    }

                    // ---------- City ----------
                    if (rawRow.TryGetValue("CityCode", out var cityCode) &&
                        !string.IsNullOrWhiteSpace(cityCode))
                    {
                        if (!cityCache.TryGetValue(cityCode, out var id))
                        {
                            var city = await _queriesManager.Cities.GetByCode(cityCode);
                            if (city == null)
                                rowErrors.Add($"City '{cityCode}' not found.");
                            else
                                cityCache[cityCode] = id = city.Id;
                        }

                        if (cityCache.TryGetValue(cityCode, out var cid))
                            createDto.CityId = cid;
                    }

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
                    .GenerateTemplateAsync<CompanyImportTemplateDto>("Company");

                var file = new FileResultDto
                {
                    Content = content,
                    FileName = "Company.xlsx"
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
        private ICompanyCommandRepository _commands
        {
            get { return _accountUoW.Company; }
        }
    }
}