using NDS.Shared.Domain.Contracts;

namespace Inspection.Domain.Models.MenuManagement
{
    public class MenuLocalization : IRootEntity
    {
        public string Menu_ID { get; set; } = null!;
        public string LocaleCode { get; set; } = null!;
        public string? Caption { get; set; }
        public string? Tooltip { get; set; }
        public virtual Menu Menu { get; set; } = null!;
    }
}