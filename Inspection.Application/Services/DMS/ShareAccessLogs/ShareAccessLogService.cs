using AutoMapper;
using Inspection.Application.Contracts.Dto.DMSDTOs.ShareAccessLogs;
using Inspection.Application.Contracts.Managers;
using Inspection.Application.Contracts.Repositories.Command.DMS.ShareAccessLogs;
using Inspection.Application.Contracts.Services.DMS.ShareAccessLogs;
using Inspection.Application.Contracts.Services.MenuManagement.SeriesF;
using Inspection.Application.Contracts.UnitOfWork;
using Inspection.Application.Services.ServicesBase;
using Inspection.Application.Shared.ExcelTemplate;
using Inspection.Domain.Models.DMS.ShareAccessLogs;
using NDS.Shared.Application.DataQuery;
using NDS.Shared.Application.Multitenant;
using NDS.Shared.Kernel.BaseReturnTypes;
using NDS.Shared.Kernel.Exceptions;

namespace Inspection.Application.Services.DMS.ShareAccessLogs
{

    internal class ShareAccessLogService : AccountsServiceBase, IShareAccessLogService
    {
        private readonly ITenantResolver _tenantResolver;
        private readonly IExcelTemplateGenerator _templateGenerator;
        private readonly ISeriesService _seriesService;

        public ShareAccessLogService(IAccountUnitOfWork accountUoW, IAccountsQueriesManager queriesManager, IMapper mapper, IExceptionManager exceptionManager, ITenantResolver tenantResolver, IExcelTemplateGenerator templateGenerator, ISeriesService seriesService) : base(accountUoW, queriesManager, mapper, exceptionManager)
        {
            _tenantResolver = tenantResolver;
            _templateGenerator = templateGenerator;
            _seriesService = seriesService;

        }
        public async Task<ReturnBase<IEnumerable<ShareAccessLogDto>>> GetList(SqlQueryOptions? sqlQueryOptions = null)
        {
            try
            {
                var entities = await _queriesManager.ShareAccessLog.GetList(sqlQueryOptions);

                var mappedResult = _mapper.Map<IEnumerable<ShareAccessLogDto>>(entities);

                return ReturnBase<IEnumerable<ShareAccessLogDto>>.Success(mappedResult);
            }
            catch (Exception ex)
            {
                return ReturnBase<IEnumerable<ShareAccessLogDto>>.Fail(ex, _exceptionManager);
            }
        }
        public async Task<ReturnBase<ShareAccessLogDto>> Create(ShareAccessLogCreateDto createDto)
        {
            try
            {
                var entity = _mapper.Map<ShareAccessLog>(createDto);
                entity.Tenant_ID = _tenantResolver.GetTenantName();

                // Insert
                var insertResult = await _commands.InsertAsync(entity);

                if (!insertResult.Succeeded)
                    return ReturnBase<ShareAccessLogDto>.Fail(insertResult.Errors);

                var saveResult = await _accountUoW.SaveAsync();

                if (!saveResult.Succeeded)
                    return ReturnBase<ShareAccessLogDto>.Fail(saveResult.Errors);

                var resultDto = _mapper.Map<ShareAccessLogDto>(entity);

                return ReturnBase<ShareAccessLogDto>.Success(resultDto);
            }
            catch (Exception ex)
            {
                return ReturnBase<ShareAccessLogDto>.Fail(ex, _exceptionManager);
            }
        }

        public async Task<ReturnBase<ShareAccessLogDto>> Update(ShareAccessLogUpdateDto updateDto)
        {
            try
            {
                var entity = await _queriesManager.ShareAccessLog.GetById(updateDto.Id);

                if (entity is null)
                {
                    return ReturnBase<ShareAccessLogDto>.Fail(new[]
                    {
                new ReturnBaseError
                {
                    ErrorCode = "404",
                    ErrorMessage =$"Share AccessLog with Id '{updateDto.Id}' was not found."
                }
            });
                }

                entity.Tenant_ID = _tenantResolver.GetTenantName();

                _mapper.Map(updateDto, entity);

                var updateResult = await _commands.UpdateAsync(entity);

                if (!updateResult.Succeeded)
                    return ReturnBase<ShareAccessLogDto>.Fail(updateResult.Errors);

                var saveResult = await _accountUoW.SaveAsync();

                if (!saveResult.Succeeded)
                    return ReturnBase<ShareAccessLogDto>.Fail(saveResult.Errors);

                var mappedResult = _mapper.Map<ShareAccessLogDto>(entity);

                return ReturnBase<ShareAccessLogDto>.Success(mappedResult);
            }
            catch (Exception ex)
            {
                return ReturnBase<ShareAccessLogDto>.Fail(ex, _exceptionManager);
            }
        }

        public async Task<ReturnBase<ShareAccessLogDto>> Delete(long id)
        {
            try
            {
                var entity = await _queriesManager.ShareAccessLog.GetById(id);
                if (entity is null)
                {
                    var error = new ReturnBaseError
                    {
                        ErrorCode = "404",
                        ErrorMessage = $"ShareAccessLog with Id '{id}' was not found."
                    };
                    var listOfErrors = new List<ReturnBaseError>() { error };
                    return ReturnBase<ShareAccessLogDto>.Fail(listOfErrors);
                }

                var deleteResult = await _commands.DeleteById(id);

                if (!deleteResult.Succeeded)
                    return ReturnBase<ShareAccessLogDto>.Fail(deleteResult.Errors);

                var saveResult = await _accountUoW.SaveAsync();

                if (!saveResult.Succeeded)
                    return ReturnBase<ShareAccessLogDto>.Fail(saveResult.Errors);

                var mappedResult = _mapper.Map<ShareAccessLogDto>(entity);

                return ReturnBase<ShareAccessLogDto>.Success(mappedResult);

            }
            catch (Exception ex)
            {
                return ReturnBase<ShareAccessLogDto>.Fail(ex, _exceptionManager);
            }
        }

        public async Task<ReturnBase<IEnumerable<ShareAccessLogReturnSearchDto>>> Search(SqlQueryOptions sqlQueryOptions)
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

                var getResult = await _queriesManager.ShareAccessLog.Search(sqlQueryOptions);
                if (!getResult.Succeeded)
                    return ReturnBase<IEnumerable<ShareAccessLogReturnSearchDto>>.Fail(getResult.Errors);

                return ReturnBase<IEnumerable<ShareAccessLogReturnSearchDto>>.Success(getResult.Result);
            }
            catch (Exception ex)
            {
                return ReturnBase<IEnumerable<ShareAccessLogReturnSearchDto>>.Fail(ex, _exceptionManager);
            }
        }

        public async Task<ReturnBase<ShareAccessLogDto>> GetById(long id)
        {
            try
            {
                var entity = await _queriesManager.ShareAccessLog.GetById(id);
                if (entity is null)
                {
                    var error = new ReturnBaseError
                    {
                        ErrorCode = "404",
                        ErrorMessage = $"Share AccessLog with Id '{id}' was not found."
                    };
                    var listOfErrors = new List<ReturnBaseError>() { error };
                    return ReturnBase<ShareAccessLogDto>.Fail(listOfErrors);
                }

                var mappedResult = _mapper.Map<ShareAccessLogDto>(entity);

                return ReturnBase<ShareAccessLogDto>.Success(mappedResult);
            }
            catch (Exception ex)
            {
                return ReturnBase<ShareAccessLogDto>.Fail(ex, _exceptionManager);
            }
        }

        private IShareAccessLogCommandRepository _commands
        {
            get { return _accountUoW.ShareAccessLog; }
        }
    }

}
