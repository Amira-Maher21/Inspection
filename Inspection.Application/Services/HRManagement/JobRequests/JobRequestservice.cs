using AutoMapper;
using Inspection.Application.Contracts.Dto.HRManagement.ApplicantCVs;
using Inspection.Application.Contracts.Dto.HRManagement.JobRequests;
using Inspection.Application.Contracts.Managers;
using Inspection.Application.Contracts.Repositories.Command.HRManagement.JobRequests;
using Inspection.Application.Contracts.Repositories.Query.HRManagement.ApplicantCVs;
using Inspection.Application.Contracts.Repositories.Query.HRManagement.JobRequests;
using Inspection.Application.Contracts.Services.HRManagement.JobRequests;
using Inspection.Application.Contracts.UnitOfWork;
using Inspection.Application.Services.ServicesBase;
using Inspection.Domain.Models.HRManagement.JobRequests;
using NDS.Shared.Application.DataQuery;
using NDS.Shared.Kernel.BaseReturnTypes;
using NDS.Shared.Kernel.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inspection.Application.Services.HRManagement.JobRequests
{
    public class JobRequestservice : AccountsServiceBase, IJobRequestService
    {
        public JobRequestservice(IAccountUnitOfWork accountUoW, IAccountsQueriesManager queriesManager, IMapper mapper, IExceptionManager exceptionManager) : base(accountUoW, queriesManager, mapper, exceptionManager)
        {
        }

        public async Task<ReturnBase<UpdateJobRequestDto>> DeleteJobRequestAsync(long id)
        {
            try
            {
                var entity = await _queriesManager.JobRequestQueryRepository.GetByIdAsync(id);
                if (entity is null)
                {
                    var error = new ReturnBaseError
                    {
                        ErrorCode = "404",
                        ErrorMessage = "JobRequest Not Found"
                    };
                    var listOfErrors = new List<ReturnBaseError>() { error };
                    return ReturnBase<UpdateJobRequestDto>.Fail(listOfErrors);
                }

                var deleteResult = await _commands.DeleteByIdAsync(id);

                if (!deleteResult.Succeeded)
                    return ReturnBase<UpdateJobRequestDto>.Fail(deleteResult.Errors);

                var saveResult = await _accountUoW.SaveAsync();

                if (!saveResult.Succeeded)
                    return ReturnBase<UpdateJobRequestDto>.Fail(saveResult.Errors);

                var mappedResult = _mapper.Map<UpdateJobRequestDto>(entity);

                return ReturnBase<UpdateJobRequestDto>.Success(mappedResult);

            }
            catch (Exception ex)
            {
                return ReturnBase<UpdateJobRequestDto>.Fail(ex, _exceptionManager);
            }
        }

        public async Task<ReturnBase<JobRequestDto>> GetJobRequestByIdAsync(long id)
        {
            try
            {
                var entity = await _queriesManager.JobRequestQueryRepository.GetByIdAsync(id);
                if (entity is null)
                {
                    var error = new ReturnBaseError
                    {
                        ErrorCode = "404",
                        ErrorMessage = "Company Not Found"
                    };
                    var listOfErrors = new List<ReturnBaseError>() { error };
                    return ReturnBase<JobRequestDto>.Fail(listOfErrors);
                }

                var mappedResult = _mapper.Map<JobRequestDto>(entity);

                return ReturnBase<JobRequestDto>.Success(mappedResult);
            }
            catch (Exception ex)
            {
                return ReturnBase<JobRequestDto>.Fail(ex, _exceptionManager);
            }
        }

        public async Task<ReturnBase<IEnumerable<JobRequestDto>>> GetJobRequestListAsync(SqlQueryOptions sqlQueryOptions)
        {
            try
            {
                var getResult = await _queriesManager.JobRequestQueryRepository.GetListAsync(sqlQueryOptions);
                if (!getResult.Succeeded)
                    return ReturnBase<IEnumerable<JobRequestDto>>.Fail(getResult.Errors);

                return ReturnBase<IEnumerable<JobRequestDto>>.Success(getResult.Result);
            }
            catch (Exception ex)
            {
                return ReturnBase<IEnumerable<JobRequestDto>>.Fail(ex, _exceptionManager);
            }
        }

        public async Task<ReturnBase<IEnumerable<JobRequestLookUpForNames>>> GetLookUpCompanyForNamesAsync(SqlQueryOptions queryOptions)
        {
            //var result = await this._queriesManager.JobRequestQueryRepository.GetLookUpCompanyForNamesAsync(queryOptions);

            //var mappedResult = _mapper.Map<IEnumerable<JobRequestLookUpForNames>>(result.Result);

            //return ReturnBase<IEnumerable<JobRequestLookUpForNames>>.Success(mappedResult);
            var result = await this._queriesManager.JobRequestQueryRepository.GetLookUpCompanyForNamesAsync(queryOptions);

            var mappedResult = result.Result.Select(j => new JobRequestLookUpForNames
            {
                Id = j.Id,
                DepartmentName = j.DepartmentName,
                JobTitleName = j.JobTitleName
            });

            return ReturnBase<IEnumerable<JobRequestLookUpForNames>>.Success(mappedResult);
        }

        public async Task<ReturnBase<UpdateJobRequestDto>> InsertJobRequestAsync(CreateJobRequestDto insertDto)
        {
            try
            {
                var entity = _mapper.Map<JobRequest>(insertDto);

                var insertResult = await _commands.InsertAsync(entity);
                if (!insertResult.Succeeded)
                {
                    return ReturnBase<UpdateJobRequestDto>.Fail(insertResult.Errors);
                }

                var saveResult = await _accountUoW.SaveAsync();
                if (!saveResult.Succeeded)
                {
                    return ReturnBase<UpdateJobRequestDto>.Fail(saveResult.Errors);
                }

                var resultDto = _mapper.Map<UpdateJobRequestDto>(entity);

                return ReturnBase<UpdateJobRequestDto>.Success(resultDto);
            }
            catch (Exception ex)
            {
                return ReturnBase<UpdateJobRequestDto>.Fail(ex, _exceptionManager);
            }
        }

        public async Task<ReturnBase<UpdateJobRequestDto>> UpdateJobRequestAsync(UpdateJobRequestDto updateDto, long id)
        {
            try
            {
                var entity = await _queriesManager.JobRequestQueryRepository.GetByIdAsync(id);
                if (entity == null)
                {
                    var error = new ReturnBaseError
                    {
                        ErrorCode = "404",
                        ErrorMessage = "JobRequest Not Found"
                    };
                    return ReturnBase<UpdateJobRequestDto>.Fail(new List<ReturnBaseError> { error });
                }

                _mapper.Map(updateDto, entity);

                var updateResult = await _commands.UpdateAsync(entity);
                if (!updateResult.Succeeded)
                    return ReturnBase<UpdateJobRequestDto>.Fail(updateResult.Errors);

                var saveResult = await _accountUoW.SaveAsync();
                if (!saveResult.Succeeded)
                    return ReturnBase<UpdateJobRequestDto>.Fail(saveResult.Errors);

                var mappedResult = _mapper.Map<UpdateJobRequestDto>(entity);

                return ReturnBase<UpdateJobRequestDto>.Success(mappedResult);
            }
            catch (Exception ex)
            {
                var realException = ex.InnerException ?? ex;
                return ReturnBase<UpdateJobRequestDto>.Fail(realException, _exceptionManager);
            }
        }
        public async Task<ReturnBase<bool>> ChangeStatus(long id, ChangejobRequestStatus Status)
        {
            try
            {
                var entityMaster = await _queriesMaster.GetByIdAsync(id);
                if (entityMaster == null)
                    return ReturnBase<bool>.Fail();
                entityMaster.Status = Status.Status;
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
        private IJobRequestCommandRepository _commands
        {
            get { return _accountUoW.JobRequestCommandRepository; }
        }
        private IJobRequestQueryRepository _queriesMaster => _queriesManager.JobRequestQueryRepository;

    }
}
