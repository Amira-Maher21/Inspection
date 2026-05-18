using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inspection.Application.Contracts.Dto.TestTableSubDetail
{
    public class TestTableSubDetailDtoByInclude
    {
        [Required]
        public string Name { get; set; } = default!;

        public long TestTableDetailsId { get; set; }
    }
}
