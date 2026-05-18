using Inspection.Application.Contracts.Dto.SampleDTOs.CurrencyExchangeRateDTOs;
using Inspection.Application.Contracts.Repositories.Query.Sample.CurrencyExchangeRate;
using Inspection.Domain.Models.Sample.CurrencyExchangeRate;
using Inspection.Infrastructure.QueryObjects.Sample.CurrencyExchangeRate;
using Microsoft.EntityFrameworkCore;
using NDS.Shared.Application.DataQuery;
using NDS.Shared.Application.Multitenant;
using NDS.Shared.Infrastructure.DataContext;
using NDS.Shared.Infrastructure.RepositoryBase;
using NDS.Shared.Kernel.BaseReturnTypes;
using NDS.Shared.Kernel.Exceptions;

namespace Inspection.Infrastructure.Repositories.Query.Sample.CurrencyExchangeRate
{
    internal class SCurrencyExchangeRateQueryRepository :
       QueryRepositoryBase<SCurrencyExchangeRateHeader>,
       ISCurrencyExchangeRateQueryRepository
    {
        public SCurrencyExchangeRateQueryRepository(ISqlQueryBuilder queryBuilder, DapperDbContext dapper, DbContext context, ITenantResolver tenantResolver, IExceptionManager exceptionManager) : base(queryBuilder, dapper, context, tenantResolver, exceptionManager)
        {
        }

        public async Task<ReturnBase<SCurrencyExchangeRateItemDto?>> GetByIdAsync(long id)
        {
            try
            {
                var entity = await _context
                      .Set<SCurrencyExchangeRateHeader>()
                      .Where(e => e.Id == id && e.Tenant_ID == _tenantResolver.GetTenantName())
                      .Select(e => new SCurrencyExchangeRateItemDto
                      {
                          Id = e.Id,
                          BaseCurrencyId = e.BaseCurrencyId,
                          BaseCurrencyName = e.Currency!.Name,
                          Description = e.Description,
                          EffectiveDate = e.EffectiveDate,
                          IsActive = e.IsActive,
                          Lines = e.Lines!.Select(line => new SCurrencyExchangeRateItemDto.SCurrencyExchangeRateDetailLine
                          {
                              Id = line.Id,
                              TargetCurrencyId = line.TargetCurrencyId,
                              TargetCurrencyName = line.Currency.Name,
                              Rate = line.Rate

                          })
                      })
                      .FirstOrDefaultAsync();
                return ReturnBase<SCurrencyExchangeRateItemDto?>.Success(entity);
            }
            catch (Exception ex)
            {
                return ReturnBase<SCurrencyExchangeRateItemDto?>.Fail(ex, _exceptionManager);
            }

        }

        public async Task<ReturnBase<IEnumerable<SCurrencyExchangeRateListItemDto>>> GetListAsync(SqlQueryOptions queryOptions)
        {
            var listQuery = new SCurrencyExchangeRateListQuery(
                 _queryBuilder,
                 _dapper,
                 _tenantResolver,
                 _exceptionManager
             );
            return await base.Query(listQuery, queryOptions);
        }
        public async Task<ReturnBase<IEnumerable<SCurrencyExchangeRateLineListItemDto>>> GetLinesAsync(long id)
        {
            try
            {


                var lines = _dbSet
                    .Where(e => e.Id == id && e.Tenant_ID == _tenantResolver.GetTenantName())
                    .SelectMany(e => e.Lines!)
                    .Select(line => new SCurrencyExchangeRateLineListItemDto
                    {
                        TargetCurrencyName = line.Currency!.Name,
                        Rate = line.Rate
                    });

                return ReturnBase<IEnumerable<SCurrencyExchangeRateLineListItemDto>>.Success(await lines.ToListAsync());

            }
            catch (Exception ex)
            {
                return ReturnBase<IEnumerable<SCurrencyExchangeRateLineListItemDto>>.Fail(ex, _exceptionManager);
            }
        }

        public async Task<ReturnBase<decimal>> GetLatestRateAsync(long baseCurrencyId, long targetCurrencyId, DateTime Date)
        {
            try
            {
                var tenant = _tenantResolver.GetTenantName();

                var rate = await _context
                    .Set<SCurrencyExchangeRateHeader>()
                    .Where(h =>
                        h.BaseCurrencyId == baseCurrencyId &&
                        h.Tenant_ID == tenant &&
                        h.IsActive &&
                        h.EffectiveDate <= Date)
                    .OrderByDescending(h => h.EffectiveDate)
                    .SelectMany(h => h.Lines!
                        .Where(l => l.TargetCurrencyId == targetCurrencyId)
                        .Select(l => (decimal?)l.Rate))
                    .FirstOrDefaultAsync();

                if (rate == null)
                {
                    return ReturnBase<decimal>.Fail(
                        new Exception($"No exchange rate found for currency {targetCurrencyId} on or before {Date:yyyy-MM-dd}"),
                        _exceptionManager
                    );
                }

                return ReturnBase<decimal>.Success(rate.Value);
            }
            catch (Exception ex)
            {
                return ReturnBase<decimal>.Fail(ex, _exceptionManager);
            }
        }

    }
}