using AutoMapper;
using Inspection.Application.Contracts.Dto.HRManagement.Departments;
using Inspection.Application.Contracts.Dto.HRManagement.JobOfferNegotiations;
using Inspection.Application.Contracts.Managers;
using Inspection.Application.Contracts.Repositories.Command.HRManagement.JobOfferNegotiations;
using Inspection.Application.Contracts.Services.HRManagement.JobOfferNegotiations;
using Inspection.Application.Contracts.UnitOfWork;
using Inspection.Application.Services.ServicesBase;
using Inspection.Domain.Models.HRManagement.JobOfferNegotiations;
using NDS.Shared.Application.DataQuery;
using NDS.Shared.Kernel.BaseReturnTypes;
using NDS.Shared.Kernel.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inspection.Application.Services.HRManagement.JobOfferNegotiations
{
    internal class JobOfferNegotiationService : AccountsServiceBase, IJobOfferNegotiationService
    {
        public JobOfferNegotiationService(IAccountUnitOfWork accountUoW, IAccountsQueriesManager queriesManager, IMapper mapper, IExceptionManager exceptionManager) : base(accountUoW, queriesManager, mapper, exceptionManager)
        {
        }
        public async Task<ReturnBase<UpdateJobOfferNegotiationDto>> DeleteJobOfferNegotiationTypeAsync(long id)
        {
            try
            {
                var entity = await _queriesManager.DepartmentQueryRepository.GetByIdAsync(id);
                if (entity is null)
                {
                    var error = new ReturnBaseError
                    {
                        ErrorCode = "404",
                        ErrorMessage = "department Not Found"
                    };
                    var listOfErrors = new List<ReturnBaseError>() { error };
                    return ReturnBase<UpdateJobOfferNegotiationDto>.Fail(listOfErrors);
                }

                var deleteResult = await _commands.DeleteByIdAsync(id);

                if (!deleteResult.Succeeded)
                    return ReturnBase<UpdateJobOfferNegotiationDto>.Fail(deleteResult.Errors);

                var saveResult = await _accountUoW.SaveAsync();

                if (!saveResult.Succeeded)
                    return ReturnBase<UpdateJobOfferNegotiationDto>.Fail(saveResult.Errors);

                var mappedResult = _mapper.Map<UpdateJobOfferNegotiationDto>(entity);

                return ReturnBase<UpdateJobOfferNegotiationDto>.Success(mappedResult);

            }
            catch (Exception ex)
            {
                return ReturnBase<UpdateJobOfferNegotiationDto>.Fail(ex, _exceptionManager);
            }
        }

        public async Task<ReturnBase<JobOfferNegotiationDto>> GetJobOfferNegotiationTypeByIdAsync(long id)
        {
            try
            {
                var entity = await _queriesManager.JobOfferNegotiationQueryRepository.GetByIdAsync(id);
                if (entity is null)
                {
                    var error = new ReturnBaseError
                    {
                        ErrorCode = "404",
                        ErrorMessage = "Company Not Found"
                    };
                    var listOfErrors = new List<ReturnBaseError>() { error };
                    return ReturnBase<JobOfferNegotiationDto>.Fail(listOfErrors);
                }

                var mappedResult = _mapper.Map<JobOfferNegotiationDto>(entity);

                return ReturnBase<JobOfferNegotiationDto>.Success(mappedResult);
            }
            catch (Exception ex)
            {
                return ReturnBase<JobOfferNegotiationDto>.Fail(ex, _exceptionManager);
            }
        }

      

        public async Task<ReturnBase<UpdateJobOfferNegotiationDto>> InsertJobOfferNegotiationTypeAsync(CreateJobOfferNegotiationDto insertDto)
        {
            try
            {
                var entity = _mapper.Map<JobOfferNegotiation>(insertDto);

                var insertResult = await _commands.InsertAsync(entity);
                if (!insertResult.Succeeded)
                {
                    return ReturnBase<UpdateJobOfferNegotiationDto>.Fail(insertResult.Errors);
                }

                var saveResult = await _accountUoW.SaveAsync();
                if (!saveResult.Succeeded)
                {
                    return ReturnBase<UpdateJobOfferNegotiationDto>.Fail(saveResult.Errors);
                }

                var resultDto = _mapper.Map<UpdateJobOfferNegotiationDto>(entity);

                return ReturnBase<UpdateJobOfferNegotiationDto>.Success(resultDto);
            }
            catch (Exception ex)
            {
                return ReturnBase<UpdateJobOfferNegotiationDto>.Fail(ex, _exceptionManager);
            }
        }

        public async Task<ReturnBase<UpdateJobOfferNegotiationDto>> UpdateJobOfferNegotiationTypeAsync(UpdateJobOfferNegotiationDto updateDto, long id)
        {

            try
            {
                var entity = await _queriesManager.JobOfferNegotiationQueryRepository.GetByIdAsync(id);
                if (entity == null)
                {
                    var error = new ReturnBaseError
                    {
                        ErrorCode = "404",
                        ErrorMessage = "JobOfferNegotiation Not Found"
                    };
                    return ReturnBase<UpdateJobOfferNegotiationDto>.Fail(new List<ReturnBaseError> { error });
                }

                _mapper.Map(updateDto, entity);

                var updateResult = await _commands.UpdateAsync(entity);
                if (!updateResult.Succeeded)
                    return ReturnBase<UpdateJobOfferNegotiationDto>.Fail(updateResult.Errors);

                var saveResult = await _accountUoW.SaveAsync();
                if (!saveResult.Succeeded)
                    return ReturnBase<UpdateJobOfferNegotiationDto>.Fail(saveResult.Errors);

                var mappedResult = _mapper.Map<UpdateJobOfferNegotiationDto>(entity);

                return ReturnBase<UpdateJobOfferNegotiationDto>.Success(mappedResult);
            }
            catch (Exception ex)
            {
                var realException = ex.InnerException ?? ex;
                return ReturnBase<UpdateJobOfferNegotiationDto>.Fail(realException, _exceptionManager);
            }
        }
        public async Task<ReturnBase<IEnumerable<JobOfferNegotiationDtoLookUpForNames>>> GetLookUpCompanyForNamesAsync(SqlQueryOptions queryOptions)
        {
          
            var result = await this._queriesManager.JobOfferNegotiationQueryRepository.GetLookUpCompanyForNamesAsync(queryOptions);

            var mappedResult = result.Result.Select(d => new JobOfferNegotiationDtoLookUpForNames
            {
                Id = d.Id,
                Name = d.ProposedSalary
            });

            return ReturnBase<IEnumerable<JobOfferNegotiationDtoLookUpForNames>>.Success(mappedResult);

        }

        public async Task<ReturnBase<IEnumerable<JobOfferNegotiationDto>>> GetJobOfferNegotiationTypeListAsync(SqlQueryOptions sqlQueryOptions)
        {
            try
            {
                var getResult = await _queriesManager.JobOfferNegotiationQueryRepository.GetListAsync(sqlQueryOptions);
                if (!getResult.Succeeded)
                    return ReturnBase<IEnumerable<JobOfferNegotiationDto>>.Fail(getResult.Errors);

                return ReturnBase<IEnumerable<JobOfferNegotiationDto>>.Success(getResult.Result);
            }
            catch (Exception ex)
            {
                return ReturnBase<IEnumerable<JobOfferNegotiationDto>>.Fail(ex, _exceptionManager);
            }
        }

        private IJobOfferNegotiationCommandRepository _commands
        {
            get { return _accountUoW.JobOfferNegotiationCommandRepository; }
        }

    }
}
