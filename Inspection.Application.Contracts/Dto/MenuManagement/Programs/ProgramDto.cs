namespace Inspection.Application.Contracts.Dto.MenuManagement.Programs
{
    public class ProgramDto
    {
        public string Program_ID { get; set; } = null!;
        public string ProgramName { get; set; } = null!;
        public string? WebRoute { get; set; }
        public string? Icon { get; set; }
        //public virtual ICollection<Menu> Menus { get; set; } = new List<Menu>();
    }
}
