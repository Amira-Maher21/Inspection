using AutoMapper;
using Inspection.Application.Contracts.Dto.SalesManagment.sales.JobOrderDetails;
using Inspection.Application.Contracts.Dto.SalesManagment.sales.JobOrderF;
using Inspection.Application.Contracts.Managers;
using Inspection.Application.Contracts.Repositories.Command.SalesManagment.sales;
using Inspection.Application.Contracts.Services.SalesManagment.sales;
using Inspection.Application.Contracts.UnitOfWork;
using Inspection.Application.Services.ServicesBase;
using Inspection.Application.Shared.ExcelTemplate;
using Inspection.Domain.Models.Inspection.Techinal.JobOrder;
using NDS.Shared.Application.Multitenant;
using NDS.Shared.Kernel.BaseReturnTypes;
using NDS.Shared.Kernel.Exceptions;

namespace Inspection.Application.Services.SalesManagment.sales
{




    public class JobOrderDetailService : AccountsServiceBase, IJobOrderDetailService
    {
        private readonly ITenantResolver _tenantResolver;
        private readonly IExcelTemplateGenerator _templateGenerator;
        public JobOrderDetailService(IAccountUnitOfWork accountUoW, IAccountsQueriesManager queriesManager, IMapper mapper, IExceptionManager exceptionManager, ITenantResolver tenantResolver, IExcelTemplateGenerator templateGenerator) : base(accountUoW, queriesManager, mapper, exceptionManager)
        {
            _tenantResolver = tenantResolver;
            _templateGenerator = templateGenerator;
        }
        //public async Task<List<JobOrderDetailDtoByInclude>> GetListAsync()
        //{

        //    var list = await _queriesManager.JobOrderDetails.GetAllAsync();
        //    return _mapper.Map<List<JobOrderDetailDtoByInclude>>(list.Result);
        //}
        public async Task<ReturnBase<UpdateJobOrderLinesDto>> InsertJobOrderDetailAsync(CreateJobOrderLinesDto insertDto)
        {
            try
            {
                var entity = _mapper.Map<JobOrderLine>(insertDto);

                var insertResult = await _commands.InsertAsync(entity);
                if (!insertResult.Succeeded)
                {
                    return ReturnBase<UpdateJobOrderLinesDto>.Fail(insertResult.Errors);
                }

                var saveResult = await _accountUoW.SaveAsync();
                if (!saveResult.Succeeded)
                {
                    return ReturnBase<UpdateJobOrderLinesDto>.Fail(saveResult.Errors);
                }

                var resultDto = _mapper.Map<UpdateJobOrderLinesDto>(entity);

                return ReturnBase<UpdateJobOrderLinesDto>.Success(resultDto);
            }
            catch (Exception ex)
            {
                return ReturnBase<UpdateJobOrderLinesDto>.Fail(ex, _exceptionManager);
            }
        }
        public async Task<ReturnBase<UpdateJobOrderLinesDto>> UpdateJobOrderDetailAsync(UpdateJobOrderLinesDto updateDto, long id)
        {
            try
            {
                var entity = await _queriesManager.JobOrderDetail.GetByIdAsync(id);
                if (entity is null)
                {
                    var error = new ReturnBaseError
                    {
                        ErrorCode = "404",
                        ErrorMessage = "Job Order Detail Not Found"
                    };
                    var listOfErrors = new List<ReturnBaseError>() { error };
                    return ReturnBase<UpdateJobOrderLinesDto>.Fail(listOfErrors);
                }

                //if (updateDto.ServiceTypeId is 0)
                //    entity.ServiceTypeId = updateDto.ServiceTypeId;

                //if (updateDto.Notes is not null)
                //    entity.Notes = updateDto.Notes;
                entity = _mapper.Map<JobOrderLine>(updateDto);
                var updateResult = await _commands.UpdateAsync(entity);

                if (!updateResult.Succeeded)
                    return ReturnBase<UpdateJobOrderLinesDto>.Fail(updateResult.Errors);

                var saveResult = await _accountUoW.SaveAsync();

                if (!saveResult.Succeeded)
                    return ReturnBase<UpdateJobOrderLinesDto>.Fail(saveResult.Errors);

                var mappedResult = _mapper.Map<UpdateJobOrderLinesDto>(entity);

                return ReturnBase<UpdateJobOrderLinesDto>.Success(mappedResult);

            }
            catch (Exception ex)
            {
                return ReturnBase<UpdateJobOrderLinesDto>.Fail(ex, _exceptionManager);
            }
        }
        public async Task<ReturnBase<UpdateJobOrderLinesDto>> DeleteJobOrderDetailAsync(long id)
        {
            try
            {
                var entity = await _queriesManager.JobOrderDetail.GetByIdAsync(id);
                if (entity is null)
                {
                    var error = new ReturnBaseError
                    {
                        ErrorCode = "404",
                        ErrorMessage = "Job Order Detail Not Found"
                    };
                    var listOfErrors = new List<ReturnBaseError>() { error };
                    return ReturnBase<UpdateJobOrderLinesDto>.Fail(listOfErrors);
                }

                var deleteResult = await _commands.DeleteByIdAsync(id);

                if (!deleteResult.Succeeded)
                    return ReturnBase<UpdateJobOrderLinesDto>.Fail(deleteResult.Errors);

                var saveResult = await _accountUoW.SaveAsync();

                if (!saveResult.Succeeded)
                    return ReturnBase<UpdateJobOrderLinesDto>.Fail(saveResult.Errors);

                var mappedResult = _mapper.Map<UpdateJobOrderLinesDto>(entity);

                return ReturnBase<UpdateJobOrderLinesDto>.Success(mappedResult);

            }
            catch (Exception ex)
            {
                return ReturnBase<UpdateJobOrderLinesDto>.Fail(ex, _exceptionManager);
            }
        }
        //public async Task<ReturnBase<IEnumerable<JobOrderDetailDtoByInclude>>> GetJobOrderDetailListAsync(SqlQueryOptions sqlQueryOptions)
        //{
        //    try
        //    {
        //        var getResult = await _queriesManager.JobOrderDetail.GetListAsync(sqlQueryOptions);
        //        if (!getResult.Succeeded)
        //            return ReturnBase<IEnumerable<JobOrderDetailDtoByInclude>>.Fail(getResult.Errors);

        //        return ReturnBase<IEnumerable<JobOrderDetailDtoByInclude>>.Success(getResult.Result);
        //    }
        //    catch (Exception ex)
        //    {
        //        return ReturnBase<IEnumerable<JobOrderDetailDtoByInclude>>.Fail(ex, _exceptionManager);
        //    }
        //}
        public async Task<ReturnBase<JobOrderLinesDto>> GetJobOrderDetailByIdAsync(long id)
        {
            try
            {
                var entity = await _queriesManager.JobOrderDetail.GetByIdAsync(id);
                if (entity is null)
                {
                    var error = new ReturnBaseError
                    {
                        ErrorCode = "404",
                        ErrorMessage = "JobOrderDetail Not Found"
                    };
                    var listOfErrors = new List<ReturnBaseError>() { error };
                    return ReturnBase<JobOrderLinesDto>.Fail(listOfErrors);
                }

                var mappedResult = _mapper.Map<JobOrderLinesDto>(entity);

                return ReturnBase<JobOrderLinesDto>.Success(mappedResult);
            }
            catch (Exception ex)
            {
                return ReturnBase<JobOrderLinesDto>.Fail(ex, _exceptionManager);
            }
        }
        //public async Task<ReturnBase<IEnumerable<JobOrderDetailDtoByInclude>>> GetJobOrderDetailListByIncludeAsync(SqlQueryOptions sqlQueryOptions)
        //{
        //    try
        //    {
        //        var getResult = await _queriesManager.JobOrderDetails.GetListIncludeNameAsync(sqlQueryOptions);
        //        if (!getResult.Succeeded)
        //            return ReturnBase<IEnumerable<JobOrderDetailDtoByInclude>>.Fail(getResult.Errors);

        //        return ReturnBase<IEnumerable<JobOrderDetailDtoByInclude>>.Success(_mapper.Map<IEnumerable<JobOrderDetailDtoByInclude>>(getResult.Result));
        //    }
        //    catch (Exception ex)
        //    {
        //        return ReturnBase<IEnumerable<JobOrderDetailDtoByInclude>>.Fail(ex, _exceptionManager);
        //    }

        //}
        //public async Task<ReturnBase<IEnumerable<JobOrderDetailDtoLookUpForNames>>> GetLookUpJobOrderDetailForNamesAsync(SqlQueryOptions queryOptions)
        //{
        //    var result = await this._queriesManager.JobOrderDetails.GetLookUpJobOrderDetailForNamesAsync(queryOptions);

        //    var mappedResult = _mapper.Map<IEnumerable<JobOrderDetailDtoLookUpForNames>>(result.Result);

        //    return ReturnBase<IEnumerable<JobOrderDetailDtoLookUpForNames>>.Success(mappedResult);

        //}

        private IJobOrderDetailCommandRepository _commands
        {
            get { return _accountUoW.JobOrderDetail; }
        }



        public async Task<ReturnBase<IEnumerable<JobOrderLinegGetListDto>>> GetJobOrderDetailsListAsync()
        {
            try
            {
                var list = await _queriesManager.JobOrderDetail.GetListAsync();

                return ReturnBase<IEnumerable<JobOrderLinegGetListDto>>
                    .Success(list);
            }
            catch (Exception ex)
            {
                return ReturnBase<IEnumerable<JobOrderLinegGetListDto>>
                    .Fail(ex, _exceptionManager);
            }
        }
    }
}
