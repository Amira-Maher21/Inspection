namespace Inspection.Application.Contracts.Dto.AccountingDtos.AccountSystemDto.DefaultAccountAssignment
{
    public class DefaultAccountAssignmentCreateDto
    {
        public long DefaultAccountGroupID { get; set; }
        public long DefaultAccountTypeID { get; set; }

        public long AccountID { get; set; }
        public long CurrencyID { get; set; }


    }
}
