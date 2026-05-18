namespace Inspection.Domain.Models.MenuManagement
{

    public class Menu
    {
        public string Menu_ID { get; set; } = null!;
        public string Menu_Name { get; set; } = null!;
        public string? Program_ID { get; set; }
        public string? Parent_ID { get; set; }
        public bool? DontUseInReport { get; set; }
        public bool? Is_DashBoard { get; set; }
        public bool? Is_Report { get; set; }
        public string? WebRoute { get; set; }
        public string? Icon { get; set; }

        public ICollection<MenuLocalization> MenuLocalizations { get; set; } = new List<MenuLocalization>();
        public virtual Program? Program { get; set; }
        public virtual Screen_Code? ScreenCode { get; set; }
    }
}