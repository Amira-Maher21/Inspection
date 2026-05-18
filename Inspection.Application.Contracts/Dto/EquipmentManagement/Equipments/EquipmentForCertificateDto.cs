using Inspection.Application.Contracts.Dto.AccountingDtos.AR.MasterData.Customers;

namespace Inspection.Application.Contracts.Dto.EquipmentManagement.Equipments
{
    public class EquipmentForCertificateDto
    {
        public long Id { get; set; }
        public string Description { get; set; }
        public string? SerialNumber { get; set; }

        public string? EquipmentNo { get; set; }
        public long EquipmentTypeId { get; set; }

        public long? CustomerId { get; set; }
        public string? Tenant_ID { get; set; }
        public CustomerForCertificateDto Customer { get; set; }
    }
}
