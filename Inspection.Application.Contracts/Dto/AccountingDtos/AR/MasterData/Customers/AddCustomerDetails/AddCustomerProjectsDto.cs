using Inspection.Application.Contracts.Dto.InspectionManagement.CustomerProjects;

namespace Inspection.Application.Contracts.Dto.AccountingDtos.AR.MasterData.Customers.AddCustomerDetails
{
    public class AddCustomerProjectsDto
    {
        public long CustomerId { get; set; }
        public List<CreateCustomerProjectDto> Projects { get; set; }
    }

}
