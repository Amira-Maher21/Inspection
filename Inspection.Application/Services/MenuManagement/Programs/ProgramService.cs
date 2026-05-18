using AutoMapper;
using Inspection.Application.Contracts.Dto.MenuManagement.Programs;
using Inspection.Application.Contracts.Managers;
using Inspection.Application.Contracts.Services.MenuManagement.Programs;
using Inspection.Application.Contracts.UnitOfWork;
using Inspection.Application.Services.ServicesBase;
using Inspection.Application.Shared.ExcelTemplate;
using NDS.Shared.Application.DataQuery;
using NDS.Shared.Application.Multitenant;
using NDS.Shared.Kernel.BaseReturnTypes;
using NDS.Shared.Kernel.Exceptions;

namespace Inspection.Application.Services.MenuManagement.Programs
{



    public class ProgramService : AccountsServiceBase, IProgramService
    {
        private readonly ITenantResolver _tenantResolver;
        private readonly IExcelTemplateGenerator _templateGenerator;

        public ProgramService(IAccountUnitOfWork accountUoW, IAccountsQueriesManager queriesManager, IMapper mapper, IExceptionManager exceptionManager, ITenantResolver tenantResolver, IExcelTemplateGenerator templateGenerator) : base(accountUoW, queriesManager, mapper, exceptionManager)
        {
            _tenantResolver = tenantResolver;
            _templateGenerator = templateGenerator;
        }


        public async Task<ReturnBase<IEnumerable<ProgramDto>>> GetList(SqlQueryOptions? sqlQueryOptions = null)
        {
            try
            {
                var entities = await _queriesManager.programQueryRepository.GetList(sqlQueryOptions);
                var mappedResult = _mapper.Map<IEnumerable<ProgramDto>>(entities);
                return ReturnBase<IEnumerable<ProgramDto>>.Success(mappedResult);
            }
            catch (Exception ex)
            {
                return ReturnBase<IEnumerable<ProgramDto>>.Fail(ex, _exceptionManager);
            }
        }
    }
}
