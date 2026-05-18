using Inspection.Domain.Models.EquipmentManagement.Equipments;
using Inspection.Domain.Models.EquipmentManagement.EquipmentsMoreInformationDetails;
using Inspection.Domain.Models.EquipmentManagement.EquipmentTypes;
using NDS.Shared.Domain.Contracts;
using NDS.Shared.Domain.Contracts.Multitenant;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Inspection.Domain.Models.EquipmentManagement.EquipmentsMoreInfo
{
    public class EquipmentsMoreInformation : IRootEntity, ITenantEntity
    {
        [Key]
        public long Id { get; set; }


        //[ForeignKey("EquipmentTypes")]
        public long EquipmentTypeId { get; set; }
        public EquipmentType EquipmentTypes { get; set; }

        [ForeignKey("Equipment")]
        public long EquipmentId { get; set; }
        public Equipment Equipment { get; set; }



        //public string series { get; set; }
        public ICollection<EquipmentsMoreInformationDetail>? EquipmentsMoreInformationDetails { get; set; }
        public string Tenant_ID { get; set; }


    }
}
