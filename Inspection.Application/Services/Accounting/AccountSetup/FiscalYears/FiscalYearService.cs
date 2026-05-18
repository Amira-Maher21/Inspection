using AutoMapper;
using Inspection.Application.Contracts.Dto.AccountingDtos.AccountingSetupDtos.FiscalYearDTOs;
using Inspection.Application.Contracts.Managers;
using Inspection.Application.Contracts.Repositories.Command.Accounting.AccountSetup.FiscalYears;
using Inspection.Application.Contracts.Services.Accounting.AccountSetup.FiscalYears;
using Inspection.Application.Contracts.UnitOfWork;
using Inspection.Application.Services.ServicesBase;
using Inspection.Application.Shared.ExcelTemplate;
using Inspection.Domain.Models.Accounting.AccountingSetup.FiscalYears;
using NDS.Shared.Application.DataQuery;
using NDS.Shared.Application.Multitenant;
using NDS.Shared.Kernel.BaseReturnTypes;
using NDS.Shared.Kernel.Exceptions;

namespace Inspection.Application.Services.Accounting.AccountSetup.FiscalYears
{
    internal class FiscalYearService : AccountsServiceBase, IFiscalYearService
    {
        private readonly ITenantResolver _tenantResolver;
        private readonly IExcelTemplateGenerator _templateGenerator;

        public FiscalYearService(IAccountUnitOfWork accountUoW, IAccountsQueriesManager queriesManager, IMapper mapper, IExceptionManager exceptionManager, ITenantResolver tenantResolver, IExcelTemplateGenerator templateGenerator) : base(accountUoW, queriesManager, mapper, exceptionManager)
        {
            _tenantResolver = tenantResolver;
            _templateGenerator = templateGenerator;
        }
        public async Task<ReturnBase<FiscalYearDto>> Create(FiscalYearCreateDto createDto)
        {
            try
            {
                var entity = _mapper.Map<FiscalYear>(createDto);
                entity.Tenant_ID = _tenantResolver.GetTenantName();

                var insertResult = await _commands.InsertAsync(entity);
                if (!insertResult.Succeeded)
                {
                    return ReturnBase<FiscalYearDto>.Fail(insertResult.Errors);
                }

                var saveResult = await _accountUoW.SaveAsync();
                if (!saveResult.Succeeded)
                {
                    return ReturnBase<FiscalYearDto>.Fail(saveResult.Errors);
                }

                var resultDto = _mapper.Map<FiscalYearDto>(entity);

                return ReturnBase<FiscalYearDto>.Success(resultDto);
            }
            catch (Exception ex)
            {
                return ReturnBase<FiscalYearDto>.Fail(ex, _exceptionManager);
            }
        }

        public async Task<ReturnBase<FiscalYearDto>> Update(FiscalYearUpdateDto updateDto)
        {
            try
            {
                var entity = await _queriesManager.FiscalYears.GetById(updateDto.Id);
                if (entity is null)
                {
                    var error = new ReturnBaseError
                    {
                        ErrorCode = "404",
                        ErrorMessage = "Fiscal Year Not Found"
                    };
                    var listOfErrors = new List<ReturnBaseError>() { error };
                    return ReturnBase<FiscalYearDto>.Fail(listOfErrors);
                }

                entity.Tenant_ID = _tenantResolver.GetTenantName();

                _mapper.Map(updateDto, entity);
                var updateResult = await _commands.UpdateAsync(entity);

                if (!updateResult.Succeeded)
                    return ReturnBase<FiscalYearDto>.Fail(updateResult.Errors);

                var saveResult = await _accountUoW.SaveAsync();

                if (!saveResult.Succeeded)
                    return ReturnBase<FiscalYearDto>.Fail(saveResult.Errors);

                var mappedResult = _mapper.Map<FiscalYearDto>(entity);

                return ReturnBase<FiscalYearDto>.Success(mappedResult);

            }
            catch (Exception ex)
            {
                return ReturnBase<FiscalYearDto>.Fail(ex, _exceptionManager);
            }
        }
        public async Task<ReturnBase<FiscalYearDto>> Delete(long id)
        {
            try
            {
                var entity = await _queriesManager.FiscalYears.GetById(id);
                if (entity is null)
                {
                    var error = new ReturnBaseError
                    {
                        ErrorCode = "404",
                        ErrorMessage = "Fiscal Year Not Found"
                    };
                    var listOfErrors = new List<ReturnBaseError>() { error };
                    return ReturnBase<FiscalYearDto>.Fail(listOfErrors);
                }

                var deleteResult = await _commands.DeleteById(id);

                if (!deleteResult.Succeeded)
                    return ReturnBase<FiscalYearDto>.Fail(deleteResult.Errors);

                var saveResult = await _accountUoW.SaveAsync();

                if (!saveResult.Succeeded)
                    return ReturnBase<FiscalYearDto>.Fail(saveResult.Errors);

                var mappedResult = _mapper.Map<FiscalYearDto>(entity);

                return ReturnBase<FiscalYearDto>.Success(mappedResult);

            }
            catch (Exception ex)
            {
                return ReturnBase<FiscalYearDto>.Fail(ex, _exceptionManager);
            }
        }

        public async Task<ReturnBase<IEnumerable<FiscalYearDto>>> Search(SqlQueryOptions sqlQueryOptions)
        {
            try
            {
                var getResult = await _queriesManager.FiscalYears.Search(sqlQueryOptions);
                if (!getResult.Succeeded)
                    return ReturnBase<IEnumerable<FiscalYearDto>>.Fail(getResult.Errors);

                return ReturnBase<IEnumerable<FiscalYearDto>>.Success(getResult.Result);
            }
            catch (Exception ex)
            {
                return ReturnBase<IEnumerable<FiscalYearDto>>.Fail(ex, _exceptionManager);
            }
        }

        public async Task<ReturnBase<FiscalYearDto>> GetById(long id)
        {
            try
            {
                var entity = await _queriesManager.FiscalYears.GetById(id);
                if (entity is null)
                {
                    var error = new ReturnBaseError
                    {
                        ErrorCode = "404",
                        ErrorMessage = "Fiscal Year Not Found"
                    };
                    var listOfErrors = new List<ReturnBaseError>() { error };
                    return ReturnBase<FiscalYearDto>.Fail(listOfErrors);
                }

                var mappedResult = _mapper.Map<FiscalYearDto>(entity);

                return ReturnBase<FiscalYearDto>.Success(mappedResult);
            }
            catch (Exception ex)
            {
                return ReturnBase<FiscalYearDto>.Fail(ex, _exceptionManager);
            }
        }
        private IFiscalYearCommandRepository _commands
        {
            get { return _accountUoW.FiscalYear; }
        }
    }
}