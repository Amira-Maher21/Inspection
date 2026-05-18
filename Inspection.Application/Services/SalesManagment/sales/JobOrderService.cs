using AutoMapper;
using Inspection.Application.Contracts.Dto.SalesManagment.sales.JobOrderF;
using Inspection.Application.Contracts.Managers;
using Inspection.Application.Contracts.Repositories.Command.SalesManagment.sales;
using Inspection.Application.Contracts.Repositories.Query.SalesManagment.sales;
using Inspection.Application.Contracts.Services.MenuManagement.SeriesF;
using Inspection.Application.Contracts.Services.SalesManagment.sales;
using Inspection.Application.Contracts.UnitOfWork;
using Inspection.Application.Services.ServicesBase;
using Inspection.Domain.Models.Inspection.Techinal.JobOrder;
using Inspection.Domain.Models.SalesManagment.Transaction.DTOs;
using NDS.Shared.Application.DataQuery;
using NDS.Shared.Application.Multitenant;
using NDS.Shared.Application.SharedModels;
using NDS.Shared.Kernel.BaseReturnTypes;
using NDS.Shared.Kernel.Exceptions;

namespace Inspection.Application.Services.SalesManagment.sales
{
    public class JobOrderService : AccountsServiceBase, IJobOrderService
    {
        private readonly ITenantResolver _tenantResolver;
        private readonly ISeriesService _seriesService;
        public JobOrderService(IAccountUnitOfWork accountUoW, IAccountsQueriesManager queriesManager,
            IMapper mapper, IExceptionManager exceptionManager,
            ITenantResolver tenantResolver, ISeriesService seriesService) : base(accountUoW, queriesManager, mapper, exceptionManager)
        {
            _tenantResolver = tenantResolver;
            _seriesService = seriesService;
        }

        private IJobOrderCommandRepository _commands => _accountUoW.JobOrder;
        private IJobOrderDetailCommandRepository _commandsJobOrderDetails => _accountUoW.JobOrderDetail;
        private IJobOrderQueryRepository _queries => _queriesManager.JobOrder;

        public async Task<ReturnBase<JobOrderDto>> CreateAsync(CreateJobOrderDto input)
        {
            try
            {
                // at least one related document is required
                if (!input.InspectionRequestId.HasValue &&
                    !input.QuotationId.HasValue &&
                    !input.SalesOrderId.HasValue)
                {
                    return ReturnBase<JobOrderDto>.Fail(
                        new Exception("At least one related document must be selected: Inspection Request, Quotation, or Sales Order."),
                        _exceptionManager
                    );
                }


                var entity = _mapper.Map<JobOrder>(input);
                var TenantName = _tenantResolver.GetTenantName();
                entity.Tenant_ID = TenantName;


                entity.JobOrderLines = new List<JobOrderLine>();


                // Series
                const string SCREEN_CODE = "Job order";
                var series = await _queriesManager.Series.GetByScreen_IDAsync(SCREEN_CODE);

                if (series == null || !series.IsActive)
                {
                    return ReturnBase<JobOrderDto>.Fail(
                        new Exception($"No active series configured for screen '{SCREEN_CODE}'"),
                        _exceptionManager
                    );
                }

                entity.SeriesId = series.Id;

                var seriesResult =
                    await _seriesService.GetSeriesCodeWithCustomDateUsingSeriesDetails(
                        series.Id,
                        entity.JobOrderDate
                    );

                if (!seriesResult.Succeeded || seriesResult.Result == null)
                    return ReturnBase<JobOrderDto>.Fail(seriesResult.Errors);

                entity.JobOrderNumber =
                    seriesResult.Result["FinelSeriesCodeAndSeriesNumber"];

                entity.RunningNumber =
                    int.Parse(seriesResult.Result["RunningNumber"]);

                // ADD CHILDREN BEFORE INSERT
                //foreach (var item in input.JobOrderLines)
                //{
                //    var entityDetail = _mapper.Map<JobOrderLine>(item);
                //    entity.JobOrderLines.Add(entityDetail);
                //}

                if (input.JobOrderLines != null && input.JobOrderLines.Any())
                {
                    entity.JobOrderLines = _mapper.Map<List<JobOrderLine>>(input.JobOrderLines);
                    foreach (var line in entity.JobOrderLines)
                    {
                        line.JobOrders = entity;
                    }
                }
                else
                {
                    entity.JobOrderLines = new List<JobOrderLine>();
                }

                var insertResult = await _commands.InsertAsync(entity);
                if (!insertResult.Succeeded)
                {
                    return ReturnBase<JobOrderDto>.Fail(insertResult.Errors);
                }

                var saveResult = await _accountUoW.SaveAsync();
                if (!saveResult.Succeeded)
                {
                    return ReturnBase<JobOrderDto>.Fail(saveResult.Errors);
                }

                var resultDto = _mapper.Map<JobOrderDto>(entity);

                return ReturnBase<JobOrderDto>.Success(resultDto);
            }
            catch (Exception ex)
            {
                return ReturnBase<JobOrderDto>.Fail(ex, _exceptionManager);
            }
        }

        public async Task<ReturnBase<bool>> DeleteAsync(long id)
        {
            try
            {
                var keys = new EntityKeyValueDictionary();
                keys.Add(new KeyValuePair<string, object>("Id", id));

                var deleteResult = await _commands.DeleteAsync(keys);
                if (!deleteResult.Succeeded)
                {
                    return ReturnBase<bool>.Fail(deleteResult.Errors);
                }

                var saveResult = await _accountUoW.SaveAsync();
                if (!saveResult.Succeeded)
                {
                    return ReturnBase<bool>.Fail(saveResult.Errors);
                }

                return ReturnBase<bool>.Success(true);
            }
            catch (Exception ex)
            {
                return ReturnBase<bool>.Fail(ex, _exceptionManager);
            }
        }

        public async Task<ReturnBase<JobOrderDto>> GetAsync(long id)
        {
            try
            {
                var Item = await _queries.GetByIdAsync(id);
                var itemDto = _mapper.Map<JobOrderDto>(Item);
                return new ReturnBase<JobOrderDto>(itemDto, true);
            }
            catch (Exception ex)
            {
                return ReturnBase<JobOrderDto>.Fail(ex, _exceptionManager);
            }
        }


        public async Task<ReturnBase<List<JobOrderDto>>> GetListAsync()
        {
            try
            {
                var list = await _queries.GetAllAsync();

                return ReturnBase<List<JobOrderDto>>.Success(_mapper.Map<List<JobOrderDto>>(list.Result));
            }
            catch (Exception ex)
            {
                return ReturnBase<List<JobOrderDto>>.Fail(ex, _exceptionManager);
            }
        }


        public async Task<ReturnBase<IEnumerable<JobOrderDtoLookUpForNames>>> GetLookUpJobOrderForNamesAsync(SqlQueryOptions queryOptions)
        {
            var result = await this._queriesManager.JobOrder.GetLookUpJobOrderForNamesAsync(queryOptions);

            var mappedResult = _mapper.Map<IEnumerable<JobOrderDtoLookUpForNames>>(result.Result);

            return ReturnBase<IEnumerable<JobOrderDtoLookUpForNames>>.Success(mappedResult);

        }
        public async Task<ReturnBase<List<JobOrderIncludeDto>>> GetListByIncludeAsync(SqlQueryOptions sqlQueryOptions)
        {
            try
            {
                var list = await _queries.GetListByIncludeAsync(sqlQueryOptions);

                return ReturnBase<List<JobOrderIncludeDto>>.Success(_mapper.Map<List<JobOrderIncludeDto>>(list));
            }
            catch (Exception ex)
            {
                return ReturnBase<List<JobOrderIncludeDto>>.Fail(ex, _exceptionManager);
            }
        }

        public async Task<ReturnBase<JobOrderDto>> UpdateAsync(UpdateJobOrderDto updateDto)
        {

            try
            {
                // at least one related document is required
                if (!updateDto.InspectionRequestId.HasValue &&
                    !updateDto.QuotationId.HasValue &&
                    !updateDto.SalesOrderId.HasValue)
                {
                    return ReturnBase<JobOrderDto>.Fail(
                        new Exception("At least one related document must be selected: Inspection Request, Quotation, or Sales Order."),
                        _exceptionManager
                    );
                }

                var entity = await _queriesManager.JobOrder.GetByIdAsync(updateDto.Id);

                if (entity is null)
                {
                    var error = new ReturnBaseError
                    {
                        ErrorCode = "404",
                        ErrorMessage = "Job Order Detail Not Found"
                    };
                    var listOfErrors = new List<ReturnBaseError>() { error };
                    return ReturnBase<JobOrderDto>.Fail(listOfErrors);
                }
                // Update request fields

                _mapper.Map(updateDto, entity);
                entity.JobOrderLines = null;

                var updateResult = await _commands.UpdateAsync(entity);
                if (!updateResult.Succeeded)

                    return ReturnBase<JobOrderDto>.Fail(updateResult.Errors);

                List<JobOrderLine> finalDet = new List<JobOrderLine>();

                // Update details
                foreach (var detail in updateDto.JobOrderLines)
                {
                    detail.JobOrderId = entity.Id;

                    var TenantName = _tenantResolver.GetTenantName();
                    //detail.Tenant_ID = TenantName;

                    var existing = await _queriesManager.JobOrderDetail.GetByIdAsync(detail.Id);


                    if (existing == null)
                    {
                        var insdetails = _mapper.Map<JobOrderLine>(detail);
                        var insertResultdet = await _commandsJobOrderDetails.InsertAsync(insdetails);
                        if (!insertResultdet.Succeeded)
                        {
                            return ReturnBase<JobOrderDto>.Fail(insertResultdet.Errors);
                        }

                        finalDet.Add(insdetails);

                    }
                    else
                    {
                        _mapper.Map(detail, existing);
                        var updateResultdet = await _commandsJobOrderDetails.UpdateAsync(existing);
                        if (!updateResultdet.Succeeded)
                        {
                            return ReturnBase<JobOrderDto>.Fail(updateResultdet.Errors);
                        }


                        finalDet.Add(existing);
                    }


                }


                var saveResult = await _accountUoW.SaveAsync();
                if (!saveResult.Succeeded)
                    return ReturnBase<JobOrderDto>.Fail(saveResult.Errors);
                entity.JobOrderLines = finalDet;


                var mappedResult = _mapper.Map<JobOrderDto>(entity);
                return ReturnBase<JobOrderDto>.Success(mappedResult);
            }

            catch (Exception ex)
            {
                return ReturnBase<JobOrderDto>.Fail(ex, _exceptionManager);
            }

        }


        // Document Change Status
        public async Task<ReturnBase<bool>> ChangeDocumentStatusAsync(ChangeJobOrderDocumentStatusDto newStatus)
        {
            try
            {
                var quotation = await _queries.GetByIdAsync(newStatus.RequestId);
                if (quotation == null)
                    return ReturnBase<bool>.Fail();

                var oldStatus = quotation.DocumentStatus;
                quotation.DocumentStatus = newStatus.DocumentStatus;

                if (!string.IsNullOrWhiteSpace(newStatus.CancelledDescription))
                {
                    quotation.DocumentStatusCancelledDescription = newStatus.CancelledDescription;
                }

                var updateResult = await _commands.UpdateAsync(quotation);
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
