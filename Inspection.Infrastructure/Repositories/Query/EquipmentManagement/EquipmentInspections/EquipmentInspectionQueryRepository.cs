using Inspection.Application.Contracts.Dto.EquipmentManagement.EquipmentInspections;
using Inspection.Application.Contracts.Repositories.Query.EquipmentManagement.EquipmentInspections;
using Inspection.Domain.Models.EquipmentManagement.EquipmentInspections;
using Inspection.Infrastructure.DataContext;
using Microsoft.EntityFrameworkCore;
using NDS.Shared.Application.DataQuery;
using NDS.Shared.Application.Multitenant;
using NDS.Shared.Infrastructure.DataContext;
using NDS.Shared.Infrastructure.RepositoryBase;
using NDS.Shared.Kernel.Exceptions;

namespace Inspection.Infrastructure.Repositories.Query.EquipmentManagement.EquipmentInspections
{
    public class EquipmentInspectionQueryRepository : QueryRepositoryBase<EquipmentInspection>, IEquipmentInspectionQueryRepository
    {
        private readonly DbInspectionContext _db;

        public EquipmentInspectionQueryRepository(ISqlQueryBuilder sqlQueryBuilder, DapperDbContext dapperDbContext, DbContext context, ITenantResolver tenantResolver, IExceptionManager exceptionManager) : base(sqlQueryBuilder, dapperDbContext, context, tenantResolver, exceptionManager)
        {
            _db = (DbInspectionContext)context;
        }

        public Task<List<EquipmentInspectionWithNavigationPropertiesDto>> GetListWithDetailsAsync(long equipmentId)
        {
            throw new NotImplementedException();
        }

        public async Task<EquipmentInspection?> GetById(long id)
        {
            return await _dbSet
                 .FirstOrDefaultAsync(c => c.Id == id);
        }



        //public async Task<List<EquipmentInspectionWithNavigationPropertiesDto>> GetListWithDetailsAsync()
        //{
        //    return await _db.EquipmentInspections
        //        .Include(x => x.Equipment)
        //        .Include(x => x.InspectionOrder)
        //        .Select(x => new EquipmentInspectionWithNavigationPropertiesDto
        //        {
        //            EquipmentInspections = x,
        //            Equipments = x.Equipment,
        //            InspectionOrders = x.InspectionOrder
        //        })
        //        .ToListAsync();
        //}
        //public async Task<List<EquipmentInspectionWithNavigationPropertiesDto>> GetListWithDetailsAsync(Guid equipmentId)
        //{
        //    return await _db.EquipmentInspections
        //        .Where(x => x.EquipmentId == equipmentId) 
        //        .Include(x => x.Equipment)
        //        .Include(x => x.InspectionOrder)
        //        .Select(x => new EquipmentInspectionWithNavigationPropertiesDto
        //        {
        //            EquipmentInspections = x,
        //            Equipments = x.Equipment,
        //            InspectionOrders = x.InspectionOrder
        //        })
        //        .ToListAsync();
        //}


    }
}

