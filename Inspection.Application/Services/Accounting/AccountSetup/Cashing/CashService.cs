using AutoMapper;
using Inspection.Application.Contracts.Dto.AccountingDtos.AccountingSetupDtos.Cashing;
using Inspection.Application.Contracts.Managers;
using Inspection.Application.Contracts.Repositories.Command.Accounting.AccountSetup.Cashing;
using Inspection.Application.Contracts.Services.Accounting.AccountSetup.Cashing;
using Inspection.Application.Contracts.UnitOfWork;
using Inspection.Application.Services.ServicesBase;
using Inspection.Application.Shared.ExcelTemplate;
using Inspection.Application.Shared.SharedValidation;
using Inspection.Domain.Models.Accounting.AccountingSetup.Cashing;
using NDS.Shared.Application.DataQuery;
using NDS.Shared.Application.Multitenant;
using NDS.Shared.Kernel.BaseReturnTypes;
using NDS.Shared.Kernel.Exceptions;

namespace Inspection.Application.Services.Accounting.AccountSetup.Cashing
{
    internal class CashService : AccountsServiceBase, ICashService
    {
        private readonly ITenantResolver _tenantResolver;
        private readonly IExcelTemplateGenerator _templateGenerator;

        public CashService(IAccountUnitOfWork accountUoW, IAccountsQueriesManager queriesManager, IMapper mapper, IExceptionManager exceptionManager, ITenantResolver tenantResolver, IExcelTemplateGenerator templateGenerator) : base(accountUoW, queriesManager, mapper, exceptionManager)
        {
            _tenantResolver = tenantResolver;
            _templateGenerator = templateGenerator;
        }
        //done
        public async Task<ReturnBase<CashDto>> Create(
            CashCreateDto createDto)
        {
            try
            {
                createDto.Code.ValidateAsCode();
                createDto.Name.ValidateAsName();
                var entity = _mapper.Map<Cash>(createDto);
                entity.Tenant_ID = _tenantResolver.GetTenantName();
                var insertResult = await _commands.InsertAsync(entity);
                if (!insertResult.Succeeded)
                {
                    return ReturnBase<CashDto>.Fail(insertResult.Errors);
                }

                var saveResult = await _accountUoW.SaveAsync();
                if (!saveResult.Succeeded)
                    return ReturnBase<CashDto>.Fail(saveResult.Errors);

                var resultDto = _mapper.Map<CashDto>(entity);
                return ReturnBase<CashDto>.Success(resultDto);
            }
            catch (Exception ex)
            {
                return ReturnBase<CashDto>.Fail(ex, _exceptionManager);
            }
        }
        //done
        public async Task<ReturnBase<CashDto>> Delete(long id)
        {
            try
            {
                var entity = await _queriesManager.Cashs.GetById(id);
                if (entity is null)
                {
                    var error = new ReturnBaseError
                    {
                        ErrorCode = "404",
                        ErrorMessage = "Cash Not Found"
                    };
                    var listOfErrors = new List<ReturnBaseError>() { error };
                    return ReturnBase<CashDto>.Fail(listOfErrors);
                }

                var deleteResult = await _commands.DeleteById(id);

                if (!deleteResult.Succeeded)
                    return ReturnBase<CashDto>.Fail(deleteResult.Errors);

                var saveResult = await _accountUoW.SaveAsync();

                if (!saveResult.Succeeded)
                    return ReturnBase<CashDto>.Fail(saveResult.Errors);

                var mappedResult = _mapper.Map<CashDto>(entity);

                return ReturnBase<CashDto>.Success(mappedResult);

            }
            catch (Exception ex)
            {
                return ReturnBase<CashDto>.Fail(ex, _exceptionManager);
            }
        }
        //done
        public async Task<ReturnBase<List<CashDto>>> GetAll()
        {
            try
            {
                var result = await _queriesManager.Cashs.GetAll();

                if (!result.Succeeded)
                {
                    return ReturnBase<List<CashDto>>.Fail(result.Errors);
                }

                var mapped = _mapper.Map<List<CashDto>>(result.Result);

                return ReturnBase<List<CashDto>>.Success(mapped);
            }
            catch (Exception ex)
            {
                return ReturnBase<List<CashDto>>.Fail(ex, _exceptionManager);
            }
        }
        //done
        public async Task<ReturnBase<CashDto>> GetById(long id)
        {
            try
            {
                var entity = await _queriesManager.Cashs.GetById(id);
                if (entity is null)
                {
                    var error = new ReturnBaseError
                    {
                        ErrorCode = "404",
                        ErrorMessage = "Cash not Found"
                    };
                    var listOfErrors = new List<ReturnBaseError>() { error };
                    return ReturnBase<CashDto>.Fail(listOfErrors);
                }

                var mappedResult = _mapper.Map<CashDto>(entity);

                return ReturnBase<CashDto>.Success(mappedResult);
            }
            catch (Exception ex)
            {
                return ReturnBase<CashDto>.Fail(ex, _exceptionManager);
            }
        }
        //done
        public async Task<ReturnBase<IEnumerable<CashReturnSearchDto>>> Search(SqlQueryOptions sqlQueryOptions)
        {
            try
            {
                var getResult = await _queriesManager.Cashs.Search(sqlQueryOptions);
                if (!getResult.Succeeded)
                    return ReturnBase<IEnumerable<CashReturnSearchDto>>.Fail(getResult.Errors);

                var mappedResult = _mapper.Map<IEnumerable<CashReturnSearchDto>>(getResult.Result);

                return ReturnBase<IEnumerable<CashReturnSearchDto>>.Success(mappedResult);
            }
            catch (Exception ex)
            {
                return ReturnBase<IEnumerable<CashReturnSearchDto>>.Fail(ex, _exceptionManager);
            }
        }

        public async Task<ReturnBase<CashDto>> Update(CashUpdateDto updateDto)
        {
            try
            {
                updateDto.Code.ValidateAsCode();
                updateDto.Name.ValidateAsName();
                var entity = await _queriesManager.Cashs.GetById(updateDto.Id);
                if (entity is null)
                {
                    var error = new ReturnBaseError
                    {
                        ErrorCode = "404",
                        ErrorMessage = "Cash Not Found"
                    };
                    var listOfErrors = new List<ReturnBaseError>() { error };
                    return ReturnBase<CashDto>.Fail(listOfErrors);
                }


                entity.Tenant_ID = _tenantResolver.GetTenantName();

                _mapper.Map(updateDto, entity);
                var updateResult = await _commands.UpdateAsync(entity);

                if (!updateResult.Succeeded)
                    return ReturnBase<CashDto>.Fail(updateResult.Errors);

                var saveResult = await _accountUoW.SaveAsync();

                if (!saveResult.Succeeded)
                    return ReturnBase<CashDto>.Fail(saveResult.Errors);

                var mappedResult = _mapper.Map<CashDto>(entity);

                return ReturnBase<CashDto>.Success(mappedResult);

            }
            catch (Exception ex)
            {
                return ReturnBase<CashDto>.Fail(ex, _exceptionManager);
            }
        }


        private ICashCommandRepository _commands
        {
            get { return _accountUoW.Cash; }
        }
    }
}