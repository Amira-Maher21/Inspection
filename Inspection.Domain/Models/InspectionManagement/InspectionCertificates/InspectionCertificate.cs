using Inspection.Domain.Models.InspectionManagement.InspectionChecklists;
using NDS.Shared.Domain.Contracts;
using NDS.Shared.Domain.Contracts.Multitenant;
using System.ComponentModel.DataAnnotations.Schema;

namespace Inspection.Domain.Models.InspectionManagement.InspectionCertificates
{
    public class InspectionCertificate : IRootEntity, ITenantEntity
    {

        public long Id { get; set; }

        public string CertificateNumber { get; set; }
        public DateTime IssueDate { get; set; } = DateTime.UtcNow;

        [ForeignKey("InspectionChecklists")]
        public long InspectionChecklistId { get; set; }
        public InspectionChecklist InspectionChecklists { get; set; }

        public string Series { get; set; }

        public string Tenant_ID { get; set; }

        //public long EquipmentAssetId { get; set; }    // إضافة
        //public string Result { get; set; }            // إضافة


        //[ForeignKey("Inspector")]
        //public long InspectorId { get; set; }
        //public Inspector Inspector { get; set; }




    }
}