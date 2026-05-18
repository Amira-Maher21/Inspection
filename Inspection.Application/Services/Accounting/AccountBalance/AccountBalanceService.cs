using AutoMapper;
using Inspection.Application.Contracts.Dto.AccountingDtos.AccountBalance;
using Inspection.Application.Contracts.Managers;
using Inspection.Application.Contracts.Repositories.Command.Accounting.AccountBalances;
using Inspection.Application.Contracts.Services.Accounting.AccountBalances;
using Inspection.Application.Contracts.UnitOfWork;
using Inspection.Application.Services.ServicesBase;
using Inspection.Application.Shared.ExcelTemplate;
using Inspection.Domain.Models.Accounting.AccountBalance;
using NDS.Shared.Application.Multitenant;
using NDS.Shared.Kernel.BaseReturnTypes;
using NDS.Shared.Kernel.Exceptions;

namespace Inspection.Application.Services.Accounting.AccountBalanceServices
{
    public class AccountBalanceService : AccountsServiceBase, IAccountBalanceService
    {
        private readonly ITenantResolver _tenantResolver;
        private readonly IExcelTemplateGenerator _templateGenerator;

        private IAccountBalanceCommandRepository _commands => _accountUoW.AccountBalance;

        public AccountBalanceService(
                IAccountUnitOfWork accountUoW,
                IAccountsQueriesManager queriesManager,
                IMapper mapper,
                IExceptionManager exceptionManager,
                ITenantResolver tenantResolver,
                IExcelTemplateGenerator templateGenerator
            )
            : base(accountUoW, queriesManager, mapper, exceptionManager)
        {
            _tenantResolver = tenantResolver;
            _templateGenerator = templateGenerator;
        }


        public async Task<ReturnBase<AccountBalanceDto>> Create(AccountBalanceCreateDto createDto)
        {
            try
            {
                //await ValidateQuantityRule(createDto.TotalCredit, createDto.TotalDebit);

                var entity = _mapper.Map<AccountBalance>(createDto);
                entity.Tenant_ID = _tenantResolver.GetTenantName();


                var insertResult = await _commands.InsertAsync(entity);
                if (!insertResult.Succeeded)
                    return ReturnBase<AccountBalanceDto>.Fail(insertResult.Errors);

                //var saveResult = await _accountUoW.SaveAsync();
                //if (!saveResult.Succeeded)
                //    return ReturnBase<AccountBalanceDto>.Fail(saveResult.Errors);

                var resultDto = _mapper.Map<AccountBalanceDto>(entity);
                return ReturnBase<AccountBalanceDto>.Success(resultDto);
            }
            catch (Exception ex)
            {
                return ReturnBase<AccountBalanceDto>.Fail(ex, _exceptionManager);
            }
        }


        public async Task<ReturnBase<AccountBalanceDto>> Update(AccountBalanceUpdateDto updateDto)
        {
            try
            {
                var entity = await _queriesManager.AccountBalance.GetById(updateDto.Id);
                if (entity == null)
                    return ReturnBase<AccountBalanceDto>.Fail(new List<ReturnBaseError>
                    {
                        new ReturnBaseError { ErrorCode = "404", ErrorMessage = "Account Balance Not Found" }
                    });

                //await ValidateQuantityRule(createDto.TotalCredit, createDto.TotalDebit);
                entity.Tenant_ID = _tenantResolver.GetTenantName();

                _mapper.Map(updateDto, entity);
                entity.Mod_User = "currentUser";
                entity.Mod_Date = DateTime.UtcNow;

                //var saveResult = await _accountUoW.SaveAsync();
                //if (!saveResult.Succeeded)
                //    return ReturnBase<AccountBalanceDto>.Fail(saveResult.Errors);

                var resultDto = _mapper.Map<AccountBalanceDto>(entity);
                return ReturnBase<AccountBalanceDto>.Success(resultDto);
            }
            catch (Exception ex)
            {
                return ReturnBase<AccountBalanceDto>.Fail(ex, _exceptionManager);
            }
        }


        public async Task<ReturnBase<AccountBalanceDto>> Delete(long id)
        {
            try
            {
                var entity = await _queriesManager.AccountBalance.GetById(id);
                if (entity == null)
                {
                    return ReturnBase<AccountBalanceDto>.Fail(new List<ReturnBaseError>
                    {
                        new ReturnBaseError
                        {
                            ErrorCode = "404",
                            ErrorMessage = "Account Balance Not Found"
                        }
                    });
                }

                var deleteResult = await _commands.DeleteById(id);
                if (!deleteResult.Succeeded)
                    return ReturnBase<AccountBalanceDto>.Fail(deleteResult.Errors);

                var saveResult = await _accountUoW.SaveAsync();
                if (!saveResult.Succeeded)
                    return ReturnBase<AccountBalanceDto>.Fail(saveResult.Errors);

                var mappedResult = _mapper.Map<AccountBalanceDto>(entity);
                return ReturnBase<AccountBalanceDto>.Success(mappedResult);
            }
            catch (Exception ex)
            {
                return ReturnBase<AccountBalanceDto>.Fail(ex, _exceptionManager);
            }
        }

        public async Task<AccountBalance?> GetByItemAsync(string tenantId, long companyId, long? chartOfAccountId)
        {
            var getResult = await _queriesManager.AccountBalance.GetByItemAsync(tenantId, companyId, chartOfAccountId);
            return getResult;
        }


        public async Task<ReturnBase<AccountBalanceDto>> GetById(long id)
        {
            try
            {
                var entity = await _queriesManager.AccountBalance.GetById(id);
                if (entity == null)
                {
                    return ReturnBase<AccountBalanceDto>.Fail(new List<ReturnBaseError>
                    {
                        new ReturnBaseError
                        {
                            ErrorCode = "404",
                            ErrorMessage = "Account Balance Not Found"
                        }
                    });
                }

                var mappedResult = _mapper.Map<AccountBalanceDto>(entity);
                return ReturnBase<AccountBalanceDto>.Success(mappedResult);
            }
            catch (Exception ex)
            {
                return ReturnBase<AccountBalanceDto>.Fail(ex, _exceptionManager);
            }
        }
        private ReturnBase<AccountBalanceDto> ValidateQuantityRule(decimal? totalDebit, decimal? totalCredit)
        {
            var inQty = totalDebit ?? 0;
            var outQty = totalCredit ?? 0;

            if ((inQty > 0 && outQty > 0) || (inQty == 0 && outQty == 0))
            {
                return ReturnBase<AccountBalanceDto>.Fail(new List<ReturnBaseError>
                {
                    new ReturnBaseError
                    {
                        ErrorCode = "400",
                        ErrorMessage = "Either TotalDebit or TotalCredit must be entered, not both or neither."
                    }
                });
            }

            return ReturnBase<AccountBalanceDto>.Success(null);
        }

        
    }
}