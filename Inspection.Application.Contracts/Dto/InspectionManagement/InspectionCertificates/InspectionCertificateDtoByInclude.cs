namespace Inspection.Application.Contracts.Dto.InspectionManagement.InspectionCertificates
{
    public class InspectionCertificateDtoByInclude
    {
        public long Id { get; set; }
        public string CertificateNumber { get; set; }
        public DateTime IssueDate { get; set; } = DateTime.UtcNow;
        public long InspectionChecklistId { get; set; }
        public string Series { get; set; }
        public string Tenant_ID { get; set; }
        public long JobOrderId { get; set; }
        public long CustomerId { get; set; }
        public long EquipmentTypeId { get; set; }
        public long EquipmentId { get; set; }
        public string InspectionTypeId { get; set; }
        public string LocationId { get; set; }
        public long CustomerProjectId { get; set; }
        public long InspectorId { get; set; }
        public long InspectionMethodId { get; set; }
        public string PreviousInspectionDate { get; set; }
        public string InspectionDate { get; set; }
        public string ExpireDate { get; set; }
        public string TimeSheetNo { get; set; }
        public string StickerNo { get; set; }
        public string RemarksAndRecommendations { get; set; }
        public string Status { get; set; }
        public string RefferenceStandard { get; set; }
        public string JobOrderNo { get; set; }
        public string EquipmentTypeName { get; set; }
        public string EquipmentName { get; set; }
        public string EquipmentSerialNumber { get; set; }
        public string EquipmentEquipmentNo { get; set; }
        public string EquipmentDescription { get; set; }
        public string EquipmentPurchaseDate { get; set; }
        public string EquipmentExpiryDate { get; set; }
        public string CustomerName { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public string Mobile { get; set; }
        public string Phone { get; set; }
        public string CompanyName { get; set; }
        public string InspectionTypeArabicName { get; set; }
        public string InspectionTypeEnglishName { get; set; }
        public string LocationName { get; set; }
        public string CustomerProjectName { get; set; }
        public string InspectorName { get; set; }
        public string InspectionMethodName { get; set; }
    }
}