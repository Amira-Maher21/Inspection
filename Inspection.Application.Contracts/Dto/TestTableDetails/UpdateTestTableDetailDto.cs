using Inspection.Application.Contracts.Dto.TestTableSubDetails;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inspection.Application.Contracts.Dto.TestTableDetails
{
    public class UpdateTestTableDetailDto
    {
        public long Id { get; set; }
        [Required]
        public string Name { get; set; } = default!;

        public long TestTableMasterId { get; set; }
        public IEnumerable<TestTableSubDetailDto> TestTableSubDetails { get; set; }
    }
}
