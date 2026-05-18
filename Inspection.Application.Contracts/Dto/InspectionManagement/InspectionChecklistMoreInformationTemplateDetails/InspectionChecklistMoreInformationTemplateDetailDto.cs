namespace Inspection.Application.Contracts.Dto.InspectionManagement.InspectionChecklistMoreInformationTemplateDetails
{
    public class InspectionChecklistMoreInformationTemplateDetailDto
    {
        public long Id { get; set; }
        public string KeyName { get; set; }
        public string KeyValue { get; set; }


        public long InspectionChecklistMoreInformationTemplateId { get; set; }

        public string Tenant_ID { get; set; }
    }
}
