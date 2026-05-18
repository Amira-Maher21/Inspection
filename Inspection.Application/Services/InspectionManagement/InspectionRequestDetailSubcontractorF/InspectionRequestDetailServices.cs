using AutoMapper;
 using Inspection.Application.Contracts.Dto.InspectionManagement.InspectionRequestSubcontractorDetailF;
using Inspection.Application.Contracts.Managers;
using Inspection.Application.Contracts.Repositories.Command.InspectionManagement.InspectionRequestDetailSubcontractorF;
using Inspection.Application.Contracts.Services.InspectionManagement.InspectionRequestDetailSubcontractorF;
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

namespace Inspection.Application.Services.InspectionManagement.InspectionRequestDetailSubcontractorF
{
 

 
    public class InspectionRequestDetailSubcontractorServices : AccountsServiceBase, IInspectionRequestDetailSubcontractorService
    {
        public InspectionRequestDetailSubcontractorServices(IAccountUnitOfWork accountUoW, IAccountsQueriesManager queriesManager, IMapper mapper, IExceptionManager exceptionManager) : base(accountUoW, queriesManager, mapper, exceptionManager)
        {
        }
        public async Task<List<InspectionRequestSubcontractorDetailDtoByInclude>> GetListAsync()
        {

            var list = await _queriesManager.InspectionRequestDetailSubcontractors.GetAllAsync();
            return _mapper.Map<List<InspectionRequestSubcontractorDetailDtoByInclude>>(list.Result);
        }
        public async Task<ReturnBase<UpdateInspectionRequestSubcontractorDetailDto>> InsertInspectionRequestDetailSubcontractorAsync(CreateInspectionRequestSubcontractorDetailDto insertDto)
        {
            try
            {
                var entity = _mapper.Map<InspectionRequestSubcontractorDetail>(insertDto);

                var insertResult = await _commands.InsertAsync(entity);
                if (!insertResult.Succeeded)
                {
                    return ReturnBase<UpdateInspectionRequestSubcontractorDetailDto>.Fail(insertResult.Errors);
                }

                var saveResult = await _accountUoW.SaveAsync();
                if (!saveResult.Succeeded)
                {
                    return ReturnBase<UpdateInspectionRequestSubcontractorDetailDto>.Fail(saveResult.Errors);
                }

                var resultDto = _mapper.Map<UpdateInspectionRequestSubcontractorDetailDto>(entity);

                return ReturnBase<UpdateInspectionRequestSubcontractorDetailDto>.Success(resultDto);
            }
            catch (Exception ex)
            {
                return ReturnBase<UpdateInspectionRequestSubcontractorDetailDto>.Fail(ex, _exceptionManager);
            }
        }
        public async Task<ReturnBase<UpdateInspectionRequestSubcontractorDetailDto>> UpdateInspectionRequestDetailSubcontractorAsync(UpdateInspectionRequestSubcontractorDetailDto updateDto, long id)
        {
            try
            {
                var entity = await _queriesManager.InspectionRequestDetailSubcontractors.GetByIdAsync(id);
                if (entity is null)
                {
                    var error = new ReturnBaseError
                    {
                        ErrorCode = "404",
                        ErrorMessage = "Inspection Request Detail Subcontractor Not Found"
                    };
                    var listOfErrors = new List<ReturnBaseError>() { error };
                    return ReturnBase<UpdateInspectionRequestSubcontractorDetailDto>.Fail(listOfErrors);
                }

             
                entity = _mapper.Map<InspectionRequestSubcontractorDetail>(updateDto);
                var updateResult = await _commands.UpdateAsync(entity);

                if (!updateResult.Succeeded)
                    return ReturnBase<UpdateInspectionRequestSubcontractorDetailDto>.Fail(updateResult.Errors);

                var saveResult = await _accountUoW.SaveAsync();

                if (!saveResult.Succeeded)
                    return ReturnBase<UpdateInspectionRequestSubcontractorDetailDto>.Fail(saveResult.Errors);

                var mappedResult = _mapper.Map<UpdateInspectionRequestSubcontractorDetailDto>(entity);

                return ReturnBase<UpdateInspectionRequestSubcontractorDetailDto>.Success(mappedResult);

            }
            catch (Exception ex)
            {
                return ReturnBase<UpdateInspectionRequestSubcontractorDetailDto>.Fail(ex, _exceptionManager);
            }
        }
        public async Task<ReturnBase<UpdateInspectionRequestSubcontractorDetailDto>> DeleteInspectionRequestDetailSubcontractorAsync(long id)
        {
            try
            {
                var entity = await _queriesManager.InspectionRequestDetailSubcontractors.GetByIdAsync(id);
                if (entity is null)
                {
                    var error = new ReturnBaseError
                    {
                        ErrorCode = "404",
                        ErrorMessage = "InspectionRequestDetailSubcontractor Not Found"
                    };
                    var listOfErrors = new List<ReturnBaseError>() { error };
                    return ReturnBase<UpdateInspectionRequestSubcontractorDetailDto>.Fail(listOfErrors);
                }

                var deleteResult = await _commands.DeleteByIdAsync(id);

                if (!deleteResult.Succeeded)
                    return ReturnBase<UpdateInspectionRequestSubcontractorDetailDto>.Fail(deleteResult.Errors);

                var saveResult = await _accountUoW.SaveAsync();

                if (!saveResult.Succeeded)
                    return ReturnBase<UpdateInspectionRequestSubcontractorDetailDto>.Fail(saveResult.Errors);

                var mappedResult = _mapper.Map<UpdateInspectionRequestSubcontractorDetailDto>(entity);

                return ReturnBase<UpdateInspectionRequestSubcontractorDetailDto>.Success(mappedResult);

            }
            catch (Exception ex)
            {
                return ReturnBase<UpdateInspectionRequestSubcontractorDetailDto>.Fail(ex, _exceptionManager);
            }
        }
        public async Task<ReturnBase<IEnumerable<InspectionRequestSubcontractorDetailDtoByInclude>>> GetInspectionRequestDetailSubcontractorListAsync(SqlQueryOptions sqlQueryOptions)
        {
            try
            {
                var getResult = await _queriesManager.InspectionRequestDetailSubcontractors.GetListAsync(sqlQueryOptions);
                if (!getResult.Succeeded)
                    return ReturnBase<IEnumerable<InspectionRequestSubcontractorDetailDtoByInclude>>.Fail(getResult.Errors);

                return ReturnBase<IEnumerable<InspectionRequestSubcontractorDetailDtoByInclude>>.Success(getResult.Result);
            }
            catch (Exception ex)
            {
                return ReturnBase<IEnumerable<InspectionRequestSubcontractorDetailDtoByInclude>>.Fail(ex, _exceptionManager);
            }
        }
        public async Task<ReturnBase<InspectionRequestSubcontractorDetailDto>> GetInspectionRequestDetailSubcontractorByIdAsync(long id)
        {
            try
            {
                var entity = await _queriesManager.InspectionRequestDetailSubcontractors.GetByIdAsync(id);
                if (entity is null)
                {
                    var error = new ReturnBaseError
                    {
                        ErrorCode = "404",
                        ErrorMessage = "InspectionRequestDetailSubcontractor Not Found"
                    };
                    var listOfErrors = new List<ReturnBaseError>() { error };
                    return ReturnBase<InspectionRequestSubcontractorDetailDto>.Fail(listOfErrors);
                }

                var mappedResult = _mapper.Map<InspectionRequestSubcontractorDetailDto>(entity);

                return ReturnBase<InspectionRequestSubcontractorDetailDto>.Success(mappedResult);
            }
            catch (Exception ex)
            {
                return ReturnBase<InspectionRequestSubcontractorDetailDto>.Fail(ex, _exceptionManager);
            }
        }
        public async Task<ReturnBase<IEnumerable<InspectionRequestSubcontractorDetailDtoByInclude>>> GetInspectionRequestDetailSubcontractorListByIncludeAsync(SqlQueryOptions sqlQueryOptions)
        {
            try
            {
                var getResult = await _queriesManager.InspectionRequestDetailSubcontractors.GetListIncludeNameAsync(sqlQueryOptions);
                if (!getResult.Succeeded)
                    return ReturnBase<IEnumerable<InspectionRequestSubcontractorDetailDtoByInclude>>.Fail(getResult.Errors);

                return ReturnBase<IEnumerable<InspectionRequestSubcontractorDetailDtoByInclude>>.Success(_mapper.Map<IEnumerable<InspectionRequestSubcontractorDetailDtoByInclude>>(getResult.Result));
            }
            catch (Exception ex)
            {
                return ReturnBase<IEnumerable<InspectionRequestSubcontractorDetailDtoByInclude>>.Fail(ex, _exceptionManager);
            }

        }
        //public async Task<ReturnBase<IEnumerable<InspectionRequestDetailSubcontractorDtoLookUpForNames>>> GetLookUpInspectionRequestDetailSubcontractorForNamesAsync(SqlQueryOptions queryOptions)
        //{
        //    var result = await this._queriesManager.InspectionRequestDetailSubcontractors.GetLookUpInspectionRequestDetailSubcontractorForNamesAsync(queryOptions);

        //    var mappedResult = _mapper.Map<IEnumerable<InspectionRequestDetailSubcontractorDtoLookUpForNames>>(result.Result);

        //    return ReturnBase<IEnumerable<InspectionRequestDetailSubcontractorDtoLookUpForNames>>.Success(mappedResult);

        //}

        private IInspectionRequestDetailSubcontractorCommandRepository _commands
        {
            get { return _accountUoW.InspectionRequestDetailSubcontractor; }
        }


    }
}
