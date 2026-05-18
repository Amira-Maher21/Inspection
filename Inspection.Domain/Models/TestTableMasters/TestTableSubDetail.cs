using NDS.Shared.Domain.Contracts;
using System.ComponentModel.DataAnnotations.Schema;

namespace Inspection.Domain.Models.TestTableMasters
{
    [Table("TestTableSubDetail", Schema = "Inspection")]

    public class TestTableSubDetail : IRootEntity
    {
        public long Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public long TestTableDetailId { get; set; }
    }
}