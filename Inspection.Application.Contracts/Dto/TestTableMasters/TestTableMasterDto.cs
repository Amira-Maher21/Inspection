using Inspection.Application.Contracts.Dto.TestTableDetails;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inspection.Application.Contracts.Dto.TestTableMasters
{
    public class TestTableMasterDto
    {
        public long Id { get; set; }
        [Required]
        public string Name { get; set; }
        public IEnumerable<TestTableDetailDto> TestTableDetails { get; set; }
    }
}
