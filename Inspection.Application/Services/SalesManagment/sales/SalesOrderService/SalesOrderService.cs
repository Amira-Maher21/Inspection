using AutoMapper;
using Inspection.Application.Contracts.Dto.SalesManagment.sales.SalesOrder;
using Inspection.Application.Contracts.Managers;
using Inspection.Application.Contracts.Repositories.Command.InspectionManagement.InspectionRequests;
using Inspection.Application.Contracts.Repositories.Command.SalesManagment.sales.SalesOrderCommandRepository;
using Inspection.Application.Contracts.Repositories.Query.SalesManagment.sales.SalesOrderQuery;
using Inspection.Application.Contracts.Services.MenuManagement.SeriesF;
using Inspection.Application.Contracts.Services.SalesManagment.sales.SalesOrder;
using Inspection.Application.Contracts.UnitOfWork;
using Inspection.Application.Services.ServicesBase;
using Inspection.Domain.Models.SalesManagment.Transaction.SalesOrders;
using NDS.Shared.Application.DataQuery;
using NDS.Shared.Application.Multitenant;
using NDS.Shared.Application.SharedModels;
using NDS.Shared.Kernel.BaseReturnTypes;
using NDS.Shared.Kernel.Exceptions;

namespace Inspection.Application.Services.SalesManagment.sales.SalesOrderService
{
    public class SalesOrderService : AccountsServiceBase, ISalesOrderService
    {
        private readonly ITenantResolver _tenantResolver;
        private readonly ISeriesService _seriesService;

        public SalesOrderService(IAccountUnitOfWork accountUoW, IAccountsQueriesManager queriesManager,
            IMapper mapper, IExceptionManager exceptionManager,
            ITenantResolver tenantResolver,
            ISeriesService seriesService) : base(accountUoW, queriesManager, mapper, exceptionManager)
        {
            _tenantResolver = tenantResolver;
            _seriesService = seriesService;
        }

        private ISalesOrderCommandRepository _commandsMaster => _accountUoW.SalesOrder;
        private ISalesOrderLinesCommandRepository _commandsDetails => _accountUoW.SalesOrderLines;
        private ISalesOrderQueryRepository _queriesMaster => _queriesManager.SalesOrder;
        private ISalesOrderLineQueryRepository _queriesDetails => _queriesManager.SalesOrderLines;
        private IInspectionRequestCommandRepository _inspectionRequestCommands => _accountUoW.InspectionRequest;

        //public async Task<ReturnBase<bool>> ChangeStatus(long id, ChangeStatusRequest Status)
        //{
        //    try
        //    {
        //        var entityMaster = await _queriesMaster.GetByIdAsync(id);
        //        if (entityMaster == null)
        //            return ReturnBase<bool>.Fail();
        //        entityMaster.ApprovalStatus = Status.ApprovalStatus;
        //        var updateResultMaster = await _commandsMaster.UpdateAsync(entityMaster);
        //        var saveResult = await _accountUoW.SaveAsync();
        //        if (!saveResult.Succeeded)
        //            return ReturnBase<bool>.Fail(saveResult.Errors);
        //        return ReturnBase<bool>.Success(true);
        //    }
        //    catch (Exception ex)
        //    {
        //        return ReturnBase<bool>.Fail(ex, _exceptionManager);
        //    }


        //}

        private ReturnBaseError? ValidateSalesOrderDates(
            DateTime? orderDate,
            DateTime? validUntil,
            DateTime? deliveryDate)
        {
            if (!orderDate.HasValue)
                return null;


            if (validUntil.HasValue && validUntil.Value < orderDate.Value)
            {
                return new ReturnBaseError
                {
                    ErrorCode = "INVALID_VALID_UNTIL",
                    ErrorMessage = "Valid Until must be greater than or equal to Order Date."
                };
            }


            if (deliveryDate.HasValue && deliveryDate.Value < orderDate.Value)
            {
                return new ReturnBaseError
                {
                    ErrorCode = "INVALID_DELIVERY_DATE",
                    ErrorMessage = "Delivery Date must be greater than or equal to Order Date."
                };
            }


            if (orderDate.Value.Date < DateTime.UtcNow.Date)
            {
                return new ReturnBaseError
                {
                    ErrorCode = "INVALID_ORDER_DATE",
                    ErrorMessage = "Order Date cannot be in the past."
                };
            }

            return null;
        }
        public async Task<ReturnBase<UpdateSalesOrderDto>> CreateAsync(CreateSalesOrderDto input)
        {
            try
            {

                var ruleError = ValidateSalesOrderDates(
            input.OrderDate,
            input.ValidUntil,
            input.DeliveryDate);

                if (ruleError != null)
                {
                    return ReturnBase<UpdateSalesOrderDto>.Fail(
                        new List<ReturnBaseError> { ruleError });
                }

                var entityMaster = _mapper.Map<SalesOrder>(input);

                entityMaster.Tenant_ID = _tenantResolver.GetTenantName();
                entityMaster.SalesOrderLines = new List<SalesOrderLines>();


                // Series
                const string SCREEN_CODE = "Sales Order";
                var series = await _queriesManager.Series.GetByScreen_IDAsync(SCREEN_CODE);

                if (series == null || !series.IsActive)
                {
                    return ReturnBase<UpdateSalesOrderDto>.Fail(
                        new Exception($"No active series configured for screen '{SCREEN_CODE}'"),
                        _exceptionManager
                    );
                }

                entityMaster.SeriesId = series.Id;

                var seriesResult =
                    await _seriesService.GetSeriesCodeWithCustomDateUsingSeriesDetails(
                        series.Id,
                        entityMaster.OrderDate
                    );

                if (!seriesResult.Succeeded || seriesResult.Result == null)
                    return ReturnBase<UpdateSalesOrderDto>.Fail(seriesResult.Errors);

                entityMaster.OrderNumber =
                    seriesResult.Result["FinelSeriesCodeAndSeriesNumber"];

                entityMaster.RunningNumber =
                    int.Parse(seriesResult.Result["RunningNumber"]);

                // 🔥 ADD CHILDREN BEFORE INSERT
                foreach (var item in input.SalesOrderLines)
                {
                    var entityDetail = _mapper.Map<SalesOrderLines>(item);
                    entityMaster.SalesOrderLines.Add(entityDetail);
                }

                // 🔥 INSERT ONCE
                var insertMasterResult = await _commandsMaster.InsertAsync(entityMaster);
                if (!insertMasterResult.Succeeded)
                    return ReturnBase<UpdateSalesOrderDto>.Fail(insertMasterResult.Errors);

                // 🔥 SAVE ONCE
                var saveResult = await _accountUoW.SaveAsync();
                if (!saveResult.Succeeded)
                    return ReturnBase<UpdateSalesOrderDto>.Fail(saveResult.Errors);

                return ReturnBase<UpdateSalesOrderDto>.Success(
                    _mapper.Map<UpdateSalesOrderDto>(entityMaster)
                );
            }
            catch (Exception ex)
            {
                return ReturnBase<UpdateSalesOrderDto>.Fail(ex, _exceptionManager);
            }
        }

        public async Task<ReturnBase<bool>> DeleteAsync(long id)
        {
            try
            {
                var keys = new EntityKeyValueDictionary();
                keys.Add(new KeyValuePair<string, object>("Id", id));

                var deleteResult = await _commandsMaster.DeleteAsync(keys);
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
        public async Task<ReturnBase<SalesOrderDto>> GetAsync(long id)
        {
            try
            {
                var Item = await _queriesMaster.GetByIdAsync(id);
                var itemDto = _mapper.Map<SalesOrderDto>(Item);

                return new ReturnBase<SalesOrderDto>(itemDto, true);
            }
            catch (Exception ex)
            {
                return ReturnBase<SalesOrderDto>.Fail(ex, _exceptionManager);
            }
        }
        public async Task<ReturnBase<List<SalesOrderDto>>> GetListAsync()
        {
            try
            {
                var list = await _queriesMaster.GetAllAsync();

                return ReturnBase<List<SalesOrderDto>>.Success(_mapper.Map<List<SalesOrderDto>>(list.Result));
            }
            catch (Exception ex)
            {
                return ReturnBase<List<SalesOrderDto>>.Fail(ex, _exceptionManager);
            }
        }

        public async Task<ReturnBase<List<SalesOrderDtoInclude>>> GetListByIncludeAsync(SqlQueryOptions sqlQueryOptions)
        {
            try
            {

                var list = await _queriesMaster.GetListByIncludeAsync(sqlQueryOptions);

                return ReturnBase<List<SalesOrderDtoInclude>>
                    .Success(list?.ToList() ?? new List<SalesOrderDtoInclude>());
            }
            catch (Exception ex)
            {
                return ReturnBase<List<SalesOrderDtoInclude>>.Fail(ex, _exceptionManager);
            }
        }

        public async Task<ReturnBase<List<SalesOrderLookupDefualtDto>>> SalesOrderLookupDefualt(SqlQueryOptions sqlQueryOptions)
        {
            try
            {
                var list = await _queriesMaster.GetListByIncludeAsync(sqlQueryOptions);

                return ReturnBase<List<SalesOrderLookupDefualtDto>>.Success(_mapper.Map<List<SalesOrderLookupDefualtDto>>(list));
            }
            catch (Exception ex)
            {
                return ReturnBase<List<SalesOrderLookupDefualtDto>>.Fail(ex, _exceptionManager);
            }
        }

        public async Task<ReturnBase<UpdateSalesOrderDto>> UpdateAsync(long id, UpdateSalesOrderDto input)
        {
            try
            {
                var ruleError = ValidateSalesOrderDates(
           input.OrderDate,
           input.ValidUntil,
           input.DeliveryDate);

                if (ruleError != null)
                {
                    return ReturnBase<UpdateSalesOrderDto>.Fail(
                        new List<ReturnBaseError> { ruleError });
                }



                var entityMaster = await _queriesMaster.GetByIdAsync(id);
                if (entityMaster == null)
                    return ReturnBase<UpdateSalesOrderDto>.Fail();

                _mapper.Map(input, entityMaster);
                entityMaster.SalesOrderLines = null;


                var updateResultMaster = await _commandsMaster.UpdateAsync(entityMaster);
                if (!updateResultMaster.Succeeded)
                    return ReturnBase<UpdateSalesOrderDto>.Fail(updateResultMaster.Errors);
                else
                {
                    //ensert Details and update Details
                    foreach (var item in input.SalesOrderLines)
                    {
                        if (item.Id <= 0)
                        {
                            item.SalesOrderId = entityMaster.Id;
                            var entityDetail = _mapper.Map<SalesOrderLines>(item);
                            var resultDetail = await _commandsDetails.InsertAsync(entityDetail);
                            if (!resultDetail.Succeeded)
                            {
                                return ReturnBase<UpdateSalesOrderDto>.Fail(resultDetail.Errors);
                            }
                        }
                        else
                        {
                            var entityDetails = await _queriesDetails.GetByIdAsync(item.Id);
                            _mapper.Map(item, entityDetails);
                            var updateResultDetails = await _commandsDetails.UpdateAsync(entityDetails);
                            if (!updateResultDetails.Succeeded)
                            {
                                return ReturnBase<UpdateSalesOrderDto>.Fail(updateResultDetails.Errors);
                            }
                        }
                    }
                }
                var saveResult = await _accountUoW.SaveAsync();
                if (!saveResult.Succeeded) return ReturnBase<UpdateSalesOrderDto>.Fail(saveResult.Errors);

                return ReturnBase<UpdateSalesOrderDto>.Success(_mapper.Map<UpdateSalesOrderDto>(entityMaster));
            }
            catch (Exception ex)
            {
                return ReturnBase<UpdateSalesOrderDto>.Fail(ex, _exceptionManager);
            }
        }

        // Document Change Status
        public async Task<ReturnBase<bool>> ChangeDocumentStatusAsync(ChangeSalesOrderDocumentStatusDto newStatus)
        {
            try
            {
                var order = await _queriesMaster.GetByIdAsync(newStatus.RequestId);
                if (order == null)
                    return ReturnBase<bool>.Fail();

                var oldStatus = order.DocumentStatus;
                order.DocumentStatus = newStatus.DocumentStatus;

                if (!string.IsNullOrWhiteSpace(newStatus.CancelledDescription))
                {
                    order.DocumentStatusCancelledReason = newStatus.CancelledDescription;
                }

                var updateResult = await _commandsMaster.UpdateAsync(order);
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
