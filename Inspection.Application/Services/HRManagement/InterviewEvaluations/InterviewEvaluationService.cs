using AutoMapper;
using Inspection.Application.Contracts.Dto.HRManagement.InterviewEvaluations;
using Inspection.Application.Contracts.Managers;
using Inspection.Application.Contracts.Repositories.Command.HRManagement.InterviewEvaluations;
using Inspection.Application.Contracts.Services.HRManagement.InterviewEvaluations;
using Inspection.Application.Contracts.UnitOfWork;
using Inspection.Application.Services.ServicesBase;
using Inspection.Domain.Models.HRManagement.InterviewEvaluations;
using NDS.Shared.Application.DataQuery;
using NDS.Shared.Kernel.BaseReturnTypes;
using NDS.Shared.Kernel.Exceptions;


namespace Inspection.Application.Services.HRManagement.InterviewEvaluations
{
    internal class InterviewEvaluationService : AccountsServiceBase, IInterviewEvaluationService
    {
        public InterviewEvaluationService(IAccountUnitOfWork accountUoW, IAccountsQueriesManager queriesManager, IMapper mapper, IExceptionManager exceptionManager) : base(accountUoW, queriesManager, mapper, exceptionManager)
        {
        }



        public async Task<ReturnBase<UpdateInterviewEvaluationDto>> DeleteInterviewEvaluationTypeAsync(long id)
        {

            try
            {
                var entity = await _queriesManager.InterviewEvaluationQueryRepository.GetByIdAsync(id);
                if (entity is null)
                {
                    var error = new ReturnBaseError
                    {
                        ErrorCode = "404",
                        ErrorMessage = "InterviewEvaluation Not Found"
                    };
                    var listOfErrors = new List<ReturnBaseError>() { error };
                    return ReturnBase<UpdateInterviewEvaluationDto>.Fail(listOfErrors);
                }

                var deleteResult = await _commands.DeleteByIdAsync(id);

                if (!deleteResult.Succeeded)
                    return ReturnBase<UpdateInterviewEvaluationDto>.Fail(deleteResult.Errors);

                var saveResult = await _accountUoW.SaveAsync();

                if (!saveResult.Succeeded)
                    return ReturnBase<UpdateInterviewEvaluationDto>.Fail(saveResult.Errors);

                var mappedResult = _mapper.Map<UpdateInterviewEvaluationDto>(entity);

                return ReturnBase<UpdateInterviewEvaluationDto>.Success(mappedResult);

            }
            catch (Exception ex)
            {
                return ReturnBase<UpdateInterviewEvaluationDto>.Fail(ex, _exceptionManager);
            }
        }

        public async Task<ReturnBase<InterviewEvaluationDto>> GetInterviewEvaluationTypeByIdAsync(long id)
        {
            try
            {
                var entity = await _queriesManager.InterviewEvaluationQueryRepository.GetByIdAsync(id);
                if (entity is null)
                {
                    var error = new ReturnBaseError
                    {
                        ErrorCode = "404",
                        ErrorMessage = "Company Not Found"
                    };
                    var listOfErrors = new List<ReturnBaseError>() { error };
                    return ReturnBase<InterviewEvaluationDto>.Fail(listOfErrors);
                }

                var mappedResult = _mapper.Map<InterviewEvaluationDto>(entity);

                return ReturnBase<InterviewEvaluationDto>.Success(mappedResult);
            }
            catch (Exception ex)
            {
                return ReturnBase<InterviewEvaluationDto>.Fail(ex, _exceptionManager);
            }
        }

        public async Task<ReturnBase<IEnumerable<InterviewEvaluationDto>>> GetInterviewEvaluationTypeListAsync(SqlQueryOptions sqlQueryOptions)
        {
            try
            {
                var getResult = await _queriesManager.InterviewEvaluationQueryRepository.GetListAsync(sqlQueryOptions);
                if (!getResult.Succeeded)
                    return ReturnBase<IEnumerable<InterviewEvaluationDto>>.Fail(getResult.Errors);

                return ReturnBase<IEnumerable<InterviewEvaluationDto>>.Success(getResult.Result);
            }
            catch (Exception ex)
            {
                return ReturnBase<IEnumerable<InterviewEvaluationDto>>.Fail(ex, _exceptionManager);
            }
        }

        public async Task<ReturnBase<IEnumerable<InterviewEvaluationDtoLookUpForNames>>> GetLookUpCompanyForNamesAsync(SqlQueryOptions queryOptions)
        {
            var result = await this._queriesManager.InterviewEvaluationQueryRepository.GetLookUpCompanyForNamesAsync(queryOptions);

            var mappedResult = result.Result.Select(d => new InterviewEvaluationDtoLookUpForNames
            {
                Id = d.Id,
                Name = d.InterviewerName
            });

            return ReturnBase<IEnumerable<InterviewEvaluationDtoLookUpForNames>>.Success(mappedResult);
        }

        public async Task<ReturnBase<UpdateInterviewEvaluationDto>> InsertInterviewEvaluationTypeAsync(CreateInterviewEvaluationDto insertDto)
        {
            try
            {
                var entity = _mapper.Map<InterviewEvaluation>(insertDto);

                var insertResult = await _commands.InsertAsync(entity);
                if (!insertResult.Succeeded)
                {
                    return ReturnBase<UpdateInterviewEvaluationDto>.Fail(insertResult.Errors);
                }

                var saveResult = await _accountUoW.SaveAsync();
                if (!saveResult.Succeeded)
                {
                    return ReturnBase<UpdateInterviewEvaluationDto>.Fail(saveResult.Errors);
                }

                var resultDto = _mapper.Map<UpdateInterviewEvaluationDto>(entity);

                return ReturnBase<UpdateInterviewEvaluationDto>.Success(resultDto);
            }
            catch (Exception ex)
            {
                return ReturnBase<UpdateInterviewEvaluationDto>.Fail(ex, _exceptionManager);
            }
        }

        public async Task<ReturnBase<UpdateInterviewEvaluationDto>> UpdateInterviewEvaluationTypeAsync(UpdateInterviewEvaluationDto updateDto, long id)
        {
            try
            {
                var entity = await _queriesManager.InterviewEvaluationQueryRepository.GetByIdAsync(id);
                if (entity == null)
                {
                    var error = new ReturnBaseError
                    {
                        ErrorCode = "404",
                        ErrorMessage = "InterviewEvaluation Not Found"
                    };
                    return ReturnBase<UpdateInterviewEvaluationDto>.Fail(new List<ReturnBaseError> { error });
                }

                _mapper.Map(updateDto, entity);

                var updateResult = await _commands.UpdateAsync(entity);
                if (!updateResult.Succeeded)
                    return ReturnBase<UpdateInterviewEvaluationDto>.Fail(updateResult.Errors);

                var saveResult = await _accountUoW.SaveAsync();
                if (!saveResult.Succeeded)
                    return ReturnBase<UpdateInterviewEvaluationDto>.Fail(saveResult.Errors);

                var mappedResult = _mapper.Map<UpdateInterviewEvaluationDto>(entity);

                return ReturnBase<UpdateInterviewEvaluationDto>.Success(mappedResult);
            }
            catch (Exception ex)
            {
                var realException = ex.InnerException ?? ex;
                return ReturnBase<UpdateInterviewEvaluationDto>.Fail(realException, _exceptionManager);
            }
        }

        private IInterviewEvaluationCommandRepository _commands
        {
            get { return _accountUoW.InterviewEvaluationCommandRepository; }
        }

    }
}
