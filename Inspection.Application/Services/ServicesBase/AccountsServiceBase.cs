using AutoMapper;
using Inspection.Application.Contracts.Managers;
using Inspection.Application.Contracts.UnitOfWork;
using NDS.Shared.Kernel.Exceptions;

namespace Inspection.Application.Services.ServicesBase
{
    public abstract class AccountsServiceBase
    {
        protected readonly IAccountUnitOfWork _accountUoW;
        protected readonly IAccountsQueriesManager _queriesManager;
        protected readonly IMapper _mapper;
        protected readonly IExceptionManager _exceptionManager;
        //protected readonly IDatabaseExceptionManager _exceptionManager;

        public AccountsServiceBase(IAccountUnitOfWork accountUoW, IAccountsQueriesManager queriesManager, IMapper mapper, IExceptionManager exceptionManager)
        {
            _accountUoW = accountUoW;
            _queriesManager = queriesManager;
            _mapper = mapper;
            _exceptionManager = exceptionManager;
        }
    }
}
