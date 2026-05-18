using Inspection.Application.Contracts.Dto.TestTableDetails;
using Inspection.Domain.Models.TestTableMasters;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inspection.Application.Contracts.Dto.TestTableMasters
{
    public class CreateTestTableMasterDto
    {
        [Required]
        public string Name { get; set; } = default!;

        public IEnumerable<TestTableDetailDto> TestTableDetails { get; set; }

    }
}
