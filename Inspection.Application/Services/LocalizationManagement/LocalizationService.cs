using AutoMapper;
using Inspection.Application.Contracts.Dto.LocalizationDto;
using Inspection.Application.Contracts.Managers;
using Inspection.Application.Contracts.Services.LocalizationManagement;
using Inspection.Application.Contracts.UnitOfWork;
using Inspection.Application.Services.ServicesBase;
using Inspection.Domain.Models.Localizations;
using NDS.Shared.Application.DataQuery;
using NDS.Shared.Application.SharedModels;
using NDS.Shared.Kernel.BaseReturnTypes;
using NDS.Shared.Kernel.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inspection.Application.Services.LocalizationManagement
{
    internal class LocalizationService : AccountsServiceBase, ILocalizationService
    {
        public LocalizationService(IAccountUnitOfWork accountUoW, IAccountsQueriesManager queriesManager, IMapper mapper, IExceptionManager exceptionManager) : base(accountUoW, queriesManager, mapper, exceptionManager)
        {
        }

       
        public async Task<ReturnBase<CreateLocalizationDto>> InsertLocalizationAsync(CreateLocalizationDto insertDto)
        {
            try
            {
                //var getEntityResult = await _queriesManager.Localization.GetLocalizationItemAsync(insertDto.Translate);
                //if(getEntityResult.Result is not null)
                //{
                //    var error = new ReturnBaseError
                //    {
                //        ErrorCode = "400",
                //        ErrorMessage = "Translation Already Exist",
                //        Source = "Insert Localization"
                //    };
                //    var listOfErrors = new List<ReturnBaseError>
                //    {
                //        error
                //    };

                //    return ReturnBase<CreateLocalizationDto>.Fail(listOfErrors);
                //}
                var mappedResult = _mapper.Map<Localization>(insertDto);

               var insertResult = await _accountUoW.Localization.InsertAsync(mappedResult);

                if (!insertResult.Succeeded)
                    return ReturnBase<CreateLocalizationDto>.Fail(insertResult.Errors);


                var savedResult = await _accountUoW.SaveAsync();

                if(!savedResult.Succeeded)
                    return ReturnBase<CreateLocalizationDto>.Fail(savedResult.Errors);

                var returnResult = _mapper.Map<CreateLocalizationDto>(mappedResult);

                return ReturnBase<CreateLocalizationDto>.Success(returnResult);
            }
            catch (Exception ex)
            {
                return ReturnBase<CreateLocalizationDto>.Fail(ex, _exceptionManager);
            }
        }
        public async Task<ReturnBase<UpdateLocalizationDto>> UpdateLocalizationAsync(UpdateLocalizationDto updateDto)
        {
           try
           {
                var mappedResult = _mapper.Map<Localization>(updateDto);
                if(mappedResult is null)
                {
                    var error = new ReturnBaseError
                    {
                        ErrorCode = "400",
                        ErrorMessage = "Some thing went wrong, please try again!",
                        Source = "Update Localization"
                    };
                    var listOfErrors = new List<ReturnBaseError>
                    {
                        error
                    };

                    return ReturnBase<UpdateLocalizationDto>.Fail(listOfErrors);
                }

                var updateResult = await _accountUoW.Localization.UpdateAsync(mappedResult);

                if(!updateResult.Succeeded)
                    return ReturnBase<UpdateLocalizationDto>.Fail(updateResult.Errors);

                var saveResult = await _accountUoW.SaveAsync();

                if(!saveResult.Succeeded)
                    return ReturnBase<UpdateLocalizationDto>.Fail(saveResult.Errors);

                var returnResult = _mapper.Map<UpdateLocalizationDto>(mappedResult);

                return ReturnBase<UpdateLocalizationDto>.Success(returnResult);
           }
           catch(Exception ex)
           {
                return ReturnBase<UpdateLocalizationDto>.Fail(ex, _exceptionManager);
            }
        }
        public async Task<ReturnBase<UpdateLocalizationDto>> DeleteLocalizationAsync(EntityKeyValueDictionary keyValuePairs)
        {
            try
            {
                var deleteResult = await _accountUoW.Localization.DeleteAsync(keyValuePairs);
                if(!deleteResult.Succeeded)
                    return ReturnBase<UpdateLocalizationDto>.Fail(deleteResult.Errors);
                
                var saveResult = await _accountUoW.SaveAsync();
                if (!saveResult.Succeeded)
                    return ReturnBase<UpdateLocalizationDto>.Fail(saveResult.Errors);

                var mappedResult = _mapper.Map<UpdateLocalizationDto>(deleteResult.Result);

                return ReturnBase<UpdateLocalizationDto>.Success(mappedResult);
            }
            catch(Exception ex)
            {
                return ReturnBase<UpdateLocalizationDto>.Fail(ex, _exceptionManager);
            }
        }
        public async Task<ReturnBase<IEnumerable<GetLocalizationDto>>> GetLocalizationListAsync(SqlQueryOptions sqlQueryOptions)
        {
            try
            {
                var getResult = await _queriesManager.Localization.GetLocalizationListAsync(sqlQueryOptions);

                if (!getResult.Succeeded)
                    return ReturnBase<IEnumerable<GetLocalizationDto>>.Fail(getResult.Errors);

                return ReturnBase<IEnumerable<GetLocalizationDto>>.Success(getResult.Result);
            }
            catch(Exception ex)
            {
                return ReturnBase<IEnumerable<GetLocalizationDto>>.Fail(ex, _exceptionManager);
            }
        }

        public async Task<ReturnBase<IEnumerable<GetLocalizationDto>>> GetList()
        {
            try
            {
                var getResult = await _queriesManager.Localization.GetAllAsync();

                if (!getResult.Succeeded)
                    return ReturnBase<IEnumerable<GetLocalizationDto>>.Fail(getResult.Errors);

                return ReturnBase<IEnumerable<GetLocalizationDto>>.Success(_mapper.Map<IEnumerable<GetLocalizationDto>>(getResult.Result));
            }
            catch (Exception ex)
            {
                return ReturnBase<IEnumerable<GetLocalizationDto>>.Fail(ex, _exceptionManager);
            }
        }

        public async Task<ReturnBase<Localization>> DeleteLocalization(UpdateLocalizationDto model)
        {
            try
            {
                var deleteResult = await _accountUoW.Localization.DeleteLocalizationAsync(model);
                if (!deleteResult.Succeeded)
                    return ReturnBase<Localization>.Fail(deleteResult.Errors);

                var saveResult = await _accountUoW.SaveAsync();
                if (!saveResult.Succeeded)
                    return ReturnBase<Localization>.Fail(saveResult.Errors);

                var mappedResult = _mapper.Map<Localization>(deleteResult.Result);

                return ReturnBase<Localization>.Success(mappedResult);
            }
            catch (Exception ex) 
            {
                return ReturnBase<Localization>.Fail(ex, _exceptionManager);
            }
        }
    }
}
