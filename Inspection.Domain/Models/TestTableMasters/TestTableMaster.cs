using Inspection.Domain.Models.TestTableMasters;
using NDS.Shared.Domain.Contracts;
using System.ComponentModel.DataAnnotations.Schema;

namespace Inspection.Domain.Models.TestTableMaster
{
    [Table("TestTableMaster", Schema = "Inspection")]

    public class TestTableMaster : IRootEntity
    {
        public long Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public IEnumerable<TestTableDetail> TestTableDetails { get; set; }

    }
}