using Inspection.Application.Contracts.Dto.TestTableSubDetails;
using Inspection.Domain.Models.TestTableMasters;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inspection.Application.Contracts.Dto.TestTableDetails
{
    public class CreateTestTableDetailDto 
    {
        [Required]
        public string Name { get; set; } = default!;
     
        public long TestTableMasterId { get; set; }

        public IEnumerable<TestTableSubDetailDto> TestTableSubDetails { get; set; }




    }
}
