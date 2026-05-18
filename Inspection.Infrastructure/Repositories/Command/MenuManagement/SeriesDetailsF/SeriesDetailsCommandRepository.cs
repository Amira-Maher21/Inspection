using Inspection.Application.Contracts.Repositories.Command.MenuManagement.SeriesDetailsF;
using Inspection.Domain.Enums;
using Inspection.Domain.Models.MenuManagement;
using Microsoft.EntityFrameworkCore;
using NDS.Shared.Application.Multitenant;
using NDS.Shared.Infrastructure.RepositoryBase;
using NDS.Shared.Kernel.Exceptions;

namespace Inspection.Infrastructure.Repositories.Command.MenuManagement.SeriesDetailsF
{
    public class SeriesDetailsCommandRepository : CommandRepositoryBase<SeriesDetails>, ISeriesDetailsCommandRepository
    {
        public SeriesDetailsCommandRepository(DbContext context, ITenantResolver tenantResolver, IExceptionManager exceptionManager) 
            : base(context, tenantResolver, exceptionManager)
        {
        }

        //public async Task<SeriesDetails?> GetOrCreateSeriesDetailsAsync(long seriesId, int year, int month, string tenantId)
        //{
        //    var existing = await _dbSet
        //        .FirstOrDefaultAsync(sd => sd.SeriesId == seriesId
        //            && sd.Year == year
        //            && sd.Month == month
        //            && sd.Tenant_ID == tenantId);

        //    if (existing != null)
        //    {
        //        return existing;
        //    }

        //    // Create new SeriesDetails for this month/year
        //    var newSeriesDetails = new SeriesDetails
        //    {
        //        SeriesId = seriesId,
        //        Year = year,
        //        Month = month,
        //        CurrentNumber = 0,
        //        Tenant_ID = tenantId
        //    };

        //    await _dbSet.AddAsync(newSeriesDetails);

        //    return newSeriesDetails;
        //}

        public async Task<SeriesDetails?> GetOrCreateSeriesDetailsAsync(
            long seriesId,
            int year,
            int month,
            string tenantId,
            ResetPolicyEnum resetPolicy
        )
        {
            int effectiveYear = year;
            int? effectiveMonth = null;

            switch (resetPolicy)
            {
                case ResetPolicyEnum.Monthly:
                    effectiveMonth = month;
                    break;

                case ResetPolicyEnum.Yearly:
                    effectiveMonth = null;
                    break;

                case ResetPolicyEnum.Never:
                    effectiveYear = 0;
                    effectiveMonth = null;
                    break;
            }

            var existing = await _dbSet.FirstOrDefaultAsync(sd =>
                sd.SeriesId == seriesId &&
                sd.Year == effectiveYear &&
                sd.Month == effectiveMonth &&
                sd.Tenant_ID == tenantId
            );

            if (existing != null)
                return existing;

            var newSeriesDetails = new SeriesDetails
            {
                SeriesId = seriesId,
                Year = effectiveYear,
                Month = effectiveMonth,
                CurrentNumber = 0,
                Tenant_ID = tenantId
            };

            await _dbSet.AddAsync(newSeriesDetails);
            return newSeriesDetails;
        }

    }
}