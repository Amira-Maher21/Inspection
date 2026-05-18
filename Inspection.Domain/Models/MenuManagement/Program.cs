namespace Inspection.Domain.Models.MenuManagement
{
    public class Program
    {
        public string Program_ID { get; set; } = null!;
        public string ProgramName { get; set; } = null!;
        public string? WebRoute { get; set; }
        public string? Icon { get; set; }
        public virtual ICollection<Menu> Menus { get; set; } = new List<Menu>();
    }
}


