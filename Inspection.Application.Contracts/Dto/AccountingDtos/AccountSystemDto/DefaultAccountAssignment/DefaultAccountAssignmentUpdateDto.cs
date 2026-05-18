namespace Inspection.Application.Contracts.Dto.AccountingDtos.AccountSystemDto.DefaultAccountAssignment
{
    public class DefaultAccountAssignmentUpdateDto
    {
        public long Id { get; set; }
        public long DefaultAccountGroupID { get; set; }
        public long DefaultAccountTypeID { get; set; }

        public long AccountID { get; set; }
        public long CurrencyID { get; set; }
    }
}
