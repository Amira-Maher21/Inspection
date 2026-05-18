namespace Inspection.Application.Contracts.Dto.SystemConfigurationDTOs.OperationDTOs
{
    public class OperationCreateDto
    {
        public string Name { get; set; }
        public string Code { get; set; }
        public string Description { get; set; }
        public DateTime AwardDate { get; set; }
        public string Location { get; set; }
        public bool IsActive { get; set; }
        public bool IsClosed { get; set; }
        public DateTime? PlannedStartDate { get; set; }
        public DateTime? PlannedEndDate { get; set; }
        public DateTime? ClosedDate { get; set; }




        public long OperationTypeId { get; set; }
        public long CostUnitId { get; set; }
        public long CostCenterId { get; set; }
        public long CustomerId { get; set; }
        public long CompanyId { get; set; }



    }
}
