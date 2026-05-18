using AutoMapper;
using Inspection.Application.Contracts.Dto.HRManagement.ApplicantCVs;
using Inspection.Application.Contracts.Managers;
using Inspection.Application.Contracts.Repositories.Command.HRManagement.ApplicantCVs;
using Inspection.Application.Contracts.Repositories.Query.HRManagement.ApplicantCVs;
using Inspection.Application.Contracts.Services.HRManagement.ApplicantCVs;
using Inspection.Application.Contracts.UnitOfWork;
using Inspection.Application.Services.ServicesBase;
using Inspection.Domain.Models.HRManagement.ApplicantCVs;
using NDS.Shared.Application.DataQuery;
using NDS.Shared.Kernel.BaseReturnTypes;
using NDS.Shared.Kernel.Exceptions;

namespace Inspection.Application.Services.HRManagement.ApplicantCVs
{
    public class ApplicantCVService : AccountsServiceBase, IApplicantCVService
    {
        public ApplicantCVService(IAccountUnitOfWork accountUoW, IAccountsQueriesManager queriesManager, IMapper mapper, IExceptionManager exceptionManager) : base(accountUoW, queriesManager, mapper, exceptionManager)
        {
        }

        public async Task<ReturnBase<UpdateApplicantCVDto>> DeleteApplicantCVTypeAsync(long id)
        {
            try
            {
                var entity = await _queriesManager.ApplicantCVQueryRepository.GetByIdAsync(id);
                if (entity is null)
                {
                    var error = new ReturnBaseError
                    {
                        ErrorCode = "404",
                        ErrorMessage = "Company Not Found"
                    };
                    var listOfErrors = new List<ReturnBaseError>() { error };
                    return ReturnBase<UpdateApplicantCVDto>.Fail(listOfErrors);
                }

                var deleteResult = await _commands.DeleteByIdAsync(id);

                if (!deleteResult.Succeeded)
                    return ReturnBase<UpdateApplicantCVDto>.Fail(deleteResult.Errors);

                var saveResult = await _accountUoW.SaveAsync();

                if (!saveResult.Succeeded)
                    return ReturnBase<UpdateApplicantCVDto>.Fail(saveResult.Errors);

                var mappedResult = _mapper.Map<UpdateApplicantCVDto>(entity);

                return ReturnBase<UpdateApplicantCVDto>.Success(mappedResult);

            }
            catch (Exception ex)
            {
                return ReturnBase<UpdateApplicantCVDto>.Fail(ex, _exceptionManager);
            }
        }

        public async Task<ReturnBase<ApplicantCVDto>> GetApplicantCVTypeByIdAsync(long id)
        {
            try
            {
                var entity = await _queriesManager.ApplicantCVQueryRepository.GetByIdAsync(id);
                if (entity is null)
                {
                    var error = new ReturnBaseError
                    {
                        ErrorCode = "404",
                        ErrorMessage = "Company Not Found"
                    };
                    var listOfErrors = new List<ReturnBaseError>() { error };
                    return ReturnBase<ApplicantCVDto>.Fail(listOfErrors);
                }

                var mappedResult = _mapper.Map<ApplicantCVDto>(entity);

                return ReturnBase<ApplicantCVDto>.Success(mappedResult);
            }
            catch (Exception ex)
            {
                return ReturnBase<ApplicantCVDto>.Fail(ex, _exceptionManager);
            }
        }

        public async Task<ReturnBase<IEnumerable<ApplicantCVDto>>> GetApplicantCVTypeListAsync(SqlQueryOptions sqlQueryOptions)
        {
            try
            {
                var getResult = await _queriesManager.ApplicantCVQueryRepository.GetListAsync(sqlQueryOptions);
                if (!getResult.Succeeded)
                    return ReturnBase<IEnumerable<ApplicantCVDto>>.Fail(getResult.Errors);

                return ReturnBase<IEnumerable<ApplicantCVDto>>.Success(getResult.Result);
            }
            catch (Exception ex)
            {
                return ReturnBase<IEnumerable<ApplicantCVDto>>.Fail(ex, _exceptionManager);
            }
        }

        public async Task<ReturnBase<UpdateApplicantCVDto>> InsertApplicantCVTypeAsync(CreateApplicantCVDto insertDto)
        {

            try
            {
                var entity = _mapper.Map<ApplicantCV>(insertDto);

                var insertResult = await _commands.InsertAsync(entity);
                if (!insertResult.Succeeded)
                {
                    return ReturnBase<UpdateApplicantCVDto>.Fail(insertResult.Errors);
                }

                var saveResult = await _accountUoW.SaveAsync();
                if (!saveResult.Succeeded)
                {
                    return ReturnBase<UpdateApplicantCVDto>.Fail(saveResult.Errors);
                }

                var resultDto = _mapper.Map<UpdateApplicantCVDto>(entity);

                return ReturnBase<UpdateApplicantCVDto>.Success(resultDto);
            }
            catch (Exception ex)
            {
                return ReturnBase<UpdateApplicantCVDto>.Fail(ex, _exceptionManager);
            }
        }

        //public async Task<ReturnBase<UpdateApplicantCVDto>> UpdateApplicantCVTypeAsync(UpdateApplicantCVDto updateDto, long id)
        //{

        //    try
        //    {
        //        var entity = await _queriesManager.ApplicantCVQueryRepository.GetByIdAsync(id);
        //        if (entity is null)
        //        {
        //            var error = new ReturnBaseError
        //            {
        //                ErrorCode = "404",
        //                ErrorMessage = "Company Not Found"
        //            };
        //            var listOfErrors = new List<ReturnBaseError>() { error };
        //            return ReturnBase<UpdateApplicantCVDto>.Fail(listOfErrors);
        //        }


        //        _mapper.Map(updateDto, entity);
        //        var updateResult = await _commands.UpdateAsync(entity);

        //        if (!updateResult.Succeeded)
        //            return ReturnBase<UpdateApplicantCVDto>.Fail(updateResult.Errors);

        //        var saveResult = await _accountUoW.SaveAsync();

        //        if (!saveResult.Succeeded)
        //            return ReturnBase<UpdateApplicantCVDto>.Fail(saveResult.Errors);

        //        var mappedResult = _mapper.Map<UpdateApplicantCVDto>(entity);

        //        return ReturnBase<UpdateApplicantCVDto>.Success(mappedResult);

        //    }
        //    catch (Exception ex)
        //    {
        //        return ReturnBase<UpdateApplicantCVDto>.Fail(ex, _exceptionManager);
        //    }
        //}
        public async Task<ReturnBase<UpdateApplicantCVDto>> UpdateApplicantCVTypeAsync(UpdateApplicantCVDto updateDto, long id)
        {
            try
            {
                var entity = await _queriesManager.ApplicantCVQueryRepository.GetByIdAsync(id);
                if (entity is null)
                {
                    var error = new ReturnBaseError
                    {
                        ErrorCode = "404",
                        ErrorMessage = "ApplicantCV Not Found"
                    };
                    return ReturnBase<UpdateApplicantCVDto>.Fail(new List<ReturnBaseError> { error });
                }

                if (updateDto.JobRequestId.HasValue)
                    entity.JobRequestId = updateDto.JobRequestId.Value;

                if (!string.IsNullOrWhiteSpace(updateDto.FullName))
                    entity.FullName = updateDto.FullName!;

                if (!string.IsNullOrWhiteSpace(updateDto.Email))
                    entity.Email = updateDto.Email!;

                if (!string.IsNullOrWhiteSpace(updateDto.Phone))
                    entity.Phone = updateDto.Phone!;

                if (!string.IsNullOrWhiteSpace(updateDto.CVUrl))
                    entity.CVUrl = updateDto.CVUrl!;

                if (!string.IsNullOrWhiteSpace(updateDto.Qualifications))
                    entity.Qualifications = updateDto.Qualifications!;

                if (updateDto.Status.HasValue)
                    entity.Status = updateDto.Status.Value;

                if (updateDto.IsInterviewed.HasValue)
                    entity.IsInterviewed = updateDto.IsInterviewed.Value;

                var updateResult = await _commands.UpdateAsync(entity);
                if (!updateResult.Succeeded)
                    return ReturnBase<UpdateApplicantCVDto>.Fail(updateResult.Errors);

                var saveResult = await _accountUoW.SaveAsync();
                if (!saveResult.Succeeded)
                    return ReturnBase<UpdateApplicantCVDto>.Fail(saveResult.Errors);

                var updatedEntity = await _queriesManager.ApplicantCVQueryRepository.GetByIdAsync(id);


                var mappedResult = new UpdateApplicantCVDto
                {
                    Id = entity.Id,
                    JobRequestId = entity.JobRequestId,
                    FullName = entity.FullName,
                    Email = entity.Email,
                    Phone = entity.Phone,
                    CVUrl = entity.CVUrl,
                    Qualifications = entity.Qualifications,
                    Status = entity.Status,
                    IsInterviewed = entity.IsInterviewed
                };

                return ReturnBase<UpdateApplicantCVDto>.Success(mappedResult);
            }
            catch (Exception ex)
            {
                return ReturnBase<UpdateApplicantCVDto>.Fail(ex, _exceptionManager);
            }
        }


        public async Task<ReturnBase<bool>> ChangeStatus(long id, ChangeApplicantStatusRequest Status)
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
        public async Task<ReturnBase<IEnumerable<ApplicantCVDtoLookUpForNames>>> GetLookUpCompanyForNamesAsync(SqlQueryOptions queryOptions)
        {
            var result = await this._queriesManager.ApplicantCVQueryRepository.GetLookUpCompanyForNamesAsync(queryOptions);

            var mappedResult = _mapper.Map<IEnumerable<ApplicantCVDtoLookUpForNames>>(result.Result);

            return ReturnBase<IEnumerable<ApplicantCVDtoLookUpForNames>>.Success(mappedResult);

        }
        private IApplicantCVCommandRepository _commands
        {
            get { return _accountUoW.ApplicantCVCommandRepository; }
        }

        private IApplicantCVQueryRepository _queriesMaster => _queriesManager.ApplicantCVQueryRepository;
    }
}
