using AutoMapper;
using Inspection.Application.Contracts.Dto.DMSDTOs.FolderDTOs;
using Inspection.Application.Contracts.Managers;
using Inspection.Application.Contracts.Repositories.Command.DMS.Folders;
using Inspection.Application.Contracts.Services.DMS.Folders;
using Inspection.Application.Contracts.Services.MenuManagement.SeriesF;
using Inspection.Application.Contracts.UnitOfWork;
using Inspection.Application.Services.ServicesBase;
using Inspection.Application.Shared.ExcelTemplate;
using Inspection.Domain.Enums.DMS.FolderEnums;
using Inspection.Domain.Models.DMS.Folders;
using NDS.Shared.Application.DataQuery;
using NDS.Shared.Application.Multitenant;
using NDS.Shared.Kernel.BaseReturnTypes;
using NDS.Shared.Kernel.Exceptions;

namespace Inspection.Application.Services.DMS.Folders
{
    internal class FolderService : AccountsServiceBase, IFolderService
    {
        private readonly ITenantResolver _tenantResolver;
        private readonly IExcelTemplateGenerator _templateGenerator;
        private readonly ISeriesService _seriesService;

        public FolderService(IAccountUnitOfWork accountUoW, IAccountsQueriesManager queriesManager, IMapper mapper, IExceptionManager exceptionManager, ITenantResolver tenantResolver, IExcelTemplateGenerator templateGenerator, ISeriesService seriesService) : base(accountUoW, queriesManager, mapper, exceptionManager)
        {
            _tenantResolver = tenantResolver;
            _templateGenerator = templateGenerator;
            _seriesService = seriesService;

        }
        public async Task<ReturnBase<FolderDto>> Create(FolderCreateDto createDto)
        {
            try
            {
                var entity = _mapper.Map<Folder>(createDto);
                entity.Tenant_ID = _tenantResolver.GetTenantName();

                // Validation 
                var validationResult = await ValidateFolderInternal(entity, null);

                if (!validationResult.Succeeded)
                    return ReturnBase<FolderDto>.Fail(validationResult.Errors);

                // Insert
                var insertResult = await _commands.InsertAsync(entity);

                if (!insertResult.Succeeded)
                    return ReturnBase<FolderDto>.Fail(insertResult.Errors);

                var saveResult = await _accountUoW.SaveAsync();

                if (!saveResult.Succeeded)
                    return ReturnBase<FolderDto>.Fail(saveResult.Errors);

                var resultDto = _mapper.Map<FolderDto>(entity);

                return ReturnBase<FolderDto>.Success(resultDto);
            }
            catch (Exception ex)
            {
                return ReturnBase<FolderDto>.Fail(ex, _exceptionManager);
            }
        }

        public async Task<ReturnBase<FolderDto>> Update(FolderUpdateDto updateDto)
        {
            try
            {
                var entity = await _queriesManager.Folder.GetById(updateDto.Id);

                if (entity is null)
                {
                    return ReturnBase<FolderDto>.Fail(new[]
                    {
                new ReturnBaseError
                {
                    ErrorCode = "404",
                    ErrorMessage = "Folder Not Found"
                }
            });
                }

                entity.Tenant_ID = _tenantResolver.GetTenantName();

                // Map new values
                _mapper.Map(updateDto, entity);

                // Validation
                var validationResult = await ValidateFolderInternal(entity, entity.Id);

                if (!validationResult.Succeeded)
                    return ReturnBase<FolderDto>.Fail(validationResult.Errors);

                // Update
                var updateResult = await _commands.UpdateAsync(entity);

                if (!updateResult.Succeeded)
                    return ReturnBase<FolderDto>.Fail(updateResult.Errors);

                var saveResult = await _accountUoW.SaveAsync();

                if (!saveResult.Succeeded)
                    return ReturnBase<FolderDto>.Fail(saveResult.Errors);

                var mappedResult = _mapper.Map<FolderDto>(entity);

                return ReturnBase<FolderDto>.Success(mappedResult);
            }
            catch (Exception ex)
            {
                return ReturnBase<FolderDto>.Fail(ex, _exceptionManager);
            }
        }



        public async Task<ReturnBase<FolderDto>> Delete(long id)
        {
            try
            {
                var entity = await _queriesManager.Folder.GetById(id);
                if (entity is null)
                {
                    var error = new ReturnBaseError
                    {
                        ErrorCode = "404",
                        ErrorMessage = "Folder Not Found"
                    };
                    var listOfErrors = new List<ReturnBaseError>() { error };
                    return ReturnBase<FolderDto>.Fail(listOfErrors);
                }

                var deleteResult = await _commands.DeleteById(id);

                if (!deleteResult.Succeeded)
                    return ReturnBase<FolderDto>.Fail(deleteResult.Errors);

                var saveResult = await _accountUoW.SaveAsync();

                if (!saveResult.Succeeded)
                    return ReturnBase<FolderDto>.Fail(saveResult.Errors);

                var mappedResult = _mapper.Map<FolderDto>(entity);

                return ReturnBase<FolderDto>.Success(mappedResult);

            }
            catch (Exception ex)
            {
                return ReturnBase<FolderDto>.Fail(ex, _exceptionManager);
            }
        }

        public async Task<ReturnBase<IEnumerable<FolderReturnSearchDto>>> Search(SqlQueryOptions sqlQueryOptions)
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

                var getResult = await _queriesManager.Folder.Search(sqlQueryOptions, tenantId, companyId);
                if (!getResult.Succeeded)
                    return ReturnBase<IEnumerable<FolderReturnSearchDto>>.Fail(getResult.Errors);

                return ReturnBase<IEnumerable<FolderReturnSearchDto>>.Success(getResult.Result);
            }
            catch (Exception ex)
            {
                return ReturnBase<IEnumerable<FolderReturnSearchDto>>.Fail(ex, _exceptionManager);
            }
        }

        public async Task<ReturnBase<FolderDto>> GetById(long id)
        {
            try
            {
                var entity = await _queriesManager.Folder.GetById(id);
                if (entity is null)
                {
                    var error = new ReturnBaseError
                    {
                        ErrorCode = "404",
                        ErrorMessage = "Folder Not Found"
                    };
                    var listOfErrors = new List<ReturnBaseError>() { error };
                    return ReturnBase<FolderDto>.Fail(listOfErrors);
                }

                var mappedResult = _mapper.Map<FolderDto>(entity);

                return ReturnBase<FolderDto>.Success(mappedResult);
            }
            catch (Exception ex)
            {
                return ReturnBase<FolderDto>.Fail(ex, _exceptionManager);
            }
        }

        private async Task<ReturnBase<bool>> ValidateFolderInternal(
       Folder entity,
       long? ignoreId)
        {
            var errors = new List<ReturnBaseError>();

            // Rule 1: ERPLink requires LinkedEntityId
            if (entity.FolderType == FolderType.ERPLink &&
                entity.LinkedEntityId == null)
            {
                errors.Add(new ReturnBaseError
                {
                    ErrorCode = "LINKED_ENTITY_REQUIRED",
                    ErrorMessage = "LinkedEntityId is required when FolderType is ERPLink."
                });
            }

            // Rule 2: Duplicate Name Check
            var duplicateExists =
                await _commands.ExistsDuplicateNameAsync(
                    entity.Tenant_ID,
                    entity.CompanyId,
                    entity.ParentFolderId,
                    entity.Name,
                    ignoreId);

            if (duplicateExists)
            {
                errors.Add(new ReturnBaseError
                {
                    ErrorCode = "DUPLICATE_FOLDER",
                    ErrorMessage = "A folder with the same name already exists in this parent folder."
                });
            }

            if (errors.Any())
                return ReturnBase<bool>.Fail(errors);

            return ReturnBase<bool>.Success(true);
        }

        private IFolderCommandRepository _commands
        {
            get { return _accountUoW.Folder; }
        }
    }
}