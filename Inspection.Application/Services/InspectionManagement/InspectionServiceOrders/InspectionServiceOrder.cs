using AutoMapper;
using Inspection.Application.Contracts.Dto.InspectionManagement.InspectionRequests;
using Inspection.Application.Contracts.Managers;
using Inspection.Application.Contracts.Repositories.Command.InspectionManagement.InspectionRequestDetailF;
using Inspection.Application.Contracts.Repositories.Command.InspectionManagement.InspectionRequestDetailSubcontractorF;
using Inspection.Application.Contracts.Repositories.Command.InspectionManagement.InspectionRequests;
using Inspection.Application.Contracts.Repositories.Query.SalesManagment.Transactions.SalesQuotations;
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

namespace Inspection.Application.Services.InspectionManagement.InspectionServiceOrders
{
    public class InspectionServiceOrder : AccountsServiceBase, IInspectionServiceOrder
    {
        private readonly ITenantResolver _tenantResolver;
        private readonly ISeriesService _seriesService;

        public InspectionServiceOrder(IAccountUnitOfWork accountUoW, IAccountsQueriesManager queriesManager,
            IMapper mapper, IExceptionManager exceptionManager, ITenantResolver tenantResolver,
            ISeriesService seriesService) : base(accountUoW, queriesManager, mapper, exceptionManager)
        {
            _tenantResolver = tenantResolver;
            _seriesService = seriesService;

        }
        private IInspectionRequestLinesCommandRepository _commandsRequestLines => _accountUoW.InspectionRequestLines;
        private IInspectionRequestDetailSubcontractorCommandRepository _commandsRequestDetailSubcontractor => _accountUoW.InspectionRequestDetailSubcontractor;
        private ISalesQuotationQueryRepository _salesQuotationQueriesMaster => _queriesManager.SalesQuotation;


        public async Task<List<InspectionRequestDtoByInclude>> GetListAsync()
        {

            var list = await _queriesManager.InspectionRequest.GetAllAsync();

            return _mapper.Map<List<InspectionRequestDtoByInclude>>(list.Result);
        }

        public async Task<ReturnBase<InspectionRequestDto>> InsertInspectionRequestAsync(CreateInspectionRequestDto insertDto)
        {
            try
            {
                var ruleError = ValidateInspectionRequestDates(
                    insertDto.RequestDate,
                    insertDto.RequestedInspectionDate);

                if (ruleError != null)
                {
                    return ReturnBase<InspectionRequestDto>.Fail(
                        new List<ReturnBaseError> { ruleError });
                }

                var entity = _mapper.Map<InspectionRequest>(insertDto);
                entity.Tenant_ID = _tenantResolver.GetTenantName();

                // SCREEN CODE FOR THIS MODULE
                const string SCREEN_CODE = "Inspection Request";

                // Get Series automatically by ScreenCode
                var series = await _queriesManager.Series.GetByScreen_IDAsync(SCREEN_CODE);

                if (series == null || !series.IsActive)
                {
                    return ReturnBase<InspectionRequestDto>.Fail(
                        new Exception($"No active series configured for screen '{SCREEN_CODE}'"),
                        _exceptionManager
                    );
                }

                entity.SeriesId = series.Id;

                // Generate series number (month/year aware)
                var seriesResult =
                    await _seriesService.GetSeriesCodeWithCustomDateUsingSeriesDetails(
                        series.Id,
                        entity.RequestDate
                    );

                if (!seriesResult.Succeeded || seriesResult.Result == null)
                {
                    return ReturnBase<InspectionRequestDto>.Fail(seriesResult.Errors);
                }

                entity.RequestNumber =
                    seriesResult.Result["FinelSeriesCodeAndSeriesNumber"];

                entity.RunningNumber =
                    int.Parse(seriesResult.Result["RunningNumber"]);

                foreach (var item in insertDto.InspectionRequestLines)
                {
                    var entityDetail = _mapper.Map<InspectionRequestLines>(item);
                    entity.InspectionRequestLines.Add(entityDetail);
                }

                // 🔹 Save entity
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

        public async Task<ReturnBase<InspectionRequestDto>> UpdateInspectionRequestAsync(UpdateInspectionRequestDto updateDto)
        {
            try
            {
                // Validate if request used in quotation
                var existsInQuotation = await _queriesManager.SalesQuotation
                    .GetByInspectionRequestId(updateDto.Id);

                if (existsInQuotation != null)
                {
                    return ReturnBase<InspectionRequestDto>.Fail(new List<ReturnBaseError>
                    {
                        new()
                        {
                            ErrorCode = "VALIDATION",
                            ErrorMessage = "This Inspection Service Order is already used in Sales Quotation and cannot be edited."
                        }
                    });
                }

                var ruleError = ValidateInspectionRequestDates(
                        updateDto.RequestDate,
                        updateDto.RequestedInspectionDate);

                if (ruleError != null)
                {
                    return ReturnBase<InspectionRequestDto>.Fail(
                        new List<ReturnBaseError> { ruleError });
                }
                var entity = await _queriesManager.InspectionRequest.GetByIdAsync(updateDto.Id);

                if (entity is null)
                {
                    var error = new ReturnBaseError
                    {
                        ErrorCode = "404",
                        ErrorMessage = "Inspection Service Order Not Found"
                    };
                    var listOfErrors = new List<ReturnBaseError>() { error };
                    return ReturnBase<InspectionRequestDto>.Fail(listOfErrors);
                }

                // Update request fields

                _mapper.Map(updateDto, entity);
                entity.InspectionRequestLines = null;

                var updateResult = await _commands.UpdateAsync(entity);
                if (!updateResult.Succeeded)

                    return ReturnBase<InspectionRequestDto>.Fail(updateResult.Errors);

                List<InspectionRequestLines> finalDet = new List<InspectionRequestLines>();

                // Update details
                foreach (var detail in updateDto.InspectionRequestLines)
                {
                    detail.InspectionRequestId = entity.Id;


                    var existing = await _queriesManager.InspectionRequestLines.GetByIdAsync(detail.Id);


                    if (existing == null)
                    {
                        var insdetails = _mapper.Map<InspectionRequestLines>(detail);
                        var insertResultdet = await _commandsRequestLines.InsertAsync(insdetails);
                        if (!insertResultdet.Succeeded)
                        {
                            return ReturnBase<InspectionRequestDto>.Fail(insertResultdet.Errors);
                        }

                        finalDet.Add(insdetails);

                    }
                    else
                    {
                        _mapper.Map(detail, existing);
                        var updateResultdet = await _commandsRequestLines.UpdateAsync(existing);
                        if (!updateResultdet.Succeeded)
                        {
                            return ReturnBase<InspectionRequestDto>.Fail(updateResultdet.Errors);
                        }


                        finalDet.Add(existing);
                    }


                }

                var saveResult = await _accountUoW.SaveAsync();
                if (!saveResult.Succeeded)
                    return ReturnBase<InspectionRequestDto>.Fail(saveResult.Errors);
                entity.InspectionRequestLines = finalDet;

                var mappedResult = _mapper.Map<InspectionRequestDto>(entity);
                return ReturnBase<InspectionRequestDto>.Success(mappedResult);
            }

            catch (Exception ex)
            {
                return ReturnBase<InspectionRequestDto>.Fail(ex, _exceptionManager);
            }
        }

        private ReturnBaseError? ValidateInspectionRequestDates(
            DateTime requestDate,
            DateTime? requestedInspectionDate)
        {
            if (requestDate.Date > DateTime.UtcNow.Date)
            {
                return new ReturnBaseError
                {
                    ErrorCode = "INVALID_REQUEST_DATE",
                    ErrorMessage = "Request Date cannot be in the future."
                };
            }

            if (!requestedInspectionDate.HasValue)
                return null;

            if (requestedInspectionDate.Value.Date < requestDate.Date)
            {
                return new ReturnBaseError
                {
                    ErrorCode = "INVALID_INSPECTION_DATE",
                    ErrorMessage = "Requested Inspection Date must be greater than or equal to Request Date."
                };
            }

            if (requestedInspectionDate.Value.Date < DateTime.UtcNow.Date)
            {
                return new ReturnBaseError
                {
                    ErrorCode = "PAST_INSPECTION_DATE",
                    ErrorMessage = "Requested Inspection Date cannot be in the past."
                };
            }

            return null;
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
                        ErrorMessage = "Inspection Service Order Not Found"
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
                        ErrorMessage = "Inspection Service Order Not Found"
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


        public async Task<ReturnBase<IEnumerable<InspectionRequestDtoLookUpForNames>>> GetLookUpInspectionRequestForNamesAsync(SqlQueryOptions sqlQueryOptions)
        {
            var result = await this._queriesManager.InspectionRequest.GetLookUpInspectionRequestForNamesAsync(sqlQueryOptions);

            var mappedResult = _mapper.Map<IEnumerable<InspectionRequestDtoLookUpForNames>>(result.Result);

            return ReturnBase<IEnumerable<InspectionRequestDtoLookUpForNames>>.Success(mappedResult);

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

        public Task<ReturnBase<List<InspectionRequestLookupDto>>> GetRequestNumbersForDropdownAsync()
        {
            throw new NotImplementedException();
        }

        private IInspectionRequestCommandRepository _commands
        {
            get { return _accountUoW.InspectionRequest; }
        }


        // Change Document Status
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

                // Check if this InspectionRequest exists in any SalesQuotation
                var salesQuotation = await _salesQuotationQueriesMaster.GetByInspectionRequestId(entity.Id);

                if (salesQuotation != null && salesQuotation.DocumentStatus == SalesQuotationDocumentStatus.Sent)
                {
                    // If SalesQuotation exists and is Sent, InspectionRequest cannot go back to Draft
                    if (dto.DocumentStatus == InspectionDocumentStatus.Draft)
                    {
                        return ReturnBase<bool>.Fail(new List<ReturnBaseError>
                        {
                            new()
                            {
                                ErrorCode = "VALIDATION",
                                ErrorMessage = "Cannot revert Inspection Service Order to Draft because related Sales Quotation is already Sent."
                            }
                        });
                    }

                    // Force status to QuotationIssued if it's not Draft
                    entity.DocumentStatus = InspectionDocumentStatus.QuotationIssued;
                }
                else
                {
                    // Normal validation rule for cancellation
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

                    entity.DocumentStatus = dto.DocumentStatus;
                    entity.DocumentStatusCancelledDescription =
                        dto.DocumentStatus == InspectionDocumentStatus.Cancelled
                            ? dto.CancelledDescription ?? string.Empty
                            : string.Empty;
                }

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
    }
}
