namespace Inspection.Application.Contracts.Dto.ContractingDTOs.Setup.Divisions
{
    public class DivisionUpdateDto
    {
        public long Id { get; set; }

        public long CompanyId { get; set; }

        public string DivisionCode { get; set; } = string.Empty;
        public string DivisionName { get; set; } = string.Empty;

        public long? ParentDivisionId { get; set; }

        public bool IsLeaf { get; set; }


    }
}
