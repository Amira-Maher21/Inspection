using NDS.Shared.Domain.Contracts;
using System.ComponentModel.DataAnnotations.Schema;

namespace Inspection.Domain.Models.TestTableMasters
{
    [Table("TestTableDetail", Schema = "Inspection")]

    public class TestTableDetail : IRootEntity
    {
        public long Id { get; set; }
        public long TestTableMasterId { get; set; }
        public string Name { get; set; } = string.Empty;
        public IEnumerable<TestTableSubDetail> TestTableSubDetails { get; set; }

    }
}