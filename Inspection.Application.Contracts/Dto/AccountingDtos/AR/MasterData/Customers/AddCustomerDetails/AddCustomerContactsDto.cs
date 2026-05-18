using Inspection.Application.Contracts.Dto.AccountingDtos.AR.MasterData.CustomerContacts;

namespace Inspection.Application.Contracts.Dto.AccountingDtos.AR.MasterData.Customers.AddCustomerDetails
{
    public class AddCustomerContactsDto
    {
        public long CustomerId { get; set; }
        public List<CustomerContactCreateDto> Contacts { get; set; }
    }

}
