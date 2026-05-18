using AutoMapper;
using Inspection.Application.Contracts.Dto.AccountingDtos.AccountSystemDto.DefaultAccountTypeDto;
using Inspection.Application.Contracts.Managers;
using Inspection.Application.Contracts.Repositories.Command.Accounting.AccountSystem;
using Inspection.Application.Contracts.Services.Accounting.AccountSystem;
using Inspection.Application.Contracts.UnitOfWork;
using Inspection.Application.Services.ServicesBase;
using Inspection.Application.Shared.ExcelTemplate;
using Inspection.Application.Shared.SharedValidation;
using Inspection.Domain.Models.Accounting.AccountingSystem;
using NDS.Shared.Application.DataQuery;
using NDS.Shared.Application.Multitenant;
using NDS.Shared.Kernel.BaseReturnTypes;
using NDS.Shared.Kernel.Exceptions;

namespace Inspection.Application.Services.Accounting.AccountSystem
{
    internal class DefaultAccountTypeService : AccountsServiceBase, IDefaultAccountTypeService
    {
        private readonly ITenantResolver _tenantResolver;
        private readonly IExcelTemplateGenerator _templateGenerator;

        public DefaultAccountTypeService(IAccountUnitOfWork accountUoW, IAccountsQueriesManager queriesManager, IMapper mapper, IExceptionManager exceptionManager, ITenantResolver tenantResolver, IExcelTemplateGenerator templateGenerator) : base(accountUoW, queriesManager, mapper, exceptionManager)
        {
            _tenantResolver = tenantResolver;
            _templateGenerator = templateGenerator;
        }
        //done
        public async Task<ReturnBase<DefaultAccountTypeDto>> Create(
            DefaultAccountTypeCreateDto createDto)
        {
            try
            {
                createDto.Code.ValidateAsCode();
                createDto.Name.ValidateAsName();
                var entity = _mapper.Map<DefaultAccountType>(createDto);
                var insertResult = await _commands.InsertAsync(entity);
                if (!insertResult.Succeeded)
                {
                    return ReturnBase<DefaultAccountTypeDto>.Fail(insertResult.Errors);
                }

                var saveResult = await _accountUoW.SaveAsync();
                if (!saveResult.Succeeded)
                    return ReturnBase<DefaultAccountTypeDto>.Fail(saveResult.Errors);

                var resultDto = _mapper.Map<DefaultAccountTypeDto>(entity);
                return ReturnBase<DefaultAccountTypeDto>.Success(resultDto);
            }
            catch (Exception ex)
            {
                return ReturnBase<DefaultAccountTypeDto>.Fail(ex, _exceptionManager);
            }
        }
        //done
        public async Task<ReturnBase<DefaultAccountTypeDto>> Delete(long id)
        {
            try
            {
                var entity = await _queriesManager.DefaultAccountTypes.GetById(id);
                if (entity is null)
                {
                    var error = new ReturnBaseError
                    {
                        ErrorCode = "404",
                        ErrorMessage = "Default Account Type Not Found"
                    };
                    var listOfErrors = new List<ReturnBaseError>() { error };
                    return ReturnBase<DefaultAccountTypeDto>.Fail(listOfErrors);
                }

                var deleteResult = await _commands.DeleteById(id);

                if (!deleteResult.Succeeded)
                    return ReturnBase<DefaultAccountTypeDto>.Fail(deleteResult.Errors);

                var saveResult = await _accountUoW.SaveAsync();

                if (!saveResult.Succeeded)
                    return ReturnBase<DefaultAccountTypeDto>.Fail(saveResult.Errors);

                var mappedResult = _mapper.Map<DefaultAccountTypeDto>(entity);

                return ReturnBase<DefaultAccountTypeDto>.Success(mappedResult);

            }
            catch (Exception ex)
            {
                return ReturnBase<DefaultAccountTypeDto>.Fail(ex, _exceptionManager);
            }
        }
        //done
        public async Task<ReturnBase<List<DefaultAccountTypeDto>>> GetAll()
        {
            try
            {
                var result = await _queriesManager.DefaultAccountTypes.GetAll();

                if (!result.Succeeded)
                {
                    return ReturnBase<List<DefaultAccountTypeDto>>.Fail(result.Errors);
                }

                var mapped = _mapper.Map<List<DefaultAccountTypeDto>>(result.Result);

                return ReturnBase<List<DefaultAccountTypeDto>>.Success(mapped);
            }
            catch (Exception ex)
            {
                return ReturnBase<List<DefaultAccountTypeDto>>.Fail(ex, _exceptionManager);
            }
        }
        //done
        public async Task<ReturnBase<DefaultAccountTypeDto>> GetById(long id)
        {
            try
            {
                var entity = await _queriesManager.DefaultAccountTypes.GetById(id);
                if (entity is null)
                {
                    var error = new ReturnBaseError
                    {
                        ErrorCode = "404",
                        ErrorMessage = "Default Account Type not Found"
                    };
                    var listOfErrors = new List<ReturnBaseError>() { error };
                    return ReturnBase<DefaultAccountTypeDto>.Fail(listOfErrors);
                }

                var mappedResult = _mapper.Map<DefaultAccountTypeDto>(entity);

                return ReturnBase<DefaultAccountTypeDto>.Success(mappedResult);
            }
            catch (Exception ex)
            {
                return ReturnBase<DefaultAccountTypeDto>.Fail(ex, _exceptionManager);
            }
        }
        //done
        public async Task<ReturnBase<IEnumerable<DefaultAccountTypeReturnSearchDto>>> Search(SqlQueryOptions sqlQueryOptions)
        {
            try
            {
                var getResult = await _queriesManager.DefaultAccountTypes.Search(sqlQueryOptions);
                if (!getResult.Succeeded)
                    return ReturnBase<IEnumerable<DefaultAccountTypeReturnSearchDto>>.Fail(getResult.Errors);

                // Map ChartOfAccountDto to DefaultAccountTypeDto
                var mappedResult = _mapper.Map<IEnumerable<DefaultAccountTypeReturnSearchDto>>(getResult.Result);

                return ReturnBase<IEnumerable<DefaultAccountTypeReturnSearchDto>>.Success(mappedResult);
            }
            catch (Exception ex)
            {
                return ReturnBase<IEnumerable<DefaultAccountTypeReturnSearchDto>>.Fail(ex, _exceptionManager);
            }
        }

        public async Task<ReturnBase<DefaultAccountTypeDto>> Update(DefaultAccountTypeUpdateDto updateDto)
        {
            try
            {
                updateDto.Code.ValidateAsCode();
                updateDto.Name.ValidateAsName();
                var entity = await _queriesManager.DefaultAccountTypes.GetById(updateDto.Id);
                if (entity is null)
                {
                    var error = new ReturnBaseError
                    {
                        ErrorCode = "404",
                        ErrorMessage = "Default Account Type Not Found"
                    };
                    var listOfErrors = new List<ReturnBaseError>() { error };
                    return ReturnBase<DefaultAccountTypeDto>.Fail(listOfErrors);
                }



                entity = _mapper.Map<DefaultAccountType>(updateDto);
                var updateResult = await _commands.UpdateAsync(entity);

                if (!updateResult.Succeeded)
                    return ReturnBase<DefaultAccountTypeDto>.Fail(updateResult.Errors);

                var saveResult = await _accountUoW.SaveAsync();

                if (!saveResult.Succeeded)
                    return ReturnBase<DefaultAccountTypeDto>.Fail(saveResult.Errors);

                var mappedResult = _mapper.Map<DefaultAccountTypeDto>(entity);

                return ReturnBase<DefaultAccountTypeDto>.Success(mappedResult);

            }
            catch (Exception ex)
            {
                return ReturnBase<DefaultAccountTypeDto>.Fail(ex, _exceptionManager);
            }
        }

        private IDefaultAccountTypeCommandRepository _commands
        {
            get { return _accountUoW.DefaultAccountType; }
        }
    }
}
