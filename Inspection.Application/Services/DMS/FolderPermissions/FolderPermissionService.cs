using AutoMapper;
using Inspection.Application.Contracts.Dto.DMSDTOs.FolderPermissionDTOs;
using Inspection.Application.Contracts.Managers;
using Inspection.Application.Contracts.Repositories.Command.DMS.FolderPermissions;
using Inspection.Application.Contracts.Services.DMS.FolderPermissions;
using Inspection.Application.Contracts.Services.MenuManagement.SeriesF;
using Inspection.Application.Contracts.UnitOfWork;
using Inspection.Application.Services.ServicesBase;
using Inspection.Application.Shared.ExcelTemplate;
using Inspection.Domain.Models.DMS.FolderPermissions;
using NDS.Shared.Application.DataQuery;
using NDS.Shared.Application.Multitenant;
using NDS.Shared.Kernel.BaseReturnTypes;
using NDS.Shared.Kernel.Exceptions;

namespace Inspection.Application.Services.DMS.FolderPermissions
{
    internal class FolderPermissionService : AccountsServiceBase, IFolderPermissionService
    {
        private readonly ITenantResolver _tenantResolver;
        private readonly IExcelTemplateGenerator _templateGenerator;
        private readonly ISeriesService _seriesService;

        public FolderPermissionService(IAccountUnitOfWork accountUoW, IAccountsQueriesManager queriesManager, IMapper mapper, IExceptionManager exceptionManager, ITenantResolver tenantResolver, IExcelTemplateGenerator templateGenerator, ISeriesService seriesService) : base(accountUoW, queriesManager, mapper, exceptionManager)
        {
            _tenantResolver = tenantResolver;
            _templateGenerator = templateGenerator;
            _seriesService = seriesService;

        }
        public async Task<ReturnBase<FolderPermissionDto>> Create(
            FolderPermissionCreateDto createDto)
        {
            try
            {
                // DATE VALIDATION
                var validationErrors =
                    ValidatePermissionDates(createDto.ValidFrom, createDto.ValidUntil);

                if (validationErrors.Any())
                    return ReturnBase<FolderPermissionDto>.Fail(validationErrors);

                // Insert
                var entity = _mapper.Map<FolderPermission>(createDto);
                entity.Tenant_ID = _tenantResolver.GetTenantName();

                var insertResult = await _commands.InsertAsync(entity);

                if (!insertResult.Succeeded)
                    return ReturnBase<FolderPermissionDto>.Fail(insertResult.Errors);

                var saveResult = await _accountUoW.SaveAsync();

                if (!saveResult.Succeeded)
                    return ReturnBase<FolderPermissionDto>.Fail(saveResult.Errors);

                var resultDto = _mapper.Map<FolderPermissionDto>(entity);

                return ReturnBase<FolderPermissionDto>.Success(resultDto);
            }
            catch (Exception ex)
            {
                return ReturnBase<FolderPermissionDto>.Fail(ex, _exceptionManager);
            }
        }


        public async Task<ReturnBase<FolderPermissionDto>> Update(FolderPermissionUpdateDto updateDto)
        {
            try
            {
                var entity =
                    await _queriesManager.FolderPermission.GetById(updateDto.Id);

                if (entity is null)
                {
                    return ReturnBase<FolderPermissionDto>.Fail(new[]
                    {
                new ReturnBaseError
                {
                    ErrorCode = "404",
                    ErrorMessage =$"Folder Permission with Id '{updateDto.Id}' was not found."
                }
            });
                }

                // DATE VALIDATION
                var validationErrors =
                    ValidatePermissionDates(updateDto.ValidFrom, updateDto.ValidUntil);

                if (validationErrors.Any())
                    return ReturnBase<FolderPermissionDto>.Fail(validationErrors);

                entity.Tenant_ID = _tenantResolver.GetTenantName();

                // Map new values
                _mapper.Map(updateDto, entity);

                var updateResult = await _commands.UpdateAsync(entity);

                if (!updateResult.Succeeded)
                    return ReturnBase<FolderPermissionDto>.Fail(updateResult.Errors);

                var saveResult = await _accountUoW.SaveAsync();

                if (!saveResult.Succeeded)
                    return ReturnBase<FolderPermissionDto>.Fail(saveResult.Errors);

                var mappedResult = _mapper.Map<FolderPermissionDto>(entity);

                return ReturnBase<FolderPermissionDto>.Success(mappedResult);
            }
            catch (Exception ex)
            {
                return ReturnBase<FolderPermissionDto>.Fail(ex, _exceptionManager);
            }
        }


        public async Task<ReturnBase<FolderPermissionDto>> Delete(long id)
        {
            try
            {
                var entity = await _queriesManager.FolderPermission.GetById(id);
                if (entity is null)
                {
                    var error = new ReturnBaseError
                    {
                        ErrorCode = "404",
                        ErrorMessage = $"Folder Permission with Id '{id}' was not found."
                    };
                    var listOfErrors = new List<ReturnBaseError>() { error };
                    return ReturnBase<FolderPermissionDto>.Fail(listOfErrors);
                }

                var deleteResult = await _commands.DeleteById(id);

                if (!deleteResult.Succeeded)
                    return ReturnBase<FolderPermissionDto>.Fail(deleteResult.Errors);

                var saveResult = await _accountUoW.SaveAsync();

                if (!saveResult.Succeeded)
                    return ReturnBase<FolderPermissionDto>.Fail(saveResult.Errors);

                var mappedResult = _mapper.Map<FolderPermissionDto>(entity);

                return ReturnBase<FolderPermissionDto>.Success(mappedResult);

            }
            catch (Exception ex)
            {
                return ReturnBase<FolderPermissionDto>.Fail(ex, _exceptionManager);
            }
        }

        public async Task<ReturnBase<IEnumerable<FolderPermissionReturnSearchDto>>> Search(SqlQueryOptions sqlQueryOptions)
        {
            try
            {
                var tenantId = _tenantResolver.GetTenantName();
                var commonData = _tenantResolver.GetCommonUserData();

                long companyId = 2;

                if (commonData?.Company != null)
                {
                    long parsedCompanyId;
                    if (long.TryParse(commonData.Company, out parsedCompanyId))
                    {
                        companyId = parsedCompanyId;
                    }
                }

                var getResult = await _queriesManager.FolderPermission.Search(sqlQueryOptions, tenantId, companyId);
                if (!getResult.Succeeded)
                    return ReturnBase<IEnumerable<FolderPermissionReturnSearchDto>>.Fail(getResult.Errors);

                return ReturnBase<IEnumerable<FolderPermissionReturnSearchDto>>.Success(getResult.Result);
            }
            catch (Exception ex)
            {
                return ReturnBase<IEnumerable<FolderPermissionReturnSearchDto>>.Fail(ex, _exceptionManager);
            }
        }

        public async Task<ReturnBase<FolderPermissionDto>> GetById(long id)
        {
            try
            {
                var entity = await _queriesManager.FolderPermission.GetById(id);
                if (entity is null)
                {
                    var error = new ReturnBaseError
                    {
                        ErrorCode = "404",
                        ErrorMessage = $"Folder Permission with Id '{id}' was not found."
                    };
                    var listOfErrors = new List<ReturnBaseError>() { error };
                    return ReturnBase<FolderPermissionDto>.Fail(listOfErrors);
                }

                var mappedResult = _mapper.Map<FolderPermissionDto>(entity);

                return ReturnBase<FolderPermissionDto>.Success(mappedResult);
            }
            catch (Exception ex)
            {
                return ReturnBase<FolderPermissionDto>.Fail(ex, _exceptionManager);
            }
        }

        private List<ReturnBaseError> ValidatePermissionDates(DateTime? validFrom, DateTime? validUntil)
        {
            var errors = new List<ReturnBaseError>();

            // Rule 1: End date cannot be before start date
            if (validFrom.HasValue && validUntil.HasValue &&
                validUntil.Value < validFrom.Value)
            {
                errors.Add(new ReturnBaseError
                {
                    ErrorCode = "INVALID_DATE_RANGE",
                    ErrorMessage = "ValidUntil cannot be earlier than ValidFrom."
                });
            }

            // Rule 2 (optional but recommended)
            if (validUntil.HasValue && validUntil.Value < DateTime.UtcNow)
            {
                errors.Add(new ReturnBaseError
                {
                    ErrorCode = "EXPIRED_PERMISSION",
                    ErrorMessage = "ValidUntil cannot be in the past."
                });
            }

            return errors;
        }

        private IFolderPermissionCommandRepository _commands
        {
            get { return _accountUoW.FolderPermission; }
        }
    }
}