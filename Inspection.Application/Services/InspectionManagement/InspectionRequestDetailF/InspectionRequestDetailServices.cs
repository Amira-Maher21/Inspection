using AutoMapper;
using Inspection.Application.Contracts.Dto.InspectionManagement.InspectionRequestDetailF;
using Inspection.Application.Contracts.Managers;
using Inspection.Application.Contracts.Repositories.Command.InspectionManagement.InspectionRequestDetailF;
using Inspection.Application.Contracts.Services.InspectionManagement.InspectionRequestDetailF;
using Inspection.Application.Contracts.UnitOfWork;
using Inspection.Application.Services.ServicesBase;
using Inspection.Domain.Models.InspectionManagement.InspectionRequests;
using NDS.Shared.Application.DataQuery;
using NDS.Shared.Kernel.BaseReturnTypes;
using NDS.Shared.Kernel.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inspection.Application.Services.InspectionManagement.InspectionRequestLinesF
{
 

 
    public class InspectionRequestLinesServices : AccountsServiceBase, IInspectionRequestLinesService
    {
        public InspectionRequestLinesServices(IAccountUnitOfWork accountUoW, IAccountsQueriesManager queriesManager, IMapper mapper, IExceptionManager exceptionManager) : base(accountUoW, queriesManager, mapper, exceptionManager)
        {
        }
        public async Task<List<InspectionRequestLinesDtoByInclude>> GetListAsync()
        {

            var list = await _queriesManager.InspectionRequestLines.GetAllAsync();
            return _mapper.Map<List<InspectionRequestLinesDtoByInclude>>(list.Result);
        }
        public async Task<ReturnBase<UpdateInspectionRequestLinesDto>> InsertInspectionRequestLinesAsync(CreateInspectionRequestLinesDto insertDto)
        {
            try
            {
                var entity = _mapper.Map<InspectionRequestLines>(insertDto);
                var insertResult = await _commands.InsertAsync(entity);
                if (!insertResult.Succeeded)
                {
                    return ReturnBase<UpdateInspectionRequestLinesDto>.Fail(insertResult.Errors);
                }

                var saveResult = await _accountUoW.SaveAsync();
                if (!saveResult.Succeeded)
                {
                    return ReturnBase<UpdateInspectionRequestLinesDto>.Fail(saveResult.Errors);
                }

                var resultDto = _mapper.Map<UpdateInspectionRequestLinesDto>(entity);

                return ReturnBase<UpdateInspectionRequestLinesDto>.Success(resultDto);
            }
            catch (Exception ex)
            {
                return ReturnBase<UpdateInspectionRequestLinesDto>.Fail(ex, _exceptionManager);
            }
        }
        public async Task<ReturnBase<UpdateInspectionRequestLinesDto>> UpdateInspectionRequestLinesAsync(UpdateInspectionRequestLinesDto updateDto, long id)
        {
            try
            {
                var entity = await _queriesManager.InspectionRequestLines.GetByIdAsync(id);
                if (entity is null)
                {
                    var error = new ReturnBaseError
                    {
                        ErrorCode = "404",
                        ErrorMessage = "InspectionRequestLines Not Found"
                    };
                    var listOfErrors = new List<ReturnBaseError>() { error };
                    return ReturnBase<UpdateInspectionRequestLinesDto>.Fail(listOfErrors);
                }

                //if (updateDto.ServiceTypeId is 0)
                //    entity.ServiceTypeId = updateDto.ServiceTypeId;

                //if (updateDto.Notes is not null)
                //    entity.Notes = updateDto.Notes;
                entity = _mapper.Map<InspectionRequestLines>(updateDto);
                var updateResult = await _commands.UpdateAsync(entity);

                if (!updateResult.Succeeded)
                    return ReturnBase<UpdateInspectionRequestLinesDto>.Fail(updateResult.Errors);

                var saveResult = await _accountUoW.SaveAsync();

                if (!saveResult.Succeeded)
                    return ReturnBase<UpdateInspectionRequestLinesDto>.Fail(saveResult.Errors);

                var mappedResult = _mapper.Map<UpdateInspectionRequestLinesDto>(entity);

                return ReturnBase<UpdateInspectionRequestLinesDto>.Success(mappedResult);

            }
            catch (Exception ex)
            {
                return ReturnBase<UpdateInspectionRequestLinesDto>.Fail(ex, _exceptionManager);
            }
        }
        public async Task<ReturnBase<UpdateInspectionRequestLinesDto>> DeleteInspectionRequestLinesAsync(long id)
        {
            try
            {
                var entity = await _queriesManager.InspectionRequestLines.GetByIdAsync(id);
                if (entity is null)
                {
                    var error = new ReturnBaseError
                    {
                        ErrorCode = "404",
                        ErrorMessage = "InspectionRequestLines Not Found"
                    };
                    var listOfErrors = new List<ReturnBaseError>() { error };
                    return ReturnBase<UpdateInspectionRequestLinesDto>.Fail(listOfErrors);
                }

                var deleteResult = await _commands.DeleteByIdAsync(id);

                if (!deleteResult.Succeeded)
                    return ReturnBase<UpdateInspectionRequestLinesDto>.Fail(deleteResult.Errors);

                var saveResult = await _accountUoW.SaveAsync();

                if (!saveResult.Succeeded)
                    return ReturnBase<UpdateInspectionRequestLinesDto>.Fail(saveResult.Errors);

                var mappedResult = _mapper.Map<UpdateInspectionRequestLinesDto>(entity);

                return ReturnBase<UpdateInspectionRequestLinesDto>.Success(mappedResult);

            }
            catch (Exception ex)
            {
                return ReturnBase<UpdateInspectionRequestLinesDto>.Fail(ex, _exceptionManager);
            }
        }
        public async Task<ReturnBase<IEnumerable<InspectionRequestLinesDtoByInclude>>> GetInspectionRequestLinesListAsync(SqlQueryOptions sqlQueryOptions)
        {
            try
            {
                var getResult = await _queriesManager.InspectionRequestLines.GetListAsync(sqlQueryOptions);
                if (!getResult.Succeeded)
                    return ReturnBase<IEnumerable<InspectionRequestLinesDtoByInclude>>.Fail(getResult.Errors);

                return ReturnBase<IEnumerable<InspectionRequestLinesDtoByInclude>>.Success(getResult.Result);
            }
            catch (Exception ex)
            {
                return ReturnBase<IEnumerable<InspectionRequestLinesDtoByInclude>>.Fail(ex, _exceptionManager);
            }
        }
        public async Task<ReturnBase<InspectionRequestLinesDto>> GetInspectionRequestLinesByIdAsync(long id)
        {
            try
            {
                var entity = await _queriesManager.InspectionRequestLines.GetByIdAsync(id);
                if (entity is null)
                {
                    var error = new ReturnBaseError
                    {
                        ErrorCode = "404",
                        ErrorMessage = "InspectionRequestLines Not Found"
                    };
                    var listOfErrors = new List<ReturnBaseError>() { error };
                    return ReturnBase<InspectionRequestLinesDto>.Fail(listOfErrors);
                }

                var mappedResult = _mapper.Map<InspectionRequestLinesDto>(entity);

                return ReturnBase<InspectionRequestLinesDto>.Success(mappedResult);
            }
            catch (Exception ex)
            {
                return ReturnBase<InspectionRequestLinesDto>.Fail(ex, _exceptionManager);
            }
        }
        public async Task<ReturnBase<IEnumerable<InspectionRequestLinesDtoByInclude>>> GetInspectionRequestLinesListByIncludeAsync(SqlQueryOptions sqlQueryOptions)
        {
            try
            {
                var getResult = await _queriesManager.InspectionRequestLines.GetListIncludeNameAsync(sqlQueryOptions);
                if (!getResult.Succeeded)
                    return ReturnBase<IEnumerable<InspectionRequestLinesDtoByInclude>>.Fail(getResult.Errors);

                return ReturnBase<IEnumerable<InspectionRequestLinesDtoByInclude>>.Success(_mapper.Map<IEnumerable<InspectionRequestLinesDtoByInclude>>(getResult.Result));
            }
            catch (Exception ex)
            {
                return ReturnBase<IEnumerable<InspectionRequestLinesDtoByInclude>>.Fail(ex, _exceptionManager);
            }

        }
        //public async Task<ReturnBase<IEnumerable<InspectionRequestLinesDtoLookUpForNames>>> GetLookUpInspectionRequestLinesForNamesAsync(SqlQueryOptions queryOptions)
        //{
        //    var result = await this._queriesManager.InspectionRequestLiness.GetLookUpInspectionRequestLinesForNamesAsync(queryOptions);

        //    var mappedResult = _mapper.Map<IEnumerable<InspectionRequestLinesDtoLookUpForNames>>(result.Result);

        //    return ReturnBase<IEnumerable<InspectionRequestLinesDtoLookUpForNames>>.Success(mappedResult);

        //}

        private IInspectionRequestLinesCommandRepository _commands
        {
            get { return _accountUoW.InspectionRequestLines; }
        }


    }
}
