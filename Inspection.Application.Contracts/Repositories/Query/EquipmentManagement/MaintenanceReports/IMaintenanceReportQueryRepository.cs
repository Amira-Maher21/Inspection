using Inspection.Domain.Models.EquipmentManagement.Equipments;
using Inspection.Domain.Models.EquipmentManagement.MaintenanceReports;
using NDS.Shared.Application.RepositoryBase;
 
namespace Inspection.Application.Contracts.Repositories.Query.EquipmentManagement.MaintenanceReports
{
    public interface IMaintenanceReportQueryRepository : IQueryRepository<MaintenanceReport>
    {
    }
}
