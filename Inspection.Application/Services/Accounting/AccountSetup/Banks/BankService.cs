using AutoMapper;
using Inspection.Application.Contracts.Dto.AccountingDtos.AccountingSetupDtos.BankDTOs;
using Inspection.Application.Contracts.Managers;
using Inspection.Application.Contracts.Repositories.Command.Accounting.AccountSetup.Banks;
using Inspection.Application.Contracts.Services.Accounting.AccountSetup.Banks;
using Inspection.Application.Contracts.UnitOfWork;
using Inspection.Application.Services.ServicesBase;
using Inspection.Application.Shared.ExcelTemplate;
using Inspection.Application.Shared.SharedValidation;
using Inspection.Domain.Models.Accounting.AccountingSetup.Banks;
using NDS.Shared.Application.DataQuery;
using NDS.Shared.Application.Multitenant;
using NDS.Shared.Kernel.BaseReturnTypes;
using NDS.Shared.Kernel.Exceptions;

namespace Inspection.Application.Services.Accounting.AccountSetup.Banks
{
    internal class BankService : AccountsServiceBase, IBankService
    {
        private readonly ITenantResolver _tenantResolver;
        private readonly IExcelTemplateGenerator _templateGenerator;

        public BankService(IAccountUnitOfWork accountUoW, IAccountsQueriesManager queriesManager, IMapper mapper, IExceptionManager exceptionManager, ITenantResolver tenantResolver, IExcelTemplateGenerator templateGenerator) : base(accountUoW, queriesManager, mapper, exceptionManager)
        {
            _tenantResolver = tenantResolver;
            _templateGenerator = templateGenerator;
        }

        public async Task<ReturnBase<BankDto>> Create(BankCreateDto createDto)
        {
            try
            {


                createDto.Code.ValidateAsCode();
                createDto.Name.ValidateAsName();
                var entity = _mapper.Map<Bank>(createDto);
                entity.Tenant_ID = _tenantResolver.GetTenantName();

                var insertResult = await _commands.InsertAsync(entity);
                if (!insertResult.Succeeded)
                {
                    return ReturnBase<BankDto>.Fail(insertResult.Errors);
                }

                var saveResult = await _accountUoW.SaveAsync();
                if (!saveResult.Succeeded)
                {
                    return ReturnBase<BankDto>.Fail(saveResult.Errors);
                }

                var resultDto = _mapper.Map<BankDto>(entity);

                return ReturnBase<BankDto>.Success(resultDto);
            }
            catch (Exception ex)
            {
                return ReturnBase<BankDto>.Fail(ex, _exceptionManager);
            }
        }

        public async Task<ReturnBase<BankDto>> Update(BankUpdateDto updateDto)
        {
            try
            {


                updateDto.Code.ValidateAsCode();
                updateDto.Name.ValidateAsName();
                // Load existing entity
                var entity = await _queriesManager.Banks.GetById(updateDto.Id);
                if (entity == null)
                {
                    return ReturnBase<BankDto>.Fail(new List<ReturnBaseError>
            {
                new()
                {
                    ErrorCode = "404",
                    ErrorMessage = "Bank Not Found"
                }
            });
                }


                entity.Tenant_ID = _tenantResolver.GetTenantName();




                // Map DTO → EXISTING entity (DO NOT replace instance)
                _mapper.Map(updateDto, entity);

                // Persist changes
                var updateResult = await _commands.UpdateAsync(entity);
                if (!updateResult.Succeeded)
                    return ReturnBase<BankDto>.Fail(updateResult.Errors);

                var saveResult = await _accountUoW.SaveAsync();
                if (!saveResult.Succeeded)
                    return ReturnBase<BankDto>.Fail(saveResult.Errors);

                // Return result
                var resultDto = _mapper.Map<BankDto>(entity);
                return ReturnBase<BankDto>.Success(resultDto);
            }
            catch (Exception ex)
            {
                return ReturnBase<BankDto>.Fail(ex, _exceptionManager);
            }
        }

        public async Task<ReturnBase<BankDto>> Delete(long id)
        {
            try
            {
                var entity = await _queriesManager.Banks.GetById(id);
                if (entity is null)
                {
                    var error = new ReturnBaseError
                    {
                        ErrorCode = "404",
                        ErrorMessage = "Bank Not Found"
                    };
                    var listOfErrors = new List<ReturnBaseError>() { error };
                    return ReturnBase<BankDto>.Fail(listOfErrors);
                }

                var deleteResult = await _commands.DeleteById(id);

                if (!deleteResult.Succeeded)
                    return ReturnBase<BankDto>.Fail(deleteResult.Errors);

                var saveResult = await _accountUoW.SaveAsync();

                if (!saveResult.Succeeded)
                    return ReturnBase<BankDto>.Fail(saveResult.Errors);

                var mappedResult = _mapper.Map<BankDto>(entity);

                return ReturnBase<BankDto>.Success(mappedResult);

            }
            catch (Exception ex)
            {
                return ReturnBase<BankDto>.Fail(ex, _exceptionManager);
            }
        }

        public async Task<ReturnBase<IEnumerable<BankDto>>> Search(SqlQueryOptions sqlQueryOptions)
        {
            try
            {
                var getResult = await _queriesManager.Banks.Search(sqlQueryOptions);
                if (!getResult.Succeeded)
                    return ReturnBase<IEnumerable<BankDto>>.Fail(getResult.Errors);

                return ReturnBase<IEnumerable<BankDto>>.Success(getResult.Result);
            }
            catch (Exception ex)
            {
                return ReturnBase<IEnumerable<BankDto>>.Fail(ex, _exceptionManager);
            }
        }

        public async Task<ReturnBase<BankDto>> GetById(long id)
        {
            try
            {
                var entity = await _queriesManager.Banks.GetById(id);
                if (entity is null)
                {
                    var error = new ReturnBaseError
                    {
                        ErrorCode = "404",
                        ErrorMessage = "Bank Not Found"
                    };
                    var listOfErrors = new List<ReturnBaseError>() { error };
                    return ReturnBase<BankDto>.Fail(listOfErrors);
                }

                var mappedResult = _mapper.Map<BankDto>(entity);

                return ReturnBase<BankDto>.Success(mappedResult);
            }
            catch (Exception ex)
            {
                return ReturnBase<BankDto>.Fail(ex, _exceptionManager);
            }
        }


        private IBankCommandRepository _commands
        {
            get { return _accountUoW.Bank; }
        }

    }

}
