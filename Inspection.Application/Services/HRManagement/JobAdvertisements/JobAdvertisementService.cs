using AutoMapper;
using Inspection.Application.Contracts.Dto.HRManagement.JobAdvertisements;
using Inspection.Application.Contracts.Managers;
using Inspection.Application.Contracts.Repositories.Command.HRManagement.JobAdvertisements;

using Inspection.Application.Contracts.Services.HRManagement.JobAdvertisements;
using Inspection.Application.Contracts.UnitOfWork;
using Inspection.Application.Services.ServicesBase;
using Inspection.Domain.Models.HRManagement.JobAdvertisements;
using NDS.Shared.Application.DataQuery;
using NDS.Shared.Kernel.BaseReturnTypes;
using NDS.Shared.Kernel.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inspection.Application.Services.HRManagement.JobAdvertisements
{
    internal class JobAdvertisementService : AccountsServiceBase, IJobAdvertisementService
    {
        public JobAdvertisementService(IAccountUnitOfWork accountUoW, IAccountsQueriesManager queriesManager, IMapper mapper, IExceptionManager exceptionManager) : base(accountUoW, queriesManager, mapper, exceptionManager)
        {
        }
        public async Task<ReturnBase<UpdateJobAdvertisementDto>> DeleteJobAdvertisementTypeAsync(long id)
        {
            try
            {
                var entity = await _queriesManager.JobAdvertisementQueryRepository.GetByIdAsync(id);
                if (entity is null)
                {
                    var error = new ReturnBaseError
                    {
                        ErrorCode = "404",
                        ErrorMessage = "JobAdvertisement Not Found"
                    };
                    var listOfErrors = new List<ReturnBaseError>() { error };
                    return ReturnBase<UpdateJobAdvertisementDto>.Fail(listOfErrors);
                }

                var deleteResult = await _commands.DeleteByIdAsync(id);

                if (!deleteResult.Succeeded)
                    return ReturnBase<UpdateJobAdvertisementDto>.Fail(deleteResult.Errors);

                var saveResult = await _accountUoW.SaveAsync();

                if (!saveResult.Succeeded)
                    return ReturnBase<UpdateJobAdvertisementDto>.Fail(saveResult.Errors);

                var mappedResult = _mapper.Map<UpdateJobAdvertisementDto>(entity);

                return ReturnBase<UpdateJobAdvertisementDto>.Success(mappedResult);

            }
            catch (Exception ex)
            {
                return ReturnBase<UpdateJobAdvertisementDto>.Fail(ex, _exceptionManager);
            }
        }

        public async Task<ReturnBase<JobAdvertisementDto>> GetJobAdvertisementTypeByIdAsync(long id)
        {
            try
            {
                var entity = await _queriesManager.JobAdvertisementQueryRepository.GetByIdAsync(id);
                if (entity is null)
                {
                    var error = new ReturnBaseError
                    {
                        ErrorCode = "404",
                        ErrorMessage = "Company Not Found"
                    };
                    var listOfErrors = new List<ReturnBaseError>() { error };
                    return ReturnBase<JobAdvertisementDto>.Fail(listOfErrors);
                }

                var mappedResult = _mapper.Map<JobAdvertisementDto>(entity);

                return ReturnBase<JobAdvertisementDto>.Success(mappedResult);
            }
            catch (Exception ex)
            {
                return ReturnBase<JobAdvertisementDto>.Fail(ex, _exceptionManager);
            }
        }

        public async Task<ReturnBase<IEnumerable<JobAdvertisementDto>>> GetJobAdvertisementTypeListAsync(SqlQueryOptions sqlQueryOptions)
        {
            try
            {
                var getResult = await _queriesManager.JobAdvertisementQueryRepository.GetListAsync(sqlQueryOptions);
                if (!getResult.Succeeded)
                    return ReturnBase<IEnumerable<JobAdvertisementDto>>.Fail(getResult.Errors);

                return ReturnBase<IEnumerable<JobAdvertisementDto>>.Success(getResult.Result);
            }
            catch (Exception ex)
            {
                return ReturnBase<IEnumerable<JobAdvertisementDto>>.Fail(ex, _exceptionManager);
            }
        }

        public async Task<ReturnBase<UpdateJobAdvertisementDto>> InsertJobAdvertisementTypeAsync(CreateJobAdvertisementDto insertDto)
        {
            try
            {
                var entity = _mapper.Map<JobAdvertisement>(insertDto);

                var insertResult = await _commands.InsertAsync(entity);
                if (!insertResult.Succeeded)
                {
                    return ReturnBase<UpdateJobAdvertisementDto>.Fail(insertResult.Errors);
                }

                var saveResult = await _accountUoW.SaveAsync();
                if (!saveResult.Succeeded)
                {
                    return ReturnBase<UpdateJobAdvertisementDto>.Fail(saveResult.Errors);
                }

                var resultDto = _mapper.Map<UpdateJobAdvertisementDto>(entity);

                return ReturnBase<UpdateJobAdvertisementDto>.Success(resultDto);
            }
            catch (Exception ex)
            {
                return ReturnBase<UpdateJobAdvertisementDto>.Fail(ex, _exceptionManager);
            }
        }

        public async Task<ReturnBase<UpdateJobAdvertisementDto>> UpdateJobAdvertisementTypeAsync(UpdateJobAdvertisementDto updateDto, long id)
        {

            try
            {
                var entity = await _queriesManager.JobAdvertisementQueryRepository.GetByIdAsync(id);
                if (entity == null)
                {
                    var error = new ReturnBaseError
                    {
                        ErrorCode = "404",
                        ErrorMessage = "JobAdvertisement Not Found"
                    };
                    return ReturnBase<UpdateJobAdvertisementDto>.Fail(new List<ReturnBaseError> { error });
                }

                _mapper.Map(updateDto, entity);

                var updateResult = await _commands.UpdateAsync(entity);
                if (!updateResult.Succeeded)
                    return ReturnBase<UpdateJobAdvertisementDto>.Fail(updateResult.Errors);

                var saveResult = await _accountUoW.SaveAsync();
                if (!saveResult.Succeeded)
                    return ReturnBase<UpdateJobAdvertisementDto>.Fail(saveResult.Errors);

                var mappedResult = _mapper.Map<UpdateJobAdvertisementDto>(entity);

                return ReturnBase<UpdateJobAdvertisementDto>.Success(mappedResult);
            }
            catch (Exception ex)
            {
                var realException = ex.InnerException ?? ex;
                return ReturnBase<UpdateJobAdvertisementDto>.Fail(realException, _exceptionManager);
            }
        }
        public async Task<ReturnBase<IEnumerable<JobAdvertisementDtoLookUpForNames>>> GetLookUpCompanyForNamesAsync(SqlQueryOptions queryOptions)
        {
            //var result = await this._queriesManager.JobAdvertisementQueryRepository.GetLookUpCompanyForNamesAsync(queryOptions);

            //var mappedResult = _mapper.Map<IEnumerable<JobAdvertisementDtoLookUpForNames>>(result.Result);

            //return ReturnBase<IEnumerable<JobAdvertisementDtoLookUpForNames>>.Success(mappedResult);
            var result = await this._queriesManager.JobAdvertisementQueryRepository.GetLookUpCompanyForNamesAsync(queryOptions);

            var mappedResult = result.Result.Select(d => new JobAdvertisementDtoLookUpForNames
            {
                Id = d.Id,
                Name = d.Platform
            });

            return ReturnBase<IEnumerable<JobAdvertisementDtoLookUpForNames>>.Success(mappedResult);

        }
        private IJobAdvertisementCommandRepository _commands
        {
            get { return _accountUoW.JobAdvertisementCommandRepository; }
        }

    }
}
