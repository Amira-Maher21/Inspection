using AutoMapper;
using Inspection.Application.Contracts.Dto.Inventory.Transaction.ScrapReasons;
using Inspection.Application.Contracts.Managers;
using Inspection.Application.Contracts.Repositories.Command.Inventory.Transaction.ScrapReasons;
using Inspection.Application.Contracts.Repositories.Query.Inventory.Transaction.ScrapReasons;
using Inspection.Application.Contracts.Services.Inventory.Transaction.ScrapReasons;
using Inspection.Application.Contracts.UnitOfWork;
using Inspection.Application.Services.ServicesBase;
using Inspection.Domain.Models.Inventory.Transaction.ScrapReasons;
using NDS.Shared.Application.DataQuery;
using NDS.Shared.Application.Multitenant;
using NDS.Shared.Kernel.BaseReturnTypes;
using NDS.Shared.Kernel.Exceptions;

namespace Inspection.Application.Services.Inventory.Transaction.ScrapReasons
{
    public class ScrapReasonService : AccountsServiceBase, IScrapReasonService
    {
        private readonly ITenantResolver _tenantResolver;
        private readonly IAccountsQueriesManager _queriesManager;

        public ScrapReasonService(
            IAccountUnitOfWork accountUoW,
            IAccountsQueriesManager queriesManager,
            IMapper mapper,
            IExceptionManager exceptionManager,
            ITenantResolver tenantResolver
        )
            : base(accountUoW, queriesManager, mapper, exceptionManager)
        {
            _queriesManager = queriesManager ?? throw new ArgumentNullException(nameof(queriesManager));
            _tenantResolver = tenantResolver;
        }

        private IScrapReasonCommandRepository _commands => _accountUoW.ScrapReason;

        private IScrapReasonQueryRepository _queries =>
            _queriesManager.ScrapReason ?? throw new NullReferenceException("IScrapReasonQueryRepository is null");


        public async Task<ReturnBase<ScrapReasonDto>> Create(ScrapReasonCreateDto dto)
        {
            try
            {
                var entity = _mapper.Map<ScrapReason>(dto);
                entity.Tenant_ID = _tenantResolver.GetTenantName();

                var insertResult = await _commands.InsertAsync(entity);
                if (!insertResult.Succeeded)
                    return ReturnBase<ScrapReasonDto>.Fail(insertResult.Errors);

                var saveResult = await _accountUoW.SaveAsync();
                if (!saveResult.Succeeded)
                    return ReturnBase<ScrapReasonDto>.Fail(saveResult.Errors);

                return ReturnBase<ScrapReasonDto>.Success(_mapper.Map<ScrapReasonDto>(entity));
            }
            catch (Exception ex)
            {
                return ReturnBase<ScrapReasonDto>.Fail(ex, _exceptionManager);
            }
        }


        public async Task<ReturnBase<ScrapReasonDto>> Update(ScrapReasonUpdateDto dto)
        {
            try
            {
                var entity = await _queries.GetById(dto.Id);
                if (entity == null)
                    return ReturnBase<ScrapReasonDto>.Fail(
                        new List<ReturnBaseError>
                        {
                            new() { ErrorCode = "404", ErrorMessage = "ScrapReason Not Found" }
                        });

                _mapper.Map(dto, entity);

                var saveResult = await _accountUoW.SaveAsync();
                if (!saveResult.Succeeded)
                    return ReturnBase<ScrapReasonDto>.Fail(saveResult.Errors);

                return ReturnBase<ScrapReasonDto>.Success(_mapper.Map<ScrapReasonDto>(entity));
            }
            catch (Exception ex)
            {
                return ReturnBase<ScrapReasonDto>.Fail(ex, _exceptionManager);
            }
        }


        public async Task<ReturnBase<ScrapReasonDto>> Delete(long id)
        {
            try
            {
                var entity = await _queries.GetById(id);
                if (entity == null)
                    return ReturnBase<ScrapReasonDto>.Fail(
                        new List<ReturnBaseError>
                        {
                            new() { ErrorCode = "404", ErrorMessage = "ScrapReason Not Found" }
                        });

                var deleteResult = await _commands.DeleteAsync(id);
                if (!deleteResult.Succeeded)
                    return ReturnBase<ScrapReasonDto>.Fail(deleteResult.Errors);

                var saveResult = await _accountUoW.SaveAsync();
                if (!saveResult.Succeeded)
                    return ReturnBase<ScrapReasonDto>.Fail(saveResult.Errors);

                return ReturnBase<ScrapReasonDto>.Success(_mapper.Map<ScrapReasonDto>(entity));
            }
            catch (Exception ex)
            {
                return ReturnBase<ScrapReasonDto>.Fail(ex, _exceptionManager);
            }
        }


        public async Task<ReturnBase<ScrapReasonDto>> GetById(long id)
        {
            try
            {
                var entity = await _queries.GetById(id);
                if (entity == null)
                    return ReturnBase<ScrapReasonDto>.Fail(
                        new List<ReturnBaseError>
                        {
                            new() { ErrorCode = "404", ErrorMessage = "ScrapReason Not Found" }
                        });

                return ReturnBase<ScrapReasonDto>.Success(_mapper.Map<ScrapReasonDto>(entity));
            }
            catch (Exception ex)
            {
                return ReturnBase<ScrapReasonDto>.Fail(ex, _exceptionManager);
            }
        }


        public async Task<ReturnBase<IEnumerable<ScrapReasonReturnSearchDto>>> Search(SqlQueryOptions sqlQueryOptions)
        {
            try
            {
                var result = await _queries.Search(sqlQueryOptions);

                if (!result.Succeeded)
                    return ReturnBase<IEnumerable<ScrapReasonReturnSearchDto>>.Fail(result.Errors);

                var mapped = result.Result
                    .Select(x => _mapper.Map<ScrapReasonReturnSearchDto>(x))
                    .ToList();

                return ReturnBase<IEnumerable<ScrapReasonReturnSearchDto>>.Success(mapped);
            }
            catch (Exception ex)
            {
                return ReturnBase<IEnumerable<ScrapReasonReturnSearchDto>>.Fail(ex, _exceptionManager);
            }
        }
    }
}