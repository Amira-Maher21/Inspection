using AutoMapper;
using Inspection.Application.Contracts.Dto.InspectionManagement.InspectionRequests;
using Inspection.Application.Contracts.Managers;
using Inspection.Application.Contracts.Repositories.Command.InspectionManagement.InspectionRequests;
using Inspection.Application.Contracts.Services.InspectionManagement.InspectionRequests;
using Inspection.Application.Contracts.Services.MenuManagement.SeriesF;
using Inspection.Application.Contracts.UnitOfWork;
using Inspection.Application.Services.ServicesBase;
using Inspection.Domain.Enums;
using Inspection.Domain.Models.InspectionManagement.InspectionRequests;
using Inspection.Domain.Models.InspectionManagement.InspectionRequests.Transaction.DTOs;
using NDS.Shared.Application.DataQuery;
using NDS.Shared.Application.Multitenant;
using NDS.Shared.Kernel.BaseReturnTypes;
using NDS.Shared.Kernel.Exceptions;

namespace Inspection.Application.Services.InspectionManagement.InspectionRequests
{
    public class InspectionRequestService : AccountsServiceBase, IInspectionRequestService
    {
        private readonly ITenantResolver _tenantResolver;
        private readonly ISeriesService _seriesService;

        public InspectionRequestService(IAccountUnitOfWork accountUoW,
            IAccountsQueriesManager queriesManager,
            IMapper mapper,
            IExceptionManager exceptionManager,
            ITenantResolver tenantResolver, ISeriesService seriesService) : base(accountUoW, queriesManager, mapper, exceptionManager)
        {
            _tenantResolver = tenantResolver;
            _seriesService = seriesService;

        }

        public async Task<List<InspectionRequestDtoByInclude>> GetListAsync()
        {

            var list = await _queriesManager.InspectionRequest.GetAllAsync();

            return _mapper.Map<List<InspectionRequestDtoByInclude>>(list.Result);
        }

        public async Task<ReturnBase<InspectionRequestDto>> InsertInspectionRequestAsync(CreateInspectionRequestDto insertDto)
        {
            try
            {
                var entity = _mapper.Map<InspectionRequest>(insertDto);
                entity.Tenant_ID = _tenantResolver.GetTenantName();

                // AUTO RESOLVE SERIES USING SCREEN CODE
                const string SCREEN_CODE = "Inspection Request";

                var series = await _seriesService.GetSeriesByScreenCodeAsync(SCREEN_CODE);

                if (series == null)
                {
                    return ReturnBase<InspectionRequestDto>.Fail(
                        new Exception($"No series configured for screen {SCREEN_CODE}"),
                        _exceptionManager
                    );
                }

                entity.SeriesId = series.Id;

                // Generate Request Number
                var seriesResult =
                    await _seriesService.GetSeriesCodeWithCustomDateUsingSeriesDetails(
                        series.Id,
                        entity.RequestDate
                    );

                if (!seriesResult.Succeeded)
                    return ReturnBase<InspectionRequestDto>.Fail(seriesResult.Errors);

                entity.RequestNumber =
                    seriesResult.Result["FinelSeriesCodeAndSeriesNumber"];

                entity.RunningNumber =
                    int.Parse(seriesResult.Result["RunningNumber"]);

                // 💾 Save
                var insertResult = await _commands.InsertAsync(entity);
                if (!insertResult.Succeeded)
                    return ReturnBase<InspectionRequestDto>.Fail(insertResult.Errors);

                var saveResult = await _accountUoW.SaveAsync();
                if (!saveResult.Succeeded)
                    return ReturnBase<InspectionRequestDto>.Fail(saveResult.Errors);

                return ReturnBase<InspectionRequestDto>.Success(
                    _mapper.Map<InspectionRequestDto>(entity)
                );
            }
            catch (Exception ex)
            {
                return ReturnBase<InspectionRequestDto>.Fail(ex, _exceptionManager);
            }
        }

        public async Task<ReturnBase<InspectionRequestDto>> UpdateInspectionRequestAsync(UpdateInspectionRequestDto updateDto, long id)
        {
            try
            {
                var entity = await _queriesManager.InspectionRequest.GetByIdAsync(id);

                if (entity is null)
                {
                    var error = new ReturnBaseError
                    {
                        ErrorCode = "404",
                        ErrorMessage = "Inspection Request Not Found"
                    };
                    var listOfErrors = new List<ReturnBaseError>() { error };
                    return ReturnBase<InspectionRequestDto>.Fail(listOfErrors);
                }
                // Update request fields
                entity.Tenant_ID = _tenantResolver.GetTenantName();
                _mapper.Map(updateDto, entity);

                var updateResult = await _commands.UpdateAsync(entity);
                if (!updateResult.Succeeded)

                    return ReturnBase<InspectionRequestDto>.Fail(updateResult.Errors);


                var saveResult = await _accountUoW.SaveAsync();
                if (!saveResult.Succeeded)
                    return ReturnBase<InspectionRequestDto>.Fail(saveResult.Errors);

                var mappedResult = _mapper.Map<InspectionRequestDto>(entity);
                return ReturnBase<InspectionRequestDto>.Success(mappedResult);
            }

            catch (Exception ex)
            {
                return ReturnBase<InspectionRequestDto>.Fail(ex, _exceptionManager);
            }
        }

        public async Task<ReturnBase<InspectionRequestDto>> DeleteInspectionRequestAsync(long id)
        {
            try
            {
                var entity = await _queriesManager.InspectionRequest.GetByIdAsync(id);
                if (entity is null)
                {
                    var error = new ReturnBaseError
                    {
                        ErrorCode = "404",
                        ErrorMessage = "Inspection Request Not Found"
                    };
                    var listOfErrors = new List<ReturnBaseError>() { error };
                    return ReturnBase<InspectionRequestDto>.Fail(listOfErrors);
                }

                var deleteResult = await _commands.DeleteByIdAsync(id);

                if (!deleteResult.Succeeded)
                    return ReturnBase<InspectionRequestDto>.Fail(deleteResult.Errors);

                var saveResult = await _accountUoW.SaveAsync();

                if (!saveResult.Succeeded)
                    return ReturnBase<InspectionRequestDto>.Fail(saveResult.Errors);

                var mappedResult = _mapper.Map<InspectionRequestDto>(entity);

                return ReturnBase<InspectionRequestDto>.Success(mappedResult);

            }
            catch (Exception ex)
            {
                return ReturnBase<InspectionRequestDto>.Fail(ex, _exceptionManager);
            }
        }

        public async Task<ReturnBase<InspectionRequestDto>> GetInspectionRequestByIdAsync(long id)
        {
            try
            {
                var entity = await _queriesManager.InspectionRequest.GetByIdAsync(id);
                if (entity is null)
                {
                    var error = new ReturnBaseError
                    {
                        ErrorCode = "404",
                        ErrorMessage = "Inspection Request Not Found"
                    };
                    var listOfErrors = new List<ReturnBaseError>() { error };
                    return ReturnBase<InspectionRequestDto>.Fail(listOfErrors);
                }

                var mappedResult = _mapper.Map<InspectionRequestDto>(entity);

                return ReturnBase<InspectionRequestDto>.Success(mappedResult);
            }
            catch (Exception ex)
            {
                return ReturnBase<InspectionRequestDto>.Fail(ex, _exceptionManager);
            }
        }

        public async Task<ReturnBase<IEnumerable<InspectionRequestDtoByInclude>>> GetInspectionRequestListByIncludeAsync(SqlQueryOptions sqlQueryOptions)
        {
            try
            {
                var getResult = await _queriesManager.InspectionRequest.GetListIncldeNameAsync(sqlQueryOptions);
                if (!getResult.Succeeded)
                    return ReturnBase<IEnumerable<InspectionRequestDtoByInclude>>.Fail(getResult.Errors);

                return ReturnBase<IEnumerable<InspectionRequestDtoByInclude>>.Success(_mapper.Map<IEnumerable<InspectionRequestDtoByInclude>>(getResult.Result));
            }
            catch (Exception ex)
            {
                return ReturnBase<IEnumerable<InspectionRequestDtoByInclude>>.Fail(ex, _exceptionManager);
            }

        }

        public async Task<ReturnBase<IEnumerable<InspectionRequestDtoLookUpForNames>>> GetLookUpInspectionRequestForNamesAsync(SqlQueryOptions queryOptions)
        {
            var result = await this._queriesManager.InspectionRequest.GetLookUpInspectionRequestForNamesAsync(queryOptions);

            var mappedResult = _mapper.Map<IEnumerable<InspectionRequestDtoLookUpForNames>>(result.Result);

            return ReturnBase<IEnumerable<InspectionRequestDtoLookUpForNames>>.Success(mappedResult);

        }


        public async Task<ReturnBase<List<InspectionRequestDtoLookUpForRequestDetails>>> GetRequestDetailsAsync(long id)
        {


            try
            {
                var entity = await _queriesManager.InspectionRequest.GetRequestDetailsAsync(id);
                if (entity is null)
                {
                    var error = new ReturnBaseError
                    {
                        ErrorCode = "404",
                        ErrorMessage = " Not Found"
                    };
                    var listOfErrors = new List<ReturnBaseError>() { error };
                    return ReturnBase<List<InspectionRequestDtoLookUpForRequestDetails>>.Fail(listOfErrors);
                }

                var mappedResult = _mapper.Map<List<InspectionRequestDtoLookUpForRequestDetails>>(entity);

                return ReturnBase<List<InspectionRequestDtoLookUpForRequestDetails>>.Success(mappedResult);
            }
            catch (Exception ex)
            {
                return ReturnBase<List<InspectionRequestDtoLookUpForRequestDetails>>.Fail(ex, _exceptionManager);
            }
        }



        public async Task<ReturnBase<bool>> ChangeStatus(long id, ChangeInspectionApprovalStatus Status)
        {
            try
            {
                var entityMaster = await _queriesManager.InspectionRequest.GetByIdAsync(id);
                if (entityMaster == null)
                    return ReturnBase<bool>.Fail();
                entityMaster.ApprovalStatus = Status.ApprovalStatus;
                var updateResultMaster = await _commands.UpdateAsync(entityMaster);
                var saveResult = await _accountUoW.SaveAsync();
                if (!saveResult.Succeeded)
                    return ReturnBase<bool>.Fail(saveResult.Errors);
                return ReturnBase<bool>.Success(true);
            }
            catch (Exception ex)
            {
                return ReturnBase<bool>.Fail(ex, _exceptionManager);
            }


        }

        public async Task<ReturnBase<List<InspectionRequestLookupDto>>> GetRequestNumbersForDropdownAsync()
        {
            try
            {
                return await this._queriesManager.InspectionRequest.GetRequestNumbersForDropdownAsync();
            }
            catch (Exception ex)
            {
                return ReturnBase<List<InspectionRequestLookupDto>>.Fail(ex, _exceptionManager);
            }
        }

        public async Task<ReturnBase<bool>> ChangeDocumentStatusAsync(ChangeInspectionRequestDocumentStatusDto dto)
        {
            try
            {
                var entity = await _queriesManager.InspectionRequest.GetByIdAsync(dto.RequestId);

                if (entity == null)
                {
                    return ReturnBase<bool>.Fail(new List<ReturnBaseError>
                    {
                        new()
                        {
                            ErrorCode = "404",
                            ErrorMessage = "Inspection Service Order Not Found"
                        }
                    });
                }

                // Validation rule
                if (dto.DocumentStatus == InspectionDocumentStatus.Cancelled &&
                    string.IsNullOrWhiteSpace(dto.CancelledDescription))
                {
                    return ReturnBase<bool>.Fail(new List<ReturnBaseError>
                    {
                        new()
                        {
                            ErrorCode = "VALIDATION",
                            ErrorMessage = "Cancellation description is required when document is cancelled"
                        }
                    });
                }

                // Apply changes
                entity.DocumentStatus = dto.DocumentStatus;
                entity.DocumentStatusCancelledDescription =
                    dto.DocumentStatus == InspectionDocumentStatus.Cancelled
                        ? dto.CancelledDescription ?? string.Empty
                        : string.Empty;

                var updateResult = await _commands.UpdateAsync(entity);
                if (!updateResult.Succeeded)
                    return ReturnBase<bool>.Fail(updateResult.Errors);

                var saveResult = await _accountUoW.SaveAsync();
                if (!saveResult.Succeeded)
                    return ReturnBase<bool>.Fail(saveResult.Errors);

                return ReturnBase<bool>.Success(true);
            }
            catch (Exception ex)
            {
                return ReturnBase<bool>.Fail(ex, _exceptionManager);
            }
        }


        private IInspectionRequestCommandRepository _commands
        {
            get { return _accountUoW.InspectionRequest; }
        }


    }
}
