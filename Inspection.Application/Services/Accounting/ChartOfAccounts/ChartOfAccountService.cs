using AutoMapper;
using ClosedXML.Excel;
using Inspection.Application.Contracts.Dto.AccountingDtos.ChartOfAccounts.ChartOfAccountDTOs;
using Inspection.Application.Contracts.Dto.SharedDtos;
using Inspection.Application.Contracts.Managers;
using Inspection.Application.Contracts.Repositories.Command.Accounting.ChartOfAccounts;
using Inspection.Application.Contracts.Services.Accounting.ChartOfAccounts;
using Inspection.Application.Contracts.UnitOfWork;
using Inspection.Application.Services.ServicesBase;
using Inspection.Application.Shared.ExcelTemplate;
using Inspection.Domain.Models.Accounting.ChartOfAccounts;
using NDS.Shared.Application.DataQuery;
using NDS.Shared.Application.Multitenant;
using NDS.Shared.Kernel.BaseReturnTypes;
using NDS.Shared.Kernel.Exceptions;

namespace Inspection.Application.Services.Accounting.ChartOfAccounts
{
    public class ChartOfAccountService : AccountsServiceBase, IChartOfAccountService
    {
        private readonly ITenantResolver _tenantResolver;
        private readonly IExcelTemplateGenerator _templateGenerator;

        public ChartOfAccountService(IAccountUnitOfWork accountUoW, IAccountsQueriesManager queriesManager, IMapper mapper, IExceptionManager exceptionManager, ITenantResolver tenantResolver, IExcelTemplateGenerator templateGenerator) : base(accountUoW, queriesManager, mapper, exceptionManager)
        {
            _tenantResolver = tenantResolver;
            _templateGenerator = templateGenerator;
        }
        public async Task<ReturnBase<List<ChartOfAccountDto>>> GetAll()
        {

            try
            {
                var result = await _queriesManager.ChartOfAccounts.GetAll();

                if (!result.Succeeded)
                {
                    return ReturnBase<List<ChartOfAccountDto>>.Fail(result.Errors);
                }

                var mapped = _mapper.Map<List<ChartOfAccountDto>>(result.Result);

                return ReturnBase<List<ChartOfAccountDto>>.Success(mapped);
            }
            catch (Exception ex)
            {
                return ReturnBase<List<ChartOfAccountDto>>.Fail(ex, _exceptionManager);
            }
        }
        public async Task<ReturnBase<ChartOfAccountDto>> Create(ChartOfAccountCreateDto createDto)
        {
            try
            {

                // 🔹 Business rules
                var ruleError = await ValidateChartOfAccountRules(createDto);
                if (ruleError != null)
                    return ReturnBase<ChartOfAccountDto>.Fail(new List<ReturnBaseError> { ruleError });

                var entity = _mapper.Map<ChartOfAccount>(createDto);

                entity.Tenant_ID = _tenantResolver.GetTenantName();

                // 🔹 Dynamic Level
                entity.SetLevel(await CalculateLevel(createDto.ParentAccountId));

                var insertResult = await _commands.InsertAsync(entity);
                if (!insertResult.Succeeded)
                    return ReturnBase<ChartOfAccountDto>.Fail(insertResult.Errors);

                var saveResult = await _accountUoW.SaveAsync();
                if (!saveResult.Succeeded)
                    return ReturnBase<ChartOfAccountDto>.Fail(saveResult.Errors);

                return ReturnBase<ChartOfAccountDto>.Success(
                    _mapper.Map<ChartOfAccountDto>(entity));
            }
            catch (Exception ex)
            {
                return ReturnBase<ChartOfAccountDto>.Fail(ex, _exceptionManager);
            }
        }

        public async Task<ReturnBase<ChartOfAccountDto>> Update(
            ChartOfAccountUpdateDto updateDto
            )
        {
            try
            {
                // 1️ Get existing entity
                var entity = await _queriesManager.ChartOfAccounts.GetById(updateDto.Id);
                if (entity == null)
                {
                    return ReturnBase<ChartOfAccountDto>.Fail(new List<ReturnBaseError>
            {
                new ReturnBaseError
                {
                    ErrorCode = "404",
                    ErrorMessage = "Chart Of Account Not Found"
                }
            });
                }


                entity.Tenant_ID = _tenantResolver.GetTenantName();


                // 2️ Validate business rules (UPDATE scenario)
                var ruleError = await ValidateChartOfAccountRulesForUpdate(updateDto, entity);
                if (ruleError != null)
                {
                    return ReturnBase<ChartOfAccountDto>.Fail(
                        new List<ReturnBaseError> { ruleError });
                }

                // 3️ Recalculate Level ONLY if parent changed
                if (entity.ParentAccountId != updateDto.ParentAccountId)
                {
                    var newLevel = await CalculateLevel(updateDto.ParentAccountId);
                    entity.SetLevel(newLevel);
                }

                // 4️ Map allowed fields (AFTER validation)
                _mapper.Map(updateDto, entity);

                // 5️ Persist changes
                var updateResult = await _commands.UpdateAsync(entity);
                if (!updateResult.Succeeded)
                    return ReturnBase<ChartOfAccountDto>.Fail(updateResult.Errors);

                var saveResult = await _accountUoW.SaveAsync();
                if (!saveResult.Succeeded)
                    return ReturnBase<ChartOfAccountDto>.Fail(saveResult.Errors);

                // 6️ Return result
                var resultDto = _mapper.Map<ChartOfAccountDto>(entity);
                return ReturnBase<ChartOfAccountDto>.Success(resultDto);
            }
            catch (Exception ex)
            {
                return ReturnBase<ChartOfAccountDto>.Fail(ex, _exceptionManager);
            }
        }

        // method for update validation
        private async Task<ReturnBaseError?> ValidateChartOfAccountRulesForUpdate(
            ChartOfAccountUpdateDto dto,
            ChartOfAccount existingEntity)
        {
            // ---------------- Level & Parent rules ----------------

            if (!dto.IsMain && dto.ParentAccountId == null)
            {
                return new ReturnBaseError
                {
                    ErrorCode = "BUSINESS_RULE",
                    ErrorMessage = "Parent account is required when IsMain is false."
                };
            }

            if (dto.IsMain && dto.ParentAccountId != null)
            {
                return new ReturnBaseError
                {
                    ErrorCode = "BUSINESS_RULE",
                    ErrorMessage = "Main account cannot have a parent."
                };
            }

            // ---------------- Cost Center rule ----------------

            if (dto.IsCostCenterRequired && dto.CostCenterId == null)
            {
                return new ReturnBaseError
                {
                    ErrorCode = "BUSINESS_RULE",
                    ErrorMessage = "Cost Center is required when IsCostCenterRequired is true."
                };
            }

            // ---------------- Cost Unit rule ----------------

            if (dto.IsCostUnitRequired && dto.CostUnitId == null)
            {
                return new ReturnBaseError
                {
                    ErrorCode = "BUSINESS_RULE",
                    ErrorMessage = "Cost Unit is required when IsCostUnitRequired is true."
                };
            }

            // ---------------- UPDATE-ONLY rules ----------------
            // Prevent changing AccountTypeCode if used as parent
            if (existingEntity.AccountTypeCode != dto.AccountTypeCode)
            {
                var hasChildren = await _commands.HasChildren(existingEntity.Id);
                if (hasChildren)
                {
                    return new ReturnBaseError
                    {
                        ErrorCode = "BUSINESS_RULE",
                        ErrorMessage =
                            "Cannot change Account Type because this account is used as a parent by other accounts."
                    };
                }
            }

            // Prevent IsMain: true → false if it has children
            if (existingEntity.IsMain && !dto.IsMain)
            {
                var child = await _commands.GetFirstChild(existingEntity.Id);
                if (child != null)
                {
                    return new ReturnBaseError
                    {
                        ErrorCode = "BUSINESS_RULE",
                        ErrorMessage =
                            $"Cannot change IsMain to false. " +
                            $"This account is used as a parent by " +
                            $"Account (Code: {child.AccountCode}, Name: {child.AccountName})."
                    };
                }
            }

            return null;
        }


        public async Task<ReturnBase<ChartOfAccountDto>> Delete(long id)
        {
            try
            {
                // 1️⃣ Load entity
                var entity = await _queriesManager.ChartOfAccounts.GetById(id);
                if (entity == null)
                {
                    return ReturnBase<ChartOfAccountDto>.Fail(new List<ReturnBaseError>
            {
                new()
                {
                    ErrorCode = "404",
                    ErrorMessage = "Chart Of Account Not Found"
                }
            });
                }

                // 2️⃣ BUSINESS RULE: prevent delete if used as parent
                var childIds = await _commands.GetChildAccountIds(id);
                if (childIds.Any())
                {
                    var usedIn = string.Join(", ", childIds);

                    return ReturnBase<ChartOfAccountDto>.Fail(new List<ReturnBaseError>
            {
                new()
                {
                    ErrorCode = "BUSINESS_RULE",
                    ErrorMessage =
                        $"Cannot delete this account because it is used as a parent in accounts {{ {usedIn} }}."
                }
            });
                }

                // 3️⃣ Delete entity (NOT by Id)
                await _commands.DeleteById(id);

                // 4️⃣ Save
                var saveResult = await _accountUoW.SaveAsync();
                if (!saveResult.Succeeded)
                    return ReturnBase<ChartOfAccountDto>.Fail(saveResult.Errors);

                // 5️⃣ Return deleted entity
                return ReturnBase<ChartOfAccountDto>.Success(
                    _mapper.Map<ChartOfAccountDto>(entity));
            }
            catch (Exception ex)
            {
                return ReturnBase<ChartOfAccountDto>.Fail(ex, _exceptionManager);
            }
        }

        public async Task<ReturnBase<IEnumerable<ChartOfAccountReturnSearchDto>>> Search(SqlQueryOptions sqlQueryOptions)
        {
            try
            {
                var getResult = await _queriesManager.ChartOfAccounts.Search(sqlQueryOptions);
                if (!getResult.Succeeded)
                    return ReturnBase<IEnumerable<ChartOfAccountReturnSearchDto>>.Fail(getResult.Errors);

                return ReturnBase<IEnumerable<ChartOfAccountReturnSearchDto>>.Success(getResult.Result);
            }
            catch (Exception ex)
            {
                return ReturnBase<IEnumerable<ChartOfAccountReturnSearchDto>>.Fail(ex, _exceptionManager);
            }
        }


        public async Task<ReturnBase<ChartOfAccountDto>> GetById(long id)
        {
            try
            {
                var entity = await _queriesManager.ChartOfAccounts.GetById(id);
                if (entity is null)
                {
                    var error = new ReturnBaseError
                    {
                        ErrorCode = "404",
                        ErrorMessage = "Chart Of Account Found"
                    };
                    var listOfErrors = new List<ReturnBaseError>() { error };
                    return ReturnBase<ChartOfAccountDto>.Fail(listOfErrors);
                }

                var mappedResult = _mapper.Map<ChartOfAccountDto>(entity);

                return ReturnBase<ChartOfAccountDto>.Success(mappedResult);
            }
            catch (Exception ex)
            {
                return ReturnBase<ChartOfAccountDto>.Fail(ex, _exceptionManager);
            }
        }

        public async Task<ReturnBase<ChartOfAccountDto>> GetByCode(string code)
        {
            try
            {
                var entity = await _queriesManager.ChartOfAccounts.GetByCode(code);
                if (entity is null)
                {
                    var error = new ReturnBaseError
                    {
                        ErrorCode = "404",
                        ErrorMessage = "Chart Of Account Not Found"
                    };
                    var listOfErrors = new List<ReturnBaseError>() { error };
                    return ReturnBase<ChartOfAccountDto>.Fail(listOfErrors);
                }

                var mappedResult = _mapper.Map<ChartOfAccountDto>(entity);

                return ReturnBase<ChartOfAccountDto>.Success(mappedResult);
            }
            catch (Exception ex)
            {
                return ReturnBase<ChartOfAccountDto>.Fail(ex, _exceptionManager);
            }
        }

        //Import Dynamic ChartOfAccounts
        public async Task<ReturnBase<ImportResultDto>> ImportChartOfAccounts(ExcelImportRequestDto dto)
        {
            try
            {
                var finalResult = new ImportResultDto();
                var profile = new ChartOfAccountImportProfile();

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
                var accountTypeCache = new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase);
                var currencyCache = new Dictionary<string, long>(StringComparer.OrdinalIgnoreCase);
                var costUnitCache = new Dictionary<string, long>(StringComparer.OrdinalIgnoreCase);
                var costCenterCache = new Dictionary<string, long>(StringComparer.OrdinalIgnoreCase);
                var parentAccountCache = new Dictionary<string, long>(StringComparer.OrdinalIgnoreCase);

                for (int r = firstDataRow; r <= lastRow; r++)
                {
                    finalResult.ProcessedCount++;

                    // Read Row
                    var rawRow = new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase);
                    for (int c = 0; c < headers.Count; c++)
                        rawRow[headers[c]] = ws.Cell(r, c + 1).GetString().Trim();

                    var rowErrors = new List<string>();
                    ChartOfAccountCreateDto? createDto = null;

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

                    // AccountType (REQUIRED)
                    if (!accountTypeCache.ContainsKey(createDto.AccountTypeCode))
                    {
                        var accountType = await _queriesManager.AccountTypes.GetByCode(createDto.AccountTypeCode);
                        if (accountType == null)
                            rowErrors.Add($"AccountType '{createDto.AccountTypeCode}' not found.");
                        else
                            accountTypeCache[createDto.AccountTypeCode] = accountType.AccountTypeCode;
                    }

                    // Currency (OPTIONAL)
                    if (rawRow.TryGetValue("CurrencyCode", out var currencyCode) &&
                        !string.IsNullOrWhiteSpace(currencyCode))
                    {
                        if (!currencyCache.TryGetValue(currencyCode, out var currencyId))
                        {
                            var currency = await _queriesManager.Currencies.GetByCode(currencyCode);
                            if (currency == null)
                                rowErrors.Add($"Currency '{currencyCode}' not found.");
                            else
                                currencyCache[currencyCode] = currencyId = currency.Id;
                        }

                        if (currencyCache.TryGetValue(currencyCode, out var cid))
                            createDto.CurrencyId = cid;
                    }

                    // CostUnit (OPTIONAL)
                    if (rawRow.TryGetValue("CostUnitCode", out var costUnitCode) &&
                        !string.IsNullOrWhiteSpace(costUnitCode))
                    {
                        if (!costUnitCache.TryGetValue(costUnitCode, out var costUnitId))
                        {
                            var costUnit = await _queriesManager.CostUnits.GetByCode(costUnitCode);
                            if (costUnit == null)
                                rowErrors.Add($"CostUnit '{costUnitCode}' not found.");
                            else
                                costUnitCache[costUnitCode] = costUnitId = costUnit.Id;
                        }

                        if (costUnitCache.TryGetValue(costUnitCode, out var cuid))
                            createDto.CostUnitId = cuid;
                    }

                    // CostCenter (OPTIONAL)
                    if (rawRow.TryGetValue("CostCenterCode", out var costCenterCode) &&
                        !string.IsNullOrWhiteSpace(costCenterCode))
                    {
                        if (!costCenterCache.TryGetValue(costCenterCode, out var costCenterId))
                        {
                            var costCenter = await _queriesManager.CostCenters.GetByCode(costCenterCode);
                            if (costCenter == null)
                                rowErrors.Add($"CostCenter '{costCenterCode}' not found.");
                            else
                                costCenterCache[costCenterCode] = costCenterId = costCenter.Id;
                        }

                        if (costCenterCache.TryGetValue(costCenterCode, out var ccid))
                            createDto.CostCenterId = ccid;
                    }

                    // Parent Account (OPTIONAL)
                    if (rawRow.TryGetValue("ParentAccountCode", out var parentCode) &&
                        !string.IsNullOrWhiteSpace(parentCode))
                    {
                        if (!parentAccountCache.TryGetValue(parentCode, out var parentId))
                        {
                            var parent = await _queriesManager.ChartOfAccounts.GetByCode(parentCode);
                            if (parent == null)
                                rowErrors.Add($"Parent account '{parentCode}' not found.");
                            else
                                parentAccountCache[parentCode] = parentId = parent.Id;
                        }

                        if (parentAccountCache.TryGetValue(parentCode, out var pid))
                            createDto.ParentAccountId = pid;
                    }

                    // If any errors → skip row
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
                    .GenerateTemplateAsync<ChartOfAccountImportTemplateDto>("ChartOfAccount");

                var file = new FileResultDto
                {
                    Content = content,
                    FileName = "ChartOfAccount.xlsx"
                };

                return ReturnBase<FileResultDto>.Success(file);
            }
            catch (Exception ex)
            {
                return ReturnBase<FileResultDto>.Fail(ex, _exceptionManager);
            }
        }

        private async Task<ReturnBaseError?> ValidateChartOfAccountRules(
      ChartOfAccountCreateDto dto,
      ChartOfAccount? existingEntity = null)
        {
            // =========================================================
            // 1️⃣ Parent / IsMain rules
            // =========================================================

            // ❌ Non-main accounts MUST have a parent
            if (!dto.IsMain && dto.ParentAccountId == null)
            {
                return new ReturnBaseError
                {
                    ErrorCode = "BUSINESS_RULE",
                    ErrorMessage = "Parent account is required when the account is not main."
                };
            }

            // ✅ Main accounts:
            // ParentAccountId is OPTIONAL
            // (Allowed → supports multi-level main accounts)
            // So: NO validation error here


            // =========================================================
            // 2️⃣ Cost Center rules
            // =========================================================

            if (dto.IsCostCenterRequired && dto.CostCenterId == null)
            {
                return new ReturnBaseError
                {
                    ErrorCode = "BUSINESS_RULE",
                    ErrorMessage = "Cost Center is required when IsCostCenterRequired is true."
                };
            }

            // If NOT required → CostCenterId can be null (default behavior)


            // =========================================================
            // 3️⃣ Cost Unit rules
            // =========================================================

            if (dto.IsCostUnitRequired && dto.CostUnitId == null)
            {
                return new ReturnBaseError
                {
                    ErrorCode = "BUSINESS_RULE",
                    ErrorMessage = "Cost Unit is required when IsCostUnitRequired is true."
                };
            }

            // If NOT required → CostUnitId can be null


            // =========================================================
            // 4️⃣ UPDATE-only rules
            // =========================================================

            if (existingEntity != null)
            {
                // 🔒 Prevent changing AccountTypeCode if this account has children
                if (existingEntity.AccountTypeCode != dto.AccountTypeCode)
                {
                    var hasChildren = await _commands.HasChildren(existingEntity.Id);
                    if (hasChildren)
                    {
                        return new ReturnBaseError
                        {
                            ErrorCode = "BUSINESS_RULE",
                            ErrorMessage =
                                "Cannot change Account Type because this account is used as a parent by other accounts."
                        };
                    }
                }

                // 🔒 Prevent turning IsMain from true → false if it has children
                if (existingEntity.IsMain && !dto.IsMain)
                {
                    var child = await _commands.GetFirstChild(existingEntity.Id);
                    if (child != null)
                    {
                        return new ReturnBaseError
                        {
                            ErrorCode = "BUSINESS_RULE",
                            ErrorMessage =
                                $"Cannot change IsMain to false. " +
                                $"This account is used as a parent by " +
                                $"Account (Code: {child.AccountCode}, Name: {child.AccountName})."
                        };
                    }
                }
            }

            // =========================================================
            // ✅ All rules passed
            // =========================================================
            return null;
        }
        private async Task<long> CalculateLevel(long? parentAccountId)
        {
            if (parentAccountId == null)
                return 1;

            var parent = await _queriesManager.ChartOfAccounts.GetById(parentAccountId.Value);
            if (parent == null)
                throw new InvalidOperationException("Parent account not found.");

            return parent.Level + 1;
        }





        public async Task<ReturnBase<IEnumerable<ChartOfAccountSelectQueryDto>>> Select(SqlQueryOptions sqlQueryOptions)
        {
            try
            {

                var getResult = await _queriesManager.ChartOfAccounts.Select(sqlQueryOptions);

                if (!getResult.Succeeded)
                    return ReturnBase<IEnumerable<ChartOfAccountSelectQueryDto>>.Fail(getResult.Errors);

                var mappedResult = _mapper.Map<IEnumerable<ChartOfAccountSelectQueryDto>>(getResult.Result);

                return ReturnBase<IEnumerable<ChartOfAccountSelectQueryDto>>.Success(mappedResult);
            }
            catch (Exception ex)
            {
                return ReturnBase<IEnumerable<ChartOfAccountSelectQueryDto>>.Fail(ex, _exceptionManager);
            }
        }
        private IChartOfAccountCommandRepository _commands
        {
            get { return _accountUoW.ChartOfAccount; }
        }
    }
}