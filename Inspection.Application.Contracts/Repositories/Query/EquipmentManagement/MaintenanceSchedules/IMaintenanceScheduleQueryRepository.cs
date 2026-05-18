using Inspection.Domain.Models.EquipmentManagement.MaintenanceSchedules;
using NDS.Shared.Application.RepositoryBase;


namespace Inspection.Application.Contracts.Repositories.Query.EquipmentManagement.MaintenanceSchedules
{
    public interface IMaintenanceScheduleQueryRepository : IQueryRepository<MaintenanceSchedule>
    {
    }
}
