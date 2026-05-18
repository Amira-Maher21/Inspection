using AutoMapper;
using Inspection.Application.Contracts.Dto.AccountingDtos.ChartOfAccounts.AccountTypeDTOs;
using Inspection.Application.Contracts.Managers;
using Inspection.Application.Contracts.Services.Accounting.ChartOfAccounts;
using Inspection.Application.Contracts.UnitOfWork;
using Inspection.Application.Services.ServicesBase;
using Inspection.Application.Shared.ExcelTemplate;
using NDS.Shared.Application.Multitenant;
using NDS.Shared.Kernel.BaseReturnTypes;
using NDS.Shared.Kernel.Exceptions;

namespace Inspection.Application.Services.Accounting.ChartOfAccounts
{
    internal class AccountTypeService : AccountsServiceBase, IAccountTypeService
    {
        private readonly ITenantResolver _tenantResolver;
        private readonly IExcelTemplateGenerator _templateGenerator;

        public AccountTypeService(IAccountUnitOfWork accountUoW, IAccountsQueriesManager queriesManager, IMapper mapper, IExceptionManager exceptionManager, ITenantResolver tenantResolver, IExcelTemplateGenerator templateGenerator) : base(accountUoW, queriesManager, mapper, exceptionManager)
        {
            _tenantResolver = tenantResolver;
            _templateGenerator = templateGenerator;
        }
        public async Task<ReturnBase<List<AcountTypeDto>>> GetAll()
        {

            try
            {
                var result = await _queriesManager.AccountTypes.GetAll();

                if (!result.Succeeded)
                {
                    return ReturnBase<List<AcountTypeDto>>.Fail(result.Errors);
                }

                var mapped = _mapper.Map<List<AcountTypeDto>>(result.Result);

                return ReturnBase<List<AcountTypeDto>>.Success(mapped);
            }
            catch (Exception ex)
            {
                return ReturnBase<List<AcountTypeDto>>.Fail(ex, _exceptionManager);
            }
        }
        public async Task<ReturnBase<AcountTypeDto>> GetByCode(string code)
        {
            try
            {
                var entity = await _queriesManager.AccountTypes.GetByCode(code);
                if (entity is null)
                {
                    var error = new ReturnBaseError
                    {
                        ErrorCode = "404",
                        ErrorMessage = "Account Type Not Found"
                    };
                    var listOfErrors = new List<ReturnBaseError>() { error };
                    return ReturnBase<AcountTypeDto>.Fail(listOfErrors);
                }

                var mappedResult = _mapper.Map<AcountTypeDto>(entity);

                return ReturnBase<AcountTypeDto>.Success(mappedResult);
            }
            catch (Exception ex)
            {
                return ReturnBase<AcountTypeDto>.Fail(ex, _exceptionManager);
            }
        }

    }
}