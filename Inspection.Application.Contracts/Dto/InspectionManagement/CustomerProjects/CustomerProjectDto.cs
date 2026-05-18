namespace Inspection.Application.Contracts.Dto.InspectionManagement.CustomerProjects
{
    public class CustomerProjectDto
    {

        public long Id { get; set; }

        public long CustomerId { get; set; }

        public string ProjectCode { get; set; }
        public string ProjectName { get; set; }
        public string Location { get; set; }
        public string BuildingNumber { get; set; }
        public string StreetName { get; set; }
        public string District { get; set; }
        public string City { get; set; }
        public string PostalCode { get; set; }
        public string? AdditionalNumber { get; set; }
        public string? GPSLatitude { get; set; }
        public string? GPSLongitude { get; set; }
        public string? Notes { get; set; }
    }
}
