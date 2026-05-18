using AutoMapper;
using Inspection.Application.Contracts.Dto.AccountingDtos.AccountingSetupDtos.BankAccountDTOs;
using Inspection.Application.Contracts.Managers;
using Inspection.Application.Contracts.Repositories.Command.Accounting.AccountSetup.BankAccounts;
using Inspection.Application.Contracts.Services.Accounting.AccountSetup.BankAccounts;
using Inspection.Application.Contracts.UnitOfWork;
using Inspection.Application.Services.ServicesBase;
using Inspection.Application.Shared.ExcelTemplate;
using Inspection.Domain.Models.Accounting.AccountingSetup.BankAccounts;
using NDS.Shared.Application.DataQuery;
using NDS.Shared.Application.Multitenant;
using NDS.Shared.Kernel.BaseReturnTypes;
using NDS.Shared.Kernel.Exceptions;

namespace Inspection.Application.Services.Accounting.AccountSetup.BankAccounts
{
    internal class BankAccountService : AccountsServiceBase, IBankAccountService
    {
        private readonly ITenantResolver _tenantResolver;
        private readonly IExcelTemplateGenerator _templateGenerator;

        public BankAccountService(IAccountUnitOfWork accountUoW, IAccountsQueriesManager queriesManager, IMapper mapper, IExceptionManager exceptionManager, ITenantResolver tenantResolver, IExcelTemplateGenerator templateGenerator) : base(accountUoW, queriesManager, mapper, exceptionManager)
        {
            _tenantResolver = tenantResolver;
            _templateGenerator = templateGenerator;
        }
        public async Task<ReturnBase<BankAccountDto>> Create(BankAccountCreateDto createDto)
        {
            try
            {


                var entity = _mapper.Map<BankAccount>(createDto);

                entity.Tenant_ID = _tenantResolver.GetTenantName();


                var insertResult = await _commands.InsertAsync(entity);
                if (!insertResult.Succeeded)
                {
                    return ReturnBase<BankAccountDto>.Fail(insertResult.Errors);
                }

                var saveResult = await _accountUoW.SaveAsync();
                if (!saveResult.Succeeded)
                {
                    return ReturnBase<BankAccountDto>.Fail(saveResult.Errors);
                }

                var resultDto = _mapper.Map<BankAccountDto>(entity);

                return ReturnBase<BankAccountDto>.Success(resultDto);
            }
            catch (Exception ex)
            {
                return ReturnBase<BankAccountDto>.Fail(ex, _exceptionManager);
            }
        }

        public async Task<ReturnBase<BankAccountDto>> Update(BankAccountUpdateDto updateDto)
        {
            try
            {
                // Load existing entity
                var entity = await _queriesManager.BankAccounts.GetById(updateDto.Id);
                if (entity == null)
                {
                    return ReturnBase<BankAccountDto>.Fail(new List<ReturnBaseError>
                    {
                        new()
                        {
                            ErrorCode = "404",
                            ErrorMessage = "Cost Unit Not Found"
                        }
                    });
                }

                entity.Tenant_ID = _tenantResolver.GetTenantName();



                // Map DTO → EXISTING entity (DO NOT replace instance)
                _mapper.Map(updateDto, entity);

                // Persist changes
                var updateResult = await _commands.UpdateAsync(entity);
                if (!updateResult.Succeeded)
                    return ReturnBase<BankAccountDto>.Fail(updateResult.Errors);

                var saveResult = await _accountUoW.SaveAsync();
                if (!saveResult.Succeeded)
                    return ReturnBase<BankAccountDto>.Fail(saveResult.Errors);

                var mappedResult = _mapper.Map<BankAccountDto>(entity);

                return ReturnBase<BankAccountDto>.Success(mappedResult);
            }
            catch (Exception ex)
            {
                return ReturnBase<BankAccountDto>.Fail(ex, _exceptionManager);
            }
        }

        public async Task<ReturnBase<BankAccountDto>> Delete(long id)
        {
            try
            {
                var entity = await _queriesManager.BankAccounts.GetById(id);
                if (entity is null)
                {
                    var error = new ReturnBaseError
                    {
                        ErrorCode = "404",
                        ErrorMessage = "Bank Account Not Found"
                    };
                    var listOfErrors = new List<ReturnBaseError> { error };
                    return ReturnBase<BankAccountDto>.Fail(listOfErrors);
                }

                var deleteResult = await _commands.HardDeleteById(id);
                if (!deleteResult.Succeeded)
                    return ReturnBase<BankAccountDto>.Fail(deleteResult.Errors);

                var saveResult = await _accountUoW.SaveAsync();
                if (!saveResult.Succeeded)
                    return ReturnBase<BankAccountDto>.Fail(saveResult.Errors);

                var mappedResult = _mapper.Map<BankAccountDto>(entity);
                return ReturnBase<BankAccountDto>.Success(mappedResult);
            }
            catch (Exception ex)
            {
                return ReturnBase<BankAccountDto>.Fail(ex, _exceptionManager);
            }
        }

        public async Task<ReturnBase<IEnumerable<BankAccountReturnSearchDto>>> Search(SqlQueryOptions sqlQueryOptions)
        {
            try
            {
                var getResult = await _queriesManager.BankAccounts.Search(sqlQueryOptions);
                if (!getResult.Succeeded)
                    return ReturnBase<IEnumerable<BankAccountReturnSearchDto>>.Fail(getResult.Errors);

                return ReturnBase<IEnumerable<BankAccountReturnSearchDto>>.Success(getResult.Result);
            }
            catch (Exception ex)
            {
                return ReturnBase<IEnumerable<BankAccountReturnSearchDto>>.Fail(ex, _exceptionManager);
            }
        }

        public async Task<ReturnBase<BankAccountDto>> GetById(long id)
        {
            try
            {
                var entity = await _queriesManager.BankAccounts.GetById(id);
                if (entity is null)
                {
                    var error = new ReturnBaseError
                    {
                        ErrorCode = "404",
                        ErrorMessage = "Bank Account Not Found"
                    };
                    var listOfErrors = new List<ReturnBaseError>() { error };
                    return ReturnBase<BankAccountDto>.Fail(listOfErrors);
                }

                var mappedResult = _mapper.Map<BankAccountDto>(entity);

                return ReturnBase<BankAccountDto>.Success(mappedResult);
            }
            catch (Exception ex)
            {
                return ReturnBase<BankAccountDto>.Fail(ex, _exceptionManager);
            }
        }





        private IBankAccountCommandRepository _commands
        {
            get { return _accountUoW.BankAccount; }
        }

    }

}
