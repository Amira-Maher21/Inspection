namespace Inspection.Application.Contracts.Dto.InspectionManagement.InspectionChecklistMoreInformationDetails
{
    public class CreateInspectionChecklistMoreInformationDetailDto
    {

        public string KeyName { get; set; }
        public string KeyValue { get; set; }


        public long InspectionChecklistMoreInformationId { get; set; }

        public string Tenant_ID { get; set; }

    }
}
