//using AutoMapper;
//using Inspection.Application.Contracts.Dto.AccountingDtos.AccountingSetupDtos.CostCenterDTOs;
//using Inspection.Application.Contracts.Managers;
//using Inspection.Application.Contracts.Repositories.Command.Accounting.AccountSetup;
//using Inspection.Application.Contracts.Repositories.Query.Accounting.AccountSetup;
//using Inspection.Application.Contracts.Services.Accounting.AccountSetup;
//using Inspection.Application.Contracts.UnitOfWork;
//using Inspection.Application.Services.ServicesBase;
//using Inspection.Application.Shared.ExcelTemplate;
//using Inspection.Domain.Models.Accounting.AccountingSetup;
//using NDS.Shared.Application.DataQuery;
//using NDS.Shared.Application.Multitenant;
//using NDS.Shared.Kernel.BaseReturnTypes;
//using NDS.Shared.Kernel.Exceptions;

//namespace Inspection.Application.Services.Accounting.AccountSetup
//{
//    public class CostCenterService : AccountsServiceBase, ICostCenterService
//    {
//        private readonly ITenantResolver _tenantResolver;
//        private readonly IAccountsQueriesManager _queriesManager;

//        private readonly IExcelTemplateGenerator _templateGenerator;

//        public CostCenterService(
//            IAccountUnitOfWork accountUoW,
//            IAccountsQueriesManager queriesManager,
//            IMapper mapper,
//            IExceptionManager exceptionManager,
//            ITenantResolver tenantResolver,
//            IExcelTemplateGenerator templateGenerator
//        )
//            : base(accountUoW, queriesManager, mapper, exceptionManager)
//        {
//            _queriesManager = queriesManager ?? throw new ArgumentNullException(nameof(queriesManager));

//            _tenantResolver = tenantResolver;
//            _templateGenerator = templateGenerator;
//        }
//        //private ICostCenterCommandRepository _commands
//        //{
//        //    get { return _accountUoW.CostCenter; }
//        //}
//        private ICostCenterCommandRepository _commands => _accountUoW.CostCenter;

//        private ICostCenterQueryRepository _queries => _queriesManager.CostCenters ?? throw new NullReferenceException("ICostCentersQueryRepo is null");

//        public async Task<List<CostCenterDto>> GetAll()
//        {

//            var list = await _queriesManager.CostCenters.GetAllAsync();
//            return _mapper.Map<List<CostCenterDto>>(list.Result);
//        }


//        private ReturnBaseError[] ValidateCostCenter(CostCenter entity)
//        {
//            var errors = new List<ReturnBaseError>();

//            if (!entity.IsMain && !entity.ParentCostCenterId.HasValue)
//            {
//                errors.Add(new ReturnBaseError
//                {
//                    ErrorMessage = "ParentCostCenterId is required for non-main cost centers."
//                });
//            }

//            if (entity.IsMain && entity.ParentCostCenterId.HasValue)
//            {
//                errors.Add(new ReturnBaseError
//                {
//                    ErrorMessage = "ParentCostCenterId must be null for main cost centers."
//                });
//            }

//            return errors.Any() ? errors.ToArray() : null;
//        }

//        public async Task<ReturnBase<CostCenterDto>> Create(CostCenterCreateDto createDto)
//        {
//            try
//            {
//                var entity = _mapper.Map<CostCenter>(createDto);

//                entity.ParentCostCenterId = null;

//                var insertResult = await _commands.InsertAsync(entity);
//                if (!insertResult.Succeeded)
//                {
//                    return ReturnBase<CostCenterDto>.Fail(insertResult.Errors);
//                }

//                var saveResult = await _accountUoW.SaveAsync();
//                if (!saveResult.Succeeded)
//                {
//                    return ReturnBase<CostCenterDto>.Fail(saveResult.Errors);
//                }

//                entity.ParentCostCenterId = entity.Id;

//                var updateResult = await _commands.UpdateAsync(entity);
//                if (!updateResult.Succeeded)
//                    return ReturnBase<CostCenterDto>.Fail(updateResult.Errors);

//                var finalSaveResult = await _accountUoW.SaveAsync();
//                if (!finalSaveResult.Succeeded)
//                    return ReturnBase<CostCenterDto>.Fail(finalSaveResult.Errors);
//                entity.Tenant_ID = _tenantResolver.GetTenantName();

//                var resultDto = _mapper.Map<CostCenterDto>(entity);

//                return ReturnBase<CostCenterDto>.Success(resultDto);
//            }
//            catch (Exception ex)
//            {
//                return ReturnBase<CostCenterDto>.Fail(new[]
//                {
//            new ReturnBaseError { ErrorMessage = ex.Message }
//        });
//            }
//        }

//        public async Task<ReturnBase<CostCenterDto>> Update(CostCenterUpdateDto updateDto, long id)
//        {
//            try
//            {
//                var entity = await _queriesManager.CostCenters.GetById(id);
//                if (entity is null)
//                {
//                    return ReturnBase<CostCenterDto>.Fail(new[]
//                    {
//                new ReturnBaseError
//                {
//                    ErrorCode = "404",
//                    ErrorMessage = "CostCenter Not Found"
//                }
//            });
//                }

//                _mapper.Map(updateDto, entity);

//                if (entity.IsMain && !entity.ParentCostCenterId.HasValue)
//                {
//                    entity.ParentCostCenterId = entity.Id;
//                }

//                if (!entity.IsMain && !entity.ParentCostCenterId.HasValue)
//                {
//                    return ReturnBase<CostCenterDto>.Fail(new[]
//                    {
//                new ReturnBaseError
//                {
//                    ErrorMessage = "ParentCostCenterId is required for non-main cost centers."
//                }
//            });
//                }

//                var saveResult = await _accountUoW.SaveAsync();
//                if (!saveResult.Succeeded)
//                    return ReturnBase<CostCenterDto>.Fail(saveResult.Errors);

//                var mappedResult = _mapper.Map<CostCenterDto>(entity);
//                return ReturnBase<CostCenterDto>.Success(mappedResult);
//            }
//            catch (Exception ex)
//            {
//                return ReturnBase<CostCenterDto>.Fail(new[]
//                {
//            new ReturnBaseError { ErrorMessage = ex.Message }
//        });
//            }
//        }

//        public async Task<ReturnBase<CostCenterDto>> Delete(long id)
//        {
//            try
//            {
//                var entity = await _queriesManager.CostCenters.GetById(id);
//                if (entity is null)
//                {
//                    var error = new ReturnBaseError
//                    {
//                        ErrorCode = "404",
//                        ErrorMessage = "Company Not Found"
//                    };
//                    var listOfErrors = new List<ReturnBaseError>() { error };
//                    return ReturnBase<CostCenterDto>.Fail(listOfErrors);
//                }

//                var deleteResult = await _commands.DeleteById(id);

//                if (!deleteResult.Succeeded)
//                    return ReturnBase<CostCenterDto>.Fail(deleteResult.Errors);

//                var saveResult = await _accountUoW.SaveAsync();

//                if (!saveResult.Succeeded)
//                    return ReturnBase<CostCenterDto>.Fail(saveResult.Errors);

//                var mappedResult = _mapper.Map<CostCenterDto>(entity);

//                return ReturnBase<CostCenterDto>.Success(mappedResult);

//            }
//            catch (Exception ex)
//            {
//                return ReturnBase<CostCenterDto>.Fail(ex, _exceptionManager);
//            }
//        }
//        public async Task<ReturnBase<IEnumerable<CostCenterDto>>> Search(SqlQueryOptions sqlQueryOptions)
//        {
//            try
//            {
//                var result = await _queries.Search(sqlQueryOptions);
//                if (!result.Succeeded) return ReturnBase<IEnumerable<CostCenterDto>>.Fail(result.Errors);

//                var mapped = result.Result.Select(c => _mapper.Map<CostCenterDto>(c)).ToList();
//                return ReturnBase<IEnumerable<CostCenterDto>>.Success(mapped);
//            }
//            catch (Exception ex)
//            {
//                return ReturnBase<IEnumerable<CostCenterDto>>.Fail(ex, _exceptionManager);
//            }
//        }

//        public async Task<ReturnBase<CostCenterDto>> GetById(long id)
//        {
//            try
//            {
//                var entity = await _queriesManager.CostCenters.GetById(id);
//                if (entity is null)
//                {
//                    var error = new ReturnBaseError
//                    {
//                        ErrorCode = "404",
//                        ErrorMessage = "CostCenter Not Found"
//                    };
//                    var listOfErrors = new List<ReturnBaseError>() { error };
//                    return ReturnBase<CostCenterDto>.Fail(listOfErrors);
//                }

//                var mappedResult = _mapper.Map<CostCenterDto>(entity);

//                return ReturnBase<CostCenterDto>.Success(mappedResult);
//            }
//            catch (Exception ex)
//            {
//                return ReturnBase<CostCenterDto>.Fail(ex, _exceptionManager);
//            }
//        }

//        public async Task<ReturnBase<CostCenterDto>> GetByCode(string code)
//        {
//            try
//            {
//                var entity = await _queriesManager.CostCenters.GetByCode(code);
//                if (entity is null)
//                {
//                    var error = new ReturnBaseError
//                    {
//                        ErrorCode = "404",
//                        ErrorMessage = "Cost Center Not Found"
//                    };
//                    var listOfErrors = new List<ReturnBaseError>() { error };
//                    return ReturnBase<CostCenterDto>.Fail(listOfErrors);
//                }

//                var mappedResult = _mapper.Map<CostCenterDto>(entity);

//                return ReturnBase<CostCenterDto>.Success(mappedResult);
//            }
//            catch (Exception ex)
//            {
//                return ReturnBase<CostCenterDto>.Fail(ex, _exceptionManager);
//            }
//        }


//    }
//}


using AutoMapper;
using ClosedXML.Excel;
using Inspection.Application.Contracts.Dto.AccountingDtos.AccountingSetupDtos.CostCenterDTOs;
using Inspection.Application.Contracts.Dto.SharedDtos;
using Inspection.Application.Contracts.Managers;
using Inspection.Application.Contracts.Repositories.Command.Accounting.AccountSetup;
using Inspection.Application.Contracts.Repositories.Query.Accounting.AccountSetup;
using Inspection.Application.Contracts.Services.Accounting.AccountSetup;
using Inspection.Application.Contracts.UnitOfWork;
using Inspection.Application.Services.ServicesBase;
using Inspection.Application.Shared.ExcelTemplate;
using Inspection.Domain.Models.Accounting.AccountingSetup;
using NDS.Shared.Application.DataQuery;
using NDS.Shared.Application.Multitenant;
using NDS.Shared.Kernel.BaseReturnTypes;
using NDS.Shared.Kernel.Exceptions;

public class CostCenterService : AccountsServiceBase, ICostCenterService
{
    private readonly ITenantResolver _tenantResolver;
    private readonly IExcelTemplateGenerator _templateGenerator;


    public CostCenterService(
        IAccountUnitOfWork accountUoW,
        IAccountsQueriesManager queriesManager,
        IMapper mapper,
        IExceptionManager exceptionManager,
        ITenantResolver tenantResolver,
        IExcelTemplateGenerator templateGenerator
    ) : base(accountUoW, queriesManager, mapper, exceptionManager)
    {
        _tenantResolver = tenantResolver;
        _templateGenerator = templateGenerator;
    }

    private ICostCenterCommandRepository _commands => _accountUoW.CostCenter;

    private ICostCenterQueryRepository _queries => _queriesManager.CostCenters;





    public async Task<ReturnBase<CostCenterDto>> Create(CostCenterCreateDto dto)
    {
        try
        {
            var ruleError = await ValidateRules(dto.ParentCostCenterId);
            if (ruleError != null)
                return ReturnBase<CostCenterDto>.Fail(new[] { ruleError });

            var entity = _mapper.Map<CostCenter>(dto);
            entity.Tenant_ID = _tenantResolver.GetTenantName();

            entity.IsMain = !dto.ParentCostCenterId.HasValue;

            var insertResult = await _commands.InsertAsync(entity);
            if (!insertResult.Succeeded)
                return ReturnBase<CostCenterDto>.Fail(insertResult.Errors);

            if (dto.ParentCostCenterId.HasValue)
                await SetParentIsMain(dto.ParentCostCenterId.Value, false);

            var saveResult = await _accountUoW.SaveAsync();
            if (!saveResult.Succeeded)
                return ReturnBase<CostCenterDto>.Fail(saveResult.Errors);

            return ReturnBase<CostCenterDto>.Success(
                _mapper.Map<CostCenterDto>(entity));
        }
        catch (Exception ex)
        {
            return ReturnBase<CostCenterDto>.Fail(ex, _exceptionManager);
        }
    }

    public async Task<ReturnBase<CostCenterDto>> Update(CostCenterUpdateDto dto)
    {
        try
        {
            var entity = await _queries.GetById(dto.Id);
            if (entity == null)
                return NotFound();



            var ruleError = await ValidateRules(dto.ParentCostCenterId, entity);
            if (ruleError != null)
                return ReturnBase<CostCenterDto>.Fail(new[] { ruleError });

            if (entity.ParentCostCenterId != dto.ParentCostCenterId)
            {
                if (entity.ParentCostCenterId.HasValue)
                    await TryRestoreParentMain(entity.ParentCostCenterId.Value);

                if (dto.ParentCostCenterId.HasValue)
                    await SetParentIsMain(dto.ParentCostCenterId.Value, false);
            }
            entity.Tenant_ID = _tenantResolver.GetTenantName();

            _mapper.Map(dto, entity);

            entity.IsMain = !dto.ParentCostCenterId.HasValue;

            var updateResult = await _commands.UpdateAsync(entity);
            if (!updateResult.Succeeded)
                return ReturnBase<CostCenterDto>.Fail(updateResult.Errors);

            var saveResult = await _accountUoW.SaveAsync();
            if (!saveResult.Succeeded)
                return ReturnBase<CostCenterDto>.Fail(saveResult.Errors);

            return ReturnBase<CostCenterDto>.Success(
                _mapper.Map<CostCenterDto>(entity));
        }
        catch (Exception ex)
        {
            return ReturnBase<CostCenterDto>.Fail(ex, _exceptionManager);
        }
    }

    public async Task<ReturnBase<CostCenterDto>> Delete(long id)
    {
        try
        {
            var entity = await _queries.GetById(id);
            if (entity == null)
                return NotFound();

            if (await _commands.HasChildren(id))
            {
                return ReturnBase<CostCenterDto>.Fail(new[]
                {
                    new ReturnBaseError
                    {
                        ErrorCode = "BUSINESS_RULE",
                        ErrorMessage = "Cannot delete cost center that has sub cost centers."
                    }
                });
            }

            var parentId = entity.ParentCostCenterId;

            var deleteResult = await _commands.DeleteById(id);
            if (!deleteResult.Succeeded)
                return ReturnBase<CostCenterDto>.Fail(deleteResult.Errors);

            if (parentId.HasValue)
                await TryRestoreParentMain(parentId.Value);

            var saveResult = await _accountUoW.SaveAsync();
            if (!saveResult.Succeeded)
                return ReturnBase<CostCenterDto>.Fail(saveResult.Errors);

            return ReturnBase<CostCenterDto>.Success(
                _mapper.Map<CostCenterDto>(entity));
        }
        catch (Exception ex)
        {
            return ReturnBase<CostCenterDto>.Fail(ex, _exceptionManager);
        }
    }

    public async Task<ReturnBase<CostCenterDto>> GetById(long id)
    {
        try
        {
            var entity = await _queries.GetById(id);
            if (entity == null)
                return NotFound();

            return ReturnBase<CostCenterDto>.Success(
                _mapper.Map<CostCenterDto>(entity));
        }
        catch (Exception ex)
        {
            return ReturnBase<CostCenterDto>.Fail(ex, _exceptionManager);
        }
    }

    public async Task<ReturnBase<IEnumerable<CostCenterReturnSearchDto>>> Search(SqlQueryOptions options)
    {
        try
        {
            var result = await _queries.Search(options);
            if (!result.Succeeded)
                return ReturnBase<IEnumerable<CostCenterReturnSearchDto>>.Fail(result.Errors);

            return ReturnBase<IEnumerable<CostCenterReturnSearchDto>>.Success(
                _mapper.Map<IEnumerable<CostCenterReturnSearchDto>>(result.Result));
        }
        catch (Exception ex)
        {
            return ReturnBase<IEnumerable<CostCenterReturnSearchDto>>.Fail(ex, _exceptionManager);
        }
    }

    private async Task SetParentIsMain(long parentId, bool isMain)
    {
        var parent = await _queries.GetById(parentId);
        if (parent != null)
            parent.IsMain = isMain;
    }

    private async Task TryRestoreParentMain(long parentId)
    {
        var hasChildren = await _commands.HasChildren(parentId);
        if (!hasChildren)
        {
            var parent = await _queries.GetById(parentId);
            if (parent != null)
                parent.IsMain = true;
        }
    }

    private ReturnBase<CostCenterDto> NotFound()
    {
        return ReturnBase<CostCenterDto>.Fail(new[]
        {
            new ReturnBaseError
            {
                ErrorCode = "404",
                ErrorMessage = "Cost Center Not Found"
            }
        });
    }

    private Task<ReturnBaseError?> ValidateRules(
        long? parentId,
        CostCenter? existing = null)
    {
        if (parentId.HasValue &&
            existing != null &&
            parentId.Value == existing.Id)
        {
            return Task.FromResult<ReturnBaseError?>(new ReturnBaseError
            {
                ErrorCode = "BUSINESS_RULE",
                ErrorMessage = "Cost center cannot be parent of itself."
            });
        }

        return Task.FromResult<ReturnBaseError?>(null);
    }

    public async Task<ReturnBase<CostCenterDto>> GetByCode(string code)
    {
        try
        {
            var entity = await _queries.GetByCode(code);
            if (entity == null)
                return ReturnBase<CostCenterDto>.Fail(new[]
                {
                new ReturnBaseError { ErrorCode = "404", ErrorMessage = "Cost Center Not Found" }
            });

            return ReturnBase<CostCenterDto>.Success(_mapper.Map<CostCenterDto>(entity));
        }
        catch (Exception ex)
        {
            return ReturnBase<CostCenterDto>.Fail(ex, _exceptionManager);
        }
    }

    public async Task<List<CostCenterDto>> GetAll()
    {
        var list = await _queries.GetAllAsync();
        return _mapper.Map<List<CostCenterDto>>(list.Result);
    }




    public async Task<ReturnBase<ImportResultDto>> ImportCostCenter(ExcelImportRequestDto dto)
    {
        try
        {
            var finalResult = new ImportResultDto();
            var profile = new Inspection.Application.Services.Accounting.AccountSetup.CostCenters.CostCenterImportProfile();

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
                    rawRow[headers[c]] = ws.Cell(r, c + 1).GetString().Trim();

                var rowErrors = new List<string>();
                CostCenterCreateDto? createDto = null;

                // -------- Mapping & Validation --------
                try
                {
                    createDto = await profile.MapAsync(rawRow, rowErrors);
                    await profile.ValidateAsync(createDto, rawRow, rowErrors);
                }
                catch (Exception ex)
                {
                    rowErrors.Add(ex.Message);
                }

                if (rowErrors.Any() || createDto == null)
                {
                    finalResult.FailedRows.Add(new ImportRowErrorDto
                    {
                        RowNumber = r,
                        RawRowData = string.Join(" | ",
                            rawRow.Select(kv => $"{kv.Key}:{kv.Value}")),
                        Errors = rowErrors.Any() ? rowErrors : new() { "Row mapping failed." }
                    });
                    continue;
                }

                // --------   CostCenter --------

                var createResult = await Create(createDto);

                if (!createResult.Succeeded)
                {
                    finalResult.FailedRows.Add(new ImportRowErrorDto
                    {
                        RowNumber = r,
                        RawRowData = string.Join(" | ",
                            rawRow.Select(kv => $"{kv.Key}:{kv.Value}")),
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
                .GenerateTemplateAsync<CostCenterImportTemplateDto>("CostCenter");

            var file = new FileResultDto
            {
                Content = content,
                FileName = "CostCenter.xlsx"
            };

            return ReturnBase<FileResultDto>.Success(file);
        }
        catch (Exception ex)
        {
            return ReturnBase<FileResultDto>.Fail(ex, _exceptionManager);
        }
    }



}
