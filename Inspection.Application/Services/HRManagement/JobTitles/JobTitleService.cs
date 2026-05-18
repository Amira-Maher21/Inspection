using AutoMapper;
using Inspection.Application.Contracts.Dto.HRManagement.JobTitles;
using Inspection.Application.Contracts.Managers;
using Inspection.Application.Contracts.Repositories.Command.HRManagement.JobTitles;
using Inspection.Application.Contracts.Services.HRManagement.JobTitles;
using Inspection.Application.Contracts.Services.HRManagement.JobTitles;
using Inspection.Application.Contracts.UnitOfWork;
using Inspection.Application.Services.ServicesBase;
using Inspection.Domain.Models.HRManagement.JobTitles;
using NDS.Shared.Application.DataQuery;
using NDS.Shared.Kernel.BaseReturnTypes;
using NDS.Shared.Kernel.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inspection.Application.Services.HRManagement.JobTitles
{
    public class JobTitleService : AccountsServiceBase, IJobTitleService
    {
        public JobTitleService(IAccountUnitOfWork accountUoW, IAccountsQueriesManager queriesManager, IMapper mapper, IExceptionManager exceptionManager) : base(accountUoW, queriesManager, mapper, exceptionManager)
        {
        }
        public async Task<ReturnBase<UpdateJobTitleDto>> DeleteJobTitleAsync(long id)
        {
            try
            {
                var entity = await _queriesManager.JobTitleQueryRepository.GetByIdAsync(id);
                if (entity is null)
                {
                    var error = new ReturnBaseError
                    {
                        ErrorCode = "404",
                        ErrorMessage = "JobTitle Not Found"
                    };
                    var listOfErrors = new List<ReturnBaseError>() { error };
                    return ReturnBase<UpdateJobTitleDto>.Fail(listOfErrors);
                }

                var deleteResult = await _commands.DeleteByIdAsync(id);

                if (!deleteResult.Succeeded)
                    return ReturnBase<UpdateJobTitleDto>.Fail(deleteResult.Errors);

                var saveResult = await _accountUoW.SaveAsync();

                if (!saveResult.Succeeded)
                    return ReturnBase<UpdateJobTitleDto>.Fail(saveResult.Errors);

                var mappedResult = _mapper.Map<UpdateJobTitleDto>(entity);

                return ReturnBase<UpdateJobTitleDto>.Success(mappedResult);

            }
            catch (Exception ex)
            {
                return ReturnBase<UpdateJobTitleDto>.Fail(ex, _exceptionManager);
            }
        }

        public async Task<ReturnBase<JobTitleDto>> GetJobTitleByIdAsync(long id)
        {
            try
            {
                var entity = await _queriesManager.JobTitleQueryRepository.GetByIdAsync(id);
                if (entity is null)
                {
                    var error = new ReturnBaseError
                    {
                        ErrorCode = "404",
                        ErrorMessage = "Company Not Found"
                    };
                    var listOfErrors = new List<ReturnBaseError>() { error };
                    return ReturnBase<JobTitleDto>.Fail(listOfErrors);
                }

                var mappedResult = _mapper.Map<JobTitleDto>(entity);

                return ReturnBase<JobTitleDto>.Success(mappedResult);
            }
            catch (Exception ex)
            {
                return ReturnBase<JobTitleDto>.Fail(ex, _exceptionManager);
            }
        }

        public async Task<ReturnBase<IEnumerable<JobTitleDto>>> GetJobTitleListAsync(SqlQueryOptions sqlQueryOptions)
        {
            try
            {
                var getResult = await _queriesManager.JobTitleQueryRepository.GetListAsync(sqlQueryOptions);
                if (!getResult.Succeeded)
                    return ReturnBase<IEnumerable<JobTitleDto>>.Fail(getResult.Errors);

                return ReturnBase<IEnumerable<JobTitleDto>>.Success(getResult.Result);
            }
            catch (Exception ex)
            {
                return ReturnBase<IEnumerable<JobTitleDto>>.Fail(ex, _exceptionManager);
            }
        }

        public async Task<ReturnBase<IEnumerable<JobTitleLookUpForNames>>> GetLookUpCompanyForNamesAsync(SqlQueryOptions queryOptions)
        {
            //var result = await this._queriesManager.JobTitleQueryRepository.GetLookUpCompanyForNamesAsync(queryOptions);

            //var mappedResult = _mapper.Map<IEnumerable<JobTitleLookUpForNames>>(result.Result);

            //return ReturnBase<IEnumerable<JobTitleLookUpForNames>>.Success(mappedResult);
            var result = await this._queriesManager.JobTitleQueryRepository.GetLookUpCompanyForNamesAsync(queryOptions);
            var mappedResult = result.Result.Select(j => new JobTitleLookUpForNames
            {
                Id = j.Id,
                Title = j.Title,
                //DepartmentName = j.DepartmentName
            });

            return ReturnBase<IEnumerable<JobTitleLookUpForNames>>.Success(mappedResult);

        }

        public async Task<ReturnBase<UpdateJobTitleDto>> InsertJobTitleAsync(CreateJobTitleDto insertDto)
        {
            try
            {
                var entity = _mapper.Map<JobTitle>(insertDto);

                var insertResult = await _commands.InsertAsync(entity);
                if (!insertResult.Succeeded)
                {
                    return ReturnBase<UpdateJobTitleDto>.Fail(insertResult.Errors);
                }

                var saveResult = await _accountUoW.SaveAsync();
                if (!saveResult.Succeeded)
                {
                    return ReturnBase<UpdateJobTitleDto>.Fail(saveResult.Errors);
                }

                var resultDto = _mapper.Map<UpdateJobTitleDto>(entity);

                return ReturnBase<UpdateJobTitleDto>.Success(resultDto);
            }
            catch (Exception ex)
            {
                return ReturnBase<UpdateJobTitleDto>.Fail(ex, _exceptionManager);
            }
        }

        public async Task<ReturnBase<UpdateJobTitleDto>> UpdateJobTitleAsync(UpdateJobTitleDto updateDto, long id)
        {
            try
            {
                var entity = await _queriesManager.JobTitleQueryRepository.GetByIdAsync(id);
                if (entity == null)
                {
                    var error = new ReturnBaseError
                    {
                        ErrorCode = "404",
                        ErrorMessage = "JobTitle Not Found"
                    };
                    return ReturnBase<UpdateJobTitleDto>.Fail(new List<ReturnBaseError> { error });
                }

                _mapper.Map(updateDto, entity);

                var updateResult = await _commands.UpdateAsync(entity);
                if (!updateResult.Succeeded)
                    return ReturnBase<UpdateJobTitleDto>.Fail(updateResult.Errors);

                var saveResult = await _accountUoW.SaveAsync();
                if (!saveResult.Succeeded)
                    return ReturnBase<UpdateJobTitleDto>.Fail(saveResult.Errors);

                var mappedResult = _mapper.Map<UpdateJobTitleDto>(entity);

                return ReturnBase<UpdateJobTitleDto>.Success(mappedResult);
            }
            catch (Exception ex)
            {
                var realException = ex.InnerException ?? ex;
                return ReturnBase<UpdateJobTitleDto>.Fail(realException, _exceptionManager);
            }
        }
        private IJobTitleCommandRepository _commands
        {
            get { return _accountUoW.JobTitleCommandRepository; }
        }

    }
}
