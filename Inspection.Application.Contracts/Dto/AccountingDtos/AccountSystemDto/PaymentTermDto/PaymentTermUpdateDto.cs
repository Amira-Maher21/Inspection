namespace Inspection.Application.Contracts.Dto.AccountingDtos.AccountSystemDto.PaymentTermDto
{
    public class PaymentTermUpdateDto
    {
        public long Id { get; set; }
        public string Code { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
        public int DaysDue { get; set; }
        public decimal? DiscountPercentage { get; set; }
        public int DaysDiscount { get; set; }
        public string Description { get; set; } = string.Empty;
        public long CompanyId { get; set; }
    }
}