using Inspection.Domain.Enums;
using Inspection.Domain.Enums.Checklists;

namespace Inspection.Application.Contracts.Dto.InspectionDto.Techinal.Checklists
{
    public class ChecklistImportTemplateDto
    {
        public string EquipmentCode { get; set; } = string.Empty;
        public string InspectorCode { get; set; } = string.Empty;
        public string ChecklistTemplateCode { get; set; } = string.Empty;
        public string StandardCode { get; set; } = string.Empty;
        public string InspectionTypeCode { get; set; } = string.Empty;
        //public string CustomerCode { get; set; } = string.Empty;

        public EquipmentStatus Status { get; set; }
        public string Location { get; set; } = string.Empty;
        public string Remarks { get; set; } = string.Empty;
        public DateTime InspectionDate { get; set; }
        public string CompanyCode { get; set; } = string.Empty;
        public ChecklistDocStatus DocStatus { get; set; }
    }
}
