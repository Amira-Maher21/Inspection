using AutoMapper;
using ClosedXML.Excel;
using Inspection.Application.Contracts.Dto.AccountingDtos.AccountingSetupDtos.CostUnitDTOs;
using Inspection.Application.Contracts.Dto.SharedDtos;
using Inspection.Application.Contracts.Managers;
using Inspection.Application.Contracts.Repositories.Command.Accounting.AccountSetup.CostUnits;
using Inspection.Application.Contracts.Services.Accounting.AccountSetup.CostUnits;
using Inspection.Application.Contracts.UnitOfWork;
using Inspection.Application.Services.ServicesBase;
using Inspection.Application.Shared.ExcelTemplate;
using Inspection.Application.Shared.SharedValidation;
using Inspection.Domain.Models.Accounting.AccountingSetup.CostUnits;
using NDS.Shared.Application.DataQuery;
using NDS.Shared.Application.Multitenant;
using NDS.Shared.Kernel.BaseReturnTypes;
using NDS.Shared.Kernel.Exceptions;

namespace Inspection.Application.Services.Accounting.AccountSetup.CostUnits
{
    internal class CostUnitService : AccountsServiceBase, ICostUnitService
    {
        private readonly ITenantResolver _tenantResolver;
        private readonly IExcelTemplateGenerator _templateGenerator;

        public CostUnitService(IAccountUnitOfWork accountUoW, IAccountsQueriesManager queriesManager, IMapper mapper, IExceptionManager exceptionManager, ITenantResolver tenantResolver, IExcelTemplateGenerator templateGenerator) : base(accountUoW, queriesManager, mapper, exceptionManager)
        {
            _tenantResolver = tenantResolver;
            _templateGenerator = templateGenerator;
        }
        //public async Task<List<CostUnitDto>> GetAll(string tenantId)
        //{

        //    var list = await _queriesManager.CostUnits.GetAll(tenantId);
        //    return _mapper.Map<List<CostUnitDto>>(list.Result);
        //}
        public async Task<ReturnBase<CostUnitDto>> Create(CostUnitCreateDto createDto)
        {
            try
            {
                createDto.Code.ValidateAsCode();
                createDto.Name.ValidateAsName();
                // 🔹 SINGLE METHOD CALL
                var ruleError = await ValidateIsMainRules(
                    createDto.IsMain,
                    createDto.ParentCostUnitId);

                if (ruleError != null)
                {
                    return ReturnBase<CostUnitDto>.Fail(new List<ReturnBaseError>
            {
                ruleError
            });
                }

                var entity = _mapper.Map<CostUnit>(createDto);
                entity.Tenant_ID = _tenantResolver.GetTenantName();

                var insertResult = await _commands.InsertAsync(entity);
                if (!insertResult.Succeeded)
                {
                    return ReturnBase<CostUnitDto>.Fail(insertResult.Errors);
                }

                var saveResult = await _accountUoW.SaveAsync();
                if (!saveResult.Succeeded)
                {
                    return ReturnBase<CostUnitDto>.Fail(saveResult.Errors);
                }

                var resultDto = _mapper.Map<CostUnitDto>(entity);

                return ReturnBase<CostUnitDto>.Success(resultDto);
            }
            catch (Exception ex)
            {
                return ReturnBase<CostUnitDto>.Fail(ex, _exceptionManager);
            }
        }

        public async Task<ReturnBase<CostUnitDto>> Update(CostUnitUpdateDto updateDto)
        {
            try
            {
                updateDto.Code.ValidateAsCode();
                updateDto.Name.ValidateAsName();
                // Load existing entity
                var entity = await _queriesManager.CostUnits.GetById(updateDto.Id);
                if (entity == null)
                {
                    return ReturnBase<CostUnitDto>.Fail(new List<ReturnBaseError>
            {
                new()
                {
                    ErrorCode = "404",
                    ErrorMessage = "Cost Unit Not Found"
                }
            });
                }



                // Business rule validation
                var ruleError = await ValidateIsMainRules(
                    updateDto.IsMain,
                    updateDto.ParentCostUnitId,
                    entity);

                if (ruleError != null)
                {
                    return ReturnBase<CostUnitDto>.Fail(new List<ReturnBaseError>
            {
                ruleError
            });
                }
                entity.Tenant_ID = _tenantResolver.GetTenantName();

                // Map DTO → EXISTING entity (DO NOT replace instance)
                _mapper.Map(updateDto, entity);

                // Persist changes
                var updateResult = await _commands.UpdateAsync(entity);
                if (!updateResult.Succeeded)
                    return ReturnBase<CostUnitDto>.Fail(updateResult.Errors);

                var saveResult = await _accountUoW.SaveAsync();
                if (!saveResult.Succeeded)
                    return ReturnBase<CostUnitDto>.Fail(saveResult.Errors);

                // Return result
                var resultDto = _mapper.Map<CostUnitDto>(entity);
                return ReturnBase<CostUnitDto>.Success(resultDto);
            }
            catch (Exception ex)
            {
                return ReturnBase<CostUnitDto>.Fail(ex, _exceptionManager);
            }
        }

        public async Task<ReturnBase<CostUnitDto>> Delete(long id)
        {
            try
            {
                // 1️⃣ Load entity
                var entity = await _queriesManager.CostUnits.GetById(id);
                if (entity == null)
                {
                    return ReturnBase<CostUnitDto>.Fail(new List<ReturnBaseError>
            {
                new()
                {
                    ErrorCode = "404",
                    ErrorMessage = "Cost Unit Not Found"
                }
            });
                }

                // 2️⃣ BUSINESS RULE: prevent delete if used as parent
                var childIds = await _commands.GetChildCostUnitIds(id);
                if (childIds.Any())
                {
                    var usedIn = string.Join(", ", childIds);

                    return ReturnBase<CostUnitDto>.Fail(new List<ReturnBaseError>
            {
                new()
                {
                    ErrorCode = "BUSINESS_RULE",
                    ErrorMessage =
                        $"Cannot delete this Cost Unit because it is used as a parent in Cost Units {{ {usedIn} }}."
                }
            });
                }

                // 3️⃣ Delete aggregate root
                await _commands.DeleteById(id);

                // 4️⃣ Commit
                var saveResult = await _accountUoW.SaveAsync();
                if (!saveResult.Succeeded)
                    return ReturnBase<CostUnitDto>.Fail(saveResult.Errors);

                // 5️⃣ Return deleted entity
                return ReturnBase<CostUnitDto>.Success(
                    _mapper.Map<CostUnitDto>(entity));
            }
            catch (Exception ex)
            {
                return ReturnBase<CostUnitDto>.Fail(ex, _exceptionManager);
            }
        }
        public async Task<ReturnBase<CostUnitDto>> GetByCode(string code)
        {
            try
            {
                var entity = await _queriesManager.CostUnits.GetByCode(code);
                if (entity is null)
                {
                    var error = new ReturnBaseError
                    {
                        ErrorCode = "404",
                        ErrorMessage = "Cost Unit Not Found"
                    };
                    var listOfErrors = new List<ReturnBaseError>() { error };
                    return ReturnBase<CostUnitDto>.Fail(listOfErrors);
                }

                var mappedResult = _mapper.Map<CostUnitDto>(entity);

                return ReturnBase<CostUnitDto>.Success(mappedResult);
            }
            catch (Exception ex)
            {
                return ReturnBase<CostUnitDto>.Fail(ex, _exceptionManager);
            }
        }

        public async Task<ReturnBase<IEnumerable<CostUnitDto>>> Search(SqlQueryOptions sqlQueryOptions)
        {
            try
            {
                var getResult = await _queriesManager.CostUnits.Search(sqlQueryOptions);
                if (!getResult.Succeeded)
                    return ReturnBase<IEnumerable<CostUnitDto>>.Fail(getResult.Errors);

                return ReturnBase<IEnumerable<CostUnitDto>>.Success(getResult.Result);
            }
            catch (Exception ex)
            {
                return ReturnBase<IEnumerable<CostUnitDto>>.Fail(ex, _exceptionManager);
            }
        }

        public async Task<ReturnBase<CostUnitDto>> GetById(long id)
        {
            try
            {
                var entity = await _queriesManager.CostUnits.GetById(id);
                if (entity is null)
                {
                    var error = new ReturnBaseError
                    {
                        ErrorCode = "404",
                        ErrorMessage = "Cost Unit Not Found"
                    };
                    var listOfErrors = new List<ReturnBaseError>() { error };
                    return ReturnBase<CostUnitDto>.Fail(listOfErrors);
                }

                var mappedResult = _mapper.Map<CostUnitDto>(entity);

                return ReturnBase<CostUnitDto>.Success(mappedResult);
            }
            catch (Exception ex)
            {
                return ReturnBase<CostUnitDto>.Fail(ex, _exceptionManager);
            }
        }

        //Import Dynamic Cost Units
        public async Task<ReturnBase<ImportResultDto>> ImportCostUnits(ExcelImportRequestDto dto)
        {
            try
            {
                var finalResult = new ImportResultDto();

                var profile = new CostUnitImportProfile();

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

                for (int r = firstDataRow; r <= lastRow; r++)
                {
                    finalResult.ProcessedCount++;

                    var rawRow = new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase);
                    for (int c = 0; c < headers.Count; c++)
                    {
                        rawRow[headers[c]] = ws.Cell(r, c + 1).GetString().Trim();
                    }

                    var rowErrors = new List<string>();
                    CostUnitCreateDto? createDto = null;

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
                    .GenerateTemplateAsync<CostUnitImportTemplateDto>("CostUnit");

                var file = new FileResultDto
                {
                    Content = content,
                    FileName = "CostUnit.xlsx"
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
        private ICostUnitCommandRepository _commands
        {
            get { return _accountUoW.CostUnit; }
        }
        private async Task<ReturnBaseError?> ValidateIsMainRules(
            bool newIsMain,
            long? newParentCostUnitId,
            CostUnit? existingEntity = null)
        {
            // Rule 1: Parent required when IsMain = false
            if (!newIsMain && newParentCostUnitId == null)
            {
                return new ReturnBaseError
                {
                    ErrorCode = "BUSINESS_RULE",
                    ErrorMessage = "Parent Cost Unit is required when IsMain is false."
                };
            }

            // Rule 2: Update only (true → false AND used as parent)
            if (existingEntity != null &&
                existingEntity.IsMain &&
                !newIsMain)
            {
                var child = await _commands.GetFirstChild(existingEntity.Id);

                if (child != null)
                {
                    return new ReturnBaseError
                    {
                        ErrorCode = "BUSINESS_RULE",
                        ErrorMessage =
                            $"Cannot change IsMain to false. " +
                            $"This Cost Unit is used as a parent by " +
                            $"Cost Unit (Code: {child.Code}, Name: {child.Name})."
                    };
                }
            }

            return null;
        }
    }
}