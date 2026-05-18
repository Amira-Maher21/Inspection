using NDS.Shared.Domain.Contracts;
using System.ComponentModel.DataAnnotations.Schema;

namespace Inspection.Domain.Models.MenuManagement
{
    public class Screen_Code : IRootEntity
    {
        public string Screen_ID { get; set; } = null!;
        public string Screen_Name { get; set; } = null!;
        [ForeignKey("Menu_ID")]
        public string? Menu_ID { get; set; }
        public int? TrType_No { get; set; }
        public bool? DuplicateTrTypeNo { get; set; }
        public string Program_ID { get; set; } = null!;
        public string TabelMasterName { get; set; } = null!;
        public bool NotWorkWithSmallClients { get; set; }
        public bool HasApproval { get; set; }
        public string? FieldNameCondition { get; set; }
        public bool HasIndex { get; set; }
        public bool HasOpen { get; set; }
        public bool HasAdd { get; set; }
        public bool HasUpdate { get; set; }
        public bool HasDelete { get; set; }
        public bool HasPrice { get; set; }
        public bool HasPost { get; set; }
        public bool HasPrint { get; set; }
        public bool HasAttachment { get; set; }
        public bool Documntation { get; set; }
        public bool DevelopingBackEnd { get; set; }
        public bool DevelopingFrontEnd { get; set; }
        public bool Tested { get; set; }
        public virtual Menu Menu { get; set; } = null!;
    }
}