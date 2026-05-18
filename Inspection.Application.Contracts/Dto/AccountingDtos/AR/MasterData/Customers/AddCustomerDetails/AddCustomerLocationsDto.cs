using Inspection.Application.Contracts.Dto.InspectionManagement.CustomerLocations;

namespace Inspection.Application.Contracts.Dto.AccountingDtos.AR.MasterData.Customers.AddCustomerDetails
{
    public class AddCustomerLocationsDto
    {
        public long CustomerId { get; set; }
        public List<CreateCustomerLocationDto> Locations { get; set; }
    }

}
